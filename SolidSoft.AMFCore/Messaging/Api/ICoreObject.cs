using SolidSoft.AMFCore.Messaging.Api.Event;

namespace SolidSoft.AMFCore.Messaging.Api
{
	/// <summary>
	/// Base interface containing common methods and attributs for all core objects.
	/// </summary>
	public interface ICoreObject : IAttributeStore, IEventDispatcher, IEventHandler, IEventListener
	{
	}
}