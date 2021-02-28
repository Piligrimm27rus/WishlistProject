using System;

namespace WishlistLibrary.Models
{
    public class Home : ILocation
    {
        /// <summary>
        /// Название дома
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Адрес дома
        /// </summary>
        public string Location { get; }

        public Home(string name, string location)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название дома не может быть пустым или быть Null", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(location))
            {
                throw new ArgumentNullException("Адрес дома не может быть пустым или быть Null", nameof(location));
            }
            
            Name = name;
            Location = location;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
