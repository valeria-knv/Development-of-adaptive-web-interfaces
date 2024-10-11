using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    // Class Thread
    static void ThreadExample()
    {
        Console.WriteLine("Thread started: Counting from 1 to 5");
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }
        Console.WriteLine("Thread finished counting.");
    }

    // Async - First Method
    static async Task AsyncFileDownload()
    {
        Console.WriteLine("Async - File Download: Starting parallel file downloads...");

        Task download1 = SimulateFileDownload("product1.xlsx", 2000); 
        Task download2 = SimulateFileDownload("product2.xlsx", 3000);
        Task download3 = SimulateFileDownload("product3.xlsx", 1000);

        await Task.WhenAll(download1, download2, download3);
        Console.WriteLine("Async - File Download: All files downloaded.");
    }

    static async Task SimulateFileDownload(string fileName, int delay)
    {
        Console.WriteLine($"Downloading {fileName}...");
        await Task.Delay(delay);
        Console.WriteLine($"{fileName} downloaded.");
    }

    // Async - Second Method
    static async Task<long> AsyncFactorial()
    {
        Console.WriteLine("AsyncExample2: Starting factorial calculation...");
        long number = 5;
        long factorialResult = await Task.Run(() => CalculateFactorial(number));
        Console.WriteLine("AsyncExample2: Factorial calculation completed.");
        return factorialResult;
    }

    static long CalculateFactorial(long n)
    {
        long result = 1;
        for (long i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    static async Task Main(string[] args)
    {
        Thread thread = new Thread(new ThreadStart(ThreadExample));
        thread.Start();
        thread.Join(); 

        await AsyncFileDownload();
        long factorial = await AsyncFactorial();
        Console.WriteLine($"Result from AsyncFactorial (factorial of 5): {factorial}");

        Console.WriteLine("Main method completed.");
    }
}
