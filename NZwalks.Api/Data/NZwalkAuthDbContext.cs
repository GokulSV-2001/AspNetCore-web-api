using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZwalks.Api.Data
{
    public class NZwalkAuthDbContext : IdentityDbContext
    {
        public NZwalkAuthDbContext(DbContextOptions<NZwalkAuthDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var readerKeyId="c1155e95-cc87-4087-bf51-7835f12b3409";
            var writerKeyId="0668f00a-c561-4b25-abe4-e8c874ea649f";

            var roles= new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id=readerKeyId,
                    Name="Reader",
                    ConcurrencyStamp=readerKeyId,
                    NormalizedName="Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id=writerKeyId,
                    Name="Writer",
                    ConcurrencyStamp=writerKeyId,
                    NormalizedName="Writer".ToUpper()
                }
            };
             builder.Entity<IdentityRole>().HasData(roles);
        }

       
    }
}