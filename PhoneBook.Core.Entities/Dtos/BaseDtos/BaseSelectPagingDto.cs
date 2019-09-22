using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Entities.Dtos.BaseDtos
{
   public class BaseSelectPagingDto
    {
        public Boolean ShowPagingView { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
    }
}
