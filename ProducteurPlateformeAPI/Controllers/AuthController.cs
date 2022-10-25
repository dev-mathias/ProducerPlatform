using BLL_Producteur.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using ProducteurPlateformeAPI.Models;


namespace ProducteurPlateformeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICustomerRepository<Customer> _customerRepo;
        private readonly IProducerRepository<Producer> _producerRepo;
        public AuthController(ICustomerRepository<Customer> customerRepo, IProducerRepository<Producer> producerRepo)
        {
            _customerRepo = customerRepo;
            _producerRepo = producerRepo;
        }
        [HttpPost]
        public ActionResult Login(LoginForm form)
        {
            try
            {
                Customer? customer = _customerRepo.CheckCustomer(form.Email, form.Password);
                if (customer is null)
                {
                    Producer? producer = _producerRepo.CheckProducer(form.Email, form.Password);
                    if (producer is null) throw new Exception();
                    else return Ok(producer);
                }
                else return Ok(customer);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }



    }
}
