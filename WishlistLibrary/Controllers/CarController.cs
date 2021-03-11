using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WishlistLibrary.Models;

namespace WishlistLibrary.Controllers
{
    public class CarController : ControllerBase
    {
        public List<Car> cars { get; }

        /// <summary>
        /// Название файла для списка сохраненных машин
        /// </summary>
        public const string FILE_NAME = "cars.bin";

        /// <summary>
        /// Проверка на новую машину в списке сохраненных машин
        /// </summary>
        public bool isNewCar { get; }

        /// <summary>
        /// Текущая машина пользователя
        /// </summary>
        public Car currentCar { get; private set; }

        public CarController(string carModel)
        {
            cars = Load<List<Car>>(FILE_NAME) ?? new List<Car>();

            currentCar = cars.SingleOrDefault(x => x.Model == carModel);

            if (currentCar == null)
            {
                currentCar = new Car(carModel);
                cars.Add(currentCar);
                isNewCar = true;
            }
        }

        public void SetNewCar(string carModel, Fuel fuel,double carExpenditure)
        {
            cars[cars.Count - 1] = new Car(carModel, fuel, carExpenditure);
            currentCar = cars[cars.Count - 1];
            Save(FILE_NAME, cars);
        }
    }
}
