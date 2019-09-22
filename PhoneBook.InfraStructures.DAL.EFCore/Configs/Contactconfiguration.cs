using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Core.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.InfraStructures.DAL.EFCore.Configs
{
    public class Contactconfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Tbl_Contacts");

            #region PropertyConfigs

            builder.Property(x => x.Id)
                 .HasColumnName("ID");

            builder.Property(x => x.FirstName)
                .HasMaxLength(30)
                .IsRequired()
                .IsUnicode();

            builder.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode();

            builder.Property(x => x.EmailAddress)
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(x => x.WebSite)
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(x => x.CompanyName)
                .HasMaxLength(50)
                .IsUnicode();

            #endregion
            
        }
    }
}
