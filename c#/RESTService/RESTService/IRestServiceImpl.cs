using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace RESTService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRestServiceImpl" in both code and config file together.
    [ServiceContract]
    public interface IRestServiceImpl
    {
        [OperationContract]
        [WebInvoke(Method="GET", ResponseFormat=WebMessageFormat.Xml, BodyStyle= WebMessageBodyStyle.Wrapped, UriTemplate="xml/{id}")]
        string XmlData(string id);

        string JSONData(string id)
    }
}
