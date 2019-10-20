using AutoMapper;
using FoiDemo.API.Controllers.Base;
using FoiDemo.API.Models;
using FoiDemo.Business.Services.EntityServices;
using FoiDemo.Data.Models;

namespace FoiDemo.API.Controllers
{
    public class ClientsController : EntityController<Client, ClientDto, ClientForCreateDto, ClientService>
    {
        public ClientsController(ClientService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
