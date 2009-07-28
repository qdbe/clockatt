using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using clockatt.FormControls;

namespace clockatt.Configration
{
    /// <summary>
    /// 設定変更ダイアログの基礎クラス
    /// </summary>
    public partial class ConfigBaseForm : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConfigBaseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="settings"></param>
        public ConfigBaseForm(System.Configuration.SettingsBase settings)
        {
            InitializeComponent();
            this.SettingData = settings;
        }

        /// <summary>
        /// 設定データ
        /// </summary>
        protected System.Configuration.SettingsBase SettingData { get; set; }

        /// <summary>
        /// 設定データからデータを取得し、コントロールに割り当てる
        /// </summary>
        /// <param name="parent"></param>
        protected virtual void GetDataFromSettings(Control parent)
        {
            foreach (Control con in parent.Controls)
            {
                if (con is ConfigSelectorBase)
                {
                    ConfigSelectorBase selecor = (ConfigSelectorBase)con;
                    selecor.GetDataFromSettings(this.SettingData);
                }
                else if (con.Controls.Count > 0)
                {
                    GetDataFromSettings(con);
                }

                if (con is CheckBoxSelector)
                {
                    ((CheckBoxSelector)con).SamplePropertyChanged += new EventHandler(ConfigBaseForm_ChekedChanged);
                }
            }
        }

        /// <summary>
        /// 設定値を既定値に戻す
        /// </summary>
        /// <param name="parent"></param>
        protected virtual void GetDefaultDataFromSettings(Control parent)
        {
            Properties.Settings defset = Properties.Settings.Default;
            defset.Reset();
            foreach (Control con in parent.Controls)
            {
                if (con is ConfigSelectorBase)
                {
                    ConfigSelectorBase selecor = (ConfigSelectorBase)con;
                    selecor.GetDataFromSettings(defset);
                }
                else if (con.Controls.Count > 0)
                {
                    GetDefaultDataFromSettings(con);
                }
            }
        }

        /// <summary>
        /// 各コントロールの値を設定値に戻す
        /// </summary>
        /// <param name="parent"></param>
        protected virtual void SetDataToSettings(Control parent)
        {
            foreach (Control con in parent.Controls)
            {
                if (con is ConfigSelectorBase)
                {
                    ConfigSelectorBase selecor = (ConfigSelectorBase)con;
                    selecor.SetDataToSettings(this.SettingData);
                }
                else if (con.Controls.Count > 0)
                {
                    SetDataToSettings(con);
                }
            }
        }

        /// <summary>
        /// サンプルの再描画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ConfigBaseForm_ValueChanged(object sender, EventArgs e)
        {
            this.RedrawSample();
        }

        /// <summary>
        /// サンプルの再描画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ConfigBaseForm_ChekedChanged(object sender, EventArgs e)
        {
            this.RedrawSample();
        }

        /// <summary>
        /// 再描画を行う
        /// </summary>
        public virtual void RedrawSample()
        {
        }

        /// <summary>
        /// リセット実行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.GetDataFromSettings(this);
        }

        /// <summary>
        /// 既定値に戻す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDefault_Click(object sender, EventArgs e)
        {
            if( MessageBox.Show(this,"設定を既定値に戻してよろしいですか？","",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes )
            {
                this.GetDefaultDataFromSettings(this);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}
