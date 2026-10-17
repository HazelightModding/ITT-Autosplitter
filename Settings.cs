using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using static LiveSplit.ItTakesTwo.Splits;

namespace LiveSplit.ItTakesTwo
{
    public partial class Settings : UserControl
    {
        public Logger Log = Logger.GetLogger("Settings");
        public bool Ordered { get; set; }
        public List<ITTSplit> Splits { get; private set; }
        public ITTSplit StartTrigger { get; set; }
        public ITTSplit ResetTrigger { get; set; }
        public bool TimeWithoutCutscenes { get; set; }
        private bool isLoading;

        private static Settings _settings;
        public static Settings GetOrCreate()
        {
            return _settings ??= new Settings();
        }

        public Settings()
        {
            isLoading = true;
            InitializeComponent();
            string version = typeof(Component).Assembly.GetName().Version.ToString();
#if DEBUG
            version += "-dev";
            EnableConsoleCheckBox.Checked = true;
#endif
            versionLabel.Text = "Autosplitter Version: " + version;

            Splits = new List<ITTSplit>();

            SetupComboBox(StartTriggerComboBox);
            SetupComboBox(ResetTriggerComboBox);
            SetSelectedItemTo(StartTriggerComboBox, "Shed_Awakening_Awakening_Start");
            SetSelectedItemTo(ResetTriggerComboBox, "Shed_Awakening_Awakening_Start");

            isLoading = false;
        }

        public SortMode GetSortMode()
        {
            SortMode mode = SortMode.Alphabetical;
            if (rdType.Checked) mode = SortMode.Type;
            else if (rdChapter.Checked) mode = SortMode.Chapter;

            return mode;
        }

        private void SetSelectedItemTo(ComboBox comboBox, string ID)
        {
            var item = comboBox.Items.OfType<ITTSplitComboBoxItem>().FirstOrDefault(s => s.Split != null && s.Split.ID == ID);
            if (item != null)
                comboBox.SelectedItem = item;
            else
                comboBox.SelectedIndex = -1;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            Log.Debug("Loading settings");
            isLoading = true;
            flowMain.SuspendLayout();

            try
            {
                // Keep first control
                //for (int i = flowMain.Controls.Count - 1; i > 0; i--)
                //{
                //    flowMain.Controls.RemoveAt(i);
                //}

                var watch = Stopwatch.StartNew();
                foreach (var setting in flowMain.Controls.OfType<SplitSettings>().ToList())
                {
                    DestroySetting(setting);
                }
                Log.Debug($"It took {watch.ElapsedMilliseconds} ms to destroy the settings. ");

                OrderedSplitsCheckBox.Checked = Ordered;
                StartTriggerCheckBox.Checked = StartTrigger != null;
                ResetTriggerCheckBox.Checked = ResetTrigger != null;

                watch.Restart();
                foreach (var split in Splits)
                {
                    CreateSetting(split);
                }
                watch.Stop();
                Log.Debug($"It took {watch.ElapsedMilliseconds} ms to create {Splits.Count} settings. ");
                Log.Debug($"With an average of {watch.ElapsedMilliseconds / Splits.Count} ms per split.");
            }
            finally 
            {
                flowMain.ResumeLayout(true);
                isLoading = false;
            }
            
        }



        private void AddSplit(SplitSettings setting, int addIndex = 0)
        {
            if (setting == null) 
                return;

            int index = setting.Parent.Controls.GetChildIndex(setting) + addIndex;
            SplitSettings newsetting = CreateSetting();
            flowMain.Controls.SetChildIndex(newsetting, index);
            UpdateSplits();
        }

        private SplitSettings GetSplitSetting(object sender)
        {
            if (sender is not Control)
                return null;

            var control = sender as Control;

            if (!flowMain.Controls.Contains(control.Parent))
                return null;

            return control.Parent as SplitSettings;
        }

        private void ToggleEdit(SplitSettings setting, bool enabled)
        {
            setting.btnEdit.Text = enabled ? "✔" : "✏";
            setting.splitSettingComboBox.Enabled = enabled;
            setting.ComboBoxCutsceneCheckBox.Enabled = enabled;
        }

