using SEDC.Lamazon.Domain.Entities;
using SEDC.Lamazon.Services.ViewModels.Role;

namespace SEDC.Lamazon.Services.ViewModels.User;

public class UserViewModel
{
    public int Id { get; set; } 
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string StreetAdress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public RoleViewModel Role { get; set; }
}
