using AutoMapper;
using MVPDev.Dtos;
using MVPDev.Models;

namespace MVPDev.Mappings {
    public class ClienteMapping : Profile {
        public ClienteMapping()  {
            CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));
            CreateMap<ClienteResponse, ClienteModel>();
            CreateMap<ClienteModel, ClienteResponse>();
        }
    }
}
