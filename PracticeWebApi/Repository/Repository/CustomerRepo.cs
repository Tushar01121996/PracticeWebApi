using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace Repository.Repository
{
    public class CustomerRepo : ICustomer
    {
        private readonly AppDBContext dbContext;
        public CustomerRepo(AppDBContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<Customer> Delete(int id)
        {
            try
            {
                var data = await dbContext.Customer.Where(x => x.Id == id).FirstOrDefaultAsync();
                dbContext.Remove(data);
                await dbContext.SaveChangesAsync();
                return data;

            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public Task<List<Customer>> GetAll()
        {
            var resultSet = dbContext.Customer.ToListAsync();
            return resultSet;
        }
        public Task<Customer> GetById(int id)
        {
            var resultSet = dbContext.Customer.Where(x => x.Id == id).FirstOrDefaultAsync();
            return resultSet;
        }
        public async Task<Customer> SaveUpdate(Customer customer)
        {
            try
            {
                int resultId = 0;
                if (customer.Id > 0)
                {
                    dbContext.Update(customer);
                    resultId = await dbContext.SaveChangesAsync();
                }
                else
                {
                    await dbContext.AddAsync(customer);
                    resultId = await dbContext.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {

            }
            return customer;
        }
    }
}
