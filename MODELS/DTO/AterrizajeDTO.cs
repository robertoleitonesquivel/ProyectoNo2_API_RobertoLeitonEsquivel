using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DTO
{
    public class AterrizajeDTO
    {
        public DateTime FechaRegistro { get; set; }
        public List<AterrizajesAvionesDTO> Aviones { get; set; }
    }

    public class AterrizajesAvionesDTO
    {
        public int IdAvion { get; set; }
        public bool PerdidasHumanas { get; set; } = false;
        public bool PerdidoMision { get; set; } = false;
    }
}
