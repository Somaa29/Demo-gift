using Assignmentc_4.IServices;
using Assignmentc_4.Models;

namespace Assignmentc_4.Services
{
    public class ProductServices : IProductServices
    {
        AsmDbContext _dbContext;
        public ProductServices()
        {
            _dbContext = new AsmDbContext();
        }
        public bool CreateProduct(Product p)
        {

            try
            {
                _dbContext.Products.Add(p);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProduct(Guid id)
        {
            try
            {//find chỉ dùng đc khi id là khóa chính
                var product = _dbContext.Products.Find(id);
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProductById(Guid id)
        {
            return _dbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetProductByName(string name)
        {
            return _dbContext.Products.Where(p => p.Name.Contains(name)).ToList();
        }

        public bool UpdateProduct(Product p)
        {
            try
            {
                var product = _dbContext.Products.Find(p.Id);
                product.Name = p.Name;
                product.SoLuongTon = p.SoLuongTon;
                product.ImgUrl = p.ImgUrl;
                product.Price = p.Price;
                product.Status = p.Status;
                _dbContext.Products.Update(product);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
