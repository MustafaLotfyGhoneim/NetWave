# NetWave

NetWave is a lightweight and powerful HTTP client library designed specifically for .NET 8 applications. It simplifies making HTTP requests and provides seamless integration with RESTful APIs. With NetWave, developers can perform GET and POST requests easily while benefiting from enhanced error handling, detailed logs, and user-friendly exceptions.

---

## **Features**

- **Ease of Use**: Intuitive and developer-friendly APIs, abstracting away the complexity of HTTP requests.
- **Compatibility**: Optimized for .NET 8, leveraging the latest features and enhancements.
- **Performance**: Built on top of `HttpClient`, ensuring high performance and low memory overhead.
- **Detailed Logs**: Comprehensive logging for each request and response, making debugging easier.
- **Flexible Serialization**: Out-of-the-box support for JSON serialization/deserialization using `System.Text.Json`.
- **Error Handling**: Meaningful exceptions with detailed messages to quickly identify issues.

---

## **Installation**

Install the package via NuGet:

```bash
dotnet add package NetWave
```


## **Usage**
1-  **Perform GET Requests** <br />
Fetch data from an API endpoint:

```c#
using NetWave;

var url = "https://jsonplaceholder.typicode.com/posts";
var result = await NetWave.GetAsync<dynamic[]>(url);

Console.WriteLine("GET Request Result:");
foreach (var item in result)
{
    Console.WriteLine($"ID: {item.id}, Title: {item.title}");
}
```

2- **Perform POST Requests** <br/>
Send data to an API endpoint:

```c#
using NetWave;

var postUrl = "https://jsonplaceholder.typicode.com/posts";
var body = new { title = "foo", body = "bar", userId = 1 };

var postResult = await NetWave.PostAsync<dynamic, dynamic>(postUrl, body);

Console.WriteLine("POST Request Result:");
Console.WriteLine($"Created ID: {postResult.id}");
```
3- **Handle Errors Gracefully** <br/>
NetWave automatically logs errors, but you can handle them explicitly if needed:

```c#
using NetWave;

try
{
    var url = "https://invalid.api.endpoint";
    var result = await NetWave.GetAsync<dynamic>(url);
    Console.WriteLine(result ?? "Request failed.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

```


## **Why Choose NetWave?**

- **Developer-Centric**: Simplifies HTTP interactions, letting you focus on your application's logic.
- **Modern Features**: Built to harness the power of .NET 8.
- **Reliable**: Tested to ensure stability across various use cases.
---
## **License** <br/>
This project is licensed under the MIT License.

## **Contact** <br/>
For support or feedback, feel free to reach out via the GitHub Issues page.

## **Examples** <br/>
![image](https://github.com/user-attachments/assets/535a25a5-0c93-40a0-9eb8-cacebbfdf1b9)

![image](https://github.com/user-attachments/assets/3707b915-500f-425e-b551-6f1608273eeb)
