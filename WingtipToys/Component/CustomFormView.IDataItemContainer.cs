using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WingtipToys.CustomControl
{
    public partial class CustomFormView : IDataItemContainer
    {
        public object DataItem => throw new NotImplementedException();

        public int DataItemIndex => throw new NotImplementedException();

        public int DisplayIndex => throw new NotImplementedException();
    }
}
