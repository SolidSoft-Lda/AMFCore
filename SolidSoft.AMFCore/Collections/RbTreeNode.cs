namespace SolidSoft.AMFCore.Collections
{
    /// <summary>
    /// Node of a red-black tree.
    /// </summary>
    public class RbTreeNode
    {
        /// <summary>
        /// Creates a default node with value val.
        /// </summary>
        /// <remarks>
        /// Node has no children and is red.
        /// </remarks>
        public RbTreeNode(object val):this(val, RbTreeNode.Nil, RbTreeNode.Nil, RbTreeNode.Nil, true)
        {
        }

        /// <summary>
        /// Creates a node from field values.
        /// </summary>
        public RbTreeNode(object val, RbTreeNode parent, RbTreeNode left, RbTreeNode right, bool isRed)
        {
            Value = val;
            Parent = parent;
            Left = left;
            Right = right;
            IsRed = isRed;
        }

        /// <summary>
        /// true if node is logically null (leaf) node, false otherwise.
        /// </summary>
        public virtual bool IsNull { get { return false; } }

        /// <summary>
        /// Value held by the node.
        /// </summary>
        public object Value;

        /// <summary>
        /// Parent node.
        /// </summary>
        public RbTreeNode Parent;

        /// <summary>
        /// Left child.
        /// </summary>
        public RbTreeNode Left;

        /// <summary>
        /// Right child.
        /// </summary>
        public RbTreeNode Right;

        /// <summary>
        /// true if node is red, false if node is black.
        /// </summary>
        public bool IsRed;

        /// <summary>
        /// Logically null (leaf) node.
        /// </summary>
        public static readonly RbTreeNode Nil = new NullNode();

        /// <summary>
        /// Constructor used internally for creating a Nil node.
        /// </summary>
        protected RbTreeNode() { }

        /// <summary>
        /// Represents null node
        /// </summary>
        /// <remarks>
        /// Null node is a leaf node with null value and without children.
        /// It is always black.
        /// </remarks>
        private class NullNode : RbTreeNode
        {
            /// <summary>
            /// Creates a logically null node.
            /// </summary>
            public NullNode()
            {
                Parent = this;
                Left = this;
                Right = this;
                IsRed = false;
            }

            /// <summary>
            /// Returns true for logically null node.
            /// </summary>
            public override bool IsNull { get { return true; } }
        }
    }
}