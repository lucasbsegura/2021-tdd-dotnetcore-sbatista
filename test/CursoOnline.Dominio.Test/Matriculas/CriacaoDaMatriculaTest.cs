﻿using CursoOnline.Dominio._Base;
using CursoOnline.Dominio.Alunos;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Dominio.Matriculas;
using CursoOnline.Dominio.Test._Builders;
using CursoOnline.Dominio.Test._Util;
using Moq;
using Xunit;

namespace CursoOnline.Dominio.Test.Matriculas
{
    public class CriacaoDaMatriculaTest
    {
        private readonly Mock<ICursoRepositorio> _cursoRepositorio;
        private readonly Mock<IAlunoRepositorio> _alunoRepositorio;
        private readonly CriacaoDaMatricula _criacaoDaMatricula;
        private readonly MatriculaDTO _matriculaDto;
        private readonly Mock<IMatriculaRepositorio> _matriculaRepositorio;
        private readonly Aluno _aluno;
        private readonly Dominio.Cursos.Curso _curso;

        public CriacaoDaMatriculaTest()
        {
            _cursoRepositorio = new Mock<ICursoRepositorio>();
            _alunoRepositorio = new Mock<IAlunoRepositorio>();
            _matriculaRepositorio = new Mock<IMatriculaRepositorio>();

            _aluno = AlunoBuilder.Novo().ComId(23).ComPublicoAlvo(Cursos.PublicoAlvo.Universitário).Build();
            _alunoRepositorio.Setup(r => r.ObterPorId(_aluno.Id)).Returns(_aluno);

            _curso = CursoBuilder.Novo().ComId(45).ComPublic(Cursos.PublicoAlvo.Universitário).Build();
            _cursoRepositorio.Setup(r => r.ObterPorId(_curso.Id)).Returns(_curso);

            _matriculaDto = new MatriculaDTO { AlunoId = _aluno.Id, CursoId = _curso.Id, ValorPago = _curso.Valor };

            _criacaoDaMatricula = new CriacaoDaMatricula(_alunoRepositorio.Object, _cursoRepositorio.Object, _matriculaRepositorio.Object);
        }

        [Fact]
        public void DeveNotificarQuandoCursoNaoForEncontrado()
        {
            Dominio.Cursos.Curso cursoInvalido = null;
            _cursoRepositorio.Setup(r => r.ObterPorId(_matriculaDto.CursoId)).Returns(cursoInvalido);

            Assert.Throws<ExcecaoDeDominio>(() =>
                    _criacaoDaMatricula.Criar(_matriculaDto))
                .ComMensagem(Resource.CursoNaoEncontrado);
        }

        [Fact]
        public void DeveNotificarQuandoAlunoNaoForEncontrado()
        {
            Aluno alunoInvalido = null;
            _alunoRepositorio.Setup(r => r.ObterPorId(_matriculaDto.AlunoId)).Returns(alunoInvalido);

            Assert.Throws<ExcecaoDeDominio>(() =>
                    _criacaoDaMatricula.Criar(_matriculaDto))
                .ComMensagem(Resource.AlunoNaoEncontrado);
        }

        [Fact]
        public void DeveAdicionarMatricula()
        {
            _criacaoDaMatricula.Criar(_matriculaDto);

            _matriculaRepositorio.Verify(r => r.Adicionar(It.Is<Matricula>(m => m.Aluno == _aluno && m.Curso == _curso)));
        }
    }
}