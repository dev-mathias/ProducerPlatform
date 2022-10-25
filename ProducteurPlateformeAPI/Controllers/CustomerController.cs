using Microsoft.AspNetCore.Mvc;
using BLL_Producteur.Entities;
using Common.Repositories;
using ProducteurPlateformeAPI.Models;
using static ProducteurPlateformeAPI.Mappers.Mapper;
using System.Net.Http.Headers;
using QuickType;
using Newtonsoft.Json;
using ProducteurPlateformeAPI.Mappers;

namespace ProducteurPlateformeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository<Customer> _customerRepo;
        private readonly IAdressRepository<Address> _adressRepo;
        public CustomerController(ICustomerRepository<Customer> customerRepo, IAdressRepository<Address> adressRepo)
        {
            _customerRepo = customerRepo;
            _adressRepo = adressRepo;   
        }


        [HttpPost("{id:int}")]
        public ActionResult<Customer> Login(string email, string password)
        {
            try
            {
                Customer currentCustomer = _customerRepo.CheckCustomer(email, password);
                if (currentCustomer is null) throw new NullReferenceException();
                return Ok(currentCustomer);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<Customer> Get(int id)
        {
            try
            {
                Customer customer = _customerRepo.GetCustomerById(id);
                if (customer is null) throw new NullReferenceException();
                return Ok(customer);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult<int> Post(CustomerCreate newCustomer)
        {
            Customer customer = newCustomer.ToCustom();
            AddressForm addressform = new AddressForm
            {
                Rue = newCustomer.Rue,
                CodePostal = newCustomer.CodePostal,
                Numero = newCustomer.Numero,
                Pays = newCustomer.Pays,
                Ville = newCustomer.Ville
            };
            customer.Address = addressform.GetCoordGpsAsync().Result;
            int newAdressId=_adressRepo.CreateAdress(customer.Address);
            customer.Address.Id=newAdressId;
            int newId=_customerRepo.CreateCustomer(customer);
            return CreatedAtAction(nameof(Get), new { id = newId }, newId);
        }
        
      
    }
}
