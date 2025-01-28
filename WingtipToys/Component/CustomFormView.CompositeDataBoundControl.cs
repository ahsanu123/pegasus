using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WingtipToys.CustomControl
{
    public partial class CustomFormView : CompositeDataBoundControl
    {
        protected override int CreateChildControls(IEnumerable dataSource, bool dataBinding)
        {
            throw new NotImplementedException();
        }
    }
}
