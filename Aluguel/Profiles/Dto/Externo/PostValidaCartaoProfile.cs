using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Servicos.Externo;
using AutoMapper;

namespace Aluguel.Profiles.Dto.Externo
{
    public class PostValidaCartaoProfile : Profile
    {
        public PostValidaCartaoProfile()
        {
            CreateMap<UpdateCartaoDeCreditoDto, PostValidaCartaoDto>()
                .ForMember(dest => dest.NomeTitular, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Cvv, opt => opt.MapFrom(src => src.CodigoSeguranca));

        }
    }
}
