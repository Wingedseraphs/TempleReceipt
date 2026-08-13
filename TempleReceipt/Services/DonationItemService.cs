using System.Collections.Generic;
using TempleReceipt.Models;

namespace TempleReceipt.Services
{
    public class DonationItemService
    {
        public IReadOnlyList<DonationItem> GetDefaultItems()
        {
            return _items;
        }
        private readonly List<DonationItem> _items = new List<DonationItem>
        {
            new DonationItem{ Name="法會捐款", DefaultAmount=0 },
            new DonationItem{ Name="祭改/補運", DefaultAmount=500 },
            new DonationItem{ Name="捐米(1斤60元)", DefaultAmount=60 },
            new DonationItem{ Name="普渡法會(闔家)", DefaultAmount=2400 },
            new DonationItem{ Name="宮費", DefaultAmount=800 }
        };
    }
}