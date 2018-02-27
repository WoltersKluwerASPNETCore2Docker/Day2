using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComm.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComm.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private DataContext ECommDataContext { get; }
        public ProductController(DataContext dataContext)
        {
            ECommDataContext = dataContext;
        }

        // GET: api/Product
        //[HttpGet]
        //public IEnumerable<Product> Get()
        //{
        //    return ECommDataContext.Products.ToList();
        //}
        // Lambda Style
        [HttpGet]
        public IEnumerable<Product> Get() => ECommDataContext.Products.ToList();

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public Product Get(int id)
        {
            return ECommDataContext.Products.SingleOrDefault(p => p.Id == id);
        }
        
        // POST: api/Product
        [HttpPost]
        public void Post([FromBody]Product product)
        {
            ECommDataContext.Products.Add(product);
            ECommDataContext.SaveChanges();
        }
        
        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product product)
        {
            if (product == null || product.Id != id) return;

            var existing = ECommDataContext.Products.SingleOrDefault(p => p.Id == id);
            if (existing == null) return;

            existing.ProductName = product.ProductName;
            existing.UnitPrice = product.UnitPrice;
            existing.Package = product.Package;
            existing.IsDiscontinued = product.IsDiscontinued;
            existing.SupplierId = product.SupplierId;
            ECommDataContext.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var existing = ECommDataContext.Products.SingleOrDefault(p => p.Id == id);
            ECommDataContext.Remove(existing);
            ECommDataContext.SaveChanges();
        }
    }
}
