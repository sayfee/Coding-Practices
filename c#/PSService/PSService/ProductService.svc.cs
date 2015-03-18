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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class ProductService : IProductService
    {
        public CompositeType GetData(string value)
        {
            CompositeType c = new CompositeType();
            c.StringValue = value;
            c.BoolValue = false;

            return c;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        public Database.Product GetProduct(string id)
        {
            try
            {
                int productId = Convert.ToInt32(id);
                using (AdventureWorks2012Entities database = new AdventureWorks2012Entities())
                {
                    return database.Products.SingleOrDefault(p => p.ProductID == productId);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);

            }
        }

        public List<Database.Product> GetAllProducts()
        {
            try
            {
                using (AdventureWorks2012Entities database = new AdventureWorks2012Entities())
                {
                    return database.Products.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);

            }
        }

        public List<Database.Product> GetProductByColor(string value)
        {
            try
            {
                using (AdventureWorks2012Entities database = new AdventureWorks2012Entities())
                {
                    return database.Products.Where(p => p.Color == value).ToList();
                     
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);

            }
        }

        public int AddProduct(Database.Product product)
        {
            try
            {
                using (AdventureWorks2012Entities database = new AdventureWorks2012Entities())
                {
                    database.Products.AddObject(product);
                    database.SaveChanges();

                    return product.ProductID;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);

            }
        }

        public bool UpdateProduct(Database.Product product)
        {
            try
            {
                using (AdventureWorks2012Entities database = new AdventureWorks2012Entities())
                {
                    Product old = database.Products.SingleOrDefault(p => p.ProductID == product.ProductID);
                    old.Name = product.Name;
                    old.Color = product.Color;
                    old.Weight = product.Weight;
                     
                    database.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);

            }
        }

        public bool DeleteProduct(string id)
        {
            try
            {
                
                int productId = Convert.ToInt32(id);

                using (AdventureWorks2012Entities database = new AdventureWorks2012Entities())
                {
                    Product old = database.Products.SingleOrDefault(p => p.ProductID == productId);
                    database.Products.DeleteObject(old);
                    

                    database.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);

            }
        }
    }
}
