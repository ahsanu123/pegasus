using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WingtipToys.CustomControl
{
    public class CustomDataItemContainer : IDataItemContainer
    {
        public object DataItem => throw new System.NotImplementedException();

        public int DataItemIndex => throw new System.NotImplementedException();

        public int DisplayIndex => throw new System.NotImplementedException();
    }
}
