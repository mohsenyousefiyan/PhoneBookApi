using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Contracts.Repository;
using PhoneBook.Core.Entities.Dtos.BaseDtos;
using PhoneBook.Core.Entities.Dtos.PhoneNumberTypeDtos.InputDtos;
using PhoneBook.Core.Entities.Dtos.PhoneNumberTypeDtos.OutPutDtos;
using PhoneBook.Core.Entities.Entities;
using PhoneBook.InfraStructures.DAL.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.InfraStructures.DAL.EFCore.Repository
{
    public class PhoneNumberTypeRepository : IPhoneNumberTypeRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PhoneNumberTypeRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<BaseResultCRUDDto<OutPut_PhoneNumberTypeDto>> AddPhoneNumberType(PhoneNumberTypeAddDto addedmodel)
        {           
            var AddedItem = new PhoneNymberType() { PhoneNymberTypeName = addedmodel.PhoneNumberTypeName };

            dbContext.PhoneNymberTypes.Add(AddedItem);
            await dbContext.SaveChangesAsync();

            return new BaseResultCRUDDto<OutPut_PhoneNumberTypeDto>()
            {
                IsSuccess = true,
                CRUDObject = new OutPut_PhoneNumberTypeDto() { Id = AddedItem.Id, PhoneNumberTypeName = AddedItem.PhoneNymberTypeName }
            };
        }

        public async Task<BaseOutPutDto> DeletePhoneNumberType(int id)
        {
            try
            {
                var DeletedItem = await dbContext.PhoneNymberTypes.FirstOrDefaultAsync(x => x.Id == id);
                if (DeletedItem == null)
                    return new BaseOutPutDto() { ErrorMessage = "رکوردی با این آی دی یافت نشد" };

                dbContext.PhoneNymberTypes.Remove(DeletedItem);
                await dbContext.SaveChangesAsync();
                return new BaseOutPutDto() { IsSuccess = true };
            }
            catch(Exception ex)
            {
                return new BaseOutPutDto() { ErrorMessage = ex.Message };
            }
        }

        public async Task<BaseResultCRUDDto<OutPut_PhoneNumberTypeDto>> UpdatePhoneNumberType(PhoneNumberTypeUpdateDto editmodel)
        {           
            var EditItem=await dbContext.PhoneNymberTypes.FirstOrDefaultAsync(x=>x.Id== editmodel.Id);
            if (EditItem != null)
            {
                EditItem.PhoneNymberTypeName = editmodel.PhoneNumberTypeName;
                dbContext.Update(EditItem);
                await dbContext.SaveChangesAsync();
                return new BaseResultCRUDDto<OutPut_PhoneNumberTypeDto>() { IsSuccess = true,CRUDObject=await GetById(EditItem.Id) };
            }
            else
                return new BaseResultCRUDDto<OutPut_PhoneNumberTypeDto>() { ErrorMessage = "نوع تلفنی با این آی دی وجود ندارد" };
        }


        public async Task<OutPut_PhoneNumberTypeDto> GetById(int id)
        {
            var phonenumbertype =await dbContext.PhoneNymberTypes.Where(x => x.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (phonenumbertype != null)
            {
                return new OutPut_PhoneNumberTypeDto()
                {
                    Id = phonenumbertype.Id,
                    PhoneNumberTypeName = phonenumbertype.PhoneNymberTypeName
                };
            }

            return null;
        }
        public async Task<List<OutPut_PhoneNumberTypeDto>> GetPhoneNumberTypList(PhoneNumberTypeSelectDto phoneNumberTypeSelectDto)
        {
            var Query = dbContext.PhoneNymberTypes.Where(x => string.IsNullOrEmpty(phoneNumberTypeSelectDto.PhoneNumberTypeName) || x.PhoneNymberTypeName.Contains(phoneNumberTypeSelectDto.PhoneNumberTypeName))
                .AsNoTracking()
                .Select(x=>new OutPut_PhoneNumberTypeDto()
                {
                    Id=x.Id,
                    PhoneNumberTypeName=x.PhoneNymberTypeName 
                });

            if (phoneNumberTypeSelectDto.ShowPagingView)
            {
                var lst=await Query.Skip(phoneNumberTypeSelectDto.Page * phoneNumberTypeSelectDto.PageSize)
                    .Take(phoneNumberTypeSelectDto.PageSize)
                    .ToListAsync();

                return lst;
            }
            else
            {
                var lst =await Query.ToListAsync();
                return lst;
            }

        }
        public async Task<OutPut_PhoneNumberTypeDto> GetByPhoneNumberTypeName(string phonenumbertypename)
        {
            var phonenumbertype = await dbContext.PhoneNymberTypes.Where(x => x.PhoneNymberTypeName == phonenumbertypename)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if(phonenumbertype!=null )
                return new OutPut_PhoneNumberTypeDto() { Id = phonenumbertype.Id, PhoneNumberTypeName=phonenumbertype.PhoneNymberTypeName};

            return null;
        }      
    }
}
