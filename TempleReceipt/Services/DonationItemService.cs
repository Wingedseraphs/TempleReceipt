using System.Collections.Generic;
using TempleReceipt.Models;

namespace TempleReceipt.Services
{
    public class DonationItemService
    {
        public List<DonationItem> GetDefaultItems()
        {
            return new List<DonationItem>()
            {
                new DonationItem{ Name="香油錢", DefaultAmount=1000 },
                new DonationItem{ Name="祭改/補運", DefaultAmount=600 },
                new DonationItem{ Name="捐米(1斤60元)", DefaultAmount=60 },
                new DonationItem{ Name="普渡法會", DefaultAmount=2400 }
            };
        }
    }
}