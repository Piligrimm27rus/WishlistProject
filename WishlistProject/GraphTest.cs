using System;
using WishlistLibrary.Controllers;
using WishlistLibrary.Models;


namespace WishlistProject
{
    class GraphTest
    {
        ShopController shopController;
        public GraphTest()
        {
            shopController = new ShopController();

            var location1 = new Home("Дом", "Даниловского 29");
            var location2 = new Shop("Пятерочка", "Стрельникова");
            var location3 = new Shop("Десяточка", "Бондаря 19");

            shopController.AddNewLocation(location1);
            shopController.AddNewLocation(location2);
            shopController.AddNewLocation(location3);

            shopController.AddNewRoad(location1, location2, 1);
            shopController.AddNewRoad(location1, location3, 1);

            var matrix = shopController.GetMatrix();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    Console.Write(matrix[i, k].ToString() + "\t");
                }

                Console.WriteLine();
            }

            AllRoadsFrom(location1);
        }

        private void AllRoadsFrom(ILocation location)
        {
            Console.WriteLine(location + ": ");
            foreach (var item in shopController.GetLocationsFrom(location))
            {
                Console.Write(item + ", ");
            }
        }
    }
}
