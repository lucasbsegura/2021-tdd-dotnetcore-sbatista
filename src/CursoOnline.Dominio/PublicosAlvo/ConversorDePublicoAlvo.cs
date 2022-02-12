using CursoOnline.Dominio._Base;
using CursoOnline.Dominio.Cursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoOnline.Dominio.PublicosAlvo
{
    public class ConversorDePublicoAlvo : IConversorDePublicoAlvo
    {
        public PublicoAlvo Converter(string publicoAlvo)
        {
            ValidadorDeRegra.Novo()
                .Quando(!Enum.TryParse<PublicoAlvo>(publicoAlvo, out var publicoAlvoConvertido), Resource.PublicoAlvoInvalido)
                .DispararExcecaoSeExistir();

            return publicoAlvoConvertido;
        }
    }
}
