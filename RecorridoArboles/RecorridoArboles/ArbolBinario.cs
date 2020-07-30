using System;
using System.Collections.Generic;
using System.Text;

namespace RecorridoArboles
{
    public class Node
    {
        public int key;
        public Node left;
        public Node right;
        public string direction;

        public Node(int item)
        {
            key = item;
            left = null;
            right = null;
        }

    }

    public class BinaryTree
    {
        public Node root;
        public List<String> order = new List<String>();
        public int cantidad = -1;
        public StringBuilder orderValue = new StringBuilder();

        public BinaryTree()
        {
            root = null;
        }

        public Boolean contains(String value)
        {
            Boolean result = false;
            foreach (string i in order)
            {
                if (int.Parse(value) == (int.Parse(i)))
                {
                    result = true;
                    break;
                }

            }
            return result;
        }
        public void insert(int elemento)
        {
            if (root != null)
            {
                root = insert(elemento, root);
            }
            else
            {
                root = new Node(elemento);
            }

        }


        private Node insert(int elemento, Node nodo)
        {

            if (nodo == null)
            {

                return new Node(elemento);
            }
            if (elemento < nodo.key)
            {
                nodo.left = insert(elemento, nodo.left);
            }
            else if (elemento > nodo.key)
            {
                nodo.right = insert(elemento, nodo.right);
            }

            return nodo;
        }

        public void printPostorder(Node node)
        {
            if (node == null)
                return;

            printPostorder(node.left);
            printPostorder(node.right);
            orderValue.Append(node.key + " ");
        }

        public void printInorder(Node node)
        {
            if (node == null)
                return;

            printInorder(node.left);
            orderValue.Append(node.key + " ");
            printInorder(node.right);
        }

        public void printPreorder(Node node)
        {
            if (node == null)
                return;

            orderValue.Append(node.key + " ");
            printPreorder(node.left);
            printPreorder(node.right);
        }

        public void printPostorder() { printPostorder(root); }
        public void printInorder() { printInorder(root); }
        public void printPreorder() { printPreorder(root); }
    }
}
