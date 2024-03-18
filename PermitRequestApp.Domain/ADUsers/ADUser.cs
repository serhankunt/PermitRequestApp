﻿using PermitRequestApp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermitRequestApp.Domain.ADUsers;
public sealed class ADUser : Entity
{
    private ADUser(string firstName, string lastName, string email, UserType userType, Guid? managerId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserType = userType;
        ManagerId = managerId;
    }

    private ADUser()
    {

    }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public UserType UserType { get; private set; } = UserType.WhiteCollarEmployee;

    public Guid? ManagerId { get; private set; }
    public ADUser? Manager { get; private set; }

    public static ADUser Create(string firstName, string lastName, string email, UserType userType, Guid? managerId)
    {
        ADUser user = new(firstName, lastName, email, userType, managerId);
        return user;
    }
    public static ADUser CreateSeedData(Guid id, string firstName, string lastName, string email, UserType userType, Guid? managerId)
    {
        ADUser user = new(firstName, lastName, email, userType, managerId);
        user.Id = id;
        return user;
    }

    public void Update(string firstName, string lastName, string email, UserType userType, Guid? managerId)
    {
        if (string.IsNullOrEmpty(firstName) || firstName.Length < 3)
        {
            throw new ArgumentException("FirstName is required and must be 3 letter at least");
        }
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        ManagerId = managerId;
        UserType = userType;
    }

}
