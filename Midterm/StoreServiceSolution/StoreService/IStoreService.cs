using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using StoreService.DataContracts;

namespace StoreService {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IStoreService {
        [OperationContract]
        [WebGet(UriTemplate = "/GetProducts", ResponseFormat = WebMessageFormat.Json)]
        List<ProductDTO> GetProducts();

        [OperationContract]
        [WebInvoke(UriTemplate = "/CreateProduct", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Response CreateProduct(ProductDTO product);

        [OperationContract]
        [WebInvoke(UriTemplate = "/UpdateProduct", Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Response UpdateProduct(ProductDTO product);

        [OperationContract]
        [WebInvoke(UriTemplate = "/DeleteProduct", Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Response DeleteProduct(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/GetCategories", ResponseFormat = WebMessageFormat.Json)]
        List<CategoryDTO> GetCategories();
    }
}
