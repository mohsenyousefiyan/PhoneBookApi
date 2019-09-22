using System.Collections.Generic;

namespace PhoneBook.Core.Entities.Dtos.BaseDtos
{
    public class BaseSelectOutPutDto<T> : BaseOutPutDto where T : class
    {
        public T ResultItem { get; set; }
        public List<T> ResultList { get; set; }
    }
}
