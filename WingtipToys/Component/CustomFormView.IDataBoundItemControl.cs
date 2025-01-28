using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WingtipToys.CustomControl
{
    public partial class CustomFormView : IDataBoundItemControl
    {
        public DataKey DataKey => throw new NotImplementedException();

        public DataBoundControlMode Mode => throw new NotImplementedException();

        public string[] DataKeyNames
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}
