using Assignmentc_4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignmentc_4.Configuration
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("GioHang");//đặt tên bảng sql
            builder.HasKey(p => p.UserId);
            builder.Property(p => p.Description).HasColumnType("nvarchar(100)");
        }
    }
}
