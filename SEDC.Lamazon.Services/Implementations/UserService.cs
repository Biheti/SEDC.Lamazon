using Microsoft.AspNetCore.Identity;
using SEDC.Lamazon.DataAccess.Inplementations;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Entities;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Services.Maper;
using SEDC.Lamazon.Services.ViewModels.Role;
using SEDC.Lamazon.Services.ViewModels.User;
using System.Data;

namespace SEDC.Lamazon.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly PasswordHasher<User> _passwordHasher;

    public UserService(IUserRepository userRepository) 
    {
        _userRepository = userRepository;
        _passwordHasher = new PasswordHasher<User>();
    }

    public UserViewModel LoginUser(LoginUserViewModel loginUserViewModel)
    {
        User user = _userRepository.GetUserByEmail(loginUserViewModel.Email);
        if (user is null)
            throw new Exception("Login credentials do not match any user");

        PasswordVerificationResult passwordVerificationResult=
            _passwordHasher.VerifyHashedPassword(user, user.Password, loginUserViewModel.Password);

        if (passwordVerificationResult == PasswordVerificationResult.Failed)
            throw new Exception("Login credentials do not match any user");

        return user.ToUserViewModel();
    }

    public void RegisterUser(RegisterUserViewModel registerUserViewModel)
    {
        if (registerUserViewModel == null)
            throw new Exception("Model is null");

        if (registerUserViewModel.Password != registerUserViewModel.ConfirmationPassword)
            throw new Exception("Password must match");

        User newUser = new User()
        {
            City = registerUserViewModel.City,
            Email = registerUserViewModel.Email,
            FullName = registerUserViewModel.FullName,
            PhoneNumber = registerUserViewModel.PhoneNumber,
            PostalCode = registerUserViewModel.PostalCode,
            State = registerUserViewModel.State,
            StreetAdress = registerUserViewModel.StreetAdress,
        };
        string hashPassword = _passwordHasher.HashPassword(newUser, registerUserViewModel.Password);
        newUser.Password = hashPassword;

        Role role = _userRepository.GetUserRole(registerUserViewModel.RoleId);

        if (role == null)
            throw new Exception("The role does not existi");

        newUser.Role = role;

        _userRepository.Insert(newUser);
    }

    public void DeleteUserById(int id)
    {
        _userRepository.Delete(id);
    }

    public List<RoleViewModel> GetAllUserRoles()
    {
        return _userRepository.GetAllUserRoles()
            .Select (ur => new RoleViewModel()
            {
                Id = ur.Id,
                Key = ur.Key,
                Name = ur.Name
            }).ToList();
    }

    public List<UserViewModel> GetAllUsers()
    {
        return _userRepository
            .GetAll()
            .Select (ur =>ur.ToUserViewModel())
            .ToList();
    }

    public RoleViewModel GetRoleById(int id)
    {
        Role role = _userRepository.GetUserRole(id);

        return new RoleViewModel()
        {
            Id = role.Id,
            Key = role.Key,
            Name = role.Name
        };
    }

    public UserViewModel GetUserById(int id)
    {
        return _userRepository
            .Get(id)
            .ToUserViewModel();
    }

   
}
