using System.ComponentModel.DataAnnotations;

namespace back_dotnetcore_rest_api.Resources
{
    public class SaveUserActionResource
    {
        [Required]
        public string MathOperation 
        {
            get; set; 
        }

        [Required]
        public string MathResult 
        { 
            get; set; 
        }
    }
}