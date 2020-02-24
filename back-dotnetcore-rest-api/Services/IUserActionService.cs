using System.Collections.Generic;
using System.Threading.Tasks;
using back_dotnetcore_rest_api.Models;

namespace back_dotnetcore_rest_api.Services 
{
    public interface IUserActionService 
    {
        Task<IEnumerable<UserAction>> ListAsync();

        Task<int> NumberOfActions();
        
        Task<SaveResponse> SaveAsync(UserAction action);
    }
}