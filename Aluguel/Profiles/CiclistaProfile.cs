using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Models;
using AutoMapper;

namespace Aluguel.Profiles
{
    public class CiclistaProfile : Profile 
    { 
        public CiclistaProfile()
        {
            CreateMap<PaisDto, Pais>();

            CreateMap<Pais, PaisDto>();

            CreateMap<CreatePassaporteDto, Passaporte>();
            
            CreateMap<PassaporteDto, Passaporte>();

            CreateMap<Passaporte, PassaporteDto>();
            
            CreateMap<CreateCiclistaDto, Ciclista>();

            CreateMap<CreateMeioDePagamentoDto, CartaoDeCredito>();

            CreateMap<CiclistaDto, Ciclista>();

            CreateMap<Ciclista, CiclistaDto>();
        }
    }
}