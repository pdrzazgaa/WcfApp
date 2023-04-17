using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using WcfService;
using System.Net.Security;

namespace WcfServiceHost
{   
    internal class Program
    {
        static void Main(string[] args)
        {
            // URI dla bazowego serwisu
            Uri baseAdress = new Uri("http://localhost:8080/MyCalculator");

            // instancja serwisu
            ServiceHost myHost = new ServiceHost(typeof(MyCalculator), baseAdress);

            // endpoint serwisu
            BasicHttpBinding binding1 = new BasicHttpBinding();
            ServiceEndpoint endpoint1 = myHost.AddServiceEndpoint(typeof(ICalculator), binding1, "endpoint1");

            // ustawienie metadanych
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            myHost.Description.Behaviors.Add(smb);

            WSHttpBinding binding2 = new WSHttpBinding();
            binding2.Security.Mode = SecurityMode.None;
            ServiceEndpoint endpoint2 = myHost.AddServiceEndpoint(typeof(ICalculator), binding2, "endpoint2");

            Console.WriteLine("\n ----> Endpoints:");
            Console.WriteLine("\nService endpoint {0}:", endpoint1.Name);
            Console.WriteLine("Binding: {0}:", endpoint1.Binding.ToString());
            Console.WriteLine("ListenUri: {0}:", endpoint1.ListenUri.ToString());

            Console.WriteLine("\nService endpoint {0}:", endpoint2.Name);
            Console.WriteLine("Binding: {0}:", endpoint2.Binding.ToString());
            Console.WriteLine("ListenUri: {0}:", endpoint2.ListenUri.ToString());


            try
            {
                myHost.Open();
                Console.WriteLine("Serwis wystartował i działa");
                Console.WriteLine("Naciśnij <ENTER> aby zatrzymać serwis");
                Console.WriteLine();
                Console.ReadLine();
                myHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("Wystąpił wyjątek:", ce.Message);
                myHost.Abort();
            }
            catch (Exception e)
            {
                Console.WriteLine("Wystąpił wyjątek:", e.Message);
                myHost.Abort();
            }
        }
    }
}
