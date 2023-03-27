using Assignmentc_4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignmentc_4.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("SanPham");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(p => p.Price).IsRequired().HasColumnType("int");
            builder.Property(p => p.SoLuongTon).IsRequired().HasColumnType("int");
            builder.Property(p => p.Status).IsRequired().HasColumnType("int");
        }
    }
}
