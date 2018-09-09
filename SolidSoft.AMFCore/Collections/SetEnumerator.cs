namespace SolidSoft.AMFCore.Collections
{
    /// <summary>
    /// Summary description for SetEnumerator.
    /// </summary>
    internal class SetEnumerator : System.Collections.IEnumerator
    {
        RbTree _tree;
        RbTreeNode _currentNode = null;

        public SetEnumerator(RbTree tree)
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