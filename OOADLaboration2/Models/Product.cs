using System;
namespace OOADLaboration2.Models
{
    public class Product
    {

        public Product(string Name, string Type)
        {
            this.Name = Name;
            this.Type = Type;
        }

        public string Name { get; set; }
        public string Type { get; set; }
    }
}
