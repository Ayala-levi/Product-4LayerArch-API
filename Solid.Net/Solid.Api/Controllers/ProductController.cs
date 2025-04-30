using Microsoft.AspNetCore.Mvc;
using Solid.Core.Services;
using Solid.Data.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //ShopDBContext יצרנו משתנה מסוג  
        //כי הוא מחובר ישירות לדאטה בייס
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productService.GetAll());
        }


        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_productService.Get(id));
            }
            catch
            {
                return NotFound("Id is not valid");
            }

        }


        //מסמך של כל המוצרים
        // POST api/<ProductController>
        [HttpPost("createDataSave/{path}")]
        public IActionResult Post(string path)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (Product p in _productService.GetAll())
                    {
                        writer.WriteLine("product" + p.Id);
                        writer.WriteLine(p.Name);
                        writer.WriteLine(p.Price);
                        writer.WriteLine(p.Description);
                        writer.WriteLine(p.StockQuantity);
                    }
                    return Ok("succeed");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] Product p)
        {
            try
            {
                _productService.AddProduct(p);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product p)
        {
            Product product = _productService.UpdateProduct(id, p);
            if (product == null)
            {
                throw new Exception("Not Exist for update");
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                Product product = _productService.DeleteProduct(id);
                if (product == null)
                {
                    throw new Exception("Not Exist for delete");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}

