namespace clockatt.FormControls
{
    partial class CheckBoxSelector
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
            this.chkBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkBox
            // 
            this.chkBox.AutoSize = true;
            this.chkBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkBox.Location = new System.Drawing.Point(0, 0);
            this.chkBox.Name = "chkBox";
            this.chkBox.Size = new System.Drawing.Size(200, 20);
            this.chkBox.TabIndex = 0;
            this.chkBox.Text = "checkBox1";
            this.chkBox.UseVisualStyleBackColor = true;
            // 
            // CheckBoxSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkBox);
            this.Name = "CheckBoxSelector";
            this.Size = new System.Drawing.Size(200, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkBox;
    }
}
