// <copyright file="BinarySearchTree.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>
namespace BinarySearchTree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Binary Search Tree.
    /// </summary>
    /// <typeparam name="T">Universal type.</typeparam>
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        private Node<T> root;
        private readonly IComparer<T> comparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        public BinarySearchTree()
        {
            this.root = null;
            this.Count = 0;
            this.comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        public BinarySearchTree(IComparer<T> comparer) : this()
        {
            this.comparer = comparer;
        }

        /// <summary>
        /// Gets the number of elements.
        /// </summary>
        /// <value>
        /// The number of elements.
        /// </value>
        public int Count { get; private set; }

        /// <summary>
        /// Check if element exist.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>True if element exist else false.</returns>
        public bool Contains(T element)
        {
            return this.Find(element, this.root) != null;
        }

        /// <summary>
        /// Inserts the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        public void Insert(T element)
        {
            if (this.root == null)
            {
                this.root = new Node<T>(element);
                this.Count++;
                return;
            }

            this.Insert(element, this.root);
        }

        /// <summary>
        /// Removes the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        public void Remove(T element)
        {
            if (this.root is null)
            {
                return;
            }

            this.Remove(element, this.root);
        }

        /// <summary>
        /// Tree traversal by preorder.
        /// </summary>
        /// <returns>Node value</returns>
        public IEnumerable<T> PreOrder()
        {
            if (this.root is null)
            {
                throw new InvalidOperationException(nameof(this.root));
            }

            return this.PreOrder(this.root);
        }

        /// <summary>
        /// Tree traversal by inorder.
        /// </summary>
        /// <returns>Node value</returns>
        public IEnumerable<T> InOrder()
        {
            if (this.root is null)
            {
                throw new InvalidOperationException(nameof(this.root));
            }

            return this.InOrder(this.root);
        }

        /// <summary>
        /// Tree traversal by postorder.
        /// </summary>
        /// <returns>Node value</returns>
        public IEnumerable<T> PostOrder()
        {
            if (this.root is null)
            {
                throw new InvalidOperationException(nameof(this.root));
            }

            return this.PostOrder(this.root);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.PreOrder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.PreOrder().GetEnumerator();
        }

        private Node<T> Find(T element, Node<T> node)
        {
            if (node == null)
            {
                return null;
            }

            if (this.comparer.Compare(node.Value, element) == 0)
            {
                return node;
            }

            if (this.comparer.Compare(node.Value, element) > 0)
            {
                return this.Find(element, node.Left);
            }
            else
            {
                return this.Find(element, node.Right);
            }
        }

        private void Insert(T element, Node<T> node)
        {
            if (this.comparer.Compare(node.Value, element) > 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(element);
                    this.Count++;
                }
                else
                {
                    this.Insert(element, node.Left);
                }
            }

            if (this.comparer.Compare(node.Value, element) <= 0)
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(element);
                    this.Count++;
                }
                else
                {
                    this.Insert(element, node.Right);
                }
            }
        }

        private void Remove(T element, Node<T> node)
        {
            if (this.comparer.Compare(node.Value, element) > 0)
            {
                this.Remove(element, node.Left);
            }

            if (this.comparer.Compare(node.Value, element) < 0)
            {
                this.Remove(element, node.Right);
            }

            if (this.comparer.Compare(node.Value, element) == 0)
            {
                if (node.Left == null && node.Right == null)
                {
                    node = null;
                    return;
                }

                if (node.Left == null)
                {
                    node = node.Right;
                    node.Right = null;
                    this.Count--;
                    return;
                }

                if (node.Right == null)
                {
                    node = node.Left;
                    node.Left = null;
                    this.Count--;
                    return;
                }

                if (node.Right.Left == null)
                {
                    node = node.Right;
                    node.Right = null;
                    this.Count--;
                    return;
                }
                else
                {
                    Node<T> theMostLeft = this.FindTheMostLeft(node.Right);
                    node.Value = theMostLeft.Value;
                    this.Remove(theMostLeft.Value);
                }
            }
        }

        private Node<T> FindTheMostLeft(Node<T> node)
        {
            if (node.Left != null)
            {
                this.FindTheMostLeft(node.Left);
            }

            return node;
        }

        private IEnumerable<T> PreOrder(Node<T> node)
        {
            yield return node.Value;

            if (node.Left != null)
            {
                foreach (var element in this.PreOrder(node.Left))
                {
                    yield return element;
                }
            }

            if (node.Right != null)
            {
                foreach (var element in this.PreOrder(node.Right))
                {
                    yield return element;
                }
            }
        }

        private IEnumerable<T> InOrder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var element in this.InOrder(node.Left))
                {
                    yield return element;
                }
            }

            yield return node.Value;

            if (node.Right != null)
            {
                foreach (var element in this.InOrder(node.Right))
                {
                    yield return element;
                }
            }
        }

        private IEnumerable<T> PostOrder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var element in this.PostOrder(node.Left))
                {
                    yield return element;
                }
            }

            if (node.Right != null)
            {
                foreach (var element in this.PostOrder(node.Right))
                {
                    yield return element;
                }
            }

            yield return node.Value;
        } 
    }
}