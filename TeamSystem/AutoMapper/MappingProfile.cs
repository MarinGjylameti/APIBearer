using AutoMapper;
using global::AutoMapper;
using TeamSystem.Models;
using TeamSystem.Models.DTOs;

namespace TeamSystem.AutoMapper
{
   
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PostsDTO, Posts>();
            CreateMap<KategoriDTO, Kategori>();
            CreateMap<KategoriPostDTO, KategoriPostim>();
            CreateMap<UserDTO, User>();

            // Add more mappings as needed
        }
    }

}
