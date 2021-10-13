
namespace Nostradamus.Dialogs
{
    partial class dlgOrbsEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgOrbsEdit));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSelPlanet = new System.Windows.Forms.Label();
            this.lblSelPlanetData = new System.Windows.Forms.Label();
            this.lblSelAspect = new System.Windows.Forms.Label();
            this.lblSelAspectData = new System.Windows.Forms.Label();
            this.lblPlanetData = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.txtOrbValue = new System.Windows.Forms.TextBox();
            this.chDown = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.Location = new System.Drawing.Point(13, 123);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.OnOK);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.Location = new System.Drawing.Point(126, 123);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // lblSelPlanet
            // 
            this.lblSelPlanet.AutoSize = true;
            this.lblSelPlanet.Location = new System.Drawing.Point(13, 13);
            this.lblSelPlanet.Name = "lblSelPlanet";
            this.lblSelPlanet.Size = new System.Drawing.Size(93, 15);
            this.lblSelPlanet.TabIndex = 9;
            this.lblSelPlanet.Text = "Selected Planet: ";
            // 
            // lblSelPlanetData
            // 
            this.lblSelPlanetData.AutoSize = true;
            this.lblSelPlanetData.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSelPlanetData.Location = new System.Drawing.Point(113, 13);
            this.lblSelPlanetData.Name = "lblSelPlanetData";
            this.lblSelPlanetData.Size = new System.Drawing.Size(0, 15);
            this.lblSelPlanetData.TabIndex = 10;
            // 
            // lblSelAspect
            // 
            this.lblSelAspect.AutoSize = true;
            this.lblSelAspect.Location = new System.Drawing.Point(13, 32);
            this.lblSelAspect.Name = "lblSelAspect";
            this.lblSelAspect.Size = new System.Drawing.Size(93, 15);
            this.lblSelAspect.TabIndex = 11;
            this.lblSelAspect.Text = "Selected Aspect:";
            // 
            // lblSelAspectData
            // 
            this.lblSelAspectData.AutoSize = true;
            this.lblSelAspectData.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSelAspectData.Location = new System.Drawing.Point(113, 32);
            this.lblSelAspectData.Name = "lblSelAspectData";
            this.lblSelAspectData.Size = new System.Drawing.Size(73, 15);
            this.lblSelAspectData.TabIndex = 12;
            this.lblSelAspectData.Text = "Conjunction";
            // 
            // lblPlanetData
            // 
            this.lblPlanetData.AutoSize = true;
            this.lblPlanetData.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPlanetData.Location = new System.Drawing.Point(113, 12);
            this.lblPlanetData.Name = "lblPlanetData";
            this.lblPlanetData.Size = new System.Drawing.Size(28, 15);
            this.lblPlanetData.TabIndex = 13;
            this.lblPlanetData.Text = "Sun";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(13, 51);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(73, 15);
            this.lblValue.TabIndex = 14;
            this.lblValue.Text = "Value of orb:";
            // 
            // txtOrbValue
            // 
            this.txtOrbValue.Location = new System.Drawing.Point(13, 70);
            this.txtOrbValue.Name = "txtOrbValue";
            this.txtOrbValue.Size = new System.Drawing.Size(213, 23);
            this.txtOrbValue.TabIndex = 15;
            this.txtOrbValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnValueKeyDown);
            this.txtOrbValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnValuePressed);
            // 
            // chDown
            // 
            this.chDown.AutoSize = true;
            this.chDown.Checked = true;
            this.chDown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chDown.Location = new System.Drawing.Point(13, 100);
            this.chDown.Name = "chDown";
            this.chDown.Size = new System.Drawing.Size(226, 19);
            this.chDown.TabIndex = 16;
            this.chDown.Text = "Provide this value for all objects down";
            this.chDown.UseVisualStyleBackColor = true;
            this.chDown.CheckedChanged += new System.EventHandler(this.chDown_CheckedChanged);
            // 
            // dlgOrbsEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 158);
            this.Controls.Add(this.chDown);
            this.Controls.Add(this.txtOrbValue);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblPlanetData);
            this.Controls.Add(this.lblSelAspectData);
            this.Controls.Add(this.lblSelAspect);
            this.Controls.Add(this.lblSelPlanetData);
            this.Controls.Add(this.lblSelPlanet);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlgOrbsEdit";
            this.Text = "Enter orb value";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSelPlanet;
        private System.Windows.Forms.Label lblSelPlanetData;
        private System.Windows.Forms.Label lblSelAspect;
        private System.Windows.Forms.Label lblSelAspectData;
        private System.Windows.Forms.Label lblPlanetData;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtOrbValue;
        private System.Windows.Forms.CheckBox chDown;
    }
}