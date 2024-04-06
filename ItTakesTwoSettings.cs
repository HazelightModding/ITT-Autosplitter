using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.Model;
using static System.Windows.Forms.AxHost;
using static LiveSplit.ItTakesTwo.ItTakesTwoStatics;

namespace LiveSplit.ItTakesTwo {
    public partial class ItTakesTwoSettings : UserControl {
        private ItTakesTwoComponent itt;
        public bool Ordered { get; set; }
        public List<SplitName> Splits { get; private set; }
        public SplitName? StartTrigger { get; set; }
        public SplitName? ResetTrigger { get; set; }
        private bool isLoading;
        private List<string> availableSplits = new List<string>();
        private List<string> availableSplitsAlphaSorted = new List<string>();

        public ItTakesTwoSettings(ItTakesTwoComponent mainComp) {
            this.itt = mainComp;
            isLoading = true;
            InitializeComponent();
            string version = typeof(ItTakesTwoComponent).Assembly.GetName().Version.ToString();
#if DEBUG
            version += "-dev";
#endif
            this.versionLabel.Text = "Autosplitter Version: " + version;

            Splits = new List<SplitName>();

            StartTriggerComboBox.DataSource = GetAvailableSplits();
            // Comboboxes synchronize if we don't do this lmao
            ResetTriggerComboBox.BindingContext = new BindingContext();
            ResetTriggerComboBox.DataSource = GetAvailableSplits();
            SetDefaultValues();
            isLoading = false;
        }

        private void SetDefaultValues() {
            StartTriggerComboBox.Text = "Awakening_Start (Checkpoint)";
            ResetTriggerComboBox.Text = "Awakening_Start (Checkpoint)";
        }

        private void WriteLog(string log) {
            itt.WriteLog("[SETTINGS] " + log);
        }

        private void Settings_Load(object sender, EventArgs e) {
            isLoading = true;
            this.flowMain.SuspendLayout();

            for (int i = flowMain.Controls.Count - 1; i > 0; i--) {
                flowMain.Controls.RemoveAt(i);
            }

            chkOrdered.Checked = Ordered;
            StartTriggerCheckBox.Checked = StartTrigger != null;
            ResetTriggerCheckBox.Checked = ResetTrigger != null;

            foreach (SplitName split in Splits) {
                string desc = GetDescription(split.ToString());
                ItTakesTwoSplitSettings setting = new ItTakesTwoSplitSettings();
                setting.cboName.DataSource = new List<string>() { desc };
                setting.cboName.Enabled = false;
                setting.cboName.Text = desc;
                AddHandlers(setting);

                flowMain.Controls.Add(setting);
            }

            isLoading = false;
            this.flowMain.ResumeLayout(true);
        }



        private void AddSplit(ItTakesTwoSplitSettings setting, bool below = false) {
            if (setting == null) return;

            int index = GetSplitIndex(setting) + (below ? 1 : 0);

            ItTakesTwoSplitSettings newsetting = createSetting();
            flowMain.Controls.Add(newsetting);
            flowMain.Controls.SetChildIndex(newsetting, index);
            UpdateSplits();
        }

        private void RemoveSplit(ItTakesTwoSplitSettings setting) {
            if (setting == null) return;

            RemoveHandlers(setting);
            flowMain.Controls.RemoveAt(GetSplitIndex(setting));
        }

        private int GetSplitIndex(ItTakesTwoSplitSettings setting) {
            return setting.Parent.Controls.GetChildIndex(setting);
        }

        private ItTakesTwoSplitSettings GetSplitSetting(object sender) {
            for (int i = flowMain.Controls.Count - 1; i > 0; i--) {
                if (flowMain.Controls[i].Contains((Control)sender)) {
                    return (ItTakesTwoSplitSettings)((Control)sender).Parent;
                }
            }
            return null;
        }

        private void enableEdit(ItTakesTwoSplitSettings setting) {
            string currentText = setting.cboName.Text;
            setting.btnEdit.Text = "✔";
            setting.cboName.DataSource = GetAvailableSplits();
            setting.cboName.Text = currentText;
            setting.cboName.Enabled = true;
        }
        private void disableEdit(ItTakesTwoSplitSettings setting) {
            setting.btnEdit.Text = "✏";
            setting.cboName.Enabled = false;
        }
        
