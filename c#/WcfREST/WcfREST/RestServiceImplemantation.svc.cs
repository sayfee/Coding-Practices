using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfREST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RestServiceImplemantation" in code, svc and config file together.
    public class RestServiceImplemantation : IRestServiceImplemantation
    {
        public void DoWork()
        {
        }

        public string XMLData(string id)
        {
            return "xml id";
        }

        public string JSONData(string id)
        {
            return "json";
        }
    }
}
