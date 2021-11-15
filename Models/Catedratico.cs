using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devwebfinal.Models
{
    public class Catedratico
    {
        public int Idcatedratico { get; set; }
        public string Primer_nombre { get; set; }
        public string Segundo_nombre { get; set; }
        public string Primer_apellido { get; set; }
        public string Segundo_apellido { get; set; }
        public string Estado { get; set; }
        public string Aprobado { get; set; }
    }
}
