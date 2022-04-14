using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreService.DataContracts;
using StoreService.EF;

namespace StoreService.BL {
    public static class CategoryManagement {
        public static List<CategoryDTO> GetCategories() {
            using(StoreModel db = new StoreModel()) {
                return db.Categories.Select(c => new CategoryDTO {
                    Id = c.Id,
                    CategoryName = c.CategoryName
                }).ToList();
            }
        }
    }
}