        public void UpdateSplits() {
            if (isLoading) return;

            Ordered = chkOrdered.Checked;

            StartTrigger = StartTriggerCheckBox.Checked ? GetSplitName(StartTriggerComboBox.Text) : null;
            ResetTrigger = ResetTriggerCheckBox.Checked ? GetSplitName(ResetTriggerComboBox.Text) : null;

            Splits.Clear();
            foreach (Control c in flowMain.Controls) {
                if (c is ItTakesTwoSplitSettings) {
                    ItTakesTwoSplitSettings setting = (ItTakesTwoSplitSettings)c;
                    if (!string.IsNullOrEmpty(setting.cboName.Text)) {
                        SplitName split = GetSplitName(setting.cboName.Text);
                        Splits.Add(split);
                    }
                }
            }
        }
        public XmlNode UpdateSettings(XmlDocument document) {
            XmlElement xmlSettings = document.CreateElement("Settings");

            XmlElement xmlOrdered = document.CreateElement("Ordered");
            xmlOrdered.InnerText = Ordered.ToString();
            xmlSettings.AppendChild(xmlOrdered);

            XmlElement xmlStartTrigger = document.CreateElement("StartTrigger");
            xmlStartTrigger.InnerText = StartTrigger.ToString();
            xmlSettings.AppendChild(xmlStartTrigger);

            XmlElement xmlResetTrigger = document.CreateElement("ResetTrigger");
            xmlResetTrigger.InnerText = ResetTrigger.ToString();
            xmlSettings.AppendChild(xmlResetTrigger);

            XmlElement xmlSplits = document.CreateElement("Splits");
            xmlSettings.AppendChild(xmlSplits);

            foreach (SplitName split in Splits) {
                XmlElement xmlSplit = document.CreateElement("Split");
                xmlSplit.InnerText = split.ToString();

                xmlSplits.AppendChild(xmlSplit);
            }

            return xmlSettings;
        }
        public void SetSettings(XmlNode settings) {
            XmlNode orderedNode = settings.SelectSingleNode(".//Ordered");
            XmlNode StartTriggerNode = settings.SelectSingleNode(".//StartTrigger");
            XmlNode ResetTriggerNode = settings.SelectSingleNode(".//ResetTrigger");
            bool isOrdered = false;

            if (orderedNode != null) {
                bool.TryParse(orderedNode.InnerText, out isOrdered);
            }
            if (StartTriggerNode != null) {
                string splitDescription = StartTriggerNode.InnerText.Trim();
                if (!string.IsNullOrEmpty(splitDescription)) {
                    StartTrigger = GetSplitName(splitDescription);
                    StartTriggerComboBox.Text = GetDescription(StartTrigger.ToString());
                    StartTriggerCheckBox.Checked = true;
                }
            }
            if (ResetTriggerNode != null) {
                string splitDescription = ResetTriggerNode.InnerText.Trim();
                if (!string.IsNullOrEmpty(splitDescription)) {
                    ResetTrigger = GetSplitName(splitDescription);
                    ResetTriggerComboBox.Text = GetDescription(ResetTrigger.ToString());
                    ResetTriggerCheckBox.Checked = true;
                }
            }
            Ordered = isOrdered;

            Splits.Clear();
            XmlNodeList splitNodes = settings.SelectNodes(".//Splits/Split");
            foreach (XmlNode splitNode in splitNodes) {
                string splitDescription = splitNode.InnerText;
                SplitName split = GetSplitName(splitDescription);
                Splits.Add(split);
            }
        }
        private ItTakesTwoSplitSettings createSetting() {
            ItTakesTwoSplitSettings setting = new ItTakesTwoSplitSettings();
            List<string> splitNames = GetAvailableSplits();
            setting.cboName.DataSource = splitNames;
            setting.cboName.Text = splitNames[0];
            setting.btnEdit.Text = "✔";
            AddHandlers(setting);
            return setting;
        }

        public List<string> GetAvailableSplits() {
            if (availableSplits.Count == 0) {
                foreach (SplitName split in Enum.GetValues(typeof(SplitName))) {
                    string desc = GetDescription(split.ToString());
                    availableSplits.Add(desc);
                    availableSplitsAlphaSorted.Add(desc);
                }
                availableSplitsAlphaSorted.Sort(delegate (string one, string two) {
                    return one.CompareTo(two);
                });
            }
            return rdAlpha.Checked ? availableSplitsAlphaSorted : availableSplits;
        }

        #region Event Handlers
        private void AddHandlers(ItTakesTwoSplitSettings setting) {
            setting.cboName.SelectedIndexChanged += new EventHandler(ControlChanged);
            setting.cboName.SelectedIndexChanged += new EventHandler(ComboBoxSelectedIndexChangedHandler);
            setting.btnRemove.Click += new EventHandler(btnRemove_Click);
            setting.btnEdit.Click += new EventHandler(btnEdit_Click);
            setting.btnAddAbove.Click += new EventHandler(btnAddAbove_Click);
            setting.btnAddBelow.Click += new EventHandler(btnAddBelow_Click);
            setting.cboName.TextUpdate += new EventHandler(ComboBoxTextUpdateHandler);
        }
        private void RemoveHandlers(ItTakesTwoSplitSettings setting) {
            setting.cboName.SelectedIndexChanged -= ControlChanged;
            setting.cboName.SelectedIndexChanged -= ComboBoxSelectedIndexChangedHandler;
            setting.btnRemove.Click -= btnRemove_Click;
            setting.btnEdit.Click -= btnEdit_Click;
            setting.btnAddAbove.Click -= btnAddAbove_Click;
            setting.btnAddBelow.Click -= btnAddBelow_Click;
            setting.cboName.TextUpdate -= ComboBoxTextUpdateHandler;
        }

        

