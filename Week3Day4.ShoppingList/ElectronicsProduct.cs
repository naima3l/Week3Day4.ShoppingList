using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Day4.ShoppingList
{
    class ElectronicsProduct : Product
    {
        public EnumBrandE Brand { get; set; }
        public EnumTemplate Template { get; set; }

        public ElectronicsProduct(string code, decimal price, string descr, EnumBrandE brand, EnumTemplate template) :
            base(code, price, descr)
        {
            Brand = brand;
            Template = template;
        }

        public override string Print()
        {
            return $"Prodotto di elettronica -> {base.Print()}, Brand: {Brand}, Modello: {Template}";
        }
    }
    enum EnumBrandE
    {
        Samsung,
        Phillips,
        Motorola,
        Dyson,
        Bosch
    }

    enum EnumTemplate
    {
        New,
        Old,
        s20,
        xx1,
        xx2
    }
}
