using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Models.Contracts
{
    public interface ICommon
    {
        Task<T> ExecuteHttpAsync<T>(HttpMethod _httpMethod, string _endpoint, T _data = default(T));
    }
}
