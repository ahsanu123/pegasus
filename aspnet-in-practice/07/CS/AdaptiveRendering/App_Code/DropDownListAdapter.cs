using System;
using System.Web;
using System.Web.UI.WebControls.Adapters;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace ASPNET4InPractice
{
    public class DropDownListAdapter : WebControlAdapter
    {
        string uniqueID = null;

        protected override void RenderContents(HtmlTextWriter writer)
        {
            DropDownList list = this.Control as DropDownList;

            uniqueID = list.UniqueID;

            string lastOptionGroup = null;
            string currentOptionGroup = null;
            foreach (ListItem item in list.Items)
            {
                currentOptionGroup = item.Attributes["OptionGroup"] as string;

                if (currentOptionGroup != null)
                {
                    if (lastOptionGroup == null || !lastOptionGroup.Equals(currentOptionGroup, StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (lastOptionGroup != null)
                            RenderOptionGroupEndTag(writer);

                        RenderOptionGroupBeginTag(currentOptionGroup, writer);
                    }

                    lastOptionGroup = currentOptionGroup;
                }

                RenderListItem(item, writer);
            }

            if (lastOptionGroup != null)
                RenderOptionGroupEndTag(writer);
        }

        private void RenderOptionGroupBeginTag(string name, HtmlTextWriter writer)
        {
            writer.Indent++;
            writer.WriteBeginTag("optgroup");
            writer.WriteAttribute("label", name);
            writer.Write(HtmlTextWriter.TagRightChar);
            writer.WriteLine();
        }

        private void RenderOptionGroupEndTag(HtmlTextWriter writer)
        {
            writer.WriteEndTag("optgroup");
            writer.WriteLine();
            writer.Indent--;
        }

        private void RenderListItem(ListItem item, HtmlTextWriter writer)
        {
            writer.Indent++;
            writer.WriteBeginTag("option");
            writer.WriteAttribute("value", item.Value, true);

            if (item.Selected)
                writer.WriteAttribute("selected", "selected", false);

            foreach (string key in item.Attributes.Keys)
            {
                if (!key.Equals("optiongroup", StringComparison.CurrentCultureIgnoreCase))
                    writer.WriteAttribute(key, item.Attributes[key]);
            }

            writer.Write(HtmlTextWriter.TagRightChar);

            if (Page != null)
            {
                Page.ClientScript.RegisterForEventValidation(uniqueID, item.Value);
            }

            HttpUtility.HtmlEncode(item.Text, writer);
            writer.WriteEndTag("option");
            writer.WriteLine();
            writer.Indent--;
        }
    }
}