namespace clockatt.FormControls
{
    partial class FolderSelector
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.btnFolderSearch = new System.Windows.Forms.Button();
            this.folderSelectDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtFolderName);
            this.panel1.Controls.Add(this.btnFolderSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(404, 20);
            this.panel1.TabIndex = 0;
            // 
            // txtFolderName
            // 
            this.txtFolderName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtFolderName.Location = new System.Drawing.Point(0, 0);
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.Size = new System.Drawing.Size(328, 19);
            this.txtFolderName.TabIndex = 1;
            // 
            // btnFolderSearch
            // 
            this.btnFolderSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFolderSearch.Location = new System.Drawing.Point(329, 0);
            this.btnFolderSearch.Name = "btnFolderSearch";
            this.btnFolderSearch.Size = new System.Drawing.Size(75, 20);
            this.btnFolderSearch.TabIndex = 0;
            this.btnFolderSearch.Text = "フォルダ選択";
            this.btnFolderSearch.UseVisualStyleBackColor = true;
            this.btnFolderSearch.Click += new System.EventHandler(this.btnFolderSearch_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FolderSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "FolderSelector";
            this.Size = new System.Drawing.Size(404, 20);
            this.Validated += new System.EventHandler(this.FolderSelector_Validated);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.FolderSelector_Validating);
            this.Enter += new System.EventHandler(this.FolderSelector_Enter);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFolderSearch;
        private System.Windows.Forms.TextBox txtFolderName;
        private System.Windows.Forms.FolderBrowserDialog folderSelectDlg;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
