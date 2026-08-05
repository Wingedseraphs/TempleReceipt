using System;
using TempleReceipt.Services;

namespace TempleReceipt.Tests
{
    internal static class ChineseMoneyTests
    {
        public static void Verify()
        {
            ChineseMoneyService service = new ChineseMoneyService();

            AssertEqual("零元整", service.Convert(0));
            AssertEqual("壹萬零壹元整", service.Convert(10001));
            AssertEqual("壹萬零壹拾元整", service.Convert(10010));
            AssertEqual("壹拾萬零壹元整", service.Convert(100001));
            AssertEqual("壹佰萬壹仟零壹元整", service.Convert(1001001));
            AssertEqual("壹佰萬零壹元整", service.Convert(1000001));
            AssertEqual("壹億零壹元整", service.Convert(100000001));
            AssertEqual("壹億零壹萬零壹元整", service.Convert(100010001));
            AssertEqual("壹億貳仟參佰肆拾伍萬陸仟柒佰捌拾玖元整",
                service.Convert(123456789));
        }

        private static void AssertEqual(string expected, string actual)
        {
            if (expected != actual)
            {
                throw new InvalidOperationException(
                    $"預期：{expected}；實際：{actual}");
            }
        }
    }
}
