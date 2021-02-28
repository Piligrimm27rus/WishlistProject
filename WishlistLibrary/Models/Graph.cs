using System;
using System.Collections.Generic;
using System.Text;

namespace WishlistLibrary.Models
{
    // TODO: Сделать может быть в будущем
    public class Graph
    {
        /// <summary>
        /// Название графа
        /// </summary>
        public string Name { get; }

        //Граф
        public List<RoadFromTo> Roads { get; } //Edge
        public List<ILocation> Locations { get; } //Vertex

        
    }
}
