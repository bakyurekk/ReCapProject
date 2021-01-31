using Business.Abstract;
using DataAccess.Abstract;
using Entities.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contract
{
    public class CarManager : ICarService
    {
        ICarDal  _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public List<Car> GetAll()
        {
            // İş Kodları

            return _carDal.GetAll();
        }
    }
}
