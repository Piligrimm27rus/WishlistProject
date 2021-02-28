using System;

namespace WishlistLibrary
{
    /// <summary>
    /// Продукт
    /// </summary>
    [Serializable]
    public class Product
    {
        /// <summary>
        /// Название продукта.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Цена продукта.
        /// </summary>
        public int Price { get; set; }

        public Product(string name, int price)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Название товара не может быть пустым или быть равным Null.", nameof(name));
            }

            if (price <= 0)
            {
                throw new ArgumentException("Цена товара не может быть равна 0 или быть отрицательна.", nameof(price));
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
