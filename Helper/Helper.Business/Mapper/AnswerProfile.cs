using AutoMapper;
using Helper.Business.Answers.Dtos;
using Helper.Entites.Entites;

namespace Helper.Business.Mapper
{
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {

            CreateMap<Answer, CreateAnswerDto>().ReverseMap();
            CreateMap<Answer, UpdateAnswerDto>().ReverseMap();
            CreateMap<Answer, DeleteAnswerDto>().ReverseMap();
            CreateMap<Answer, AnswerAllListDto>().ReverseMap();
        }
    }
}
