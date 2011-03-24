using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt.ConfigValue
{
    public class ConfigHolidayName : ConfigStringValue
    {

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void InitValue()
        {
            this.CurrentValue = string.Empty;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConfigHolidayName(): base()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConfigHolidayName(string name)
            : base()
        {
            this.TryParse(name);
        }

        /// <summary>
        /// 文字列をパースする
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public override bool TryParse(string strValue)
        {
            if (strValue == null)
            {
                this.CurrentValue = string.Empty;
                return true;
            }

            this.CurrentValue = strValue;

            return true;
        }

        /// <summary>
        /// ハッシュコードを取得する
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.CurrentValue.GetHashCode();
        }
    }
}
