using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Contracts.Repository;
using PhoneBook.Core.Entities.Dtos.BaseDtos;
using PhoneBook.Core.Entities.Dtos.ContactDtos.InputDtos;
using PhoneBook.Core.Entities.Dtos.ContactDtos.OutPutDtos;
using PhoneBook.Core.Entities.Dtos.ContactPhoneNumbersDto.InputDtos;
using PhoneBook.Core.Entities.Dtos.ContactPhoneNumbersDto.OutPutDtos;
using PhoneBook.Core.Entities.Dtos.GroupDtos.OutPutDtos;
using PhoneBook.Core.Entities.Entities;
using PhoneBook.InfraStructures.DAL.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.InfraStructures.DAL.EFCore.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ContactRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<BaseResultCRUDDto<OutPut_ContactDto>> Addcontact(ContactAddDto addedmodel)
        {
            if ((addedmodel.ContactPhoneNumbers != null && addedmodel.ContactPhoneNumbers.Count > 0)==false)
                return new BaseResultCRUDDto<OutPut_ContactDto>() { ErrorMessage = "PhoneNumberList Is blank" };

            var AddedItem = new Contact()
            {
                FirstName = addedmodel.FirstName,
                LastName = addedmodel.LastName,
                EmailAddress = addedmodel.EmailAddress,
                Address = addedmodel.Address,
                CompanyName = addedmodel.CompanyName,
                WebSite = addedmodel.WebSite,
                BirthDate = addedmodel.BirthDate
            };

            using (var dbtran = await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    dbContext.Contacts.Add(AddedItem);

                    var phoneaddedmodel = addedmodel.ContactPhoneNumbers.
                        Select(x => new ContactPhoneNumbers()
                        {
                            ContactId = AddedItem.Id,
                            PhoneNumberTypeId = x.PhoneNumberTypeId,
                            PhoneNumber = x.PhoneNumber
                        })
                        .ToList();

                    dbContext.ContactPhoneNumbers.AddRange(phoneaddedmodel);
                    await dbContext.SaveChangesAsync();
                    dbtran.Commit();

                    return new BaseResultCRUDDto<OutPut_ContactDto>()
                    {
                        IsSuccess = true,
                        CRUDObject = new OutPut_ContactDto()
                        {
                            Id = AddedItem.Id,
                            FirstName = AddedItem.FirstName,
                            LastName = AddedItem.LastName,
                            EmailAddress = AddedItem.EmailAddress,
                            Address = AddedItem.Address,
                            CompanyName = AddedItem.CompanyName,
                            WebSite = AddedItem.WebSite,
                            BirthDate = AddedItem.BirthDate
                        }
                    };
                }
                catch (Exception ex)
                {
                    dbtran.Rollback();

                    return new BaseResultCRUDDto<OutPut_ContactDto>() { ErrorMessage = ex.Message };
                }
            }
        }

        public async Task<BaseResultCRUDDto<OutPut_ContactDto>> UpdateContact(ContactUpdateDto editmodel)
        {
            var EditItem = await dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == editmodel.Id);
            if (EditItem != null)
            {
                EditItem.FirstName = editmodel.FirstName;
                EditItem.LastName = editmodel.LastName;
                EditItem.WebSite = editmodel.WebSite;
                EditItem.Address = editmodel.Address;
                EditItem.BirthDate = editmodel.BirthDate;
                EditItem.CompanyName = editmodel.CompanyName;
                EditItem.EmailAddress = editmodel.EmailAddress;

                using (var dbtrn = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        dbContext.Update(EditItem);

                        var detaillist = await dbContext.ContactPhoneNumbers.Where(x => x.ContactId == editmodel.Id).ToListAsync();
                        dbContext.ContactPhoneNumbers.RemoveRange(detaillist);

                        var phoneaddedmodel = editmodel.ContactPhoneNumbers.
                       Select(x => new ContactPhoneNumbers()
                       {
                           ContactId = editmodel.Id,
                           PhoneNumberTypeId = x.PhoneNumberTypeId,
                           PhoneNumber = x.PhoneNumber
                       })
                       .ToList();

                        dbContext.ContactPhoneNumbers.AddRange(phoneaddedmodel);
                        await dbContext.SaveChangesAsync();
                        dbtrn.Commit();

                        return new BaseResultCRUDDto<OutPut_ContactDto>()
                        {
                            IsSuccess = true,
                            CRUDObject = await GetById(editmodel.Id)
                        };

                    }
                    catch (Exception ex)
                    {
                        dbtrn.Rollback();
                        return new BaseResultCRUDDto<OutPut_ContactDto>() { ErrorMessage = ex.Message };
                    }
                }
            }
            else
                return new BaseResultCRUDDto<OutPut_ContactDto>() { ErrorMessage = "مخاطبی با این آی دی وجود ندارد" };
        }

        public async Task<BaseOutPutDto> DeleteContact(int id)
        {
            
                var DeletedItem = await dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
                if (DeletedItem == null)
                    return new BaseOutPutDto() { ErrorMessage = "رکوردی با این آی دی یافت نشد" };

            using (var dbtran = await dbContext.Database.BeginTransactionAsync())
            {
                try
                {

                    var contactgroups = await dbContext.ContactGroups.Where(x => x.ContactId == id).ToListAsync();
                    dbContext.ContactGroups.RemoveRange(contactgroups);

                    var contactNumbers = await dbContext.ContactPhoneNumbers.Where(x => x.ContactId == id).ToListAsync();
                    dbContext.ContactPhoneNumbers.RemoveRange(contactNumbers);

                    dbContext.Contacts.Remove(DeletedItem);
                    await dbContext.SaveChangesAsync();

                    dbtran.Commit();

                    return new BaseOutPutDto() { IsSuccess = true };
                }
                catch (Exception ex)
                {
                    dbtran.Rollback();
                    return new BaseOutPutDto() { ErrorMessage = ex.Message };
                }
            }            
        }

        public async Task<BaseOutPutDto> DeletePhoneNumber(int id)
        {
            try
            {
                var DeletedItem = await dbContext.ContactPhoneNumbers.Where(x => x.Id == id).FirstOrDefaultAsync();
                dbContext.ContactPhoneNumbers.Remove(DeletedItem);
                await dbContext.SaveChangesAsync();
                return new BaseOutPutDto() { IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new BaseOutPutDto() { ErrorMessage = ex.Message };
            }
        }


        public async Task<OutPut_ContactDto> GetByContactFullName(string contactfullname)
        {
            var contactid = await dbContext.Contacts.Where(x => (x.FirstName+" "+x.LastName) == contactfullname)
                 .AsNoTracking()
                 .Select(x=>(int?)x.Id)
                 .FirstOrDefaultAsync();

            if (contactid.HasValue && contactid.Value > 0)
                return await GetById(contactid.Value);
            return null;
        }

        public async Task<OutPut_ContactDto> GetById(int id)
        {
            var contact = await dbContext.Contacts.Where(x => x.Id == id)
                .Select(x=>new OutPut_ContactDto()
                {
                    Id=x.Id,
                    FirstName=x.FirstName,
                    LastName=x.LastName,
                    BirthDate=x.BirthDate,
                    CompanyName=x.CompanyName,
                    WebSite=x.WebSite,
                    Address=x.Address,
                    EmailAddress=x.EmailAddress,
                    Groups=dbContext.ContactGroups.Include(y=>y.Group)
                    .Where(y=>y.ContactId==x.Id)
                    .Select(y=>new OutPut_GroupDto()
                    {
                        Id = y.Id,
                        GroupName = y.Group.GroupName
                    }).ToList(),
                    ContactPhoneNumbers= dbContext.ContactPhoneNumbers.Include(y => y.PhoneNymberType)
                    .Where(y => y.ContactId == x.Id)
                    .Select(y => new OutPut_ContactPhoneNumbersDto()
                    {
                        Id = y.Id,
                        PhoneNumberTypeName = y.PhoneNymberType.PhoneNymberTypeName,
                        PhoneNumber=y.PhoneNumber,
                        PhoneNumberTypeId=y.PhoneNumberTypeId
                    }).ToList()

                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return contact;
           
        }

        public async Task<List<OutPut_ContactDto>> GetContactList(ContactSelectDto selectmodel)
        {
            var templist = from contact in dbContext.Contacts
                           join phones in dbContext.ContactPhoneNumbers on contact.Id equals phones.ContactId                           
                           where (
                                 (string.IsNullOrEmpty(selectmodel.FullName) || ((contact.FirstName + " " + contact.LastName).Contains(selectmodel.FullName))) &&
                                 (string.IsNullOrEmpty(selectmodel.PhoneNumber) || (phones.PhoneNumber.Contains(selectmodel.PhoneNumber)))
                           )
                           group contact by contact.Id into ids
                           select ids.Key;
            var ides = templist.ToList();

             var Query = dbContext.Contacts.Where(x => ides.Contains(x.Id))
                 .Select(x => new OutPut_ContactDto()
                 {
                     Id = x.Id,
                     FirstName = x.FirstName,
                     LastName = x.LastName,
                     BirthDate = x.BirthDate,
                     CompanyName = x.CompanyName,
                     WebSite = x.WebSite,
                     Address = x.Address,
                     EmailAddress = x.EmailAddress,
                     Groups = dbContext.ContactGroups.Include(y => y.Group)
                     .Where(y => y.ContactId == x.Id)
                     .Select(y => new OutPut_GroupDto()
                     {
                         Id = y.Id,
                         GroupName = y.Group.GroupName
                     }).ToList(),
                     ContactPhoneNumbers = dbContext.ContactPhoneNumbers.Include(y => y.PhoneNymberType)
                     .Where(y => y.ContactId == x.Id)
                     .Select(y => new OutPut_ContactPhoneNumbersDto()
                     {
                         Id = y.Id,
                         PhoneNumberTypeName = y.PhoneNymberType.PhoneNymberTypeName,
                         PhoneNumber = y.PhoneNumber,
                         PhoneNumberTypeId = y.PhoneNumberTypeId
                     }).ToList()

                 })
                 .AsNoTracking();

             if (selectmodel.ShowPagingView)
             {
                 var lst = await Query.Skip(selectmodel.Page * selectmodel.PageSize)
                     .Take(selectmodel.PageSize)
                     .ToListAsync();

                 return lst;
             }
             else
             {
                 var lst = await Query.ToListAsync();
                 return lst;
             }
           // return new List<OutPut_ContactDto>(); 
        }

      
    }
}
