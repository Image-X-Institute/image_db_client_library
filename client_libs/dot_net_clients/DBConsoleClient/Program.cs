using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace DBClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private const string baseUrl = "http://10.65.67.179:8090/";
        private const string accessToken = "";

        static async Task Main(string[] args)
        {
            var dbClient = new ImagingDBClientLibrary.DBClient(baseUrl, accessToken);
            var allPatients = await dbClient.getAllPatients();

            foreach (var patient in allPatients.patients)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("ID: " + patient.patientTrialId);
                Console.WriteLine("Age: " + patient.age);
                Console.WriteLine("Gender: " + patient.gender);
                Console.WriteLine("Clinical Trial: " + patient.clinicalTrial);
                Console.WriteLine("test Centre: " + patient.testCentre);
            }
        }
    }
}