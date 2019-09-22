using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.Contracts.Service;
using PhoneBook.Core.Entities.Dtos.BaseDtos;
using PhoneBook.Core.Entities.Dtos.ContactDtos.InputDtos;
using PhoneBook.Core.Entities.Dtos.ContactDtos.OutPutDtos;
using PhoneBook.Core.Entities.Dtos.ContactPhoneNumbersDto.InputDtos;
using PhoneBook.EndPoints.WebAPI.InfraStructures;

namespace PhoneBook.EndPoints.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }


        [HttpGet]
        [Route("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var selectobject = await contactService.GetById(id);
            var Result = new BaseSelectOutPutDto<OutPut_ContactDto>()
            {
                IsSuccess = true,
                ResultItem = selectobject
            };

            return Ok(Result);
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> SearchContact([FromQuery]ContactSelectDto searchitems)
        {
            searchitems.Page--;
            var resultlist = await contactService.SearchContact(searchitems);
            var Result = new BaseSelectOutPutDto<OutPut_ContactDto>()
            {
                IsSuccess = true,
                ResultList = resultlist
            };

            return Ok(Result);
        }


        [HttpPost]
        [Route("create")]
        [ValidationModelFilter]
        public async Task<IActionResult> CreateContact(ContactAddDto model)
        {
            var resultAdd = await contactService.CreateContact(model);
            return Ok(resultAdd);
        }

        [HttpPut]
        [Route("edit")]
        [ValidationModelFilter]
        public async Task<IActionResult> EditContact(ContactUpdateDto  model)
        {
            var result = await contactService.EditContact(model);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete")]
        [ValidationModelFilter]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var result = await contactService.DeleteContact(id);
            return Ok(result);
        }


        [HttpDelete]
        [Route("deletenumber")]
        [ValidationModelFilter]
        public async Task<IActionResult> DeletePhoneNumber(int id)
        {
            var result = await contactService.DeletePhoneNumber(id);
            return Ok(result);
        }
    }
}