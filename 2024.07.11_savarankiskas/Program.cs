
using _2024._07._11_savarankiska_uzduotis;

namespace _2024._07._11_savarankiskas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "inventory.txt";

            Warehouse<FoodItem> foodWarehouse = new Warehouse<FoodItem>(filePath);
            FoodItem apple = new FoodItem("Apple", 0.2, DateTime.Now.AddDays(10), 95);
            foodWarehouse.AddItem(apple);

            Warehouse<WeaponItem> weaponWarehouse = new Warehouse<WeaponItem>(filePath);
            WeaponItem sword = new WeaponItem("Sword", 3.5, 50);
            weaponWarehouse.AddItem(sword);

            Warehouse<MedicalItem> medicalWarehouse = new Warehouse<MedicalItem>(filePath);
            MedicalItem bandage = new MedicalItem("Bandage", 0.1, DateTime.Now.AddYears(2), "Cuts");
            medicalWarehouse.AddItem(bandage);

            var foodItems = foodWarehouse.GetItems();
            var weaponItems = weaponWarehouse.GetItems();
            var medicalItems = medicalWarehouse.GetItems();

            Console.WriteLine("Food Items:");
            foreach (var item in foodItems)
            {
                Console.WriteLine($"Name: {item.Name}, Weight: {item.Weight}, Expiration Date: {item.ExpirationDate}, Calories: {item.Calories}");
            }

            Console.WriteLine("\nWeapon Items:");
            foreach (var item in weaponItems)
            {
                Console.WriteLine($"Name: {item.Name}, Weight: {item.Weight}, Damage: {item.Damage}");
            }

            Console.WriteLine("\nMedical Items:");
            foreach (var item in medicalItems)
            {
                Console.WriteLine($"Name: {item.Name}, Weight: {item.Weight}, Expiration Date: {item.ExpirationDate}, Diseases: {item.Diseases}");
            }
        }
    }
}
