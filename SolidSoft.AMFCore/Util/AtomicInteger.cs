using System.Threading;

namespace SolidSoft.AMFCore.Util
{
    public class AtomicInteger
    {
        int _counter;

        public AtomicInteger()
            : this(0)
        {
        }

        public AtomicInteger(int initialValue)
        {
            _counter = initialValue;
        }

        public int Value
        {
            get
            {
                //Reading int32 is atomic already on both 32 and 64 bit systems
                return _counter;
            }
            set
            {
                Interlocked.Exchange(ref _counter, value);
            }
        }

        /// <summary>
        /// Atomically increment by one the current value.
        /// </summary>
        /// <returns></returns>
        public int Increment()
        {
			return Interlocked.Increment(ref _counter);
        }
        /// <summary>
        /// Atomically decrement by one the current value.
        /// </summary>
        /// <returns></returns>
        public int Decrement()
        {
			return Interlocked.Decrement(ref _counter);
        }

        public int PostDecrement()
        {
			return Interlocked.Decrement(ref _counter) + 1;
        }

        public int PostIncrement()
        {
			return Interlocked.Increment(ref _counter) - 1;
        }

        /// <summary>
        /// Atomically add the given value to current value.
        /// </summary>
        /// <param name="delta"></param>
        /// <returns></returns>
        public int Increment(int delta)
        {
            return Interlocked.Add(ref _counter, delta);
        }

		public int Decrement(int delta)
        {
            return Interlocked.Add(ref _counter, -delta);
        }

        public int PostDecrement(int delta)
        {
            return Interlocked.Add(ref _counter, -delta) + delta;
        }

        public int PostIncrement(int delta)
        {
            return (Interlocked.Add(ref _counter, delta) - delta);
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}