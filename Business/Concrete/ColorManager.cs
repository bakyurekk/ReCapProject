using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofact.Validation;
using Core.Ultilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.AddedMessages);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.DeletedMessages);
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Color>>(_colorDal.GetAll(), Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }


        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>( _colorDal.Get(color => color.ColorId == id));
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.UpdatedMessages);
        }
    }
}
