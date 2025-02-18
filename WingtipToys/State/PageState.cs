using System;
using System.Collections.Generic;
using System.Security.RightsManagement;
using System.Web;

namespace WingtipToys.ApplicationState
{
    public interface IPageStateBase
    {
        string Id { get; set; }
    }

    public static class AppState{
        public static ProductPageState ProductPageState {get;set;} = new ProductPageState();
    }

    public static class PageState
    {
        private static Dictionary<string, Action<IPageStateBase>> _subscriber;

        public static void SetState(IPageStateBase stateBase)
        {
            HttpContext.Current.Session[stateBase.Id] = stateBase;

            if (_subscriber != null && _subscriber.ContainsKey(stateBase.Id))
            {
                _subscriber[stateBase.Id]?.Invoke(stateBase);
            }
        }

        public static T GetState<T>(string key)
            where T : IPageStateBase
        {
            return (T)HttpContext.Current.Session[key];
        }

        public static void RemoveState(string key)
        {
            if (HttpContext.Current.Session[key] != null)
                HttpContext.Current.Session.Remove(key);
        }

        public static void ClearState()
        {
            HttpContext.Current.Session.Clear();
        }

        public static void Subscribe(string key, Action<IPageStateBase> callback)
        {
            if (_subscriber != null && !_subscriber.ContainsKey(key))
                _subscriber.Add(key, callback);
        }

        public static void Unsubscribe(string key)
        {
            if (_subscriber != null && _subscriber.ContainsKey(key))
                _subscriber.Remove(key);
        }
    }
}
