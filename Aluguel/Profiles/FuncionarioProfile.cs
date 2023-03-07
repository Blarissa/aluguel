using Aluguel.Data.Dtos;
using Aluguel.Models;
using AutoMapper;

namespace Aluguel.Profiles
{
    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile()
        {
            CreateMap<Funcionario, ReadFuncionarioDto>();
            CreateMap<CreateFuncionarioDto, Funcionario>();
            CreateMap<UpdateFuncionarioDto, Funcionario>();
        }
    }
}
