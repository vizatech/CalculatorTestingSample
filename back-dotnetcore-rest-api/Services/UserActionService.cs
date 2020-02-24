using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using back_dotnetcore_rest_api.Models;
using back_dotnetcore_rest_api.Repositories;

namespace back_dotnetcore_rest_api.Services 
{
    public class UserActionService: IUserActionService
    {
        private readonly IUserActionRepo _userActionRepo;

        public UserActionService(IUserActionRepo userActionRepo)
        {
            this._userActionRepo = userActionRepo;
        }

        public async Task<IEnumerable<UserAction>> ListAsync() 
        {
            return await _userActionRepo.ListAsyncRepo();
        }

        public async Task<int> NumberOfActions() 
        {
            IEnumerable<UserAction> actions = await this.ListAsync();
            int numberOfActions = actions.Count();
            return numberOfActions;
        }
    }
}