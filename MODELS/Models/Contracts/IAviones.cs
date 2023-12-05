using MODELS.DTO;
using MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Models.Contracts
{
    public interface IAviones
    {
        Task AddAsync(List<Aviones> _aviones);
        Task<List<GetAvionesDTO>> GetBySerie(int _serie);
        Task<List<ModelosAvionesDTO>> GetAllAsync();
    }
}
