using System;
using WishlistLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace WishlistProject
{
    static class Calculate
    {
        public static void CalculateCost()
        {
            double finalCost = 0;

            Console.WriteLine("");
            if (Program.wishlist.Count == 0)
            {
                Console.WriteLine("Список покупок пуст!");
                return;
            }

            for (int i = 0; i < Program.wishlist.Count; i++) //Вывести все
            {
                var name = Program.wishlist[i].Item2.Name;
                var productPrice = Program.wishlist[i].Item2.Price;
                Console.WriteLine($"{name}\t-\t{productPrice}руб.");
            }

            finalCost += AllProductsPrice();
            WriteLineRedColor($"Итого по продуктам: {finalCost}руб.");

            if (Program.car != null)
            {
                finalCost += FuelPrice();
            }

            WriteLineRedColor($"Конечная стоимость {finalCost}руб.");

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        private static double FuelPrice() //Возможно это нужно делать в контроллере (и разделить на несколько методов)
        {
            var car = Program.car;
            double fuelPrice =  car.currentCar.Fuel.Price; //Цена бензина
            double expenditure = car.currentCar.Expenditure; //Расход машины
            double allDistance = 0; //Общая дистанция пройденая на машине
            ILocation currentPosition = Program.graphTest.graphController.locations[0]; //Текущая позиция
            List<Shop> allShops = new List<Shop>(); //Все магазины которые необходимо посетить (без повторений)

            for (int i = 0; i < Program.wishlist.Count; i++)
            {
                if (!allShops.Contains(Program.wishlist[i].Item1))
                {
                    allShops.Add(Program.wishlist[i].Item1);
                }
            }

            Console.WriteLine("Построение оптимального пути");
            for (int i = 0; i < allShops.Count; i++)
            {
                var path = Program.graphTest.graphController.FindShortestPath(currentPosition.Name, allShops[i].Name);

                allDistance += Program.graphTest.graphController.GetDistance(path);

                Console.WriteLine(string.Join(" -> ", path));

                currentPosition = path[path.Count - 1];
            }

            double total = (fuelPrice * expenditure / (100 / allDistance));
            WriteLineRedColor($"Итого расход топлива: {total}руб.");
            return total;
        }

        private static void WriteLineRedColor(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(str);

            Console.ResetColor();
        }

        private static double AllProductsPrice()
        {
            return Program.wishlist.Sum(x => x.Item2.Price);
        }
    }
}
