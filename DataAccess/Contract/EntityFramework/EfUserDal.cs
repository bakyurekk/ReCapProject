using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Contract.EntityFramework
{
    class EfUserDal: EfEntityRepositoryBase<User,ReCapProjectDbContext>,IUserDal
    {
    }
}
