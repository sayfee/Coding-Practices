using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreesWithCompositePattern
{
    public abstract class ProductComponent
    {
        public virtual void add(ProductComponent newProductComponent) { }

        public virtual void remove(ProductComponent newProductComponent) { }

        ProductComponent getProductComponent(int componentIndex)
        {
            return null;
        }

        public abstract void displayProductInfo();
    }

    public class ProductGroup : ProductComponent {

        List<ProductComponent> productComponents = new List<ProductComponent>();
        private string productGroupName;

        public ProductGroup(string productGroupName)
        {
            this.productGroupName = productGroupName;
        }

        public override void add(ProductComponent newProductComponent)
        {
            productComponents.Add(newProductComponent);
        }


        public void remove(ProductComponent newProductComponent)
        {
            productComponents.Remove(newProductComponent);
        }

        public ProductComponent getProductComponent(int componentIndex)
        {
            return productComponents[componentIndex];
        }


        public string getProductGroupName()
        {
            return productGroupName;
        }

        public override void displayProductInfo()
        {
            Console.WriteLine(getProductGroupName());

            foreach (ProductComponent pc in productComponents)
            {
                pc.displayProductInfo();
            }

            Console.WriteLine();
        }
    }

    public class Product : ProductComponent
    {
        private string productName;
        private double productPrice;

        public Product(string productName, double productPrice)
        {
            this.productName = productName;
            this.productPrice = productPrice;
        }

        public string getProductName()
        {
            return productName;
        }

        public void setProductName(string productName) {
            this.productName = productName;
        }

        public double getproductPrice()
        {
            return productPrice;
        }

        public void setProductName(double productPrice)
        {
            this.productPrice = productPrice;
        }

        public override void displayProductInfo()
        {
            Console.WriteLine(getProductName() + " $"
                + getproductPrice());
        }
    }
     
}
