
namespace Nostradamus.Dialogs
{
   
    partial class dlgHousesSystems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgHousesSystems));
            this.label1 = new System.Windows.Forms.Label();
            this.lstHouses = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSelected = new System.Windows.Forms.TextBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available houses systems";
            // 
            // lstHouses
            // 
            this.lstHouses.BackColor = System.Drawing.SystemColors.Info;
            this.lstHouses.FormattingEnabled = true;
            this.lstHouses.ItemHeight = 15;
            this.lstHouses.Location = new System.Drawing.Point(13, 42);
            this.lstHouses.Name = "lstHouses";
            this.lstHouses.Size = new System.Drawing.Size(269, 259);
            this.lstHouses.TabIndex = 1;
            this.lstHouses.SelectedIndexChanged += new System.EventHandler(this.OnSystemChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Selected system";
            // 
            // txtSelected
            // 
            this.txtSelected.BackColor = System.Drawing.SystemColors.Info;
            this.txtSelected.Location = new System.Drawing.Point(13, 327);
            this.txtSelected.Name = "txtSelected";
            this.txtSelected.ReadOnly = true;
            this.txtSelected.Size = new System.Drawing.Size(231, 23);
            this.txtSelected.TabIndex = 3;
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnHelp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHelp.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnHelp.Location = new System.Drawing.Point(251, 327);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(31, 23);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.OnHelp);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnOK.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOK.Location = new System.Drawing.Point(13, 357);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(269, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "Use selected system";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.OnOK);
            // 
            // dlgHousesSystems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 394);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.txtSelected);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstHouses);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlgHousesSystems";
            this.Text = "Houses Systems";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstHouses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSelected;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnOK;
    }
}