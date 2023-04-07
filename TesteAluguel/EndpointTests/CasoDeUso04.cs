using Aluguel.Controllers;
using Aluguel.Data;
using Aluguel.Data.Dao.Devolucao;
using Aluguel.Data.Dtos.Devolucao;
using Aluguel.Handlers.Devolucoes;
using Aluguel.Models.Entidades;
using Aluguel.Repositorios;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteAluguel.ApiFake;
using TesteAluguel.ApiFakes.Equipamento;
using TesteAluguel.RepositoriosFakes;

namespace TesteAluguel.EndpointTests
{
    public class CasoDeUso04
    {

        [Fact(DisplayName = "CT01")]
        public async void TestarComBicicletaValidaETrancaValida()
        {
            //Arrange
            Guid idBike = new("c239e318-4a5c-493f-acce-f9e0dee5a96b");
            Guid idTranca = new("db4af3c7-12fc-44fe-85b1-03732e851c84");

            //Criacao do banco isolado
            var optionsBanco = new DbContextOptionsBuilder<AluguelContexto>().UseInMemoryDatabase("TesteAluguelContexto1").Options;
            AluguelContexto store = new AluguelContexto(optionsBanco);

            //alimentar banco de dados======================================================
            Ciclista ciclista = new Ciclista() {
                Id = new Guid("123e4567-e89b-12d3-a456-426614174000"),
                Nome = "Nome",
                DataNascimento = new DateTime(2020,10,06),
                Email = "email@email",
                Senha = "password",
                UrlFotoDocumento = new Uri("https://www.SomeValidURI.co"),
                Cpf= "01254875895"

            };

            CartaoDeCredito cartaoDeCredito= new CartaoDeCredito() {
                Id = new Guid("654e4567-e89b-12d3-a456-426614174000"),
                CiclistaId= new Guid("123e4567-e89b-12d3-a456-426614174000"),
                Numero = "12341234123412341234",
                Nome = "Nome Titular",
                MesValidade = 3,
                AnoValidade = 2024,
                CodigoSeguranca = 111,
            };

            Emprestimo emprestimo = new Emprestimo() {
                Id = new Guid("abcaf3c7-12fc-44fe-85b1-03732e851c84"),
                DataHora = new DateTime(2023,03,20,20,00,00),
                Valor = 50,
                CartaoDeCreditoId= new Guid("654e4567-e89b-12d3-a456-426614174000"),
                CiclistaId= new Guid("123e4567-e89b-12d3-a456-426614174000"),
                BicicletaId = idBike,
                TrancaId = idTranca,
            };

            store.Ciclistas.Add(ciclista);
            store.CartoesDeCredito.Add(cartaoDeCredito);
            store.Emprestimos.Add(emprestimo);
            store.SaveChanges();
            //==============================================================================

            //Inicializacao do repo com a base isolada
            DevolucaoRepository repo = new(store);

            //Servico Equipamento
            var equipamentoDouble = new EquipamentoDoubleTrancaCadastradaLivreEBicicletaCadastradaEmUso();

            //Nao utilizado nesse cenario
            var externoDouble = new ExternoDouble();


            var endpointDevolucao = new DevolucaoController(repo, externoDouble, equipamentoDouble);

            //Act
            PostDevolucaoDto entradaMock = new PostDevolucaoDto() {
                IdBicicleta = idBike,
                IdTranca= idTranca,
            };
            RealizaDevolucaoHandler handler = new(repo,externoDouble, equipamentoDouble);

            var retorno = await endpointDevolucao.PostDevolucao(entradaMock, handler);

            //Assert
            Assert.IsType<OkObjectResult>(retorno);
            store.Database.EnsureDeleted();
        }

        [Fact(DisplayName = "CT02", Skip = "O controlador contempla esse CT automaticamente em validacao de tipo. Impossivel inicializar com tipo divergente")]
        public async void TestarComBicicletaForaDeFormatoETrancaValida()
        {
            //Arrange
            string idBike = "bikeInvalida";
            Guid idTranca = new("db4af3c7-12fc-44fe-85b1-03732e851c84");

            var optionsBanco = new DbContextOptionsBuilder<AluguelContexto>().UseInMemoryDatabase("TesteAluguelContexto1").Options;
            AluguelContexto store = new AluguelContexto(optionsBanco);

            DevolucaoRepository repo = new(store);

            //Servico Equipamento
            var equipamentoDouble = new EquipamentoDoubleTrancaCadastradaLivreEBicicletaCadastradaEmUso();

            //Nao utilizado nesse cenario
            var externoDouble = new ExternoDouble();


            var endpointDevolucao = new DevolucaoController(repo, externoDouble, equipamentoDouble);

            //Act
            var entradaMock = new {
                IdBicicleta = idBike,
                IdTranca= idTranca,
            };
            RealizaDevolucaoHandler handler = new(repo,externoDouble, equipamentoDouble);

            //Tentativa de inserir um tipo de dado invalido
            //var retorno = await endpointDevolucao.PostDevolucao((PostDevolucaoDto) entradaMock, handler);

            //Assert
            //Assert.IsType<OkObjectResult>(retorno);
            store.Database.EnsureDeleted();
        }

