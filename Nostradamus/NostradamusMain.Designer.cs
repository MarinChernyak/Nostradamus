
namespace Nostradamus
{
    partial class NostradamusMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NostradamusMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.createMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byLastNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panMain = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createMapToolStripMenuItem,
            this.testMapToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1298, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // createMapToolStripMenuItem
            // 
            this.createMapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byLastNameToolStripMenuItem});
            this.createMapToolStripMenuItem.Name = "createMapToolStripMenuItem";
            this.createMapToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.createMapToolStripMenuItem.Text = "Create Map...";
            // 
            // byLastNameToolStripMenuItem
            // 
            this.byLastNameToolStripMenuItem.Name = "byLastNameToolStripMenuItem";
            this.byLastNameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.byLastNameToolStripMenuItem.Text = "By LastName";
            this.byLastNameToolStripMenuItem.Click += new System.EventHandler(this.OnCreateMapByLastName);
            // 
            // testMapToolStripMenuItem
            // 
            this.testMapToolStripMenuItem.Name = "testMapToolStripMenuItem";
            this.testMapToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.testMapToolStripMenuItem.Text = "TestMap";
            this.testMapToolStripMenuItem.Click += new System.EventHandler(this.testMapToolStripMenuItem_Click);
            // 
            // panMain
            // 
            this.panMain.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panMain.Location = new System.Drawing.Point(12, 78);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(1274, 871);
            this.panMain.TabIndex = 1;
            // 
            // NostradamusMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 961);
            this.Controls.Add(this.panMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NostradamusMain";
            this.Text = "Nostradamus 8.5";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NostradamusMain_FormClosing);
            this.Load += new System.EventHandler(this.NostradamusMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem createMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byLastNameToolStripMenuItem;
        private System.Windows.Forms.Panel panMain;
        private System.Windows.Forms.ToolStripMenuItem testMapToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}

