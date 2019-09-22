using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Entities.Entities;
using PhoneBook.InfraStructures.DAL.EFCore.Configs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.InfraStructures.DAL.EFCore.Context
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<PhoneNymberType> PhoneNymberTypes { get; set; }
        public DbSet<Group>Groups { get; set; }
        public DbSet<ContactGroup> ContactGroups { get; set; }
        public DbSet<ContactPhoneNumbers>ContactPhoneNumbers { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneNymberTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContactGroupConfiguration());
            modelBuilder.ApplyConfiguration(new Contactconfiguration());
            modelBuilder.ApplyConfiguration(new ContactPhoneNumbersConfiguration());
        }
    }
}
