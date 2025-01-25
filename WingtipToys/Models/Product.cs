using System.ComponentModel.DataAnnotations;

namespace WingtipToys.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Description { get; set; }
        public double? UnitPrice { get; set; }
    }
}
