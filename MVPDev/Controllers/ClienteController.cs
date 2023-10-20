using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using MVPDev.Context;
using MVPDev.Dtos;
using MVPDev.Interfaces;

namespace MVPDev.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase {
        private readonly ClienteDbContext clienteContext;
        private readonly IClienteService clienteService;

        public ClienteController(IClienteService clienteService, ClienteDbContext clienteContext) {
            this.clienteContext = clienteContext;
            this.clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteResponse>>> ListarClientes() {
            return await this.clienteContext.Clientes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteResponse>> BuscarCliente(int id)
        {
            var cliente = await this.clienteContext.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound("Cliente não foi encontrado!");

            return cliente;
        }

        // [HttpGet("basica/{id}")]
        // public async Task<ActionResult> BuscarClienteApi(int id) {
        //     var response = await this.clienteService.BuscarCliente(id);
        //     if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //         return Ok(response.DataReturn);
        //     else
        //         return StatusCode((int)response.StatusCode, response.ErrorReturn);
        // }

        [HttpPost]
        public async Task<ActionResult<ClienteResponse>> AdicionarCliente(ClienteResponse cliente)
        {
            await this.clienteContext.Clientes.AddAsync(cliente);
            await this.clienteContext.SaveChangesAsync();
            return Ok("Cliente adicionado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarCliente(int id, ClienteResponse cliente) {
            if (cliente.Id == 0)
                cliente.Id = id;

            this.clienteContext.Clientes.Update(cliente);
            await this.clienteContext.SaveChangesAsync();

            return Ok("Cliente alterado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirCliente(int id) {
            var cliente = await this.clienteContext.Clientes.FindAsync(id);
            if (cliente != null) {
                this.clienteContext.Remove(cliente);
                await this.clienteContext.SaveChangesAsync();

                return Ok("Cliente excluido com sucesso!");
            }
            else
                return NotFound("Cliente não foi encontrado!");
        }
    }
}