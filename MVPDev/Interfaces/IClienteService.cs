using MVPDev.Dtos;
using MVPDev.Models;

namespace MVPDev.Interfaces {
    public interface IClienteService {
        Task<ResponseGenerico<ClienteResponse>> BuscarCliente(int id);
    }
}