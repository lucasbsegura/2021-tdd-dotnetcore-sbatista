using CursoOnline.Dominio._Base;
using CursoOnline.Dominio.PublicosAlvo;
using CursoOnline.Dominio.Test._Util;
using Xunit;

namespace CursoOnline.Dominio.Test.PublicoAlvo
{
    public class ConversorDePublicoAlvoTest
    {
        private readonly ConversorDePublicoAlvo _conversor = new ConversorDePublicoAlvo();

        [Theory]
        [InlineData(Cursos.PublicoAlvo.Empregado, "Empregado")]
        [InlineData(Cursos.PublicoAlvo.Empreendedor, "Empreendedor")]
        [InlineData(Cursos.PublicoAlvo.Estudante, "Estudante")]
        [InlineData(Cursos.PublicoAlvo.Universitário, "Universitário")]
        public void DeveConverterPublicoAlvo(Cursos.PublicoAlvo publicoAlvoEsperado, string publicoAlvoEmString)
        {
            var publicoAlvoConvertido = _conversor.Converter(publicoAlvoEmString);

            Assert.Equal(publicoAlvoEsperado, publicoAlvoConvertido);
        }

        [Fact]
        public void NaoDeveConverterQuandoPublicoAlvoEhInvalido()
        {
            const string publicoAlvoInvalido = "Invalido";

            Assert.Throws<ExcecaoDeDominio>(() =>
                    _conversor.Converter(publicoAlvoInvalido))
                .ComMensagem(Resource.PublicoAlvoInvalido);
        }
    }
}
