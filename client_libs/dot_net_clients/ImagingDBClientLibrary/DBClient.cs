using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;


namespace ImagingDBClientLibrary
{
    public class DBClient
    {
        private static readonly HttpClient client = new HttpClient();
        private string baseUrl = "http://localhost:8090/";
        private string accessToken;

        public DBClient(string baseUrl, string accessToken="")
        {
            this.baseUrl = baseUrl;
            this.accessToken = accessToken;
        }

        private void prepareClient()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Image X Real time DB .NET client");
        }

        public async Task<Patients> getAllPatients()
        {
            prepareClient();
            var queryUrl = baseUrl + "patients" + (string.IsNullOrEmpty(accessToken) ? "" : "?token=" + accessToken);
            var streamTask = client.GetStreamAsync(queryUrl);
            var patients = await JsonSerializer.DeserializeAsync<Patients>(await streamTask);
            return patients;
        }

        public async Task<Fractions> getAllFractions()
        {
            prepareClient();
            var queryUrl = baseUrl + "fractions" + (string.IsNullOrEmpty(accessToken) ? "" : "?token=" + accessToken);
            var streamTask = client.GetStreamAsync(queryUrl);
            var fractions = await JsonSerializer.DeserializeAsync<Fractions>(await streamTask);
            return fractions;
        }

    }
}
