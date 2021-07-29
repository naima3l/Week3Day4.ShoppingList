using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Day4.ShoppingList
{
    class FoodProduct : Product
    {
        public DateTime ExpirationDate { get; set; }

        public FoodProduct(string code, decimal price, string descr, DateTime expiration):
            base(code, price, descr)
        {
            ExpirationDate = expiration;
        }

        public override string Print()
        {
            return $"Prodotto Alimentare -> {base.Print()}, Scedenza: {ExpirationDate}";
        }
    }
}
