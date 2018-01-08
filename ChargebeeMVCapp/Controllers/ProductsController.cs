using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChargebeeMVCapp.Controllers
{
    public class ProductsController : ApiController
    {
        private static List<Product> _products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Honda Civic", Description = "Luxury Model 2013" },
                new Product() { Id = 2, Name = "Honda Accord", Description = "Deluxe Model 2012" },
                new Product() { Id = 3, Name = "BMW V6", Description = "V6 Engine Luxury 2013" },
                new Product() { Id = 4, Name = "Audi A8", Description = "V8 Engine 2013" },
                new Product() { Id = 5, Name = "Mercedes M3", Description = "Basic Model 2013" }
            };

        public ProductsController()
        {
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        [HttpGet]
        public Product GetProduct(int id)
        {
            Product pro = _products.Find(p => p.Id == id);

            if (pro == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            else
                return pro;
        }

        [HttpGet]
        public IEnumerable<Product> GetProductsBySearch(string search)
        {
            var products = _products.Where(p => p.Description.Contains(search));

            if (products.ToList().Count > 0)
                return products;
            else
                throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage PostProduct(Product p)
        {
            if (p == null)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            _products.Add(p);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpDelete]
        public IEnumerable<Product> DeleteProduct(int id)
        {
            Product pro = _products.Find(p => p.Id == id);
            _products.Remove(pro);

            return _products;
        }

        [HttpPut]
        public HttpResponseMessage PutProduct(Product p)
        {
            Product pro = _products.Find(pr => pr.Id == p.Id);

            if (pro == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            pro.Id = p.Id;
            pro.Name = p.Name;
            pro.Description = p.Description;

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}