using MosCore.Infrastructure.Identity.Models;
using MosCore.Web.Areas.Admin.Models;
using AutoMapper;

namespace MosCore.Web.Areas.Admin.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
        }
    }
}