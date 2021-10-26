
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.numDay = new System.Windows.Forms.NumericUpDown();
            this.lvlYear = new System.Windows.Forms.Label();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numHour = new System.Windows.Forms.NumericUpDown();
            this.numMinutes = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMonths = new System.Windows.Forms.ComboBox();
            this.cmbDynamicMapType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDynamicStep = new System.Windows.Forms.ComboBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRecalculate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Day";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(89, 13);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(43, 15);
            this.lblMonth.TabIndex = 2;
            this.lblMonth.Text = "Month";
            // 
            // numDay
            // 
            this.numDay.Location = new System.Drawing.Point(13, 32);
            this.numDay.Name = "numDay";
            this.numDay.Size = new System.Drawing.Size(62, 23);
            this.numDay.TabIndex = 3;
            this.numDay.ValueChanged += new System.EventHandler(this.OnDayChanged);
            // 
            // lvlYear
            // 
            this.lvlYear.AutoSize = true;
            this.lvlYear.Location = new System.Drawing.Point(166, 13);
            this.lvlYear.Name = "lvlYear";
            this.lvlYear.Size = new System.Drawing.Size(29, 15);
            this.lvlYear.TabIndex = 5;
            this.lvlYear.Text = "Year";
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(165, 31);
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(62, 23);
            this.numYear.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Hour";
            // 
            // numHour
            // 
            this.numHour.Location = new System.Drawing.Point(13, 80);
            this.numHour.Name = "numHour";
            this.numHour.Size = new System.Drawing.Size(62, 23);
            this.numHour.TabIndex = 3;
            // 
            // numMinutes
            // 
            this.numMinutes.Location = new System.Drawing.Point(89, 80);
            this.numMinutes.Name = "numMinutes";
            this.numMinutes.Size = new System.Drawing.Size(62, 23);
            this.numMinutes.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Minute";
            // 
            // cmbMonths
            // 
            this.cmbMonths.BackColor = System.Drawing.SystemColors.Info;
            this.cmbMonths.FormattingEnabled = true;
            this.cmbMonths.Location = new System.Drawing.Point(89, 30);
            this.cmbMonths.Name = "cmbMonths";
            this.cmbMonths.Size = new System.Drawing.Size(62, 23);
            this.cmbMonths.TabIndex = 8;
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
            // dlgDynamicMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 300);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.btnRecalculate);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.cmbDynamicStep);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDynamicMapType);
            this.Controls.Add(this.cmbMonths);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numYear);
            this.Controls.Add(this.lvlYear);
            this.Controls.Add(this.numMinutes);
            this.Controls.Add(this.numHour);
            this.Controls.Add(this.numDay);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlgDynamicMap";
            this.Text = "Dynamic Map";
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.NumericUpDown numDay;
        private System.Windows.Forms.Label lvlYear;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numHour;
        private System.Windows.Forms.NumericUpDown numMinutes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMonths;
        private System.Windows.Forms.ComboBox cmbDynamicMapType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDynamicStep;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRecalculate;
    }
}