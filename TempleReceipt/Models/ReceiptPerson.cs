using System.Collections.Generic;
using System.Linq;
using TempleReceipt.Models;

public class ReceiptPerson
{
    public string Name { get; set; }

    public List<ReceiptItem> Items { get; set; }
        = new List<ReceiptItem>();

    public decimal TotalAmount
    {
        get
        {
            return Items.Sum(x => x.Amount);
        }
    }
}