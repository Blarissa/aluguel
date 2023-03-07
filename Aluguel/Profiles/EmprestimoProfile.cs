using Aluguel.Data.Dtos;
using Aluguel.Models;
using AutoMapper;

namespace Aluguel.Profiles
{
    public class EmprestimoProfile : Profile
    {
        public EmprestimoProfile()
        {
            CreateMap<CreateEmprestimoDto, Emprestimo>();
        }
    }
}
