﻿
namespace Nostradamus.UserControls
{
    partial class PlanetsVisibilityPanelView
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
            this.panMain = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panMain
            // 
            this.panMain.Location = new System.Drawing.Point(3, 3);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(571, 350);
            this.panMain.TabIndex = 0;
            this.panMain.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaintMain);
            this.panMain.DoubleClick += new System.EventHandler(this.OnDoubleClickPanel);
            // 
            // PlanetsVisibilityPanelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panMain);
            this.Name = "PlanetsVisibilityPanelView";
            this.Size = new System.Drawing.Size(577, 357);
            this.DoubleClick += new System.EventHandler(this.OnDoubleClickPanel);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panMain;
    }
}
