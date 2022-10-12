using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cleanasia.Areas.Identity.Data;
using Cleanasia.Models;
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

        public DbSet<CategoryModel> category { get; set; }
        public DbSet<ServiceModel> Service { get; set; }
        public DbSet<ContactUsModel> contactUs { get; set; }
        public DbSet<bookingServiceModel> bookingService { get; set; }
        public DbSet<CheckOutModel> CheckoutDetail { get; set; }
    }
}
