using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using StoreService.AppData;

namespace StoreService {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IStoreService {
        [OperationContract]
        bool CreateProduct(Product p);

        [OperationContract]
        bool DeleteProduct(int id);

        [OperationContract]
        List<Product> GetProducts();

        [OperationContract]
        Product GetProductById(int id);

        [OperationContract]
        List<Category> GetCategories();

        [OperationContract]
        Category GetCategoryById(int id);
    }
}
