using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MODELS.Models
{
    public class AterrisajeAviones
    {
        public int IdAterrisaje { get; set; }
        public int IdAvion { get; set; }
        public bool PerdidasHumanas { get; set; }
        public bool PerdidoMision { get; set; }

    }
}