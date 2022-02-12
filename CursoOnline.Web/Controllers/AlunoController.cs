using CursoOnline.Dominio._Base;
using CursoOnline.Dominio.Alunos;
using CursoOnline.Web.Util;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CursoOnline.Web.Controllers
{
    public class AlunoController : Controller
    {
        private readonly ArmazenadorDeAluno _armazenadorDeAluno;
        private readonly IRepositorio<Aluno> _alunoRepositorio;

        public AlunoController(ArmazenadorDeAluno armazenadorDeAluno, IRepositorio<Aluno> alunoRepositorio)
        {
            _armazenadorDeAluno = armazenadorDeAluno;
            _alunoRepositorio = alunoRepositorio;
        }

        public IActionResult Index()
        {
            var alunos = _alunoRepositorio.Consultar();

            if (alunos.Any())
            {
                var dtos = alunos.Select(c => new AlunoParaListagemDTO
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Cpf = c.Cpf,
                    Email = c.Email
                });
                return View("Index", PaginatedList<AlunoParaListagemDTO>.Create(dtos, Request));
            }

            return View("Index", PaginatedList<AlunoParaListagemDTO>.Create(null, Request));
        }

        public IActionResult Editar(int id)
        {
            var aluno = _alunoRepositorio.ObterPorId(id);
            var dto = new AlunoDTO
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                Cpf = aluno.Cpf,
                Email = aluno.Email,
                PublicoAlvo = aluno.PublicoAlvo.ToString()
            };

            return View("NovoOuEditar", dto);
        }

        public IActionResult Novo()
        {
            return View("NovoOuEditar", new AlunoDTO());
        }

        [HttpPost]
        public IActionResult Salvar(AlunoDTO model)
        {
            _armazenadorDeAluno.Armazenar(model);

            return Ok();
        }
    }
}
