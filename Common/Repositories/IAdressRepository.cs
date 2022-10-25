using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface IAdressRepository<TEntity>
    {
        TEntity GetAdressById(int id);
        int CreateAdress(TEntity entity);
        TEntity GetAdressByCustomer(int customerId);
        TEntity GetAdressByProducer(int customerId);
        IEnumerable<TEntity> GetAdresses();
    }
}
