using System;

namespace ApplicationLayer.DesignPatterns.Observer
{
    public interface IEventDispatcher
    {
        void RegisterListener(EventsID eventID, Action<object> callback);
        void PostEvent(EventsID eventID, object param = null);
        void RemoveListener(EventsID eventID, Action<object> callback);
        void ClearAllListener();
    }
}
