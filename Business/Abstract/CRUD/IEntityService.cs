using Core.Ultilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract.CRUD
{
    public interface ICrudService<T>
    {
        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(int id);
        IResult Add(T entity);

        IResult Delete(T entity);

        IResult Update(T entity);
    }
}
