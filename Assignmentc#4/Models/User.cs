using System.Data;

namespace Assignmentc_4.Models
{
    public class User
    {
        public Guid Id { get; set; }  
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public int Status { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
