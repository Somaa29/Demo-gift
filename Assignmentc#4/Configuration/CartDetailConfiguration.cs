using Assignmentc_4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignmentc_4.Configuration
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.ToTable("CartDetails");
            //  builder.Property(p => p.Quantity).HasColumnType("int").IsRequired();
            //sét khóa ngoại
            builder.Property(c => c.Amount).IsRequired();
            builder.HasOne(p => p.Cart).WithMany(p => p.CartDetails)
              .HasForeignKey(p => p.IdUser);
            builder.HasOne(p => p.Product).WithMany(p => p.CartDetails)
              .HasForeignKey(p => p.IdProduct);
        }
    }
}
