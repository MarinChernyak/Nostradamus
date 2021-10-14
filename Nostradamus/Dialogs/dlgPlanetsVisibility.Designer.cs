
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMajor = new System.Windows.Forms.TabPage();
            this.tabFict = new System.Windows.Forms.TabPage();
            this.tabSmall = new System.Windows.Forms.TabPage();
            this.planetsVisibilityPanelView1 = new Nostradamus.UserControls.PlanetsVisibilityPanelView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMajor);
            this.tabControl1.Controls.Add(this.tabFict);
            this.tabControl1.Controls.Add(this.tabSmall);
            this.tabControl1.Location = new System.Drawing.Point(13, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(566, 383);
            this.tabControl1.TabIndex = 0;
            // 
            // tabMajor
            // 
            this.tabMajor.Location = new System.Drawing.Point(4, 24);
            this.tabMajor.Name = "tabMajor";
            this.tabMajor.Padding = new System.Windows.Forms.Padding(3);
            this.tabMajor.Size = new System.Drawing.Size(558, 355);
            this.tabMajor.TabIndex = 0;
            this.tabMajor.Text = "Major";
            this.tabMajor.UseVisualStyleBackColor = true;
            // 
            // tabFict
            // 
            this.tabFict.Location = new System.Drawing.Point(4, 24);
            this.tabFict.Name = "tabFict";
            this.tabFict.Padding = new System.Windows.Forms.Padding(3);
            this.tabFict.Size = new System.Drawing.Size(558, 355);
            this.tabFict.TabIndex = 1;
            this.tabFict.Text = "Fictitious points";
            this.tabFict.UseVisualStyleBackColor = true;
            // 
            // tabSmall
            // 
            this.tabSmall.Location = new System.Drawing.Point(4, 24);
            this.tabSmall.Name = "tabSmall";
            this.tabSmall.Size = new System.Drawing.Size(558, 355);
            this.tabSmall.TabIndex = 2;
            this.tabSmall.Text = "Small Objects";
            this.tabSmall.UseVisualStyleBackColor = true;
            // 
            // planetsVisibilityPanelView1
            // 
            this.planetsVisibilityPanelView1.Location = new System.Drawing.Point(23, 44);
            this.planetsVisibilityPanelView1.Name = "planetsVisibilityPanelView1";
            this.planetsVisibilityPanelView1.Size = new System.Drawing.Size(546, 342);
            this.planetsVisibilityPanelView1.TabIndex = 0;
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
            // 
            // dlgPlanetsVisibility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 436);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.planetsVisibilityPanelView1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlgPlanetsVisibility";
            this.Text = "Planets Visibility Setup";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMajor;
        private System.Windows.Forms.TabPage tabFict;
        private System.Windows.Forms.TabPage tabSmall;
        private UserControls.PlanetsVisibilityPanelView planetsVisibilityPanelView1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}