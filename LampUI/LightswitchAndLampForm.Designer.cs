﻿namespace LampUI
{
    partial class LightswitchAndLampForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.currentDalStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lightswitchGroupBox = new System.Windows.Forms.GroupBox();
            this.lightswitchDataGridView = new System.Windows.Forms.DataGridView();
            this.lightswitchButtonsGroupBox = new System.Windows.Forms.GroupBox();
            this.toggleLightswitchButton = new System.Windows.Forms.Button();
            this.deleteLightswitchButton = new System.Windows.Forms.Button();
            this.createLightSwitchButton = new System.Windows.Forms.Button();
            this.lampsGroupBox = new System.Windows.Forms.GroupBox();
            this.lampsDataGridView = new System.Windows.Forms.DataGridView();
            this.lampButtonsGroupBox = new System.Windows.Forms.GroupBox();
            this.deleteLampButton = new System.Windows.Forms.Button();
            this.createLampButton = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.lightswitchGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lightswitchDataGridView)).BeginInit();
            this.lightswitchButtonsGroupBox.SuspendLayout();
            this.lampsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lampsDataGridView)).BeginInit();
            this.lampButtonsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentDalStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 574);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.Size = new System.Drawing.Size(914, 26);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // currentDalStatusLabel
            // 
            this.currentDalStatusLabel.Name = "currentDalStatusLabel";
            this.currentDalStatusLabel.Size = new System.Drawing.Size(96, 20);
            this.currentDalStatusLabel.Text = "Current DAL: ";
            // 
            // lightswitchGroupBox
            // 
            this.lightswitchGroupBox.Controls.Add(this.lightswitchDataGridView);
            this.lightswitchGroupBox.Controls.Add(this.lightswitchButtonsGroupBox);
            this.lightswitchGroupBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.lightswitchGroupBox.Location = new System.Drawing.Point(0, 0);
            this.lightswitchGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lightswitchGroupBox.Name = "lightswitchGroupBox";
            this.lightswitchGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lightswitchGroupBox.Size = new System.Drawing.Size(447, 574);
            this.lightswitchGroupBox.TabIndex = 1;
            this.lightswitchGroupBox.TabStop = false;
            this.lightswitchGroupBox.Text = "Lightswitches";
            // 
            // lightswitchDataGridView
            // 
            this.lightswitchDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lightswitchDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightswitchDataGridView.Location = new System.Drawing.Point(3, 24);
            this.lightswitchDataGridView.MultiSelect = false;
            this.lightswitchDataGridView.Name = "lightswitchDataGridView";
            this.lightswitchDataGridView.ReadOnly = true;
            this.lightswitchDataGridView.RowHeadersWidth = 51;
            this.lightswitchDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lightswitchDataGridView.Size = new System.Drawing.Size(441, 465);
            this.lightswitchDataGridView.TabIndex = 1;
            this.lightswitchDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LightswitchDataGridView_CellClick);
            this.lightswitchDataGridView.SelectionChanged += new System.EventHandler(this.LightswitchDataGridView_SelectionChanged);
            // 
            // lightswitchButtonsGroupBox
            // 
            this.lightswitchButtonsGroupBox.Controls.Add(this.toggleLightswitchButton);
            this.lightswitchButtonsGroupBox.Controls.Add(this.deleteLightswitchButton);
            this.lightswitchButtonsGroupBox.Controls.Add(this.createLightSwitchButton);
            this.lightswitchButtonsGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lightswitchButtonsGroupBox.Location = new System.Drawing.Point(3, 489);
            this.lightswitchButtonsGroupBox.Name = "lightswitchButtonsGroupBox";
            this.lightswitchButtonsGroupBox.Size = new System.Drawing.Size(441, 81);
            this.lightswitchButtonsGroupBox.TabIndex = 0;
            this.lightswitchButtonsGroupBox.TabStop = false;
            // 
            // toggleLightswitchButton
            // 
            this.toggleLightswitchButton.Location = new System.Drawing.Point(263, 27);
            this.toggleLightswitchButton.Name = "toggleLightswitchButton";
            this.toggleLightswitchButton.Size = new System.Drawing.Size(94, 29);
            this.toggleLightswitchButton.TabIndex = 2;
            this.toggleLightswitchButton.Text = "Toggle";
            this.toggleLightswitchButton.UseVisualStyleBackColor = true;
            this.toggleLightswitchButton.Click += new System.EventHandler(this.ToggleLightswitchButton_Click);
            // 
            // deleteLightswitchButton
            // 
            this.deleteLightswitchButton.Location = new System.Drawing.Point(163, 27);
            this.deleteLightswitchButton.Name = "deleteLightswitchButton";
            this.deleteLightswitchButton.Size = new System.Drawing.Size(94, 29);
            this.deleteLightswitchButton.TabIndex = 1;
            this.deleteLightswitchButton.Text = "Delete";
            this.deleteLightswitchButton.UseVisualStyleBackColor = true;
            this.deleteLightswitchButton.Click += new System.EventHandler(this.DeleteLightswitchButton_Click);
            // 
            // createLightSwitchButton
            // 
            this.createLightSwitchButton.Location = new System.Drawing.Point(63, 27);
            this.createLightSwitchButton.Name = "createLightSwitchButton";
            this.createLightSwitchButton.Size = new System.Drawing.Size(94, 29);
            this.createLightSwitchButton.TabIndex = 0;
            this.createLightSwitchButton.Text = "Create";
            this.createLightSwitchButton.UseVisualStyleBackColor = true;
            this.createLightSwitchButton.Click += new System.EventHandler(this.CreateLightSwitchButton_Click);
            // 
            // lampsGroupBox
            // 
            this.lampsGroupBox.Controls.Add(this.lampsDataGridView);
            this.lampsGroupBox.Controls.Add(this.lampButtonsGroupBox);
            this.lampsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lampsGroupBox.Location = new System.Drawing.Point(447, 0);
            this.lampsGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lampsGroupBox.Name = "lampsGroupBox";
            this.lampsGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lampsGroupBox.Size = new System.Drawing.Size(467, 574);
            this.lampsGroupBox.TabIndex = 2;
            this.lampsGroupBox.TabStop = false;
            this.lampsGroupBox.Text = "Lamps";
            // 
            // lampsDataGridView
            // 
            this.lampsDataGridView.AllowUserToAddRows = false;
            this.lampsDataGridView.AllowUserToDeleteRows = false;
            this.lampsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lampsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lampsDataGridView.Location = new System.Drawing.Point(3, 24);
            this.lampsDataGridView.Name = "lampsDataGridView";
            this.lampsDataGridView.ReadOnly = true;
            this.lampsDataGridView.RowHeadersWidth = 51;
            this.lampsDataGridView.RowTemplate.Height = 29;
            this.lampsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lampsDataGridView.Size = new System.Drawing.Size(461, 465);
            this.lampsDataGridView.TabIndex = 2;
            this.lampsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LampsDataGridView_CellClick);
            this.lampsDataGridView.SelectionChanged += new System.EventHandler(this.LampsDataGridView_SelectionChanged);
            // 
            // lampButtonsGroupBox
            // 
            this.lampButtonsGroupBox.Controls.Add(this.deleteLampButton);
            this.lampButtonsGroupBox.Controls.Add(this.createLampButton);
            this.lampButtonsGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lampButtonsGroupBox.Location = new System.Drawing.Point(3, 489);
            this.lampButtonsGroupBox.Name = "lampButtonsGroupBox";
            this.lampButtonsGroupBox.Size = new System.Drawing.Size(461, 81);
            this.lampButtonsGroupBox.TabIndex = 1;
            this.lampButtonsGroupBox.TabStop = false;
            // 
            // deleteLampButton
            // 
            this.deleteLampButton.Location = new System.Drawing.Point(233, 27);
            this.deleteLampButton.Name = "deleteLampButton";
            this.deleteLampButton.Size = new System.Drawing.Size(94, 29);
            this.deleteLampButton.TabIndex = 3;
            this.deleteLampButton.Text = "Delete";
            this.deleteLampButton.UseVisualStyleBackColor = true;
            this.deleteLampButton.Click += new System.EventHandler(this.DeleteLampButton_Click);
            // 
            // createLampButton
            // 
            this.createLampButton.Location = new System.Drawing.Point(133, 27);
            this.createLampButton.Name = "createLampButton";
            this.createLampButton.Size = new System.Drawing.Size(94, 29);
            this.createLampButton.TabIndex = 2;
            this.createLampButton.Text = "Create";
            this.createLampButton.UseVisualStyleBackColor = true;
            this.createLampButton.Click += new System.EventHandler(this.CreateLampButton_Click);
            // 
            // LightswitchAndLampForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.lampsGroupBox);
            this.Controls.Add(this.lightswitchGroupBox);
            this.Controls.Add(this.statusStrip);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LightswitchAndLampForm";
            this.Text = "Lightswitch and lamp";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.lightswitchGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lightswitchDataGridView)).EndInit();
            this.lightswitchButtonsGroupBox.ResumeLayout(false);
            this.lampsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lampsDataGridView)).EndInit();
            this.lampButtonsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatusStrip statusStrip;
        private ToolStripStatusLabel currentDalStatusLabel;
        private GroupBox lightswitchGroupBox;
        private GroupBox lampsGroupBox;
        private DataGridView lightswitchDataGridView;
        private GroupBox lightswitchButtonsGroupBox;
        private Button createLightSwitchButton;
        private GroupBox lampButtonsGroupBox;
        private DataGridView lampsDataGridView;
        private Button toggleLightswitchButton;
        private Button deleteLightswitchButton;
        private Button deleteLampButton;
        private Button createLampButton;
    }
}