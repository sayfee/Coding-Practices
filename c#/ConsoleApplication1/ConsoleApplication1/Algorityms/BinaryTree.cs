using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.Algorityms
{
    class BinaryTree
    {
        Node root;

        public void add(int key, string name)
        {
            Node newNode = new Node(key, name);
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                Node focusedNode = root;

                Node parent;

                while (true)
                {
                    parent = focusedNode;

                    if (key < parent.key)
                    {
                        focusedNode = focusedNode.left;
                        if (focusedNode == null)
                        {
                            parent.left = newNode;
                            return;
                        }
                    }
                    else
                    {
                        focusedNode = focusedNode.right;
                        if (focusedNode == null)
                        {
                            parent.right = newNode;
                            return;
                        }
                    }
                }
               
            }

        }

        public Node find(int key)
        {
            Node focusedNode = root;
            if (focusedNode.key != key)
            {
                
                while (true)
                {
                    if (focusedNode.key > key)
                    {
                        if (focusedNode.left != null)
                            focusedNode = focusedNode.left;
                        else
                            return null;
                    }
                    else if (focusedNode.key < key)
                    {
                        if (focusedNode.right != null)
                            focusedNode = focusedNode.right;
                        else
                            return null;
                    }
                    else
                        return focusedNode;
                }
            }
            else
                return focusedNode;
        }

        public void inOrderTraverseTree(Node focusNode)
        {
            if (focusNode == null)
            {
                inOrderTraverseTree(focusNode.left);
                Console.WriteLine(focusNode);
                inOrderTraverseTree(focusNode.right);
            }

        }

        public static void Main1()
        {
            BinaryTree bin = new BinaryTree();

            bin.add(10000, "Albay");
            bin.add(50, "Ust Tegmen");
            bin.add(1000, "Binbasi");
            bin.add(20, "Tegmen");
            bin.add(100, "Yuzbasi");

            Console.WriteLine(bin.find(20));
            Console.ReadKey();
        }
    }

    public class Node
    {
        public int key;
        public string name;

        public Node left;
        public Node right;

        public Node(int key, string name)
        {
            this.key = key; this.name = name;
        }

        public override string ToString()
        {
            return name + " has the key " + key;

        }
    }
}
