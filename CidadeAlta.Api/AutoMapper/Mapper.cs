using AutoMapper;
using CidadeAlta.Domain.Entities;
using CidadeAlta.Domain.ViewModel;

namespace CidadeAlta.Api.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CriminalCode, CriminalCodeViewModel>();
            CreateMap<Status, StatusViewModel>();
        }
    }
}
