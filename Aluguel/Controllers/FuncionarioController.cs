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
        private ValidacaoFuncionario validator;        

        public FuncionarioController(AluguelContexto contexto, IMapper mapper)
        {
            this.contexto = contexto;
            funcionarioDao = new FuncionarioDao(contexto);
            this.mapper = mapper;
            validator = new ValidacaoFuncionario(funcionarioDao);                       
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
            if (!validator.Matricula(idFuncionario))
                return UnprocessableEntity(validator.Erros);

            var funcionario = funcionarioDao.RecuperaFuncionarioPorId(idFuncionario);

            if (funcionario == null)
                return NotFound(new Erro() {
                    Codigo = 1, 
                    Mensagem = "Funcionário não encontrado!" 
                });            

            var funcionarioDto = mapper.Map<ReadFuncionarioDto>(funcionario);

            return Ok(funcionarioDto);
        }

        [HttpPost]
        public IActionResult AdicionaFuncionario([FromBody] CreateFuncionarioDto funcionarioDto)
        {
            if (!validator.IsValid(funcionarioDto))        
                return UnprocessableEntity(validator.Erros);            

            var funcionario = mapper.Map<Funcionario>(funcionarioDto);

            funcionarioDao.AdicionaFuncionario(funcionario);
           
            return Ok(funcionario);
        }

        [HttpPut("{idFuncionario}")]
        public IActionResult AtualizaFuncionario(int idFuncionario, [FromBody] UpdateFuncionarioDto funcionarioDto)
        {
            if (!(validator.Matricula(idFuncionario) &&
                validator.IsValid(funcionarioDto)))
                return UnprocessableEntity(validator.Erros);
            
            var funcionario = funcionarioDao
                .RecuperaFuncionarioPorId(idFuncionario);   
            
            if (funcionario == null)
                return NotFound(new Erro()
                {
                    Codigo = 1,
                    Mensagem = "Funcionário não encontrado!"
                });

            mapper.Map(funcionarioDto, funcionario);
            contexto.SaveChanges();

            return Ok(funcionario);
        }

        [HttpDelete("{idFuncionario}")]        
        public IActionResult DeletaFuncionario(int idFuncionario)
        {
            if (!validator.Matricula(idFuncionario))
                return UnprocessableEntity(validator.Erros);
            
            var funcionario = funcionarioDao.RecuperaFuncionarioPorId(idFuncionario);
            
            if (funcionario == null)
                return NotFound(new Erro()
                {
                    Codigo = 1,
                    Mensagem = "Funcionário não encontrado!"
                });            

            funcionarioDao.DeletaFuncionario(funcionario);
                
            return Ok(funcionario);            
        }
    }
}
