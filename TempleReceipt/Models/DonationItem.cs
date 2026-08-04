namespace TempleReceipt.Models
{
    /// <summary>
    /// 預設功德項目
    /// </summary>
    public class DonationItem
    {
        /// <summary>
        /// 功德項目名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 預設金額
        /// </summary>
        public decimal DefaultAmount { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}