namespace RegSide
{
    partial class Form2
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.rbHD = new System.Windows.Forms.RadioButton();
            this.rbYP = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(503, 327);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(397, 327);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(100, 21);
            this.txtNumber.TabIndex = 1;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(347, 332);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(47, 12);
            this.lblNumber.TabIndex = 2;
            this.lblNumber.Text = "Number:";
            // 
            // rbHD
            // 
            this.rbHD.AutoSize = true;
            this.rbHD.Location = new System.Drawing.Point(265, 330);
            this.rbHD.Name = "rbHD";
            this.rbHD.Size = new System.Drawing.Size(35, 16);
            this.rbHD.TabIndex = 3;
            this.rbHD.TabStop = true;
            this.rbHD.Text = "HD";
            this.rbHD.UseVisualStyleBackColor = true;
            // 
            // rbYP
            // 
            this.rbYP.AutoSize = true;
            this.rbYP.Location = new System.Drawing.Point(306, 330);
            this.rbYP.Name = "rbYP";
            this.rbYP.Size = new System.Drawing.Size(35, 16);
            this.rbYP.TabIndex = 3;
            this.rbYP.TabStop = true;
            this.rbYP.Text = "YP";
            this.rbYP.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(590, 362);
            this.Controls.Add(this.rbYP);
            this.Controls.Add(this.rbHD);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.btnGenerate);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.RadioButton rbHD;
        private System.Windows.Forms.RadioButton rbYP;
    }
}
