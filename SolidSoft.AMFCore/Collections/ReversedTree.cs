namespace SolidSoft.AMFCore.Collections
{
    /// <summary>
    /// Summary description for ReversedTree.
    /// </summary>
    internal sealed class ReversedTree : System.Collections.IEnumerable
    {
        private RbTree _tree;

        public ReversedTree(RbTree tree)
        {
            _tree = tree;
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return new Enumerator(_tree);
        }

        private sealed class Enumerator : System.Collections.IEnumerator
        {
            RbTree _tree;
            RbTreeNode _currentNode;

            public Enumerator(RbTree tree)
            {
                _tree = tree;
            }

            #region IEnumerator Members

            public void Reset()
            {
                _currentNode = null;
            }

            public object Current
            {
                get
                {
                    // if _currentNode is null, will throw an exception, which confirms to IEnumerable spec
                    return _currentNode.Value;
                }
            }

            public bool MoveNext()
            {
                if (_currentNode == null)
                {
                    _currentNode = _tree.First;
                }
                else
                {
                    _currentNode = _tree.Next(_currentNode);
                }

                return !_currentNode.IsNull;
            }

            #endregion
        }
    }
}