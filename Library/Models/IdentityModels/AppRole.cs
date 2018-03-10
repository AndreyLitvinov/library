using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.IdentityModels
{
    public class AppRole : IdentityRole<Guid>
    {
        public AppRole(string roleName) : base(roleName) { }

        public string NavigationsItems { get; set; }

        public const string Librarian = "Librarian";
        public const string User = "User";
        public const string Stockman = "Stockman";
        public const string Admin = "Admin";

        public static string[] AllRoles => new string[] { Librarian, User, Stockman, Admin };
    }
}
