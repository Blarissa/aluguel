using Aluguel.Data;
using Aluguel.Data.Dao;
using Aluguel.Data.Dtos;
using Aluguel.Models;
using Aluguel.Validacao;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aluguel.Controllers
{
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

        [HttpGet]
        public IActionResult RecuperaFuncionarios()
        {
            var funcionarios = mapper.Map<List<ReadFuncionarioDto>>
                (funcionarioDao.RecuperaTodosFuncionarios());

            return Ok(funcionarios);
        }

        [HttpGet("{idFuncionario}")]
        public IActionResult RecuperaFuncionarioPorId(int idFuncionario)
        {          
            var funcionario = funcionarioDao.RecuperaFuncionarioPorId(idFuncionario);

            if (funcionario == null)
                return NotFound(new Erro("000a", "Funcionário não encontrado"));

            var funcionarioDto = mapper.Map<ReadFuncionarioDto>(funcionario);

            return Ok(funcionarioDto);
        }

        [HttpPost]
        public IActionResult AdicionaFuncionario([FromBody] CreateFuncionarioDto funcionarioDto)
        {
            var funcionario = mapper.Map<Funcionario>(funcionarioDto);

            funcionarioDao.AdicionaFuncionario(funcionario);
           
            return Ok(funcionario);
        }

        [HttpPut("{idFuncionario}")]
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

        [HttpDelete("{idFuncionario}")]        
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
