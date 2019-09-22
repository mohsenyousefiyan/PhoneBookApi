using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.Contracts.Service;
using PhoneBook.Core.Entities.Dtos.BaseDtos;
using PhoneBook.Core.Entities.Dtos.PhoneNumberTypeDtos.InputDtos;
using PhoneBook.Core.Entities.Dtos.PhoneNumberTypeDtos.OutPutDtos;
using PhoneBook.EndPoints.WebAPI.InfraStructures;

namespace PhoneBook.EndPoints.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberTypeController : ControllerBase
    {
        private readonly IPhoneNumberTypeService phoneNumberTypeService;

        public PhoneNumberTypeController(IPhoneNumberTypeService phoneNumberTypeService)
        {
            this.phoneNumberTypeService = phoneNumberTypeService;
        }


        [HttpGet]
        [Route("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var selectobject=await phoneNumberTypeService.GetById(id);
            var Result = new BaseSelectOutPutDto<OutPut_PhoneNumberTypeDto>()
            {
                IsSuccess = true,
                ResultItem = selectobject
            };
            
            return Ok(Result);
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> SearchPhoneNumberType([FromQuery]PhoneNumberTypeSelectDto searchitems)
        {
            searchitems.Page--;
            var resultlist =await phoneNumberTypeService.SearchPhoneNumberTyp(searchitems);
            var Result = new BaseSelectOutPutDto<OutPut_PhoneNumberTypeDto>()
            {
                IsSuccess = true,
                ResultList = resultlist
            };

            return Ok(Result);
        }

        
        [HttpPost]
        [Route("create")]
        [ValidationModelFilter]
        public async Task<IActionResult>CreatePhoneNumberType(PhoneNumberTypeAddDto model)
        {
            var resultAdd=await phoneNumberTypeService.CreatePhoneNumberType(model);
            return Ok(resultAdd);
        }


        [HttpPut]
        [Route("edit")]
        [ValidationModelFilter]
        public async Task<IActionResult> EditPhoneNumberType(PhoneNumberTypeUpdateDto model)
        {
            var result = await phoneNumberTypeService.EditPhoneNumberType(model);
            return Ok(result);
        }


        [HttpDelete]
        [Route("delete")]
        [ValidationModelFilter]
        public async Task<IActionResult> DeletePhoneNumberType(int id)
        {
            var result = await phoneNumberTypeService.DeletePhoneNumberType(id);
            return Ok(result);
        }

    }
}