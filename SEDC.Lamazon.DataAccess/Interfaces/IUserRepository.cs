using SEDC.Lamazon.Domain.Entities;
namespace SEDC.Lamazon.DataAccess.Interfaces;

public interface IUserRepository
{
    List<User> GetAll();
    User Get(int id);
    int Insert(User user);
    void Update(User user);
    void Delete(int id);

    List<Role> GetAllUserRoles();
    Role GetUserRole(int id);

    User GetUserByEmail(string email);
}
