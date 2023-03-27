namespace Assignmentc_4.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int SoLuongTon { get; set; }
        public string ImgUrl { get; set; }
        public int Status { get; set; }
        public virtual ICollection<BillDetail> Details { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}
