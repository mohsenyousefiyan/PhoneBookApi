using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Core.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.InfraStructures.DAL.EFCore.Configs
{
    public class PhoneNymberTypeConfiguration : IEntityTypeConfiguration<PhoneNymberType>
    {
        public void Configure(EntityTypeBuilder<PhoneNymberType> builder)
        {
            builder.ToTable("Tbl_PhoneNymberType");

            #region PropertyConfigs

            builder.Property(x => x.Id)
                    .HasColumnName("ID");

            builder.Property(x => x.PhoneNymberTypeName)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode();

            #endregion

            #region SeedData

            builder.HasData(new PhoneNymberType() { Id = 1, PhoneNymberTypeName = "Mobile" },
                new PhoneNymberType() { Id = 2, PhoneNymberTypeName = "Work" },
                new PhoneNymberType() { Id = 3, PhoneNymberTypeName = "Home" },
                new PhoneNymberType() { Id = 4, PhoneNymberTypeName = "Fax" },
                new PhoneNymberType() { Id = 5, PhoneNymberTypeName = "Other" });

            #endregion
        }
    }
}
