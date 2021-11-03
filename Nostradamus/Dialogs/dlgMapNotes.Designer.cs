
namespace Nostradamus.Dialogs
{
    partial class dlgMapNotes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgMapNotes));
            this.chFLNames = new System.Windows.Forms.CheckBox();
            this.chCoordinamesStatic = new System.Windows.Forms.CheckBox();
            this.chCoordHouses = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chAspectsTable = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chCoordDynamic = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnSaveUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chFLNames
            // 
            this.chFLNames.AutoSize = true;
            this.chFLNames.Location = new System.Drawing.Point(13, 57);
            this.chFLNames.Name = "chFLNames";
            this.chFLNames.Size = new System.Drawing.Size(130, 19);
            this.chFLNames.TabIndex = 1;
            this.chFLNames.Text = "First and Last Name";
            this.chFLNames.UseVisualStyleBackColor = true;
            // 
            // chCoordinamesStatic
            // 
            this.chCoordinamesStatic.AutoSize = true;
            this.chCoordinamesStatic.Location = new System.Drawing.Point(13, 83);
            this.chCoordinamesStatic.Name = "chCoordinamesStatic";
            this.chCoordinamesStatic.Size = new System.Drawing.Size(232, 19);
            this.chCoordinamesStatic.TabIndex = 2;
            this.chCoordinamesStatic.Text = "Coordinames of planets in a static map";
            this.chCoordinamesStatic.UseVisualStyleBackColor = true;
            // 
            // chCoordHouses
            // 
            this.chCoordHouses.AutoSize = true;
            this.chCoordHouses.Location = new System.Drawing.Point(13, 109);
            this.chCoordHouses.Name = "chCoordHouses";
            this.chCoordHouses.Size = new System.Drawing.Size(151, 19);
            this.chCoordHouses.TabIndex = 3;
            this.chCoordHouses.Text = "Coordinames of houses";
            this.chCoordHouses.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Notes of a Static Map";
            // 
            // chAspectsTable
            // 
            this.chAspectsTable.AutoSize = true;
            this.chAspectsTable.Location = new System.Drawing.Point(13, 135);
            this.chAspectsTable.Name = "chAspectsTable";
            this.chAspectsTable.Size = new System.Drawing.Size(97, 19);
            this.chAspectsTable.TabIndex = 5;
            this.chAspectsTable.Text = "Aspects Table";
            this.chAspectsTable.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(12, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Notes of a Dynamic Map";
            // 
            // chCoordDynamic
            // 
            this.chCoordDynamic.AutoSize = true;
            this.chCoordDynamic.Location = new System.Drawing.Point(13, 212);
            this.chCoordDynamic.Name = "chCoordDynamic";
            this.chCoordDynamic.Size = new System.Drawing.Size(250, 19);
            this.chCoordDynamic.TabIndex = 2;
            this.chCoordDynamic.Text = "Coordinames of planets in a dynamic map";
            this.chCoordDynamic.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 237);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(181, 19);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Dynamic-Static Aspects Table";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnSaveUpdate
            // 
            this.btnSaveUpdate.Location = new System.Drawing.Point(38, 296);
            this.btnSaveUpdate.Name = "btnSaveUpdate";
            this.btnSaveUpdate.Size = new System.Drawing.Size(126, 23);
            this.btnSaveUpdate.TabIndex = 6;
            this.btnSaveUpdate.Text = "Save and Update";
            this.btnSaveUpdate.UseVisualStyleBackColor = true;
            this.btnSaveUpdate.Click += new System.EventHandler(this.OnSaveUpdate);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(170, 296);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(126, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dlgMapNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 331);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveUpdate);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.chAspectsTable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chCoordHouses);
            this.Controls.Add(this.chCoordDynamic);
            this.Controls.Add(this.chCoordinamesStatic);
            this.Controls.Add(this.chFLNames);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlgMapNotes";
            this.Text = "Notes of the Map";
            this.Load += new System.EventHandler(this.dlgMapNotes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chFLNames;
        private System.Windows.Forms.CheckBox chCoordinamesStatic;
        private System.Windows.Forms.CheckBox chCoordHouses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chAspectsTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chCoordDynamic;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnSaveUpdate;
        private System.Windows.Forms.Button btnCancel;
    }
}