using D=DAL_Producteur.Entities;
using B=BLL_Producteur.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repositories;
using static BLL_Producteur.Mapper.Mapper;
using BLL_Producteur.Entities;

namespace BLL_Producteur.Service
{
    public class PurchaseService : IPurchaseRepository<B.Purchase>
    {
        private readonly IPurchaseRepository<D.Purchase> _purchaseRepository;
        private readonly IProductRepository<B.Product> _productRepository;
        private readonly ICustomerRepository<B.Customer> _customerRepository;
        private readonly IProducerRepository<B.Producer> _producerRepository;
        public PurchaseService(IPurchaseRepository<D.Purchase> purchaseRepository, IProductRepository<B.Product> productRepository, ICustomerRepository<B.Customer> customerRepository, IProducerRepository<B.Producer> producerRepository )
        {
            _purchaseRepository = purchaseRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _producerRepository = producerRepository;
        }

        public int CreatePurchase(B.Purchase entity)
        {
            Product productToUpdate = entity.Product;
            productToUpdate.Quantity = productToUpdate.Quantity - entity.Quantity;
            _productRepository.UpdateProduct(productToUpdate.Id, productToUpdate);
            return _purchaseRepository.CreatePurchase(entity.ToDal());
        }

        public IEnumerable<Purchase> GetPurchaseByCustomerId(int customerId)
        {   
            IEnumerable<Purchase> entities= _purchaseRepository.GetPurchaseByCustomerId(customerId).ToBll();
            entities=entities.Select(p =>
                {
                    p.Product = _productRepository.GetProductByPurchase(p.Id);
                    p.Product.Producer = _producerRepository.GetProducerByProduct(p.Product.Id);
                    p.Customer=_customerRepository.GetCustomerById(customerId);
                    return p;
                });
            return entities;
        }

        public B.Purchase GetPurchaseById(int id)
        {
            B.Purchase purchase = _purchaseRepository.GetPurchaseById(id).ToBll();
            purchase.Customer = _customerRepository.GetCustomerByPurchase(id);
            purchase.Product = _productRepository.GetProductByPurchase(id);
            purchase.Product.Producer = _producerRepository.GetProducerByProduct(purchase.Product.Id);
            return purchase;
        }
    }
}
