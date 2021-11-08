
namespace Nostradamus.Dialogs
{
    partial class dlgCreateMapManually
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgCreateMapManually));
            this.chDayLightSaving = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAdditionalHour = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.manualDate1 = new Nostradamus.UserControls.ManualDate();
            this.geoPlaceSelector = new Nostradamus.UserControls.GeoPlaceSelector();
            this.SuspendLayout();
            // 
            // chDayLightSaving
            // 
            this.chDayLightSaving.Location = new System.Drawing.Point(17, 271);
            this.chDayLightSaving.Name = "chDayLightSaving";
            this.chDayLightSaving.Size = new System.Drawing.Size(114, 18);
            this.chDayLightSaving.TabIndex = 32;
            this.chDayLightSaving.Text = "Day Light Saving";
            this.chDayLightSaving.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 298);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 15);
            this.label7.TabIndex = 33;
            this.label7.Text = "Additional Hour(s)";
            // 
            // txtAdditionalHour
            // 
            this.txtAdditionalHour.Location = new System.Drawing.Point(12, 317);
            this.txtAdditionalHour.Name = "txtAdditionalHour";
            this.txtAdditionalHour.Size = new System.Drawing.Size(211, 23);
            this.txtAdditionalHour.TabIndex = 34;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(12, 354);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(89, 23);
            this.btnCreate.TabIndex = 35;
            this.btnCreate.Text = "Create Map...";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.OnCreateMap);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(134, 354);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 23);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // manualDate1
            // 
            this.manualDate1.Day = 1;
            this.manualDate1.Hour = 0;
            this.manualDate1.Location = new System.Drawing.Point(9, 7);
            this.manualDate1.Min = 0;
            this.manualDate1.Month = 1;
            this.manualDate1.Name = "manualDate1";
            this.manualDate1.Size = new System.Drawing.Size(221, 107);
            this.manualDate1.TabIndex = 36;
            this.manualDate1.Year = 0;
            // 
            // geoPlaceSelector
            // 
            this.geoPlaceSelector.Location = new System.Drawing.Point(-4, 123);
            this.geoPlaceSelector.Name = "geoPlaceSelector";
            this.geoPlaceSelector.Size = new System.Drawing.Size(246, 150);
            this.geoPlaceSelector.TabIndex = 37;
            // 
            // dlgCreateMapManually
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 395);
            this.Controls.Add(this.manualDate1);
            this.Controls.Add(this.geoPlaceSelector);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtAdditionalHour);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chDayLightSaving);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlgCreateMapManually";
            this.Text = "Type Map Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chDayLightSaving;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAdditionalHour;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private UserControls.GeoPlaceSelector geoPlaceSelector;
        private UserControls.ManualDate manualDate1;
    }
}