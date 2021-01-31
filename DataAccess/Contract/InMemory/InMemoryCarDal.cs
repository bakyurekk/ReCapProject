using DataAccess.Abstract;
using Entities.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Contract.InMemory
{
   public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
                {
                    new Car{CarId=1, BrandId=1, ColorId=1, ModelYear="2015", DailyPrice=50000, Description="Ford Mustang"},
                    new Car{CarId=2, BrandId=2, ColorId=3, ModelYear="2019", DailyPrice=45000, Description="Wolsvogen Golf"},
                    new Car{CarId=3, BrandId=2, ColorId=2, ModelYear="2020", DailyPrice=78000, Description="Wolsvogen Pasat"},
                    new Car{CarId=4, BrandId=1, ColorId=2, ModelYear="2009", DailyPrice=90000, Description="Ford Fiesta"},
                    new Car{CarId=5, BrandId=1, ColorId=3, ModelYear="2017", DailyPrice=48500, Description="Ford Mustang"},
                };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId );

            _cars.Remove(carToDelete);
        }
        

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int brandId)
        {
            _cars.Where(c => c.BrandId == brandId).ToList();
            return _cars;
        }

        public void Update(Car car)
        {
            Car CarToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            CarToUpdate.BrandId = car.BrandId;
            CarToUpdate.ColorId = car.ColorId;
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.Description = car.Description;

        }
    }
}
