using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raamatuklubi.Core.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public List<Book>? AddedBooks { get; set; }
        public List<Comment>? AddedComments { get; set; }
        public string DisplayName { get; set; }
        public bool IsAdmin { get; set; }
    }
}