        public ITTSplitComboBoxItem UpdateComboBox(ComboBox comboBox, CheckBox checkBox)
        {
            var index = comboBox.SelectedIndex;
            if (index < 0 || index >= comboBox.Items.Count)
                return new();

            var item = comboBox.Items[index] as ITTSplitComboBoxItem;
            if (item.Split != null && item.Split.Type == SplitType.Cutscene)
            {
                if (!checkBox.Visible)
                    comboBox.Width -= checkBox.Width;
                checkBox.Checked = item.Split.SplitAtStart;
                checkBox.Visible = true;
                
            }
            else
            {
                if (checkBox.Visible)
                    comboBox.Width += checkBox.Width;
                checkBox.Visible = false;
            }

            ToolTips.SetToolTip(comboBox, item.Split.Tooltip);

            return item;
        }

        public void UpdateSplits()
        {
            if (isLoading)
                return;

            Ordered = OrderedSplitsCheckBox.Checked;

            if (StartTriggerCheckBox.Checked)
            {
                StartTrigger = UpdateComboBox(StartTriggerComboBox, StartTriggerCutsceneCheckBox).Split;
            }

            if (ResetTriggerCheckBox.Checked)
            {
                ResetTrigger = UpdateComboBox(ResetTriggerComboBox, ResetTriggerCutsceneCheckBox).Split;
            }

            Splits.Clear();

            foreach (Control c in flowMain.Controls)
            {
                if (c is SplitSettings setting)
                {
                    var split = UpdateComboBox(setting.splitSettingComboBox, setting.ComboBoxCutsceneCheckBox).Split;
                    Splits.Add(split);
                }
            }
        }

        public XmlElement CreateSplitXmlElement(XmlDocument document, ITTSplit split, string elementName)
        {
            XmlElement element = document.CreateElement(elementName);
            if (split != null)
            {
                element.InnerText = split.ID;
                if (split.Type == SplitType.Cutscene)
                {
                    element.SetAttribute("SplitAtStart", split.SplitAtStart.ToString());
                }
            }

            return element;
        }
        public XmlNode UpdateSettings(XmlDocument document)
        {
            XmlElement xmlSettings = document.CreateElement("Settings");

            XmlElement xmlOrdered = document.CreateElement("Ordered");
            xmlOrdered.InnerText = Ordered.ToString();
            xmlSettings.AppendChild(xmlOrdered);

            XmlElement xmlTimeWithoutCutscenes = document.CreateElement("TimeWithoutCutscenes");
            xmlTimeWithoutCutscenes.InnerText = TimeWithoutCutscenes.ToString();
            xmlSettings.AppendChild(xmlTimeWithoutCutscenes);

            xmlSettings.AppendChild(CreateSplitXmlElement(document, StartTrigger, "StartTrigger"));
            xmlSettings.AppendChild(CreateSplitXmlElement(document, ResetTrigger, "ResetTrigger"));

            XmlElement xmlSplits = document.CreateElement("Splits");
            xmlSettings.AppendChild(xmlSplits);

            foreach (ITTSplit split in Splits)
            {
                xmlSplits.AppendChild(CreateSplitXmlElement(document, split, "Split"));
            }

            return xmlSettings;
        }

        public bool SetSplitFromXmlNode(XmlNode node, out ITTSplit split)
        {
            split = null;
            if (node == null)
                return false;

            string splitDescription = node.InnerText.Trim();
            split = SplitInfo.GetSplit(splitDescription);
            if (split == null)
                return false;

            bool value = false;
            var SplitAtStart = node.Attributes["SplitAtStart"];
            if (SplitAtStart != null)
                bool.TryParse(SplitAtStart.InnerText, out value);

            split.SplitAtStart = value;
            return true;
        }

