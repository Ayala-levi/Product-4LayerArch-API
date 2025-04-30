using Microsoft.EntityFrameworkCore;
using Solid.Core.Repositories;
using Solid.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webShop.Entities;

namespace Solid.Data.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private ShopDBContext _Context;
        public ProductRepository(ShopDBContext context)
        {
            _Context = context;
        }

        public List<Product> Get()
        {
            return _Context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _Context.Products.FirstOrDefault(p => p.Id == id);
        }

        public Product Add(Product product)
        {
            _Context.Products.Add(product);
            _Context.SaveChanges();
            return product;
        }
        public Product Update(int id, Product product)
        {
            Product p = _Context.Products.FirstOrDefault(p => p.Id == id);

            p.Name = product.Name;
            p.Description = product.Description;
            p.Price = product.Price;
            p.StockQuantity = product.StockQuantity;

            _Context.SaveChanges();
            return p;
        }
        public Product Delete(int id)
        {
            Product p = _Context.Products.FirstOrDefault(u => u.Id == id);
            _Context.Products.Remove(p);
            _Context.SaveChanges();
            return p;
        }

    }
}
