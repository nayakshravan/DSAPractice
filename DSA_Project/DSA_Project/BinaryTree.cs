using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public class Node
    {
        public int Data;
        public Node Left;
        public Node Right;

        public Node(int data)
        {
            Data = data;
            Left = Right = null;
        }
    }

    public class BinaryTree
    {
        public Node Root;

        public void Insert(int data)
        {
            Root = InsertRecursive(Root, data);
        }

        private Node InsertRecursive(Node root, int data)
        {
            if (root == null)
            {
                return new Node(data);
            }

            if (data < root.Data)
            {
                root.Left = InsertRecursive(root.Left, data);
            }
            else
            {
                root.Right = InsertRecursive(root.Right, data);
            }

            return root;
        }

        // Left, Root, Right
        public void InOrderTraversal(Node node)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left);
                Console.Write(node.Data + " ");
                InOrderTraversal(node.Right);
            }
        }
    }
}
