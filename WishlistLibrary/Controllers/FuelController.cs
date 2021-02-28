using System;
using System.Collections.Generic;
using System.Linq;
using WishlistLibrary.Models;

namespace WishlistLibrary.Controllers
{
    public class FuelController : ControllerBase
    {
        /// <summary>
        /// Имя файлов сохраненными данными о топливе
        /// </summary>
        private readonly string FILE_NAME = "Fuel.bin";

        /// <summary>
        /// Список топлив
        /// </summary>
        public List<Fuel> fuels { get; }

        /// <summary>
        /// Текущее топливо машины
        /// </summary>
        public Fuel currentFuel { get; private set; }

        /// <summary>
        /// Проверка на новое топливо если такого топлива не было в списке
        /// </summary>
        public bool isNewFuel { get; set; } = false;

        public FuelController(string fuelName)
        {
            fuels = Load<List<Fuel>>(FILE_NAME) ?? new List<Fuel>();

            currentFuel = fuels.SingleOrDefault(fuel => fuel.Name == fuelName);

            if (currentFuel == null)
            {
                currentFuel = new Fuel(fuelName);
                fuels.Add(currentFuel);
                isNewFuel = true;
            }
        }

        public void SetNewData(double fuelPrice)
        {
            currentFuel.Price = fuelPrice;
            Save(FILE_NAME, fuels);
        }
    }
}
