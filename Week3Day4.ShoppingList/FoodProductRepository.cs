using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Day4.ShoppingList
{
    class FoodProductRepository : IDbRepository<FoodProduct>
    {
        private static Random r = new Random();
        internal static DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(r.Next(range));
        }

        static List<FoodProduct> foodProducts = new List<FoodProduct>
        {
            new FoodProduct("F01",5,"salmone affumicato della Norvegia",RandomDay()),
            new FoodProduct("F02",1,"parmigiano reggiano",RandomDay()),
            new FoodProduct("F03",7,"pasta al forno",RandomDay()),
            new FoodProduct("F04",2,"insalata",RandomDay()),
            new FoodProduct("F05",4,"gelato",RandomDay())
        };

        public List<FoodProduct> Fetch()
        {
            return foodProducts;
        }

        public List<FoodProduct> FetchStaticList()
        {
            return foodProducts;
        }

        internal List<FoodProduct> ShowFoodProductByPrice(decimal price)
        {
            var food = foodProducts.Where(t => t.Price <= price);
            List<FoodProduct> f = new List<FoodProduct>();

            if (food.Count() > 0)
            {
                foreach (var x in food)
                {
                    f.Add(x);
                }
            }

            return f;
        }

        internal List<FoodProduct> ShowFoodProductsByExpiratiion(DateTime date)
        {
            var food = foodProducts.Where(t => t.ExpirationDate >= date);
            List<FoodProduct> f = new List<FoodProduct>();

            if (food.Count() > 0)
            {
                foreach (var x in food)
                {
                    f.Add(x);
                }
            }

            return f;
        }
    }
}
