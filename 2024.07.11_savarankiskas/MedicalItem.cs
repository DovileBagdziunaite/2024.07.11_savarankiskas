using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024._07._11_savarankiska_uzduotis
{
    internal class MedicalItem: InventoryItem
    {
        public DateTime ExpirationDate { get; set; }
        public string Diseases { get; set; }

        public MedicalItem(string name, double weight, DateTime expirationDate, string diseases)
            : base(name, weight)
        {
            ExpirationDate = expirationDate;
            Diseases = diseases;
        }
    }
}
