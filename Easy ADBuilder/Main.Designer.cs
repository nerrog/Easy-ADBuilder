namespace Easy_ADBuilder
{
    partial class Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.trop = new MetroFramework.Controls.MetroTextBox();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // trop
            // 
            // 
            // 
            // 
            this.trop.CustomButton.Image = null;
            this.trop.CustomButton.Location = new System.Drawing.Point(470, 2);
            this.trop.CustomButton.Name = "";
            this.trop.CustomButton.Size = new System.Drawing.Size(297, 297);
            this.trop.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.trop.CustomButton.TabIndex = 1;
            this.trop.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.trop.CustomButton.UseSelectable = true;
            this.trop.CustomButton.Visible = false;
            this.trop.Lines = new string[] {
        "Trop"};
            this.trop.Location = new System.Drawing.Point(22, 63);
            this.trop.MaxLength = 32767;
            this.trop.Multiline = true;
            this.trop.Name = "trop";
            this.trop.PasswordChar = '\0';
            this.trop.ReadOnly = true;
            this.trop.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.trop.SelectedText = "";
            this.trop.SelectionLength = 0;
            this.trop.SelectionStart = 0;
            this.trop.ShortcutsEnabled = true;
            this.trop.Size = new System.Drawing.Size(770, 302);
            this.trop.TabIndex = 0;
            this.trop.Text = "Trop";
            this.trop.UseSelectable = true;
            this.trop.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.trop.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.Location = new System.Drawing.Point(23, 380);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(111, 15);
            this.metroCheckBox1.TabIndex = 1;
            this.metroCheckBox1.Text = "利用規約に同意";
            this.metroCheckBox1.UseSelectable = true;
            // 
            // metroButton1
            // 
            this.metroButton1.Enabled = false;
            this.metroButton1.Location = new System.Drawing.Point(439, 380);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(354, 47);
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "ADB環境構築開始";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(4, 433);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(71, 12);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "by nerrog.net";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroCheckBox1);
            this.Controls.Add(this.trop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Easy ADBuilder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox trop;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

