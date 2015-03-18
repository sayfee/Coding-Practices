using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ProductInterfaces;

namespace ProductServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IWCFProductService" in both code and config file together.
    public class WCFProductService : IWCFProductService
    {
        public void DoWork()
        {
        }

        public List<string> ListProducts()
        {
            List<string> productList = new List<string>();
            try
            {
                using (AdventureWorks2012Entities database = new AdventureWorks2012Entities())
                {
                    var products = from p in database.Products
                                   select p.ProductNumber;

                     
                    productList = products.ToList();
                }
            }
            catch
            { 
                
            }

            return productList;
        }
    }
}
