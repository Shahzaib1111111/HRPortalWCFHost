using System;
using System.ServiceModel;
using System.ServiceModel.Description;
namespace WCFHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Uri httpUrl = new Uri("http://localhost:8000/WCFSample/IServiceCalc");
            ServiceHost host = new ServiceHost(typeof(WCFSample.ServiceCalc), httpUrl);

            host.AddServiceEndpoint(typeof(WCFSample.IServiceCalc), new WSHttpBinding(), "");

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);

            host.Open();
            Console.WriteLine("Service is host at " + DateTime.Now.ToString());
            Console.WriteLine("Host is running... Press  key to stop");
            Console.ReadLine();
        }
    }
}
