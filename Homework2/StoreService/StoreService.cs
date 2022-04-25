using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using StoreService.AppData;
using StoreService.EF;

namespace StoreService {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class StoreService : IStoreService {
        public AppData.Product GetProductById(int id) {
            using(StoreModel db = new StoreModel()) {
                return db.Products.Where(p => p.Id == id)
                    .Select(p => new AppData.Product { 
                        Id = p.Id,
                        ProductName = p.ProductName,
                        Description = p.Description,
                        Quantity = (int)p.Quantity,
                        Category = new AppData.Category {
                            Id = p.Category.Id,
                            CategoryName = p.Category.CategoryName
                        }
                    }).FirstOrDefault();
            }
        }

        public List<AppData.Product> GetProducts() {
            using(StoreModel db = new StoreModel()) {
                return db.Products.Select(p => new AppData.Product {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    Quantity = (int)p.Quantity,
                    Category = new AppData.Category {
                        Id = p.Category.Id,
                        CategoryName = p.Category.CategoryName
                    }
                }).ToList();
            }
        }

        public bool CreateProduct(AppData.Product p) {
            try {
                using (StoreModel db = new StoreModel()) {
                    db.Products.Add(new EF.Product() {
                        ProductName = p.ProductName,
                        Description = p.Description,
                        Quantity = p.Quantity,
                        CategoryId = p.Category.Id
                    });
                    db.SaveChanges();
                    return true;
                }
            } catch {
                return false;
            }
        }

        public bool DeleteProduct(int id) {
            try {
                using(StoreModel db = new StoreModel()) {
                    EF.Product product = db.Products.Where(p => p.Id == id).First();
                    db.Products.Remove(product);
                    db.SaveChanges();
                    return true; 
                }
            } catch {
                return false;
            }
        }
        
        public List<AppData.Category> GetCategories() {
            using (StoreModel db = new StoreModel()) {
                return db.Categories.Select(c => new AppData.Category {
                    Id = c.Id,
                    CategoryName = c.CategoryName
                }).ToList();
            }
        }

        public AppData.Category GetCategoryById(int id) {
            throw new NotImplementedException();
        }
    }
}
