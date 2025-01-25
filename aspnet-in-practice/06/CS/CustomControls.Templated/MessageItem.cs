using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace CustomControls.Templated
{
	public class MessageItem : Control, INamingContainer
	{
		private Message parentControl;
		public MessageItem(Message parent)
		{
			parentControl = parent;
		}

		public string Text
		{
			get
			{
				return parentControl.Text;
			}
		}
	}
}