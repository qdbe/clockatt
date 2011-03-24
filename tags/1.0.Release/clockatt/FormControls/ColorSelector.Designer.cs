namespace clockatt.FormControls
{
    partial class ColorSelector
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
            this.txtColorName = new System.Windows.Forms.TextBox();
            this.btnColorSearch = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.colorSelectDialog = new System.Windows.Forms.ColorDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtColorName);
            this.panel1.Controls.Add(this.btnColorSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 20);
            this.panel1.TabIndex = 3;
            // 
            // txtColorName
            // 
            this.txtColorName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtColorName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtColorName.Location = new System.Drawing.Point(0, 0);
            this.txtColorName.Name = "txtColorName";
            this.txtColorName.ReadOnly = true;
            this.txtColorName.Size = new System.Drawing.Size(127, 19);
            this.txtColorName.TabIndex = 1;
            this.txtColorName.TabStop = false;
            // 
            // btnColorSearch
            // 
            this.btnColorSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnColorSearch.Location = new System.Drawing.Point(125, 0);
            this.btnColorSearch.Name = "btnColorSearch";
            this.btnColorSearch.Size = new System.Drawing.Size(75, 20);
            this.btnColorSearch.TabIndex = 0;
            this.btnColorSearch.Text = "カラー選択";
            this.btnColorSearch.UseVisualStyleBackColor = true;
            this.btnColorSearch.Click += new System.EventHandler(this.btnColorSearch_Click);
            // 
            // ColorSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ColorSelector";
            this.Size = new System.Drawing.Size(200, 20);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtColorName;
        private System.Windows.Forms.Button btnColorSearch;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ColorDialog colorSelectDialog;
    }
}
