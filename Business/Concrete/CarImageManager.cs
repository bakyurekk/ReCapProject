using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofact.Validation;
using Core.Ultilities.BusinessRules;
using Core.Ultilities.Results;
using Core.Utilities.FileHelper;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file,CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitedExceded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.AddAsync(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                CarImageDelete(carImage),
                FileHelper.DeleteAsync(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult();

        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.UpdateAsync(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {

            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.Id == id));
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.Id == id));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id));
        }


        // -- Bussines Rules Code -- 
        private IResult CheckIfCarImageLimitedExceded(int id)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == id).Count();
            if (result >5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }

        private List<CarImage> CheckIfCarImageNull(int id)
        {
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images\default.jpg");
            var result = _carImageDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now } };
            }
            return _carImageDal.GetAll(p => p.CarId == id);
        }

        private IResult CarImageDelete(CarImage carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }


    }
}
