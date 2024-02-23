using System;
using System.Collections.Generic;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        var listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:8081/"); // Set the URL to serve your Vue.js app
        listener.Start();
        Console.WriteLine("Listening on http://localhost:8081/");

        while (true)
        {
            var context = listener.GetContext();
            var requestUrl = context.Request.Url.AbsolutePath;
            var currDir = Directory.GetCurrentDirectory();
            var neededDir = Directory.GetParent(currDir).Parent.Parent.Parent.ToString().Replace('\\', '/');
            Console.WriteLine($"{currDir}");
            var fullDir = neededDir + "/ClientApp/public/";
            var filePath = Path.Combine(fullDir, requestUrl.TrimStart('/'));
            Console.WriteLine(filePath);

            if (filePath.EndsWith("/"))
            {
                filePath += "index.html"; // Serve index.html by default
            }

            if (File.Exists(filePath))
            {
                var response = context.Response;
                var fileContent = File.ReadAllText(filePath);

                response.ContentType = "text/html"; // Set the appropriate content type
                response.ContentLength64 = fileContent.Length;

                using (var writer = new StreamWriter(response.OutputStream))
                {
                    writer.Write(fileContent);
                }
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Response.Close();
            }
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
}
