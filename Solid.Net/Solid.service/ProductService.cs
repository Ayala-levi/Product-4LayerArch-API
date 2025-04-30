using Solid.Core.Repositories;
using Solid.Core.Services;
using Solid.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.service
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public List<Product> GetAll()
        {
            return _productRepository.Get();
        }
        public Product Get(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public Product AddProduct(Product product)
        {
            // אם קיים המוצר לפי השם לטפל לוגיקה
            return _productRepository.Add(product);
        }
        public Product UpdateProduct(int id, Product product)
        {
            return _productRepository.Update(id, product);
        }
        public Product DeleteProduct(int id)
        {
            return _productRepository.Delete(id);
        }
    }
}
