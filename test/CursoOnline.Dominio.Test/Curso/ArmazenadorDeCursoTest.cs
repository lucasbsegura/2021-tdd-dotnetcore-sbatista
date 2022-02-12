using Bogus;
using CursoOnline.Dominio._Base;
using CursoOnline.Dominio.PublicosAlvo;
using CursoOnline.Dominio.Test._Builders;
using CursoOnline.Dominio.Test._Util;
using Moq;
using Xunit;

namespace CursoOnline.Dominio.Test.Curso
{
    public class ArmazenadorDeCursoTest
    {
        private Cursos.CursoDTO _cursoDTO;
        private Cursos.ArmazenadorDeCurso _armazenadorDeCurso;
        private Mock<Cursos.ICursoRepositorio> _cursoRepositoryMock;
        public ArmazenadorDeCursoTest()
        {
            var fake = new Faker();

            _cursoDTO = new Cursos.CursoDTO
            {
                Nome = fake.Random.Words(),
                Carga = fake.Random.Double(50, 1000),
                Publico = "Estudante",
                Valor = fake.Random.Double(1000, 2000),
                Descricao = fake.Lorem.Paragraph()
            };

            _cursoRepositoryMock = new Mock<Cursos.ICursoRepositorio>();
            var conversorDePublicoAlvo = new Mock<IConversorDePublicoAlvo>();
            _armazenadorDeCurso = new Cursos.ArmazenadorDeCurso(_cursoRepositoryMock.Object, conversorDePublicoAlvo.Object);
        }

        [Fact]
        public void DeveAdicionarCurso()
        {
            _armazenadorDeCurso.Armazenar(_cursoDTO);
            _cursoRepositoryMock.Verify(r => r.Adicionar(
                                                It.Is<Cursos.Curso>(c =>
                                                                    c.Nome == _cursoDTO.Nome &&
                                                                    c.Descricao == _cursoDTO.Descricao)
                                                ));
        }

        [Fact]
        public void NaoDeveAdicionarCursoComNomeJaExistente()
        {
            var cursoJaSalvo = CursoBuilder.Novo().ComId(432).ComNome(_cursoDTO.Nome).Build();
            _cursoRepositoryMock.Setup(r => r.ObterPeloNome(_cursoDTO.Nome)).Returns(cursoJaSalvo);

            Assert.Throws<ExcecaoDeDominio>(() => _armazenadorDeCurso.Armazenar(_cursoDTO)).ComMensagem(Resource.NomeDoCursoJaExiste);
        }

        [Fact]
        public void DeveAlterarDadosDoCurso()
        {
            _cursoDTO.Id = 323;
            var curso = CursoBuilder.Novo().Build();
            _cursoRepositoryMock.Setup(r => r.ObterPorId(_cursoDTO.Id)).Returns(curso);

            _armazenadorDeCurso.Armazenar(_cursoDTO);

            Assert.Equal(_cursoDTO.Nome, curso.Nome);
            Assert.Equal(_cursoDTO.Valor, curso.Valor);
            Assert.Equal(_cursoDTO.Carga, curso.Carga);
        }

        [Fact]
        public void NaoDeveAdicionarNoRepositorioQuandoCursoJaExiste()
        {
            _cursoDTO.Id = 323;
            var curso = CursoBuilder.Novo().Build();
            _cursoRepositoryMock.Setup(r => r.ObterPorId(_cursoDTO.Id)).Returns(curso);

            _armazenadorDeCurso.Armazenar(_cursoDTO);

            _cursoRepositoryMock.Verify(r => r.Adicionar(It.IsAny<Cursos.Curso>()), Times.Never);
        }
    }

}
