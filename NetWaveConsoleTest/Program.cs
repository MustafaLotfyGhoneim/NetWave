// Example GET request
using System.Text.Json.Nodes;

var url = "https://jsonplaceholder.typicode.com/posts/1";
var result = await NetWave.GetAsync<dynamic>(url);

Console.WriteLine("GET Request Result:");
Console.WriteLine(result);

// Example POST request
var postUrl = "https://jsonplaceholder.typicode.com/posts";
var body = new
{
    title = "foo",
    body = "bar",
    userId = 1
};

var postResult = await NetWave.PostAsync<dynamic, dynamic>(postUrl, body);

Console.WriteLine("\nPOST Request Result:");
Console.WriteLine(postResult);

// Example 2: Fetch a list of posts
var fetchUrl = "https://jsonplaceholder.typicode.com/posts";
var fetchResult = await NetWave.GetAsync<dynamic[]>(fetchUrl);

Console.WriteLine("GET Request (List of Posts) Result:");
foreach (var post in fetchResult)
{
    var jsonElement = (System.Text.Json.JsonElement)post;
    int id = jsonElement.GetProperty("id").GetInt32();
    string title = jsonElement.GetProperty("title").GetString();

    Console.WriteLine($"ID: {id}, Title: {title}");
}

// Example 3: Create a new post
var postNewUrl = "https://jsonplaceholder.typicode.com/posts";
var postNewBody = new
{
    title = "Mustafa's New Book",
    body = "add new book",
    userId = 1
};

var postNewResult = await NetWave.PostAsync<dynamic, dynamic>(postNewUrl, postNewBody);

Console.WriteLine("\nPOST Request Result:");
Console.WriteLine(postNewResult);

// Example 4: Nonexistent endpoint
var nonexistentUrl = "https://jsonplaceholder.typicode.com/nonexistent";
var nonexistentResult = await NetWave.GetAsync<dynamic>(nonexistentUrl);

Console.WriteLine("GET Request (Nonexistent Endpoint) Result:");
Console.WriteLine(result ?? "Endpoint not found.");

// Example 5: Fetch a complex JSON
var fetchComplexUrl = "https://jsonplaceholder.typicode.com/comments?postId=1";
var fetchComplexResult = await NetWave.GetAsync<dynamic[]>(fetchComplexUrl);

Console.WriteLine("GET Request (Complex JSON) Result:");
foreach (var comment in fetchComplexResult)
{
    var jsonElement = (System.Text.Json.JsonElement)comment;
    int id = jsonElement.GetProperty("id").GetInt32();
    string name = jsonElement.GetProperty("name").GetString();
    Console.WriteLine($"Comment ID: {id}, Name: {name}");
}


// Example 6: Invalid POST data
var invalidPostUrl = "https://jsonplaceholder.typicode.com/posts";
var invalidBody = new { invalidKey = "invalidValue" };

try
{
    var invalidResult = await NetWave.PostAsync<dynamic, dynamic>(invalidPostUrl, invalidBody);
    Console.WriteLine("POST Request (Invalid Data) Result:");
    Console.WriteLine(invalidResult);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}


// Example 7: Real API request
var apiKey = "your_openweathermap_api_key"; // Replace with a valid key
var apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Cairo&appid={apiKey}";

var apiResult = await NetWave.GetAsync<dynamic>(apiUrl);

Console.WriteLine("GET Request (Real API) Result:");
Console.WriteLine($"City: {apiResult.name}, Temperature: {apiResult.main.temp}K");
