using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024._07._11_savarankiska_uzduotis
{
    internal class Warehouse<T> where T: InventoryItem
    {
        private string _filePath;

        public Warehouse(string filePath)
        {
            _filePath = filePath;
        }

        public void AddItem(T item)
        {
            string line;
            if (item is FoodItem food)
            {
                line = $"{food.Name},{food.Weight},{food.ExpirationDate:yyyy-MM-dd},{food.Calories}";
            }
            else if (item is WeaponItem weapon)
            {
                line = $"{weapon.Name},{weapon.Weight},{weapon.Damage}";
            }
            else if (item is MedicalItem medical)
            {
                line = $"{medical.Name},{medical.Weight},{medical.ExpirationDate:yyyy-MM-dd},{medical.Diseases}";
            }
            else
            {
                throw new InvalidOperationException("Unknown item type");
            }

            File.AppendAllText(_filePath, line + Environment.NewLine);
        }


        public List<T> GetItems()
        {
            var lines = File.ReadAllLines(_filePath);
            var items = new List<T>();

            foreach (var line in lines)
            {
                var parts = line.Split(',');

                if (typeof(T) == typeof(FoodItem))
                {
                    var foodItem = new FoodItem(parts[0], double.Parse(parts[1]), DateTime.Parse(parts[2]), int.Parse(parts[3]));
                    items.Add((T)(object)foodItem);
                }
                else if (typeof(T) == typeof(WeaponItem))
                {
                    var weaponItem = new WeaponItem(parts[0], double.Parse(parts[1]), int.Parse(parts[2]));
                    items.Add((T)(object)weaponItem);
                }
                else if (typeof(T) == typeof(MedicalItem))
                {
                    var medicalItem = new MedicalItem(parts[0], double.Parse(parts[1]), DateTime.Parse(parts[2]), parts[3]);
                    items.Add((T)(object)medicalItem);
                }
                else
                {
                    throw new InvalidOperationException("Unknown item type");
                }
            }

            return items;
        }


        public T GetItem(string name)
        {
            List<T> items = GetItems();

            foreach (T item in items)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }

            return null;
        }

        public List<T> GetItemsErrorSearch()
        {
            var lines = File.ReadAllLines(_filePath);  
            var items = new List<T>();

            foreach (var line in lines)
            {
                var parts = line.Split(',');

                // Atspausdiname dalis, kad pamatytume, kas tiksliai yra dalijamasis
                Console.WriteLine($"Eilutė: {line}");
                Console.WriteLine($"Dalių skaičius: {parts.Length}");
                for (int i = 0; i < parts.Length; i++)
                {
                    Console.WriteLine($"Dalis {i}: {parts[i]}");
                }

                if (typeof(T) == typeof(FoodItem) && parts.Length == 4)
                {
                    try
                    {
                        var foodItem = new FoodItem(parts[0],
                                                    double.Parse(parts[1]),
                                                    DateTime.Parse(parts[2]),
                                                    int.Parse(parts[3]));
                        items.Add((T)(object)foodItem);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Klaida konvertuojant eilutę: {line}. Klaidos pranešimas: {ex.Message}");
                    }
                }
                else if (typeof(T) == typeof(WeaponItem) && parts.Length == 3)
                {
                    try
                    {
                        var weaponItem = new WeaponItem(parts[0],
                                                        double.Parse(parts[1]),
                                                        int.Parse(parts[2]));
                        items.Add((T)(object)weaponItem);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Klaida konvertuojant eilutę: {line}. Klaidos pranešimas: {ex.Message}");
                    }
                }
                else if (typeof(T) == typeof(MedicalItem) && parts.Length == 4)
                {
                    try
                    {
                        var medicalItem = new MedicalItem(parts[0],
                                                          double.Parse(parts[1]),
                                                          DateTime.Parse(parts[2]),
                                                          parts[3]);
                        items.Add((T)(object)medicalItem);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Klaida konvertuojant eilutę: {line}. Klaidos pranešimas: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine($"Nežinomas arba netinkamas formatas eilutei: {line}");
                }
            }

            return items;
        }
    }
}
