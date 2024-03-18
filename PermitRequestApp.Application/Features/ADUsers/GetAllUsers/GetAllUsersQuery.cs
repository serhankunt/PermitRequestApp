using Ardalis.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermitRequestApp.Application.Features.ADUsers.GetAllUsers;
public sealed record GetAllUsersQuery(): IRequest<Result<List<GetAllUserQueryResponse>>>;
