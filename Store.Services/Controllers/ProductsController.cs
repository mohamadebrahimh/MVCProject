using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Store.Models.Models;
using Store.Services.DAL;
using Store.Services.Models;

namespace Store.Services.Controllers
{
    public class ProductsController : ApiController
    {
        private StoreDbContext db = new StoreDbContext();

        [HttpGet]
        public IHttpActionResult GetProducts()
        {
            var products = db.Products.ToList();

            List<ProductResponseModel> productResponses = new List<ProductResponseModel>();
            foreach (var product in products)
            {
                ProductResponseModel model = new ProductResponseModel()
                {
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category.Name,
                    CompanyId = product.CompanyId,
                    CompanyName = product.Company.PersianName,
                    Description = product.Description,
                    Id = product.Id,
                    ModelName = product.ModelName
                };
                productResponses.Add(model);
            }
            return Ok(productResponses);
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        [HttpGet]
        public IHttpActionResult GetProduct([FromUri]int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            ProductResponseModel productResponse = new ProductResponseModel()
            {
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
                CompanyId = product.CompanyId,
                CompanyName = product.Company.PersianName,
                Description = product.Description,
                Id = product.Id,
                ModelName = product.ModelName
            };

            return Ok(productResponse);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult EditProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        [HttpPost]
        public IHttpActionResult AddProduct([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            db.SaveChanges();

            return Ok("محصول جدید با موفقت ثبت شد");
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        [HttpDelete]
        public IHttpActionResult DeleteProduct([FromUri]int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok("محصول با موفقت حذف شد");
        }



        [HttpGet]
        public IHttpActionResult GetCountries()
        {
            var countries = db.Countries;

            List<CountryResponseModel> countryResponses = new List<CountryResponseModel>();
            foreach (var country in countries)
            {
                CountryResponseModel model = new CountryResponseModel()
                {

                    Id = country.Id,
                    Name = country.Name

                };
                countryResponses.Add(model);
            }
            return Ok(countryResponses);
        }

        [HttpGet]
        public IHttpActionResult GetCategories()
        {
            var categories = db.Categories.ToList();

            List<CategoryResponseModel> categoryResponses = new List<CategoryResponseModel>();
            foreach (var category in categories)
            {
                CategoryResponseModel model = new CategoryResponseModel()
                {

                    Id = category.Id,
                    Name = category.Name,

                };
                categoryResponses.Add(model);
            }

            return Ok(categoryResponses);
        }

        [HttpGet]
        public IHttpActionResult GetComponies()
        {
            var companies = db.Companies.ToList();

            List<CompanyResponseModel> companyResponses = new List<CompanyResponseModel>();
            foreach (var company in companies)
            {
                CompanyResponseModel model = new CompanyResponseModel()
                {

                    Id = company.Id,
                    EnglishName = company.EnglishName,
                    PersianName = company.PersianName,
                    CountryId = company.CountryId,
                    CountryName = company.Country.Name

                };
                companyResponses.Add(model);
            }

            return Ok(companyResponses);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }
    }
}