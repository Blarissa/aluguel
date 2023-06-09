﻿using Aluguel.Data.Dtos;
using Aluguel.Data.Dtos.Emprestimo;
using Aluguel.Models.Entidades;
using AutoMapper;

namespace Aluguel.Profiles
{
    public class EmprestimoProfile : Profile
    {
        public EmprestimoProfile()
        {
            CreateMap<ReadEmprestimoDto, Emprestimo>()
                .ForMember(dest => dest.BicicletaId, org => org.MapFrom(src => src.Bicicleta))
                .ForMember(dest => dest.DataHora, org => org.MapFrom(src => src.HoraInicio));
        }
    }
}
