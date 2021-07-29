using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Day4.ShoppingList
{
    class ProductRepository : IDbRepository<Product>
    {
        static List<Product> products = new List<Product>();

        FoodProductRepository fpr = new FoodProductRepository();
        ClothingProductRepository cpr = new ClothingProductRepository();
        ElectronicsProductRepository epr = new ElectronicsProductRepository();

        List<Product> cart = new List<Product>();
        public List<Product> Fetch()
        {
            List<FoodProduct> foodProducts = fpr.FetchStaticList();
            List<ClothingProduct> clothingProducts = cpr.FetchStaticList();
            List<ElectronicsProduct> electronicsProducts = epr.FetchStaticList();


            products.AddRange(foodProducts);
            products.AddRange(clothingProducts);
            products.AddRange(electronicsProducts);

            return products;

        }


        public List<Product> FetchStaticList()
        {
            return products;
        }

        internal int AddProductToCart(string cod)
        {
            var p = products.Where(t => t.Code == cod);

            if (p.Count() > 0)
            {
                foreach (var x in p)
                {
                    cart.Add(x);
                }
                return 0;
            }
            else return -1;

        }

        public List<Product> FetchCart()
        {

            return cart;

        }

        internal decimal TotalCart(List<Product> p)
        {
          
            var total = cart.Count(t=> t.Price > 0);
            return total;
        }
    }
}
