using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.Contracts.Service;
using PhoneBook.Core.Entities.Dtos.BaseDtos;
using PhoneBook.Core.Entities.Dtos.GroupDtos.InputDtos;
using PhoneBook.Core.Entities.Dtos.GroupDtos.OutPutDtos;
using PhoneBook.EndPoints.WebAPI.InfraStructures;

namespace PhoneBook.EndPoints.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService groupService;

        public GroupController(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        [HttpGet]
        [Route("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var selectobject = await groupService.GetById(id);
            var Result = new BaseSelectOutPutDto<OutPut_GroupDto>()
            {
                IsSuccess = true,
                ResultItem = selectobject
            };

            return Ok(Result);
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> SearchGroups([FromQuery]GroupSelectDto searchitems)
        {
            searchitems.Page--;
            var resultlist = await groupService.SearchGroup (searchitems);
            var Result = new BaseSelectOutPutDto<OutPut_GroupDto>()
            {
                IsSuccess = true,
                ResultList = resultlist
            };

            return Ok(Result);
        }

        [HttpPost]
        [Route("create")]
        [ValidationModelFilter]
        public async Task<IActionResult> CreateGroup(GroupAddDto model)
        {
            var resultAdd = await groupService.CreateGroup(model);
            return Ok(resultAdd);
        }

        [HttpPut]
        [Route("edit")]
        [ValidationModelFilter]
        public async Task<IActionResult> EditGroup(GroupUpdateDto model)
        {
            var result = await groupService.EditGroup(model);
            return Ok(result);
        }


        [HttpDelete]
        [Route("delete")]
        [ValidationModelFilter]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var result = await groupService.DeleteGroup(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("addmember")]
        [ValidationModelFilter]
        public async Task<IActionResult> AddMemberToGroup(GroupMemberAddDto model)
        {
            var resultAdd = await groupService.AddContactToGroup(model);
            return Ok(resultAdd);
        }

        [HttpDelete]
        [Route("deletemember")]
        [ValidationModelFilter]
        public async Task<IActionResult> DeletememberFromGroup(int groupid,int contactid)
        {
            var result = await groupService.DeleteMember(groupid,contactid);
            return Ok(result);
        }
    }
}