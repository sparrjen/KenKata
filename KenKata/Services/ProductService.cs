using KenKata.Data;
using KenKata.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KenKata.Services
{
    public class ProductService : IProductService
    {
        private readonly SqlDbProductsContext _sqlDbProductsContext;

        public ProductService(SqlDbProductsContext sqlDbProductsContext)
        {
            _sqlDbProductsContext = sqlDbProductsContext;
        }

        public IEnumerable<Product> Products => _sqlDbProductsContext.Products.Include(c => c.Category);

        public Product GetProductById(int productId)
        {
            return _sqlDbProductsContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }
    }
}
