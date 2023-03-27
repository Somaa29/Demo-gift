using Assignmentc_4.Models;

namespace Assignmentc_4.IServices
{
    public interface IBillServices
    {
        public bool CreateBill(Bill p);
        public bool UpdateBill(Bill p);
        public bool DeleteBill(Guid id);
        public List<Bill> GetAllBills();
        public Bill GetBillById(Guid id);
    }
}
