using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using back_dotnetcore_rest_api.Models;
using back_dotnetcore_rest_api.Services;


namespace back_dotnetcore_rest_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {

        private readonly IUserActionService _userActionService;

        public CalculatorController(IUserActionService userActionService)
        {
            this._userActionService = userActionService;
        }

        [HttpGet]
        public async Task<int> GetUserActionNumberAsync()
        {
            int numOfActions = await _userActionService.NumberOfActions();
            return numOfActions;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<UserAction>> GetUserActionsAsync()
        {
            IEnumerable<UserAction> actions = await _userActionService.ListAsync();
            return actions;
        }

        
    }
}