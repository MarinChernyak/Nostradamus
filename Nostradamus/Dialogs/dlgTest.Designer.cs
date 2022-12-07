
namespace Nostradamus.Dialogs
{
    partial class dlgTest
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
            this.txtData = new System.Windows.Forms.TextBox();
            this.JD = new System.Windows.Forms.Label();
            this.butCalc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.butClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(13, 38);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(319, 23);
            this.txtData.TabIndex = 0;
            // 
            // JD
            // 
            this.JD.AutoSize = true;
            this.JD.Location = new System.Drawing.Point(13, 13);
            this.JD.Name = "JD";
            this.JD.Size = new System.Drawing.Size(19, 15);
            this.JD.TabIndex = 1;
            this.JD.Text = "JD";
            // 
            // butCalc
            // 
            this.butCalc.Location = new System.Drawing.Point(12, 76);
            this.butCalc.Name = "butCalc";
            this.butCalc.Size = new System.Drawing.Size(75, 23);
            this.butCalc.TabIndex = 2;
            this.butCalc.Text = "Calculate";
            this.butCalc.UseVisualStyleBackColor = true;
            this.butCalc.Click += new System.EventHandler(this.butCalc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "date:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(13, 146);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 15);
            this.lblDate.TabIndex = 4;
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(12, 175);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(75, 23);
            this.butClose.TabIndex = 5;
            this.butClose.Text = "Close";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // dlgTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 210);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butCalc);
            this.Controls.Add(this.JD);
            this.Controls.Add(this.txtData);
            this.Name = "dlgTest";
            this.Text = "dlgTest";
            this.Load += new System.EventHandler(this.dlgTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label JD;
        private System.Windows.Forms.Button butCalc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button butClose;
    }
}