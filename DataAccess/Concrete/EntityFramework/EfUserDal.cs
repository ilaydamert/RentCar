using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,ReCarContext>,IUserDal
    {
        public List<UserDetailDto> GetUserDetails()
        {
            using (ReCarContext context = new ReCarContext())
            {
                var result = from u in context.Users join c in context.Customers on u.Id equals c.UserId
                           

                             select new UserDetailDto {Id=u.Id,CompanyName=c.CompanyName,FirstName=u.FirstName,LastName=u.LastName,Email=u.Email,Password=u.Password};
                return result.ToList();
            }
        }
    }
}
