using Entities.Contract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService:IEntityService<Car>
    {
        List<Car> GetCarsByBrandId(int id);

        List<Car> GetCarsByColorId(int id);

        List<CarDetailDto> GetCarDetails();

    }
}
