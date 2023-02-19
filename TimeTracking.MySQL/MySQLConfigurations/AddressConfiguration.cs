using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTracking.DataModels.Organisation;

namespace TimeTracking.DAL.Configurations;
internal class AddressConfiguration : AddressConfigurationBase
    {
        protected override void ConfigureDatabase(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("address", "time_tracking");
            builder.Property(x => x.Street).HasColumnName("street");
            builder.Property(x => x.PostalCode).HasColumnName("postal_code");
            builder.Property(x => x.Appartment).HasColumnName("appartment");
            builder.Property(x => x.City).HasColumnName("city");
            builder.Property(x => x.Country).HasColumnName("country");
            builder.Property(x => x.Email).HasColumnName("email");
            builder.Property(x => x.Fax).HasColumnName("fax");
            builder.Property(x => x.House).HasColumnName("house");
        }

        protected override string PrimaryKeyName => "idx_pk_address";
    }

