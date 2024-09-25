using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bogus;
using ClosedXML.Excel;
using CsvHelper;
using FluentValidation;
using HtmlAgilityPack;
using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NodaTime;
using RestSharp;



namespace lr2
{
    // Клас для MediatR
    public class Ping : IRequest<string> { }

    public class PingHandler : IRequestHandler<Ping, string>
    {
        public Task<string> Handle(Ping request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Message from MediatR");
        }
    }

    public delegate object ServiceFactory(Type serviceType);


    // Клас для AutoMapper
    public class Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
    }


    // Модель для CSV
    public class CsvPerson
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
    }


    // Клас для FluentValidation
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("First Name cannot be empty");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Last Name cannot be empty");
            RuleFor(p => p.Email).EmailAddress().WithMessage("Invalid email format");
        }
    }


    // Клас для MassTransit (обмін повідомленнями)
    public class Message
    {
        public string? Text { get; set; }
    }


    // Основний клас програми
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // 1. NodaTime
            var now = SystemClock.Instance.GetCurrentInstant();
            var timeZone = DateTimeZoneProviders.Tzdb["Europe/Kyiv"];
            var zonedTime = now.InZone(timeZone);
            Console.WriteLine($"Current Time in Kyiv (NodaTime): {zonedTime}");

            // 2. MediatR
            var services = new ServiceCollection();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            services.AddTransient<IRequestHandler<Ping, string>, PingHandler>();

            var provider = services.BuildServiceProvider();
            var mediator = provider.GetRequiredService<IMediator>();
            var response = await mediator.Send(new Ping());

            Console.WriteLine($"MediatR Response: {response}");

            // 3. RestSharp
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("users", Method.Get);
            var apiResponse = await client.ExecuteAsync(request);

            Console.WriteLine($"RestSharp Response Status: {apiResponse.StatusCode}");
            Console.WriteLine($"RestSharp Response Content: {apiResponse.Content}");

            // 4. Bogus
            var faker = new Faker<Person>()
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.Email, f => f.Internet.Email())
                .RuleFor(p => p.DateOfBirth, f => f.Date.Past(30));

            var fakePeople = faker.Generate(10);

            // 5. FluentValidation
            var validator = new PersonValidator();
            foreach (var person in fakePeople)
            {
                var result = validator.Validate(person);
                if (!result.IsValid)
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                    }
                }
            }

            // 6. AutoMapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Person, CsvPerson>());
            var mapper = new Mapper(config);
            var csvPeople = mapper.Map<List<CsvPerson>>(fakePeople);

            // 7. CsvHelper
            using (var writer = new StreamWriter("people.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(csvPeople);
            }
            Console.WriteLine("Data written to people.csv");

            // 8. ClosedXML
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("People");

            worksheet.Cell(1, 1).Value = "First Name";
            worksheet.Cell(1, 2).Value = "Last Name";
            worksheet.Cell(1, 3).Value = "Email";
            worksheet.Cell(1, 4).Value = "Date of Birth";

            for (int i = 0; i < fakePeople.Count; i++)
            {
                worksheet.Cell(i + 2, 1).Value = fakePeople[i].FirstName;
                worksheet.Cell(i + 2, 2).Value = fakePeople[i].LastName;
                worksheet.Cell(i + 2, 3).Value = fakePeople[i].Email;
                worksheet.Cell(i + 2, 4).Value = fakePeople[i].DateOfBirth;
            }

            workbook.SaveAs("people.xlsx");
            Console.WriteLine("Data written to people.xlsx");

            // 9. HtmlAgilityPack
            var doc = new HtmlDocument();
            var html = "<html><body></body></html>";
            doc.LoadHtml(html);
            //var p = doc.DocumentNode.SelectSingleNode("//p");
            var p = HtmlNode.CreateNode("<p></p>");
            doc.DocumentNode.SelectSingleNode("//body").AppendChild(p);

            Console.WriteLine("Generated Data (Bogus):");
            foreach (var person in fakePeople)
            {
                var personNode = HtmlNode.CreateNode($"<strong>{person.FirstName} {person.LastName}, {person.Email}, DOB: {person.DateOfBirth.ToShortDateString()}</strong>");
                p.AppendChild(personNode);
            }
            Console.WriteLine($"{p.InnerText}");

            // 10. MassTransit
            var busControl = Bus.Factory.CreateUsingInMemory(cfg =>
            {
                cfg.ReceiveEndpoint("message_queue", ep =>
                {
                    ep.Handler<Message>(context =>
                    {
                        return Console.Out.WriteLineAsync($"Received: {context.Message.Text}");
                    });
                });
            });

            await busControl.StartAsync();
            try
            {
                try
                {
                    await busControl.Publish(new Message { Text = "Hello, World!" });
                    Console.WriteLine("Message published. Press any key to exit.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error publishing message: {ex.Message}");
                }

                Console.ReadKey();
            }
            finally
            {
                await busControl.StopAsync();
            }
        }
    }

}