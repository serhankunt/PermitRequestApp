using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermitRequestApp.Domain.ADUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermitRequestApp.Infrastructure.Configurations;
internal class AdUserConfiguration : IEntityTypeConfiguration<ADUser>
{
    public void Configure(EntityTypeBuilder<ADUser> builder)
    {
        builder.ToTable("ADUser");

        List<ADUser> users = new List<ADUser>()
        {
            ADUser.CreateSeedData(
                id:Guid.Parse("9a000b64-a2c8-4102-b243-4c5bd4d5a9c1"),
                firstName:"Özge",
                lastName:"Toksöz",
                email:"ozgetoksoz@gmail.com",
                userType:UserType.Manager,
                managerId:null),

             ADUser.CreateSeedData(
                id:Guid.Parse("88204738-994b-4999-b752-78e071ba9d1f"),
                firstName:"H. Serhan",
                lastName:"Kunt",
                email:"serhankunt@gmail.com",
                userType:UserType.WhiteCollarEmployee,
                managerId:Guid.Parse("9a000b64-a2c8-4102-b243-4c5bd4d5a9c1")),

             ADUser.CreateSeedData(
                id:Guid.Parse("2a2e822c-b1cf-422f-a8ae-6307e0f03a77"),
                firstName:"Betül",
                lastName:"Kunt",
                email:"betulkunt@gmail.com",
                userType:UserType.BlueCollarEmployee,
                managerId: Guid.Parse("88204738-994b-4999-b752-78e071ba9d1f")),

        };

        builder.HasData(users);

        

    }
}
