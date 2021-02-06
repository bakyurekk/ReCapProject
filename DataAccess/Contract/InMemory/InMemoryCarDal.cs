using DataAccess.Abstract;
using Entities.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Contract.InMemory
{
   public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        readonly List<Brand> _brands;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
                {
                    new Car{CarId=1, BrandId=1, ColorId=1, ModelYear=2015, DailyPrice=50000, Description="Ford Mustang"},
                    new Car{CarId=2, BrandId=4, ColorId=3, ModelYear=2019, DailyPrice=45000, Description="Opel Astra"},
                    new Car{CarId=3, BrandId=2, ColorId=2, ModelYear=2020, DailyPrice=78000, Description="Volkswagen Pasat"},
                    new Car{CarId=4, BrandId=3, ColorId=2, ModelYear=2009, DailyPrice=90000, Description="Mercedes G35"},
                    new Car{CarId=5, BrandId=5, ColorId=3, ModelYear=2017, DailyPrice=48500, Description="Seat Leon"},
                };

            _brands = new List<Brand>
            {
                new Brand{BrandId=1, BrandName="Ford"},
                new Brand{BrandId=2, BrandName="Volkswagen"},
                new Brand{BrandId=3, BrandName="Mercedes"},
                new Brand{BrandId=4, BrandName="Opel"},
                new Brand{BrandId=5, BrandName="Seat"},
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


        public void Update(Car car)
        {
            Car CarToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            CarToUpdate.BrandId = car.BrandId;
            CarToUpdate.ColorId = car.ColorId;
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.Description = car.Description;

        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
