using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace StoreServiceHost {
    public class Program {
        static void Main(string[] args) {
            Uri httpUrl = new Uri("http://localhost:8090/StoreService");

            ServiceHost host = new ServiceHost(typeof(StoreService.StoreService), httpUrl);

            host.AddServiceEndpoint(typeof(StoreService.IStoreService), new WSHttpBinding(), "");

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);

            host.Open();
            Console.WriteLine("Service Hosted Sucessfully: " + httpUrl.AbsoluteUri);
            Console.Read();
        }
    }
}
