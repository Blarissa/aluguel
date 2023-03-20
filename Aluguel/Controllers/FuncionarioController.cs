﻿using Aluguel.Data;
using Aluguel.Data.Dao;
using Aluguel.Data.Dtos;
using Aluguel.Migrations;
using Aluguel.Models;
using Aluguel.Validacao;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aluguel.Controllers
{
    [Tags("Aluguel")]
    [ApiController]
    [Route("[controller]")]   
    public class FuncionarioController : ControllerBase
    {
        private AluguelContexto contexto;
        private FuncionarioDao funcionarioDao;
        private IMapper mapper;

        public FuncionarioController(AluguelContexto contexto, IMapper mapper)
        {
            this.contexto = contexto;
            funcionarioDao = new FuncionarioDao(contexto);
            this.mapper = mapper;            
        }

        /// <summary>
        /// Recupera funcionários cadastrados
        /// </summary>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ReadFuncionarioDto))]        
        public IActionResult RecuperaFuncionarios()
        {
            var funcionarios = mapper.Map<List<ReadFuncionarioDto>>
                (funcionarioDao.RecuperaTodosFuncionarios());

            return Ok(funcionarios);
        }


        /// <summary>
        /// Recupera funcionário
        /// </summary>
        [HttpGet("{idFuncionario}")]
        [ProducesResponseType(200, Type = typeof(ReadFuncionarioDto))]
        [ProducesResponseType(422, Type = typeof(List<Erro>))]
        [ProducesResponseType(404, Type = typeof(List<Erro>))]
        public IActionResult RecuperaFuncionarioPorId(int idFuncionario)
        {          
            var funcionario = funcionarioDao.RecuperaFuncionarioPorId(idFuncionario);

            if (funcionario == null)
                return NotFound(new Erro("000a", "Funcionário não encontrado"));

            var funcionarioDto = mapper.Map<ReadFuncionarioDto>(funcionario);

            return Ok(funcionarioDto);
        }


        /// <summary>
        /// Cadastrar funcionário
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Funcionario))]
        [ProducesResponseType(422, Type = typeof(List<Erro>))]
        [ProducesResponseType(404, Type = typeof(List<Erro>))]
        public IActionResult AdicionaFuncionario([FromBody] CreateFuncionarioDto funcionarioDto)
        {
            var funcionario = mapper.Map<Funcionario>(funcionarioDto);

            funcionarioDao.AdicionaFuncionario(funcionario);
           
            return Ok(funcionario);
        }

        /// <summary>
        /// Editar funcionário
        /// </summary>
        [HttpPut("{idFuncionario}")]
        [ProducesResponseType(200, Type = typeof(Funcionario))]
        [ProducesResponseType(422, Type = typeof(List<Erro>))]
        [ProducesResponseType(404, Type = typeof(List<Erro>))]
        public IActionResult AtualizaFuncionario(int idFuncionario, 
            [FromBody] UpdateFuncionarioDto funcionarioDto)
        {           
            var funcionario = funcionarioDao
                .RecuperaFuncionarioPorId(idFuncionario);

            if (funcionario == null)
                return NotFound(new Erro("000a", "Funcionário não encontrado"));
            
            mapper.Map(funcionarioDto, funcionario);
            contexto.SaveChanges();
         
            return Ok(funcionario);
        }

        /// <summary>
        /// Remover funcionário
        /// </summary>
        [HttpDelete("{idFuncionario}")]
        [ProducesResponseType(200, Type = typeof(Funcionario))]
        [ProducesResponseType(422, Type = typeof(List<Erro>))]
        [ProducesResponseType(404, Type = typeof(List<Erro>))]
        public IActionResult DeletaFuncionario(int idFuncionario)
        {                        
            var funcionario = funcionarioDao.RecuperaFuncionarioPorId(idFuncionario);

            if (funcionario == null)
                return NotFound(new Erro("000a", "Funcionário não encontrado"));

            funcionarioDao.DeletaFuncionario(funcionario);
                
            return Ok(funcionario);            
        }
    }
}
