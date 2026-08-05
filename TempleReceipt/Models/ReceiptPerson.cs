using System.Collections.Generic;
using System.Linq;

namespace TempleReceipt.Models
{
    /// <summary>
    /// 同一張收據中的一位捐款人及其功德項目。
    /// </summary>
    public class ReceiptPerson
    {
        /// <summary>捐款人姓名</summary>
        public string Name { get; set; }

        /// <summary>此捐款人的功德項目</summary>
        public List<ReceiptItem> Items { get; set; }
            = new List<ReceiptItem>();

        /// <summary>此捐款人的項目小計</summary>
        public decimal TotalAmount
        {
            get
            {
                return Items.Sum(x => x.Amount);
            }
        }

        public override string ToString()
        {
            string displayName = string.IsNullOrWhiteSpace(Name)
                ? "未命名捐款人"
                : Name;

            return $"{displayName}（{Items.Count} 項，{TotalAmount:N0} 元）";
        }
    }
}
