using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Data.Dtos.Passaporte;
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

            CreateMap<Passaporte, CreatePassaporteDto>()
                .ForMember(dst => dst.Pais, opt => {
                    opt.MapFrom(src => src.Pais.Codigo.ToLower());
                });
            
            CreateMap<CreateCiclistaDto, Ciclista>()
                .ForMember(dst => dst.Cpf, opt =>
                {
                    opt.Condition(src => src.Cpf != null);
                    opt.MapFrom(src => src.Cpf);
                })
                .ForMember(dst => dst.Passaporte, opt =>
                {
                    opt.Condition(src => src.Passaporte != null);
                    opt.MapFrom(src => src.Passaporte);
                });

            CreateMap<CreateMeioDePagamentoDto, CartaoDeCredito>();

            CreateMap<ReadCiclistaDto, Ciclista>();

            CreateMap<Ciclista, CreateCiclistaDto>()                
                .ForMember(dst => dst.Cpf, opt =>
                {
                    opt.Condition(src => src.Cpf != null);
                    opt.MapFrom(src => src.Cpf);
                })
                .ForMember(dst => dst.Passaporte, opt =>
                {
                    opt.Condition(src => src.Passaporte != null);
                    opt.MapFrom(src => src.Passaporte);                        
                })
                .ForMember(dst => dst.ConfirmaSenha, opt => 
                           opt.MapFrom(src => src.Senha)); 

            CreateMap<CartaoDeCredito, CreateMeioDePagamentoDto>();                

            CreateMap<Ciclista, ReadCiclistaDto>();
        }
    }
}