using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace clockatt.FormControls
{
    public partial class FolderSelector : ConfigSelectorBase
    {
        public FolderSelector()
        {
            InitializeComponent();
            this.SetValue(string.Empty);
        }

        public override void SetValue(object value)
        {
            if (!(value is string))
            {
                throw new ArgumentException(value.GetType().Name + "は引数にセットできません");
            }
            pSelectedValue = value;
            this.txtFolderName.Text = (string)value;
            this.toolTip1.SetToolTip(this.txtFolderName, this.txtFolderName.Text);
            this.SetSampleProperty(this.pSelectedValue);
        }

        private void btnFolderSearch_Click(object sender, EventArgs e)
        {
            this.folderSelectDlg.SelectedPath = this.txtFolderName.Text;
            this.folderSelectDlg.ShowNewFolderButton = true;
            if (this.folderSelectDlg.ShowDialog(this) == DialogResult.OK)
            {
                this.txtFolderName.Text = this.folderSelectDlg.SelectedPath;
                SetValue(this.folderSelectDlg.SelectedPath);
            }
        }

        protected override Type GetSamplePropertyType()
        {
            return typeof(string);
        }

        private void FolderSelector_Enter(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this, "");
        }

        private void FolderSelector_Validating(object sender, CancelEventArgs e)
        {
            if (this.Enabled == true)
            {
                if (this.txtFolderName.Text == string.Empty)
                {
                    this.errorProvider1.SetError(this, "フォルダを指定して下さい");
                    e.Cancel = true;
                    return;
                }
                DirectoryInfo di = new DirectoryInfo(this.txtFolderName.Text);
                if (di == null)
                {
                    this.errorProvider1.SetError(this, "指定されたフォルダは存在しません。正しいフォルダを指定してください");
                    e.Cancel = true;
                }
                else if (di.Exists == false)
                {
                    this.errorProvider1.SetError(this, "指定されたフォルダは存在しません。正しいフォルダを指定してください");
                    e.Cancel = true;
                }
            }
        }

        private void FolderSelector_Validated(object sender, EventArgs e)
        {
            this.pSelectedValue = this.txtFolderName.Text;
        }

    }
}
