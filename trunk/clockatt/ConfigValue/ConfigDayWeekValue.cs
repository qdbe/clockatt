using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace clockatt.ConfigValue
{
    /// <summary>
    /// 曜日の設定値を管理する
    /// </summary>
    public class ConfigDayWeekValue : ConfigIntValue
    {
        public new static readonly int ALL = 0;
        public static readonly int Mon = 1;
        public static readonly int Tue = 2;
        public static readonly int Wed = 3;
        public static readonly int Thu = 4;
        public static readonly int Fri = 5;
        public static readonly int Sat = 6;
        public static readonly int Sun = 7;

        public new static readonly int InValid = -99;

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void InitValue()
        {
            this.pCurrentValue = ALL;
            this.MaxValue = Mon;
            this.MinValue = Sun;
            this.InitialError = "曜日の指定が不正です";

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
            if (this.pCurrentValue == ALL)
            {
                // 現時点での値が ワイルドカードであれば、全ての値に当てはまると考える
                return true;
            }
            if (
                (pCurrentValue == ConfigDayWeekValue.Mon && checkValue == DayOfWeek.Monday) ||
                (pCurrentValue == ConfigDayWeekValue.Tue && checkValue == DayOfWeek.Tuesday) ||
                (pCurrentValue == ConfigDayWeekValue.Wed && checkValue == DayOfWeek.Wednesday) ||
                (pCurrentValue == ConfigDayWeekValue.Thu && checkValue == DayOfWeek.Thursday) ||
                (pCurrentValue == ConfigDayWeekValue.Fri && checkValue == DayOfWeek.Friday) ||
                (pCurrentValue == ConfigDayWeekValue.Sat && checkValue == DayOfWeek.Saturday) ||
                (pCurrentValue == ConfigDayWeekValue.Sun && checkValue == DayOfWeek.Sunday)
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
