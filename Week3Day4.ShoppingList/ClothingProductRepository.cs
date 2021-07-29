using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Day4.ShoppingList
{
    class ClothingProductRepository : IDbRepository<ClothingProduct>
    {
        static List<ClothingProduct> clothingProducts = new List<ClothingProduct>
        {
            new ClothingProduct("C01",23,"maglietta rossa",EnumSize.S,EnumBrand.Armani),
            new ClothingProduct("C02",11,"cintura",EnumSize.S,EnumBrand.Mango),
            new ClothingProduct("C03",76,"impermeabile dorato",EnumSize.S,EnumBrand.Versace),
            new ClothingProduct("C04",12,"pantaloncini",EnumSize.S,EnumBrand.Armani),
            new ClothingProduct("C05",49,"borsetta sanpshot",EnumSize.S,EnumBrand.MarcJacobs)
        };
        public List<ClothingProduct> Fetch()
        {
            return clothingProducts;
        }

        public List<ClothingProduct> FetchStaticList()
        {
            return clothingProducts;
        }

        internal List<ClothingProduct> ShowClothingProductByPrice(decimal price)
        {
            var cl = clothingProducts.Where(t => t.Price <= price);
            List<ClothingProduct> c = new List<ClothingProduct>();

            if (cl.Count() > 0)
            {
                foreach (var x in cl)
                {
                    c.Add(x);
                }
            }

            return c;
        }

        internal List<ClothingProduct> ShowClothingBySize(EnumSize s)
        {
            var cl = clothingProducts.Where(t => t.Size == s);
            List<ClothingProduct> c = new List<ClothingProduct>();

            if (cl.Count() > 0)
            {
                foreach (var x in cl)
                {
                    c.Add(x);
                }
            }

            return c;
        }
    }
}
