using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Contract;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Contract.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectDbContext context = new ReCapProjectDbContext())
            {
                var resault = from c in context.Cars
                              join cr in context.Colors on c.ColorId equals cr.ColorId
                              join b in context.Brands on c.BrandId equals b.BrandId
                              select new CarDetailDto
                              {
                                  CarName = c.CarName,
                                  BrandName = b.BrandName,
                                  ColorName = cr.ColorName,
                                  DailyPrice =c.DailyPrice
                                  
                              };
                return resault.ToList();

            }
        }
    }
}
