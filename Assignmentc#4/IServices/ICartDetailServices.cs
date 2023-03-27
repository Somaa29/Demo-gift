using Assignmentc_4.Models;

namespace Assignmentc_4.IServices
{
    public interface ICartDetailServices
    {
        public bool CreateCartDetail(CartDetail p);
        public bool UpdateCartDetail(CartDetail p);
        public bool DeleteCartDetail(Guid id);
        public List<CartDetail> GetAllCartDetails();
        public CartDetail GetCartDetailById(Guid id);
    }
}
