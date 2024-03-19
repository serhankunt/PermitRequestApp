using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermitRequestApp.Domain.ADUsers;
public interface IADUserRepository
{
    IQueryable<ADUser> GetAllUsers();
	Task<ADUser?> GetByIdAsync(Guid employeeId, CancellationToken cancellationToken = default);
}
