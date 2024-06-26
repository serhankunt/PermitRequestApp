﻿using Microsoft.Extensions.DependencyInjection;
using PermitRequestApp.Domain.CumulativeLeaveRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PermitRequestApp.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(
                Assembly.GetExecutingAssembly(),
                typeof(CumulativeLeaveRequest).Assembly);
        });

        return services;
    }
}
