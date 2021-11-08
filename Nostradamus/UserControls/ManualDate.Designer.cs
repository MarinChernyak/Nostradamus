
namespace Nostradamus.UserControls
{
    partial class ManualDate
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnToday = new System.Windows.Forms.Button();
            this.cmbMonths = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.lvlYear = new System.Windows.Forms.Label();
            this.numMinutes = new System.Windows.Forms.NumericUpDown();
            this.numHour = new System.Windows.Forms.NumericUpDown();
            this.numDay = new System.Windows.Forms.NumericUpDown();
            this.lblMonth = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).BeginInit();
            this.SuspendLayout();
            // 
            // btnToday
            // 
            this.btnToday.Location = new System.Drawing.Point(155, 72);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(62, 23);
            this.btnToday.TabIndex = 26;
            this.btnToday.Text = "Now...";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.OnToday);
            // 
            // cmbMonths
            // 
            this.cmbMonths.BackColor = System.Drawing.SystemColors.Info;
            this.cmbMonths.FormattingEnabled = true;
            this.cmbMonths.Location = new System.Drawing.Point(79, 22);
            this.cmbMonths.Name = "cmbMonths";
            this.cmbMonths.Size = new System.Drawing.Size(62, 23);
            this.cmbMonths.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "Minute";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "Hour";
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(155, 23);
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(62, 23);
            this.numYear.TabIndex = 22;
            // 
            // lvlYear
            // 
            this.lvlYear.AutoSize = true;
            this.lvlYear.Location = new System.Drawing.Point(156, 5);
            this.lvlYear.Name = "lvlYear";
            this.lvlYear.Size = new System.Drawing.Size(29, 15);
            this.lvlYear.TabIndex = 21;
            this.lvlYear.Text = "Year";
            // 
            // numMinutes
            // 
            this.numMinutes.Location = new System.Drawing.Point(79, 72);
            this.numMinutes.Name = "numMinutes";
            this.numMinutes.Size = new System.Drawing.Size(62, 23);
            this.numMinutes.TabIndex = 18;
            // 
            // numHour
            // 
            this.numHour.Location = new System.Drawing.Point(3, 72);
            this.numHour.Name = "numHour";
            this.numHour.Size = new System.Drawing.Size(62, 23);
            this.numHour.TabIndex = 19;
            // 
            // numDay
            // 
            this.numDay.Location = new System.Drawing.Point(3, 24);
            this.numDay.Name = "numDay";
            this.numDay.Size = new System.Drawing.Size(62, 23);
            this.numDay.TabIndex = 20;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(79, 5);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(43, 15);
            this.lblMonth.TabIndex = 17;
            this.lblMonth.Text = "Month";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Day";
            // 
            // ManualDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnToday);
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
            this.Name = "ManualDate";
            this.Size = new System.Drawing.Size(221, 107);
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.ComboBox cmbMonths;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.Label lvlYear;
        private System.Windows.Forms.NumericUpDown numMinutes;
        private System.Windows.Forms.NumericUpDown numHour;
        private System.Windows.Forms.NumericUpDown numDay;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label label1;
    }
}
