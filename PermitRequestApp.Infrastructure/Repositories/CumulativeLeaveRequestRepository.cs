using GenericRepository;
using Microsoft.EntityFrameworkCore;
using PermitRequestApp.Domain.CumulativeLeaveRequests;
using PermitRequestApp.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermitRequestApp.Infrastructure.Repositories;
internal sealed class CumulativeLeaveRequestRepository : Repository<CumulativeLeaveRequest,ApplicationDbContext>, ICumulativeLeaveRequestRepository
{
	public CumulativeLeaveRequestRepository(ApplicationDbContext context) : base(context)
	{
	}
}
