using Microsoft.AspNetCore.Mvc;
using BLL_Producteur.Entities;
using Common.Repositories;
using ProducteurPlateformeAPI.Models;
using static ProducteurPlateformeAPI.Mappers.Mapper;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using QuickType;
using ProducteurPlateformeAPI.Mappers;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProducteurPlateformeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IAdressRepository<Address> _adressRepo;
        private readonly IProducerRepository<Producer> _producerRepository;
        public ProducerController(IProducerRepository<Producer> producerRepository, IAdressRepository<Address> adressRepo)
        {
            _producerRepository = producerRepository;
            _adressRepo = adressRepo;   
        }

        [HttpPost("{id:int}")]
        public ActionResult Login(string email, string password)
        {
            try
            {
                Producer currentProducer = _producerRepository.CheckProducer(email, password);
                if (currentProducer is null) throw new NullReferenceException();
                return Ok(currentProducer);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // GET api/<ProducerController>/5
        [HttpGet("{id}")]
        public ActionResult<Producer> Get(int id)
        {
            return _producerRepository.GetProducerById(id);
        }

        // POST api/<ProducerController>
        [HttpPost]
        public ActionResult<int> Post(ProducerCreate value)
        {
            
            Producer producer = value.ToProducer();
            AddressForm addressform = new AddressForm
            {
                Rue = value.Rue,
                CodePostal = value.CodePostal,
                Numero = value.Numero,
                Pays = value.Pays,
                Ville=value.Ville
            };
            producer.Address =addressform.GetCoordGpsAsync().Result;
            int newAddressId = _adressRepo.CreateAdress(producer.Address);
            producer.Address.Id=newAddressId;
            int newId=_producerRepository.CreateProducer(producer);
            return CreatedAtAction(nameof(Get), new { id = newId }, newId);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Producer>> GetProducers()
        {
            try
            {
                IEnumerable<Producer> producers= _producerRepository.GetProducers();
                if (producers is null) throw new Exception("La liste de producteurs est nulle");
                return Ok(producers);
            }catch(Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("producer/Adresses")]
        [HttpGet]
        public ActionResult<IEnumerable<Address>> GetAdresses()
        {
            try
            {
                IEnumerable<Address> adresses = _adressRepo.GetAdresses();
                if (adresses is null) throw new Exception("La liste de producteurs est nulle");
                return Ok(adresses);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
       
    }
}
