using WebSecureCalculatorServiceLibrary;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WebSecureCalculatorSelfHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var baseUrlTcp = "net.tcp://localhost:6789/";
            var tcpBaseAddress = new Uri(baseUrlTcp);

            var serviceHost = new ServiceHost(typeof(Calculator), new Uri[] { tcpBaseAddress });

            var tcpBinding = new NetTcpBinding();
            tcpBinding.Security.Mode = SecurityMode.Message;
            //adding windows security!
            tcpBinding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;

            var serviceEndpoint = serviceHost.AddServiceEndpoint(typeof(ICalculator), tcpBinding, baseUrlTcp);

            var behavior = new ServiceMetadataBehavior();
            serviceHost.Description.Behaviors.Add(behavior);

            var baseMexUrl = "net.tcp://localhost:6789/mex";
            var tcpMex = serviceHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), baseMexUrl);

            serviceHost.Open();

            Console.WriteLine("Service started...");

            foreach (var endpoint in serviceHost.Description.Endpoints)
            {
                Console.WriteLine($"Address: {endpoint.Address}");
                Console.WriteLine($"Binding: {endpoint.Binding}");
                Console.WriteLine($"Contract: {endpoint.Contract.Name}\n");
            }

            Console.WriteLine("Press any key to stop");
            Console.ReadKey();

            serviceHost.Close();
        }
    }
}
