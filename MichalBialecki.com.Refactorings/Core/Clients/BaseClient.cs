using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace MichalBialecki.com.Refactorings.Core.Clients
{
    public abstract class BaseClient<T> where T : class
    {
        public async Task<T> Get(string uri)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var contentAsString = await response.Content.ReadAsStringAsync();

                if (typeof(T) == typeof(string))
                {
                    return contentAsString as T;
                }

                return JsonConvert.DeserializeObject<T>(contentAsString);
            }

            throw new System.Exception($"Could not fetch data from {uri}");
        }

        public async Task Post(string uri, T data)
        {
            var client = new HttpClient();
            var response = await client.PostAsync(
                uri,
                new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                throw new System.Exception($"Could not post data to {uri}");
            }
        }
    }
}
