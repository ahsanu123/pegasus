using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;

namespace WingtipToys.CustomControl
{
    public enum ProductCardEventType
    {
        Save,
        Edit,
        Cancel,
        Delete,
    }

    public class TwoWayProductCardEventArg : EventArgs
    {
        public int Id { get; set; }
        public ProductCardEventType EventType { get; set; }
    }

    public partial class TwoWayProductCard : System.Web.UI.UserControl
    {
        private Product _product;
        public bool IsEditMode;
        public event EventHandler<TwoWayProductCardEventArg> ProductCardEvent;

        [Bindable(true)]
        public Product Product
        {
            get
            {
                _product.Name = NameInput.Value;
                _product.Description = DescriptionInput.Value;
                _product.Type = TypeInput.Value;
                _product.ImageUrl = ImageUrlInput.Value;
                _product.UnitPrice = double.Parse(UnitPriceInput.Value);
                return _product;
            }
            set
            {
                if (value != null)
                {
                    _product = value;
                    LabelName.Text = value.Name;
                    LabelDescription.Text = value.Description;
                    LabelType.Text = value.Type;
                    LabelImageUrl.Text = value.ImageUrl;
                    LabelUnitPrice.Text = value.UnitPrice.ToString();

                    NameInput.Value = value.Name;
                    DescriptionInput.Value = value.Description;
                    TypeInput.Value = value.Type;
                    ImageUrlInput.Value = value.ImageUrl;
                    UnitPriceInput.Value = value.UnitPrice.ToString();
                }
            }
        }

        private void _setMode(bool editMode)
        {
            IsEditMode = editMode;

            ButtonCancel.Visible = IsEditMode;
            ButtonSave.Visible = IsEditMode;
            ButtonEdit.Visible = !IsEditMode;

            previewPanel.Visible = !IsEditMode;
            editPanel.Visible = IsEditMode;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // if (!IsPostBack)
            //     _setMode(false);
        }

        protected void HandleOnSave(object sender, EventArgs e)
        {
            //_setMode(false);
            var args = new TwoWayProductCardEventArg
            {
                Id = Product.Id,
                EventType = ProductCardEventType.Save,
            };
            ProductCardEvent.Invoke(this, args);
        }

        protected void HandleOnEdit(object sender, EventArgs e)
        {
            //_setMode(true);
            var args = new TwoWayProductCardEventArg
            {
                Id = Product.Id,
                EventType = ProductCardEventType.Edit,
            };
            ProductCardEvent.Invoke(this, args);
        }

        protected void HandleOnCancel(object sender, EventArgs e)
        {
            //_setMode(false);
            var args = new TwoWayProductCardEventArg
            {
                Id = Product.Id,
                EventType = ProductCardEventType.Cancel,
            };
            ProductCardEvent.Invoke(this, args);
        }
    }
}
