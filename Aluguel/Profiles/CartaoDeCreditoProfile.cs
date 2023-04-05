using Aluguel.Data.Dtos.Cartao;
using Aluguel.Models.Entidades;
using AutoMapper;

namespace Aluguel.Profiles
{
    public class CartaoDeCreditoProfile : Profile
    {
        public CartaoDeCreditoProfile()
        {
            CreateMap<CartaoDeCredito,ReadCartaoDto>();
            CreateMap<UpdateCartaoDeCreditoDto, CartaoDeCredito>();
        }
    }
}
