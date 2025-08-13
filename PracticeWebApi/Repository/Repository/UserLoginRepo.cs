using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class UserLoginRepo : IUserLogin
    {
        private readonly AppDBContext dbContext;
        public UserLoginRepo(AppDBContext _dbContext) 
        {
            dbContext = _dbContext;
        }
        public async Task<UserLogin> GetbyUserIdAsync(UserLogin userLogin)
        {
            var data = await dbContext.UserLogin.Where(x => x.UserName == userLogin.UserName).FirstOrDefaultAsync();
            return data;
        }
    }
}
