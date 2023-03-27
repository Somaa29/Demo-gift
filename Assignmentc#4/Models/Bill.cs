namespace Assignmentc_4.Models
{
    public class Bill
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UserId { get; set; }
        public int Status { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
        public virtual User User { get; set; }
    }
}
