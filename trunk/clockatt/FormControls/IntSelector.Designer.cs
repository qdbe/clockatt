namespace clockatt.FormControls
{
    partial class IntSelector
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
            this.numText = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numText)).BeginInit();
            this.SuspendLayout();
            // 
            // numText
            // 
            this.numText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numText.Location = new System.Drawing.Point(0, 0);
            this.numText.Name = "numText";
            this.numText.Size = new System.Drawing.Size(200, 19);
            this.numText.TabIndex = 0;
            // 
            // NumSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numText);
            this.Name = "NumSelector";
            this.Size = new System.Drawing.Size(200, 20);
            ((System.ComponentModel.ISupportInitialize)(this.numText)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numText;
    }
}
