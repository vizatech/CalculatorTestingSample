using System.Collections.Generic;
using System.Threading.Tasks;
using back_dotnetcore_rest_api.Models;

namespace back_dotnetcore_rest_api.Repositories
{
    public interface IUserActionRepo 
    {
        Task<IEnumerable<UserAction>> ListAsyncRepo();
    }
}