using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface IPurchaseRepository<TEntity>
    {
        int CreatePurchase(TEntity entity);
        TEntity GetPurchaseById(int id);
        IEnumerable<TEntity> GetPurchaseByCustomerId(int customerId);
    }
}
