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
                12345,
                56789,
                100000,
                10010,
                123456789
            };

            foreach (long value in values)
            {
                MessageBox.Show(
                    $"{value} -> {service.Convert(value)}");
            }
        }
    }
}