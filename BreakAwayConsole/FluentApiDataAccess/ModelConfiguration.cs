using FluentApiModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApiDataAccess
{
    public class DestinationCofiguration : EntityTypeConfiguration<Destination>
    {
        public DestinationCofiguration()
        {
            Property(d => d.Name).IsRequired();
            Property(d => d.Description).HasMaxLength(500);
            Property(d => d.Photo).HasColumnType("image");
            HasMany(d => d.Lodgings).WithRequired(l => l.Destination).WillCascadeOnDelete(true);
        }
    }

    public class LodgingConfiguration : EntityTypeConfiguration<Lodging>
    {
        public LodgingConfiguration()
        {
            Property(l => l.Name).IsRequired().HasMaxLength(200);
            HasOptional(l => l.PrimaryContact).WithMany(p => p.PrimaryContactFor);
            HasOptional(l => l.SecondaryContact).WithMany(p => p.SecondaryContactFor);
        }
    }

    public class TripConfiguration : EntityTypeConfiguration<Trip>
    {
        public TripConfiguration()
        {
            HasKey(t => t.Identifier);
            Property(t => t.Identifier).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.RowVersion).IsRowVersion();
        }
    }

    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            HasKey(p => p.SocialSecurityNumber);
            Property(p => p.SocialSecurityNumber).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.RowVersion).IsRowVersion();
            Property(p => p.SocialSecurityNumber).IsConcurrencyToken();
        }
    }

    public class InternetSpecialConfiguration : EntityTypeConfiguration<InternetSpecial>
    {
        public InternetSpecialConfiguration()
        {
            HasRequired(i => i.Accommodation).WithMany(l => l.InternetSpecials).HasForeignKey(i => i.AccommodationId);
        }
    }
}
