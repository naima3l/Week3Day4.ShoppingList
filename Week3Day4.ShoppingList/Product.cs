using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Day4.ShoppingList
{
    class Product
    {
        public string Code { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public Product(string code, decimal price, string descr)
        {
            Code = code;
            Price = price;
            Description = descr;
        }

        public virtual string Print()
        {
            return $"Codice: {Code}, Prezzo: {Price}, Descrizione: {Description}";
        }
    }
}
