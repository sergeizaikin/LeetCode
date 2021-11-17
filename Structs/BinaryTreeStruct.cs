using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Structs
{
    public enum Side
    {
        Left,
        Right
    }
    class Node
    {
        public Node RightNode { get; set; }
        public Node LeftNode { get; set; }
        public Node ParentNode { get; set; }
        public Side? NodeSide => ParentNode == null ? null : (ParentNode.LeftNode == this ? Side.Left : Side.Right);
        public int Value { get; set; }

        public Node(int value)
        {
            Value = value;
        }
    }

    class BinaryTree
    {
        public Node RootNode { get; set; }

        public Node Add(Node node, Node currentNode = null)
        {
            if(RootNode == null)
            {
                RootNode = node;
                return node;
            }

            // Se o current node estiver nulo, então a gente está na primeira posição
            currentNode = currentNode ?? RootNode;
            node.ParentNode = currentNode;

            if (node.Value == currentNode.Value)
            {
                return currentNode;
            }
            else if (node.Value < currentNode.Value)
            {
                if (currentNode.LeftNode == null)
                {
                    return Add(node, currentNode.LeftNode);
                }
            }
            else
            {
                if (currentNode.RightNode == null)
                {
                    return Add(node, currentNode.RightNode);
                }
            }

            return null;
        }

        // Este método é para simplificar a adição
        public Node Add (int value)
        {
            return Add(new Node(value));
        }
    }
}
