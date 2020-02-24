namespace back_dotnetcore_rest_api.Models
{
    public class UserAction 
    {
        public int ActionId 
        {
            get; set;
        } 
        
        public string MathOperation 
        {
            get; set;
        }

        public string MathResult 
        {
            get; set;
        }
    }
}