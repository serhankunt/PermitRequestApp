using Ardalis.Result;
using MediatR;
using PermitRequestApp.Domain.Abstractions;
using PermitRequestApp.Domain.ADUsers;
using PermitRequestApp.Domain.LeaveRequests;
using PermitRequestApp.Domain.LeaveRequests.Events;

namespace PermitRequestApp.Application.Features.LeaveRequests.CreateLeaveRequest;

internal sealed class CreateLeaveRequestCommandHandler(
	IADUserRepository aDUserRepository,
	ILeaveRequestRepository leaveRequestRepository,
	IUnitOfWork unitOfWork,
	IMediator mediator) 
	:IRequestHandler<CreateLeaveRequestCommand, Result<string>>
{
	public async Task<Result<string>> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
	{
		ADUser? user = await aDUserRepository.GetByIdAsync(request.EmployeeId, cancellationToken);
		if(user == null)
		{
			return Result.Conflict("User not found");
		}

		int lastFormNumber = leaveRequestRepository.FindLastFormNumber();
		if(lastFormNumber < 100)
		{
			lastFormNumber = 100;
		}
		else
		{
			lastFormNumber++;
		}

		LeaveRequest leaveRequest = LeaveRequest.Create(
			lastFormNumber,
			request.LeaveType,
			request.Reason,
			request.StartDate,
			request.EndDate,
			user.Id,
			user.ManagerId);

		await leaveRequestRepository.AddAsync(leaveRequest,cancellationToken);
		await unitOfWork.SaveChangesAsync(cancellationToken);

		await mediator.Publish(new LeaveRequestDomainEvent(leaveRequest.Id));

		return "Request is successful";

	}
}
