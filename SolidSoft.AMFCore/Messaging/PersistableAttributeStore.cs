using System.Collections.Generic;
using SolidSoft.AMFCore.IO;
using SolidSoft.AMFCore.Messaging.Api;
using SolidSoft.AMFCore.Messaging.Api.Persistence;

namespace SolidSoft.AMFCore.Messaging
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class PersistableAttributeStore : AttributeStore, IPersistable
	{
		protected bool		_persistent = true;
		protected string	_name;
		protected string	_path;
		protected string	_type;
		protected long		_lastModified = -1;
		protected IPersistenceStore _store = null;

		public PersistableAttributeStore(string type, string name, string path, bool persistent)
		{
			_name = name;
			_path = path;
			_type = type;
			_persistent = persistent;
		}

		public virtual string Type
		{
			get{ return _type; }
			set{ _type = value; }
		}

		#region IPersistable Members

		public virtual bool IsPersistent
		{
			get{ return _persistent; }
			set{ _persistent = value; }
		}

		public virtual string Name
		{
			get{ return _name; }
			set{ _name = value; }
		}

		public virtual string Path
		{
			get{ return _path; }
			set{ _path = value; }
		}

		public virtual long LastModified
		{
			get{ return _lastModified; }
		}

		public virtual IPersistenceStore Store
		{
			get{ return _store; }
			set
			{
				_store = value;
				if( _store != null )
					_store.Load(this);
			}
		}

        public void Serialize(AMFWriter writer)
		{
			// TODO:  Add PersistableAttributeStore.Serialize implementation
		}

        public void Deserialize(AMFReader reader)
		{
			// TODO:  Add PersistableAttributeStore.Deserialize implementation
		}

		#endregion

		protected void OnModified()
		{
			_lastModified = System.Environment.TickCount;
			if(_store != null) 
				_store.Save(this);
		}

		public override bool RemoveAttribute(string name)
		{
			bool result = base.RemoveAttribute (name);
			if(result && !name.StartsWith(Constants.TransientPrefix))
				OnModified();
			return result;
		}

		public override void RemoveAttributes()
		{
			base.RemoveAttributes();
			OnModified();
		}

		public override bool SetAttribute(string name, object value)
		{
			bool result = base.SetAttribute (name, value);
            if (result && !name.StartsWith(Constants.TransientPrefix))
				OnModified();
			return result;
		}

		public override void SetAttributes(IAttributeStore values)
		{
			base.SetAttributes (values);
			OnModified();
		}

        /// <summary>
        /// Sets multiple attributes on this object.
        /// </summary>
        /// <param name="values">Dictionary of attributes.</param>
        public override void SetAttributes(IDictionary<string, object> values)
        {
            base.SetAttributes(values);
            OnModified();
        }
    }
}