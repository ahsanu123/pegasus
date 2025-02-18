using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.ApplicationState;
using WingtipToys.Models;

namespace WingtipToys.CustomControl
{
    public static class ProductCardItemCommandArgs
    {
        public const string Save = "Save";
        public const string Edit = "Edit";
        public const string Cancel = "Cancel";
        public const string Delete = "Delete";
    }

    public partial class ProductCard : UserControl
    {
        public event CommandEventHandler ItemCommandHandler;
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
            int.TryParse(e.CommandArgument.ToString(), out int commandArgument);

            var pageState = new ProductPageState();
            pageState = PageState.GetState<ProductPageState>(nameof(ProductPageState));

            switch (e.CommandName)
            {
                case ProductCardItemCommandArgs.Save:

                    break;
                case ProductCardItemCommandArgs.Edit:
                    pageState.EditModeIndex = commandArgument;
                    PageState.SetState(pageState);

                    break;
                case ProductCardItemCommandArgs.Cancel:
                    pageState.EditModeIndex = null;
                    PageState.SetState(pageState);

                    break;
                case ProductCardItemCommandArgs.Delete:

                    break;
                default:

                    break;
            }
        }
    }
}
