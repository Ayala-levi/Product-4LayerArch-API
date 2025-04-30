using Solid.Core.Repositories;
using Solid.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Services
{
    public interface IProductService
    {
        public List<Product> GetAll();
        public Product Get(int id);
        public Product AddProduct(Product product);
        public Product UpdateProduct(int id, Product product);
        public Product DeleteProduct(int id);
    }
}
