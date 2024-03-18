using Microsoft.EntityFrameworkCore;
using PermitRequestApp.Domain.ADUsers;
using PermitRequestApp.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermitRequestApp.Infrastructure.Repositories;
internal sealed class ADUserRepository(ApplicationDbContext context) : IADUserRepository
{
    public IQueryable<ADUser> GetAllUsers()
    {
        return context.Set<ADUser>().AsNoTracking().AsQueryable();
    }
}
