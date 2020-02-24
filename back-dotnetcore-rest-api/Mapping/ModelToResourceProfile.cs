using AutoMapper;
using back_dotnetcore_rest_api.Models;
using back_dotnetcore_rest_api.Resources;

namespace back_dotnetcore_rest_api.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<UserAction, UserActionResource>();
        }
    }
}