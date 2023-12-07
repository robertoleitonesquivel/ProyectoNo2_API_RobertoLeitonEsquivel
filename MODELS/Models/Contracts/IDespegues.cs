using MODELS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Models.Contracts
{
    public interface IDespegues
    {
        Task<List<AvionesDespegueDTO>> GetAvionesBySerie(int _serie);
        Task AddAsync(DespeguesDTO _despegues);
    }
}
