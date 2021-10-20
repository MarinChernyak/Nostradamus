
namespace Nostradamus.Dialogs
{
    partial class dlgPlanetsVisibility
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgPlanetsVisibility));
            this.tabPlanetsVisibility = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.pvMain = new Nostradamus.UserControls.PlanetsVisibilityPanelView();
            this.tabFict = new System.Windows.Forms.TabPage();
            this.pvFict = new Nostradamus.UserControls.PlanetsVisibilityPanelView();
            this.tabSmall = new System.Windows.Forms.TabPage();
            this.pvSmall = new Nostradamus.UserControls.PlanetsVisibilityPanelView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabPlanetsVisibility.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabFict.SuspendLayout();
            this.tabSmall.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPlanetsVisibility
            // 
            this.tabPlanetsVisibility.Controls.Add(this.tabMain);
            this.tabPlanetsVisibility.Controls.Add(this.tabFict);
            this.tabPlanetsVisibility.Controls.Add(this.tabSmall);
            this.tabPlanetsVisibility.Location = new System.Drawing.Point(13, 12);
            this.tabPlanetsVisibility.Name = "tabPlanetsVisibility";
            this.tabPlanetsVisibility.SelectedIndex = 0;
            this.tabPlanetsVisibility.Size = new System.Drawing.Size(566, 383);
            this.tabPlanetsVisibility.TabIndex = 0;
            this.tabPlanetsVisibility.SelectedIndexChanged += new System.EventHandler(this.OnTabChanged);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pvMain);
            this.tabMain.Location = new System.Drawing.Point(4, 24);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(558, 355);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // pvMain
            // 
            this.pvMain.Location = new System.Drawing.Point(-4, 2);
            this.pvMain.MapPlanetsVisibilityCollection = null;
            this.pvMain.Name = "pvMain";
            this.pvMain.Size = new System.Drawing.Size(577, 357);
            this.pvMain.TabIndex = 0;
            // 
            // tabFict
            // 
            this.tabFict.Controls.Add(this.pvFict);
            this.tabFict.Location = new System.Drawing.Point(4, 24);
            this.tabFict.Name = "tabFict";
            this.tabFict.Padding = new System.Windows.Forms.Padding(3);
            this.tabFict.Size = new System.Drawing.Size(558, 355);
            this.tabFict.TabIndex = 1;
            this.tabFict.Text = "Fictitious points";
            this.tabFict.UseVisualStyleBackColor = true;
            // 
            // pvFict
            // 
            this.pvFict.Location = new System.Drawing.Point(3, 0);
            this.pvFict.MapPlanetsVisibilityCollection = null;
            this.pvFict.Name = "pvFict";
            this.pvFict.Size = new System.Drawing.Size(577, 357);
            this.pvFict.TabIndex = 0;
            // 
            // tabSmall
            // 
            this.tabSmall.Controls.Add(this.pvSmall);
            this.tabSmall.Location = new System.Drawing.Point(4, 24);
            this.tabSmall.Name = "tabSmall";
            this.tabSmall.Size = new System.Drawing.Size(558, 355);
            this.tabSmall.TabIndex = 2;
            this.tabSmall.Text = "Small Objects";
            this.tabSmall.UseVisualStyleBackColor = true;
            // 
            // pvSmall
            // 
            this.pvSmall.Location = new System.Drawing.Point(4, 4);
            this.pvSmall.MapPlanetsVisibilityCollection = null;
            this.pvSmall.Name = "pvSmall";
            this.pvSmall.Size = new System.Drawing.Size(577, 357);
            this.pvSmall.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.Location = new System.Drawing.Point(23, 401);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save and Exit";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.OnSave);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.Location = new System.Drawing.Point(139, 402);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // dlgPlanetsVisibility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 436);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabPlanetsVisibility);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlgPlanetsVisibility";
            this.Text = "Planets Visibility Setup";
            this.tabPlanetsVisibility.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabFict.ResumeLayout(false);
            this.tabSmall.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPlanetsVisibility;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabFict;
        private System.Windows.Forms.TabPage tabSmall;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private UserControls.PlanetsVisibilityPanelView pvMain;
        private UserControls.PlanetsVisibilityPanelView pvFict;
        private UserControls.PlanetsVisibilityPanelView pvSmall;
    }
}