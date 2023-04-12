namespace Assignmentc_4.Models
{
    public class CartDetail 
    {
        public Guid Id { get; set; }
        public Guid? IdUser { get; set; }
        public Guid IdProduct { get; set; }
        public int Amount { get; set; }
        public virtual Product Product { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
