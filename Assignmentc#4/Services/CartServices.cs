using Assignmentc_4.IServices;
using Assignmentc_4.Models;

namespace Assignmentc_4.Services
{
    public class CartServices : ICartServices
    {
        AsmDbContext _dbContext;
        public CartServices()
        {
            _dbContext = new AsmDbContext();
        }
        public bool CreateCart(Cart p)
        {
            try
            {
                _dbContext.Carts.Add(p);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCart(Guid id)
        {
            try
            {
                dynamic cart = _dbContext.Carts.Find(id);
                _dbContext.Carts.Remove(cart);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        } 

        public List<Cart> GetAllCarts()
        {
            return _dbContext.Carts.ToList();
        }

        public Cart GetCartById(Guid id)
        {
            return _dbContext.Carts.FirstOrDefault(p => p.UserId == id);
        }
        public List<Cart> GetCartByName(string name)
        {
            //return Context.Product.Where(p => p.Name.Contains(name)).ToList();
            throw new NotImplementedException();
        }

        public bool UpdateCart(Cart p)
        {
            try
            {
                var cart = _dbContext.Carts.Find(p.UserId);
                cart.Description = p.Description;
                _dbContext.Update(cart);
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
