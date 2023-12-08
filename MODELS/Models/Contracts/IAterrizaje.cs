using MODELS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Models.Contracts
{
    public interface IAterrizaje
    {
        Task AddAsync(AterrizajeDTO _aterrizaje);
        Task<List<GetDespeguesDTO>> GetAllAsync();
        Task<List<GetAllDespeguesDTO>> GetAvionesDespegues(string _numeroDespegue);
    }
}
