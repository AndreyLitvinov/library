using Library.Models.LibraryModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.IdentityModels
{
    public class AppUser : IdentityUser<Guid>
    {
        public Reader Reader { get; set; }
    }
}
