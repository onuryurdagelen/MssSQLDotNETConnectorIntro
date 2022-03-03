using System;
using System.Collections.Generic;
using System.Text;
using static MssSQLDotNETConnectorIntro.Program;

namespace MssSQLDotNETConnectorIntro
{
    public class ProductManager : IProductDal
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Create(Product p)
        {
            return _productDal.Create(p);
        }

        public void Delete(int id)
        {
            _productDal.Delete(id);
        }

        public List<Product> GetAllProducts()
        {
            return _productDal.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return _productDal.GetProductById(id);
        }

        public void Update(int id, Product p)
        {
            throw new NotImplementedException();
        }
    }
}
