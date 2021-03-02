using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofact.Validation;
using Core.Ultilities.Results;
using DataAccess.Abstract;
using Entities.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contract
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }


        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {

            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.NameInvalide);
            }

            _brandDal.Add(brand);

            return new SuccessResult(Messages.AddedMessages);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.DeletedMessages);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Brand>>(_brandDal.GetAll(), Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id));
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.UpdatedMessages);
        }
    }
}
