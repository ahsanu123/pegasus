using System;
using System.Web;

namespace WingtipToys.ApplicationState
{
    public interface IPageStateBase
    {
        string Id { get; set; }
    }

    public static class PageState
    {
        public static event Action<string, IPageStateBase> StateChange;

        public static void SetState(IPageStateBase stateBase)
        {
            HttpContext.Current.Session[stateBase.Id] = stateBase;
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
    }
}
