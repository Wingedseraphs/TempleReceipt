using System;
using System.Collections.Generic;
using System.Text;

namespace TempleReceipt.Services
{
    /// <summary>
    /// 中文數字轉換服務
    /// </summary>
    public class ChineseNumberService
    {
        private static readonly string ChineseNumbers = "零壹貳參肆伍陸柒捌玖";

        private static readonly string[] DigitUnits =
        {
            "", "拾", "佰", "仟"
        };

        private static readonly string[] SectionUnits =
        {
            "", "萬", "億"
        };

        /// <summary>
        /// 將整數轉為中文大寫。
        /// </summary>
        public string Convert(long number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException(nameof(number));

            if (number > 999999999)
                throw new ArgumentOutOfRangeException(nameof(number));

            if (number == 0)
                return ChineseNumbers[0].ToString();

            List<NumberSection> sections = new List<NumberSection>();

            int sectionIndex = 0;

            while (number > 0)
            {
                int section = (int)(number % 10000);

                if (section > 0)
                {
                    sections.Insert(0,
                        new NumberSection
                        {
                            Value = section,
                            Index = sectionIndex
                        });
                }

                number /= 10000;
                sectionIndex++;
            }

            StringBuilder result = new StringBuilder();

            foreach (NumberSection section in sections)
            {
                result.Append(ConvertSection(section.Value));

                if (section.Index > 0)
                {
                    result.Append(SectionUnits[section.Index]);
                }
            }

            return result.ToString();
        }
        /// <summary>
        /// 將四位數轉為中文大寫。
        /// </summary>
        private string ConvertSection(int number)
        {
            StringBuilder result = new StringBuilder();

            bool zero = false;

            for (int position = 3; position >= 0; position--)
            {
                int unitValue = UnitValues[3 - position];

                int digit = number / unitValue;

                number %= unitValue;

                if (digit == 0)
                {
                    zero = result.Length > 0;
                    continue;
                }

                if (zero)
                {
                    result.Append("零");
                    zero = false;
                }

                result.Append(ChineseNumbers[digit]);

                result.Append(DigitUnits[position]);
            }

            return result.ToString();
        }

        private static readonly int[] UnitValues =
        {
            1000,
            100,
            10,
            1
        };
        /// <summary>
        /// 判斷區段之間是否需要補「零」。
        /// </summary>
        private bool NeedZero(int section)
        {
            return section > 0 && section < 1000;
        }
        /// <summary>
        /// 四位數區段
        /// </summary>
        private class NumberSection
        {
            /// <summary>
            /// 區段數值 (0~9999)
            /// </summary>
            public int Value { get; set; }

            /// <summary>
            /// 區段索引
            /// 0=個位
            /// 1=萬
            /// 2=億
            /// </summary>
            public int Index { get; set; }
        }
    }
}