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

		public class ArbolBinario
		{
		public Node root;
		public StringBuilder order = new StringBuilder();		 

		public	ArbolBinario()
		{
			root = null;
		}

		public void addNode(int data, String side)
		{
			Node newNode = new Node(data);
			if (root == null)
			{
				root = newNode;
				return;
			}
			else
			{
                Node parent = new Node(data);
				Node child;
                if (side == "right")
                {
					root.direction = "right";
                    child = parent.right;
                    move(newNode, parent, child);
				}
				else if (side == "left")
                {
					root.direction = "left";
					child = parent.left;
                    move(newNode, parent, root.left);
				}
			}
		}

		public Node move(Node newNode, Node parentNode, Node childNode)
		{
			Node direction = new Node(0);
			if (childNode != null)
			{
				return direction;
			}
			else
			{
				if (parentNode.direction == "right")
                {
					parentNode.right = newNode;
                }
				else if (parentNode.direction == "left")
                {
					parentNode.left = newNode;
				}
				return null;
			}
		}

		 void printPostorder(Node node)
		{
			if (node == null)
				return;

			printPostorder(node.left);
			printPostorder(node.right);
			order.Append(node.key + " ");
		}

		public void printInorder(Node node)
		{
			if (node == null)
				return;

			printInorder(node.left);
			order.Append(node.key + " ");
			printInorder(node.right);
		}

		public void printPreorder(Node node)
		{
			if (node == null)
				return;

			order.Append(node.key + " ");
			printPreorder(node.left);
			printPreorder(node.right);
		}

		public void printPostorder() { printPostorder(root); }
		public void printInorder() { printInorder(root); }
		public void printPreorder() { printPreorder(root); }

		static public void Main(String[] args)
		{
			ArbolBinario tree = new ArbolBinario();
			tree.root = new Node(1);
			tree.root.left = new Node(2);
			tree.root.right = new Node(3);
			tree.root.left.left = new Node(4);
			tree.root.left.right = new Node(5);

			Console.WriteLine("Preorder traversal " +
							"of binary tree is ");
			tree.printPreorder();
			Console.WriteLine(tree.order);
			tree.order = new StringBuilder();

			Console.WriteLine("\nInorder traversal " +
								"of binary tree is ");
			tree.printInorder();
			Console.WriteLine(tree.order);
			tree.order = new StringBuilder();

			Console.WriteLine("\nPostorder traversal " +
								"of binary tree is ");
			tree.printPostorder();
			Console.WriteLine(tree.order);
			tree.order = new StringBuilder();
		}
	}
}
