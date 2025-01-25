using System;
using System.Web.UI;

namespace WingtipToys.CustomControl
{
    [ParseChildren]
    public class Message : Control, INamingContainer
    {
        [TemplateContainer(typeof(MessageItem))]
        public ITemplate ItemTemplate { get; set; }
        public string Text
        {
            get { return ViewState["Text"] as string; }
            set { ViewState["Text"] = value; }
        }

        protected override void CreateChildControls()
        {
            //base.CreateChildControls();
            if (ItemTemplate != null)
            {
                MessageItem template = new MessageItem(this);
                ItemTemplate.InstantiateIn(template);

                this.Controls.Clear();
                this.Controls.Add(template);
            }
            else
            {
                Controls.Add(new LiteralControl(Text));
            }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            EnsureChildControls();
            base.OnDataBinding(e);
        }
    }

    public class MessageItem : Control, INamingContainer
    {
        private Message _parentControl;

        public MessageItem(Message parent)
        {
            _parentControl = parent;
        }

        public string Text
        {
            get { return _parentControl.Text; }
        }
    }
}

