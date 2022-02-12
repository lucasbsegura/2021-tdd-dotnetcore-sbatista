using Bogus;
using Bogus.Extensions.Brazil;
using CursoOnline.Dominio._Base;
using CursoOnline.Dominio.Alunos;
using CursoOnline.Dominio.PublicosAlvo;
using CursoOnline.Dominio.Test._Builders;
using CursoOnline.Dominio.Test._Util;
using Moq;
using Xunit;

namespace CursoOnline.Dominio.Test.Alunos
{
    public class ArmazenadorDeAlunoTest
    {
        private readonly Faker _faker;
        private readonly AlunoDTO _alunoDTO;
        private readonly ArmazenadorDeAluno _armazenadorDeAluno;
        private readonly Mock<IAlunoRepositorio> _alunoRepositorio;

        public ArmazenadorDeAlunoTest()
        {
            _faker = new Faker();
            _alunoDTO = new AlunoDTO
            {
                Nome = _faker.Person.FullName,
                Email = _faker.Person.Email,
                Cpf = _faker.Person.Cpf(),
                PublicoAlvo = Dominio.Cursos.PublicoAlvo.Empregado.ToString(),
            };
            _alunoRepositorio = new Mock<IAlunoRepositorio>();
            var conversorDePublicoAlvo = new Mock<IConversorDePublicoAlvo>();
            _armazenadorDeAluno = new ArmazenadorDeAluno(_alunoRepositorio.Object, conversorDePublicoAlvo.Object);
        }

        [Fact]
        public void DeveAdicionarAluno()
        {
            _armazenadorDeAluno.Armazenar(_alunoDTO);

            _alunoRepositorio.Verify(r => r.Adicionar(It.Is<Aluno>(a => a.Nome == _alunoDTO.Nome)));
        }

        [Fact]
        public void NaoDeveAdicionarAlunoQuandoCpfJaFoiCadastrado()
        {
            var alunoComMesmoCpf = AlunoBuilder.Novo().ComId(34).Build();
            _alunoRepositorio.Setup(r => r.ObterPeloCpf(_alunoDTO.Cpf)).Returns(alunoComMesmoCpf);

            Assert.Throws<ExcecaoDeDominio>(() => _armazenadorDeAluno.Armazenar(_alunoDTO))
                .ComMensagem(Resource.CpfJaCadastrado);
        }

        [Fact]
        public void DeveEditarNomeDoAluno()
        {
            _alunoDTO.Id = 35;
            _alunoDTO.Nome = _faker.Person.FullName;
            var alunoJaSalvo = AlunoBuilder.Novo().Build();
            _alunoRepositorio.Setup(r => r.ObterPorId(_alunoDTO.Id)).Returns(alunoJaSalvo);

            _armazenadorDeAluno.Armazenar(_alunoDTO);

            Assert.Equal(_alunoDTO.Nome, alunoJaSalvo.Nome);
        }

        [Fact]
        public void NaoDeveEditarDemaisInformacoesDoAluno()
        {
            _alunoDTO.Id = 35;
            var alunoJaSalvo = AlunoBuilder.Novo().Build();
            var cpfEsperado = alunoJaSalvo.Cpf;
            var emailEsperado = alunoJaSalvo.Email;
            var publicoAlvoEsperado = alunoJaSalvo.PublicoAlvo;
            _alunoRepositorio.Setup(r => r.ObterPorId(_alunoDTO.Id)).Returns(alunoJaSalvo);

            _armazenadorDeAluno.Armazenar(_alunoDTO);

            Assert.Equal(cpfEsperado, alunoJaSalvo.Cpf);
            Assert.Equal(emailEsperado, alunoJaSalvo.Email);
            Assert.Equal(publicoAlvoEsperado, alunoJaSalvo.PublicoAlvo);
        }

        [Fact]
        public void NaoDeveAdicionarQuandoForEdicao()
        {
            _alunoDTO.Id = 35;
            var alunoJaSalvo = AlunoBuilder.Novo().Build();
            _alunoRepositorio.Setup(r => r.ObterPorId(_alunoDTO.Id)).Returns(alunoJaSalvo);

            _armazenadorDeAluno.Armazenar(_alunoDTO);

            _alunoRepositorio.Verify(r => r.Adicionar(It.IsAny<Aluno>()), Times.Never);
        }
    }
}
