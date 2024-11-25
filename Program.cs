using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using WCFService;
namespace WCFHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8000");

            using (ServiceHost host = new ServiceHost(typeof(NotificationService), baseAddress))
            {
                try
                {
                    host.AddServiceEndpoint(
                        typeof(INotificationService),
                        new BasicHttpBinding(),
                        "NotificationService");

                    var smb = new ServiceMetadataBehavior
                    {
                        HttpGetEnabled = true
                    };
                    host.Description.Behaviors.Add(smb);

                    host.Open();
                    Console.WriteLine("Service is running at {0}", baseAddress);
                    Console.WriteLine("Press Enter to terminate the service.");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    host.Abort();
                }
                finally
                {
                    if (host.State == CommunicationState.Opened)
                    {
                        host.Close();
                    }
                }
            }

        }
    }
}
