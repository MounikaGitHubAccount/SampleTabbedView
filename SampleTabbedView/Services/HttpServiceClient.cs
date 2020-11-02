using System;
using System.Net.Http;

namespace SampleTabbedView.Services
{
    public class HttpServiceClient : System.Net.Http.HttpClient
    {
        public HttpServiceClient()
        {

        }

        public HttpServiceClient(HttpMessageHandler handler) : base(handler)
        {

        }
    }
}