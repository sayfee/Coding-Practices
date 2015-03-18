using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Database;

namespace PSService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {

        [OperationContract]
        [WebGet(UriTemplate="GetData/{value}", ResponseFormat=WebMessageFormat.Json)]
        CompositeType GetData(string value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here

        [OperationContract]
        [WebGet(UriTemplate="Product/{id}")]
        Product GetProduct(string id);

        [OperationContract]
        [WebGet]
        List<Product> GetAllProducts();

        [OperationContract]
        [WebGet(UriTemplate="Product?Color={value}", ResponseFormat=WebMessageFormat.Json)]
        List<Product> GetProductByColor(string value);

        [OperationContract]
        [WebInvoke(UriTemplate="Product/Add", Method="POST")]
        int AddProduct(Product product);

        [OperationContract]
        [WebInvoke(UriTemplate="Product/Update", Method="PUT")]
        bool UpdateProduct(Product product);

        [OperationContract]
        [WebInvoke(UriTemplate="Product/Delete/{id}", Method="DELETE")]
        bool DeleteProduct(string id);


    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
     
}
