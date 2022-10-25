using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface IProductRepository<TEntity>
    {
        int CreateProduct(TEntity entity);
        void DeleteProduct(int id);
        void UpdateProduct(int id,TEntity entity);
        TEntity GetProductById(int id);
        TEntity GetProductByPurchase(int purchaseId);
        IEnumerable<TEntity> GetProducts();
        IEnumerable<TEntity> GetProductsByProducerId(int producerId);
    }
}
