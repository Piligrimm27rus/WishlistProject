using System.Collections.Generic;
using WishlistLibrary.Models;
using System.Text;
using System;
using System.Linq;

namespace WishlistLibrary.Controllers
{
    public class GraphController
    {
        List<GraphVertexInfo> infos;

        private List<RoadFromTo> roads { get; } //Edge
        private List<ILocation> locations { get; } //Vertex

        public int LocationsCount => locations.Count;
        public int RoadsCount => roads.Count;

        public List<Shop> Shops = new List<Shop>();

        public GraphController()
        {
            roads = new List<RoadFromTo>();
            locations = new List<ILocation>();
        }

        void InitInfo()
        {
            infos = new List<GraphVertexInfo>();
            foreach (var v in locations)
            {
                infos.Add(new GraphVertexInfo(v));
            }
        }

        public void AddNewLocation(ILocation location) //вершина
        {
            if (location == null)
            {
                throw new ArgumentNullException("Локация не может быть равна Null", nameof(location));
            }

            if (location is Shop)
            {
                Shops.Add((Shop)location);
            }

            locations.Add(location);
        }

        public void AddNewRoad(ILocation from, ILocation to, double lenght = 1) //ребро
        {
            RoadFromTo roadFrom = new RoadFromTo(from, to, lenght);
            RoadFromTo roadTo = new RoadFromTo(to, from, lenght);
            roads.Add(roadFrom);
            roads.Add(roadTo);
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

        public ILocation FindVertex(string vertexName)
        {
            foreach (var v in locations)
            {
                if (v.Name.Equals(vertexName))
                {
                    return v;
                }
            }

            return null;
        }

        GraphVertexInfo GetVertexInfo(ILocation v)
        {
            foreach (var i in infos)
            {
                if (i.Vertex.Equals(v))
                {
                    return i;
                }
            }

            return null;
        }

        public GraphVertexInfo FindUnvisitedVertexWithMinSum()
        {
            var minValue = double.MaxValue;
            GraphVertexInfo minVertexInfo = null;
            foreach (var i in infos)
            {
                if (i.IsUnvisited && i.EdgesWeightSum < minValue)
                {
                    minVertexInfo = i;
                    minValue = i.EdgesWeightSum;
                }
            }

            return minVertexInfo;
        }

        public List<ILocation> FindShortestPath(string startName, string finishName)
        {
            return FindShortestPath(FindVertex(startName), FindVertex(finishName));
        }

        public List<ILocation> FindShortestPath(ILocation startVertex, ILocation finishVertex)
        {
            InitInfo();
            var first = GetVertexInfo(startVertex);
            first.EdgesWeightSum = 0;
            while (true)
            {
                var current = FindUnvisitedVertexWithMinSum();
                if (current == null)
                {
                    break;
                }

                SetSumToNextVertex(current);
            }

            return GetPath(startVertex, finishVertex);
        }

        void SetSumToNextVertex(GraphVertexInfo info)
        {
            info.IsUnvisited = false;
            foreach (var e in GetAllEdges(info.Vertex.Name))
            {
                var nextInfo = GetVertexInfo(e.To);
                var sum = info.EdgesWeightSum + e.Lenght;
                if (sum < nextInfo.EdgesWeightSum)
                {
                    nextInfo.EdgesWeightSum = sum;
                    nextInfo.PreviousVertex = info.Vertex;
                }
            }
        }

        private List<RoadFromTo> GetAllEdges(string vertexName)
        {
            var list = roads.Where(r => r.From.Name == vertexName);

            List<RoadFromTo> edgesList = new List<RoadFromTo>();

            foreach (var e in list)
            {
                edgesList.Add(e);
            }

            return edgesList;
        }

        List<ILocation> GetPath(ILocation startVertex, ILocation endVertex)
        {
            //var path = endVertex.ToString();
            List<ILocation> path = new List<ILocation>() { endVertex };

            while (startVertex != endVertex)
            {
                endVertex = GetVertexInfo(endVertex).PreviousVertex;
                //path = endVertex + path;
                path.Insert(0, endVertex);
            }

            return path;
        }
    }
}
