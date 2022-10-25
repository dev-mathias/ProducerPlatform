using Common.Repositories;
using D= DAL_Producteur.Entities;
using B = BLL_Producteur.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Producteur.Entities;
using BLL_Producteur.Mapper;
using static BLL_Producteur.Mapper.Mapper;
namespace BLL_Producteur.Service
{
    public class CustomerService:ICustomerRepository<B.Customer>
    {
        private readonly ICustomerRepository<D.Customer> _customerRepo;
        private readonly IAdressRepository<B.Address> _adressRepo;
        public CustomerService(ICustomerRepository<Customer> customerRepo, IAdressRepository<B.Address> adressRepository)
        {
            _customerRepo = customerRepo;   
            _adressRepo = adressRepository;
        }

        public B.Customer? CheckCustomer(string email, string password)
        {   
            B.Customer? customer= _customerRepo.CheckCustomer(email, password).ToBll();
            if (customer is null) return null;
            else
            {
                customer.Address = _adressRepo.GetAdressByCustomer(customer.Id);
                return customer;
            }
        }

        public int CreateCustomer(B.Customer entity)
        {
           return _customerRepo.CreateCustomer(entity.ToDal());
        }

        public B.Customer GetCustomerById(int id)
        {   
            B.Customer customer= _customerRepo.GetCustomerById(id).ToBll();
            customer.Address=_adressRepo.GetAdressByCustomer(id);
            return customer;
        }

        public B.Customer GetCustomerByPurchase(int purchaseId)
        {
            B.Customer customer = _customerRepo.GetCustomerByPurchase(purchaseId).ToBll();
            customer.Address = _adressRepo.GetAdressByCustomer(customer.Id);
            return customer;
        }
    }
}
