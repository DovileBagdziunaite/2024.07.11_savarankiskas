using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024._07._11_savarankiska_uzduotis
{
    internal abstract class InventoryItem
    {
        public string Name { get; set; }
        public double Weight { get; set; }

        protected InventoryItem(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        //public abstract void Parse(string line);
        //public abstract string ConvertToString();
    }
}
