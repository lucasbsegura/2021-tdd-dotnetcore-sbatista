using System;

namespace CursoOnline.Dominio.Test._Builders
{
    public class CursoBuilder
    {
        private int _id;
        private string _nome = "Informatica Basica";
        private double _carga = 80;
        private Dominio.Cursos.PublicoAlvo _publico = Dominio.Cursos.PublicoAlvo.Estudante;
        private double _valor = 950;
        private string _descricao = "Descricao";

        public static CursoBuilder Novo()
        {
            return new CursoBuilder();
        }

        public CursoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public CursoBuilder ComDescricao(string desc)
        {
            _descricao = desc;
            return this;
        }

        public CursoBuilder ComCarga(double carga)
        {
            _carga = carga;
            return this;
        }

        public CursoBuilder ComValor(double valor)
        {
            _valor = valor;
            return this;
        }

        public CursoBuilder ComPublic(Dominio.Cursos.PublicoAlvo p)
        {
            _publico = p;
            return this;
        }

        public CursoBuilder ComId(int id)
        {
            _id = id;
            return this;
        }

        public Cursos.Curso Build()
        {
            var curso = new Cursos.Curso(_nome, _carga, _publico, _valor, _descricao);

            if (_id > 0)
            {
                //reflection
                var propertyInfo = curso.GetType().GetProperty("Id");
                propertyInfo.SetValue(curso, Convert.ChangeType(_id, propertyInfo.PropertyType), null);
            }

            return curso;
        }
    }
}
