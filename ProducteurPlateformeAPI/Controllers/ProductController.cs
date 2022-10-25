using BLL_Producteur.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using ProducteurPlateformeAPI.Mappers;
using ProducteurPlateformeAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProducteurPlateformeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository<Product> _productRepo;
        private readonly IProducerRepository<Producer> _producerRepo;
        public ProductController(IProductRepository<Product> productRepo, IProducerRepository<Producer> producerRepo)
        {
            _productRepo = productRepo;
            _producerRepo = producerRepo;
        }
        


        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            Product product= _productRepo.GetProductById(id);
            //   product.Producer=_productRepo.
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult<int> Post(ProductCreate entity)
        {
            Product product = entity.ToProduct();
            product.Producer = _producerRepo.GetProducerById(entity.ProducerId);
            int newId=_productRepo.CreateProduct(product);
            return CreatedAtAction(nameof(Get), new { id = newId }, newId);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, ProductUpdate value)
        {
            try
            {
                if (_productRepo.GetProductById(id) is null) throw new NullReferenceException();
                Product product = value.ToProduct();
                product.Producer= _producerRepo.GetProducerByProduct(id);
                _productRepo.UpdateProduct(id, product);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(new { id = id });
            }



        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if(_productRepo.GetProductById(id) is null) throw new NullReferenceException();
                _productRepo.DeleteProduct(id);
                return NoContent();
            }catch(Exception e)
            {
                return NotFound();
            }
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                IEnumerable<Product> products = _productRepo.GetProducts();
                if (products is null) throw new Exception("La liste de produits est nulle");
                return Ok(products);
            }catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("producer/{producerId}")]
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProductByProducer(int producerId)
        {
            try
            {
                IEnumerable<Product> products = _productRepo.GetProductsByProducerId(producerId);
                if (products is null) throw new Exception("Vous n'avez pas encore posté de produits");
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
