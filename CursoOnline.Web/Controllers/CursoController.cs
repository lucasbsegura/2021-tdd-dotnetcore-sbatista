using CursoOnline.Dominio._Base;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Web.Util;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoOnline.Web.Controllers
{
    public class CursoController : Controller
    {
        private readonly ArmazenadorDeCurso _armazenadorDeCurso;
        private readonly IRepositorio<Curso> _cursoRepositorio;

        public CursoController(ArmazenadorDeCurso armazenadorDeCurso, IRepositorio<Curso> cursoRepositorio)
        {
            _armazenadorDeCurso = armazenadorDeCurso;
            _cursoRepositorio = cursoRepositorio;
        }

        public IActionResult Index()
        {
            var cursos = _cursoRepositorio.Consultar();

            if (cursos.Any())
            {
                var dtos = cursos.Select(c => new CursoParaListagemDTO
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    CargaHoraria = c.Carga,
                    PublicoAlvo = c.Publico.ToString(),
                    Valor = c.Valor
                });
                return View("Index", PaginatedList<CursoParaListagemDTO>.Create(dtos, Request));
            }

            return View("Index", PaginatedList<CursoParaListagemDTO>.Create(null, Request));
        }

        public IActionResult Editar(int id)
        {
            var curso = _cursoRepositorio.ObterPorId(id);
            var dto = new CursoDTO
            {
                Id = curso.Id,
                Nome = curso.Nome,
                Descricao = curso.Descricao,
                Carga = curso.Carga,
                Valor = curso.Valor
            };

            return View("NovoOuEditar", dto);
        }

        public IActionResult Novo()
        {
            return View("NovoOuEditar", new CursoDTO());
        }

        [HttpPost]
        public IActionResult Salvar(CursoDTO model)
        {
            _armazenadorDeCurso.Armazenar(model);
            return Ok();
        }
    }
}
