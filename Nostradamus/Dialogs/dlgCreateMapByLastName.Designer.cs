
namespace Nostradamus.Dialogs
{
    partial class dlgCreateMapByLastName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgCreateMapByLastName));
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.lblFound = new System.Windows.Forms.Label();
            this.lblSelected = new System.Windows.Forms.Label();
            this.txtSelectedItem = new System.Windows.Forms.TextBox();
            this.btnCreateMap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.SystemColors.Info;
            this.txtLastName.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtLastName.Location = new System.Drawing.Point(13, 25);
            this.txtLastName.MaxLength = 50;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(239, 23);
            this.txtLastName.TabIndex = 0;
            this.txtLastName.Text = "Enter a  last name...";
            this.txtLastName.Click += new System.EventHandler(this.OnTxtLastNameClicked);
            this.txtLastName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnLastNameKeyUp);
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(13, 8);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(63, 15);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "Last Name";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearch.Location = new System.Drawing.Point(259, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lstResult
            // 
            this.lstResult.BackColor = System.Drawing.SystemColors.Info;
            this.lstResult.FormattingEnabled = true;
            this.lstResult.ItemHeight = 15;
            this.lstResult.Location = new System.Drawing.Point(13, 73);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(321, 334);
            this.lstResult.TabIndex = 3;
            this.lstResult.SelectedValueChanged += new System.EventHandler(this.OnLstPeopleSelectedValueChanged);
            // 
            // lblFound
            // 
            this.lblFound.AutoSize = true;
            this.lblFound.Location = new System.Drawing.Point(13, 55);
            this.lblFound.Name = "lblFound";
            this.lblFound.Size = new System.Drawing.Size(93, 15);
            this.lblFound.TabIndex = 4;
            this.lblFound.Text = "There are found:";
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Location = new System.Drawing.Point(13, 414);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(54, 15);
            this.lblSelected.TabIndex = 5;
            this.lblSelected.Text = "Selected:";
            // 
            // txtSelectedItem
            // 
            this.txtSelectedItem.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtSelectedItem.Enabled = false;
            this.txtSelectedItem.Location = new System.Drawing.Point(13, 431);
            this.txtSelectedItem.Name = "txtSelectedItem";
            this.txtSelectedItem.Size = new System.Drawing.Size(239, 23);
            this.txtSelectedItem.TabIndex = 6;
            // 
            // btnCreateMap
            // 
            this.btnCreateMap.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCreateMap.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnCreateMap.Location = new System.Drawing.Point(259, 431);
            this.btnCreateMap.Name = "btnCreateMap";
            this.btnCreateMap.Size = new System.Drawing.Size(75, 23);
            this.btnCreateMap.TabIndex = 7;
            this.btnCreateMap.Text = "Create...";
            this.btnCreateMap.UseVisualStyleBackColor = false;
            this.btnCreateMap.Click += new System.EventHandler(this.OnCreateMap);
            // 
            // dlgCreateMapByLastName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 466);
            this.Controls.Add(this.btnCreateMap);
            this.Controls.Add(this.txtSelectedItem);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.lblFound);
            this.Controls.Add(this.lstResult);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtLastName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlgCreateMapByLastName";
            this.Text = "Create Map By Last Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox lstResult;
        private System.Windows.Forms.Label lblFound;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.TextBox txtSelectedItem;
        private System.Windows.Forms.Button btnCreateMap;
    }
}