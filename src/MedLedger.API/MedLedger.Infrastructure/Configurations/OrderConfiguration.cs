using MedLedger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedLedger.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Quantity)
                .IsRequired();

            builder.Property(o => o.TotalPrice)
                .HasPrecision(10,2);

            builder.Property(o => o.OrderDate)
                .IsRequired();

            builder.HasIndex(o => o.OrderDate);

            builder.HasOne(o => o.Medicine)
                .WithMany(m => m.Orders)
                .HasForeignKey( o => o.MedicineId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Pharmacy)
                .WithMany(m => m.Orders)
                .HasForeignKey(o => o.PharmacyId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
