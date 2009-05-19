using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace clockatt
{
    public class ConfigMonth : ConfigAbstract
    {

        public static readonly ConfigMonth ALLVALUE = new ConfigMonth();
        public static readonly int ALL = 0;
        public static readonly int InValid = 99;

        /// <summary>
        /// 表示文字列 英語 短縮形
        /// </summary>
        private static string[] strMonth = new string[]{
        "ALL",
        "Jan",
        "Feb",
        "Mar",
        "Apr",
        "May",
        "Jun",
        "Jul",
        "Aug",
        "Sep",
        "Oct",
        "Nov",
        "Dec"
        };

        /// <summary>
        /// 表示文字列 英語
        /// </summary>
        private static string[] strLongMonth = new string[]{
        "ALL",
        "January",
        "February",
        "March",
        "April",
        "May",
        "June",
        "July",
        "August",
        "September",
        "October",
        "November",
        "December"
        };

        /// <summary>
        /// 表示文字列 日本語 短縮形
        /// </summary>
        private static string[] strJpMonth = new string[]{
        "ALL",
        "一",
        "二",
        "三",
        "四",
        "五",
        "六",
        "七",
        "八",
        "九",
        "十",
        "十一",
        "十二"
        };

        /// <summary>
        /// 表示文字列 日本語
        /// </summary>
        private static string[] strLongJpMonth = new string[]{
        "ALL",
        "一月",
        "二月",
        "三月",
        "四月",
        "五月",
        "六月",
        "七月",
        "八月",
        "九月",
        "十月",
        "十一月",
        "十二月"
        };

        /// <summary>
        /// 表示文字列 数値日本語 短縮形
        /// </summary>
        private static string[] strDegJpMonth = new string[]{
        "ALL",
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7",
        "8",
        "9",
        "10",
        "11",
        "12"
        };

        /// <summary>
        /// 表示文字列 数値日本語 
        /// </summary>
        private static string[] strDegLongJpMonth = new string[]{
        "ALL",
        "1月",
        "2月",
        "3月",
        "4月",
        "5月",
        "6月",
        "7月",
        "8月",
        "9月",
        "10月",
        "11月",
        "12月"
        };

        /// <summary>
        /// 表示文字列の配列
        /// </summary>
        private ArrayList strArray;


        public ConfigMonth()
        {
            this.pCurrentValue = ALL;

            strArray = new ArrayList();
            strArray.Add(strMonth);
            strArray.Add(strLongMonth);
            strArray.Add(strJpMonth);
            strArray.Add(strLongJpMonth);
            strArray.Add(strDegJpMonth);
            strArray.Add(strDegLongJpMonth);
        }


        public ConfigMonth(string strValue) : base()
        {
            if (this.TryParse(strValue) == false)
            {
                this.CurrentValue = InValid;
            }
        }

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
            if (obj is ConfigMonth)
            {
                if (this.pCurrentValue == ((ConfigMonth)obj).CurrentValue)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ハッシュコードを返す
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return pCurrentValue;
        }

    }
}
