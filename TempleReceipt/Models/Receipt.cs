using System;
using System.Collections.Generic;

namespace TempleReceipt.Models
{
    /// <summary>
    /// 收據資料
    /// </summary>
    public class Receipt
    {
        /// <summary>收據編號</summary>
        public string ReceiptNo { get; set; }

        /// <summary>經手人</summary>
        public string Operator { get; set; }

        /// <summary>姓名</summary>
        public string Name { get; set; }

        /// <summary>地址</summary>
        public string Address { get; set; }

        /// <summary>建立時間</summary>
        public DateTime CreateTime { get; set; }

        /// <summary>功德項目</summary>
        public List<ReceiptItem> Items { get; set; } = new List<ReceiptItem>();

        /// <summary>總金額</summary>
        public decimal TotalAmount
        {
            get
            {
                return Items.Sum(x => x.Amount);
            }
        }
    }
}