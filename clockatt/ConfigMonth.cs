﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace clockatt
{
    public class ConfigMonth : ConfigInt
    {
        public new static readonly int ALL = 0;
        public new static readonly int InValid = 99;

        protected static int MinMonth = 1;
        protected static int MaxMonth = 12;

        protected override void InitValue()
        {
            this.MinValue = MinMonth;
            this.MaxValue = MaxMonth;

            this.pCurrentValue = ALL;

            strFormats = new string[][]{
                    new string[]{
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
                    },
                    new string[]{
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
                    },
                    new string[]{
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
                    },
                    new string[]{
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
                    },
                    new string[]{
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
                    },
                    new string[]{
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
                    }
            };
        }

        public ConfigMonth()
        {
            this.InitValue();
        }


        public ConfigMonth(string strValue) 
        {
            this.InitValue();
            if (this.TryParse(strValue) == false)
            {
                this.CurrentValue = InValid;
            }
        }
    }
}
