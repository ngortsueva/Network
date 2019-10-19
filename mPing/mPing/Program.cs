using System;
using System.IO;
using System.Net.NetworkInformation;

namespace mPing
{
    class Program
    {
        static void Main(string[] args)
        {
            string address;
            Ping ping = null;
            int count = 4;

            Console.WriteLine("mPing 1.0");
            Console.WriteLine(args.Length);
            foreach(var item in args)
            {
                Console.WriteLine(item);
            }

            if (args.Length == 0)
            {
                Console.Write("Enter IP-address: ");
                address = Console.ReadLine();
            }
            else address = args[0];            

            try
            {
                ping = new Ping();
                for (int i = 0; i < count; i++)
                {
                    PingReply res = ping.Send(address);
                    Console.WriteLine($"{res.Address} - {res.RoundtripTime} ms - {res.Status}");
                }                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (ping != null)
                    ping.Dispose();
            }
        }
    }
}
