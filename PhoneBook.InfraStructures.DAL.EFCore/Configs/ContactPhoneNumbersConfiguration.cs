using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Core.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.InfraStructures.DAL.EFCore.Configs
{
    public class ContactPhoneNumbersConfiguration : IEntityTypeConfiguration<ContactPhoneNumbers>
    {
        public void Configure(EntityTypeBuilder<ContactPhoneNumbers> builder)
        {
            builder.ToTable("Tbl_ContactPhoneNumbers");

            #region PropertyConfigs

            builder.Property(x => x.Id)
                   .HasColumnName("ID");

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(x => x.ContactId)
                .HasColumnName("LinkContactID");

            builder.Property(x => x.PhoneNumberTypeId)
                .HasColumnName("LinkPhoneNumberTypeID");

            #endregion

            #region RelationConfigs

            builder.HasOne(x => x.Contact)
                .WithMany(x => x.ContactPhoneNumbers)
                .HasForeignKey(x => x.ContactId);

            builder.HasOne(x => x.PhoneNymberType)
                .WithMany(x => x.ContactPhoneNumbers)
                .HasForeignKey(x => x.PhoneNumberTypeId);



            #endregion
        }
    }
}
