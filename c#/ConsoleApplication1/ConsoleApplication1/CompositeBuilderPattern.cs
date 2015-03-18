using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositeBuilderPattern
{
    public class Item
    {
        private Dictionary<string, string> itemInfoDict;
        private string itemName = "";

        private List<Item> children = new List<Item>();
        public string getItemName()
        {
            return itemName;
        }

        public void setItemName(string item)
        {
            this.itemName = item;
        }

        public Item(string itemName)
        {
            this.itemName = itemName;
            itemInfoDict = new Dictionary<string, string>();
        }

        public void add(Item childNode)
        {
            children.Add(childNode);
        }

        public void addItemInformation(string infoName, string info)
        {
            itemInfoDict.Add(infoName, info);
        }

        public string getItemInformation(string infoName)
        {
            return itemInfoDict[infoName];
        }

        public string toString()
        {
            string itemInformation = itemName + "\n";

            if (itemInfoDict.Count > 0)
            {
            }

            return itemInformation;
                
        }

        public string displayProductInfo()
        {
            string productInfo = "";
            foreach(var entry in itemInfoDict)
            {
                productInfo = " Key : " + entry.Key + " Value : " + entry.Value;

            }

            return productInfo;
        }



        //static void Main()
        //{
        //    ItemBuilder products = new ItemBuilder("Products");
        //    products.addChild("Produce");
        //    products.addChild("Orange");
        //    products.addItemInformation("Price", "$1.00");
        //    products.addItemInformation("Stock", "100");

        //    products.addSibling("Apple");
        //    products.addSibling("Grape");

        //    products.editThisItem("Products");
        //    products.addChild("Cereal");

        //    products.displayAllItems();

        //    Console.ReadKey();
        //}
    }

    public class ItemBuilder {
        List<Item> items = new List<Item>();

        private Item root;
        private Item current;
        private Item parent;

        public ItemBuilder(string rootName)
        {
            root = new Item(rootName);
            addItemToArrayList(root);

            current = root;
            parent = root;

            root.addItemInformation("Parent", parent.getItemName());
        }

        public void addItemInformation(string name, string value)
        {
            current.addItemInformation(name, value);
        }

        public void addChild(string child)
        {
            Item childNode = new Item(child);
            addItemToArrayList(childNode);

            current.add(childNode);
            parent = current;
            current = childNode;

            childNode.addItemInformation("Parent", parent.getItemName());

        }

        public void addSibling(string sibling)
        {
            Item siblingNode = new Item(sibling);

            addItemToArrayList(siblingNode);

            parent.add(siblingNode);

            current = siblingNode;

            siblingNode.addItemInformation("Parent", parent.getItemName());

        }

        public void addItemToArrayList(Item newItem)
        {
            items.Add(newItem);
        }

        public string toString()
        {
            return root.toString();
        }

        public void displayAllItems()
        {
            foreach (Item item in items)
            {
                Console.WriteLine(item.getItemName() + " : " + item.displayProductInfo());

            }
        }

        public void editThisItem(string itemName)
        {
            foreach (Item item in items)
            {
                if(item.getItemName().Equals(itemName))
                {
                    current = item;
                    
                   setItemsParent(current.getItemInformation("Parent"));
                }

            }
        }

         public void setItemsParent(string parentItem)
        {
            foreach (Item item in items)
            {
                if(item.getItemName().Equals(parentItem))
                {
                    parent = item;
                     
                }

            }
        }
    }
}
