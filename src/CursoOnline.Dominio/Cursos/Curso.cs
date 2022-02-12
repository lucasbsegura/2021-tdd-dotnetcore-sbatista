using CursoOnline.Dominio._Base;
using System;

namespace CursoOnline.Dominio.Cursos
{
    public class Curso : Entidade
    {
        public string Nome { get; private set; }
        public double Carga { get; private set; }
        public PublicoAlvo Publico { get; private set; }
        public double Valor { get; private set; }
        public string Descricao { get; private set; }


        private Curso() { }
        public Curso(string nome, double carga, PublicoAlvo publico, double valor, string descricao)
        {
            ValidadorDeRegra.Novo()
                .Quando(string.IsNullOrEmpty(nome), Resource.NomeInvalido)
                .Quando(carga < 1, Resource.CargaHorariaInvalida)
                .Quando(valor < 1, Resource.ValorInvalido)
                .DispararExcecaoSeExistir();

            this.Nome = nome;
            this.Carga = carga;
            this.Publico = publico;
            this.Valor = valor;
            this.Descricao = descricao;
        }

        public void AlterarNome(string nome)
        {
            ValidadorDeRegra.Novo()
               .Quando(string.IsNullOrEmpty(nome), Resource.NomeInvalido)
               .DispararExcecaoSeExistir();

            this.Nome = nome;
        }

        public void AlterarCargaHoraria(double cargaHoraria)
        {
            ValidadorDeRegra.Novo()
                .Quando(cargaHoraria < 1, Resource.CargaHorariaInvalida)
                .DispararExcecaoSeExistir();

            Carga = cargaHoraria;
        }

        public void AlterarValor(double valor)
        {
            ValidadorDeRegra.Novo()
                .Quando(valor < 1, Resource.ValorInvalido)
                .DispararExcecaoSeExistir();

            Valor = valor;
        }
    }
}
