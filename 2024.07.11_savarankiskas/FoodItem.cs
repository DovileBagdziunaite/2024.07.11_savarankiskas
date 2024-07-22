using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024._07._11_savarankiska_uzduotis
{
    internal class FoodItem: InventoryItem
    {
        public DateTime ExpirationDate { get; set; }
        public int Calories { get; set; }

        public FoodItem(string name, double weight, DateTime expirationDate, int calories)
            : base(name, weight)
        {
            ExpirationDate = expirationDate;
            Calories = calories;
        }
    }
}
