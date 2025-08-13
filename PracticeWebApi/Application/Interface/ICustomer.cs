using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ICustomer
    {
        Task<List<Customer>> GetAll();
        Task<Customer> SaveUpdate(Customer customer);
        Task<Customer> GetById(int id);
        Task<Customer> Delete(int id);
    }
}
