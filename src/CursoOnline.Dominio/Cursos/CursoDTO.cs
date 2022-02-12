using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoOnline.Dominio.Cursos
{
    public class CursoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Carga { get; set; }
        public string Publico { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
    }
}
