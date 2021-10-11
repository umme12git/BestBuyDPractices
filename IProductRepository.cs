using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyDPractices
{
    interface IProductRepository
    {
       
        public IEnumerable<Product> GetAllProducts();
        public void CreateProduct(string newName, double newPrice, int newCategoryID);

    }
}
