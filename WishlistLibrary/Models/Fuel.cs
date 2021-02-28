using System;

namespace WishlistLibrary.Models
{
    [Serializable]
    public class Fuel
    {
        /// <summary>
        /// Название топлива
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Цена топлива
        /// </summary>
        public double Price { get; set; }

        public Fuel(string name) :this(name, 1) { } 

        public Fuel(string name, double price)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Название топлива не может быть пустым или быть равным Null.", nameof(name));
            }

            if (price <= 0)
            {
                throw new ArgumentException("Цена топлива не может быть равна 0 или быть отрицательна.", nameof(price));
            }

            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}