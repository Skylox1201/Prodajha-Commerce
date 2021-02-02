
namespace Prodajha_Commerce
{
    partial class Boutique
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Boutique));
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.Profil = new System.Windows.Forms.ToolStripButton();
            this.Message = new System.Windows.Forms.ToolStripButton();
            this.Notification = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.Profil,
            this.Message,
            this.Notification});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.Padding = new System.Windows.Forms.Padding(0, 6, 0, 12);
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.bindingNavigator1.Size = new System.Drawing.Size(988, 69);
            this.bindingNavigator1.TabIndex = 5;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Comic Sans MS", 20.2F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.Info;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(164, 48);
            this.toolStripLabel1.Text = "Prodajha";
            // 
            // Profil
            // 
            this.Profil.AccessibleName = "";
            this.Profil.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Profil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Profil.Image = ((System.Drawing.Image)(resources.GetObject("Profil.Image")));
            this.Profil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Profil.Name = "Profil";
            this.Profil.Size = new System.Drawing.Size(29, 48);
            this.Profil.Text = "Profil";
            // 
            // Message
            // 
            this.Message.AccessibleDescription = "";
            this.Message.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Message.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Message.Image = ((System.Drawing.Image)(resources.GetObject("Message.Image")));
            this.Message.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(29, 48);
            this.Message.Text = "Messages";
            // 
            // Notification
            // 
            this.Notification.AccessibleName = "";
            this.Notification.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Notification.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Notification.Image = ((System.Drawing.Image)(resources.GetObject("Notification.Image")));
            this.Notification.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Notification.Name = "Notification";
            this.Notification.Size = new System.Drawing.Size(29, 48);
            this.Notification.Text = "toolStripButton3";
            this.Notification.ToolTipText = "Notification";
            // 
            // Boutique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(988, 564);
            this.Controls.Add(this.bindingNavigator1);
            this.Name = "Boutique";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton Profil;
        private System.Windows.Forms.ToolStripButton Message;
        private System.Windows.Forms.ToolStripButton Notification;
    }
}