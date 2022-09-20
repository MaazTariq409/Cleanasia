using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Cleanasia.Areas.Identity.Data
{
    public class CleanasiaUser : IdentityUser
    {
        [PersonalData]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(20,ErrorMessage ="Name should not exceed 20 characters")]
        public string FirstName { get; set; }

        [PersonalData]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [PersonalData]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }

        [PersonalData]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string CNIC { get; set; }
        [Required]

        public string Role { get; set; }
    }
}
