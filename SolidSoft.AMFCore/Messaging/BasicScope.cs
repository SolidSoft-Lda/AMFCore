using System.Collections;
using SolidSoft.AMFCore.Collections.Generic;
using SolidSoft.AMFCore.Messaging.Api;
using SolidSoft.AMFCore.Messaging.Api.Event;

namespace SolidSoft.AMFCore.Messaging
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class BasicScope : PersistableAttributeStore, IBasicScope
	{
        object _syncLock = new object();
		protected IScope	_parent;
        protected CopyOnWriteArray<IEventListener> _listeners = new CopyOnWriteArray<IEventListener>();
        /// <summary>
        /// Set to true to prevent the scope from being freed upon disconnect.
        /// </summary>
        protected bool _keepOnDisconnect = false;

		public BasicScope(IScope parent, string type, string name, bool persistent) : base(type, name, null, persistent)
		{
			_parent = parent;
		}

		#region IBasicScope Members

        /// <summary>
        /// Gets an object that can be used to synchronize access. 
        /// </summary>
        public object SyncRoot { get { return _syncLock; } }

        /// <summary>
        /// Checks whether the scope has a parent.
        /// You can think of scopes as of tree items
        /// where scope may have a parent and children (child).
        /// </summary>
		public bool HasParent
		{
			get{ return _parent != null; }
		}
        /// <summary>
        /// Get this scope's parent.
        /// </summary>
		public virtual IScope Parent
		{
			get{ return _parent; }
			set{ _parent = value; }
		}
        /// <summary>
        /// Get the scopes depth, how far down the scope tree is it. The lowest depth
        /// is 0x00, the depth of Global scope. Application scope depth is 0x01. Room
        /// depth is 0x02, 0x03 and so forth.
        /// </summary>
		public int Depth
		{
			get
			{ 
				if( HasParent )
					return _parent.Depth + 1;
				else
					return 0;
			}
		}
        /// <summary>
        /// Gets the full absolute path.
        /// </summary>
        public override string Path
		{
			get
			{
				if( HasParent )
					return _parent.Path + "/" + _parent.Name;
				else
					return string.Empty;
			}
		}

		#endregion

		public virtual void AddEventListener(IEventListener listener) 
		{
			_listeners.Add(listener);
		}

		public virtual void RemoveEventListener(IEventListener listener) 
		{
			_listeners.Remove(listener);
            if (!_keepOnDisconnect && _listeners.Count == 0) 
			{
				// Delete empty rooms
				_parent.RemoveChildScope(this);
			}
		}

		public ICollection GetEventListeners()
		{
			return _listeners;
		}

		public bool HandleEvent(IEvent evt) 
		{
			return false;
		}

		public void NotifyEvent(IEvent evt) 
		{
		}

		public virtual void DispatchEvent(IEvent evt) 
		{
			foreach(IEventListener listener in _listeners) 
			{
				if(evt.Source == null || evt.Source != listener) 
				{
					listener.NotifyEvent(evt);
				}
			}
		}

		#region IEnumerable Members

		public virtual IEnumerator GetEnumerator()
		{
			return null;
		}

		#endregion

		public override string ToString()
		{
			return this.Name;
		}
	}
}