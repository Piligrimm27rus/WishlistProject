using System;
using WishlistLibrary;
using WishlistLibrary.Models;
using WishlistLibrary.Controllers;

namespace WishlistProject
{
    class Program
    {
        static void Main(string[] args)
        {






            var g = new WishlistLibrary.Graph();

            //добавление вершин
            g.AddVertex("A");
            g.AddVertex("B");
            g.AddVertex("C");
            g.AddVertex("D");
            g.AddVertex("E");
            g.AddVertex("F");
            g.AddVertex("G");

            //добавление ребер
            g.AddEdge("A", "B", 22);
            g.AddEdge("A", "C", 33);
            g.AddEdge("A", "D", 61);
            g.AddEdge("B", "C", 47);
            g.AddEdge("B", "E", 93);
            g.AddEdge("C", "D", 11);
            g.AddEdge("C", "E", 79);
            g.AddEdge("C", "F", 63);
            g.AddEdge("D", "F", 41);
            g.AddEdge("E", "F", 17);
            g.AddEdge("E", "G", 58);
            g.AddEdge("F", "G", 84);

            var dijkstra = new Dijkstra(g);
            var path = dijkstra.FindShortestPath("A", "G");
            Console.WriteLine(path);
            Console.ReadLine();











            Console.WriteLine("Добро пожаловать в приложение по учету покупок.\n");

            /*
             A - взять машину / оставить машину
             D - Добавить магазин в список
             
             */

            GraphTest graphTest = new GraphTest();

            Console.WriteLine("Поедете в магазин на машине? да|нет"); // TODO: Сделать метод которые проверяет на да|нет

            bool withCar = Console.ReadLine().ToLower() == "да";
            
            if (withCar) //сделать через switch
            {
                Console.WriteLine("Введите название машины");

                string carModel = Console.ReadLine();

                CarController carController = new CarController(carModel);

                if (carController.isNewCar)
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

                    carController.SetNewCar(carModel, fuelController.currentFuel, carExpenditure);
                }

                foreach (var item in carController.cars)
                {
                    Console.WriteLine(item);
                }
            }

            Console.Write("");

            Console.ReadKey();
        }
    }
}