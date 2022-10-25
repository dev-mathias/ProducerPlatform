using BLL_Producteur.Entities;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B = BLL_Producteur.Entities;
using D = DAL_Producteur.Entities;
using static BLL_Producteur.Mapper.Mapper;

namespace BLL_Producteur.Service
{
    public class ProductService : IProductRepository<Product>
    {   
        private readonly IProductRepository<D.Product> _productRepository;
        private readonly IProducerRepository<B.Producer> _producerRepository;
        public ProductService(IProductRepository<D.Product> productRepository, IProducerRepository<Producer> producerRepository)
        {
            _productRepository = productRepository;
            _producerRepository = producerRepository;
        }

        public int CreateProduct(Product entity)
        {
            return _productRepository.CreateProduct(entity.ToDal());
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }

        public Product GetProductById(int id)
        {
            B.Product product= _productRepository.GetProductById(id).ToBll();
            product.Producer=_producerRepository.GetProducerByProduct(id);
            return product;
        }

        public Product GetProductByPurchase(int purchaseId)
        {
            Product product= _productRepository.GetProductByPurchase(purchaseId).ToBll();
            product.Producer = _producerRepository.GetProducerByProduct(product.Id);
            return _productRepository.GetProductByPurchase(purchaseId).ToBll();
        }

        public IEnumerable<Product> GetProducts()
        { 
            IEnumerable<Product>products=_productRepository.GetProducts().ToBll();
            products=products.Select(p =>
            {
                p.Producer = _producerRepository.GetProducerByProduct(p.Id);
                return p;
            });
            return products;
        }

        public IEnumerable<Product> GetProductsByProducerId(int producerId)
        {
            IEnumerable<Product> products= _productRepository.GetProductsByProducerId(producerId).ToBll();
            products = products.Select(p =>
            {
                p.Producer = _producerRepository.GetProducerByProduct(p.Id);
                return p;
            });
            return products;

        }

        public void UpdateProduct(int id, Product entity)
        {
            _productRepository.UpdateProduct(id, entity.ToDal());
        }
    }
}
