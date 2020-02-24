using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using back_dotnetcore_rest_api.Models;
using back_dotnetcore_rest_api.Services;
using back_dotnetcore_rest_api.Resources;
using back_dotnetcore_rest_api.Extensions;


namespace back_dotnetcore_rest_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {

        private readonly IUserActionService _userActionService;
        private readonly IMapper _mapper;

        public CalculatorController(IUserActionService userActionService, IMapper mapper)
        {
            this._userActionService = userActionService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<int> GetUserActionNumberAsync()
        {
            int numOfActions = await _userActionService.NumberOfActions();
            return numOfActions;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<UserActionResource>> GetUserActionsAsync()
        {
            IEnumerable<UserAction> actions = await _userActionService.ListAsync();
            IEnumerable<UserActionResource> resources = 
                _mapper.Map<IEnumerable<UserAction>, IEnumerable<UserActionResource>>( actions );
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostUserActionAsync([FromBody] SaveUserActionResource resource)
        {                    
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var action = _mapper.Map<SaveUserActionResource, UserAction>(resource);                     
	        var result = await _userActionService.SaveAsync(action);

            if (!result.Success)
            {
		        return BadRequest(result.Message);
            }

	        var userActionResource = _mapper.Map<UserAction, UserActionResource>(result.UserAction);

	        return Ok(userActionResource);
        }
    }
}