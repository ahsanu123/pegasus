using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Adapters;

namespace ASPNET4InPractice
{
    public class DataListAdapter : WebControlAdapter
    {
        int _repeatColumns = -1;
        private int RepeatColumns
        {
            get
            {
                if (_repeatColumns == -1)
                {
                    _repeatColumns = 1;
                    DataList dataList = Control as DataList;

                    if (dataList != null)
                    {
                        if (dataList.RepeatColumns == 0)
                        {
                            if (dataList.RepeatDirection == RepeatDirection.Horizontal)
                                _repeatColumns = dataList.Items.Count;
                        }
                        else
                        {
                            _repeatColumns = dataList.RepeatColumns;
                        }
                    }
                }
                return _repeatColumns;
            }
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            DataList dataList = Control as DataList;
            if (dataList != null)
            {
                // header
                if (dataList.HeaderTemplate != null)
                {
                    RenderHeader(writer, dataList);
                }

                // ItemTemplate && AlternatingItemTemplate
                if (dataList.ItemTemplate != null || dataList.AlternatingItemTemplate != null)
                {
                    RenderItem(writer, dataList);

                    if (dataList.RepeatDirection == RepeatDirection.Horizontal)
                        return;
                }

                // close the last div
                if ((dataList.Items.Count % RepeatColumns) != 0)
                {
                    writer.Indent--;
                    writer.WriteLine();
                    writer.WriteEndTag("div");
                }

            }

            writer.Indent--;
            writer.WriteLine();

            // FooterTemplate
            if (dataList.FooterTemplate != null)
            {
                RenderFooter(writer, dataList);
            }
        }

        private void RenderFooter(HtmlTextWriter writer, DataList dataList)
        {
            writer.WriteLine();
            writer.WriteBeginTag("div");

            // restore style
            CssStyleCollection style = GetStyleFromTemplate(dataList, dataList.FooterStyle);
            style.Add("clear", "both");
            writer.WriteAttribute("style", style.Value);

            writer.Write(HtmlTextWriter.TagRightChar);
            writer.Indent++;

            PlaceHolder container = new PlaceHolder();
            dataList.FooterTemplate.InstantiateIn(container);
            container.DataBind();
            container.RenderControl(writer);

            writer.Indent--;
            writer.WriteLine();
            writer.WriteEndTag("div");
        }

        private void RenderItem(HtmlTextWriter writer, DataList dataList)
        {
            // get Data Items
            DataListItemCollection items = dataList.Items;

            writer.WriteLine();
            DataListItem currentItem;

            int itemsPerColumn = (int)Math.Ceiling(((Double)dataList.Items.Count) / ((Double)RepeatColumns));

            int rowIndex, columnIndex, currentIndex = 0;

			Page.Trace.Write("itemsPerColumn", itemsPerColumn.ToString());

            // enumerate rows
            for (int index = 0; index < dataList.Items.Count; index++)
            {
                rowIndex = index / RepeatColumns;
                columnIndex = index % RepeatColumns;
                currentIndex = index;

                // calcutate the real DataItem index
                if (dataList.RepeatDirection == RepeatDirection.Vertical)
                    currentIndex = (columnIndex * itemsPerColumn) + rowIndex;

                // get the DataItem
                currentItem = items[currentIndex];

                if ((index % RepeatColumns) == 0)
                {
                    writer.WriteLine();
                    writer.WriteBeginTag("div");

                    writer.WriteAttribute("style", "clear:both");

                    writer.Write(HtmlTextWriter.TagRightChar);
                    writer.Indent++;
                }

                writer.WriteLine();

                writer.WriteBeginTag("div");

                // restore original style
                TableItemStyle style = (currentItem.ItemType == ListItemType.Item) ?
                                        dataList.ItemStyle :
                                        (dataList.AlternatingItemStyle == null ? dataList.ItemStyle : dataList.AlternatingItemStyle);

                // RepeatColumns Width support
                style.Width = new Unit((int)Math.Abs((double)100 / RepeatColumns), UnitType.Percentage);

                CssStyleCollection finalStyle = GetStyleFromTemplate(dataList, style);
                if (dataList.RepeatColumns > 1)
                    finalStyle.Add("float", "left");

                writer.WriteAttribute("style", finalStyle.Value);

                writer.Write(HtmlTextWriter.TagRightChar);
                writer.Indent++;

                foreach (Control itemCtrl in currentItem.Controls)
                {
                    itemCtrl.RenderControl(writer);
                }

                writer.Indent--;
                writer.WriteLine();
                writer.WriteEndTag("div");

                if (((index + 1) % RepeatColumns) == 0)
                {
                    writer.Indent--;
                    writer.WriteLine();
                    writer.WriteEndTag("div");
                }
            }
        }

        private void RenderHeader(HtmlTextWriter writer, DataList dataList)
        {
            writer.WriteBeginTag("div");

            // restore style
            CssStyleCollection style = GetStyleFromTemplate(dataList, dataList.HeaderStyle);

            if (!String.IsNullOrEmpty(style.Value))
                writer.WriteAttribute("style", style.Value);

            writer.Write(HtmlTextWriter.TagRightChar);

            PlaceHolder container = new PlaceHolder();
            dataList.HeaderTemplate.InstantiateIn(container);
            container.DataBind();

            if ((container.Controls.Count == 1) && typeof(LiteralControl).IsInstanceOfType(container.Controls[0]))
            {
                writer.WriteLine();

                LiteralControl literalControl = container.Controls[0] as LiteralControl;
                writer.Write(literalControl.Text.Trim());
            }
            else
            {
                container.RenderControl(writer);
            }

            writer.WriteEndTag("div");
        }

        protected override void RenderBeginTag(HtmlTextWriter writer)
        {
            DataList dataList = Control as DataList;

            writer.WriteBeginTag("div");

            if (dataList.Style.Value != null)
                writer.WriteAttribute("style", dataList.Style.Value);

            if (!String.IsNullOrEmpty(dataList.CssClass))
                writer.WriteAttribute("class", dataList.CssClass);

            writer.Write(HtmlTextWriter.TagRightChar);
            writer.Indent++;
        }

        protected override void RenderEndTag(HtmlTextWriter writer)
        {
            writer.WriteEndTag("div");
        }

        private CssStyleCollection GetStyleFromTemplate(DataList dataList, TableItemStyle style)
        {
            CssStyleCollection finalStyle = style.GetStyleAttributes(dataList);
            return finalStyle;
        }

    }
}