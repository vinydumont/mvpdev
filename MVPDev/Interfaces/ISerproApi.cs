using MVPDev.Dtos;
using MVPDev.Models;

namespace MVPDev.Interfaces {
    public interface ISerproApi {
        Task<ResponseGenerico<ClienteModel>> BuscarClientePorId(int id);
    }
}
