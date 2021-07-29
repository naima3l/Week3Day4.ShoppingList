using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Day4.ShoppingList
{
    class ElectronicsProductRepository : IDbRepository<ElectronicsProduct>
    {
        static List<ElectronicsProduct> electronicsProducts = new List<ElectronicsProduct>
        {
            new ElectronicsProduct("E01",23,"smartphone",EnumBrandE.Samsung,EnumTemplate.s20),
            new ElectronicsProduct("E02",11,"lavastoviglie",EnumBrandE.Bosch,EnumTemplate.New),
            new ElectronicsProduct("E03",76,"piastra per capelli",EnumBrandE.Dyson,EnumTemplate.xx2),
            new ElectronicsProduct("E04",12,"piastra panini",EnumBrandE.Phillips,EnumTemplate.New),
            new ElectronicsProduct("E05",49,"smartphone",EnumBrandE.Motorola,EnumTemplate.xx1)
        };


        public List<ElectronicsProduct> Fetch()
        {
            return electronicsProducts;
        }

        public List<ElectronicsProduct> FetchStaticList()
        {
            return electronicsProducts;
        }

        internal List<ElectronicsProduct> ShowElectronicsProductByPrice(decimal price)
        {
            var el = electronicsProducts.Where(t => t.Price <= price);
            List<ElectronicsProduct> e = new List<ElectronicsProduct>();

            if (el.Count() > 0)
            {
                foreach (var x in el)
                {
                    e.Add(x);
                }
            }

            return e;
        }

        internal List<ElectronicsProduct> ShowElectronicsByBrand(EnumBrandE b)
        {
            var el = electronicsProducts.Where(t => t.Brand == b);
            List<ElectronicsProduct> e = new List<ElectronicsProduct>();

            if (el.Count() > 0)
            {
                foreach (var x in el)
                {
                    e.Add(x);
                }
            }

            return e;
        }
    }
}
