using System;

namespace BinaryTreeTraversal
{
    class TreeNode
    {
        public string Hijo;
        public TreeNode Left, Right;

        public TreeNode(string hijo)
        {
            Hijo = hijo;
            Left = Right = null;
        }
    }

    class BinaryTree
    {
        public TreeNode Root;

        public BinaryTree()
        {
            Root = new TreeNode("A");
            Root.Left = new TreeNode("B");
            Root.Right = new TreeNode("C");

            Root.Left.Left = new TreeNode("D");
            Root.Left.Right = new TreeNode("E");
            Root.Left.Left.Left = new TreeNode("H");
            Root.Left.Left.Right = new TreeNode("I");
            Root.Left.Right.Left = new TreeNode("J");
            Root.Left.Right.Right = new TreeNode("K");

            Root.Right.Left = new TreeNode("F");
            Root.Right.Right = new TreeNode("G");
            Root.Right.Left.Left = new TreeNode("L");
            Root.Right.Left.Right = new TreeNode("M");
            Root.Right.Right.Left = new TreeNode("N");
            Root.Right.Right.Right = new TreeNode("O");
        }

        public void PreOrder(TreeNode node)
        {
            if (node == null) return;
            Console.Write(node.Hijo + " ");
            PreOrder(node.Left);
            PreOrder(node.Right);
        }

        public void DisplayPreOrder()
        {
            Console.WriteLine("Recorrido Pre-order:");
            PreOrder(Root);
            Console.WriteLine();
        }


        public void PostOrder(TreeNode node)
        {
            if (node == null) return;
            Console.Write(node.Hijo + " ");
            PostOrder(node.Right);
            PostOrder(node.Left);
        }

        public void DisplayPostOrder()
        {
            Console.WriteLine("Recorrido Post-order:");
            PostOrder(Root);
            Console.WriteLine();
        }



        public void InOrder(TreeNode node)
        {
            if (node == null) return;
            Console.Write(node.Hijo + " ");
            InOrder(node.Right);
            InOrder(node.Right);
        }

        public void DisplayInOrder()
        {
            Console.WriteLine("Recorrido In-order:");
            InOrder(Root);
            Console.WriteLine();
        }
        
    }



    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.DisplayPreOrder();
            tree.DisplayPostOrder();
            tree.DisplayInOrder();
        }
    }
}
