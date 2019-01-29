using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Domain.Entities;

namespace Northwind.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("RoomID")
                .HasMaxLength(5)
                .ValueGeneratedNever();

            builder.Property(e => e.Size)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(e => e.ClientName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.RentedCalendar).IsRequired();

            builder.Property(e => e.ClientPhone).HasMaxLength(24);

            builder.Property(e => e.ClientMail)
                .IsRequired()
                .HasMaxLength(254);
        }
    }
}
