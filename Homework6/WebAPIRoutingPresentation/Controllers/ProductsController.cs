using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPIStore.EF;
using WebAPIStore.Models;

namespace WebAPIStore.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly StoreModel db = new StoreModel();

        [Route("")]
        public IHttpActionResult GetAllProducts()
        {
            List<ProductDTO> products = db.Products.Select(p => new ProductDTO {
                Id=p.Id, 
                ProductName=p.ProductName, 
                Description=p.Description,
                Quantity = p.Quantity,
                Category = new CategoryDTO { Id = p.Category.Id, CategoryName = p.Category.CategoryName }
            }).ToList();
            return Json(products);
        }

        [Route("{id}", Name = "ProductDetail")]
        public IHttpActionResult GetProductById(int id) {
            Product product = db.Products.FirstOrDefault(p => p.Id == id);
            ProductDTO productDTO = new ProductDTO {
                Id = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Quantity = product.Quantity,
                Category = new CategoryDTO { Id = product.Category.Id, CategoryName=product.Category.CategoryName}
            };
            if (product == null) {
                return NotFound();
            }

            return Ok(productDTO);
        }

        [HttpPost, Route("", Name = "CreateProduct")]
        public IHttpActionResult CreateProduct(ProductDTO productDTO) {
            try {
                Product product = new Product {
                    ProductName = productDTO.ProductName,
                    Description = productDTO.Description,
                    Quantity = productDTO.Quantity,
                    CategoryId = productDTO.Category.Id
                };
                db.Products.Add(product);
                db.SaveChanges();

                productDTO.Id = product.Id;

                //return CreatedAtRoute("CreateProduct", new { product.Id }, productDTO);
                return CreatedAtRoute(
                    "CreateProduct", 
                    new { product.Id }, 
                    new { url = new Uri(Url.Link("ProductDetail", new { id = product.Id})) }
                );
            } catch(Exception ex) {
                return InternalServerError();
            }
        }
        
        [HttpPut, Route("{id}", Name = "UpdateProduct")]
        public IHttpActionResult UpdateProduct(int id, ProductDTO productDTO) {
            try {
                Product product = db.Products.FirstOrDefault(p => p.Id == id); 
                if (product == null) {
                    return NotFound();
                }
                product.ProductName = productDTO.ProductName;
                product.Description = productDTO.Description;
                product.Quantity = productDTO.Quantity;
                product.CategoryId = productDTO.Category.Id;
                db.SaveChanges();

                productDTO.Id = product.Id;
                productDTO.Category.CategoryName = product.Category.CategoryName;
                return Ok(productDTO);
            } catch(Exception ex) {
                return InternalServerError();
            }
        }

        [HttpDelete, Route("{id}", Name = "DeleteProduct")]
        public IHttpActionResult DeleteProduct(int id) {
            try {
                Product product = db.Products.FirstOrDefault(i => i.Id == id);
                if (product == null)
                    return NotFound();

                db.Products.Remove(product);
                db.SaveChanges();

                return Ok(id);
            } catch (Exception ex) {
                return InternalServerError();
            }
        }
    }
}