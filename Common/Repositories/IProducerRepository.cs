using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface IProducerRepository<TEntity>
    {
        int CreateProducer(TEntity entity);
        TEntity GetProducerById(int id);
        TEntity GetProducerByProduct(int productId);
        TEntity? CheckProducer(string email, string password);
        IEnumerable<TEntity> GetProducers();
    }
}
