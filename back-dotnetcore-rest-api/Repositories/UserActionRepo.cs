using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_dotnetcore_rest_api.Models;
using back_dotnetcore_rest_api.Persistence;

namespace back_dotnetcore_rest_api.Repositories
{
    public class UserActionRepo: AbstractRepo, IUserActionRepo
    {
        public UserActionRepo(CalculatorDBContext context): base(context) 
        {

        }

        public async Task<IEnumerable<UserAction>> ListAsyncRepo()
        {
            return await _context.ActionsOfUser.ToListAsync();
        }

        public async Task AddAsync(UserAction action)
        {
            await _context.ActionsOfUser.AddAsync(action);
        }
    }
}