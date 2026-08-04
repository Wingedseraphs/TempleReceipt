namespace TempleReceipt.Models
{
    /// <summary>
    /// 收據計算結果
    /// </summary>
    public class ReceiptSummary
    {
        public decimal TotalAmount { get; set; }

        public string ChineseMoney { get; set; }

        public string DaoCalendar { get; set; }
    }
}