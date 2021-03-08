using System;
using WishlistLibrary;
using System.Collections.Generic;
using WishlistLibrary.Models;
using WishlistLibrary.Controllers;

namespace WishlistProject
{
    class Program
    {
        static CarController car = null;
        static List<string> products = new List<string>(); //Список покупок
        static bool withCar = false;

        static void Main(string[] args)
        {

            bool firstlabel = true;
            GraphTest graphTest = new GraphTest(); //карта магазинов

            while (true)
            {
                if (!firstlabel)
                {
                    Console.Clear();
                    firstlabel = false;
                }
                else
                    Console.WriteLine("Добро пожаловать в приложение по учету покупок.\n");

                Console.WriteLine(withCar == true ? "A - взять машину" : "A - оставить машину");
                Console.WriteLine("D - Добавить продукт в список");
                Console.WriteLine("X - Выйти из приложения");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                        TakeOrUntakeCar(withCar);
                        break;
                    case ConsoleKey.D:
                        AddProductToWishlist(Console.ReadLine());
                        break;
                    case ConsoleKey.X:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void AddProductToWishlist(string product)
        {
            if (string.IsNullOrWhiteSpace(product))
            {
                throw new ArgumentNullException("Продукт не может быть пустым", nameof(product));
            }

            products.Add(product);
        }

        private static void TakeOrUntakeCar(bool withCar)
        {
            if (!withCar)
            {
                Console.WriteLine("Введите название машины");

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
                    withCar = true;
                }
            }
            else
            {
                withCar = false;
                car = null;
            }
        }
    }
}