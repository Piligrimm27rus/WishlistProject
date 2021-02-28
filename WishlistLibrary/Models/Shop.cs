using System;
using System.Collections.Generic;
using System.Text;

namespace WishlistLibrary.Models
{
    /// <summary>
    /// Магазин
    /// </summary>
    [Serializable]
    public class Shop : ILocation
    {
        /// <summary>
        /// Название магазина
        /// </summary>
        public string Name { get; }


        /// <summary>
        /// Адрес магазина
        /// </summary>
        public string Location { get; }

        /// <summary>
        /// Продукты в магазине
        /// </summary>
        public List<Product> Products { get; }

        public Shop(string name, string location)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название магазина не может быть пустым или быть Null", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(location))
            {
                throw new ArgumentNullException("Адрес магазина не может быть пустым или быть Null", nameof(location));
            }

            Name = name;
            Location = location;
            Products = new List<Product>();
        }

        public override string ToString()
        {
            return Name;
        }   
    }
}