        public void SetSettings(XmlNode settings)
        {
            List<string> failed = new();

            XmlNode orderedNode = settings.SelectSingleNode(".//Ordered");
            XmlNode timeWithoutCutscenesNode = settings.SelectSingleNode(".//TimeWithoutCutscenes");
            XmlNode StartTriggerNode = settings.SelectSingleNode(".//StartTrigger");
            XmlNode ResetTriggerNode = settings.SelectSingleNode(".//ResetTrigger");

            if (orderedNode != null && bool.TryParse(orderedNode.InnerText, out bool isOrdered))
                Ordered = isOrdered;

            if (timeWithoutCutscenesNode != null && bool.TryParse(timeWithoutCutscenesNode.InnerText, out bool isTimedWithoutCutscenes))
                TimeWithoutCutsceneCheckBox.Checked = isTimedWithoutCutscenes;

            ITTSplit split = null;
            if (SetSplitFromXmlNode(StartTriggerNode, out split))
            {
                StartTrigger = split;
                SetSelectedItemTo(StartTriggerComboBox, split.ID);
                StartTriggerCheckBox.Checked = split.SplitAtStart;
            }    
            else
                failed.Add(StartTriggerNode.InnerText.Trim());

            if (SetSplitFromXmlNode(ResetTriggerNode, out split))
            {
                ResetTrigger = split;
                SetSelectedItemTo(ResetTriggerComboBox, split.ID);
                ResetTriggerCheckBox.Checked = split.SplitAtStart;
            } 
            else
                failed.Add(ResetTriggerNode.InnerText.Trim());

            Splits.Clear();
            XmlNodeList splitNodes = settings.SelectNodes(".//Splits/Split");
            foreach (XmlNode splitNode in splitNodes)
            {
                if (SetSplitFromXmlNode(splitNode, out split))
                {
                    Splits.Add(split);
                }
                else
                {
                    failed.Add(splitNode.InnerText.Trim());
                }
            }

            foreach (var failedSplit in failed)
            {
                Log.Warning("No setting named \"" + failedSplit + "\"");
            }
        }
        private SplitSettings CreateSetting(ITTSplit split = null)
        {
            var total = Stopwatch.StartNew();
            var watch = Stopwatch.StartNew();

            SplitSettings setting = new SplitSettings();
            SetupComboBox(setting.splitSettingComboBox);

            Log.Debug($"CreateSetting SetupComboBox took {watch.ElapsedMilliseconds} ms to execute. ");
            watch.Restart();

            setting.btnEdit.Text = "✔";
            setting.splitSettingComboBox.SelectedIndexChanged += ControlChanged;
            setting.btnRemove.Click += btnRemove_Click;
            setting.btnEdit.Click += btnEdit_Click;
            setting.btnAddAbove.Click += btnAddAbove_Click;
            setting.btnAddBelow.Click += btnAddBelow_Click;
            setting.ComboBoxCutsceneCheckBox.CheckedChanged += ControlChanged;

            Log.Debug($"CreateSetting event subscriptions took {watch.ElapsedMilliseconds} ms to execute. ");
            watch.Restart();

            flowMain.Controls.Add(setting);

            Log.Debug($"CreateSetting adding to control took {watch.ElapsedMilliseconds} ms to execute. ");
            watch.Restart();

            if (split != null)
            {
                SetSelectedItemTo(setting.splitSettingComboBox, split.ID);

                if (split.Type == SplitType.Cutscene)
                    setting.ComboBoxCutsceneCheckBox.Checked = split.SplitAtStart;

                Log.Debug($"CreateSetting set selected item took {watch.ElapsedMilliseconds} ms to execute. ");
                watch.Stop();
            }

            watch.Stop();
            Log.Debug($"CreateSetting took {total.ElapsedMilliseconds} ms to execute. ");

            return setting;
        }

        private void DestroySetting(SplitSettings setting)
        {
            setting.splitSettingComboBox.SelectedIndexChanged -= ControlChanged;
            setting.btnRemove.Click -= btnRemove_Click;
            setting.btnEdit.Click -= btnEdit_Click;
            setting.btnAddAbove.Click -= btnAddAbove_Click;
            setting.btnAddBelow.Click -= btnAddBelow_Click;
            setting.ComboBoxCutsceneCheckBox.CheckedChanged -= ControlChanged;

            flowMain.Controls.Remove(setting);
        }

        #region Event Handlers

