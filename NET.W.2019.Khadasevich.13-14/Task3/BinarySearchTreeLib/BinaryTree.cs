using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTreeLib
{
    /// <summary>
    /// A class that represents tree node entity
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    public class TreeNode<T>
    {
        #region Fields
        /// <summary>
        /// Tree node data
        /// </summary>
        private T data;

        /// <summary>
        /// Reference to the left node
        /// </summary>
        private TreeNode<T> leftNode;

        /// <summary>
        /// Reference to the right node
        /// </summary>
        private TreeNode<T> rightNode;

        /// <summary>
        /// Reference to the parent node
        /// </summary>
        private TreeNode<T> parentNode;

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref=TreeNode{T}/> class
        /// </summary>
        /// <param name="data"></param>
        public TreeNode(T data)
        {
            this.Data = data;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets data
        /// </summary>
        public T Data { get => data; set => data = value; }

        /// <summary>
        /// Gets or sets left node
        /// </summary>
        public TreeNode<T> LeftNode { get => leftNode; set => leftNode = value; }

        /// <summary>
        /// Gets or sets right node
        /// </summary>
        public TreeNode<T> RightNode { get => rightNode; set => rightNode = value; }

        /// <summary>
        /// Gets or sets parent node
        /// </summary>
        public TreeNode<T> ParentNode { get => parentNode; set => parentNode = value; }

        #endregion
    }

    /// <summary>
    /// Represents a class providing binary tree search operations
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    public class BinaryTree<T> : IEnumerable<T>
    {
        #region Fields
        /// <summary>
        /// Tree root
        /// </summary>
        private TreeNode<T> rootNode;

        /// <summary>
        /// Provides method that compares two objects with the same type
        /// </summary>
        private Comparison<T> comparer;

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTree{T}"/> class
        /// </summary>
        /// <param name="collection">Collection of data</param>
        /// <param name="comparison">Comparison method</param>
        /// <exception cref="ArgumentNullException">Thrown when data collection or comparison method is null</exception>
        public BinaryTree(IEnumerable<T> collection, Comparison<T> comparison)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Data collection is null.");
            }

            if (comparison == null)
            {
                throw new ArgumentNullException("Comparision method is null.");
            }

            RootNode = null;
            Comparer = comparison;

            foreach (var element in collection)
            {
                InsertNode(element);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTree{T}"/> class with default comparison method
        /// </summary>
        /// <param name="collection">Data collection</param>
        public BinaryTree(IEnumerable<T> collection) : this(collection, Comparer<T>.Default.Compare)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets root node
        /// </summary>
        public TreeNode<T> RootNode { get => rootNode; set => rootNode = value; }

        /// <summary>
        /// Gets or sets comparer
        /// </summary>
        public Comparison<T> Comparer { get => comparer; set => comparer = value; }

        #endregion

        #region Public API
        /// <summary>
        /// Inserts new node into binary tree
        /// </summary>
        /// <param name="data">New node data</param>
        public void InsertNode(T data)
        {
            TreeNode<T> newNode = new TreeNode<T>(data);

            if (RootNode == null)
            {
                RootNode = newNode;
            }
            else
            {
                TreeNode<T> currentNode = RootNode;

                TreeNode<T> parentNode = null;
                while (currentNode != null)
                {
                    parentNode = currentNode;
                    if (Comparer(data, currentNode.Data) < 0)
                    {
                        currentNode = currentNode.LeftNode;
                        if (currentNode == null)
                        {
                            parentNode.LeftNode = newNode;
                        }
                    }
                    else if (Comparer(data, currentNode.Data) == 0)
                    {
                        currentNode.Data = data;
                    }
                    else
                    {
                        currentNode = currentNode.RightNode;
                        if (currentNode == null)
                        {
                            parentNode.RightNode = newNode;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks if current binary tree contains specified element
        /// </summary>
        /// <param name="element">Element to find</param>
        /// <returns>True if binary tree contains element. False otherwise</returns>
        public bool Contains(T element)
        {
            if (RootNode == null)
            {
                return false;
            }

            TreeNode<T> currentNode = RootNode;

            while (currentNode != null)
            {
                if (Comparer(element, currentNode.Data) == 0)
                {
                    return true;
                }
                else if (Comparer(element, currentNode.Data) < 0)
                {
                    currentNode = currentNode.LeftNode;
                }
                else
                {
                    currentNode = currentNode.RightNode;
                }
            }

            return false;
        }

        /// <summary>
        /// Provides infix traversal of the binary tree
        /// </summary>
        /// <returns>Enumerable infix traverse</returns>
        public IEnumerable<T> InOrder()
        {
            return InOrder(RootNode);
        }

        /// <summary>
        /// Provides prefix traversal of the binary tree
        /// </summary>
        /// <returns>Enumerable prefix traverse</returns>
        public IEnumerable<T> PreOrder()
        {
            return PreOrder(RootNode);
        }

        /// <summary>
        /// Provides postfix traversal of the binary tree
        /// </summary>
        /// <returns>Enumerable postfix traverse</returns>
        public IEnumerable<T> PostOrder()
        {
            return PostOrder(RootNode);
        }

        /// <summary>
        /// Returns enumerable infix traversal of the binary tree
        /// </summary>
        /// <returns>Enumerable infix traversal</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }

        /// <summary>
        /// Returns enumerator for the binary tree
        /// </summary>
        /// <returns>Enumerator for the binary tree</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Private API

        /// <summary>
        /// Provides infix traversal of the binary tree
        /// </summary>
        /// <returns>Enumerable infix traverse</returns>
        private IEnumerable<T> InOrder(TreeNode<T> currentNode)
        {
            if (currentNode.LeftNode != null)
            {
                foreach (var node in InOrder(currentNode.LeftNode))
                {
                    yield return node;
                }
            }

            yield return currentNode.Data;

            if (currentNode.RightNode != null)
            {
                foreach (var node in InOrder(currentNode.RightNode))
                {
                    yield return node;
                }
            }
        }

        /// <summary>
        /// Provides prefix traversal of the binary tree
        /// </summary>
        /// <returns>Enumerable prefix traverse</returns>
        private IEnumerable<T> PreOrder(TreeNode<T> currentNode)
        {
            yield return currentNode.Data;

            if (currentNode.LeftNode != null)
            {
                foreach (var node in PreOrder(currentNode.LeftNode))
                {
                    yield return node;
                }
            }

            if (currentNode.RightNode != null)
            {
                foreach (var node in PreOrder(currentNode.RightNode))
                {
                    yield return node;
                }
            }
        }

        /// <summary>
        /// Provides postfix traversal of the binary tree
        /// </summary>
        /// <returns>Enumerable postfix traverse</returns>
        private IEnumerable<T> PostOrder(TreeNode<T> currentNode)
        {
            if (currentNode.LeftNode != null)
            {
                foreach (var node in PostOrder(currentNode.LeftNode))
                {
                    yield return node;
                }
            }

            if (currentNode.RightNode != null)
            {
                foreach (var node in PostOrder(currentNode.RightNode))
                {
                    yield return node;
                }
            }

            yield return currentNode.Data;
        }

        #endregion
    }
}
