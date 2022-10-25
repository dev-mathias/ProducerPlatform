using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface ICustomerRepository<TEntity>
    {
        int CreateCustomer(TEntity entity);
        TEntity GetCustomerById(int id);
        TEntity GetCustomerByPurchase(int purchaseId);
        TEntity? CheckCustomer(string email, string password);
    }
}
