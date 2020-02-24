using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using back_dotnetcore_rest_api.Models;
using back_dotnetcore_rest_api.Repositories;

namespace back_dotnetcore_rest_api.Services 
{
    public class UserActionService: IUserActionService
    {
        private readonly IUserActionRepo _userActionRepo;
        private readonly IUnitOfWork _unitOfWork;

        public UserActionService(IUserActionRepo userActionRepo, IUnitOfWork unitOfWork)
        {
            this._userActionRepo = userActionRepo;
            this._unitOfWork = unitOfWork;
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

        public async Task<SaveResponse> SaveAsync(UserAction action)
        {
            try
            {
                await _userActionRepo.AddAsync(action);
                await _unitOfWork.CompleteAsync();               

                return new SaveResponse(action);
            } 
            catch (Exception ex) 
            {
                return new SaveResponse($"An error occurred when saving the user action: {ex.Message}");
            }
        }
    }
}