using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
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

            [SecuredOperation("carimage.crud,admin", Priority = 1)]
            [ValidationAspect(typeof(CarImageValidator))]
            [CacheRemoveAspect("ICarImageService.Get")]
            public IResult Add(CarImage carImage, IFormFile file)
            {
                IResult result = BusinessRules.Run(
                    CheckIfImageLimit(carImage.CarId)
                    );

                if (result != null)
                {
                    return result;
                }

                carImage.ImagePath = FileHelper.AddAsync(file);
                _carImageDal.Add(carImage);
                return new SuccessResult();
            }

            [SecuredOperation("carimage.crud", Priority = 1)]
            [ValidationAspect(typeof(CarImageValidator))]
            [CacheRemoveAspect("ICarImageService.Get")]
            public IResult Update(CarImage carImage, IFormFile file)
            {
                var oldpath = $@"{Environment.CurrentDirectory}\wwwroot{_carImageDal.Get(p => p.Id == carImage.Id).ImagePath}";
                carImage.ImagePath = FileHelper.UpdateAsync(oldpath, file);

                _carImageDal.Update(carImage);
                return new SuccessResult();
            }

            [SecuredOperation("carimage.crud")]
            [CacheRemoveAspect("IProductService.Get")]
            public IResult Delete(CarImage carImage)
            {
                var oldpath = $@"{Environment.CurrentDirectory}\wwwroot{_carImageDal.Get(p => p.Id == carImage.Id).ImagePath}";
                FileHelper.DeleteAsync(oldpath);

                _carImageDal.Delete(carImage);
                return new SuccessResult();
            }

            [CacheAspect] 
            public IDataResult<CarImage> Get(int Id)
            {
                return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == Id));
            }


            [CacheAspect]
            public IDataResult<List<CarImage>> GetAll()
            {
                //Thread.Sleep(6000);
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
            }

            [CacheAspect]   
            public IDataResult<List<CarImage>> GetImagesByCarId(int CarId)
            {
                var result = _carImageDal.GetAll(c => c.CarId == CarId).Any();
                if (!result)
                {
                    List<CarImage> carimage = new List<CarImage>();
                    carimage.Add(new CarImage { CarId = CarId, ImagePath = @"\Images\default.jpg" });
                    return new SuccessDataResult<List<CarImage>>(carimage);
                }
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == CarId));
            }

            private IResult CheckIfImageLimit(int CarId)
            {
                var carImagecount = _carImageDal.GetAll(p => p.CarId == CarId).Count;
                if (carImagecount >= 5)
                {
                    return new ErrorResult(Messages.FailAddedImageLimit);
                }

                return new SuccessResult();
            }
        }
    }
