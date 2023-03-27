using Assignmentc_4.IServices;
using Assignmentc_4.Models;

namespace Assignmentc_4.Services
{
    public class BillServices : IBillServices
    {
        AsmDbContext  _dbContext;

        public BillServices()
        {
            _dbContext = new AsmDbContext();
        }
        public bool CreateBill(Bill p)
        {
            try
            {
                _dbContext.Bills.Add(p); //add vào dbset
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteBill(Guid id)
        {
            try
            {
                dynamic bill = _dbContext.Bills.Find(id);
                _dbContext.Bills.Remove(bill);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Bill> GetAllBills()
        {
            return _dbContext.Bills.ToList();
        }

        public Bill GetBillById(Guid id)
        {
            return _dbContext.Bills.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateBill(Bill p)
        {
            try
            {
                dynamic bill = _dbContext.Bills.Find(p.Id);
                bill.DateTime = DateTime.Now;
                bill.Status = p.Status;
                _dbContext.Users.Update(bill);
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
