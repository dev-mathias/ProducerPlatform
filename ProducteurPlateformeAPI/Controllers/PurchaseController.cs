using BLL_Producteur.Entities;
using Microsoft.AspNetCore.Mvc;
using ProducteurPlateformeAPI.Models;
using Common.Repositories;
using static ProducteurPlateformeAPI.Mappers.Mapper;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProducteurPlateformeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseRepository<Purchase> _purchaseRepo;
        private readonly IProductRepository<Product> _productRepo;
        private readonly ICustomerRepository<Customer> _customerRepo;
        private readonly IProducerRepository<Producer> _producerRepo;
        public PurchaseController(IPurchaseRepository<Purchase> purchaseRepo, IProductRepository<Product> productRepo, ICustomerRepository<Customer> customerRepo, IProducerRepository<Producer> producerRepo)
        {
            _purchaseRepo = purchaseRepo;
            _productRepo = productRepo;
            _customerRepo = customerRepo;
            _producerRepo = producerRepo;
        }

        // GET api/<PurchaseController>/5
        [HttpGet("{id}")]
        public ActionResult<Purchase> Get(int id)
        {
            Purchase purchase=_purchaseRepo.GetPurchaseById(id);
            if (purchase is null) return NotFound();
            else return Ok(purchase);
        }

        // POST api/<PurchaseController>
        [HttpPost]
        public ActionResult<int> Post(PurchaseCreate value)
        {
            try
            {
                Purchase purchase = value.ToPurchase();
                purchase.Customer = _customerRepo.GetCustomerById(value.CustomerId);
                purchase.Product = _productRepo.GetProductById(value.ProductId);
                purchase.Product.Producer = _producerRepo.GetProducerByProduct(purchase.Product.Id);
                if (purchase.Quantity > purchase.Product.Quantity) throw new Exception("Pas assez de stocks");
                int newId = _purchaseRepo.CreatePurchase(purchase);
                return CreatedAtAction(nameof(Get), new { id = newId }, newId);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        
        }
        [HttpGet]
        public ActionResult<IEnumerable<Purchase>> GetPurchaseByCustomer(int customerId)
        {
            try
            {
                IEnumerable<Purchase> purchases=_purchaseRepo.GetPurchaseByCustomerId(customerId);
                if(purchases is null) throw new NullReferenceException();
                return Ok(purchases);
            }catch(Exception e)
            {
                return NotFound(e);
            }
        }
    }
}
