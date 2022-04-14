using System.Collections.Generic;
using StoreService.BL;
using StoreService.DataContracts;

namespace StoreService {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class StoreService : IStoreService {
        public List<ProductDTO> GetProducts() => ProductManagement.GetProducts();

        public Response CreateProduct(ProductDTO product) => ProductManagement.CreateProduct(product);

        public Response UpdateProduct(ProductDTO product) => ProductManagement.UpdateProduct(product);

        public Response DeleteProduct(string id) => ProductManagement.DeleteProduct(id);

        public List<CategoryDTO> GetCategories() => CategoryManagement.GetCategories();
    }
}
