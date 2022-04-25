using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIRoutingPresentation.Models {
    public class ProductDTO {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public CategoryDTO Category { get; set; }
    }
}