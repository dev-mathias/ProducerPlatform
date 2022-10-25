using B=BLL_Producteur.Entities;
using D = DAL_Producteur.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repositories;
using BLL_Producteur.Entities;
using BLL_Producteur.Mapper;

namespace BLL_Producteur.Service
{
    public class ProducerService : IProducerRepository<B.Producer>
    {
        private readonly IProducerRepository<D.Producer> _producerRepo;
        private readonly IAdressRepository<B.Address> _adressRepo;
        public ProducerService(IProducerRepository<D.Producer> producerRepo, IAdressRepository<Address> adressRepo)
        {
            _producerRepo = producerRepo;
            _adressRepo = adressRepo;
        }

        public Producer CheckProducer(string email, string password)
        {
            Producer producer= _producerRepo.CheckProducer(email, password).ToBll();
            producer.Address = _adressRepo.GetAdressByProducer(producer.Id);
            return producer;
        }

        public int CreateProducer(Producer entity)
        {
            return _producerRepo.CreateProducer(entity.ToDal());
        }

        public Producer GetProducerById(int id)
        {
            Producer? producer = _producerRepo.GetProducerById(id).ToBll();
            if (producer is null) throw new ArgumentNullException();
            producer.Address=_adressRepo.GetAdressByProducer(producer.Id);
            return producer;
        }

        public Producer GetProducerByProduct(int productId)
        {
            Producer producer= _producerRepo.GetProducerByProduct(productId).ToBll();
            producer.Address=_adressRepo.GetAdressByProducer(producer.Id);
            return producer;
        }

        public IEnumerable<Producer> GetProducers()
        {
            IEnumerable<Producer> producers= _producerRepo.GetProducers().ToBll();
            producers = producers.Select(p =>
            {
                p.Address = _adressRepo.GetAdressByProducer(p.Id);
                return p;
            });
            return producers; 
        }
    }
}
