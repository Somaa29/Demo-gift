using Assignmentc_4.Models;

namespace Assignmentc_4.IServices
{
    public interface IBillDetailServices
    {
        public bool CreateBillDetails(BillDetail p);
        public bool UpdateBillDetails(BillDetail p);
        public bool DeleteBillDetails(Guid id);
        public List<BillDetail> GetAllBillDetails();
        public BillDetail GetBillDetailsById(Guid id);
    }
}
