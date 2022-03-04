using CidadeAlta.Data.Context;
using CidadeAlta.Domain.Entities;
using CidadeAlta.Domain.Repositories;

namespace CidadeAlta.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(CidadeAltaContext context)
            : base(context)
        {
        }

        public User? Find(string username)
        {
            var user = GetAll()
                .Where(u => u.UserName.Equals(username))
                .SingleOrDefault();

            return user;
        }
    }
}
