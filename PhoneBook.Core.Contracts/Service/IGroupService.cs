using PhoneBook.Core.Entities.Dtos.BaseDtos;
using PhoneBook.Core.Entities.Dtos.GroupDtos.InputDtos;
using PhoneBook.Core.Entities.Dtos.GroupDtos.OutPutDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Contracts.Service
{
    public interface IGroupService
    {
        Task<BaseResultCRUDDto<OutPut_GroupDto>> CreateGroup(GroupAddDto addedmodel);
        Task<BaseResultCRUDDto<OutPut_GroupDto>> EditGroup(GroupUpdateDto editmodel);
        Task<BaseOutPutDto> DeleteGroup(int id);
        Task<BaseOutPutDto> DeleteMember(int groupid, int contactid);

        Task<BaseOutPutDto> AddContactToGroup(GroupMemberAddDto model);
        Task<OutPut_GroupDto> GetById(int id);
        Task<List<OutPut_GroupDto>> SearchGroup(GroupSelectDto selectmodel);
    }
}
