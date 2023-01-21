using AutoMapper;
using Helper.Business.Answers.Dtos;
using Helper.Business.Auth.Dtos;
using Helper.Business.Categories.Dtos;
using Helper.Business.Helps.Dtos;
using Helper.Entites.Entites;
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

            CreateMap<IdentityUser, LoginDto>().ReverseMap();
            CreateMap<IdentityUser, RegisterDto>().ReverseMap();
            CreateMap<IdentityUser, ResetPasswordDto>().ReverseMap();
        }
    }
}
