using GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermitRequestApp.Domain.LeaveRequests;
public interface ILeaveRequestRepository : IRepository<LeaveRequest>
{
    int FindLastFormNumber();
}
