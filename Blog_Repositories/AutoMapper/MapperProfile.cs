using AutoMapper;
using Blog.DataAccess;
using Blog_Common.DTOs;

namespace Blog_Repositories
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PostDTO, Post>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom((src, dest) => src.Id))
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom((src, dest) => src.ParentId))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom((src, dest) => src.StatusId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom((src, dest) => src.UserId))
                .ForMember(dest => dest.Text, opt => opt.MapFrom((src, dest) => src.Text))
                .ForMember(dest => dest.ApprovalDate, opt => opt.MapFrom((src, dest) => src.ApprovalDate))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom((src, dest) => src.CreatedDate)).ReverseMap();

            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom((src, dest) => src.Id))
                .ForMember(dest => dest.Password, opt => opt.MapFrom((src, dest) => src.Password))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom((src, dest) => src.UserName))
                .ReverseMap();
        }
    }
}
