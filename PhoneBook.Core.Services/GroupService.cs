using PhoneBook.Core.Contracts.Repository;
using PhoneBook.Core.Contracts.Service;
using PhoneBook.Core.Entities.Dtos.BaseDtos;
using PhoneBook.Core.Entities.Dtos.GroupDtos.InputDtos;
using PhoneBook.Core.Entities.Dtos.GroupDtos.OutPutDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }


        public async Task<BaseResultCRUDDto<OutPut_GroupDto>> CreateGroup(GroupAddDto addedmodel)
        {
            if (await groupRepository.GetByGroupName(addedmodel.GroupName ) != null)
                return new BaseResultCRUDDto<OutPut_GroupDto>() { ErrorMessage = "عنوان گروه از قبل به ثبت رسیده است " };

            return await groupRepository.AddGroup(addedmodel);
        }

        public async Task<BaseOutPutDto> DeleteGroup(int id)
        {
            return await groupRepository.DeleteGroup(id);
        }

        public async Task<BaseOutPutDto> DeleteMember(int groupid, int contactid)
        {
            return await groupRepository.DeleteMember(groupid, contactid);
        }

        public async Task<BaseResultCRUDDto<OutPut_GroupDto>> EditGroup(GroupUpdateDto editmodel)
        {
            var findobject = await groupRepository.GetByGroupName(editmodel.GroupName);
            if (findobject != null && findobject.Id != editmodel.Id)
                return new BaseResultCRUDDto<OutPut_GroupDto>() { ErrorMessage = "عنوان گروه از قبل به ثبت رسیده است " };

            return await groupRepository.UpdateGroup(editmodel);
        }

        public async Task<OutPut_GroupDto> GetById(int id)
        {
            return await groupRepository.GetById(id);
        }

        public async Task<List<OutPut_GroupDto>> SearchGroup(GroupSelectDto selectmodel)
        {
            return await groupRepository.GetGroupList(selectmodel);
        }

        public async Task<BaseOutPutDto> AddContactToGroup(GroupMemberAddDto model)
        {
            return await groupRepository.AddContactToGroup(model);
        }
    }
}
