namespace WingtipToys.Routes
{
    public class RouteSpec
    {
        public RouteSpec(string name, string url, string physicalPath)
        {
            Name = name;
            Url = url;
            PhysicalPath = physicalPath;
        }

        public string Name { get; set; }
        public string Url { get; set; }
        public string PhysicalPath { get; set; }
    }
}
