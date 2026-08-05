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

            if (value < 0 || value > 999999999)
                throw new ArgumentOutOfRangeException(nameof(amount));

            if (value == 0)
                return "零元整";

            StringBuilder sb = new StringBuilder();

            int sectionIndex = 0;
            bool hasLowerSection = false;
            bool hasSkippedSection = false;
            int nearestLowerSection = 0;

            while (value > 0)
            {
                int part = (int)(value % 10000);

                if (part != 0)
                {
                    string partChinese = ConvertSection(part);

                    if (sectionIndex > 0)
                        partChinese += Section[sectionIndex];

                    // 低位區段不足四位，或中間略過完整的 0000 區段時，
                    // 需要在目前區段與低位區段之間補一個「零」。
                    if (hasLowerSection &&
                        (hasSkippedSection || nearestLowerSection < 1000))
                    {
                        partChinese += "零";
                    }

                    sb.Insert(0, partChinese);

                    hasLowerSection = true;
                    hasSkippedSection = false;
                    nearestLowerSection = part;
                }
                else if (hasLowerSection)
                {
                    hasSkippedSection = true;
                }

                value /= 10000;
                sectionIndex++;
            }

            return sb.ToString() + "元整";
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
