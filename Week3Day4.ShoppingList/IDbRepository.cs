using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Day4.ShoppingList
{
    interface IDbRepository<T>
    {
        public List<T> Fetch();
        public List<T> FetchStaticList();
    }
}
