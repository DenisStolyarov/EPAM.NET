// <copyright file="Queue.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>
namespace Collection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Class - container which allowing access to elements according to principle : first in first out.
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    public class Queue<T> : IEnumerable<T>
    {
        /// <summary>
        /// Begin of the queue
        /// </summary>
        private QueueItem head;

        /// <summary>
        /// End of the queue
        /// </summary>
        private QueueItem last;

        /// <summary>
        /// Gets queue size
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Add element to collection.
        /// </summary>
        /// <param name="item">User data</param>
        public void Push(T item)
        {
            QueueItem queueItem = new QueueItem(item);

            if (this.head == null)
            {
                this.head = queueItem;
                this.last = queueItem;
            }
            else
            {
                this.last.NextItem = queueItem;
                this.last = queueItem;
            }

            this.Count++;
        }

        /// <summary>
        /// Gets first element of queue.
        /// </summary>
        /// <returns>First value</returns>
        public T Top()
        {
            return this.head.Value;
        }

        /// <summary>
        /// Delete first element of queue.
        /// </summary>
        public void Pop()
        {
            this.head = this.head.NextItem;
            this.Count--;
        }

        /// <summary>
        /// Check count of elements.
        /// </summary>
        /// <returns>True - empty</returns>
        public bool IsEmpty()
        {
            if (this.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator(this.head);
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Element - wrapper to data.
        /// </summary>
        public class QueueItem
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="QueueItem"/> class.
            /// </summary>
            /// <param name="value">User data</param>
            public QueueItem(T value)
            {
                this.Value = value;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="QueueItem"/> class.
            /// </summary>
            public QueueItem() { }

            /// <summary>
            /// Gets or sets reference to next element of queue.
            /// </summary>
            public QueueItem NextItem { get; set; }

            /// <summary>
            /// Gets data.
            /// </summary>
            public T Value { get; }
        }

        /// <summary>
        /// Realize the enumerator for queue.
        /// </summary>
        public class QueueEnumerator : IEnumerator<T>
        {
            /// <summary>
            /// Start position.
            /// </summary>
            private readonly QueueItem head;

            /// <summary>
            /// Position of enumerator.
            /// </summary>
            private QueueItem position;

            /// <summary>
            /// Initializes a new instance of the <see cref="QueueEnumerator"/> class.
            /// </summary>
            /// <param name="queueItem">Start value</param>
            public QueueEnumerator(QueueItem queueItem)
            {
                this.position = new QueueItem
                {
                    NextItem = queueItem
                };
                this.head = queueItem;
            }

            /// <inheritdoc/>
            T IEnumerator<T>.Current
            {
                get
                {
                    if (this.position == null)
                    {
                        throw new InvalidOperationException();
                    }

                    return this.position.Value;
                }
            }

            /// <inheritdoc/>
            public object Current
            {
                get
                {
                    if (this.position == null)
                    {
                        throw new InvalidOperationException();
                    }

                    return this.position.Value;
                }
            }

            /// <inheritdoc/>
            public bool MoveNext()
            {
                if (this.position.NextItem != null)
                {
                    this.position = this.position.NextItem;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <inheritdoc/>
            public void Reset()
            {
                this.position = this.head;
            }

            /// <inheritdoc/>
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }
        }
    }
}