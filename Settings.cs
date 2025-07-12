using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
        private bool isLoading;
        private List<string> availableSplits = new();
        private List<string> availableSplitsAlphaSorted = new();
        private List<string> startEnd = new() { "Start", "End" };

        private static Settings a;
        public static Settings GetOrCreate()
        {
            return a ??= new Settings();
        }

        public Settings()
        {
            isLoading = true;
            InitializeComponent();
            string version = typeof(Component).Assembly.GetName().Version.ToString();
#if DEBUG
            version += "-dev";
#endif
            this.versionLabel.Text = "Autosplitter Version: " + version;

            Splits = new List<ITTSplit>();

            StartTriggerComboBox.DataSource = GetAvailableSplits();
            ResetTriggerComboBox.BindingContext = new BindingContext();
            ResetTriggerComboBox.DataSource = GetAvailableSplits();
            StartTriggerStartEnd.DataSource = startEnd;
            ResetTriggerStartEnd.BindingContext = new BindingContext();
            ResetTriggerStartEnd.DataSource = startEnd;
            SetDefaultValues();
            isLoading = false;
        }

        private void SetDefaultValues()
        {
            StartTriggerComboBox.Text = "Awakening_Start (Checkpoint)";
            ResetTriggerComboBox.Text = "Awakening_Start (Checkpoint)";
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            isLoading = true;
            this.flowMain.SuspendLayout();

            for (int i = flowMain.Controls.Count - 1; i > 0; i--)
            {
                flowMain.Controls.RemoveAt(i);
            }

            chkOrdered.Checked = Ordered;
            StartTriggerCheckBox.Checked = StartTrigger != null;
            ResetTriggerCheckBox.Checked = ResetTrigger != null;

            foreach (ITTSplit split in Splits)
            {
                string desc = split.GetNameWithTag();
                SplitSettings setting = new SplitSettings();
                setting.cboName.DataSource = new List<string>() { desc };
                setting.cboName.Enabled = false;
                setting.cboName.Text = desc;

                if (split.Type == SplitType.Cutscene)
                {
                    setting.cboCSStartEnd.DataSource = startEnd;
                    setting.cboCSStartEnd.Enabled = false;
                    setting.cboName.Width = 250;
                    setting.cboCSStartEnd.Visible = true;
                    setting.cboCSStartEnd.Text = split.SplitAtStart ? "Start" : "End";
                }
                AddHandlers(setting);

                flowMain.Controls.Add(setting);
            }

            isLoading = false;
            this.flowMain.ResumeLayout(true);
        }



        private void AddSplit(SplitSettings setting, bool below = false)
        {
            if (setting == null) return;

            int index = GetSplitIndex(setting) + (below ? 1 : 0);

            SplitSettings newsetting = createSetting();
            flowMain.Controls.Add(newsetting);
            flowMain.Controls.SetChildIndex(newsetting, index);
            UpdateSplits();
        }

        private void RemoveSplit(SplitSettings setting)
        {
            if (setting == null) return;

            RemoveHandlers(setting);
            flowMain.Controls.RemoveAt(GetSplitIndex(setting));
        }

        private int GetSplitIndex(SplitSettings setting)
        {
            return setting.Parent.Controls.GetChildIndex(setting);
        }

        private SplitSettings GetSplitSetting(object sender)
        {
            for (int i = flowMain.Controls.Count - 1; i > 0; i--)
            {
                if (flowMain.Controls[i].Contains((Control)sender))
                {
                    return (SplitSettings)((Control)sender).Parent;
                }
            }
            return null;
        }

        private void enableEdit(SplitSettings setting)
        {
            string currentText = setting.cboName.Text;
            setting.btnEdit.Text = "✔";
            setting.cboName.DataSource = GetAvailableSplits();
            setting.cboName.Text = currentText;
            setting.cboName.Enabled = true;

            string currentStartEnd = setting.cboCSStartEnd.Text;
            setting.cboCSStartEnd.DataSource = startEnd;
            setting.cboCSStartEnd.Text = currentStartEnd;
            setting.cboCSStartEnd.Enabled = true;
        }
        private void disableEdit(SplitSettings setting)
        {
            setting.btnEdit.Text = "✏";
            setting.cboName.Enabled = false;
            setting.cboCSStartEnd.Enabled = false;
        }



        public void UpdateSplits()
        {
            if (isLoading) return;

            Ordered = chkOrdered.Checked;

            StartTrigger = null;
            if (StartTriggerCheckBox.Checked)
            {
                StartTrigger = new(SplitInfo.GetSplit(StartTriggerComboBox.Text));
                if (StartTrigger.Type == SplitType.Cutscene)
                {
                    StartTrigger.SplitAtStart = StartTriggerStartEnd.Text == "Start";
                    StartTriggerComboBox.Width = 155;
                    StartTriggerStartEnd.Visible = true;
                }
                else
                {
                    StartTriggerComboBox.Width = 210;
                    StartTriggerStartEnd.Visible = false;
                }
            }

            ResetTrigger = null;
            if (ResetTriggerCheckBox.Checked)
            {
                ResetTrigger = new(SplitInfo.GetSplit(ResetTriggerComboBox.Text));
                if (ResetTrigger.Type == SplitType.Cutscene)
                {
                    ResetTrigger.SplitAtStart = ResetTriggerStartEnd.Text == "Start";
                    ResetTriggerComboBox.Width = 155;
                    ResetTriggerStartEnd.Visible = true;
                }
                else
                {
                    ResetTriggerComboBox.Width = 210;
                    ResetTriggerStartEnd.Visible = false;
                }
            }

            Splits.Clear();
            foreach (Control c in flowMain.Controls)
            {
                if (c is SplitSettings setting)
                {
                    if (!string.IsNullOrEmpty(setting.cboName.Text))
                    {
                        ITTSplit split = new(SplitInfo.GetSplit(setting.cboName.Text));
                        if (split.Type == SplitType.Cutscene)
                        {
                            setting.cboCSStartEnd.DataSource = startEnd;
                            split.SplitAtStart = setting.cboCSStartEnd.Text == "Start";
                            setting.cboName.Width = 250;
                            setting.cboCSStartEnd.Visible = true;
                        }
                        else
                        {
                            setting.cboName.Width = 305;
                            setting.cboCSStartEnd.Visible = false;
                        }
                        Splits.Add(split);
                    }
                }
            }
        }
        public XmlNode UpdateSettings(XmlDocument document)
        {
            XmlElement xmlSettings = document.CreateElement("Settings");

            XmlElement xmlOrdered = document.CreateElement("Ordered");
            xmlOrdered.InnerText = Ordered.ToString();
            xmlSettings.AppendChild(xmlOrdered);

            XmlElement xmlStartTrigger = document.CreateElement("StartTrigger");
            if (StartTrigger != null)
            {
                xmlStartTrigger.InnerText = StartTrigger.ID;
                if (StartTrigger.Type == SplitType.Cutscene)
                {
                    xmlStartTrigger.SetAttribute("SplitAtStart", StartTrigger.SplitAtStart.ToString());
                }
            }
            xmlSettings.AppendChild(xmlStartTrigger);

            XmlElement xmlResetTrigger = document.CreateElement("ResetTrigger");
            if (ResetTrigger != null)
            {
                xmlResetTrigger.InnerText = ResetTrigger.ID;
                if (ResetTrigger.Type == SplitType.Cutscene)
                {
                    xmlResetTrigger.SetAttribute("SplitAtStart", ResetTrigger.SplitAtStart.ToString());
                }
            }
            xmlSettings.AppendChild(xmlResetTrigger);

            XmlElement xmlSplits = document.CreateElement("Splits");
            xmlSettings.AppendChild(xmlSplits);

            foreach (ITTSplit split in Splits)
            {
                XmlElement xmlSplit = document.CreateElement("Split");
                if (split != null)
                {
                    xmlSplit.InnerText = split.ID;
                }

                if (split.Type == SplitType.Cutscene)
                {
                    xmlSplit.SetAttribute("SplitAtStart", split.SplitAtStart.ToString());
                }

                xmlSplits.AppendChild(xmlSplit);
            }

            return xmlSettings;
        }
        public void SetSettings(XmlNode settings)
        {
            List<string> failed = new();

            XmlNode orderedNode = settings.SelectSingleNode(".//Ordered");
            XmlNode StartTriggerNode = settings.SelectSingleNode(".//StartTrigger");
            XmlNode ResetTriggerNode = settings.SelectSingleNode(".//ResetTrigger");
            bool isOrdered = false;

            if (orderedNode != null)
            {
                bool.TryParse(orderedNode.InnerText, out isOrdered);
            }

            if (StartTriggerNode != null)
            {
                string splitDescription = StartTriggerNode.InnerText.Trim();
                if (!string.IsNullOrEmpty(splitDescription))
                {
                    StartTrigger = SplitInfo.GetSplit(splitDescription);

                    if (StartTrigger != null)
                    {
                        StartTriggerComboBox.Text = StartTrigger.GetNameWithTag();
                        StartTriggerCheckBox.Checked = true;
                        var SplitAtStart = StartTriggerNode.Attributes["SplitAtStart"];
                        if (SplitAtStart != null)
                        {
                            bool.TryParse(SplitAtStart.InnerText, out bool SplitAtStartValue);
                            StartTrigger.SplitAtStart = SplitAtStartValue;
                        }
                    }

                    if (StartTrigger == null)
                    {
                        failed.Add(splitDescription);
                    }

                }
            }
            if (ResetTriggerNode != null)
            {
                string splitDescription = ResetTriggerNode.InnerText.Trim();
                if (!string.IsNullOrEmpty(splitDescription))
                {
                    ResetTrigger = SplitInfo.GetSplit(splitDescription);

                    if (ResetTrigger != null)
                    {
                        ResetTriggerComboBox.Text = StartTrigger.GetNameWithTag();
                        ResetTriggerCheckBox.Checked = true;
                        var SplitAtStart = ResetTriggerNode.Attributes["SplitAtStart"];
                        if (SplitAtStart != null)
                        {
                            bool.TryParse(SplitAtStart.InnerText, out bool SplitAtStartValue);
                            ResetTrigger.SplitAtStart = SplitAtStartValue;
                        }
                    }

                    if (ResetTrigger == null)
                    {
                        failed.Add(splitDescription);
                    }

                }
            }
            Ordered = isOrdered;

            Splits.Clear();
            XmlNodeList splitNodes = settings.SelectNodes(".//Splits/Split");
            foreach (XmlNode splitNode in splitNodes)
            {
                string splitDescription = splitNode.InnerText;
                ITTSplit split = new(SplitInfo.GetSplit(splitDescription));

                if (split != null)
                {
                    var SplitAtStart = splitNode.Attributes["SplitAtStart"];
                    if (SplitAtStart != null)
                    {
                        bool.TryParse(SplitAtStart.InnerText, out bool SplitAtStartValue);
                        split.SplitAtStart = SplitAtStartValue;
                    }

                    Splits.Add(split);
                }

                if (split == null)
                {
                    failed.Add(splitDescription);
                }


            }

            foreach (var split in failed)
            {
                Log.Warning("No setting named \"" + split + "\"");
            }
        }
        private SplitSettings createSetting()
        {
            SplitSettings setting = new SplitSettings();
            List<string> splitNames = GetAvailableSplits();
            setting.cboName.DataSource = splitNames;
            setting.cboName.Text = splitNames[0];
            setting.btnEdit.Text = "✔";
            AddHandlers(setting);
            return setting;
        }

        public List<string> GetAvailableSplits()
        {
            if (availableSplits.Count == 0)
            {
                foreach (ITTSplit split in SplitInfo)
                {
                    string desc = split.GetNameWithTag();
                    availableSplits.Add(desc);
                    availableSplitsAlphaSorted.Add(desc);
                }
                availableSplitsAlphaSorted.Sort(delegate (string one, string two)
                {
                    return one.CompareTo(two);
                });
            }
            return rdAlpha.Checked ? availableSplitsAlphaSorted : availableSplits;
        }

        #region Event Handlers
        private void AddHandlers(SplitSettings setting)
        {
            setting.cboName.SelectedIndexChanged += new EventHandler(ControlChanged);
            setting.cboName.SelectedIndexChanged += new EventHandler(ComboBoxSelectedIndexChangedHandler);
            setting.btnRemove.Click += new EventHandler(btnRemove_Click);
            setting.btnEdit.Click += new EventHandler(btnEdit_Click);
            setting.btnAddAbove.Click += new EventHandler(btnAddAbove_Click);
            setting.btnAddBelow.Click += new EventHandler(btnAddBelow_Click);
            setting.cboName.TextUpdate += new EventHandler(ComboBoxTextUpdateHandler);
            setting.cboCSStartEnd.SelectedIndexChanged += new EventHandler(ControlChanged);
        }
        private void RemoveHandlers(SplitSettings setting)
        {
            setting.cboName.SelectedIndexChanged -= ControlChanged;
            setting.cboName.SelectedIndexChanged -= ComboBoxSelectedIndexChangedHandler;
            setting.btnRemove.Click -= btnRemove_Click;
            setting.btnEdit.Click -= btnEdit_Click;
            setting.btnAddAbove.Click -= btnAddAbove_Click;
            setting.btnAddBelow.Click -= btnAddBelow_Click;
            setting.cboName.TextUpdate -= ComboBoxTextUpdateHandler;
            setting.cboCSStartEnd.SelectedIndexChanged -= ControlChanged;
        }



        public void btnEdit_Click(object sender, EventArgs e)
        {
            SplitSettings setting = GetSplitSetting(sender);
            if (setting == null) return;

            if (setting.cboName.Enabled)
            {
                disableEdit(setting);
            }
            else
            {
                enableEdit(setting);
            }
        }
        public void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveSplit(GetSplitSetting(sender));
            UpdateSplits();
        }
        private void btnAddAbove_Click(object sender, EventArgs e)
        {
            AddSplit(GetSplitSetting(sender));
        }
        private void btnAddBelow_Click(object sender, EventArgs e)
        {
            AddSplit(GetSplitSetting(sender), true);
        }

        public void ControlChanged(object sender, EventArgs e)
        {
            UpdateSplits();
        }
        private void btnAddSplit_Click(object sender, EventArgs e)
        {
            SplitSettings setting = createSetting();
            flowMain.Controls.Add(setting);
            UpdateSplits();
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control c in flowMain.Controls)
            {
                if (c is SplitSettings)
                {
                    SplitSettings setting = (SplitSettings)c;
                    if (setting.cboName.Enabled)
                    {
                        string text = setting.cboName.Text;
                        setting.cboName.DataSource = GetAvailableSplits();
                        setting.cboName.Text = text;
                    }
                }
            }

            if (StartTriggerCheckBox.Checked)
            {
                string text = StartTriggerComboBox.Text;
                StartTriggerComboBox.DataSource = GetAvailableSplits();
                StartTriggerComboBox.Text = text;
            }

            if (ResetTriggerCheckBox.Checked)
            {
                string text = ResetTriggerComboBox.Text;
                ResetTriggerComboBox.DataSource = GetAvailableSplits();
                ResetTriggerComboBox.Text = text;
            }
        }
        private void flowMain_DragDrop(object sender, DragEventArgs e)
        {
            UpdateSplits();
        }
        private void flowMain_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void flowMain_DragOver(object sender, DragEventArgs e)
        {
            SplitSettings data = (SplitSettings)e.Data.GetData(typeof(SplitSettings));
            FlowLayoutPanel destination = (FlowLayoutPanel)sender;
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
                    enableEdit(data);
                    destination.Controls.SetChildIndex(data, index);
                    destination.Invalidate();
                }
            }
        }

        private void StartTriggerChanged(object sender, EventArgs e)
        {
            StartTriggerComboBox.Enabled = StartTriggerCheckBox.Checked;
            StartTriggerStartEnd.Enabled = StartTriggerCheckBox.Checked;
            UpdateSplits();
        }

        private void ResetTriggerChanged(object sender, EventArgs e)
        {
            ResetTriggerComboBox.Enabled = ResetTriggerCheckBox.Checked;
            ResetTriggerStartEnd.Enabled = ResetTriggerCheckBox.Checked;
            UpdateSplits();
        }

        private void ComboBoxTextUpdateHandler(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            string filter_param = comboBox.Text;
            List<string> splitNames = GetAvailableSplits();

            if (String.IsNullOrWhiteSpace(filter_param))
            {
                comboBox.DataSource = splitNames;
                comboBox.SelectionLength = 100;
                return;
            }

            List<string> filteredItems = splitNames.FindAll(x => x.ToLower().Contains(filter_param.ToLower()));

            comboBox.DataSource = filteredItems;
            comboBox.DroppedDown = true;
            Cursor.Current = Cursors.Default;
            comboBox.IntegralHeight = true;
            comboBox.SelectedIndex = -1;
            comboBox.Text = filter_param;
            comboBox.SelectionStart = filter_param.Length;
            comboBox.SelectionLength = 0;
        }

        private void ComboBoxSelectedIndexChangedHandler(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox.SelectedIndex == -1)
            {
                comboBox.Text = "";
                return;
            }

            string splitDescription = comboBox.SelectedValue.ToString();
            ITTSplit split = SplitInfo.GetSplit(splitDescription);

            ToolTips.SetToolTip(comboBox, split.Tooltip);
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
            {
                return;
            }

            SetDefaultValues();
            StartTriggerCheckBox.Checked = false;
            ResetTriggerCheckBox.Checked = false;
            chkOrdered.Checked = false;

            List<SplitSettings> settingsToRemove = new List<SplitSettings>();

            foreach (Control c in flowMain.Controls)
            {
                if (c is SplitSettings)
                {
                    settingsToRemove.Add((SplitSettings)c);
                }
            }

            foreach (var setting in settingsToRemove)
            {
                RemoveHandlers(setting);
                flowMain.Controls.Remove(setting);
            }

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

    }
}
