using System;
using System.ServiceModel.Security;
using WebSecureCalculatorConsoleClient.WebSecureServiceReference;

namespace WebSecureCalculatorConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var client = new CalculatorClient();

                client.ClientCredentials.UserName.UserName = "test";
                client.ClientCredentials.UserName.Password = "test";

                var total = client.Add(1, 3);
                Console.WriteLine($"Total: {total}");

                Console.ReadLine();
            }
            catch (MessageSecurityException e)
            {
                Console.WriteLine("Access Denied!");
            }            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
