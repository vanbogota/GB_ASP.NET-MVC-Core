using FinalProject.Models;
using FinalProject.Repositories;

namespace FinalProject.Services
{
    public class UserService : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public int Add(User item)
        {
            _dataContext.Users.Add(item);
            _dataContext.SaveChanges();
            return item.Id;
        }

        public bool Delete(int id)
        {
            var user = GetById(id);
            if (user == null)
                return false;

            _dataContext.Remove(user);
            _dataContext.SaveChanges();

            return true;
        }

        public bool Edit(User item)
        {
            var user = GetById(item.Id);
            if (user == null)
                return false;

            user.Email = item.Email;            
            user.Name = item.Name;

            _dataContext.SaveChanges();

            return true;
        }

        public IEnumerable<User> GetAll() => _dataContext.Users;

        public User? GetById(int id)
        {
            var user = _dataContext.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }
    }
}
