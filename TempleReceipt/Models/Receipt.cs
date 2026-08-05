using System;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>本張收據共用地址</summary>
        public string Address { get; set; }

        /// <summary>建立時間</summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>同一張收據上的捐款人</summary>
        public List<ReceiptPerson> Persons { get; set; } =
            new List<ReceiptPerson>();

        /// <summary>總金額</summary>
        public decimal TotalAmount
        {
            get
            {
                return Persons.Sum(x => x.TotalAmount);
            }
        }
    }
}
