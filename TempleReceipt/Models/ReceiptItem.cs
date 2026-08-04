namespace TempleReceipt.Models
{
    /// <summary>
    /// 功德項目
    /// </summary>
    public class ReceiptItem
    {
        /// <summary>項目名稱</summary>
        public string ItemName { get; set; }

        /// <summary>金額</summary>
        public decimal Amount { get; set; }
    }
}