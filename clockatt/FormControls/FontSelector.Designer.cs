namespace clockatt.FormControls
{
    partial class FontSelector
    {
        /// <summary> 
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナで生成されたコード

        /// <summary> 
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.fontSelectDialog = new System.Windows.Forms.FontDialog();
            this.btnFontSearch = new System.Windows.Forms.Button();
            this.txtFontName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFontSearch
            // 
            this.btnFontSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFontSearch.Location = new System.Drawing.Point(129, 0);
            this.btnFontSearch.Name = "btnFontSearch";
            this.btnFontSearch.Size = new System.Drawing.Size(75, 21);
            this.btnFontSearch.TabIndex = 0;
            this.btnFontSearch.Text = "フォント選択";
            this.btnFontSearch.UseVisualStyleBackColor = true;
            this.btnFontSearch.Click += new System.EventHandler(this.btnFontSearch_Click);
            // 
            // txtFontName
            // 
            this.txtFontName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFontName.Location = new System.Drawing.Point(0, 0);
            this.txtFontName.Name = "txtFontName";
            this.txtFontName.ReadOnly = true;
            this.txtFontName.Size = new System.Drawing.Size(131, 19);
            this.txtFontName.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtFontName);
            this.panel1.Controls.Add(this.btnFontSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 21);
            this.panel1.TabIndex = 2;
            // 
            // FontSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "FontSelector";
            this.Size = new System.Drawing.Size(204, 21);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FontDialog fontSelectDialog;
        private System.Windows.Forms.Button btnFontSearch;
        private System.Windows.Forms.TextBox txtFontName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
