
namespace Nostradamus.Dialogs
{
    partial class dlgOrbsSystem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgOrbsSystem));
            this.tabCollectionsOrbs = new System.Windows.Forms.TabControl();
            this.tabNatal = new System.Windows.Forms.TabPage();
            this.orbsPanelView = new Nostradamus.UserControls.OrbsPanelView();
            this.tabTransit = new System.Windows.Forms.TabPage();
            this.tabProgressions = new System.Windows.Forms.TabPage();
            this.lblExisting = new System.Windows.Forms.Label();
            this.cmbExisting = new System.Windows.Forms.ComboBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.btnEdit = new System.Windows.Forms.Button();
            this.tabCollectionsOrbs.SuspendLayout();
            this.tabNatal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCollectionsOrbs
            // 
            this.tabCollectionsOrbs.Controls.Add(this.tabNatal);
            this.tabCollectionsOrbs.Controls.Add(this.tabTransit);
            this.tabCollectionsOrbs.Controls.Add(this.tabProgressions);
            this.tabCollectionsOrbs.Location = new System.Drawing.Point(12, 63);
            this.tabCollectionsOrbs.Name = "tabCollectionsOrbs";
            this.tabCollectionsOrbs.SelectedIndex = 0;
            this.tabCollectionsOrbs.Size = new System.Drawing.Size(435, 426);
            this.tabCollectionsOrbs.TabIndex = 2;
            // 
            // tabNatal
            // 
            this.tabNatal.Controls.Add(this.orbsPanelView);
            this.tabNatal.Location = new System.Drawing.Point(4, 24);
            this.tabNatal.Name = "tabNatal";
            this.tabNatal.Padding = new System.Windows.Forms.Padding(3);
            this.tabNatal.Size = new System.Drawing.Size(427, 398);
            this.tabNatal.TabIndex = 0;
            this.tabNatal.Text = "Natal";
            this.tabNatal.UseVisualStyleBackColor = true;
            // 
            // orbsPanelView
            // 
            this.orbsPanelView.Location = new System.Drawing.Point(0, 0);
            this.orbsPanelView.Name = "orbsPanelView";
            this.orbsPanelView.OrbsData = null;
            this.orbsPanelView.Size = new System.Drawing.Size(506, 443);
            this.orbsPanelView.TabIndex = 10;
            // 
            // tabTransit
            // 
            this.tabTransit.Location = new System.Drawing.Point(4, 24);
            this.tabTransit.Name = "tabTransit";
            this.tabTransit.Padding = new System.Windows.Forms.Padding(3);
            this.tabTransit.Size = new System.Drawing.Size(542, 474);
            this.tabTransit.TabIndex = 1;
            this.tabTransit.Text = "Transit";
            this.tabTransit.UseVisualStyleBackColor = true;
            // 
            // tabProgressions
            // 
            this.tabProgressions.Location = new System.Drawing.Point(4, 24);
            this.tabProgressions.Name = "tabProgressions";
            this.tabProgressions.Size = new System.Drawing.Size(542, 474);
            this.tabProgressions.TabIndex = 2;
            this.tabProgressions.Text = "Progressions";
            this.tabProgressions.UseVisualStyleBackColor = true;
            // 
            // lblExisting
            // 
            this.lblExisting.AutoSize = true;
            this.lblExisting.Location = new System.Drawing.Point(12, 7);
            this.lblExisting.Name = "lblExisting";
            this.lblExisting.Size = new System.Drawing.Size(94, 15);
            this.lblExisting.TabIndex = 3;
            this.lblExisting.Text = "Existing Systems";
            // 
            // cmbExisting
            // 
            this.cmbExisting.BackColor = System.Drawing.SystemColors.Info;
            this.cmbExisting.FormattingEnabled = true;
            this.cmbExisting.Location = new System.Drawing.Point(12, 25);
            this.cmbExisting.Name = "cmbExisting";
            this.cmbExisting.Size = new System.Drawing.Size(323, 23);
            this.cmbExisting.TabIndex = 4;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnNew.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNew.Location = new System.Drawing.Point(392, 24);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(51, 23);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "New...";
            this.toolTip3.SetToolTip(this.btnNew, "Add new orbs sytem");
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.Location = new System.Drawing.Point(132, 495);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save and Exit";
            this.toolTip1.SetToolTip(this.btnSave, "Save Orbs Systems");
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.Location = new System.Drawing.Point(246, 495);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.toolTip2.SetToolTip(this.btnCancel, "Exit, without saving");
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEdit.Location = new System.Drawing.Point(341, 24);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(51, 23);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dlgOrbsSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 530);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.cmbExisting);
            this.Controls.Add(this.lblExisting);
            this.Controls.Add(this.tabCollectionsOrbs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlgOrbsSystem";
            this.Text = "dlgOrbsSystem";
            this.tabCollectionsOrbs.ResumeLayout(false);
            this.tabNatal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabCollectionsOrbs;
        private System.Windows.Forms.TabPage tabProgressions;
        private System.Windows.Forms.Label lblExisting;
        private System.Windows.Forms.ComboBox cmbExisting;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.Button btnEdit;
        private UserControls.OrbsPanelView orbsPanelView;
        private System.Windows.Forms.TabPage tabNatal;
        private System.Windows.Forms.TabPage tabTransit;
    }
}