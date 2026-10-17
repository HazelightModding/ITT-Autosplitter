namespace LiveSplit.ItTakesTwo {
    partial class Settings {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.btnAddSplit = new System.Windows.Forms.Button();
            this.flowMain = new System.Windows.Forms.FlowLayoutPanel();
            this.flowOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.Options_GroupBox = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ResetTriggerCutsceneCheckBox = new System.Windows.Forms.CheckBox();
            this.StartTriggerCutsceneCheckBox = new System.Windows.Forms.CheckBox();
            this.TimeWithoutCutsceneCheckBox = new System.Windows.Forms.CheckBox();
            this.ResetTriggerComboBox = new System.Windows.Forms.ComboBox();
            this.OrderedSplitsCheckBox = new System.Windows.Forms.CheckBox();
            this.StartTriggerCheckBox = new System.Windows.Forms.CheckBox();
            this.StartTriggerComboBox = new System.Windows.Forms.ComboBox();
            this.ResetTriggerCheckBox = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.EnableConsoleCheckBox = new System.Windows.Forms.CheckBox();
            this.WikiButton = new System.Windows.Forms.Button();
            this.PresetsButton = new System.Windows.Forms.Button();
            this.ClearAllButton = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.SortBy_GroupBox = new System.Windows.Forms.GroupBox();
            this.rdChapter = new System.Windows.Forms.RadioButton();
            this.rdAlpha = new System.Windows.Forms.RadioButton();
            this.rdType = new System.Windows.Forms.RadioButton();
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.flowMain.SuspendLayout();
            this.flowOptions.SuspendLayout();
            this.Options_GroupBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SortBy_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddSplit
            // 
            this.btnAddSplit.Location = new System.Drawing.Point(6, 128);
            this.btnAddSplit.Name = "btnAddSplit";
            this.btnAddSplit.Size = new System.Drawing.Size(57, 24);
            this.btnAddSplit.TabIndex = 0;
            this.btnAddSplit.Text = "Add Split";
            this.btnAddSplit.UseVisualStyleBackColor = true;
            this.btnAddSplit.Click += new System.EventHandler(this.btnAddSplit_Click);
            // 
            // flowMain
            // 
            this.flowMain.AllowDrop = true;
            this.flowMain.AutoSize = true;
            this.flowMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowMain.Controls.Add(this.flowOptions);
            this.flowMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowMain.Location = new System.Drawing.Point(0, 0);
            this.flowMain.Margin = new System.Windows.Forms.Padding(0);
            this.flowMain.Name = "flowMain";
            this.flowMain.Size = new System.Drawing.Size(465, 167);
            this.flowMain.TabIndex = 0;
            this.flowMain.WrapContents = false;
            this.flowMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.flowMain_DragDrop);
            this.flowMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.flowMain_DragEnter);
            this.flowMain.DragOver += new System.Windows.Forms.DragEventHandler(this.flowMain_DragOver);
            // 
            // flowOptions
            // 
            this.flowOptions.AutoSize = true;
            this.flowOptions.Controls.Add(this.Options_GroupBox);
            this.flowOptions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowOptions.Location = new System.Drawing.Point(0, 0);
            this.flowOptions.Margin = new System.Windows.Forms.Padding(0);
            this.flowOptions.Name = "flowOptions";
            this.flowOptions.Size = new System.Drawing.Size(465, 167);
            this.flowOptions.TabIndex = 0;
            // 
            // Options_GroupBox
            // 
            this.Options_GroupBox.Controls.Add(this.tabControl1);
            this.Options_GroupBox.Controls.Add(this.WikiButton);
            this.Options_GroupBox.Controls.Add(this.PresetsButton);
            this.Options_GroupBox.Controls.Add(this.ClearAllButton);
            this.Options_GroupBox.Controls.Add(this.btnAddSplit);
            this.Options_GroupBox.Controls.Add(this.versionLabel);
            this.Options_GroupBox.Controls.Add(this.SortBy_GroupBox);
            this.Options_GroupBox.Location = new System.Drawing.Point(3, 3);
            this.Options_GroupBox.Name = "Options_GroupBox";
            this.Options_GroupBox.Size = new System.Drawing.Size(459, 161);
            this.Options_GroupBox.TabIndex = 6;
            this.Options_GroupBox.TabStop = false;
            this.Options_GroupBox.Text = "Options";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(130, 15);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(323, 109);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ResetTriggerCutsceneCheckBox);
            this.tabPage1.Controls.Add(this.StartTriggerCutsceneCheckBox);
            this.tabPage1.Controls.Add(this.TimeWithoutCutsceneCheckBox);
            this.tabPage1.Controls.Add(this.ResetTriggerComboBox);
            this.tabPage1.Controls.Add(this.OrderedSplitsCheckBox);
            this.tabPage1.Controls.Add(this.StartTriggerCheckBox);
            this.tabPage1.Controls.Add(this.StartTriggerComboBox);
            this.tabPage1.Controls.Add(this.ResetTriggerCheckBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(315, 83);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Run Behavior";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ResetTriggerCutsceneCheckBox
            // 
            this.ResetTriggerCutsceneCheckBox.AutoSize = true;
            this.ResetTriggerCutsceneCheckBox.Location = new System.Drawing.Point(290, 55);
            this.ResetTriggerCutsceneCheckBox.Name = "ResetTriggerCutsceneCheckBox";
            this.ResetTriggerCutsceneCheckBox.Size = new System.Drawing.Size(15, 14);
            this.ResetTriggerCutsceneCheckBox.TabIndex = 15;
            this.ResetTriggerCutsceneCheckBox.UseVisualStyleBackColor = false;
            this.ResetTriggerCutsceneCheckBox.Visible = false;
            // 
            // StartTriggerCutsceneCheckBox
            // 
            this.StartTriggerCutsceneCheckBox.AutoSize = true;
            this.StartTriggerCutsceneCheckBox.Location = new System.Drawing.Point(290, 30);
            this.StartTriggerCutsceneCheckBox.Name = "StartTriggerCutsceneCheckBox";
            this.StartTriggerCutsceneCheckBox.Size = new System.Drawing.Size(15, 14);
            this.StartTriggerCutsceneCheckBox.TabIndex = 14;
            this.StartTriggerCutsceneCheckBox.UseVisualStyleBackColor = false;
            this.StartTriggerCutsceneCheckBox.Visible = false;
            // 
            // TimeWithoutCutsceneCheckBox
            // 
            this.TimeWithoutCutsceneCheckBox.Location = new System.Drawing.Point(104, 5);
            this.TimeWithoutCutsceneCheckBox.Name = "TimeWithoutCutsceneCheckBox";
            this.TimeWithoutCutsceneCheckBox.Size = new System.Drawing.Size(152, 19);
            this.TimeWithoutCutsceneCheckBox.TabIndex = 13;
            this.TimeWithoutCutsceneCheckBox.Text = "Time without Cutscenes";
            this.TimeWithoutCutsceneCheckBox.UseVisualStyleBackColor = true;
            this.TimeWithoutCutsceneCheckBox.CheckedChanged += new System.EventHandler(this.TimeWithoutCutsceneCheckBox_CheckedChanged);
            // 
            // ResetTriggerComboBox
            // 
            this.ResetTriggerComboBox.Enabled = false;
            this.ResetTriggerComboBox.FormattingEnabled = true;
            this.ResetTriggerComboBox.Location = new System.Drawing.Point(95, 51);
            this.ResetTriggerComboBox.Name = "ResetTriggerComboBox";
            this.ResetTriggerComboBox.Size = new System.Drawing.Size(210, 21);
            this.ResetTriggerComboBox.TabIndex = 9;
            // 
            // OrderedSplitsCheckBox
            // 
            this.OrderedSplitsCheckBox.Location = new System.Drawing.Point(6, 5);
            this.OrderedSplitsCheckBox.Name = "OrderedSplitsCheckBox";
            this.OrderedSplitsCheckBox.Size = new System.Drawing.Size(92, 19);
            this.OrderedSplitsCheckBox.TabIndex = 4;
            this.OrderedSplitsCheckBox.Text = "Ordered Splits";
            this.OrderedSplitsCheckBox.UseVisualStyleBackColor = true;
            this.OrderedSplitsCheckBox.CheckedChanged += new System.EventHandler(this.ControlChanged);
            // 
            // StartTriggerCheckBox
            // 
            this.StartTriggerCheckBox.AutoSize = true;
            this.StartTriggerCheckBox.Location = new System.Drawing.Point(6, 30);
            this.StartTriggerCheckBox.Name = "StartTriggerCheckBox";
            this.StartTriggerCheckBox.Size = new System.Drawing.Size(83, 17);
            this.StartTriggerCheckBox.TabIndex = 6;
            this.StartTriggerCheckBox.Text = "Start trigger:";
            this.StartTriggerCheckBox.UseVisualStyleBackColor = true;
            this.StartTriggerCheckBox.CheckedChanged += new System.EventHandler(this.StartTriggerChanged);
            // 
            // StartTriggerComboBox
            // 
            this.StartTriggerComboBox.Enabled = false;
            this.StartTriggerComboBox.FormattingEnabled = true;
            this.StartTriggerComboBox.Location = new System.Drawing.Point(95, 26);
            this.StartTriggerComboBox.Name = "StartTriggerComboBox";
            this.StartTriggerComboBox.Size = new System.Drawing.Size(210, 21);
            this.StartTriggerComboBox.TabIndex = 7;
            // 
            // ResetTriggerCheckBox
            // 
            this.ResetTriggerCheckBox.AutoSize = true;
            this.ResetTriggerCheckBox.Location = new System.Drawing.Point(6, 53);
            this.ResetTriggerCheckBox.Name = "ResetTriggerCheckBox";
            this.ResetTriggerCheckBox.Size = new System.Drawing.Size(89, 17);
            this.ResetTriggerCheckBox.TabIndex = 8;
            this.ResetTriggerCheckBox.Text = "Reset trigger:";
            this.ResetTriggerCheckBox.UseVisualStyleBackColor = true;
            this.ResetTriggerCheckBox.CheckedChanged += new System.EventHandler(this.ResetTriggerChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.EnableConsoleCheckBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(315, 98);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Debug";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // EnableConsoleCheckBox
            // 
            this.EnableConsoleCheckBox.Location = new System.Drawing.Point(6, 6);
            this.EnableConsoleCheckBox.Name = "EnableConsoleCheckBox";
            this.EnableConsoleCheckBox.Size = new System.Drawing.Size(152, 19);
            this.EnableConsoleCheckBox.TabIndex = 14;
            this.EnableConsoleCheckBox.Text = "Enable Console";
            this.EnableConsoleCheckBox.UseVisualStyleBackColor = true;
            this.EnableConsoleCheckBox.CheckedChanged += new System.EventHandler(this.EnableConsoleCheckBox_CheckedChanged);
            // 
            // WikiButton
            // 
            this.WikiButton.Location = new System.Drawing.Point(203, 128);
            this.WikiButton.Name = "WikiButton";
            this.WikiButton.Size = new System.Drawing.Size(55, 24);
            this.WikiButton.TabIndex = 10;
            this.WikiButton.Text = "Wiki";
            this.WikiButton.UseVisualStyleBackColor = true;
            this.WikiButton.Click += new System.EventHandler(this.WikiButton_Click);
            // 
            // PresetsButton
            // 
            this.PresetsButton.Location = new System.Drawing.Point(138, 128);
            this.PresetsButton.Name = "PresetsButton";
            this.PresetsButton.Size = new System.Drawing.Size(55, 24);
            this.PresetsButton.TabIndex = 9;
            this.PresetsButton.Text = "Presets";
            this.PresetsButton.UseVisualStyleBackColor = true;
            this.PresetsButton.Click += new System.EventHandler(this.PresetsButton_Click);
            // 
            // ClearAllButton
            // 
            this.ClearAllButton.Location = new System.Drawing.Point(73, 128);
            this.ClearAllButton.Name = "ClearAllButton";
            this.ClearAllButton.Size = new System.Drawing.Size(55, 24);
            this.ClearAllButton.TabIndex = 8;
            this.ClearAllButton.Text = "Clear";
            this.ClearAllButton.UseVisualStyleBackColor = true;
            this.ClearAllButton.Click += new System.EventHandler(this.ClearAllButton_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.Location = new System.Drawing.Point(271, 128);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(182, 24);
            this.versionLabel.TabIndex = 7;
            this.versionLabel.Text = "Autosplitter Version: x.x.x.x";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SortBy_GroupBox
            // 
            this.SortBy_GroupBox.Controls.Add(this.rdChapter);
            this.SortBy_GroupBox.Controls.Add(this.rdAlpha);
            this.SortBy_GroupBox.Controls.Add(this.rdType);
            this.SortBy_GroupBox.Location = new System.Drawing.Point(6, 15);
            this.SortBy_GroupBox.Name = "SortBy_GroupBox";
            this.SortBy_GroupBox.Size = new System.Drawing.Size(118, 105);
            this.SortBy_GroupBox.TabIndex = 6;
            this.SortBy_GroupBox.TabStop = false;
            this.SortBy_GroupBox.Text = "Sort Split Selects By";
            // 
            // rdChapter
            // 
            this.rdChapter.AutoSize = true;
            this.rdChapter.Location = new System.Drawing.Point(6, 65);
            this.rdChapter.Name = "rdChapter";
            this.rdChapter.Size = new System.Drawing.Size(62, 17);
            this.rdChapter.TabIndex = 4;
            this.rdChapter.Text = "Chapter";
            this.rdChapter.UseVisualStyleBackColor = true;
            this.rdChapter.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // rdAlpha
            // 
            this.rdAlpha.AutoSize = true;
            this.rdAlpha.Location = new System.Drawing.Point(6, 42);
            this.rdAlpha.Name = "rdAlpha";
            this.rdAlpha.Size = new System.Drawing.Size(83, 17);
            this.rdAlpha.TabIndex = 3;
            this.rdAlpha.Text = "Alphabetical";
            this.rdAlpha.UseVisualStyleBackColor = true;
            this.rdAlpha.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // rdType
            // 
            this.rdType.AutoSize = true;
            this.rdType.Checked = true;
            this.rdType.Location = new System.Drawing.Point(6, 19);
            this.rdType.Name = "rdType";
            this.rdType.Size = new System.Drawing.Size(49, 17);
            this.rdType.TabIndex = 2;
            this.rdType.TabStop = true;
            this.rdType.Text = "Type";
            this.rdType.UseVisualStyleBackColor = true;
            this.rdType.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // ToolTips
            // 
            this.ToolTips.ShowAlways = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(465, 167);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.flowMain.ResumeLayout(false);
            this.flowMain.PerformLayout();
            this.flowOptions.ResumeLayout(false);
            this.Options_GroupBox.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.SortBy_GroupBox.ResumeLayout(false);
            this.SortBy_GroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddSplit;
        private System.Windows.Forms.FlowLayoutPanel flowMain;
        private System.Windows.Forms.FlowLayoutPanel flowOptions;
        private System.Windows.Forms.RadioButton rdType;
        private System.Windows.Forms.RadioButton rdAlpha;
        private System.Windows.Forms.CheckBox OrderedSplitsCheckBox;
        private System.Windows.Forms.GroupBox Options_GroupBox;
        private System.Windows.Forms.ToolTip ToolTips;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.GroupBox SortBy_GroupBox;
        private System.Windows.Forms.CheckBox StartTriggerCheckBox;
        private System.Windows.Forms.ComboBox StartTriggerComboBox;
        private System.Windows.Forms.CheckBox ResetTriggerCheckBox;
        private System.Windows.Forms.ComboBox ResetTriggerComboBox;
        private System.Windows.Forms.Button PresetsButton;
        private System.Windows.Forms.Button ClearAllButton;
        private System.Windows.Forms.Button WikiButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RadioButton rdChapter;
        private System.Windows.Forms.CheckBox TimeWithoutCutsceneCheckBox;
        private System.Windows.Forms.CheckBox EnableConsoleCheckBox;
        private System.Windows.Forms.CheckBox StartTriggerCutsceneCheckBox;
        private System.Windows.Forms.CheckBox ResetTriggerCutsceneCheckBox;
    }
}
