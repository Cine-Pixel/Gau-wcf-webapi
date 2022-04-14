using System;
using System.Collections.Generic;
using System.Linq;
using StoreService.DataContracts;
using StoreService.EF;

namespace StoreService.BL {
    public static class ProductManagement {
        public static List<ProductDTO> GetProducts() {
            using(StoreModel db = new StoreModel()) {
                return db.Products.Select(p => new ProductDTO {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    Quantity = p.Quantity,
                    Category = new CategoryDTO { CategoryName = p.Category.CategoryName, Id = p.Category.Id }
                }).ToList();
            }
        }

        public static Response CreateProduct(ProductDTO product) {
            try {
                using(StoreModel db = new StoreModel()) {
                    Product p = new Product {
                        ProductName = product.ProductName,
                        Description = product.Description,
                        Quantity = product.Quantity,
                        CategoryId = product.Category.Id
                    };

                    db.Products.Add(p);
                    db.SaveChanges();

                    return new Response { Success = true, Message = "Succesfully added product" };
                }
            } catch (Exception ex) {
                // return new Response { Success = false, Message = "Cannot add new product" };
                return new Response { Success = false, Message = ex.Message };
            }
        }

        public static Response UpdateProduct(ProductDTO product) {
            try {
                using (StoreModel db = new StoreModel()) {
                    if (!db.Products.Any(i => i.Id == product.Id))
                        throw new Exception($"No Products with Id {product.Id}!");

                    Product p = db.Products.Where(i => i.Id == product.Id).First();
                    p.ProductName = product.ProductName;
                    p.Description = product.Description;
                    p.Quantity = product.Quantity;
                    p.CategoryId = product.Category.Id;
                    db.SaveChanges();

                    return new Response { Success = true, Message = "Product updated succesfully" };
                }
            }
            catch (Exception ex) {
                return new Response { Success = false, Message = ex.Message };
            }
        }

        public static Response DeleteProduct(string id) {
            try {
                using (StoreModel db = new StoreModel()) {
                    if (!int.TryParse(id, out int code))
                        throw new Exception("Id was not found!");

                    if (!db.Products.Any(i => i.Id == code))
                        throw new Exception($"Cannot find student with Id {id}!");

                    Product st = db.Products.Where(i => i.Id == code).First();
                    db.Products.Remove(st);
                    db.SaveChanges();

                    return new Response { Success = true, Message = "Succesfully deleted product" };
                }
            }
            catch (Exception ex) {
                //return new Response { Success = false, Message = "Cannot delete product" };
                return new Response { Success = false, Message = ex.Message };
            }
        }
    }
}