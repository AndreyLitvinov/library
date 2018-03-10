using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.LibraryModels
{
    public class BaseModel
    {
        [BindNever]
        public Guid Id { get; set; }
    }
}
