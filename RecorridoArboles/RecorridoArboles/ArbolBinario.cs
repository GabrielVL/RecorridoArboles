using System;
using System.Collections.Generic;
using System.Text;

namespace RecorridoArboles
{
	class Node
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

	class ArbolBinario
	{
		Node root;
		StringBuilder order = new StringBuilder();
		int profundidad;

		ArbolBinario()
		{
			root = null;
		}

		void addNode(int data, String side)
		{
			Node newNode = new Node(data);
			if (root != null)
			{
				root = newNode;
			}
			else
			{
				if (side == "right")
                {
					root.direction = "right";
					move(newNode, root, root.right);
				}
				else if (side == "left")
                {
					root.direction = "left";
					move(newNode, root, root.left);
				}
			}
		}

		Node move(Node newNode, Node parentNode, Node childNode)
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

		void printInorder(Node node)
		{
			if (node == null)
				return;

			printInorder(node.left);
			order.Append(node.key + " ");
			printInorder(node.right);
		}

		void printPreorder(Node node)
		{
			if (node == null)
				return;

			order.Append(node.key + " ");
			printPreorder(node.left);
			printPreorder(node.right);
		}

		void printPostorder() { printPostorder(root); }
		void printInorder() { printInorder(root); }
		void printPreorder() { printPreorder(root); }

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
