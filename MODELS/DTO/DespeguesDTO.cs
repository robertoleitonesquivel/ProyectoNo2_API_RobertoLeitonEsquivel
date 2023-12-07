using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DTO
{
    public class DespeguesDTO
    {
        public DateTime FechaDespegue { get; set; }
        public string Tecnico { get; set; }
        public string NombreMision { get; set; }
        public List<AvionesDespegueDTO> AvionesDespegue { get; set; }
    }

    public class AvionesDespegueDTO
    {
        public int IdAvion { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Serie { get; set; }
        public string NombrePiloto { get; set; }

    }
}
