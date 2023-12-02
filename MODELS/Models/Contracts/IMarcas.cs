using MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Models.Contracts
{
    public interface IMarcas
    {
        Task<List<Marcas>> GetAllAsync();
    }
}
