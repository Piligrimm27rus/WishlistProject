using System;
using WishlistLibrary;
using System.Collections.Generic;
using WishlistLibrary.Models;
using WishlistLibrary.Controllers;

namespace WishlistProject
{
    class Program
    {
        internal static CarController car = null;
        internal static List<Tuple<Shop,Product>> wishlist = new List<Tuple<Shop, Product>>(); //Список покупок
        internal static bool withCar = false;
        internal static GraphTest graphTest = new GraphTest(); //карта магазинов

        static void Main(string[] args)
        {

            bool firstlabel = true;

            while (true)
            {
                if (!firstlabel)
                    Console.Clear();
                else
                {
                    firstlabel = false;
                    Console.WriteLine("Добро пожаловать в приложение по учету покупок.\n");
                }

                Menu(); //меню

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                        TakeOrUntakeCar();
                        break;
                    case ConsoleKey.D:
                        ChooseProduct();
                        break;
                    case ConsoleKey.S:
                        ShowWishlist();
                        break;
                    case ConsoleKey.W:
                        Calculate.CalculateCost();
                        break;
                    case ConsoleKey.X:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ShowWishlist()
        {
            if (wishlist.Count == 0)
            {
                Console.WriteLine("\nСписок покупок пуст!");
            }

            Console.WriteLine("");
            for (int i = 0; i < wishlist.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {wishlist[i].Item2.Name}");
            }

            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }

        private static void Menu()
        {
            Console.WriteLine(withCar ? "A - оставить машину" : "A - взять машину");
            Console.WriteLine("D - Добавить продукт в список");
            Console.WriteLine("S - Посмотреть список покупок");
            Console.WriteLine("W - Расчитать конечную стоимость");
            Console.WriteLine("X - Выйти из приложения");
        }

        private static void ChooseProduct()
        {
            char temp;
            while (true)
            {
                //Повторение
                Console.WriteLine("\nВыберите магазин."); // TODO: Убрать повторения

                for (int i = 1; i <= graphTest.graphController.Shops.Count; i++)
                {
                    Console.WriteLine($"{i}. {graphTest.graphController.Shops[i - 1].Name}");
                }

                temp = Console.ReadKey().KeyChar;
                int chosenShop = char.IsDigit(temp) ? int.Parse(temp.ToString()) - 1 : -1;
                if (chosenShop < 0 || chosenShop >= graphTest.graphController.Shops.Count)
                {
                    Console.WriteLine("\nТакого магазина нет!");
                    continue;
                }

                //Повторение
                Console.WriteLine("\nВведите продукт.");
                for (int i = 1; i <= graphTest.graphController.Shops[i - 1].Products.Count; i++)
                {
                    Console.WriteLine($"{i}. {graphTest.graphController.Shops[chosenShop].Products[i - 1]}");
                }

                temp = Console.ReadKey().KeyChar;
                int chosenProduct = char.IsDigit(temp) ? int.Parse(temp.ToString()) - 1: -1;
                if (chosenProduct < 0 || chosenProduct >= graphTest.graphController.Shops[chosenProduct].Products.Count)
                {
                    Console.WriteLine("\nТакого продукта нет!");
                    continue;
                }

                Tuple<Shop, Product> a = new Tuple<Shop, Product>
                    (graphTest.graphController.Shops[chosenShop],
                     graphTest.graphController.Shops[chosenShop].Products[chosenProduct]);

                wishlist.Add(a);

                break;
            }
        }

        private static void TakeOrUntakeCar()
        {
            if (!withCar)
            {
                Console.WriteLine("\nВведите название машины");

                string carModel = Console.ReadLine();

                car = new CarController(carModel);

                if (car.isNewCar)
                {
                    Console.WriteLine("Расход топлива");
                    double carExpenditure = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Название машинного топлива");
                    string fuelName = Console.ReadLine();
                    FuelController fuelController = new FuelController(fuelName);

                    if (fuelController.isNewFuel)
                    {
                        Console.WriteLine("Цена топлива");
                        fuelController.SetNewData(Convert.ToDouble(Console.ReadLine()));
                    }

                    car.SetNewCar(carModel, fuelController.currentFuel, carExpenditure);
                }

                withCar = true;
            }
            else
            {
                withCar = false;
                car = null;
            }
        }
    }
}