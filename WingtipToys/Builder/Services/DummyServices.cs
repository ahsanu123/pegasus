namespace WingtipToys.Builder.Services
{

    public interface IDummyServices
    {
         string GetData { get; }
    }

    public class DummyServices : IDummyServices
    {
        public string GetData
        {
            get
            {
                return "Dummy Data";
            }
        }
    }
}
