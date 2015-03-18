using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPairArithmeticService" in both code and config file together.
    [ServiceContract]
    public interface IPairArithmeticService
    {
        [OperationContract] // Can be used by the client
        Pair Add(Pair p1, Pair p2);

        [OperationContract]
        Pair Substract(Pair p1, Pair p2);
    }
}
