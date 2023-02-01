using AutoMapper;
using Helper.Business.Answers.Dtos;
using Helper.Business.Auth.Dtos;
using Helper.Business.Categories.Dtos;
using Helper.Business.Helps.Dtos;
using Helper.Business.Users.Dtos;
using Helper.Entites.Entites;
using Helper.Entites.Identity;
using Microsoft.AspNetCore.Identity;

namespace Helper.Business.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<Answer, CreateAnswerDto>().ReverseMap();
            CreateMap<Answer, UpdateAnswerDto>().ReverseMap();
            CreateMap<Answer, DeleteAnswerDto>().ReverseMap();
            CreateMap<Answer, GetAnswerDto>().ReverseMap();

            CreateMap<Help, GetHelpDto>().ReverseMap();
            CreateMap<Help, CreateHelpDto>().ReverseMap();
            CreateMap<Help, UpdateHelpDto>().ReverseMap();  

            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<ApplicationUser, LoginDto>().ReverseMap();
            CreateMap<ApplicationUser, RegisterDto>().ReverseMap();
            CreateMap<ApplicationUser, ResetPasswordDto>().ReverseMap();
            CreateMap<ApplicationUser, UpdateApplicationUserDto>().ReverseMap();
            CreateMap<ApplicationUser, GetApplicationUserDto>().ReverseMap();

        }
    }
}
