using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace devwebfinal.Models
{
    public class Cursos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idcurso { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int creditos { get; set; }
    }
}