        [Fact(DisplayName = "CT03",Skip = "O controlador contempla esse CT automaticamente em validacao de tipo. Impossivel inicializar com tipo divergente")]
        public void TestarComBicicletaValidaETrancaForaDeFormato()
        {
            //Arrange
            Guid idBike = new("c239e318-4a5c-493f-acce-f9e0dee5a96b");
            string idTranca = "trancaInvalida";
            var optionsBanco = new DbContextOptionsBuilder<AluguelContexto>().UseInMemoryDatabase("TesteAluguelContexto1").Options;
            AluguelContexto store = new AluguelContexto(optionsBanco);

            DevolucaoRepository repo = new(store);

            //Servico Equipamento
            var equipamentoDouble = new EquipamentoDoubleTrancaCadastradaLivreEBicicletaCadastradaEmUso();

            //Nao utilizado nesse cenario
            var externoDouble = new ExternoDouble();


            var endpointDevolucao = new DevolucaoController(repo, externoDouble, equipamentoDouble);

            //Act
            var entradaMock = new {
                IdBicicleta = idBike,
                IdTranca= idTranca,
            };
            RealizaDevolucaoHandler handler = new(repo,externoDouble, equipamentoDouble);

            //Tentativa de inserir um tipo de dado invalido
            //var retorno = await endpointDevolucao.PostDevolucao((PostDevolucaoDto) entradaMock, handler);

            //Assert
            //Assert.IsType<OkObjectResult>(retorno);
            store.Database.EnsureDeleted();
        }

        [Fact(DisplayName = "CT04")]
        public async void TestarComBicicletaInvalidaETrancaValida()
        {
            //Arrange
            Guid idBike = new("72e6a3e2-fd79-4163-a6bf-8ef2b7d8b735");
            Guid idTranca = new("db4af3c7-12fc-44fe-85b1-03732e851c84");

            //Criacao do banco isolado
            var optionsBanco = new DbContextOptionsBuilder<AluguelContexto>().UseInMemoryDatabase("TesteAluguelContexto4").Options;
            AluguelContexto store = new AluguelContexto(optionsBanco);

            //alimentar banco de dados======================================================
            Ciclista ciclista = new Ciclista() {
                Id = new Guid("123e4567-e89b-12d3-a456-426614174000"),
                Nome = "Nome",
                DataNascimento = new DateTime(2020,10,06),
                Email = "email@email",
                Senha = "password",
                UrlFotoDocumento = new Uri("https://www.SomeValidURI.co"),
                Cpf= "01254875895"

            };

            CartaoDeCredito cartaoDeCredito= new CartaoDeCredito() {
                Id = new Guid("654e4567-e89b-12d3-a456-426614174000"),
                CiclistaId= new Guid("123e4567-e89b-12d3-a456-426614174000"),
                Numero = "12341234123412341234",
                Nome = "Nome Titular",
                MesValidade = 3,
                AnoValidade = 2024,
                CodigoSeguranca = 111,
            };

            Emprestimo emprestimo = new Emprestimo() {
                Id = new Guid("abcaf3c7-12fc-44fe-85b1-03732e851c84"),
                DataHora = new DateTime(2023,03,20,20,00,00),
                Valor = 50,
                CartaoDeCreditoId= new Guid("654e4567-e89b-12d3-a456-426614174000"),
                CiclistaId= new Guid("123e4567-e89b-12d3-a456-426614174000"),
                BicicletaId = idBike,
                TrancaId = idTranca,
            };

            store.Ciclistas.Add(ciclista);
            store.CartoesDeCredito.Add(cartaoDeCredito);
            store.Emprestimos.Add(emprestimo);
            store.SaveChanges();
            //==============================================================================

            //Inicializacao do repo com a base isolada
            DevolucaoRepository repo = new(store);

            //Servico Equipamento
            var equipamentoDouble = new EquipamentoDoubleTrancaCadastradaLivreEBicicletaSemCadastro();

            //Nao utilizado nesse cenario
            var externoDouble = new ExternoDouble();

            var endpointDevolucao = new DevolucaoController(repo, externoDouble, equipamentoDouble);

            //Act
            PostDevolucaoDto entradaMock = new PostDevolucaoDto() {
                IdBicicleta = idBike,
                IdTranca= idTranca,
            };
            RealizaDevolucaoHandler handler = new(repo,externoDouble, equipamentoDouble);

            var retorno = await endpointDevolucao.PostDevolucao(entradaMock, handler);

            //Assert
            Assert.IsType<NotFoundObjectResult>(retorno);
            store.Database.EnsureDeleted();
        }

