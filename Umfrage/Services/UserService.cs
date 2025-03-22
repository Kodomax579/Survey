using Microsoft.EntityFrameworkCore;
using Umfrage.Data;
using Umfrage.DTO;
using Umfrage.Model;

namespace Umfrage.Services
{
    public class UserService
    {
        private SurveyContext _context;
        public UserService(SurveyContext context)
        {
            _context = context;
        }

        public List<User> AllUser()
        {
            return _context.User.AsNoTracking().ToList();
        }

        public User? SelectedUser(string email, string password)
        {
            return _context.User.AsNoTracking().FirstOrDefault(e => e.Email == email && e.Password == password);
        }

        public bool CreateUser(CreateUserDTO newUser)
        {
            User user = new User
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                Password = newUser.Password,
                Schoolclass = newUser.Schoolclass,
                role = 0
            };
            _context.User.Add(user);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateUser(User updatedUser)
        {
            _context.User.Update(updatedUser);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteUser(int userId)
        {
            var user = _context.User.Find(userId);
            if (user == null)
                return false;

            _context.User.Remove(user);
            return _context.SaveChanges() > 0;
        }
    }
}
