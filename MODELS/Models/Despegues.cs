using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MODELS.Models
{
    public class Despegues
    {
        public int Id { get; set; }
        public string NumeroDespegue { get; set; }
        public DateTime FechaDespegue { get; set; }
        public string NombreTecnico { get; set; }
        public string NombreMision { get; set; }
    }
}