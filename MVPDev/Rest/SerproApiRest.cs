using MVPDev.Dtos;
using MVPDev.Interfaces;
using MVPDev.Models;
using System.Dynamic;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Web;
using Newtonsoft.Json.Linq;

namespace MVPDev.Rest {
    public class SerproApiRest : ISerproApi {
        public async Task<ResponseGenerico<ClienteModel>> BuscarClientePorId(int id) {
            var uri = new Uri("https://gateway.apiserpro.serpro.gov.br");
            //var encodedConsumerKey = HttpUtility.UrlEncode("djaR21PGoYp1iyK2n2ACOH9REdUb");
            //var encodedConsumerKeySecret = HttpUtility.UrlEncode("ObRsAJWOL4fv2Tp27D1vd8fB3Ote");
            //var encodedPair = Base64Encode(string.Format("{0}:{1}", encodedConsumerKey, encodedConsumerKeySecret));

            using (var client = new HttpClient()) {
                //var requestToken = new HttpRequestMessage {
                //    Method = HttpMethod.Post,
                //    RequestUri = new Uri(uri, "/token"),
                //    Content = new StringContent("grant_type=client_credentials")
                //};

                //requestToken.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded") { CharSet = "UTF-8" };
                //requestToken.Headers.TryAddWithoutValidation("Authorization", String.Format("Basic {0}", encodedPair));

                //var bearerResult = await client.SendAsync(requestToken).ConfigureAwait(false);
                //var bearerData = await bearerResult.Content.ReadAsStringAsync();
                //var bearerToken = JObject.Parse(bearerData)["access_token"].ToString();
                ////var bearerToken = "c66a7def1c96f7008a0c397dc588b6d7";

                var requestData = new HttpRequestMessage {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(uri, $"/consulta-cnpj-df-trial/v2/basica/{id}"),
                };
                //requestData.Headers.TryAddWithoutValidation("Authorization", String.Format("Bearer {0}", bearerToken));

                var response = new ResponseGenerico<ClienteModel>();
            
                var responseSerproApi = await client.SendAsync(requestData);
                var content = await responseSerproApi.Content.ReadAsStringAsync();
                var obj = JsonSerializer.Deserialize<ClienteModel>(content);

                response.StatusCode = responseSerproApi.StatusCode;
                if (responseSerproApi.IsSuccessStatusCode)
                    response.DataReturn = obj;
                else
                    response.ErrorReturn = JsonSerializer.Deserialize<ExpandoObject>(content);

                return response;
            }
        }

        public static string Base64Encode(string plainText) {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
