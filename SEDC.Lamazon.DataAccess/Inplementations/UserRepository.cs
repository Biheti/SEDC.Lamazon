using Microsoft.EntityFrameworkCore;
using SEDC.Lamazon.DataAccess.Context;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Entities;
namespace SEDC.Lamazon.DataAccess.Inplementations
{
    public class UserRepository : IUserRepository
    {
        private readonly LamazonDbContext _dbContext;

        public UserRepository(LamazonDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public void Delete(int id)
        {
            User user  =_dbContext.Users
                .Where(u => u.Id == id)
                .FirstOrDefault();

            if (user == null)
                throw new Exception($"The user witj provided id {id} does not exist");

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public User Get(int id)
        {
            User user = _dbContext.Users
                .Where(u => u.Id == id)
                .FirstOrDefault();

            if (user == null)
                throw new Exception($"The user witj provided id {id} does not exist");

            return user;
        }

        public List<User> GetAll()
        {
           return _dbContext.Users.ToList();
        }

       

        public int Insert(User user)
        {
            _dbContext.Users.Add(user);
            return _dbContext.SaveChanges();
        }

        public void Update(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }


        public List<Role> GetAllUserRoles()
        {
            return _dbContext.Roles.ToList();
        }

        public Role GetUserRole(int id)
        {
            Role role = _dbContext.Roles.Where(r => r.Id == id).FirstOrDefault();

            if (role == null)
                throw new Exception($"The user witj provided id {id} does not exist");

            return role;
        }

        public User GetUserByEmail(string email)
        {
            return _dbContext
                .Users
                .Include(u => u.Role)
                .Where(u => u.Email == email)
                .FirstOrDefault();
        }
    }
}
