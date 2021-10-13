
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
            this.orbsNatalPanelView = new Nostradamus.UserControls.OrbsPanelView();
            this.tabTransit = new System.Windows.Forms.TabPage();
            this.orbsTransitPanelView = new Nostradamus.UserControls.OrbsPanelView();
            this.tabProgressions = new System.Windows.Forms.TabPage();
            this.orbsProgressivePanelView = new Nostradamus.UserControls.OrbsPanelView();
            this.tabDirect = new System.Windows.Forms.TabPage();
            this.orbsDirectivePanelView = new Nostradamus.UserControls.OrbsPanelView();
            this.tabSolar = new System.Windows.Forms.TabPage();
            this.orbsSolarPanelView = new Nostradamus.UserControls.OrbsPanelView();
            this.tabSolarProgressions = new System.Windows.Forms.TabPage();
            this.orbsSolarProgressPanelView = new Nostradamus.UserControls.OrbsPanelView();
            this.tabSynastry = new System.Windows.Forms.TabPage();
            this.orbsSynastryPanelView = new Nostradamus.UserControls.OrbsPanelView();
            this.tabHorar = new System.Windows.Forms.TabPage();
            this.orbsHorarPanelView = new Nostradamus.UserControls.OrbsPanelView();
            this.lblExisting = new System.Windows.Forms.Label();
            this.cmbExisting = new System.Windows.Forms.ComboBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.toolTipFinishWork = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAspectFrom = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbAspectTo = new System.Windows.Forms.ComboBox();
            this.btnCopyOrbs = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMapFrom = new System.Windows.Forms.ComboBox();
            this.cmbMapTo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCopyOrbsMaps = new System.Windows.Forms.Button();
            this.tabCollectionsOrbs.SuspendLayout();
            this.tabNatal.SuspendLayout();
            this.tabTransit.SuspendLayout();
            this.tabProgressions.SuspendLayout();
            this.tabDirect.SuspendLayout();
            this.tabSolar.SuspendLayout();
            this.tabSolarProgressions.SuspendLayout();
            this.tabSynastry.SuspendLayout();
            this.tabHorar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCollectionsOrbs
            // 
            this.tabCollectionsOrbs.Controls.Add(this.tabNatal);
            this.tabCollectionsOrbs.Controls.Add(this.tabTransit);
            this.tabCollectionsOrbs.Controls.Add(this.tabProgressions);
            this.tabCollectionsOrbs.Controls.Add(this.tabDirect);
            this.tabCollectionsOrbs.Controls.Add(this.tabSolar);
            this.tabCollectionsOrbs.Controls.Add(this.tabSolarProgressions);
            this.tabCollectionsOrbs.Controls.Add(this.tabSynastry);
            this.tabCollectionsOrbs.Controls.Add(this.tabHorar);
            this.tabCollectionsOrbs.Location = new System.Drawing.Point(12, 63);
            this.tabCollectionsOrbs.Name = "tabCollectionsOrbs";
            this.tabCollectionsOrbs.SelectedIndex = 0;
            this.tabCollectionsOrbs.Size = new System.Drawing.Size(435, 426);
            this.tabCollectionsOrbs.TabIndex = 2;
            this.tabCollectionsOrbs.SelectedIndexChanged += new System.EventHandler(this.OnTabChanged);
            // 
            // tabNatal
            // 
            this.tabNatal.Controls.Add(this.orbsNatalPanelView);
            this.tabNatal.Location = new System.Drawing.Point(4, 24);
            this.tabNatal.Name = "tabNatal";
            this.tabNatal.Padding = new System.Windows.Forms.Padding(3);
            this.tabNatal.Size = new System.Drawing.Size(427, 398);
            this.tabNatal.TabIndex = 0;
            this.tabNatal.Text = "Natal";
            this.tabNatal.UseVisualStyleBackColor = true;
            // 
            // orbsNatalPanelView
            // 
            this.orbsNatalPanelView.Location = new System.Drawing.Point(0, 0);
            this.orbsNatalPanelView.Name = "orbsNatalPanelView";
            this.orbsNatalPanelView.OrbsData = null;
            this.orbsNatalPanelView.Size = new System.Drawing.Size(431, 402);
            this.orbsNatalPanelView.TabIndex = 10;
            // 
            // tabTransit
            // 
            this.tabTransit.Controls.Add(this.orbsTransitPanelView);
            this.tabTransit.Location = new System.Drawing.Point(4, 24);
            this.tabTransit.Name = "tabTransit";
            this.tabTransit.Padding = new System.Windows.Forms.Padding(3);
            this.tabTransit.Size = new System.Drawing.Size(427, 398);
            this.tabTransit.TabIndex = 1;
            this.tabTransit.Text = "Transit";
            this.tabTransit.UseVisualStyleBackColor = true;
            // 
            // orbsTransitPanelView
            // 
            this.orbsTransitPanelView.Location = new System.Drawing.Point(-2, -2);
            this.orbsTransitPanelView.Name = "orbsTransitPanelView";
            this.orbsTransitPanelView.OrbsData = null;
            this.orbsTransitPanelView.Size = new System.Drawing.Size(431, 402);
            this.orbsTransitPanelView.TabIndex = 11;
            // 
            // tabProgressions
            // 
            this.tabProgressions.Controls.Add(this.orbsProgressivePanelView);
            this.tabProgressions.Location = new System.Drawing.Point(4, 24);
            this.tabProgressions.Name = "tabProgressions";
            this.tabProgressions.Size = new System.Drawing.Size(427, 398);
            this.tabProgressions.TabIndex = 2;
            this.tabProgressions.Text = "Progressive";
            this.tabProgressions.UseVisualStyleBackColor = true;
            // 
            // orbsProgressivePanelView
            // 
            this.orbsProgressivePanelView.Location = new System.Drawing.Point(-2, -2);
            this.orbsProgressivePanelView.Name = "orbsProgressivePanelView";
            this.orbsProgressivePanelView.OrbsData = null;
            this.orbsProgressivePanelView.Size = new System.Drawing.Size(431, 402);
            this.orbsProgressivePanelView.TabIndex = 11;
            // 
            // tabDirect
            // 
            this.tabDirect.Controls.Add(this.orbsDirectivePanelView);
            this.tabDirect.Location = new System.Drawing.Point(4, 24);
            this.tabDirect.Name = "tabDirect";
            this.tabDirect.Size = new System.Drawing.Size(427, 398);
            this.tabDirect.TabIndex = 3;
            this.tabDirect.Text = "Dirrective";
            this.tabDirect.UseVisualStyleBackColor = true;
            // 
            // orbsDirectivePanelView
            // 
            this.orbsDirectivePanelView.Location = new System.Drawing.Point(-2, -2);
            this.orbsDirectivePanelView.Name = "orbsDirectivePanelView";
            this.orbsDirectivePanelView.OrbsData = null;
            this.orbsDirectivePanelView.Size = new System.Drawing.Size(431, 402);
            this.orbsDirectivePanelView.TabIndex = 11;
            // 
            // tabSolar
            // 
            this.tabSolar.Controls.Add(this.orbsSolarPanelView);
            this.tabSolar.Location = new System.Drawing.Point(4, 24);
            this.tabSolar.Name = "tabSolar";
            this.tabSolar.Size = new System.Drawing.Size(427, 398);
            this.tabSolar.TabIndex = 4;
            this.tabSolar.Text = "Solar";
            this.tabSolar.UseVisualStyleBackColor = true;
            // 
            // orbsSolarPanelView
            // 
            this.orbsSolarPanelView.Location = new System.Drawing.Point(-2, -2);
            this.orbsSolarPanelView.Name = "orbsSolarPanelView";
            this.orbsSolarPanelView.OrbsData = null;
            this.orbsSolarPanelView.Size = new System.Drawing.Size(431, 402);
            this.orbsSolarPanelView.TabIndex = 11;
            // 
            // tabSolarProgressions
            // 
            this.tabSolarProgressions.Controls.Add(this.orbsSolarProgressPanelView);
            this.tabSolarProgressions.Location = new System.Drawing.Point(4, 24);
            this.tabSolarProgressions.Name = "tabSolarProgressions";
            this.tabSolarProgressions.Size = new System.Drawing.Size(427, 398);
            this.tabSolarProgressions.TabIndex = 5;
            this.tabSolarProgressions.Text = "Solar Progressions";
            this.tabSolarProgressions.UseVisualStyleBackColor = true;
            // 
            // orbsSolarProgressPanelView
            // 
            this.orbsSolarProgressPanelView.Location = new System.Drawing.Point(-2, -2);
            this.orbsSolarProgressPanelView.Name = "orbsSolarProgressPanelView";
            this.orbsSolarProgressPanelView.OrbsData = null;
            this.orbsSolarProgressPanelView.Size = new System.Drawing.Size(431, 402);
            this.orbsSolarProgressPanelView.TabIndex = 11;
            // 
            // tabSynastry
            // 
            this.tabSynastry.Controls.Add(this.orbsSynastryPanelView);
            this.tabSynastry.Location = new System.Drawing.Point(4, 24);
            this.tabSynastry.Name = "tabSynastry";
            this.tabSynastry.Size = new System.Drawing.Size(427, 398);
            this.tabSynastry.TabIndex = 6;
            this.tabSynastry.Text = "Synastry";
            this.tabSynastry.UseVisualStyleBackColor = true;
            // 
            // orbsSynastryPanelView
            // 
            this.orbsSynastryPanelView.Location = new System.Drawing.Point(-2, -2);
            this.orbsSynastryPanelView.Name = "orbsSynastryPanelView";
            this.orbsSynastryPanelView.OrbsData = null;
            this.orbsSynastryPanelView.Size = new System.Drawing.Size(431, 402);
            this.orbsSynastryPanelView.TabIndex = 11;
            // 
            // tabHorar
            // 
            this.tabHorar.Controls.Add(this.orbsHorarPanelView);
            this.tabHorar.Location = new System.Drawing.Point(4, 24);
            this.tabHorar.Name = "tabHorar";
            this.tabHorar.Size = new System.Drawing.Size(427, 398);
            this.tabHorar.TabIndex = 7;
            this.tabHorar.Text = "Horar";
            this.tabHorar.UseVisualStyleBackColor = true;
            // 
            // orbsHorarPanelView
            // 
            this.orbsHorarPanelView.Location = new System.Drawing.Point(-2, -2);
            this.orbsHorarPanelView.Name = "orbsHorarPanelView";
            this.orbsHorarPanelView.OrbsData = null;
            this.orbsHorarPanelView.Size = new System.Drawing.Size(431, 402);
            this.orbsHorarPanelView.TabIndex = 11;
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
            this.cmbExisting.Size = new System.Drawing.Size(374, 23);
            this.cmbExisting.TabIndex = 4;
            this.cmbExisting.SelectedIndexChanged += new System.EventHandler(this.OnSystemChanged);
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
            this.btnSave.Location = new System.Drawing.Point(15, 633);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save System";
            this.toolTip1.SetToolTip(this.btnSave, "Save Current Orbs Systems");
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.Location = new System.Drawing.Point(353, 633);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.toolTip2.SetToolTip(this.btnCancel, "Exit, without saving");
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnOK.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOK.Location = new System.Drawing.Point(184, 633);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(108, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "Finish Work";
            this.toolTipFinishWork.SetToolTip(this.btnOK, "It is let exit as OK with saving just currently selected sytem.");
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 496);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Copy orbs from one aspect to another...";
            // 
            // cmbAspectFrom
            // 
            this.cmbAspectFrom.FormattingEnabled = true;
            this.cmbAspectFrom.Location = new System.Drawing.Point(16, 515);
            this.cmbAspectFrom.Name = "cmbAspectFrom";
            this.cmbAspectFrom.Size = new System.Drawing.Size(126, 23);
            this.cmbAspectFrom.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(168, 510);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 28);
            this.label2.TabIndex = 11;
            this.label2.Text = "=>";
            // 
            // cmbAspectTo
            // 
            this.cmbAspectTo.FormattingEnabled = true;
            this.cmbAspectTo.Location = new System.Drawing.Point(214, 514);
            this.cmbAspectTo.Name = "cmbAspectTo";
            this.cmbAspectTo.Size = new System.Drawing.Size(126, 23);
            this.cmbAspectTo.TabIndex = 10;
            // 
            // btnCopyOrbs
            // 
            this.btnCopyOrbs.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCopyOrbs.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCopyOrbs.Location = new System.Drawing.Point(353, 514);
            this.btnCopyOrbs.Name = "btnCopyOrbs";
            this.btnCopyOrbs.Size = new System.Drawing.Size(89, 23);
            this.btnCopyOrbs.TabIndex = 12;
            this.btnCopyOrbs.Text = "Copy Orbs";
            this.btnCopyOrbs.UseVisualStyleBackColor = false;
            this.btnCopyOrbs.Click += new System.EventHandler(this.OnCopyOrbsByAspect);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 552);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Copy orbs from one map type to another...";
            // 
            // cmbMapFrom
            // 
            this.cmbMapFrom.FormattingEnabled = true;
            this.cmbMapFrom.Location = new System.Drawing.Point(16, 571);
            this.cmbMapFrom.Name = "cmbMapFrom";
            this.cmbMapFrom.Size = new System.Drawing.Size(126, 23);
            this.cmbMapFrom.TabIndex = 10;
            // 
            // cmbMapTo
            // 
            this.cmbMapTo.FormattingEnabled = true;
            this.cmbMapTo.Location = new System.Drawing.Point(214, 570);
            this.cmbMapTo.Name = "cmbMapTo";
            this.cmbMapTo.Size = new System.Drawing.Size(126, 23);
            this.cmbMapTo.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(168, 566);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 28);
            this.label4.TabIndex = 11;
            this.label4.Text = "=>";
            // 
            // btnCopyOrbsMaps
            // 
            this.btnCopyOrbsMaps.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCopyOrbsMaps.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCopyOrbsMaps.Location = new System.Drawing.Point(353, 570);
            this.btnCopyOrbsMaps.Name = "btnCopyOrbsMaps";
            this.btnCopyOrbsMaps.Size = new System.Drawing.Size(89, 23);
            this.btnCopyOrbsMaps.TabIndex = 12;
            this.btnCopyOrbsMaps.Text = "Copy Orbs";
            this.btnCopyOrbsMaps.UseVisualStyleBackColor = false;
            this.btnCopyOrbsMaps.Click += new System.EventHandler(this.OnCopyOrbsByMap);
            // 
            // dlgOrbsSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 668);
            this.Controls.Add(this.btnCopyOrbsMaps);
            this.Controls.Add(this.btnCopyOrbs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMapTo);
            this.Controls.Add(this.cmbMapFrom);
            this.Controls.Add(this.cmbAspectTo);
            this.Controls.Add(this.cmbAspectFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
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
            this.tabTransit.ResumeLayout(false);
            this.tabProgressions.ResumeLayout(false);
            this.tabDirect.ResumeLayout(false);
            this.tabSolar.ResumeLayout(false);
            this.tabSolarProgressions.ResumeLayout(false);
            this.tabSynastry.ResumeLayout(false);
            this.tabHorar.ResumeLayout(false);
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
        private UserControls.OrbsPanelView orbsNatalPanelView;
        private System.Windows.Forms.TabPage tabNatal;
        private System.Windows.Forms.TabPage tabTransit;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ToolTip toolTipFinishWork;
        private System.Windows.Forms.TabPage tabDirect;
        private System.Windows.Forms.TabPage tabSolar;
        private System.Windows.Forms.TabPage tabSolarProgressions;
        private System.Windows.Forms.TabPage tabSynastry;
        private System.Windows.Forms.TabPage tabHorar;
        private UserControls.OrbsPanelView orbsTransitPanelView;
        private UserControls.OrbsPanelView orbsProgressivePanelView;
        private UserControls.OrbsPanelView orbsDirectivePanelView;
        private UserControls.OrbsPanelView orbsSolarPanelView;
        private UserControls.OrbsPanelView orbsSolarProgressPanelView;
        private UserControls.OrbsPanelView orbsSynastryPanelView;
        private UserControls.OrbsPanelView orbsHorarPanelView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAspectFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbAspectTo;
        private System.Windows.Forms.Button btnCopyOrbs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMapFrom;
        private System.Windows.Forms.ComboBox cmbMapTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCopyOrbsMaps;
    }
}