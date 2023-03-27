using Assignmentc_4.IServices;
using Assignmentc_4.Models;

namespace Assignmentc_4.Services
{
    public class CartDetailServices : ICartDetailServices
    {
        AsmDbContext _dbContext;
        public CartDetailServices()
        {
            _dbContext = new AsmDbContext();
        }

        public bool CreateCartDetail(CartDetail p)
        {
            try
            {
                _dbContext.CartDetails.Add(p);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCartDetail(Guid id)
        {
            try
            {
                dynamic cartdetail = _dbContext.CartDetails.Find(id);
                _dbContext.CartDetails.Remove(cartdetail);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<CartDetail> GetAllCartDetails()
        {
            return _dbContext.CartDetails.ToList();
        }

        public CartDetail GetCartDetailById(Guid id)
        {
            return _dbContext.CartDetails.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateCartDetail(CartDetail p)
        {
            try
            {
                var cartDetails = _dbContext.CartDetails.Find(p.Id);
                cartDetails.Quantity = p.Quantity;
                _dbContext.Update(cartDetails);
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
