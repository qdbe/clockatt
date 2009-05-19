using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace clockatt
{
    public class DayWeek : ConfigAbstract
    {

        public static readonly DayWeek ALLVALUE = new DayWeek();

        public static readonly int ALL = 0;
        public static readonly int Mon = 1;
        public static readonly int Tue = 2;
        public static readonly int Wed = 3;
        public static readonly int Thu = 4;
        public static readonly int Fri = 5;
        public static readonly int Sat = 6;
        public static readonly int Sun = 7;

        public static readonly int InValid = 99;


        /// <summary>
        /// 表示文字列 英語 短縮形
        /// </summary>
        private static string[] strDayWeek = new string[]{
        "ALL",
        "Mon",
        "Tue",
        "Wed",
        "Thu",
        "Fri",
        "Sat",
        "Sun"
        };

        /// <summary>
        /// 表示文字列 英語
        /// </summary>
        private static string[] strLongDayWeek = new string[]{
        "ALL",
        "Monday",
        "Tuesday",
        "Wednesday",
        "Thursday",
        "Friday",
        "Saturday",
        "Sunday"
        };

        /// <summary>
        /// 表示文字列 日本語 短縮形
        /// </summary>
        private static string[] strJpDayWeek = new string[]{
        "ALL",
        "月",
        "火",
        "水",
        "木",
        "金",
        "土",
        "日"
        };

        /// <summary>
        /// 表示文字列 日本語
        /// </summary>
        private static string[] strLongJpDayWeek = new string[]{
        "ALL",
        "月曜日",
        "火曜日",
        "水曜日",
        "木曜日",
        "金曜日",
        "土曜日",
        "日曜日"
        };

        /// <summary>
        /// 表示文字列の配列
        /// </summary>
        private ArrayList strArray;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DayWeek()
        {
            this.pCurrentValue = ALL;

            strArray = new ArrayList();
            strArray.Add(strDayWeek);
            strArray.Add(strJpDayWeek);
            strArray.Add(strLongDayWeek);
            strArray.Add(strLongJpDayWeek);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="strValue">文字列</param>
        public DayWeek(string strValue)
            : base()
        {
            if (this.TryParse(strValue) == false)
            {
                this.CurrentValue = InValid;
            }
        }

        /// <summary>
        /// 文字列のチェックおよび設定
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public override bool TryParse(string strValue)
        {
            if (strValue == null)
            {
                return false;
            }
            if (this.isWildCard(strValue) == true)
            {
                this.pCurrentValue = ALL;
                return true;
            }

            string[] checkArray;
            string lowerValue = strValue.ToLower();
            for (int i = 0; i < this.strArray.Count; i++)
            {
                checkArray = (string[])this.strArray[i];
                for (int j = 0; j < checkArray.Length; j++)
                {
                    if (checkArray[j].ToLower() == lowerValue)
                    {
                        this.pCurrentValue = j;
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 等価であるかどうかの判定
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is DayWeek)
            {
                if (this.pCurrentValue == ((DayWeek)obj).CurrentValue)
                {
                    return true;
                }
            }
            return false;
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
        /// ハッシュコードを返す
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return pCurrentValue;
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
                (pCurrentValue == DayWeek.Mon && checkValue == DayOfWeek.Monday) ||
                (pCurrentValue == DayWeek.Tue && checkValue == DayOfWeek.Tuesday) ||
                (pCurrentValue == DayWeek.Wed && checkValue == DayOfWeek.Wednesday) ||
                (pCurrentValue == DayWeek.Thu && checkValue == DayOfWeek.Thursday) ||
                (pCurrentValue == DayWeek.Fri && checkValue == DayOfWeek.Friday) ||
                (pCurrentValue == DayWeek.Sat && checkValue == DayOfWeek.Saturday) ||
                (pCurrentValue == DayWeek.Sun && checkValue == DayOfWeek.Sunday)
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
