using TempleReceipt.Models;

namespace TempleReceipt.Services
{
    public class ReceiptService
    {
        private readonly ChineseMoneyService _moneyService =
            new ChineseMoneyService();

        private readonly DaoCalendarService _daoService =
            new DaoCalendarService();

        public ReceiptSummary GetSummary(Receipt receipt)
        {
            return new ReceiptSummary()
            {
                TotalAmount = receipt.TotalAmount,

                ChineseMoney =
                    _moneyService.Convert(receipt.TotalAmount),

                DaoCalendar =
                    _daoService.GetDaoCalendar(receipt.CreateTime)
            };
        }
    }
}