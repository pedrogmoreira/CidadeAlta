using CidadeAlta.Domain.DTO;
using CidadeAlta.Domain.Entities;
using CidadeAlta.Domain.Filters;

namespace CidadeAlta.Domain.Repositories
{
    public interface ICriminalCodeRepository : IRepository<CriminalCode>
    {
        IEnumerable<CriminalCode> Get(int page, int paginationSize, CriminalCodesFilter criminalCodesFilter);
        void Update(CriminalCodeDTO criminalCodeViewModel, int userId);
        void Insert(CriminalCodeDTO criminalCodeViewModel, int userId);
    }
}
