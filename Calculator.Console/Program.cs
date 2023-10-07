using System.Web;

Console.WriteLine("Try out this amazing calculator. Press <Esc> to exit...");

var client = new HttpClient();
ConsoleKeyInfo keyInfo = default;

client.BaseAddress = new Uri("http://localhost:5266");
Console.WriteLine();

do
{
    Console.Write("Enter equation and press enter: ");
    var equation = Console.ReadLine();
    var webEncodedEquation = HttpUtility.UrlEncode(equation);
   
    var response = await client.GetAsync($"/{webEncodedEquation}");
    
    if (!response.IsSuccessStatusCode)
    {
        Console.WriteLine($"Error: {response.StatusCode}");
        continue;
    }
    
    var result = await response.Content.ReadAsStringAsync();
    
    Console.WriteLine($"Result: {result}");

} while (keyInfo.Key != ConsoleKey.Escape);

