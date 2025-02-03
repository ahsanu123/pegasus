using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.Json;
using Elmah.ContentSyndication;
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

            var jsonstring = JsonSerializer.Serialize(formObject);

            T deserialized = JsonSerializer.Deserialize<T>(jsonstring);
            return deserialized;
        }

        public static string GetFormAsJson(NameValueCollection form)
        {
            var jsonstring = JsonSerializer.Serialize(
                form.AllKeys.ToDictionary(key => key, key => form[key]),
                new JsonSerializerOptions { WriteIndented = true }
            );
            return jsonstring;
        }
    }
}
