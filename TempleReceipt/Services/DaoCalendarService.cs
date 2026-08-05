using System;

namespace TempleReceipt.Services
{
    /// <summary>
    /// 道曆轉換
    /// </summary>
    public class DaoCalendarService
    {
        public string GetDaoCalendar(DateTime dateTime)
        {
            return $"道曆：{ToChineseDigits(dateTime.Year + 2697)}年";
        }

        private static string ToChineseDigits(int value)
        {
            const string digits = "零一二三四五六七八九";
            string number = value.ToString();
            char[] result = new char[number.Length];

            for (int i = 0; i < number.Length; i++)
                result[i] = digits[number[i] - '0'];

            return new string(result);
        }
    }
}
