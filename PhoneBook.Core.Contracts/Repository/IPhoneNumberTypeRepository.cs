using PhoneBook.Core.Entities.Dtos.BaseDtos;
using PhoneBook.Core.Entities.Dtos.PhoneNumberTypeDtos.InputDtos;
using PhoneBook.Core.Entities.Dtos.PhoneNumberTypeDtos.OutPutDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Contracts.Repository
{
    public interface  IPhoneNumberTypeRepository
    {
        Task<BaseResultCRUDDto<OutPut_PhoneNumberTypeDto>> AddPhoneNumberType(PhoneNumberTypeAddDto addedmodel);
        Task<BaseResultCRUDDto<OutPut_PhoneNumberTypeDto>> UpdatePhoneNumberType(PhoneNumberTypeUpdateDto editmodel);
        Task<BaseOutPutDto> DeletePhoneNumberType(int id);

        Task<OutPut_PhoneNumberTypeDto> GetById(int id);
        Task<List<OutPut_PhoneNumberTypeDto>> GetPhoneNumberTypList(PhoneNumberTypeSelectDto selectmodel);
        Task<OutPut_PhoneNumberTypeDto> GetByPhoneNumberTypeName(string phonenumbertypename);

    }
}
