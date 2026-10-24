using LiveSplit.UI.Components;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            SetupGridView();
            SetupSplitContextMenu();
            SetupComboBox(StartTriggerComboBox);
            SetupComboBox(ResetTriggerComboBox);
            SetSelectedItemTo(StartTriggerComboBox, "Shed_Awakening_Awakening_Start");
            SetSelectedItemTo(ResetTriggerComboBox, "Shed_Awakening_Awakening_Start");

            isLoading = false;
        }

        private void SetupGridView()
        {
            SplitsDataGridView.VirtualMode = true;
            SplitsDataGridView.AllowUserToAddRows = false;

            var splitsDropdownColumn = new DataGridViewComboBoxColumn()
            {
                HeaderText = "Split",
                Name = "SplitColumn",
                MinimumWidth = 305,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataSource = GetGroupedSplits(GetSortMode()),
                ValueType = typeof(ITTSplitComboBoxItem),
                DisplayMember = nameof(ITTSplitComboBoxItem.DisplayText),
                ValueMember = nameof(ITTSplitComboBoxItem.ID)
            };
            SplitsDataGridView.Columns.Add(splitsDropdownColumn);

            var splitAtStartCheckboxColumn = new DataGridViewCheckBoxColumn()
            {
                HeaderText = "at Start",
                Name = "SplitAtStartCheckboxColumn",
                Width = 30,
                ValueType = typeof(bool)
            };
            SplitsDataGridView.Columns.Add(splitAtStartCheckboxColumn);

            SplitsDataGridView.CellValueNeeded += CellValueNeeded;
            SplitsDataGridView.CellValuePushed += CellValuePushed;
            SplitsDataGridView.EditingControlShowing += EditingControlShowing;
            SplitsDataGridView.CellPainting += CellPainting;
            SplitsDataGridView.CellClick += CellClick;

            SplitsDataGridView.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (SplitsDataGridView.IsCurrentCellDirty)
                    SplitsDataGridView.CommitEdit(
                        DataGridViewDataErrorContexts.Commit);
            };

        }

        private ContextMenuStrip SplitContextMenu;
        private int ContextMenuRowIndex = -1;
        private void SetupSplitContextMenu()
        {
            SplitContextMenu = new ContextMenuStrip();
            SplitContextMenu.Items.Add(
                "Add split above", null, (s, e) => AddSplit(null, ContextMenuRowIndex));
            SplitContextMenu.Items.Add(
                "Add split below", null, (s, e) => AddSplit(null, ContextMenuRowIndex + 1));
            SplitContextMenu.Items.Add(
                "Duplicate split", null, (s, e) =>
                {
                    if (ContextMenuRowIndex < 0 || ContextMenuRowIndex >= Splits.Count)
                        return;

                    var duplicate = SplitInfo.GetSplit(Splits[ContextMenuRowIndex].ID);
                    if (duplicate != null)
                    {
                        duplicate.SplitAtStart = Splits[ContextMenuRowIndex].SplitAtStart;
                        AddSplit(duplicate, ContextMenuRowIndex + 1);
                    }
                });
            SplitContextMenu.Items.Add(
                "Remove split", null, (s, e) => RemoveSplitAt(ContextMenuRowIndex));

            SplitsDataGridView.ContextMenuStrip = SplitContextMenu;
            SplitsDataGridView.CellMouseDown += CellMouseDown;
        }

        private void RefreshSplitsGrid()
        {
            if (Splits.Count <= 0)
                Splits.Add(new ITTSplit(SplitInfo.GetSplit("ManualSplit")));
            SplitsDataGridView.RowCount = Splits.Count;
            SplitsDataGridView.ClearSelection();
            SplitsDataGridView.Invalidate();
        }

        private void CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            ContextMenuRowIndex = e.RowIndex;

            if (ContextMenuRowIndex >= 0 && ContextMenuRowIndex < Splits.Count)
            {
                SplitsDataGridView.ClearSelection();
                SplitsDataGridView.Rows[ContextMenuRowIndex].Selected = true;

                if (e.ColumnIndex >= 0)
                {
                    SplitsDataGridView.CurrentCell = SplitsDataGridView.Rows[ContextMenuRowIndex].Cells[e.ColumnIndex];
                }
            }
        }

        private void CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= Splits.Count)
                return;

            ITTSplit CellSplit = Splits[e.RowIndex];

            if (e.ColumnIndex == 0) // ComboBox Column
            {
                e.Value = CellSplit?.ID;
            }

            if (e.ColumnIndex == 1)
            {
                e.Value = CellSplit?.SplitAtStart;
            }


        }

        private ComboBox CurrentGridComboBox;
        private void EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var columnIndex = SplitsDataGridView.CurrentCell.ColumnIndex;
            var rowIndex = SplitsDataGridView.CurrentCell.RowIndex;

            if (columnIndex == 0 // ComboBox Column
                && e.Control is ComboBox c)
            {
                /*if (CurrentGridComboBox != c)
                {
                    if (CurrentGridComboBox != null)
                    {
                        CurrentGridComboBox.DrawItem -= ComboBox_DrawItem;
                        CurrentGridComboBox.MeasureItem -= ComboBox_MeasureItem;
                    }

                    CurrentGridComboBox = c;
                    CurrentGridComboBox.DrawMode = DrawMode.OwnerDrawVariable;
                    CurrentGridComboBox.DrawItem += ComboBox_DrawItem;
                    CurrentGridComboBox.MeasureItem += ComboBox_MeasureItem;
                }*/
                SetupComboBox(c);
                //SetSelectedItemTo(c, Splits[rowIndex].ID);
                c.SelectedValue = Splits[rowIndex].ID;
                RefreshSplitsGrid();
                
            }
        }

        private void CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= Splits.Count)
                return;

            if (e.ColumnIndex == 0)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    if (SplitsDataGridView.IsDisposed ||
                        SplitsDataGridView.CurrentCell == null ||
                        SplitsDataGridView.CurrentCell.RowIndex != e.RowIndex ||
                        SplitsDataGridView.CurrentCell.ColumnIndex != e.ColumnIndex)
                        return;

                    if (!SplitsDataGridView.IsCurrentCellInEditMode)
                        SplitsDataGridView.BeginEdit(true);

                    if (SplitsDataGridView.EditingControl is ComboBox c)
                        c.DroppedDown = true;
                }));
            }
        }

        private void CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= Splits.Count)
                return;

            if (e.ColumnIndex == 0)
            {
                ITTSplitComboBoxItem item = null;
                if (e.Value is string id)
                    item = GetGroupedSplits(GetSortMode()).FirstOrDefault(
                        s => !s.IsHeader && s.Split?.ID == id); Log.Debug("Value is string");

                if (e.Value is ITTSplitComboBoxItem)
                    item = e.Value as ITTSplitComboBoxItem;

                if (item?.Split != null)
                    Splits[e.RowIndex] = item.Split;
            }
            else if (e.ColumnIndex == 1 && e.Value is bool value)
            {
                var split = Splits[e.RowIndex];

                if (split.Type == SplitType.Cutscene)
                    split.SplitAtStart = value;
            }

            RefreshSplitsGrid();
            //UpdateSplits();
        }

        private void CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= Splits.Count)
                return;

            if (e.ColumnIndex == 1 && Splits[e.RowIndex].Type != SplitType.Cutscene)
            {
                e.PaintBackground(e.ClipBounds, true);
                e.Paint(e.ClipBounds, DataGridViewPaintParts.Border);
                e.Handled = true;
            }
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

            OrderedSplitsCheckBox.Checked = Ordered;
            StartTriggerCheckBox.Checked = StartTrigger != null;
            ResetTriggerCheckBox.Checked = ResetTrigger != null;

            RefreshSplitsGrid();

            isLoading = false;
        }

        private void RemoveSplitAt(int index)
        {
            if (index < 0 || index >= Splits.Count)
                return;

            Splits.RemoveAt(index);
            RefreshSplitsGrid();
        }
        private void AddSplit(ITTSplit inSplit = null, int inIndex = -1)
        {
            inSplit ??= new ITTSplit(SplitInfo.GetSplit("ManualSplit"));

            if (inIndex < 0 || inIndex >= Splits.Count)
            {
                Splits.Add(inSplit);
            }
            else
            {
                Splits.Insert(inIndex, inSplit);
            }

            RefreshSplitsGrid();

            //UpdateSplits();
        }

        private SplitSettings GetSplitSetting(object sender)
        {
            if (sender is not Control)
                return null;

            var control = sender as Control;

            //if (!SplitGroupBox.Controls.Contains(control.Parent))
                return null;

            //return control.Parent as SplitSettings;
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

            // TODO: somehow add tooltips to each item in a dropped down combobox
            // Would also be cool to be able to add images to the tooltips.
            // Doesn't need to be for every split, but some could be useful clarifiers.
            ToolTips.SetToolTip(comboBox, item.Split.Tooltip);

            return item;
        }

        public void UpdateSplits()
        {
            if (isLoading)
                return;

            flowMain.SuspendLayout();

            Ordered = OrderedSplitsCheckBox.Checked;

            if (StartTriggerCheckBox.Checked)
            {
                StartTrigger = UpdateComboBox(StartTriggerComboBox, StartTriggerCutsceneCheckBox).Split;
            }

            if (ResetTriggerCheckBox.Checked)
            {
                ResetTrigger = UpdateComboBox(ResetTriggerComboBox, ResetTriggerCutsceneCheckBox).Split;
            }

            RefreshSplitsGrid();

            flowMain.ResumeLayout();

            /*SplitGroupBox.SuspendLayout();

            

            Splits.Clear();

            foreach (Control c in SplitGroupBox.Controls)
            {
                if (c is SplitSettings setting)
                {
                    var split = UpdateComboBox(setting.splitSettingComboBox, setting.ComboBoxCutsceneCheckBox).Split;
                    Splits.Add(split);
                }
            }

            SplitGroupBox.ResumeLayout(true);*/
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
            split = new ITTSplit(SplitInfo.GetSplit(splitDescription));
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

        #region Event Handlers

        public void ControlChanged(object sender, EventArgs e) => UpdateSplits();
        public void btnEdit_Click(object sender, EventArgs e)
        {
            SplitSettings setting = GetSplitSetting(sender);

            if (setting == null) 
                return;

            ToggleEdit(setting, !setting.splitSettingComboBox.Enabled);
        }

        private void btnAddSplit_Click(object sender, EventArgs e)
        {
            AddSplit();
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio == null || !radio.Checked)
                return;

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

            Splits.Clear();
            RefreshSplitsGrid();

            /*SplitGroupBox.SuspendLayout();
            StartTriggerCheckBox.Checked = false;
            ResetTriggerCheckBox.Checked = false;
            OrderedSplitsCheckBox.Checked = false;

            foreach (var setting in SplitGroupBox.Controls.OfType<SplitSettings>())
            {
                DestroySetting(setting);
            }
            SplitGroupBox.ResumeLayout(true);*/

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
            public string DisplayText => GetNameAndType();
            public string ID => Split?.ID;
            public string GetNameAndType()
            {
                if (IsHeader)
                    return GroupHeader;

                if (Split != null)
                    return $"{Split.Name} ({Split.Type})";

                return "";
            }
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
            var comboBox = sender as ComboBox;

            if (comboBox == null)
                return;

            if (e.Index < 0)
            {
                e.DrawBackground();
                return;
            }

            var item = comboBox.Items[e.Index] as ITTSplitComboBoxItem;

            if (!comboBox.DroppedDown)
            {
                if (item?.Split != null)
                {
                    e.DrawBackground();

                    TextRenderer.DrawText(e.Graphics, item.Split.GetNameWithTag(),
                        comboBox.Font, e.Bounds, comboBox.ForeColor,
                        TextFormatFlags.Left | TextFormatFlags.VerticalCenter |
                        TextFormatFlags.EndEllipsis);

                    e.DrawFocusRectangle();
                    return;
                }
            }
            
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
                    e.Graphics.DrawString(item.GroupHeader, GetFont(20), Brushes.Black, e.Bounds);
                }
                else
                {
                    var lines = item.ToString().Split('\n');
                    float y = e.Bounds.Top + (Font.Height / 4);

                    for (int i = 0; i < lines.Length; i++)
                    {
                        var font = i == 0 ? GetFont(10) : GetFont(12);
                        float height = font.Height;

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
            using (var font = GetFont(12))
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
            comboBox.DrawMode = DrawMode.OwnerDrawVariable;

            comboBox.BindingContext = new BindingContext();
            comboBox.DataSource = GetGroupedSplits(GetSortMode());
            comboBox.SelectedIndex = -1;

            comboBox.DropDownWidth = GetCalculatedDropDownWidth(comboBox) + 20;
            comboBox.DropDownHeight = comboBox.DropDownWidth;

            comboBox.MeasureItem -= ComboBox_MeasureItem;
            comboBox.MeasureItem += ComboBox_MeasureItem;

            comboBox.DrawItem -= ComboBox_DrawItem;
            comboBox.DrawItem += ComboBox_DrawItem;

            comboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
            comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            
            comboBox.TextUpdate -= ComboBox_TextUpdate;
            comboBox.TextUpdate += ComboBox_TextUpdate;

            comboBox.SelectionChangeCommitted -= ComboBox_SelectionChangeCommitted;
            comboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;
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
            var value = comboBox.SelectedValue as string;
            if (string.IsNullOrEmpty(value))
                return;
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

            if (comboBox.Items[e.Index] is not ITTSplitComboBoxItem item)
                return;

            e.ItemHeight = item.IsHeader ? GetFont(20).Height + 6 : GetFont(10).Height + GetFont(12).Height + 6;
        }

        private static Font GetFont(int size)
        {
            if (size == 20)
                return new Font(SystemFonts.DefaultFont.FontFamily, 20, FontStyle.Bold);
            if (size == 10)
                return new Font(SystemFonts.DefaultFont.FontFamily, 10, FontStyle.Regular);
            if (size == 12)
                return new Font(SystemFonts.DefaultFont.FontFamily, 12, FontStyle.Bold);

            return new Font(SystemFonts.DefaultFont.FontFamily, 14, FontStyle.Bold);
        }
        private void EnableConsoleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Component.ToggleConsole(EnableConsoleCheckBox.Checked);
        }

        private void TimeWithoutCutsceneCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = sender as CheckBox;
            TimeWithoutCutscenes = checkBox.Checked;
        }

        private void removeSplitButton_Click(object sender, EventArgs e)
        {
            if (SplitsDataGridView.SelectedCells.Count <= 0)
                return;

            foreach (DataGridViewCell cell in SplitsDataGridView.SelectedCells)
            {
                SplitsDataGridView.Rows[cell.RowIndex].Selected = true;
            }

            for (int i = SplitsDataGridView.SelectedRows.Count - 1; i >= 0; i--)
            {
                Splits.RemoveAt(SplitsDataGridView.SelectedRows[i].Index);
            }

            RefreshSplitsGrid();
        }
    }
}
