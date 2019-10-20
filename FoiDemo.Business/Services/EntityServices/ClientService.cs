using FoiDemo.Business.Services.Base;
using FoiDemo.Data.Interfaces;
using FoiDemo.Data.Models;

namespace FoiDemo.Business.Services.EntityServices
{
    public class ClientService : EntityService<Client>
    {
        public ClientService(IGenericRepository<Client> repository) : base(repository)
        {
        }
    }
}
