using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace Base64DiffService
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = Properties.Settings.Default.ServerURL;

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                System.Console.Out.WriteLine("Server Started");
                Console.ReadLine();
            } 
        }
    }
}
