
namespace Nostradamus.Dialogs
{
    partial class dlgCreateMapByID
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgCreateMapByID));
            this.label1 = new System.Windows.Forms.Label();
            this.txtInputCtrl = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rtResult = new System.Windows.Forms.RichTextBox();
            this.btnCreateMap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID of a map";
            // 
            // txtInputCtrl
            // 
            this.txtInputCtrl.BackColor = System.Drawing.SystemColors.Info;
            this.txtInputCtrl.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtInputCtrl.Location = new System.Drawing.Point(13, 32);
            this.txtInputCtrl.Name = "txtInputCtrl";
            this.txtInputCtrl.Size = new System.Drawing.Size(230, 23);
            this.txtInputCtrl.TabIndex = 1;
            this.txtInputCtrl.Text = "Enter an ID of a map...";
            this.txtInputCtrl.Click += new System.EventHandler(this.OnInputCtrlClicked);
            this.txtInputCtrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnInputCtrlKeyDown);
            this.txtInputCtrl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnInputCtrlKryPressed);
            this.txtInputCtrl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnInputCtrlKeyUp);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearch.Location = new System.Drawing.Point(250, 31);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rtResult
            // 
            this.rtResult.BackColor = System.Drawing.SystemColors.Info;
            this.rtResult.Location = new System.Drawing.Point(13, 72);
            this.rtResult.Name = "rtResult";
            this.rtResult.ReadOnly = true;
            this.rtResult.Size = new System.Drawing.Size(312, 346);
            this.rtResult.TabIndex = 3;
            this.rtResult.Text = "";
            // 
            // btnCreateMap
            // 
            this.btnCreateMap.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCreateMap.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCreateMap.Location = new System.Drawing.Point(13, 431);
            this.btnCreateMap.Name = "btnCreateMap";
            this.btnCreateMap.Size = new System.Drawing.Size(312, 23);
            this.btnCreateMap.TabIndex = 4;
            this.btnCreateMap.Text = "GetMap";
            this.btnCreateMap.UseVisualStyleBackColor = false;
            this.btnCreateMap.Click += new System.EventHandler(this.OnCreateMap);
            // 
            // dlgCreateMapByID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 466);
            this.Controls.Add(this.btnCreateMap);
            this.Controls.Add(this.rtResult);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtInputCtrl);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlgCreateMapByID";
            this.Text = "dlgCreateMapByID";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInputCtrl;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RichTextBox rtResult;
        private System.Windows.Forms.Button btnCreateMap;
    }
}