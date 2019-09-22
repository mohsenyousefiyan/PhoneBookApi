using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Core.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.InfraStructures.DAL.EFCore.Configs
{
    public class ContactGroupConfiguration : IEntityTypeConfiguration<ContactGroup>
    {
        public void Configure(EntityTypeBuilder<ContactGroup> builder)
        {
            builder.ToTable("Tbl_ContactGroup");

            #region PropertyConfigs

            builder.Property(x => x.Id)
                 .HasColumnName("ID");

            builder.Property(x => x.ContactId)
                .HasColumnName("LinkContactID");

            builder.Property(x => x.GroupId)
                .HasColumnName("LinkGroupID");

            #endregion

            #region RelationConfigs

            builder.HasOne(x => x.Contact)
                .WithMany(x=>x.ContactGroups)
                .HasForeignKey(x=>x.ContactId);

            builder.HasOne(x => x.Group)
                .WithMany(x => x.ContactGroups)
                .HasForeignKey(x => x.GroupId);


            #endregion
        }
    }
}
