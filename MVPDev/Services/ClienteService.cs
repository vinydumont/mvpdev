using AutoMapper;
using MVPDev.Dtos;
using MVPDev.Interfaces;

namespace MVPDev.Services {
    public class ClienteService : IClienteService {
        private readonly IMapper mapper;
        private readonly ISerproApi serproApi;

        public ClienteService(IMapper mapper, ISerproApi serproApi) {
            this.mapper = mapper;
            this.serproApi = serproApi;
        }

        public async Task<ResponseGenerico<ClienteResponse>> BuscarCliente(int id) {
            var cliente = await serproApi.BuscarClientePorId(id);

            return mapper.Map<ResponseGenerico<ClienteResponse>>(cliente);
        }
    }
}
