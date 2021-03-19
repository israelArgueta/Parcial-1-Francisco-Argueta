using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_1_Francisco_Argueta
{
    class libros
    {
        string codigo;
        string tiulo;
        string autor;
        string fechaN;
        string fechaS;
        string año;

        public string Codigo { get => codigo; set => codigo = value; }
        public string Tiulo { get => tiulo; set => tiulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Año { get => año; set => año = value; }
        public string FechaN { get => fechaN; set => fechaN = value; }
        public string FechaS { get => fechaS; set => fechaS = value; }
    }
}
