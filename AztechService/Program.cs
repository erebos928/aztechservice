using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace AztechService
{
    class Program
    {
        public static void Main(String[] args)
        {
            ServiceHost host =
             new WebServiceHost(typeof(Explorer), new Uri("http://localhost:8733/Design_Time_Addresses/AztechService/Service1/"));
            //flag to check if call to Open succeeded

            bool openSucceeded = false;
            try
            {
                host.Open();
                openSucceeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ServiceHost failed to open {0}", ex.ToString());
            }
            finally
            { //call Abort since the object will be in the Faulted state
                if (!openSucceeded)
                    host.Abort();
            }
            if (openSucceeded)
            {
                Console.WriteLine("Service is running...");
                Console.ReadLine();
            }
            else
                Console.WriteLine("Service failed to open");
            Console.ReadKey();
        }
    }
}
