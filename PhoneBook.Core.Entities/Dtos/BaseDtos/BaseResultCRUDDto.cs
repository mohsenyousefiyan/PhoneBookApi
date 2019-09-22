using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Entities.Dtos.BaseDtos
{
    public class BaseResultCRUDDto<T>:BaseOutPutDto where T :class 
    {
        public T CRUDObject { get; set; }
    }
}
