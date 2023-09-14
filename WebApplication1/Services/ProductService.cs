using Data;
using Entities.Entities;
using WebApplication1.IServices;

namespace WebApplication1.Services
{
    public class ProductService : BaseContextService, IProductService
    {
        public ProductService(ServiceContext serviceContext) : base(serviceContext) 
        {
        }

        public int InsertProduct(ProductItem productItem)
        {
            _serviceContext.Products.Add(productItem);
            _serviceContext.SaveChanges();
            return productItem.CourseId;
        }

        public void DeleteProduct(int id)
        {

            var productToDelete = _serviceContext.Set<ProductItem>()
                 .Where(u => u.CourseId == id).First();

            _serviceContext.SaveChanges();

        }

        public List<ProductItem> GetAllProducts()
        {
            return _serviceContext.Set<ProductItem>()
                .ToList();

        }

        public List<ProductItem> GetProductById(int id)
        {
            var resultList = _serviceContext.Set<ProductItem>()

                                .Where(u => u.CourseId == id);


            return resultList.ToList();
        }
        public void UpdateProduct(ProductItem productItem)
        {
            _serviceContext.Products.Update(productItem);
            _serviceContext.SaveChanges();
        }
    }
}
