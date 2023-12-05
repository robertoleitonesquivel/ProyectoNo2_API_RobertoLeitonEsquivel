using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DTO
{
    public class GetAvionesDTO
    {
        public int Id { get; set; }
        public string NombreFantasia { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set;}
        public int IdModelo { get; set; }

    }
}
