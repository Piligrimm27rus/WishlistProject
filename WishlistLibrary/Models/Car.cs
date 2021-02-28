using System;
using System.Collections.Generic;
using System.Text;

namespace WishlistLibrary.Models
{
    [Serializable]
    public class Car
    {
        /// <summary>
        /// Модель машины
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Расход машины
        /// </summary>
        public double Expenditure { get; set; }

        /// <summary>
        /// Топливо
        /// </summary>
        public Fuel Fuel { get; set; }

        public Car(string model) :this(model, new Fuel("Default", 1), 1) { }

        public Car(string model, Fuel fuel, double expenditure)
        {
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException("Название модели машины не может быть пустым или быть равным Null.", nameof(model));
            }

            if (fuel == null)
            {
                throw new ArgumentNullException("Топливо не можеть быть равен Null.", nameof(fuel));
            }

            if (expenditure <= 0)
            {
                throw new ArgumentException("Расход машины не может быть равен 0 или быть отрицательным.", nameof(expenditure));
            }

            Model = model;
            Fuel = fuel;
            Expenditure = expenditure;
        }

        public override string ToString()
        {
            return Model;
        }
    }
}
