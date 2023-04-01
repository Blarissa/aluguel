using Aluguel.Data;
using Aluguel.Data.Dao;
using Aluguel.Data.Dtos;
using Aluguel.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aluguel.Controllers
{   
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    [Tags("Aluguel")]    
    public class FuncionarioController : ControllerBase
    {
        private AluguelContexto contexto;
        private IDaoComInt<Funcionario> funcionarioDao;
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
        /// <response code="200">200 OK</response>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ReadFuncionarioDto>))]        
        public IActionResult RecuperaFuncionarios()
        {
            try
            {
                var funcionarios = mapper.Map<List<ReadFuncionarioDto>>
                    (funcionarioDao.RecuperarTodos());

                return Ok(funcionarios);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Recupera funcionário
        /// </summary>
        /// <response code="200">Dados recuperados</response>
        /// <response code="422">Dados inválidos</response>
        /// <response code="404">Não encontrado</response>

        [HttpGet("{idFuncionario}")]
        [ProducesResponseType(200, Type = typeof(ReadFuncionarioDto))]
        [ProducesResponseType(422, Type = typeof(List<Erro>))]
        [ProducesResponseType(404, Type = typeof(Erro))]
        public IActionResult RecuperaFuncionarioPorId(int idFuncionario)
        {
            try
            {
                var funcionario = funcionarioDao.RecuperarPorId(idFuncionario);

                if (funcionario == null)
                    return NotFound(new Erro("000a", "Funcionário não encontrado"));

                var funcionarioDto = mapper.Map<ReadFuncionarioDto>(funcionario);

                return Ok(funcionarioDto);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Cadastrar funcionário
        /// </summary>
        /// <response code="200">Dados cadastrados</response>
        /// <response code="422">Dados Inválidos</response>

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ReadFuncionarioDto))]
        [ProducesResponseType(422, Type = typeof(List<Erro>))]
        public IActionResult AdicionaFuncionario([FromBody, Required] CreateFuncionarioDto funcionarioDto)
        {
            try
            {
                var funcionario = mapper.Map<Funcionario>(funcionarioDto);

                funcionarioDao.Adicionar(funcionario);
           
                return Ok(funcionario);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Editar funcionário
        /// </summary>
        /// <response code="200">Dados atualizados</response>
        /// <response code="422">Dados Inválidos</response>
        /// <response code="404">Não encontrado</response>

        [HttpPut("{idFuncionario}")]
        [ProducesResponseType(200, Type = typeof(ReadFuncionarioDto))]
        [ProducesResponseType(422, Type = typeof(List<Erro>))]
        [ProducesResponseType(404, Type = typeof(Erro))]
        public IActionResult AtualizaFuncionario(int idFuncionario, 
            [FromBody, Required] UpdateFuncionarioDto funcionarioDto)
        {               
            try
            {
                var funcionario = funcionarioDao
                .RecuperarPorId(idFuncionario);

                if (funcionario == null)
                    return NotFound(new Erro("000a", "Funcionário não encontrado"));

                mapper.Map(funcionarioDto, funcionario);
                contexto.SaveChanges();

                return Ok(funcionario);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        /// <summary>
        /// Remover funcionário
        /// </summary>
        /// <response code="200">Dados removidos</response>
        /// <response code="422">Dados Inválidos</response>
        /// <response code="404">Não encontrado</response>

        [HttpDelete("{idFuncionario}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(422, Type = typeof(List<Erro>))]
        [ProducesResponseType(404, Type = typeof(Erro))]
        public IActionResult DeletaFuncionario(int idFuncionario)
        {
            try
            {
                var funcionario = funcionarioDao.RecuperarPorId(idFuncionario);

                if (funcionario == null)
                    return NotFound(new Erro("000a", "Funcionário não encontrado"));

                funcionarioDao.Deletar(funcionario);
                
                return Ok(funcionario);            
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
