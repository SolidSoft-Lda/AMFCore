namespace SolidSoft.AMFCore.Collections
{
    /// <summary>
    /// Sorted set of unique (non-equal) objects
    /// </summary>
    public class Set : SetBase
    {
        /// <summary>
        /// Creates an empty set with default comparer; members must implement IComparable.
        /// </summary>
        public Set():base(System.Collections.Comparer.Default, false)
        {
        }

        /// <summary>
        /// Creates a set from elements of given collection; default comparer is used; members must implement IComparable.
        /// </summary>
        public Set(System.Collections.ICollection collection):this()
        {
            foreach (object obj in collection)
            {
                Add(obj);
            }
        }

        /// <summary>
        /// Creates an empty set that uses given comparer object.
        /// </summary>
        public Set(System.Collections.IComparer comparer):base(comparer, false)
        {
        }

        /// <summary>
        /// Creates a set from elements of given collection that uses given comparer object.
        /// </summary>
        public Set(System.Collections.IComparer comparer, System.Collections.ICollection collection):this(comparer)
        {
            foreach (object obj in collection)
            {
                Add(obj);
            }
        }

        /// <summary>
        /// Returns union of two sets.
        /// </summary>
        public Set Union(Set other)
        {
            return Union(this, other);
        }

        /// <summary>
        /// Returns union of two sets.
        /// </summary>
        public static Set Union(Set a, Set b)
        {
            a.CheckComparer(b);
            Set result = new Set(a.Comparer);
            SetOp.Union(a, b, a.Comparer, new Inserter(result));
            return result;
        }

        /// <summary>
        /// Returns intersection of two sets.
        /// </summary>
        /// <remarks>Intersection contains elements present in both sets.</remarks>
        public Set Intersection(Set other)
        {
            return Intersection(this, other);
        }

        /// <summary>
        /// Returns intersection of two sets.
        /// </summary>
        /// <remarks>Intersection contains elements present in both sets.</remarks>
        public static Set Intersection(Set a, Set b)
        {
            a.CheckComparer(b);
            Set result = new Set(a.Comparer);
            SetOp.Inersection(a, b, a.Comparer, new Inserter(result));
            return result;
        }

        /// <summary>
        /// Returns difference of two sets.
        /// </summary>
        /// <remarks>
        /// Difference contains elements present in first set, but not in the second.<br/>
        /// Difference is not symmetric. Difference(a,b) is not equal to Difference(b,a)
        /// </remarks>
        public Set Difference(Set other)
        {
            return Difference(this, other);
        }

        /// <summary>
        /// Returns difference of two sets.
        /// </summary>
        /// <remarks>
        /// Difference contains elements present in first set, but not in the second.<br/>
        /// Difference is not symmetric. Difference(a,b) is not equal to Difference(b,a)
        /// </remarks>
        public static Set Difference(Set a, Set b)
        {
            a.CheckComparer(b);
            Set result = new Set(a.Comparer);
            SetOp.Difference(a, b, a.Comparer, new Inserter(result));
            return result;
        }

        /// <summary>
        /// Returns symmetric difference of two sets.
        /// </summary>
        /// <remarks>
        /// Symmetric difference contains elements present in one of the sets, but not in both.
        /// </remarks>
        public Set SymmetricDifference(Set other)
        {
            return SymmetricDifference(this, other);
        }

        /// <summary>
        /// Returns symmetric difference of two sets.
        /// </summary>
        /// <remarks>
        /// Symmetric difference contains elements present in one of the sets, but not in both
        /// </remarks>
        public static Set SymmetricDifference(Set a, Set b)
        {
            a.CheckComparer(b);
            Set result = new Set(a.Comparer);
            SetOp.SymmetricDifference(a, b, a.Comparer, new Inserter(result));
            return result;
        }
    }
}