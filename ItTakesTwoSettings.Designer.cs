namespace LiveSplit.ItTakesTwo {
    partial class ItTakesTwoSettings {
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
            this.PresetsButton = new System.Windows.Forms.Button();
            this.ClearAllButton = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.RunBehaviour_GroupBox = new System.Windows.Forms.GroupBox();
            this.ResetTriggerComboBox = new System.Windows.Forms.ComboBox();
            this.ResetTriggerCheckBox = new System.Windows.Forms.CheckBox();
            this.StartTriggerComboBox = new System.Windows.Forms.ComboBox();
            this.StartTriggerCheckBox = new System.Windows.Forms.CheckBox();
            this.chkOrdered = new System.Windows.Forms.CheckBox();
            this.SortBy_GroupBox = new System.Windows.Forms.GroupBox();
            this.rdAlpha = new System.Windows.Forms.RadioButton();
            this.rdType = new System.Windows.Forms.RadioButton();
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.CSRemoverCheckBox = new System.Windows.Forms.CheckBox();
            this.flowMain.SuspendLayout();
            this.flowOptions.SuspendLayout();
            this.Options_GroupBox.SuspendLayout();
            this.RunBehaviour_GroupBox.SuspendLayout();
            this.SortBy_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddSplit
            // 
            this.btnAddSplit.Location = new System.Drawing.Point(6, 116);
            this.btnAddSplit.Name = "btnAddSplit";
            this.btnAddSplit.Size = new System.Drawing.Size(57, 21);
            this.btnAddSplit.TabIndex = 0;
            this.btnAddSplit.Text = "Add Split";
            this.ToolTips.SetToolTip(this.btnAddSplit, "All game endings automatically stop timer when on final split");
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
            this.flowMain.Size = new System.Drawing.Size(456, 149);
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
            this.flowOptions.Size = new System.Drawing.Size(456, 149);
            this.flowOptions.TabIndex = 0;
            // 
            // Options_GroupBox
            // 
            this.Options_GroupBox.Controls.Add(this.CSRemoverCheckBox);
            this.Options_GroupBox.Controls.Add(this.PresetsButton);
            this.Options_GroupBox.Controls.Add(this.ClearAllButton);
            this.Options_GroupBox.Controls.Add(this.btnAddSplit);
            this.Options_GroupBox.Controls.Add(this.versionLabel);
            this.Options_GroupBox.Controls.Add(this.RunBehaviour_GroupBox);
            this.Options_GroupBox.Controls.Add(this.SortBy_GroupBox);
            this.Options_GroupBox.Location = new System.Drawing.Point(3, 3);
            this.Options_GroupBox.Name = "Options_GroupBox";
            this.Options_GroupBox.Size = new System.Drawing.Size(450, 143);
            this.Options_GroupBox.TabIndex = 6;
            this.Options_GroupBox.TabStop = false;
            this.Options_GroupBox.Text = "Options";
            // 
            // PresetsButton
            // 
            this.PresetsButton.Location = new System.Drawing.Point(143, 116);
            this.PresetsButton.Name = "PresetsButton";
            this.PresetsButton.Size = new System.Drawing.Size(55, 21);
            this.PresetsButton.TabIndex = 9;
            this.PresetsButton.Text = "DEBUG";
            this.PresetsButton.UseVisualStyleBackColor = true;
            this.PresetsButton.Click += new System.EventHandler(this.PresetsButton_Click);
            // 
            // ClearAllButton
            // 
            this.ClearAllButton.Location = new System.Drawing.Point(69, 116);
            this.ClearAllButton.Name = "ClearAllButton";
            this.ClearAllButton.Size = new System.Drawing.Size(55, 21);
            this.ClearAllButton.TabIndex = 8;
            this.ClearAllButton.Text = "Clear";
            this.ClearAllButton.UseVisualStyleBackColor = true;
            this.ClearAllButton.Click += new System.EventHandler(this.ClearAllButton_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.Location = new System.Drawing.Point(263, 114);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(182, 24);
            this.versionLabel.TabIndex = 7;
            this.versionLabel.Text = "Autosplitter Version: x.x.x.x";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RunBehaviour_GroupBox
            // 
            this.RunBehaviour_GroupBox.Controls.Add(this.ResetTriggerComboBox);
            this.RunBehaviour_GroupBox.Controls.Add(this.ResetTriggerCheckBox);
            this.RunBehaviour_GroupBox.Controls.Add(this.StartTriggerComboBox);
            this.RunBehaviour_GroupBox.Controls.Add(this.StartTriggerCheckBox);
            this.RunBehaviour_GroupBox.Controls.Add(this.chkOrdered);
            this.RunBehaviour_GroupBox.Location = new System.Drawing.Point(143, 15);
            this.RunBehaviour_GroupBox.Name = "RunBehaviour_GroupBox";
            this.RunBehaviour_GroupBox.Size = new System.Drawing.Size(301, 95);
            this.RunBehaviour_GroupBox.TabIndex = 7;
            this.RunBehaviour_GroupBox.TabStop = false;
            this.RunBehaviour_GroupBox.Text = "Run behaviour";
            // 
            // ResetTriggerComboBox
            // 
            this.ResetTriggerComboBox.Enabled = false;
            this.ResetTriggerComboBox.FormattingEnabled = true;
            this.ResetTriggerComboBox.Location = new System.Drawing.Point(107, 63);
            this.ResetTriggerComboBox.Name = "ResetTriggerComboBox";
            this.ResetTriggerComboBox.Size = new System.Drawing.Size(186, 21);
            this.ResetTriggerComboBox.TabIndex = 9;
            this.ResetTriggerComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectedIndexChangedHandler);
            this.ResetTriggerComboBox.TextUpdate += new System.EventHandler(this.ComboBoxTextUpdateHandler);
            // 
            // ResetTriggerCheckBox
            // 
            this.ResetTriggerCheckBox.AutoSize = true;
            this.ResetTriggerCheckBox.Location = new System.Drawing.Point(6, 67);
            this.ResetTriggerCheckBox.Name = "ResetTriggerCheckBox";
            this.ResetTriggerCheckBox.Size = new System.Drawing.Size(89, 17);
            this.ResetTriggerCheckBox.TabIndex = 8;
            this.ResetTriggerCheckBox.Text = "Reset trigger:";
            this.ToolTips.SetToolTip(this.ResetTriggerCheckBox, "The specified autosplit starts the timer. Use for ILs");
            this.ResetTriggerCheckBox.UseVisualStyleBackColor = true;
            this.ResetTriggerCheckBox.CheckedChanged += new System.EventHandler(this.ResetTriggerChanged);
            // 
            // StartTriggerComboBox
            // 
            this.StartTriggerComboBox.Enabled = false;
            this.StartTriggerComboBox.FormattingEnabled = true;
            this.StartTriggerComboBox.Location = new System.Drawing.Point(107, 40);
            this.StartTriggerComboBox.Name = "StartTriggerComboBox";
            this.StartTriggerComboBox.Size = new System.Drawing.Size(186, 21);
            this.StartTriggerComboBox.TabIndex = 7;
            this.StartTriggerComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectedIndexChangedHandler);
            this.StartTriggerComboBox.TextUpdate += new System.EventHandler(this.ComboBoxTextUpdateHandler);
            // 
            // StartTriggerCheckBox
            // 
            this.StartTriggerCheckBox.AutoSize = true;
            this.StartTriggerCheckBox.Location = new System.Drawing.Point(6, 42);
            this.StartTriggerCheckBox.Name = "StartTriggerCheckBox";
            this.StartTriggerCheckBox.Size = new System.Drawing.Size(83, 17);
            this.StartTriggerCheckBox.TabIndex = 6;
            this.StartTriggerCheckBox.Text = "Start trigger:";
            this.ToolTips.SetToolTip(this.StartTriggerCheckBox, "The specified autosplit starts the timer. Use for ILs");
            this.StartTriggerCheckBox.UseVisualStyleBackColor = true;
            this.StartTriggerCheckBox.CheckedChanged += new System.EventHandler(this.StartTriggerChanged);
            // 
            // chkOrdered
            // 
            this.chkOrdered.Location = new System.Drawing.Point(6, 17);
            this.chkOrdered.Name = "chkOrdered";
            this.chkOrdered.Size = new System.Drawing.Size(92, 19);
            this.chkOrdered.TabIndex = 4;
            this.chkOrdered.Text = "Ordered Splits";
            this.ToolTips.SetToolTip(this.chkOrdered, "Required for runs with Pantheon and/or transition splits");
            this.chkOrdered.UseVisualStyleBackColor = true;
            this.chkOrdered.CheckedChanged += new System.EventHandler(this.ControlChanged);
            // 
            // SortBy_GroupBox
            // 
            this.SortBy_GroupBox.Controls.Add(this.rdAlpha);
            this.SortBy_GroupBox.Controls.Add(this.rdType);
            this.SortBy_GroupBox.Location = new System.Drawing.Point(6, 15);
            this.SortBy_GroupBox.Name = "SortBy_GroupBox";
            this.SortBy_GroupBox.Size = new System.Drawing.Size(131, 95);
            this.SortBy_GroupBox.TabIndex = 6;
            this.SortBy_GroupBox.TabStop = false;
            this.SortBy_GroupBox.Text = "Sort Split Selects By";
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
            // CSRemoverCheckBox
            // 
            this.CSRemoverCheckBox.AutoSize = true;
            this.CSRemoverCheckBox.Location = new System.Drawing.Point(205, 119);
            this.CSRemoverCheckBox.Name = "CSRemoverCheckBox";
            this.CSRemoverCheckBox.Size = new System.Drawing.Size(86, 17);
            this.CSRemoverCheckBox.TabIndex = 10;
            this.CSRemoverCheckBox.Text = "CS Remover";
            this.CSRemoverCheckBox.UseVisualStyleBackColor = true;
            this.CSRemoverCheckBox.CheckedChanged += new System.EventHandler(this.CSRemover_CheckedChanged);
            // 
            // ItTakesTwoSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ItTakesTwoSettings";
            this.Size = new System.Drawing.Size(456, 149);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.flowMain.ResumeLayout(false);
            this.flowMain.PerformLayout();
            this.flowOptions.ResumeLayout(false);
            this.Options_GroupBox.ResumeLayout(false);
            this.Options_GroupBox.PerformLayout();
            this.RunBehaviour_GroupBox.ResumeLayout(false);
            this.RunBehaviour_GroupBox.PerformLayout();
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
        private System.Windows.Forms.CheckBox chkOrdered;
        private System.Windows.Forms.GroupBox Options_GroupBox;
        private System.Windows.Forms.ToolTip ToolTips;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.GroupBox RunBehaviour_GroupBox;
        private System.Windows.Forms.GroupBox SortBy_GroupBox;
        private System.Windows.Forms.CheckBox StartTriggerCheckBox;
        private System.Windows.Forms.ComboBox StartTriggerComboBox;
        private System.Windows.Forms.CheckBox ResetTriggerCheckBox;
        private System.Windows.Forms.ComboBox ResetTriggerComboBox;
        private System.Windows.Forms.Button PresetsButton;
        private System.Windows.Forms.Button ClearAllButton;
        private System.Windows.Forms.CheckBox CSRemoverCheckBox;
    }
}
