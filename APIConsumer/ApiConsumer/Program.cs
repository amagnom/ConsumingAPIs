using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ApiConsumer
{

    public class ApiConsumerMain
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> GetResponseApi(string urlApi)
        {
            try
            {
                SetupHttpClient(urlApi);
                
                HttpResponseMessage response = await client.GetAsync(urlApi);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    return jsonString;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error accessing the API: {e.Message}");
            }

            return null;
        }

        private static void SetupHttpClient(string urlApi)
        {
            client.BaseAddress = new Uri(urlApi);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
