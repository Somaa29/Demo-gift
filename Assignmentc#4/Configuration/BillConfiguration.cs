using Assignmentc_4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignmentc_4.Configuration
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("HoaDon"); // Đặt tên bảng
            builder.HasKey(p => new { p.Id });// Thiết lập khóa chính
            // Thiết lập cho các thuộc tính
            builder.Property(p => p.Status).HasColumnType("int").
                IsRequired(); // int not null
            builder.HasOne(p => p.User).WithMany(p => p.Bills).HasForeignKey(p => p.UserId);
        }
    }
}
