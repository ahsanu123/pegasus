using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WingtipToys.CustomControl
{
    public class DataSelect : DataBoundControl
    {
        private IEnumerable<string> _dataArray;
        public string Value
        {
            get { return Context.Request.Form[GetId("customSelect")]; }
        }

        public DataSelect()
        {
            Init += (src, args) =>
            {
                ViewStateMode = ViewStateMode.Disabled;
            };
        }

        protected override void PerformDataBinding(IEnumerable data)
        {
            //base.PerformDataBinding(data);
            _dataArray = data.Cast<string>();
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Name, GetId("customSelect"));

            writer.RenderBeginTag(HtmlTextWriterTag.Select);
            foreach (var item in _dataArray)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Value, item);
                if((item == _dataArray.First() && Value == null) || item == Value)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Selected, "selected");
                }
                writer.RenderBeginTag(HtmlTextWriterTag.Option);
                writer.Write(item);
                writer.RenderEndTag();
            }
            writer.RenderEndTag();
        }

        protected string GetId(string name)
        {
            return string.Format("{0}{1}{2}", ClientID, ClientIDSeparator, name);
        }
    }
}
