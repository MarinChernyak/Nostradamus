
namespace Nostradamus.Dialogs
{
    partial class dlgCreateMapByKW
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgCreateMapByKW));
            this.btnDrillDown = new System.Windows.Forms.Button();
            this.lblLstKW = new System.Windows.Forms.Label();
            this.btnGetPeople = new System.Windows.Forms.Button();
            this.btnDrillUp = new System.Windows.Forms.Button();
            this.btnCreateMap = new System.Windows.Forms.Button();
            this.txtSelected = new System.Windows.Forms.TextBox();
            this.lblSelected = new System.Windows.Forms.Label();
            this.btnReturnKW = new System.Windows.Forms.Button();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnDrillDown
            // 
            this.btnDrillDown.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDrillDown.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDrillDown.Location = new System.Drawing.Point(12, 354);
            this.btnDrillDown.Name = "btnDrillDown";
            this.btnDrillDown.Size = new System.Drawing.Size(103, 23);
            this.btnDrillDown.TabIndex = 1;
            this.btnDrillDown.Text = "Drill Down";
            this.btnDrillDown.UseVisualStyleBackColor = false;
            this.btnDrillDown.Click += new System.EventHandler(this.btnDrillDown_Click);
            // 
            // lblLstKW
            // 
            this.lblLstKW.AutoSize = true;
            this.lblLstKW.Location = new System.Drawing.Point(13, 13);
            this.lblLstKW.Name = "lblLstKW";
            this.lblLstKW.Size = new System.Drawing.Size(92, 15);
            this.lblLstKW.TabIndex = 6;
            this.lblLstKW.Text = "List of keywords";
            // 
            // btnGetPeople
            // 
            this.btnGetPeople.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnGetPeople.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGetPeople.Location = new System.Drawing.Point(12, 436);
            this.btnGetPeople.Name = "btnGetPeople";
            this.btnGetPeople.Size = new System.Drawing.Size(103, 23);
            this.btnGetPeople.TabIndex = 7;
            this.btnGetPeople.Text = "Get People";
            this.btnGetPeople.UseVisualStyleBackColor = false;
            this.btnGetPeople.Click += new System.EventHandler(this.btnGetPeople_Click);
            // 
            // btnDrillUp
            // 
            this.btnDrillUp.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDrillUp.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDrillUp.Location = new System.Drawing.Point(122, 354);
            this.btnDrillUp.Name = "btnDrillUp";
            this.btnDrillUp.Size = new System.Drawing.Size(103, 23);
            this.btnDrillUp.TabIndex = 2;
            this.btnDrillUp.Text = "Drill Up";
            this.btnDrillUp.UseVisualStyleBackColor = false;
            this.btnDrillUp.Click += new System.EventHandler(this.DrillUp_Click);
            // 
            // btnCreateMap
            // 
            this.btnCreateMap.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCreateMap.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCreateMap.Location = new System.Drawing.Point(231, 436);
            this.btnCreateMap.Name = "btnCreateMap";
            this.btnCreateMap.Size = new System.Drawing.Size(103, 23);
            this.btnCreateMap.TabIndex = 3;
            this.btnCreateMap.Text = "Create Map";
            this.btnCreateMap.UseVisualStyleBackColor = false;
            this.btnCreateMap.Click += new System.EventHandler(this.btnCreateMap_Click);
            // 
            // txtSelected
            // 
            this.txtSelected.BackColor = System.Drawing.SystemColors.Info;
            this.txtSelected.Location = new System.Drawing.Point(15, 407);
            this.txtSelected.Name = "txtSelected";
            this.txtSelected.ReadOnly = true;
            this.txtSelected.Size = new System.Drawing.Size(319, 23);
            this.txtSelected.TabIndex = 8;
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Location = new System.Drawing.Point(13, 389);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(102, 15);
            this.lblSelected.TabIndex = 9;
            this.lblSelected.Text = "Currently selected";
            // 
            // btnReturnKW
            // 
            this.btnReturnKW.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnReturnKW.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReturnKW.Location = new System.Drawing.Point(122, 436);
            this.btnReturnKW.Name = "btnReturnKW";
            this.btnReturnKW.Size = new System.Drawing.Size(103, 23);
            this.btnReturnKW.TabIndex = 2;
            this.btnReturnKW.Text = "Get keywords";
            this.btnReturnKW.UseVisualStyleBackColor = false;
            this.btnReturnKW.Click += new System.EventHandler(this.btnReturnKW_Click);
            // 
            // lstResult
            // 
            this.lstResult.BackColor = System.Drawing.SystemColors.Info;
            this.lstResult.FormattingEnabled = true;
            this.lstResult.ItemHeight = 15;
            this.lstResult.Location = new System.Drawing.Point(15, 32);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(319, 319);
            this.lstResult.TabIndex = 10;
            this.lstResult.SelectedValueChanged += new System.EventHandler(this.OnLstSelectionChanged);
            // 
            // dlgCreateMapByKW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 466);
            this.Controls.Add(this.lstResult);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.txtSelected);
            this.Controls.Add(this.btnGetPeople);
            this.Controls.Add(this.lblLstKW);
            this.Controls.Add(this.btnCreateMap);
            this.Controls.Add(this.btnReturnKW);
            this.Controls.Add(this.btnDrillUp);
            this.Controls.Add(this.btnDrillDown);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlgCreateMapByKW";
            this.Text = "Create Map by Keyword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDrillDown;
        private System.Windows.Forms.Label lblLstKW;
        private System.Windows.Forms.Button btnGetPeople;
        private System.Windows.Forms.Button btnDrillUp;
        private System.Windows.Forms.Button btnCreateMap;
        private System.Windows.Forms.TextBox txtSelected;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Button btnReturnKW;
        private System.Windows.Forms.ListBox lstResult;
    }
}