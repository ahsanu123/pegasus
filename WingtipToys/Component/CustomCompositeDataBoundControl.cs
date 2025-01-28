using System.Collections;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WingtipToys.CustomControl
{
    public class CustomCompositeDataBoundControl : CompositeDataBoundControl
    {
        protected override int CreateChildControls(IEnumerable dataSource, bool dataBinding)
        {
            throw new System.NotImplementedException();
        }
    }
}
