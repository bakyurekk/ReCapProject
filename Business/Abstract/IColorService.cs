using Core.Ultilities.Results;
using Entities.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int id);
        IResult Add(Color color);

        IResult Delete(Color color);

        IResult Update(Color color);
    }
}
