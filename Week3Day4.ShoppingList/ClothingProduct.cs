using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Day4.ShoppingList
{
    class ClothingProduct : Product
    {
        public EnumSize Size { get; set; }
        public EnumBrand Brand { get; set; }

        public ClothingProduct(string code, decimal price, string descr, EnumSize size, EnumBrand brand) :
            base(code, price, descr)
        {
            Size = size;
            Brand = brand;
        }

        public override string Print()
        {
            return $"Prodotto di abbigliamento -> {base.Print()}, Taglia: {Size}, Brand: {Brand}";
        }
    }
    enum EnumSize
    {
        XS,
        S,
        M,
        L,
        XL,
        XXL,
        XXXL
    }

    enum EnumBrand
    {
        Armani,
        Guess,
        LuJo,
        Zara,
        MarcJacobs,
        Versace,
        Mango
    }
}
