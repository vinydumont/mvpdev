
using System.ComponentModel.DataAnnotations;

namespace MVPDev.Dtos {
    public class ClienteResponse {
        public int Id { get; set; }
        public string? Cnpj { get; set; }
        public string? Nome { get; set; }
        public string? RazaoSocial { get; set; }
        public string? Cnae { get; set; }
        public string? Logradouro { get; set; }
        public string? LogNumero { get; set; }
        public string? Complemento { get; set; }
        public string? Cep { get; set; }
        public string? Bairro { get; set; }
        public string? Municipio { get; set; }
    }
}
