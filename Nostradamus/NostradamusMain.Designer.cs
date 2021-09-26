
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
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.createMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miByLastName = new System.Windows.Forms.ToolStripMenuItem();
            this.miByID = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMapsCollection = new System.Windows.Forms.TabControl();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createMapToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1298, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuMain";
            // 
            // createMapToolStripMenuItem
            // 
            this.createMapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miByLastName,
            this.miByID});
            this.createMapToolStripMenuItem.Name = "createMapToolStripMenuItem";
            this.createMapToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.createMapToolStripMenuItem.Text = "Create Map...";
            // 
            // miByLastName
            // 
            this.miByLastName.Name = "miByLastName";
            this.miByLastName.Size = new System.Drawing.Size(180, 22);
            this.miByLastName.Text = "By LastName";
            this.miByLastName.Click += new System.EventHandler(this.OnCreateMapByLastName);
            // 
            // miByID
            // 
            this.miByID.Name = "miByID";
            this.miByID.Size = new System.Drawing.Size(180, 22);
            this.miByID.Text = "By ID";
            this.miByID.Click += new System.EventHandler(this.OnCreateMapById);
            // 
            // tabMapsCollection
            // 
            this.tabMapsCollection.Location = new System.Drawing.Point(13, 28);
            this.tabMapsCollection.Name = "tabMapsCollection";
            this.tabMapsCollection.SelectedIndex = 0;
            this.tabMapsCollection.Size = new System.Drawing.Size(1273, 921);
            this.tabMapsCollection.TabIndex = 1;
            // 
            // NostradamusMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 961);
            this.Controls.Add(this.tabMapsCollection);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.Name = "NostradamusMain";
            this.Text = "Nostradamus 8.5";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NostradamusMain_FormClosing);
            this.Load += new System.EventHandler(this.NostradamusMain_Load);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem createMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miByLastName;
        private System.Windows.Forms.TabControl tabMapsCollection;
        private System.Windows.Forms.ToolStripMenuItem miByID;
    }
}

