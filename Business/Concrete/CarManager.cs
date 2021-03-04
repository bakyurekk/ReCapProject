using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofact.Validation;
using Core.Ultilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal  _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            _carDal.Add(car);

            return new SuccessResult(Messages.AddedMessages);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.DeletedMessages);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>( _carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<Car>> GetAll()
        {

            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(_carDal.GetAll(),Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>( _carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarDetails(),Messages.CarDetail);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(c => c.ColorId == id));
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.UpdatedMessages);
        }
    }
}
