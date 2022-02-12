using Bogus;
using CursoOnline.Dominio._Base;
using CursoOnline.Dominio.Test._Builders;
using CursoOnline.Dominio.Test._Util;
using ExpectedObjects;
using System;
using Xunit;
using Xunit.Abstractions;

namespace CursoOnline.Dominio.Test.Curso
{
    public class CursoTest : IDisposable
    {
        /* Eu, equanto administrador, quero criar e editar cursos para que sejam abertas matriculas para o mesmo.
         * 
         * Critérios de aceite:
         * - Criar um curso com Nome, Carga Horária, Publico Alvo, Valor do Curso;
         * - As opções para público alvo são: Estudante, Universitário, Empregado, Empreendedor;
         * - Todos os campos do curso são obrigatórios;
         * - Curso deve ter uma descrição
         */
        private readonly ITestOutputHelper _output;
        private readonly string _nome;
        private readonly double _carga;
        private readonly Dominio.Cursos.PublicoAlvo _publico;
        private readonly double _valor;
        private readonly string _descricao;

        public CursoTest(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("----- CONSTRUTOR SENDO EXECUTADO -----");

            var faker = new Faker();

            _nome = faker.Random.Word();
            _carga = faker.Random.Double(50,100);
            _publico = Dominio.Cursos.PublicoAlvo.Estudante;
            _valor = faker.Random.Double(1000, 2000);
            _descricao = faker.Lorem.Paragraph();
                        
            _output.WriteLine($"Nome: {_nome}");
            _output.WriteLine($"CargaHoraria: {_carga}");
            _output.WriteLine($"Valor: {_valor}");
            _output.WriteLine($"Descr: {_descricao}");
        }

        public void Dispose()
        {
            _output.WriteLine("----- DISPOSE SENDO EXECUTADO -----");
        }

        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = _nome,
                Carga = _carga,
                Publico = _publico,
                Valor = _valor,
                Descricao = _descricao
            };

            var curso = new Cursos.Curso(cursoEsperado.Nome, cursoEsperado.Carga, cursoEsperado.Publico, cursoEsperado.Valor, cursoEsperado.Descricao);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);

        }

        [Fact]
        public void NaoDeveCursoTerUmNomeVazio()
        {
            var cursoEsperado = new
            {
                Nome = "Informatica Basica",
                Carga = (double)80,
                Publico = Dominio.Cursos.PublicoAlvo.Estudante,
                Valor = (double)950,
                Descricao = _descricao
            };

            Assert.Throws<ExcecaoDeDominio>(() =>
                new Cursos.Curso(string.Empty, cursoEsperado.Carga, cursoEsperado.Publico, cursoEsperado.Valor, cursoEsperado.Descricao));
        }

        [Fact]
        public void NaoDeveCursoTerUmNomeNullo()
        {
            var cursoEsperado = new
            {
                Nome = "Informatica Basica",
                Carga = (double)80,
                Publico = Dominio.Cursos.PublicoAlvo.Estudante,
                Valor = (double)950,
                Descricao = _descricao
            };

            Assert.Throws<ExcecaoDeDominio>(() =>
                new Cursos.Curso(null, cursoEsperado.Carga, cursoEsperado.Publico, cursoEsperado.Valor, cursoEsperado.Descricao));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerUmNomeInvalido(string nomeInvalido)
        {
            Assert.Throws<ExcecaoDeDominio>(() =>
                CursoBuilder.Novo().ComNome(nomeInvalido).Build())
                .ComMensagem(Resource.NomeInvalido);
        }

        [Fact]
        public void NaoDeveCursoTerUmaCargaHorariaMenorQue1()
        {
            var cursoEsperado = new
            {
                Nome = "Informatica Basica",
                Carga = (double)80,
                Publico = Dominio.Cursos.PublicoAlvo.Estudante,
                Valor = (double)950,
                Descricao = _descricao
            };

            Assert.Throws<ExcecaoDeDominio>(() =>
                new Cursos.Curso(cursoEsperado.Nome, 0, cursoEsperado.Publico, cursoEsperado.Valor, cursoEsperado.Descricao));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaCargaHorariaMenorQue(int cargaInvalida)
        {
            Assert.Throws<ExcecaoDeDominio>(() =>
                CursoBuilder.Novo().ComCarga(cargaInvalida).Build())
                .ComMensagem("Carga horária inválida");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmValorMenorQue1(double valorInvalido)
        {
            Assert.Throws<ExcecaoDeDominio>(() =>
                CursoBuilder.Novo().ComValor(valorInvalido).Build())
                .ComMensagem("Valor inválido");
        }

        [Fact]
        public void DeveAlterarNome()
        {
            var nomeEsperado = "Jose";
            var curso = CursoBuilder.Novo().Build();
            curso.AlterarNome(nomeEsperado);

            Assert.Equal(nomeEsperado, curso.Nome);

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveAlterarComNomeinvalido(string nomeInvalido)
        {
            var curso = CursoBuilder.Novo().Build();

            Assert.Throws<ExcecaoDeDominio>(() => curso.AlterarNome(nomeInvalido)).ComMensagem(Resource.NomeInvalido);
        }

        [Fact]
        public void DeveAlterarCargaHoraria()
        {
            var cargaHorariaEsperada = 20.5;
            var curso = CursoBuilder.Novo().Build();

            curso.AlterarCargaHoraria(cargaHorariaEsperada);

            Assert.Equal(cargaHorariaEsperada, curso.Carga);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveAlterarComCargaHorariaInvalida(double cargaHorariaInvalida)
        {
            var curso = CursoBuilder.Novo().Build();

            Assert.Throws<ExcecaoDeDominio>(() => curso.AlterarCargaHoraria(cargaHorariaInvalida))
                .ComMensagem(Resource.CargaHorariaInvalida);
        }

        [Fact]
        public void DeveAlterarValor()
        {
            var valorEsperado = 234.99;
            var curso = CursoBuilder.Novo().Build();

            curso.AlterarValor(valorEsperado);

            Assert.Equal(valorEsperado, curso.Valor);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveAlterarComValorInvalido(double valorInvalido)
        {
            var curso = CursoBuilder.Novo().Build();

            Assert.Throws<ExcecaoDeDominio>(() => curso.AlterarValor(valorInvalido))
                .ComMensagem(Resource.ValorInvalido);
        }
    }
}
