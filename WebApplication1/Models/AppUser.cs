using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{

    public class AppUser : IdentityUser
    {

        //[MaxLength(100)]
        //public string Name { set; get; }

        //[MaxLength(255)]
        //public string Address { set; get; }

    }
}