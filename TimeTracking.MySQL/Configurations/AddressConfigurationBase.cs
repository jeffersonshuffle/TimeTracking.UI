using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTracking.DataModels;
using TimeTracking.DataModels.Organisation;

namespace TimeTracking.DAL.Configurations
{
    public abstract class AddressConfigurationBase : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Street).IsRequired(true).HasMaxLength(250);
            builder.Property(x => x.City).IsRequired(true).HasMaxLength(100);
            builder.Property(x => x.Appartment).IsRequired(true);
            builder.Property(x => x.House).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.Country).IsRequired(true).HasMaxLength(100);
            builder.Property(x => x.Region).IsRequired(false).HasMaxLength(250);
            builder.Property(x => x.PostalCode).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.Phone).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.Fax).IsRequired(false).HasMaxLength(100);
            ConfigureDatabase(builder);
        }
        protected abstract void ConfigureDatabase(EntityTypeBuilder<Address> builder);

        protected abstract string PrimaryKeyName { get; }
    }
}
