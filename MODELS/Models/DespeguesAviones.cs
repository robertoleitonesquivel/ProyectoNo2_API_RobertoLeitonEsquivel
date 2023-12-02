using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MODELS.Models
{
    public class DespeguesAviones
    {
        public int IdDespegue { get; set; }
        public int IdAvion { get; set; }
        public int IdPiloto { get; set; }
    }
}