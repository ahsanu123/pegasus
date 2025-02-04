using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.Json;
using Elmah.ContentSyndication;
using WebGrease.Css.Extensions;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Web;

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

        public static IEnumerable<string> GetForm(this Type type, bool includeId=true)
        {
            var list = type.GetProperties().Select(item => item.Name);
            if(includeId)
                return list.Where(item => item.ToLower()!="id").ToList();
            return list.ToList();   
        }

        public static void  RedirectWithQuery(this HttpResponse response, string url, object queryParam)
        {
            var query = HttpUtility.ParseQueryString(String.Empty);

            foreach(var prop in queryParam.GetType().GetProperties())
            {
                query[prop.Name] = prop.GetValue(queryParam).ToString();
            }

            response.Redirect($"{url}?{query}");
        }
    }
}
