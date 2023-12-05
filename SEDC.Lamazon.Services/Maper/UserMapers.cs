using SEDC.Lamazon.Domain.Entities;
using SEDC.Lamazon.Services.ViewModels.Role;
using SEDC.Lamazon.Services.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Services.Maper;

public static class UserMapers
{
    public static UserViewModel ToUserViewModel(this User model)
    {
        return new UserViewModel
        {
            City = model.City,
            Email = model.Email,
            FullName = model.FullName,
            Id = model.Id,
            Password = model.Password,
            PhoneNumber = model.PhoneNumber,
            Role = new RoleViewModel()
            {
                Id = model.Role.Id,
                Key = model.Role.Key,
                Name = model.Role.Name
            },
            PostalCode = model.PostalCode,
            State = model.State,
            StreetAdress = model.StreetAdress,
        };
    }
}