        public void btnEdit_Click(object sender, EventArgs e) {
            ItTakesTwoSplitSettings setting = GetSplitSetting(sender);
            if (setting == null) return;

            if (setting.cboName.Enabled) {
                disableEdit(setting);
            } else {
                enableEdit(setting);
            }
        }
        public void btnRemove_Click(object sender, EventArgs e) {
            RemoveSplit(GetSplitSetting(sender));
            UpdateSplits();
        }
        private void btnAddAbove_Click(object sender, EventArgs e) {
            AddSplit(GetSplitSetting(sender));
        }
        private void btnAddBelow_Click(object sender, EventArgs e) {
            AddSplit(GetSplitSetting(sender), true);
        }

        public void ControlChanged(object sender, EventArgs e) {
            UpdateSplits();
        }
        private void btnAddSplit_Click(object sender, EventArgs e) {
            ItTakesTwoSplitSettings setting = createSetting();
            flowMain.Controls.Add(setting);
            UpdateSplits();
        }

        private void radio_CheckedChanged(object sender, EventArgs e) {
            foreach (Control c in flowMain.Controls) {
                if (c is ItTakesTwoSplitSettings) {
                    ItTakesTwoSplitSettings setting = (ItTakesTwoSplitSettings)c;
                    if (setting.cboName.Enabled) {
                        string text = setting.cboName.Text;
                        setting.cboName.DataSource = GetAvailableSplits();
                        setting.cboName.Text = text;
                    }
                }
            }

            if (StartTriggerCheckBox.Checked) {
                string text = StartTriggerComboBox.Text;
                StartTriggerComboBox.DataSource = GetAvailableSplits();
                StartTriggerComboBox.Text = text;
            }

            if (ResetTriggerCheckBox.Checked) {
                string text = ResetTriggerComboBox.Text;
                ResetTriggerComboBox.DataSource = GetAvailableSplits();
                ResetTriggerComboBox.Text = text;
            }
        }
        private void flowMain_DragDrop(object sender, DragEventArgs e) {
            UpdateSplits();
        }
        private void flowMain_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }
        private void flowMain_DragOver(object sender, DragEventArgs e) {
            ItTakesTwoSplitSettings data = (ItTakesTwoSplitSettings)e.Data.GetData(typeof(ItTakesTwoSplitSettings));
            FlowLayoutPanel destination = (FlowLayoutPanel)sender;
            Point p = destination.PointToClient(new Point(e.X, e.Y));
            var item = destination.GetChildAtPoint(p);
            int index = destination.Controls.GetChildIndex(item, false);
            if (index == 0) {
                e.Effect = DragDropEffects.None;
            } else {
                e.Effect = DragDropEffects.Move;
                int oldIndex = destination.Controls.GetChildIndex(data);
                if (oldIndex != index) {
                    enableEdit(data);
                    destination.Controls.SetChildIndex(data, index);
                    destination.Invalidate();
                }
            }
        }

        private void StartTriggerChanged(object sender, EventArgs e) {
            StartTriggerComboBox.Enabled = StartTriggerCheckBox.Checked;
            UpdateSplits();
        }

        private void ResetTriggerChanged(object sender, EventArgs e) {
            ResetTriggerComboBox.Enabled = ResetTriggerCheckBox.Checked;
            UpdateSplits();
        }

