using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024._07._11_savarankiska_uzduotis
{
    internal class WeaponItem: InventoryItem
    {
        public int Damage { get; set; }

        public WeaponItem(string name, double weight, int damage)
            : base(name, weight)
        {
            Damage = damage;
        }
    }
}
