using System;
using System.Collections.Generic;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        var listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:8081/");
        listener.Start();
        Console.WriteLine("Listening on http://localhost:8081/");
        while (true)
        {
            var context = listener.GetContext();
            var path = context.Request.Url.LocalPath.TrimStart('/');
            if (string.IsNullOrEmpty(path))
            {
                path = "index.html"; // serve index.html by default
            }
            ServeFile(context.Response, path);
        }

        //List<Person> people = new List<Person>
        //{
        //    new Person("Avner", "sadir", 5),
        //    new Person("Eilam", "sadir", 5),
        //    new Person("Ohad", "sadir", 5),
        //    new Person("goren", "sadir", 5)

        //};

        //ShavzakCreator shavzakCreator = new ShavzakCreator(people);
        //shavzakCreator.Run();
        //Console.WriteLine("done");

        //// Implement ToString in Shavzak to print its state
        //Console.WriteLine(shavzakCreator.NextShavzak.ToString());
    }

    static void ServeFile(HttpListenerResponse response, string filePath)
    {
        try
        {
            // Determine the MIME type based on the file extension
            string mimeType = GetMimeType(filePath);

            // Set the Content-Type header
            response.ContentType = mimeType;

            // Serve the file
            using (var fileStream = File.OpenRead(filePath))
            {
                fileStream.CopyTo(response.OutputStream);
            }
        }
        catch (Exception ex)
        {
            // Handle errors
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            response.StatusDescription = ex.Message;
        }
        finally
        {
            response.Close();
        }
    }

    static string GetMimeType(string filePath)
    {
        string ext = Path.GetExtension(filePath).ToLowerInvariant();
        switch (ext)
        {
            case ".html": return "text/html";
            case ".css": return "text/css";
            case ".js": return "application/javascript";
            // Add more cases as needed
            default: return "application/octet-stream"; // fallback MIME type
        }
    }
}
