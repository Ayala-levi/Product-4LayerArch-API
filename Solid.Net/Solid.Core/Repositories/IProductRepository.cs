using Solid.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Repositories
{
    public interface IProductRepository
    {
        public List<Product> Get();
        public Product GetProductById(int id);
        public Product Add(Product product);
        public Product Update(int id, Product product);
        public Product Delete(int id);

    }
}
