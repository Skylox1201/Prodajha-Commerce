
namespace Prodajha_Commerce
{
    partial class ArticleView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticleView));
            this.ArticleName = new System.Windows.Forms.TextBox();
            this.ArticleQuantite = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ArticleDescription = new System.Windows.Forms.RichTextBox();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.ArticlePrix = new System.Windows.Forms.NumericUpDown();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ArticleImage = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ArticleCategorie = new System.Windows.Forms.ComboBox();
            this.ArticleLienImage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Supprimer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleQuantite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArticlePrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ArticleName
            // 
            this.ArticleName.AccessibleName = "Nom article";
            this.ArticleName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ArticleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.ArticleName.Location = new System.Drawing.Point(11, 46);
            this.ArticleName.Margin = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.ArticleName.Name = "ArticleName";
            this.ArticleName.Size = new System.Drawing.Size(632, 32);
            this.ArticleName.TabIndex = 1;
            this.ArticleName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArticleName_KeyDown);
            // 
            // ArticleQuantite
            // 
            this.ArticleQuantite.AccessibleName = "Quantite article";
            this.ArticleQuantite.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ArticleQuantite.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.ArticleQuantite.Location = new System.Drawing.Point(125, 168);
            this.ArticleQuantite.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.ArticleQuantite.Name = "ArticleQuantite";
            this.ArticleQuantite.Size = new System.Drawing.Size(140, 32);
            this.ArticleQuantite.TabIndex = 3;
            this.ArticleQuantite.ThousandsSeparator = true;
            this.ArticleQuantite.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArticleQuantite_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(11, 299);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(6, 170);
            this.label2.Margin = new System.Windows.Forms.Padding(11, 12, 38, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Quantitée";
            // 
            // ArticleDescription
            // 
            this.ArticleDescription.AccessibleDescription = "Saisissez l\'article";
            this.ArticleDescription.AccessibleName = "Description de l\'Article";
            this.ArticleDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.ArticleDescription.Location = new System.Drawing.Point(11, 331);
            this.ArticleDescription.Margin = new System.Windows.Forms.Padding(2);
            this.ArticleDescription.Name = "ArticleDescription";
            this.ArticleDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.ArticleDescription.Size = new System.Drawing.Size(632, 210);
            this.ArticleDescription.TabIndex = 7;
            this.ArticleDescription.Text = "";
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
            this.toolStripButton1});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 10);
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.bindingNavigator1.Size = new System.Drawing.Size(962, 42);
            this.bindingNavigator1.TabIndex = 8;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AccessibleDescription = "Retour à la tables des articles";
            this.toolStripButton1.AccessibleName = "Retour";
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(63, 244);
            this.label3.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Prix";
            // 
            // ArticlePrix
            // 
            this.ArticlePrix.AccessibleDescription = "Saisissez le prix de l\'article";
            this.ArticlePrix.AccessibleName = "Prix article";
            this.ArticlePrix.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ArticlePrix.DecimalPlaces = 2;
            this.ArticlePrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.ArticlePrix.Location = new System.Drawing.Point(125, 242);
            this.ArticlePrix.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.ArticlePrix.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.ArticlePrix.Name = "ArticlePrix";
            this.ArticlePrix.Size = new System.Drawing.Size(140, 32);
            this.ArticlePrix.TabIndex = 14;
            this.ArticlePrix.ThousandsSeparator = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pictureBox2.ImageLocation = "C:\\Users\\alexa\\source\\repos\\Prodajha Commerce\\Prodajha Commerce\\Resources\\logo_Pr" +
    "odajha.png";
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(90, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // ArticleImage
            // 
            this.ArticleImage.AccessibleDescription = "Choisissez l\'image de l\'article";
            this.ArticleImage.AccessibleName = "Image Article";
            this.ArticleImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ArticleImage.Location = new System.Drawing.Point(669, 44);
            this.ArticleImage.Margin = new System.Windows.Forms.Padding(2);
            this.ArticleImage.Name = "ArticleImage";
            this.ArticleImage.Size = new System.Drawing.Size(280, 280);
            this.ArticleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ArticleImage.TabIndex = 0;
            this.ArticleImage.TabStop = false;
            // 
            // button1
            // 
            this.button1.AccessibleName = "Save";
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F);
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(700, 371);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(212, 58);
            this.button1.TabIndex = 15;
            this.button1.Text = "Sauvegardé";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(6, 93);
            this.label4.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Catégorie";
            // 
            // ArticleCategorie
            // 
            this.ArticleCategorie.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.ArticleCategorie.FormattingEnabled = true;
            this.ArticleCategorie.Location = new System.Drawing.Point(125, 92);
            this.ArticleCategorie.Margin = new System.Windows.Forms.Padding(2);
            this.ArticleCategorie.Name = "ArticleCategorie";
            this.ArticleCategorie.Size = new System.Drawing.Size(215, 33);
            this.ArticleCategorie.TabIndex = 17;
            // 
            // ArticleLienImage
            // 
            this.ArticleLienImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.ArticleLienImage.Location = new System.Drawing.Point(336, 168);
            this.ArticleLienImage.Margin = new System.Windows.Forms.Padding(2);
            this.ArticleLienImage.Multiline = true;
            this.ArticleLienImage.Name = "ArticleLienImage";
            this.ArticleLienImage.Size = new System.Drawing.Size(288, 106);
            this.ArticleLienImage.TabIndex = 18;
            this.ArticleLienImage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArticleLienImage_KeyDown);
            this.ArticleLienImage.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(506, 141);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 25);
            this.label5.TabIndex = 19;
            this.label5.Text = "Lien Image";
            // 
            // Supprimer
            // 
            this.Supprimer.AccessibleName = "Save";
            this.Supprimer.BackColor = System.Drawing.Color.Black;
            this.Supprimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F);
            this.Supprimer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Supprimer.Location = new System.Drawing.Point(700, 449);
            this.Supprimer.Margin = new System.Windows.Forms.Padding(2);
            this.Supprimer.Name = "Supprimer";
            this.Supprimer.Size = new System.Drawing.Size(212, 62);
            this.Supprimer.TabIndex = 20;
            this.Supprimer.Text = "Supprimer";
            this.Supprimer.UseVisualStyleBackColor = false;
            this.Supprimer.Click += new System.EventHandler(this.Supprimer_Click);
            // 
            // ArticleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(962, 552);
            this.Controls.Add(this.Supprimer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ArticleLienImage);
            this.Controls.Add(this.ArticleCategorie);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ArticlePrix);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.ArticleDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ArticleQuantite);
            this.Controls.Add(this.ArticleName);
            this.Controls.Add(this.ArticleImage);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ArticleView";
            this.Text = "Article";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ArticleView_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.ArticleQuantite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArticlePrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ArticleImage;
        private System.Windows.Forms.TextBox ArticleName;
        private System.Windows.Forms.NumericUpDown ArticleQuantite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox ArticleDescription;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown ArticlePrix;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ArticleCategorie;
        private System.Windows.Forms.TextBox ArticleLienImage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Supprimer;
    }
}