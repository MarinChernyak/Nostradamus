
namespace Nostradamus.Dialogs
{
    partial class dlgDynamicMap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgDynamicMap));
            this.cmbDynamicMapType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDynamicStep = new System.Windows.Forms.ComboBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRecalculate = new System.Windows.Forms.Button();
            this.manualDate1 = new Nostradamus.UserControls.ManualDate();
            this.SuspendLayout();
            // 
            // cmbDynamicMapType
            // 
            this.cmbDynamicMapType.BackColor = System.Drawing.SystemColors.Info;
            this.cmbDynamicMapType.FormattingEnabled = true;
            this.cmbDynamicMapType.Location = new System.Drawing.Point(13, 141);
            this.cmbDynamicMapType.Name = "cmbDynamicMapType";
            this.cmbDynamicMapType.Size = new System.Drawing.Size(214, 23);
            this.cmbDynamicMapType.TabIndex = 9;
            this.cmbDynamicMapType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnMapTypeKeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Dynamic map type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Dymanic step";
            // 
            // cmbDynamicStep
            // 
            this.cmbDynamicStep.BackColor = System.Drawing.SystemColors.Info;
            this.cmbDynamicStep.FormattingEnabled = true;
            this.cmbDynamicStep.Location = new System.Drawing.Point(13, 190);
            this.cmbDynamicStep.Name = "cmbDynamicStep";
            this.cmbDynamicStep.Size = new System.Drawing.Size(214, 23);
            this.cmbDynamicStep.TabIndex = 12;
            this.cmbDynamicStep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnDynamicStepKeyPress);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBack.Location = new System.Drawing.Point(13, 232);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(59, 23);
            this.btnBack.TabIndex = 13;
            this.btnBack.Text = "<<";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.OnBack);
            // 
            // btnForward
            // 
            this.btnForward.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnForward.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnForward.Location = new System.Drawing.Point(179, 232);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(48, 23);
            this.btnForward.TabIndex = 13;
            this.btnForward.Text = ">>";
            this.btnForward.UseVisualStyleBackColor = false;
            this.btnForward.Click += new System.EventHandler(this.OnFront);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnExit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExit.Location = new System.Drawing.Point(13, 260);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(214, 23);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.OnExit);
            // 
            // btnRecalculate
            // 
            this.btnRecalculate.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnRecalculate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRecalculate.Location = new System.Drawing.Point(83, 232);
            this.btnRecalculate.Name = "btnRecalculate";
            this.btnRecalculate.Size = new System.Drawing.Size(84, 23);
            this.btnRecalculate.TabIndex = 13;
            this.btnRecalculate.Text = "Recalculate";
            this.btnRecalculate.UseVisualStyleBackColor = false;
            this.btnRecalculate.Click += new System.EventHandler(this.OnRecalculate);
            // 
            // manualDate1
            // 
            this.manualDate1.Location = new System.Drawing.Point(13, 13);
            this.manualDate1.Name = "manualDate1";
            this.manualDate1.Size = new System.Drawing.Size(221, 107);
            this.manualDate1.TabIndex = 15;
            // 
            // dlgDynamicMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 300);
            this.ControlBox = false;
            this.Controls.Add(this.manualDate1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.btnRecalculate);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.cmbDynamicStep);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDynamicMapType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlgDynamicMap";
            this.Text = "Dynamic Map";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbDynamicMapType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDynamicStep;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRecalculate;
        private UserControls.ManualDate manualDate1;
    }
}