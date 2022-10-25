using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_Producteur.Entities;
using BLL_Producteur.Mapper;
using Common.Repositories;
using D = DAL_Producteur.Entities;

namespace BLL_Producteur.Service
{
    public class AdressService : IAdressRepository<Address>
    {
        private readonly IAdressRepository<D.Address> _adressRepo;
        public AdressService(IAdressRepository<D.Address> adressRepo)
        {
            _adressRepo = adressRepo;
        }
    
        public int CreateAdress(Address entity)
        {
           return _adressRepo.CreateAdress(entity.ToDal());
        }

        public Address GetAdressByCustomer(int customerId)
        {
            return _adressRepo.GetAdressByCustomer(customerId).ToBll();
        }

        public Address GetAdressById(int id)
        {
            return _adressRepo.GetAdressById(id).ToBll();
        }

        public Address GetAdressByProducer(int customerId)
        {
            return _adressRepo.GetAdressByProducer(customerId).ToBll();
        }

        public IEnumerable<Address> GetAdresses()
        {
            return _adressRepo.GetAdresses().ToBll();
        }
    }
}
