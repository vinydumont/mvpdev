using System.Dynamic;
using System.Net;

namespace MVPDev.Dtos
{
    public class ResponseGenerico<T> where T : class
    {
        public HttpStatusCode StatusCode { get; set; }
        public T? DataReturn { get; set; }
        public ExpandoObject? ErrorReturn { get; set; }
    }
}
