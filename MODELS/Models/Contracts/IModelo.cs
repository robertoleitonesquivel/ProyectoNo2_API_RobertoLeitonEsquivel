using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Models.Contracts
{
    public interface IModelo
    {
        Task<List<Modelos>> GetByMarca(int _IdMarca);
    }
}