        [Fact(DisplayName = "CT05")]
        public async void TestarComBicicletaValidaETrancaInvalida()
        {
            //Arrange
            Guid idBike = new("c239e318-4a5c-493f-acce-f9e0dee5a96b");
            Guid idTranca = new("71245d6b-680a-4da2-8873-48aae4c7a64a");

            var optionsBanco = new DbContextOptionsBuilder<AluguelContexto>().UseInMemoryDatabase("TesteAluguelContexto5").Options;
            AluguelContexto store = new AluguelContexto(optionsBanco);

            //alimentar banco de dados======================================================
            Ciclista ciclista = new Ciclista() {
                Id = new Guid("123e4567-e89b-12d3-a456-426614174000"),
                Nome = "Nome",
                DataNascimento = new DateTime(2020,10,06),
                Email = "email@email",
                Senha = "password",
                UrlFotoDocumento = new Uri("https://www.SomeValidURI.co"),
                Cpf= "01254875895"

            };

            CartaoDeCredito cartaoDeCredito= new CartaoDeCredito() {
                Id = new Guid("654e4567-e89b-12d3-a456-426614174000"),
                CiclistaId= new Guid("123e4567-e89b-12d3-a456-426614174000"),
                Numero = "12341234123412341234",
                Nome = "Nome Titular",
                MesValidade = 3,
                AnoValidade = 2024,
                CodigoSeguranca = 111,
            };

            Emprestimo emprestimo = new Emprestimo() {
                Id = new Guid("abcaf3c7-12fc-44fe-85b1-03732e851c84"),
                DataHora = new DateTime(2023,03,20,20,00,00),
                Valor = 50,
                CartaoDeCreditoId= new Guid("654e4567-e89b-12d3-a456-426614174000"),
                CiclistaId= new Guid("123e4567-e89b-12d3-a456-426614174000"),
                BicicletaId = idBike,
                TrancaId = idTranca,
            };

            store.Ciclistas.Add(ciclista);
            store.CartoesDeCredito.Add(cartaoDeCredito);
            store.Emprestimos.Add(emprestimo);
            store.SaveChanges();
            //==============================================================================

            //Inicializacao do repo com a base isolada
            DevolucaoRepository repo = new(store);

            //Servico Equipamento
            var equipamentoDouble = new EquipamentoDoubleTrancaSemCadastroEBicicletaCadastradaEmUso();

            //Nao utilizado nesse cenario
            var externoDouble = new ExternoDouble();

            var endpointDevolucao = new DevolucaoController(repo, externoDouble, equipamentoDouble);

            //Act
            PostDevolucaoDto entradaMock = new PostDevolucaoDto() {
                IdBicicleta = idBike,
                IdTranca= idTranca,
            };
            RealizaDevolucaoHandler handler = new(repo,externoDouble, equipamentoDouble);

            var retorno = await endpointDevolucao.PostDevolucao(entradaMock, handler);

            //Assert
            Assert.IsType<NotFoundObjectResult>(retorno);
            store.Database.EnsureDeleted();
        }

