using MODELS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Models.Contracts
{
    public interface IRetiros
    {
        Task AddAsync(RestirosDTO _retitosDTO);
    }
}
