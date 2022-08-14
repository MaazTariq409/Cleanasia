using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cleanasia.Areas.Identity.Data;
using Cleanasia_FYP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cleanasia.Data
{
    public class CleanasiaContext : IdentityDbContext<CleanasiaUser>
    {
        public CleanasiaContext(DbContextOptions<CleanasiaContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
