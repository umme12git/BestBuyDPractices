using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyDPractices
{
    public class ProductRepository : IProductRepository
    {
        private IDbConnection _connection;
        public ProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Product>  GetAllProducts()
        {
            return _connection.Query<Product>("Select * from Products");
        }

        public void CreateProduct(string newName, double newPrice, int newCategoryID)
        {
            _connection.Execute("Insert into  Products  (Name, Price, CategoryID) Values(@ProductName, @ProductPrice, @ProductCategoryID);",
                new { ProductName = newName, ProductPrice = newPrice,ProductCategoryID = newCategoryID });
                                
        }

    }
}
