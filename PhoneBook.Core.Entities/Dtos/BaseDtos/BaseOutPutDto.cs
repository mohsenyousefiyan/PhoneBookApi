using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Entities.Dtos.BaseDtos
{
    public class BaseOutPutDto
    {
        public Boolean IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
