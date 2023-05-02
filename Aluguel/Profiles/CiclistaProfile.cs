using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Data.Dtos.Passaporte;
using Aluguel.Models;
using Aluguel.Models.Entidades;
using AutoMapper;

namespace Aluguel.Profiles
{
    public class CiclistaProfile : Profile 
    { 
        public CiclistaProfile()
        {
            CreateMap<CreatePassaporteDto, Passaporte>()
                .ForMember(dst => dst.Pais, src => src.Ignore());            

            CreateMap<Passaporte, CreatePassaporteDto>();
            
            CreateMap<CreateCiclistaDto, Ciclista>()
                .ForMember(dst => dst.Cpf, src =>
                {
                    src.Condition(src => src.Cpf != null);
                    src.MapFrom(src => src.Cpf);
                })
                .ForMember(dst => dst.Passaporte, src =>
                {
                    src.Condition(src => src.Passaporte != null);
                    src.MapFrom(src => src.Passaporte);
                });

            CreateMap<CreateMeioDePagamentoDto, CartaoDeCredito>();

            CreateMap<ReadCiclistaDto, Ciclista>();

            CreateMap<Ciclista, ReadCiclistaDto>();
        }
    }
}