        [Fact(DisplayName = "CT06")]
        public async void TestarComBicicletaSemUsoETrancaValida()
        {
            //Arrange
            Guid idBike = new("d8c2094a-c872-11ed-afa1-0242ac120002");
            Guid idTranca = new("71245d6b-680a-4da2-8873-48aae4c7a64a");

            var optionsBanco = new DbContextOptionsBuilder<AluguelContexto>().UseInMemoryDatabase("TesteAluguelContexto6").Options;
            AluguelContexto store = new AluguelContexto(optionsBanco);

            //alimentar banco de dados======================================================
            Ciclista ciclista = new Ciclista() {
                Id = new Guid("123e4567-e89b-12d3-a456-426614174000"),
                Nome = "Nome",
                DataNascimento = new DateTime(2020,10,06),
                Email = "email@email",
                Senha = "password",
                UrlFotoDocumento = new Uri("https://www.SomeValidURI.co"),
                Cpf= "01254875895"

            };

            CartaoDeCredito cartaoDeCredito= new CartaoDeCredito() {
                Id = new Guid("654e4567-e89b-12d3-a456-426614174000"),
                CiclistaId= new Guid("123e4567-e89b-12d3-a456-426614174000"),
                Numero = "12341234123412341234",
                Nome = "Nome Titular",
                MesValidade = 3,
                AnoValidade = 2024,
                CodigoSeguranca = 111,
            };

            Emprestimo emprestimo = new Emprestimo() {
                Id = new Guid("abcaf3c7-12fc-44fe-85b1-03732e851c84"),
                DataHora = new DateTime(2023,03,20,20,00,00),
                Valor = 50,
                CartaoDeCreditoId= new Guid("654e4567-e89b-12d3-a456-426614174000"),
                CiclistaId= new Guid("123e4567-e89b-12d3-a456-426614174000"),
                BicicletaId = idBike,
                TrancaId = idTranca,
            };

            store.Ciclistas.Add(ciclista);
            store.CartoesDeCredito.Add(cartaoDeCredito);
            store.Emprestimos.Add(emprestimo);
            store.SaveChanges();
            //==============================================================================

            //Inicializacao do repo com a base isolada
            DevolucaoRepository repo = new(store);

            //Servico Equipamento
            var equipamentoDouble = new EquipamentoDoubleTrancaCadastradaLivreEBicicletaCadastradaNova();

            //Nao utilizado nesse cenario
            var externoDouble = new ExternoDouble();

            var endpointDevolucao = new DevolucaoController(repo, externoDouble, equipamentoDouble);

            //Act
            PostDevolucaoDto entradaMock = new PostDevolucaoDto() {
                IdBicicleta = idBike,
                IdTranca= idTranca,
            };
            RealizaDevolucaoHandler handler = new(repo,externoDouble, equipamentoDouble);

            var retorno = await endpointDevolucao.PostDevolucao(entradaMock, handler);

            //Assert
            Assert.IsType<UnprocessableEntityObjectResult>(retorno);
            store.Database.EnsureDeleted();
        }

        [Fact(DisplayName = "CT07")]
        public async void TestarComBicicletaValidaETrancaNaoCadastrada()
        {
            //Arrange
            Guid idBike = new("c239e318-4a5c-493f-acce-f9e0dee5a96b");
            Guid idTranca = new("0c82f73a-c873-11ed-afa1-0242ac120002");
            var optionsBanco = new DbContextOptionsBuilder<AluguelContexto>().UseInMemoryDatabase("TesteAluguelContexto7").Options;
            AluguelContexto store = new AluguelContexto(optionsBanco);

            //alimentar banco de dados======================================================
            Ciclista ciclista = new Ciclista() {
                Id = new Guid("123e4567-e89b-12d3-a456-426614174000"),
                Nome = "Nome",
                DataNascimento = new DateTime(2020,10,06),
                Email = "email@email",
                Senha = "password",
                UrlFotoDocumento = new Uri("https://www.SomeValidURI.co"),
                Cpf= "01254875895"

            };

            CartaoDeCredito cartaoDeCredito= new CartaoDeCredito() {
                Id = new Guid("654e4567-e89b-12d3-a456-426614174000"),
                CiclistaId= new Guid("123e4567-e89b-12d3-a456-426614174000"),
                Numero = "12341234123412341234",
                Nome = "Nome Titular",
                MesValidade = 3,
                AnoValidade = 2024,
                CodigoSeguranca = 111,
            };

            Emprestimo emprestimo = new Emprestimo() {
                Id = new Guid("abcaf3c7-12fc-44fe-85b1-03732e851c84"),
                DataHora = new DateTime(2023,03,20,20,00,00),
                Valor = 50,
                CartaoDeCreditoId= new Guid("654e4567-e89b-12d3-a456-426614174000"),
                CiclistaId= new Guid("123e4567-e89b-12d3-a456-426614174000"),
                BicicletaId = idBike,
                TrancaId = idTranca,
            };

            store.Ciclistas.Add(ciclista);
            store.CartoesDeCredito.Add(cartaoDeCredito);
            store.Emprestimos.Add(emprestimo);
            store.SaveChanges();
            //==============================================================================

            //Inicializacao do repo com a base isolada
            DevolucaoRepository repo = new(store);

            //Servico Equipamento
            var equipamentoDouble = new EquipamentoDoubleTrancaCadastradaOcupadaEBicicletaCadastradaEmUso();

            //Nao utilizado nesse cenario
            var externoDouble = new ExternoDouble();

            var endpointDevolucao = new DevolucaoController(repo, externoDouble, equipamentoDouble);

            //Act
            PostDevolucaoDto entradaMock = new PostDevolucaoDto() {
                IdBicicleta = idBike,
                IdTranca= idTranca,
            };
            RealizaDevolucaoHandler handler = new(repo,externoDouble, equipamentoDouble);

            var retorno = await endpointDevolucao.PostDevolucao(entradaMock, handler);

            //Assert
            Assert.IsType<UnprocessableEntityObjectResult>(retorno);
            store.Database.EnsureDeleted();
        }
    }
}
