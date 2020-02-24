using back_dotnetcore_rest_api.Models;


namespace back_dotnetcore_rest_api.Services
{
    public class SaveResponse : BaseResponse
    {
        public UserAction UserAction 
        { 
            get; private set; 
        }

        private SaveResponse(bool success, string message, UserAction action): base(success, message)
        {
            this.UserAction = action;
        }
     
        public SaveResponse(UserAction action): this(true, string.Empty, action)
        { 

        }

        public SaveResponse(string message): this(false, message, null)
        { 

        }
    }
}