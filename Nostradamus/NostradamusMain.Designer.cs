
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
            this.byKeywordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemcreateMapManually = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemDeleteMap = new System.Windows.Forms.ToolStripMenuItem();
            this.createDynamicMapMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTransitMap = new System.Windows.Forms.ToolStripMenuItem();
            this.progressiveMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.setHouses = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOrbs = new System.Windows.Forms.ToolStripMenuItem();
            this.objectsVisibilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSettingsMapNotes = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMapsCollection = new System.Windows.Forms.TabControl();
            this.mnuStatus = new System.Windows.Forms.StatusStrip();
            this.mnuStatusHouses = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuMain.SuspendLayout();
            this.mnuStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createMapToolStripMenuItem,
            this.createDynamicMapMenuItem,
            this.mnuSettings});
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
            this.miByID,
            this.byKeywordsToolStripMenuItem,
            this.mnuItemcreateMapManually,
            this.toolStripSeparator1,
            this.mnuItemDeleteMap});
            this.createMapToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("createMapToolStripMenuItem.Image")));
            this.createMapToolStripMenuItem.Name = "createMapToolStripMenuItem";
            this.createMapToolStripMenuItem.Size = new System.Drawing.Size(137, 20);
            this.createMapToolStripMenuItem.Text = "Create Static Map...";
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
            // byKeywordsToolStripMenuItem
            // 
            this.byKeywordsToolStripMenuItem.Name = "byKeywordsToolStripMenuItem";
            this.byKeywordsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.byKeywordsToolStripMenuItem.Text = "By Keywords";
            this.byKeywordsToolStripMenuItem.Click += new System.EventHandler(this.OnCreateMapByKeyword);
            // 
            // mnuItemcreateMapManually
            // 
            this.mnuItemcreateMapManually.Name = "mnuItemcreateMapManually";
            this.mnuItemcreateMapManually.Size = new System.Drawing.Size(180, 22);
            this.mnuItemcreateMapManually.Text = "Manually";
            this.mnuItemcreateMapManually.Click += new System.EventHandler(this.OnCreateMapManually);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuItemDeleteMap
            // 
            this.mnuItemDeleteMap.Name = "mnuItemDeleteMap";
            this.mnuItemDeleteMap.Size = new System.Drawing.Size(180, 22);
            this.mnuItemDeleteMap.Text = "Delete map";
            this.mnuItemDeleteMap.Click += new System.EventHandler(this.OnDeleteMap);
            // 
            // createDynamicMapMenuItem
            // 
            this.createDynamicMapMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTransitMap,
            this.progressiveMapToolStripMenuItem});
            this.createDynamicMapMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("createDynamicMapMenuItem.Image")));
            this.createDynamicMapMenuItem.Name = "createDynamicMapMenuItem";
            this.createDynamicMapMenuItem.Size = new System.Drawing.Size(146, 20);
            this.createDynamicMapMenuItem.Text = "Create Dynamic Map";
            // 
            // mnuTransitMap
            // 
            this.mnuTransitMap.Name = "mnuTransitMap";
            this.mnuTransitMap.Size = new System.Drawing.Size(161, 22);
            this.mnuTransitMap.Text = "Transit Map";
            this.mnuTransitMap.Click += new System.EventHandler(this.OnCreateTransitMap);
            // 
            // progressiveMapToolStripMenuItem
            // 
            this.progressiveMapToolStripMenuItem.Name = "progressiveMapToolStripMenuItem";
            this.progressiveMapToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.progressiveMapToolStripMenuItem.Text = "Progressive Map";
            // 
            // mnuSettings
            // 
            this.mnuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setHouses,
            this.mnuOrbs,
            this.objectsVisibilityToolStripMenuItem,
            this.mnuItemSettingsMapNotes});
            this.mnuSettings.Image = ((System.Drawing.Image)(resources.GetObject("mnuSettings.Image")));
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(73, 20);
            this.mnuSettings.Text = "Setings";
            // 
            // setHouses
            // 
            this.setHouses.Name = "setHouses";
            this.setHouses.Size = new System.Drawing.Size(161, 22);
            this.setHouses.Text = "Houses";
            this.setHouses.Click += new System.EventHandler(this.setHouses_Click);
            // 
            // mnuOrbs
            // 
            this.mnuOrbs.Name = "mnuOrbs";
            this.mnuOrbs.Size = new System.Drawing.Size(161, 22);
            this.mnuOrbs.Text = "Orbs";
            this.mnuOrbs.Click += new System.EventHandler(this.OnOrbsClicked);
            // 
            // objectsVisibilityToolStripMenuItem
            // 
            this.objectsVisibilityToolStripMenuItem.Name = "objectsVisibilityToolStripMenuItem";
            this.objectsVisibilityToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.objectsVisibilityToolStripMenuItem.Text = "Objects Visibility";
            this.objectsVisibilityToolStripMenuItem.Click += new System.EventHandler(this.OnClickObjectsVisibility);
            // 
            // mnuItemSettingsMapNotes
            // 
            this.mnuItemSettingsMapNotes.Name = "mnuItemSettingsMapNotes";
            this.mnuItemSettingsMapNotes.Size = new System.Drawing.Size(161, 22);
            this.mnuItemSettingsMapNotes.Text = "Maps Notes";
            this.mnuItemSettingsMapNotes.Click += new System.EventHandler(this.OnMapNotesSetting);
            // 
            // tabMapsCollection
            // 
            this.tabMapsCollection.Location = new System.Drawing.Point(13, 28);
            this.tabMapsCollection.Name = "tabMapsCollection";
            this.tabMapsCollection.SelectedIndex = 0;
            this.tabMapsCollection.Size = new System.Drawing.Size(1273, 908);
            this.tabMapsCollection.TabIndex = 1;
            // 
            // mnuStatus
            // 
            this.mnuStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStatusHouses});
            this.mnuStatus.Location = new System.Drawing.Point(0, 939);
            this.mnuStatus.Name = "mnuStatus";
            this.mnuStatus.Size = new System.Drawing.Size(1298, 22);
            this.mnuStatus.TabIndex = 2;
            this.mnuStatus.Text = "Settings";
            // 
            // mnuStatusHouses
            // 
            this.mnuStatusHouses.Name = "mnuStatusHouses";
            this.mnuStatusHouses.Size = new System.Drawing.Size(118, 17);
            this.mnuStatusHouses.Text = "toolStripStatusLabel1";
            // 
            // NostradamusMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 961);
            this.Controls.Add(this.mnuStatus);
            this.Controls.Add(this.tabMapsCollection);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.Name = "NostradamusMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nostradamus 8.5";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NostradamusMain_FormClosing);
            this.Load += new System.EventHandler(this.NostradamusMain_Load);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.mnuStatus.ResumeLayout(false);
            this.mnuStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem createMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miByLastName;
        private System.Windows.Forms.TabControl tabMapsCollection;
        private System.Windows.Forms.ToolStripMenuItem miByID;
        private System.Windows.Forms.ToolStripMenuItem byKeywordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem setHouses;
        private System.Windows.Forms.StatusStrip mnuStatus;
        private System.Windows.Forms.ToolStripStatusLabel mnuStatusHouses;
        private System.Windows.Forms.ToolStripMenuItem mnuOrbs;
        private System.Windows.Forms.ToolStripMenuItem objectsVisibilityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createDynamicMapMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuTransitMap;
        private System.Windows.Forms.ToolStripMenuItem progressiveMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemDeleteMap;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSettingsMapNotes;
        private System.Windows.Forms.ToolStripMenuItem mnuItemcreateMapManually;
    }
}