        public void ControlChanged(object sender, EventArgs e) => UpdateSplits();
        public void btnEdit_Click(object sender, EventArgs e)
        {
            SplitSettings setting = GetSplitSetting(sender);

            if (setting == null) 
                return;

            ToggleEdit(setting, !setting.splitSettingComboBox.Enabled);
        }
        public void btnRemove_Click(object sender, EventArgs e)
        {
            DestroySetting(GetSplitSetting(sender));
            UpdateSplits();
        }
        private void btnAddAbove_Click(object sender, EventArgs e) => AddSplit(GetSplitSetting(sender));
        private void btnAddBelow_Click(object sender, EventArgs e) => AddSplit(GetSplitSetting(sender), 1);

        private void btnAddSplit_Click(object sender, EventArgs e)
        {
            CreateSetting();
            UpdateSplits();
        }

        private void UpdateDataSource(ComboBox comboBox, List<ITTSplitComboBoxItem> list)
        {
            comboBox.BeginUpdate();
            comboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;

            var savedItem = comboBox.SelectedItem as ITTSplitComboBoxItem;


            comboBox.DataSource = (new BindingSource().DataSource = list);

            if (savedItem != null && !savedItem.IsHeader && savedItem.Split != null)
                SetSelectedItemTo(comboBox, savedItem.Split.ID);
            else
                comboBox.SelectedIndex = -1;

            comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboBox.EndUpdate();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, bool wParam, int lParam);

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio == null || !radio.Checked)
                return;

