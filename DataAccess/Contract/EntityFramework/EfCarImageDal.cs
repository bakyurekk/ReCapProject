using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Contract.EntityFramework
{
    public class EfCarImageDal:EfEntityRepositoryBase<CarImage,ReCapProjectDbContext>,ICarImageDal
    {
    }
}
