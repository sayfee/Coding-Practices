using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace WcfREST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRestServiceImplemantation" in both code and config file together.
    [ServiceContract]
    public interface IRestServiceImplemantation
    {
        [OperationContract]    
        [WebInvoke(Method="GET", ResponseFormat=WebMessageFormat.Xml, BodyStyle=WebMessageBodyStyle.Wrapped, UriTemplate="xml/{id}")]    
        string XMLData(string id);

        [OperationContract]
        string JSONData(string id);
    }
}
