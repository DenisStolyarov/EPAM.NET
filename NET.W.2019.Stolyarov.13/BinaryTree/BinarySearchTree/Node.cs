// <copyright file="Node.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>
namespace BinarySearchTree
{
    /// <summary>
    /// Tree node
    /// </summary>
    /// <typeparam name="T">Universal type.</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class.
        /// </summary>
        /// <param name="value">The specified value.</param>
        public Node(T value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }

        /// <summary>
        /// Gets or sets the specified value.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Gets or sets pointer on the left node.
        /// </summary>
        public Node<T> Left { get; set; }

        /// <summary>
        /// Gets or sets pointer on the right node.
        /// </summary>
        public Node<T> Right { get; set; }
    }
}