using CursoOnline.Dominio._Base;
using CursoOnline.Dominio.PublicosAlvo;

namespace CursoOnline.Dominio.Cursos
{
    public class ArmazenadorDeCurso //servico de domínio
    {
        private readonly ICursoRepositorio _cursoRepositorio;
        private readonly IConversorDePublicoAlvo _conversorDePublicoAlvo;
        public ArmazenadorDeCurso(ICursoRepositorio cursoRepositorio, IConversorDePublicoAlvo conversorDePublicoAlvo)
        {
            _cursoRepositorio = cursoRepositorio;
            _conversorDePublicoAlvo = conversorDePublicoAlvo;
        }
        public void Armazenar(CursoDTO cursoDTO)
        {
            var cursoJaSalvo = _cursoRepositorio.ObterPeloNome(cursoDTO.Nome);

            ValidadorDeRegra.Novo()
                .Quando(cursoJaSalvo != null && cursoJaSalvo.Id != cursoDTO.Id, Resource.NomeDoCursoJaExiste)
                .DispararExcecaoSeExistir();

            var publicoAlvo = _conversorDePublicoAlvo.Converter(cursoDTO.Publico);
            var curso = new Cursos.Curso(cursoDTO.Nome, cursoDTO.Carga, (Cursos.PublicoAlvo)publicoAlvo, cursoDTO.Valor, cursoDTO.Descricao);

            if (cursoDTO.Id > 0)
            {
                curso = _cursoRepositorio.ObterPorId(cursoDTO.Id);
                curso.AlterarNome(cursoDTO.Nome);
                curso.AlterarValor(cursoDTO.Valor);
                curso.AlterarCargaHoraria(cursoDTO.Carga);
            }

            if (cursoDTO.Id == 0)
                _cursoRepositorio.Adicionar(curso);
        }
    }
}
