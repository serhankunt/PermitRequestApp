using Ardalis.Result;
using MediatR;
using PermitRequestApp.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermitRequestApp.Application.Features.LeaveRequests.CreateLeaveRequest;
public sealed record CreateLeaveRequestCommand(
	Guid EmployeeId,
	LeaveType LeaveType,
	DateTime StartDate,
	DateTime EndDate,
	string Reason) : IRequest<Result<string>>;
