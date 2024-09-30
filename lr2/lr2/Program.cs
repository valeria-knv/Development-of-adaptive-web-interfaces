using System; // API для основних типів і операцій
using System.IO; // API для роботи з файлами і потоками
using System.Net; // API для роботи з мережею (HTTP запити)
using System.Data.SqlClient; // API для роботи з базами даних SQL
using System.Threading.Tasks; // API для асинхронних операцій
using System.Globalization; // API для роботи з культурами і форматами
using System.Xml; // API для роботи з XML-документами
using System.Text.RegularExpressions; // API для роботи з регулярними виразами
using System.Security.Cryptography;


namespace lr2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. DateTime
            DateTime now = DateTime.Now;
            CultureInfo culture = new CultureInfo("EU-UA");
            Console.WriteLine("Формат дати для України: " + now.ToString(culture));

            // 2. File
            string filePath = "example.txt";
            File.WriteAllText(filePath, "Запис до файлу!)");

            string fileContent = File.ReadAllText(filePath);
            Console.WriteLine($"Вмiст файлу: {fileContent}");

            // 3. RegularExpressions
            string[] phoneNumbers = new string[]
            {
                "+38 095 672 0031",
                "Телефон вiдсутнiй",
                "+38 067 123 4567",
                "Неправильний номер +39 123 456",
                "+38 050 555 7777"
            };

            string pattern = @"\+38 \d{3} \d{3} \d{4}";

            foreach (string phoneNumber in phoneNumbers)
            {
                Match match = Regex.Match(phoneNumber, pattern);
                if (match.Success)
                {
                    Console.WriteLine("Знайдено номер телефону: " + match.Value);
                }
                else
                {
                    Console.WriteLine("Номер телефону не знайдено в текстi: " + phoneNumber);
                }
            }

            // 4. XMLDocumnet
            string xmlContent = "<person><name>Lera</name></person>";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlContent);
            XmlNode nameNode = xmlDoc.SelectSingleNode("//name");
            Console.WriteLine($"Iм'я з XML: {nameNode.InnerText}");

            // 5. Hash
            string password = "parol123";
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                Console.WriteLine($"SHA-256 хеш пароля: {hash}");
            }
        }
    }
}
