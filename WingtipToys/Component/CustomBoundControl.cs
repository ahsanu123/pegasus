using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WingtipToys.CustomControl
{
    public class CustomBoundControl : Control, IDataBoundItemControl
    {
        public DataKey DataKey => throw new NotImplementedException();

        public DataBoundControlMode Mode => throw new NotImplementedException();

        public string DataSourceID
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public IDataSource DataSourceObject => throw new NotImplementedException();

        public object DataSource
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        public string[] DataKeyNames
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        public string DataMember
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}
