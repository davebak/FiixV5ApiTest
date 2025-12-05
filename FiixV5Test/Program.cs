using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FiixV5Test;

class Program
{
    static async Task Main(string[] args)
    {
        // Console.WriteLine("Hello, Fiix V5 API Test!");
        string? tenant = Environment.GetEnvironmentVariable("FIIX_TENANT");
        string? apiKey = Environment.GetEnvironmentVariable("FIIX_API_KEY");
        string? accessKey = Environment.GetEnvironmentVariable("FIIX_ACCESS_KEY");
        string? secretKey = Environment.GetEnvironmentVariable("FIIX_SECRET_KEY");

        if (tenant == null || apiKey == null || accessKey == null || secretKey == null)
        {
            // Console.Write
            Console.WriteLine("Fiix variables not available from command line.");
            System.Environment.Exit(-1);
        }

        // Generate the auth signature
        string myAuthSignature = FiixApiUtils.GenerateAuthSignature(tenant, apiKey, accessKey, secretKey);

        // Create a new HTTP Client
        HttpClient myFiixClient = new HttpClient();

        // Create a request body
        FiixNewSampleAsset pingRequest = new FiixNewSampleAsset();
        string myNewRequestContent = JsonSerializer.Serialize(pingRequest);
        
        StringContent requestContent = new StringContent(
            myNewRequestContent,
            Encoding.UTF8,
            "text/plain"
        );

        HttpRequestMessage myNewMessage = new ()
        {
            Content = requestContent,
            Method = HttpMethod.Post,
            RequestUri = new Uri($"https://{tenant}.macmms.com/api/?service=cmms&appKey={apiKey}&accessKey={accessKey}&signatureMethod=HmacSHA256&signatureVersion=1")
        };
        myNewMessage.Headers.Add("Authorization", myAuthSignature);

        HttpResponseMessage myResponse = await myFiixClient.SendAsync(myNewMessage);
        string jsonResponse = await myResponse.Content.ReadAsStringAsync();

        Console.WriteLine(jsonResponse);
    }
}
