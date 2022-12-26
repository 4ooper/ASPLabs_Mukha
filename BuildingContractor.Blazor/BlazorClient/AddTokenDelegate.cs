using Blazored.LocalStorage;

namespace BlazorClient
{
    public class AddTokenDelegate : DelegatingHandler
    {
        protected readonly ILocalStorageService _localStorage;

        public AddTokenDelegate(ILocalStorageService LocalStorage) : base(new HttpClientHandler())
        {
            _localStorage = LocalStorage;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = _localStorage.GetItemAsync<string>("token");
            if (token.Result != null)
            {
                request.Headers.Add("token", token.Result);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
