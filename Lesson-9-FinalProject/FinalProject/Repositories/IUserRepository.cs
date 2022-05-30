using FinalProject.Models;

namespace FinalProject.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User? GetById(int id);
        int Add(User item);
        bool Edit(User item);
        bool Delete(int id);

    }
}
