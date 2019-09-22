using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Contracts.Repository;
using PhoneBook.Core.Entities.Dtos.BaseDtos;
using PhoneBook.Core.Entities.Dtos.GroupDtos.InputDtos;
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
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext dbContext;

        public GroupRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<BaseResultCRUDDto<OutPut_GroupDto>> AddGroup(GroupAddDto addedmodel)
        {
            var AddedItem = new Group() { GroupName = addedmodel.GroupName };

            dbContext.Groups.Add(AddedItem);
            await dbContext.SaveChangesAsync();

            return new BaseResultCRUDDto<OutPut_GroupDto>()
            {
                IsSuccess = true,
                CRUDObject = new OutPut_GroupDto() { Id = AddedItem.Id, GroupName = AddedItem.GroupName  }
            };
        }

        public async Task<BaseOutPutDto> DeleteGroup(int id)
        {
            try
            {
                var DeletedItem = await dbContext.Groups.FirstOrDefaultAsync(x => x.Id == id);
                if (DeletedItem == null)
                    return new BaseOutPutDto() { ErrorMessage = "رکوردی با این آی دی یافت نشد" };

                dbContext.Groups.Remove(DeletedItem);
                await dbContext.SaveChangesAsync();
                return new BaseOutPutDto() { IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new BaseOutPutDto() { ErrorMessage = ex.Message };
            }
        }

        public async Task<BaseOutPutDto> DeleteMember(int groupid, int contactid)
        {

            try
            {
                var DeletedItem = await dbContext.ContactGroups.Where(x => x.ContactId==contactid && x.GroupId==groupid ).ToListAsync();
                if (DeletedItem == null)
                    return new BaseOutPutDto() { ErrorMessage = "رکوردی با این آی دی یافت نشد" };

                dbContext.ContactGroups.RemoveRange(DeletedItem);
                await dbContext.SaveChangesAsync();
                return new BaseOutPutDto() { IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new BaseOutPutDto() { ErrorMessage = ex.Message };
            }
        }
        public async Task<BaseResultCRUDDto<OutPut_GroupDto>> UpdateGroup(GroupUpdateDto editmodel)
        {
            var EditItem = await dbContext.Groups.FirstOrDefaultAsync(x => x.Id == editmodel.Id);
            if (EditItem != null)
            {
                EditItem.GroupName = editmodel.GroupName;
                dbContext.Update(EditItem);
                await dbContext.SaveChangesAsync();
                return new BaseResultCRUDDto<OutPut_GroupDto>() { IsSuccess = true, CRUDObject=await GetById(EditItem.Id) };
            }
            else
                return new BaseResultCRUDDto<OutPut_GroupDto>() { ErrorMessage = "گروهی با این آی دی وجود ندارد" };
        }


        public async Task<OutPut_GroupDto> GetByGroupName(string groupname)
        {
            var group = await dbContext.Groups.Where(x => x.GroupName  == groupname)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if(group!=null)
                return new OutPut_GroupDto() { Id = group.Id, GroupName = group.GroupName };
            return null;
        }

        public async Task<OutPut_GroupDto> GetById(int id)
        {
            var group = await dbContext.Groups.Where(x => x.Id == id)
               .AsNoTracking()
               .FirstOrDefaultAsync();

            if (group != null)
            {
                return new OutPut_GroupDto()
                {
                    Id = group.Id,
                    GroupName = group.GroupName
                };
            }

            return null;
        }

        public async Task<List<OutPut_GroupDto>> GetGroupList(GroupSelectDto selectmodel)
        {
            var Query = dbContext.Groups.Where(x => string.IsNullOrEmpty(selectmodel.GroupName) || x.GroupName.Contains(selectmodel.GroupName ))
                .AsNoTracking()
                .Select(x => new OutPut_GroupDto()
                {
                    Id = x.Id,
                    GroupName  = x.GroupName
                });

            if (selectmodel.ShowPagingView )
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

        }

        public async Task<BaseOutPutDto> AddContactToGroup(GroupMemberAddDto model)
        {
            try
            {
                List<ContactGroup> ItemsToAdd = new List<ContactGroup>();
                foreach (var item in model.ContactIds)
                    ItemsToAdd.Add(new ContactGroup() { ContactId = item, GroupId = model.GroupId });

                dbContext.ContactGroups.AddRange(ItemsToAdd);
                await dbContext.SaveChangesAsync();
                return new BaseOutPutDto() { IsSuccess = true }; 
            }
            catch(Exception ex)
            {
                return new BaseOutPutDto() { ErrorMessage = ex.Message };
            }
        }
    }
}
