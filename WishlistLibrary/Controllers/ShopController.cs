using System;
using System.Collections.Generic;
using System.Text;
using WishlistLibrary.Models;

namespace WishlistLibrary.Controllers
{
    public class ShopController : ControllerBase
    {
        //Граф
        /// <summary>
        /// Edge
        /// </summary>
        private List<RoadFromTo> roads { get; }
        /// <summary>
        /// Vertex
        /// </summary>
        private List<ILocation> locations { get; }

        public int LocationsCount => locations.Count;
        public int RoadsCount => roads.Count;


        public const string FILE_NAME = "locations.bin";

        public ShopController() //TODO: Добавить загрузку файлов
        {
            //locations = Load<List<ILocation>>(FILE_NAME) ?? new List<ILocation>();

            roads = new List<RoadFromTo>();
            locations = new List<ILocation>();
        }

        public void AddNewLocation(ILocation location)
        {
            if (location == null)
            {
                throw new ArgumentNullException("Локация не может быть равна Null", nameof(location));
            }

            locations.Add(location);
        }

        public void AddNewRoad(ILocation from, ILocation to, double lenght = 1)
        {
            RoadFromTo road = new RoadFromTo(from, to, lenght);
            roads.Add(road);
        }

        public double[,] GetMatrix()
        {
            double[,] matrix = new double[LocationsCount, LocationsCount];

            for (int i = 0; i < RoadsCount; i++)
            {
                int indexRoadFrom = locations.IndexOf(roads[i].From);
                int indexRoadTo = locations.IndexOf(roads[i].To);

                matrix[indexRoadFrom, indexRoadTo] = roads[i].Lenght;
            }

            return matrix;
        }

        public List<ILocation> GetLocationsFrom(ILocation location)
        {
            var locationsList = new List<ILocation>();

            foreach (var road in roads)
            {
                if (location == road.From)
                {
                    locationsList.Add(road.To);
                }
            }

            return locationsList;
        }

        //return: список из всех возможных путей
        public List<List<ILocation>> Method(ILocation start, ILocation finish) //Обход в глубину
        {


            return new List<List<ILocation>>();
        }

        private List<ILocation> Method1(ILocation currentLocation, List<ILocation> path)
        {
            var possibleWays = GetLocationsFrom(currentLocation);

            foreach (var item in possibleWays)
            {
                if (path.Contains(item))
                {
                    return null;
                }
                else
                {
                    path.Add(item);

                }
            }

            return new List<ILocation>();
        }
    }
}