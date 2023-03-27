using Assignmentc_4.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignmentc_4.Configuration
{
    public class BillDetailConfiguration : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<BillDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Quantity).IsRequired().
                HasColumnType("int");
            // Set khóa ngoại
            builder.HasOne(p => p.Bill).WithMany(p => p.BillDetails).
                HasForeignKey(p => p.IdHD).HasConstraintName("FK_HD");
            builder.HasOne(p => p.Product).WithMany(p => p.Details).
                HasForeignKey(p => p.IdSP).HasConstraintName("FK_SP");
        }
    }
}
