using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.ApplicationState;
using WingtipToys.Models;

namespace WingtipToys.CustomControl
{
    public class ProductCardEventArg : EventArgs
    {
        public string Data { get; set; }
    }

    public static class ProductCardItemCommandArgs
    {
        public const string Save = "Save";
        public const string Edit = "Edit";
        public const string Cancel = "Cancel";
        public const string Delete = "Delete";
    }

    public partial class ProductCard : UserControl
    {
        public event EventHandler<ProductCardEventArg> ItemCommandHandler;
        public Product Product { get; set; }
        public bool IsEditMode { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsEditMode)
                ShowEditPanel();
            else if (!IsEditMode)
                ShowPreviewPanel();
        }

        private void ShowEditPanel()
        {
            EditPanel.Visible = true;
            PreviewPanel.Visible = false;
        }

        private void ShowPreviewPanel()
        {
            EditPanel.Visible = false;
            PreviewPanel.Visible = true;
        }

        protected void HandleButtonClicked(object sender, CommandEventArgs e)
        {
            var message = e.CommandName + Convert.ToInt32(e.CommandArgument);
            var eventArg = new ProductCardEventArg { Data = message };

            if (ItemCommandHandler != null)
                ItemCommandHandler.Invoke(this, eventArg);
            else DebugLabel.Text = "Item Handler was NULL!!";
        }
    }
}
