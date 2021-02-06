using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Contract.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,ReCapProjectDbContext> ,ICarDal
    {
        
    }
}
