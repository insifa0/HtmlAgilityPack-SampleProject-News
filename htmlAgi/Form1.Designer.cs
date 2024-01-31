namespace htmlAgi
{
    partial class Form1
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
            lblSiteName = new Label();
            txtUri = new TextBox();
            btnGetir = new Button();
            lstNews = new ListBox();
            SuspendLayout();
            // 
            // lblSiteName
            // 
            lblSiteName.AutoSize = true;
            lblSiteName.Location = new Point(12, 16);
            lblSiteName.Name = "lblSiteName";
            lblSiteName.Size = new Size(61, 20);
            lblSiteName.TabIndex = 0;
            lblSiteName.Text = "Site Adı";
            // 
            // txtUri
            // 
            txtUri.Location = new Point(79, 12);
            txtUri.Name = "txtUri";
            txtUri.Size = new Size(170, 27);
            txtUri.TabIndex = 1;
            txtUri.Text = "https://www.haberler.com/son-dakika/";
            // 
            // btnGetir
            // 
            btnGetir.Location = new Point(255, 12);
            btnGetir.Name = "btnGetir";
            btnGetir.Size = new Size(118, 29);
            btnGetir.TabIndex = 2;
            btnGetir.Text = "Haberler";
            btnGetir.UseVisualStyleBackColor = true;
            btnGetir.Click += btnGetir_Click;
            // 
            // lstNews
            // 
            lstNews.FormattingEnabled = true;
            lstNews.Location = new Point(12, 60);
            lstNews.Name = "lstNews";
            lstNews.Size = new Size(361, 264);
            lstNews.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 376);
            Controls.Add(lstNews);
            Controls.Add(btnGetir);
            Controls.Add(txtUri);
            Controls.Add(lblSiteName);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSiteName;
        private TextBox txtUri;
        private Button btnGetir;
        private ListBox lstNews;
    }
}
