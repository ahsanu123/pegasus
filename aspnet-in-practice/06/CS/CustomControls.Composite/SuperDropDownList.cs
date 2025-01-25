using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.ComponentModel;

namespace CustomControls.Composite
{
	[DefaultEvent("SelectedValueChanged")]
	public class SuperDropDownList: CompositeControl, INamingContainer
	{
		public string Description
		{
			get { return ViewState["Description"] as string; }
			set { ViewState["Description"] = value; }
		}

		public IList DataSource
		{
			get
			{
				// this will ensure that the child controls are ready to be used
				EnsureChildControls();
				return ((DropDownList)Controls[3]).DataSource as IList;
			}

			set
			{
				EnsureChildControls();
				((DropDownList)Controls[3]).DataSource = value;
			}
		}

		public string SelectedValue
		{
			get
			{
				EnsureChildControls();
				return ((DropDownList)Controls[3]).SelectedValue;
			}

			set
			{
				EnsureChildControls();
				((DropDownList)Controls[3]).SelectedValue = value;
			}
		}

		public bool AutoPostBack
		{
			get
			{
				EnsureChildControls();
				return ((DropDownList)Controls[3]).AutoPostBack;
			}

			set
			{
				EnsureChildControls();
				((DropDownList)Controls[3]).AutoPostBack = value;
			}
		}

		// event
		public event EventHandler SelectedValueChanged;

		protected void OnSelectedValueChanged(EventArgs e)
		{
			if (SelectedValueChanged != null)
				SelectedValueChanged(this, e);
		}

		protected override void CreateChildControls()
		{
			if (ChildControlsCreated)
				return;

			Controls.Clear();

			Controls.Add(new LiteralControl("<p>"));

			Label labelText = new Label();
			labelText.Text = Description;

			Controls.Add(labelText);

			Controls.Add(new LiteralControl(string.IsNullOrEmpty(Description)?string.Empty:": "));

			DropDownList listControl = new DropDownList();

			listControl.SelectedIndexChanged += (object sender, EventArgs e) => { OnSelectedValueChanged(e); };

			Controls.Add(listControl);

			ChildControlsCreated = true;
		}
	}
}