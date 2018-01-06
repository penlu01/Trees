﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class AVLSearchTree : BinarySearchTree
    {
        public AVLSearchTree()
            :base()
        {
        }
        public override void Insert(Node newNode, Node start, Node parent)
        {
            base.Insert(newNode, start, parent);
            Rotations(newNode);
        }
        public override Node Search(int find, Node start)
        {
            return base.Search(find, start);
        }
        public override void Delete(Node delNode)
        {
            var temp = delNode;
            if (delNode == head)
            {
                temp = head;
            }
            base.Delete(delNode);
            Rotations(temp);
        }
        public void RightRotation(Node root)
        {
            var temp = root.left;
            if (root.left.right != null)
            {
                root.left = root.left.right;
            }
            root.parent = temp;
            temp.right = root;
        }
        public void LeftRotation (Node root)
        {
            var temp = root.right;
            if (root.right.left != null)
            {
                root.right = root.right.left;
            }
            root.parent = temp;
            temp.left = root;
        }
        public void Rotations(Node child)
        {
            var root = child;
            while (!(root.findBalance() > 1 || root.findBalance() < 1))
            {
                root = child.parent;
            }
            if (root.left != null && root.left.left != null)
            {
                RightRotation(root);
            }
            if (root.left != null && root.left.right != null)
            {
                LeftRotation(root.left);
                RightRotation(root);
            }
            if (root.right != null && root.right.right != null)
            {
                LeftRotation(root);
            }
            if (root.right != null && root.right.left != null)
            {
                RightRotation(root.right);
                LeftRotation(root);
            }
        }
    }
}