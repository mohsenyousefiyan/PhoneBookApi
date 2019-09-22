using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Core.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.InfraStructures.DAL.EFCore.Configs
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Tbl_GroupInfo");

            #region PropertyConfigs

            builder.Property(x => x.Id)
                   .HasColumnName("ID");

            builder.Property(x => x.GroupName)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode();

            #endregion

        }
    }
}
