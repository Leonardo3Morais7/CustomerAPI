using CustomerAPI.Domain;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    
    static async Task Main()
    {
        string baseUrl = "http://localhost:5094/api/";
        HttpClient client = new HttpClient();
        var redoTest = "";
        do
        {
            int numRequests = 0;
            int numCustomers = 0;
            int numOffset = 0;

            Console.WriteLine("Customer simulation requests.");
            do
            {
                Console.WriteLine("How many requests you want to send?");
                Int32.TryParse(Console.ReadLine(), out numRequests);
            }
            while (numRequests <= 0);
            do
            {
                Console.WriteLine("How many customers you want to send in each request? (min. 2)");
                Int32.TryParse(Console.ReadLine(), out numCustomers);
            }
            while (numCustomers < 2);

            numOffset = await GetMaxInt(client, baseUrl);
            List<Task> customersRequest = GenerateRequestTasks(client, baseUrl, numRequests, numCustomers, numOffset);

            await Task.WhenAll(customersRequest);

            

            Console.WriteLine("\n All requests completed.");
            do
            {
                Console.WriteLine("Do you want to make another simulation? (y/n)");
                redoTest = Console.ReadLine().ToLower();
            }
            while (redoTest != "y" && redoTest != "n");

        }
        while (redoTest != "n");

        client.Dispose();
    }
    static async Task<int> GetMaxInt(HttpClient client, string baseUrl)
    {
        var response = await client.GetAsync(baseUrl + "customer");

        var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};
        var responseContent = await response.Content.ReadAsStringAsync();
        List<Customer> customers = JsonSerializer.Deserialize<List<Customer>>(responseContent, options);


        if(customers.Count > 0)
            return customers.Max(p => p.Id);
        else
            return 0;
    }

    static List<Task> GenerateRequestTasks(HttpClient client, string baseUrl, int numRequests, int numCustomers, int numOffset)
    {

        List<Task> postRequests = new List<Task>();
        for (int i = 0; i < numRequests; i++)
        {
            var customers = new List<Customer>();
            for (int j = 1; j <= numCustomers; j++)
            {
                customers.Add(new Customer((i * numCustomers) + j + numOffset));
            }
            postRequests.Add(SendPostAsync(client, baseUrl, customers));
            postRequests.Add(SendGetAsync(client, baseUrl));
        }
        return postRequests;
    }

    static async Task SendPostAsync(HttpClient client, string baseUrl, List<Customer> bodyObject)
    {
        var requestBody = JsonSerializer.Serialize(bodyObject);
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await client.PostAsync(baseUrl + "customer", content);
        Console.WriteLine("POST Request sent with body: " + WriteCustomers(bodyObject));
        Console.WriteLine("POST Request Status Code: " + response.StatusCode);
    }

    static async Task SendGetAsync(HttpClient client, string baseUrl)
    {
        var response = await client.GetAsync(baseUrl + "customer");

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var responseContent = await response.Content.ReadAsStringAsync();
        List<Customer> customers = JsonSerializer.Deserialize<List<Customer>>(responseContent, options);

        Console.WriteLine("GET Request response: " + WriteCustomers(customers));
    }

    static string WriteCustomers(List<Customer> customers)
    {
        string customersList = "";

        foreach (var customer in customers)
        {
            customersList = customersList + customer.ToString() + "\n";
        }

        return customersList;
    }
}
