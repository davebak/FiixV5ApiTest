using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace FiixV5Test;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello, Fiix V5 API Test!");
        string? tenant = Environment.GetEnvironmentVariable("FIIX_TENANT");
        string? apiKey = Environment.GetEnvironmentVariable("FIIX_API_KEY");
        string? accessKey = Environment.GetEnvironmentVariable("FIIX_ACCESS_KEY");
        string? secretKey = Environment.GetEnvironmentVariable("FIIX_SECRET_KEY");

        if (tenant == null || apiKey == null || accessKey == null || secretKey == null)
        {
            Console.WriteLine("Fiix variables not available from command line.");
            System.Environment.Exit(-1);
        }

        // Create a new HTTP Client
        HttpClient myFiixClient = new()
        {
            BaseAddress = new Uri($"https://{tenant}.macmmms.com")
        };

        myFiixClient.DefaultRequestHeaders.Add("Content-type", "text/plain;charset=utf-8");
        myFiixClient.DefaultRequestHeaders.Add("Authorization", FiixApiUtils.GenerateAuthSignature(tenant, apiKey, accessKey, secretKey));



        

    }
}
