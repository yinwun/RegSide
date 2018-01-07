namespace RegSide
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.wbPage = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbPage
            // 
            this.wbPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbPage.Location = new System.Drawing.Point(0, 0);
            this.wbPage.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPage.Name = "wbPage";
            this.wbPage.Size = new System.Drawing.Size(940, 751);
            this.wbPage.TabIndex = 0;
            this.wbPage.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbPage_DocumentCompleted);
            this.wbPage.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.wbPage_Navigated);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 751);
            this.Controls.Add(this.wbPage);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbPage;
    }
}

