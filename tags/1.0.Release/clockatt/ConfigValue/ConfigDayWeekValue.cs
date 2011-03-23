using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace clockatt.ConfigValue
{
    /// <summary>
    /// 曜日の設定値を管理する
    /// </summary>
    public class ConfigDayWeekValue : ConfigHolidayIntValue
    {
        /// <summary>
        /// 全て
        /// </summary>
        public new static readonly int ALL = 0;
        /// <summary>
        /// 月曜日
        /// </summary>
        public static readonly int Mon = 1;
        /// <summary>
        /// 火曜日
        /// </summary>
        public static readonly int Tue = 2;
        /// <summary>
        /// 水曜日
        /// </summary>
        public static readonly int Wed = 3;
        /// <summary>
        /// 木曜日
        /// </summary>
        public static readonly int Thu = 4;
        /// <summary>
        /// 金曜日
        /// </summary>
        public static readonly int Fri = 5;
        /// <summary>
        /// 土曜日
        /// </summary>
        public static readonly int Sat = 6;
        /// <summary>
        /// 日曜日
        /// </summary>
        public static readonly int Sun = 7;

        /// <summary>
        /// 不正値
        /// </summary>
        public new static readonly int InValid = -99;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void InitValue()
        {
            this.CurrentValue = ALL;
            this.MaxValue = Mon;
            this.MinValue = Sun;
            this.InitialError = "曜日の指定が不正です";
        }

        protected override void InitFormatString()
        {
            strFormats = new string[][]{
                    new string[]{
                        "ALL",
                        "Mon",
                        "Tue",
                        "Wed",
                        "Thu",
                        "Fri",
                        "Sat",
                        "Sun"
                    },
                    new string[]{
                        "ALL",
                        "Monday",
                        "Tuesday",
                        "Wednesday",
                        "Thursday",
                        "Friday",
                        "Saturday",
                        "Sunday"
                    },
                    new string[]{
                        "ALL",
                        "月",
                        "火",
                        "水",
                        "木",
                        "金",
                        "土",
                        "日"
                    },
                    new string[]{
                        "ALL",
                        "月曜日",
                        "火曜日",
                        "水曜日",
                        "木曜日",
                        "金曜日",
                        "土曜日",
                        "日曜日"
                    }
            };
        }



        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConfigDayWeekValue() : base()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="strValue">文字列</param>
        public ConfigDayWeekValue(string strValue)
            : base(strValue)
        {
        }

        /// <summary>
        /// 等価であるかどうかの判定
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals(DayOfWeek checkValue)
        {
            return this.IsSame(checkValue);
        }


        /// <summary>
        /// 値が同じか否かをチェックする
        /// </summary>
        /// <param name="checkValue"></param>
        /// <param name="settingValue"></param>
        /// <returns></returns>
        public bool IsSame(DayOfWeek checkValue)
        {
            if (this.CurrentValue == ALL)
            {
                // 現時点での値が ワイルドカードであれば、全ての値に当てはまると考える
                return true;
            }
            if (
                (CurrentValue == ConfigDayWeekValue.Mon && checkValue == DayOfWeek.Monday) ||
                (CurrentValue == ConfigDayWeekValue.Tue && checkValue == DayOfWeek.Tuesday) ||
                (CurrentValue == ConfigDayWeekValue.Wed && checkValue == DayOfWeek.Wednesday) ||
                (CurrentValue == ConfigDayWeekValue.Thu && checkValue == DayOfWeek.Thursday) ||
                (CurrentValue == ConfigDayWeekValue.Fri && checkValue == DayOfWeek.Friday) ||
                (CurrentValue == ConfigDayWeekValue.Sat && checkValue == DayOfWeek.Saturday) ||
                (CurrentValue == ConfigDayWeekValue.Sun && checkValue == DayOfWeek.Sunday)
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
