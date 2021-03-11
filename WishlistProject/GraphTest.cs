using System;
using WishlistLibrary;
using WishlistLibrary.Controllers;
using WishlistLibrary.Models;


namespace WishlistProject
{
    class GraphTest
    {
        public GraphController graphController;
        public GraphTest()
        {
            Random rnd = new Random();
            graphController = new GraphController();

            var location1 = new Home("Дом", "Пушкино 31");
            var location2 = new Shop("Пятерочка", "Стрельникова 1") { Products = { new Product("Банан", rnd.Next(10,50)), new Product("Лук", rnd.Next(10,50)) } };
            var location3 = new Shop("Самбери", "Стрельникова 2") { Products = { new Product("Чеснок", rnd.Next(10,50)), new Product("Помело", rnd.Next(10,50)) } };
            var location4 = new Shop("Продукты шмадукты", "Стрельникова 3") { Products = { new Product("Груша", rnd.Next(10,50)), new Product("Суп", rnd.Next(10,50)) } };
            var location5 = new Shop("Светофор", "Стрельникова 4") { Products = { new Product("Орех", rnd.Next(10,50)), new Product("Морковь", rnd.Next(10,50)) } };
            var location6 = new Shop("Десяточка", "Стрельникова 5") { Products = { new Product("Йогурт", rnd.Next(10,50)), new Product("Каша", rnd.Next(10,50)) } };
            var location7 = new Shop("Девяточка", "Стрельникова 6") { Products = { new Product("Дыня", rnd.Next(10,50)), new Product("Горох", rnd.Next(10,50)) } };

            //добавление вершин
            graphController.AddNewLocation(location1);
            graphController.AddNewLocation(location2);
            graphController.AddNewLocation(location3);
            graphController.AddNewLocation(location4);
            graphController.AddNewLocation(location5);
            graphController.AddNewLocation(location6);
            graphController.AddNewLocation(location7);

            //Добавление дорог
            graphController.AddNewRoad(location1, location2, 22);
            graphController.AddNewRoad(location1, location3, 33); //A-C
            graphController.AddNewRoad(location1, location4, 61);
            graphController.AddNewRoad(location2, location3, 47);
            graphController.AddNewRoad(location2, location5, 93);
            graphController.AddNewRoad(location3, location4, 11); //C-D
            graphController.AddNewRoad(location3, location5, 79);
            graphController.AddNewRoad(location3, location6, 63);
            graphController.AddNewRoad(location4, location6, 41); //D-F
            graphController.AddNewRoad(location5, location6, 17); //F-E
            graphController.AddNewRoad(location5, location7, 58); //E-G
            graphController.AddNewRoad(location6, location7, 84);

            //var path1 = graphController.FindShortestPath("A", "G"); //ACDFEG


            //for (int i = 0; i < path1.Count; i++)
            //{
            //    Console.WriteLine(path1[i].Location);
            //}
        }

        private void AllRoadsFrom(ILocation location)
        {
            Console.WriteLine(location + ": ");
            foreach (var item in graphController.GetLocationsFrom(location))
            {
                Console.Write(item + ", ");
            }
        }
    }
}
