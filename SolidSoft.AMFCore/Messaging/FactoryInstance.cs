﻿using System;
using System.Collections;

namespace SolidSoft.AMFCore.Messaging
{
	/// <summary>
	/// This class is used by the IFlexFactory to store the configuration for an instance created by the factory.
	/// There is one of these for each destination currently since only destinations create these components.
	/// </summary>
	public class FactoryInstance
	{
		IFlexFactory _factory;
		string _id;
		Hashtable _properties;
		string _scope;
		string _source;
		string _attributeId;

		/// <summary>
        /// Initializes a new instance of the FactoryInstance class.
		/// </summary>
		/// <param name="factory">The IFlexFactory this FactoryInstance is created from.</param>
		/// <param name="id">The Destination's id.</param>
		/// <param name="properties">The configuration properties for this destination.</param>
		public FactoryInstance(IFlexFactory factory, string id, Hashtable properties)
		{
			_factory = factory;
			_id = id;
			_properties = properties;
		}

		public string Id
		{
			get{ return _id; }
		}

		public virtual string Scope
		{
			get{ return _scope; }
			set{ _scope = value; }
		}

		public virtual string Source
		{
			get{ return _source; }
			set{ _source = value; }
		}

		public string AttributeId
		{
			get{ return _attributeId; }
			set{ _attributeId = value; }
		}


		public Hashtable Properties
		{
			get{ return _properties; }
		}

		/// <summary>
		/// If possible, returns the class for the underlying configuration. 
		/// This method can return null if the class is not known until the lookup method is called. 
		/// The goal is so the factories which know the class at startup time can provide earlier error detection. 
		/// If the class is not known, this method can return null and validation will wait until the first lookup call.
		/// </summary>
		/// <returns></returns>
		public virtual Type GetInstanceClass()
		{
			return null;
		}

		/// <summary>
		/// Return an instance as appropriate for this instance of the given factory. This just calls the lookup method on the factory 
		/// that this instance was created on. You override this method to return the specific component for this destination. 
		/// </summary>
		/// <returns></returns>
		public virtual object Lookup()
		{
			return _factory.Lookup(this);
		}

		/// <summary>
		/// When the caller is done with the instance, this method is called. For session scoped components, this gives you the opportunity to 
		/// update any state modified in the instance in a remote persistence store. 
		/// </summary>
		/// <param name="instance"></param>
		public virtual void OnOperationComplete(object instance)
		{
		}
	}
}