using System.Text.Json.Serialization;

namespace MVPDev.Models {
    public class ClienteModel {
        [JsonPropertyName("ni")]
        public string? Cnpj { get; set; }

        [JsonPropertyName("nomeFantasia")]
        public string? Nome { get; set; }

        [JsonPropertyName("nomeEmpresarial")]
        public string? RazaoSocial { get; set; }

        [JsonPropertyName("logradouro")]
        public string? Logradouro { get; set; }

        [JsonPropertyName("numero")]
        public string? LogNumero { get; set; }

        [JsonPropertyName("complemento")]
        public string? Complemento { get; set; }

        [JsonPropertyName("cep")]
        public string? Cep { get; set; }

        [JsonPropertyName("bairro")]
        public string? Bairro { get; set; }

        [JsonPropertyName("municipio")]
        public string? Municipio { get; set; }

        [JsonPropertyName("cnaePrincipal")]
        public string? Cnae { get; set; }
    }
}