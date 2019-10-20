using AutoMapper;
using FoiDemo.API.Models;
using FoiDemo.Data.Models;

namespace FoiDemo.API.Mappings
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ClientForCreateDto, Client>();
        }
    }
}