            SendMessage(flowMain.Handle, 11, false, 0);
            try
            {
                var list = GetGroupedSplits(GetSortMode());

                UpdateDataSource(StartTriggerComboBox, list);
                UpdateDataSource(ResetTriggerComboBox, list);

                foreach (var item in flowMain.Controls.OfType<SplitSettings>())
                {
                    UpdateDataSource(item.splitSettingComboBox, list);
                }
            }
            finally
            {
                SendMessage(flowMain.Handle, 11, true, 0);
                flowMain.Refresh();
            }
        }
        private void flowMain_DragDrop(object sender, DragEventArgs e) => UpdateSplits();
        private void flowMain_DragEnter(object sender, DragEventArgs e) => e.Effect = DragDropEffects.Move;
        private void flowMain_DragOver(object sender, DragEventArgs e)
        {
            SplitSettings data = e.Data.GetData(typeof(SplitSettings)) as SplitSettings;
            FlowLayoutPanel destination = sender as FlowLayoutPanel;

            Point p = destination.PointToClient(new Point(e.X, e.Y));
            var item = destination.GetChildAtPoint(p);
            int index = destination.Controls.GetChildIndex(item, false);
            if (index == 0)
            {
                e.Effect = DragDropEffects.None;
            }
            else
            {
                e.Effect = DragDropEffects.Move;
                int oldIndex = destination.Controls.GetChildIndex(data);
                if (oldIndex != index)
                {
                    ToggleEdit(data, true);
                    destination.Controls.SetChildIndex(data, index);
                    destination.Invalidate();
                }
            }
        }

        private void StartTriggerChanged(object sender, EventArgs e)
        {
            StartTriggerComboBox.Enabled = StartTriggerCheckBox.Checked;
            StartTriggerCutsceneCheckBox.Enabled = StartTriggerCheckBox.Checked;
            UpdateSplits();
        }

        private void ResetTriggerChanged(object sender, EventArgs e)
        {
            ResetTriggerComboBox.Enabled = ResetTriggerCheckBox.Checked;
            ResetTriggerCutsceneCheckBox.Enabled = ResetTriggerCheckBox.Checked;
            UpdateSplits();
        }
        #endregion

        private void ClearAllButton_Click(object sender, EventArgs e)
        {
            var clearMessage = MessageBox.Show(
                    "This will clear all your settings! Are you sure?",
                    "LiveSplit | It Takes Two",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning
            );

            if (clearMessage == DialogResult.No)
                return;

            flowMain.SuspendLayout();
            StartTriggerCheckBox.Checked = false;
            ResetTriggerCheckBox.Checked = false;
            OrderedSplitsCheckBox.Checked = false;

            foreach (var setting in flowMain.Controls.OfType<SplitSettings>())
            {
                DestroySetting(setting);
            }
            flowMain.ResumeLayout(true);

        }

        private void WikiButton_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://wiki.itt.run/",
                UseShellExecute = true
            });
        }

        private void PresetsButton_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.speedrun.com/itt/resources",
                UseShellExecute = true
            });
        }

        public enum SortMode
        {
            Alphabetical,
            Type,
            Chapter
        }

        

        public class ITTSplitComboBoxItem
        {
            public ITTSplit Split { get; set; }
            public string GroupHeader { get; set; }
            public bool IsHeader => GroupHeader != null;
            public Color BackgroundColor = Color.FromArgb(230, 216, 173);
            public override string ToString()
            {
                if (IsHeader) 
                    return GroupHeader;

                if (Split != null)
                    return $"[{Split.ID}] \n{Split.Name} ({Split.Type})";

                return "";
            }
        }
        public List<ITTSplitComboBoxItem> GetGroupedSplits(SortMode mode)
        {
            var result = new List<ITTSplitComboBoxItem>();
            IEnumerable<IGrouping<string, ITTSplit>> groups = null;

            switch (mode)
            {
                case SortMode.Type:
                groups = SplitInfo.GroupBy(s => s.Type.ToString());
                break;

                case SortMode.Chapter:
                groups = SplitInfo.GroupBy(s => s.Subchapter);
                break;

                case SortMode.Alphabetical:
                    result = SplitInfo.OrderBy(s => s.Name)
                    .Select(s => new ITTSplitComboBoxItem { Split = s })
                    .ToList();
                break;
            }

            if (groups != null)
            {
                // Add colors and headers to lists that aren't alphabetical, to make them easier to parse
                var backgroundColors = new List<Color>(){
                    Color.FromArgb(230, 216, 173), /* Soft yellow */
                    Color.FromArgb(173, 230, 187), /* Soft green */
                    Color.FromArgb(173, 216, 230), /* Light blue */
                    Color.FromArgb(187, 173, 230), /* Light Purple */
                    Color.FromArgb(230, 173, 187), /* Soft red */
                };

                foreach (var group in groups)
                {
                    Color c = backgroundColors[0];
                    result.Add(new ITTSplitComboBoxItem { GroupHeader = group.Key, BackgroundColor = c });
                    foreach (var split in group)
                        result.Add(new ITTSplitComboBoxItem { Split = split, BackgroundColor = c });

                    backgroundColors.Add(c);
                    backgroundColors.RemoveAt(0);
                }
            }

            return result;
        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                e.DrawBackground();
                return;
            }

            var comboBox = sender as ComboBox;
            var item = comboBox.Items[e.Index] as ITTSplitComboBoxItem;
            Color backgroundColor = item.BackgroundColor;

           
            // Alternate colours
            if (e.Index % 2 == 0)
                backgroundColor = ControlPaint.Light(backgroundColor, 0.20f);

            // Selected colour
            if ((e.State & DrawItemState.Selected) != 0)
                backgroundColor = ControlPaint.Light(backgroundColor, 0.40f);

            using (var brush = new SolidBrush(backgroundColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            
            using (var g = comboBox.CreateGraphics())
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            

                if (item.IsHeader)
                {
                    e.Graphics.DrawString(item.GroupHeader, Font20Bold, Brushes.Black, e.Bounds);
                }
                else
                {
                    var lines = item.ToString().Split('\n');
                    float y = e.Bounds.Top + (Font.GetHeight(g) / 4);

                    for (int i = 0; i < lines.Length; i++)
                    {
                        var font = i == 0 ? Font10Reg : Font12Bold;
                        float height = font.GetHeight(g);

                        e.Graphics.DrawString(lines[i], font, Brushes.Black, new RectangleF(e.Bounds.Left + 3, y, e.Bounds.Width, height));
                        y += height;
                    }
                }

            }

            e.DrawFocusRectangle();
        }

        private int MaxComboBoxWidth = 0;
        private int GetCalculatedDropDownWidth(ComboBox comboBox)
        {
            if (MaxComboBoxWidth != 0)
                return MaxComboBoxWidth;

            int maxWidth = comboBox.Width;
            using (var g = comboBox.CreateGraphics())
            using (var font = Font12Bold)
            {
                foreach (var item in GetGroupedSplits(GetSortMode()))
                {
                    if (item is null)
                        continue;

                    var size = g.MeasureString(item.ToString(), font);
                    if (size.Width > maxWidth)
                        maxWidth = (int)size.Width;
                }
            }

            MaxComboBoxWidth = maxWidth;
            return MaxComboBoxWidth;
        }

        private void SetupComboBox(ComboBox comboBox)
        {
            var watch = Stopwatch.StartNew();

            comboBox.DrawMode = DrawMode.OwnerDrawVariable;

            comboBox.BindingContext = new BindingContext();
            comboBox.DataSource = GetGroupedSplits(GetSortMode());
            // Default is awakening start
            //SetSelectedItemTo(comboBox, "Shed_Awakening_Awakening_Start");
            comboBox.SelectedIndex = -1;

            comboBox.DropDownWidth = GetCalculatedDropDownWidth(comboBox) + 20;
            comboBox.DropDownHeight = comboBox.DropDownWidth;

            // Idk why this subscription takes forever?? 
            comboBox.MeasureItem += ComboBox_MeasureItem;

            comboBox.DrawItem += ComboBox_DrawItem;
            comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            
            comboBox.TextUpdate += ComboBox_TextUpdate;
            comboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;

            watch.Stop();
            Log.Debug($"SetupComboBox took {watch.ElapsedMilliseconds} ms to execute. ");
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            var index = comboBox.SelectedIndex;
            if (index < 0 || index >= comboBox.Items.Count)
                return;

            var item = comboBox.Items[index] as ITTSplitComboBoxItem;

            // If they clicked on a header, pretend they clicked on the
            // first item under that header instead
            if (item.IsHeader)
            {
                comboBox.SelectedIndex += 1;
                return;
            }
            
            UpdateSplits();
        }

        // I'll fix this later, idc atm
        private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            var item = comboBox.SelectedItem as ITTSplitComboBoxItem;
            if (item == null || item.IsHeader)
                return;

            BeginInvoke((MethodInvoker)delegate { comboBox.Text = item.Split.GetNameWithTag(); });
        }

        private bool isUpdatingComboBoxText = false;
        private void ComboBox_TextUpdate(object sender, EventArgs e)
        {
            if (isUpdatingComboBoxText)
                return;

            var comboBox = sender as ComboBox;
            if (comboBox == null)
                return;

            var items = GetGroupedSplits(GetSortMode());
            var search = comboBox.Text.ToLower();
            var filteredItems = string.IsNullOrEmpty(search) ? items :
                items.Where(item => item.Split != null && (
                    item.Split.ID.ToLower().Contains(search) ||
                    item.Split.Name.ToLower().Contains(search) ||
                    item.Split.Type.ToString().ToLower().Contains(search)
                )).ToList();

            isUpdatingComboBoxText = true;
            comboBox.BeginUpdate();
            comboBox.DataSource = filteredItems;
            comboBox.Text = search;
            comboBox.SelectionStart = search.Length;
            comboBox.SelectionLength = 0;
            comboBox.EndUpdate();
            comboBox.DroppedDown = true;
            isUpdatingComboBoxText = false;
        }

        private void ComboBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            var comboBox = sender as ComboBox;

            if (comboBox == null || e.Index < 0)
                return;

            if (comboBox.SelectedItem is not ITTSplitComboBoxItem item)
                return;

            e.ItemHeight = item.IsHeader ? Font20Bold.Height + 6 : Font10Reg.Height + Font12Bold.Height + 6;
        }

        private static readonly Font Font10Reg  = new Font(SystemFonts.DefaultFont.FontFamily, 10, FontStyle.Regular);
        private static readonly Font Font12Bold = new Font(SystemFonts.DefaultFont.FontFamily, 12, FontStyle.Bold);
        private static readonly Font Font14Bold = new Font(SystemFonts.DefaultFont.FontFamily, 14, FontStyle.Bold);
        private static readonly Font Font20Bold = new Font(SystemFonts.DefaultFont.FontFamily, 20, FontStyle.Bold);

        private void EnableConsoleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Component.ToggleConsole(EnableConsoleCheckBox.Checked);
        }

        private void TimeWithoutCutsceneCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = sender as CheckBox;
            TimeWithoutCutscenes = checkBox.Checked;
        }
    }
}
