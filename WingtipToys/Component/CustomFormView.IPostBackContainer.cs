using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WingtipToys.CustomControl
{
    public partial class CustomFormView : IPostBackContainer
    {
        public PostBackOptions GetPostBackOptions(IButtonControl buttonControl)
        {
            throw new NotImplementedException();
        }
    }
}
