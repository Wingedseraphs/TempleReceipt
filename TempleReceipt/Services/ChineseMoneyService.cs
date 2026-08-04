using System;
using System.Text;

namespace TempleReceipt.Services
{
    /// <summary>
    /// 中文大寫金額轉換
    /// </summary>
    public class ChineseMoneyService
    {
        private static readonly string[] Number =
        {
            "零","壹","貳","參","肆","伍","陸","柒","捌","玖"
        };

        private static readonly string[] Unit =
        {
            "", "拾", "佰", "仟"
        };

        private static readonly string[] Section =
        {
            "", "萬", "億"
        };

        /// <summary>
        /// 將金額轉為中文大寫
        /// </summary>
        public string Convert(decimal amount)
        {
            long value = (long)Math.Round(amount);

            if (value == 0)
                return "零元整";

            StringBuilder sb = new StringBuilder();

            int sectionIndex = 0;

            while (value > 0)
            {
                int part = (int)(value % 10000);

                if (part != 0)
                {
                    string partChinese = ConvertSection(part);

                    if (sectionIndex > 0)
                        partChinese += Section[sectionIndex];

                    sb.Insert(0, partChinese);
                }

                value /= 10000;
                sectionIndex++;
            }

            string result = sb.ToString();

            while (result.Contains("零零"))
                result = result.Replace("零零", "零");

            result = result.Replace("零萬", "萬");
            result = result.Replace("零億", "億");
            result = result.Replace("億萬", "億");
            result = result.TrimEnd('零');

            return result + "元整";
        }

        /// <summary>
        /// 四位數轉中文
        /// </summary>
        private string ConvertSection(int number)
        {
            StringBuilder sb = new StringBuilder();

            bool zero = false;

            for (int i = 3; i >= 0; i--)
            {
                int divisor = (int)Math.Pow(10, i);

                int digit = number / divisor;

                number %= divisor;

                if (digit == 0)
                {
                    zero = sb.Length > 0;
                }
                else
                {
                    if (zero)
                    {
                        sb.Append("零");
                        zero = false;
                    }

                    sb.Append(Number[digit]);
                    sb.Append(Unit[i]);
                }
            }

            return sb.ToString();
        }
    }
}