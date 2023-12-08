using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DTO
{
    public class GetDespeguesDTO
    {
        public string Despegue {  get; set; }
        public string Mision { get; set; }
    }

    public class GetAllDespeguesDTO
    {
        public string Despegue { get; set; }
        public string Mision { get; set; }
        public string Tecnico { get; set; }
        public string Modelo { get; set; }
        public int IdAvion {  get; set; }

    }
}
