using CursoOnline.Dominio.Alunos;
using CursoOnline.Dominio.Matriculas;

namespace CursoOnline.Dominio.Test._Builders
{
    public class MatriculaBuilder
    {
        protected Aluno Aluno;
        protected Dominio.Cursos.Curso Curso;
        protected double ValorPago;
        protected bool Cancelada;
        protected bool Concluido;

        public static MatriculaBuilder Novo()
        {
            var curso = CursoBuilder.Novo().ComPublic(Cursos.PublicoAlvo.Empreendedor).Build();

            return new MatriculaBuilder
            {
                Aluno = AlunoBuilder.Novo().ComPublicoAlvo(Cursos.PublicoAlvo.Empreendedor).Build(),
                Curso = curso,
                ValorPago = curso.Valor
            };
        }

        public MatriculaBuilder ComAluno(Aluno aluno)
        {
            Aluno = aluno;
            return this;
        }

        public MatriculaBuilder ComCurso(Dominio.Cursos.Curso curso)
        {
            Curso = curso;
            return this;
        }

        public MatriculaBuilder ComValorPago(double valorPago)
        {
            ValorPago = valorPago;
            return this;
        }

        public MatriculaBuilder ComCancelada(bool cancelada)
        {
            Cancelada = cancelada;
            return this;
        }

        public MatriculaBuilder ComConcluido(bool concluido)
        {
            Concluido = concluido;
            return this;
        }

        public Matricula Build()
        {
            var matricula = new Matricula(Aluno, Curso, ValorPago);

            if (Cancelada)
                matricula.Cancelar();

            if (Concluido)
            {
                const double notaDoAluno = 7;
                matricula.InformarNota(notaDoAluno);
            }

            return matricula;
        }

        
    }
}