        private void ComboBoxTextUpdateHandler(object sender, EventArgs e) {
            ComboBox comboBox = sender as ComboBox;

            string filter_param = comboBox.Text;
            List<string> splitNames = GetAvailableSplits();

            if (String.IsNullOrWhiteSpace(filter_param)) {
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

        private void ComboBoxSelectedIndexChangedHandler(object sender, EventArgs e) {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox.SelectedIndex == -1) {
                comboBox.Text = "";
                return;
            }

            string splitDescription = comboBox.SelectedValue.ToString();
            SplitName split = GetSplitName(splitDescription);

            ToolTips.SetToolTip(comboBox, GetTooltip(split.ToString()));
            UpdateSplits();
        }
        #endregion

        private void ClearAllButton_Click(object sender, EventArgs e) {
            var clearMessage = MessageBox.Show(
                    "This will clear all your settings! Are you sure?",
                    "LiveSplit | It Takes Two",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning
                );

            if (clearMessage == DialogResult.No) {
                return;
            }

            SetDefaultValues();
            StartTriggerCheckBox.Checked = false;
            ResetTriggerCheckBox.Checked = false;
            chkOrdered.Checked = false;

            List<ItTakesTwoSplitSettings> settingsToRemove = new List< ItTakesTwoSplitSettings >();

            foreach (Control c in flowMain.Controls) {
                if (c is ItTakesTwoSplitSettings) {
                    settingsToRemove.Add((ItTakesTwoSplitSettings)c);
                }
            }

            foreach (var setting in settingsToRemove) {
                RemoveHandlers(setting);
                flowMain.Controls.Remove(setting);
            }

        }

        private void PresetsButton_Click(object sender, EventArgs e) {
            //MessageBox.Show("This will link to a website with presets or something idk lmao", "LiveSplit | It Takes Two", MessageBoxButtons.OK);

            List<ItTakesTwoSplitSettings> settingsToRemove = new List<ItTakesTwoSplitSettings>();

            foreach (Control c in flowMain.Controls) {
                if (c is ItTakesTwoSplitSettings) {
                    settingsToRemove.Add((ItTakesTwoSplitSettings)c);
                }
            }

            foreach (var setting in settingsToRemove) {
                RemoveHandlers(setting);
                flowMain.Controls.Remove(setting);
            }

            StartTriggerComboBox.Text = GetDescription(SplitName.Shed_Awakening_Awakening_Start.ToString());
            ResetTriggerComboBox.Text = GetDescription(SplitName.Shed_Awakening_Awakening_Start.ToString());
            StartTriggerCheckBox.Checked = true;
            ResetTriggerCheckBox.Checked = true;

            /*
            private void AddSplit(ItTakesTwoSplitSettings setting, bool below = false) {
            if (setting == null) return;

            int index = GetSplitIndex(setting) + (below ? 1 : 0);

            ItTakesTwoSplitSettings newsetting = createSetting();
            flowMain.Controls.Add(newsetting);
            flowMain.Controls.SetChildIndex(newsetting, index);
            UpdateSplits();
            }

            private void btnAddSplit_Click(object sender, EventArgs e) {
            ItTakesTwoSplitSettings setting = createSetting();
            flowMain.Controls.Add(setting);
            UpdateSplits();
        }

            */

            SplitName[] anyPercent = {
                SplitName.Vacuum_BP,
                SplitName.Main_Hammernails_BP,
                SplitName.Main_Grindsection_BP,
                SplitName.RealWorld_Shed_StarGazing_Meet_BP,

                SplitName.Approach_BP,
                SplitName.SquirrelHome_BP_Mech,
                SplitName.WaspsNest_BP,
                SplitName.WaspQueenBoss_BP,
                SplitName.Escape_BP,
                SplitName.Start_CS_RealWorld_House_LivingRoom_Headache,

                SplitName.PillowFort_BP,
                SplitName.Spacestation_Hub_BP,
                SplitName.Hopscotch_BP,
                SplitName.Goldberg_Trainstation_BP,
                SplitName.End_CS_PlayRoom_DinoLand_DinoCrash_Intro,
                SplitName.Goldberg_Pirate_BP,
                SplitName.End_CS_PlayRoom_Circus_Balloon_Intro,
                SplitName.Castle_Courtyard_BP,
                SplitName.Castle_Dungeon_BP,
                SplitName.Shelf_BP,
                SplitName.RealWorld_RoseRoom_Bed_Tears_BP,

                SplitName.Clockwork_Tutorial_BP,
                SplitName.Clockwork_ClockTowerLower_CrushingTrapRoom_BP,
                SplitName.Clockwork_ClockTowerLastBoss_BP,
                SplitName.Start_CS_ClockWork_UpperTower_EndingRewind,

                SplitName.SnowGlobe_Forest_BP,
                SplitName.SnowGlobe_Town_BP,
                SplitName.Snowglobe_Lake_BP,
                SplitName.SnowGlobe_Mountain,
                SplitName.SnowGlobe_Tower_TerraceProposalCutscene,

                SplitName.Garden_VegetablePatch_BP,
                SplitName.Garden_Shrubbery_BP,
                SplitName.Garden_MoleTunnels_Stealth_BP,
                SplitName.Garden_FrogPond_BP,
                SplitName.Garden_Greenhouse_BP,
                SplitName.Start_CS_Garden_GreenHouse_BossRoom_Outro,

                SplitName.Music_ConcertHall_BP,
                SplitName.Music_Nightclub_BP,
                SplitName.Music_Ending_BP,
                SplitName.Start_CS_Music_Attic_Stage_ClimacticKiss
            };

            for (int i = 0; i < anyPercent.Length; i++) {
                ItTakesTwoSplitSettings setting = createSetting();
                setting.cboName.Text = GetDescription(anyPercent[i].ToString());
                flowMain.Controls.Add(setting);
            }
            UpdateSplits();
        }
    }
}
