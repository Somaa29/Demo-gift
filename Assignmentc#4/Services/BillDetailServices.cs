using Assignmentc_4.IServices;
using Assignmentc_4.Models;

namespace Assignmentc_4.Services
{
    public class BillDetailServices : IBillDetailServices
    {
        AsmDbContext _dbContext;
        public BillDetailServices()
        {
            _dbContext = new AsmDbContext();
        }
        public bool CreateBillDetails(BillDetail p)
        {
            try
            {
                _dbContext.BillDetails.Add(p);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteBillDetails(Guid id)
        {
            try
            {
                dynamic billdetail = _dbContext.BillDetails.Find(id);
                _dbContext.BillDetails.Remove(billdetail);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<BillDetail> GetAllBillDetails()
        {
            return _dbContext.BillDetails.ToList();
        }

        public BillDetail GetBillDetailsById(Guid id)
        {
            return _dbContext.BillDetails.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateBillDetails(BillDetail p)
        {
            try
            {
                dynamic billdetail = _dbContext.BillDetails.Find(p.Id);
                billdetail.Quanity = p.Quantity;
                billdetail.Price = p.Price;
                _dbContext.BillDetails.Update(billdetail);
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
