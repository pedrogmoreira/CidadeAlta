using CidadeAlta.Domain.Entities;

namespace CidadeAlta.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User? Find(string email);
    }
}
