using Entities.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService:IEntityService<Car>
    {

        List<Car> GetCarsByBrandId(int id);

        List<Car> GetCarsByColorId(int id);


    }
}
