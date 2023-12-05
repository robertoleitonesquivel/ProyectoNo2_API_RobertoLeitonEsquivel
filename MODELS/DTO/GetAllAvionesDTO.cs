using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DTO
{
    public class GetAllAvionesDTO
    {
        public string Marca { get; set; }
        public int Serie { get; set; }
        public string Fantasia { get; set; }
        public string FechaRegistro { get; set; }
        public string NombreTecnico { get; set; }
    }

    public class ModelosAvionesDTO
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public int Stock { get; set; }
        public List<GetAllAvionesDTO> Aviones { get; set; }
    }
}
