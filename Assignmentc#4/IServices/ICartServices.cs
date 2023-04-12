using Assignmentc_4.Models;

namespace Assignmentc_4.IServices
{
    public interface ICartServices
    {
        public bool CreateCart(Cart p);
        public bool UpdateCart(Cart p);
        public bool DeleteCart(Guid id);
        public List<Cart> GetAllCarts();
        public Cart GetCartById(Guid id);
        public List<Cart> GetCartByName(string name);
    }
}
