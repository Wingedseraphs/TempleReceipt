using System.Diagnostics;
using System.Windows.Forms;
using TempleReceipt.Services;

namespace TempleReceipt.Tests
{
    public static class ChineseNumberTests
    {
        public static void TestChineseNumber()
        {
            ChineseNumberService service =
                new ChineseNumberService();

            long[] values =
            {
                0,
                1,
                9,
                10,
                11,
                20,
                99,
                100,
                101,
                110,
                111,
                1000,
                1001,
                1010,
                1100,
                1111
            };

            foreach (long value in values)
            {
                MessageBox.Show(
                    $"{value} -> {service.Convert(value)}");
            }
        }
    }
}