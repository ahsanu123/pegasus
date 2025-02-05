using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Elmah.ContentSyndication;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using WebGrease.Css.Extensions;

namespace WingtipToys.Helper
{
    public static class HelperFunction
    {
        public static T GetData<T>(NameValueCollection form)
        {
            var listkeys = typeof(T).GetProperties().Select(item => item.Name);
            var filteredFormkey = form.AllKeys.Where(item => listkeys.Contains(item));

            var formObject = new Dictionary<string, string>();

            filteredFormkey.ForEach(item =>
            {
                formObject.Add(item, form[item]);
            });

            var jsonstring = JsonConvert.SerializeObject(formObject);

            var deserialized = JsonConvert.DeserializeObject<T>(jsonstring);

            return deserialized;
        }

        public static string GetFormAsJson(NameValueCollection form)
        {
            var jsonstring = JsonConvert.SerializeObject(
                form.AllKeys.ToDictionary(key => key, key => form[key])
            );
            return jsonstring;
        }

        public static IEnumerable<string> GetForm(this Type type, bool includeId = true)
        {
            var list = type.GetProperties().Select(item => item.Name);
            if (includeId)
                return list.Where(item => item.ToLower() != "id").ToList();
            return list.ToList();
        }

        public static void RedirectWithQuery(
            this HttpResponse response,
            string url,
            object queryParam
        )
        {
            var query = HttpUtility.ParseQueryString(String.Empty);

            foreach (var prop in queryParam.GetType().GetProperties())
            {
                query[prop.Name] = prop.GetValue(queryParam).ToString();
            }

            response.Redirect($"{url}?{query}");
        }

        public static bool IsRepeaterItem(this RepeaterItemEventArgs args)
        {
            return (
                args.Item.ItemType == ListItemType.Item
                || args.Item.ItemType == ListItemType.AlternatingItem
            );
        }

        public static T GetRepeaterDataItem<T>(this RepeaterItemEventArgs args)
        {
            return (T)args.Item.DataItem;
        }

        public static T FindControlAs<T>(this RepeaterItemEventArgs args, string controlName)
            where T : Control
        {
            var control = args.Item.FindControl(controlName);
            return (T)control;
        }

        public static string SerializeObject(object anything)
        {
            return JsonConvert.SerializeObject(anything);
        }

        public static T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
