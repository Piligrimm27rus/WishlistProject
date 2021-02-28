using System;

namespace WishlistLibrary.Models
{
    public class RoadFromTo
    {
        public ILocation From { get; set; }
        public ILocation To { get; set; }
        public double Lenght { get; set; }

        public RoadFromTo(ILocation from, ILocation to, double length = 1)
        {
            if (from == null || to == null)
            {
                throw new ArgumentNullException("Локация не может быть равна Null");
            }

            if (length <= 0)
            {
                throw new ArgumentException("Длина не может быть отрицательна или быть 0", nameof(length));
            }

            From = from;
            To = to;
            Lenght = length;
        }

        public override string ToString()
        {
            return $"({From.Name} to {To.Name})";
        }
    }
}
