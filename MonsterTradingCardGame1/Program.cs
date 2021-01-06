using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;



namespace MonsterTradingCardGame1
{
    class Program
    {
        private static GameManager myGm = GameManager.getInstance();
        
        
        static async Task Main(string[] args)
        {
            // initiate a new Tcp connection
            //check Database connection
            DatabaseService.TestConnection();
            //DatabaseService.InsertUser("vollmilch","123");

            Console.CancelKeyPress += (sender, e) => Environment.Exit(0);
            Console.WriteLine("starting Server... ");


            List<Task> tasks = new List<Task>();
            TcpListener listener = new TcpListener(IPAddress.Loopback, 10001);
            listener.Start(5);
            try
            {
                while (true)
                {
                    var socket = await listener.AcceptTcpClientAsync();
                    tasks.Add(Task.Run(() => SingleConnection(socket)));
                    Console.WriteLine("connected: ");
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("error occurred: " + exc.Message);
            }

            Task.WaitAll(tasks.ToArray());
        }



        // the "main menu" for a single connection with all its working classes
        public static void SingleConnection(TcpClient client)
        {
            Action<string> debug = message => Console.WriteLine(message);


            debug("starting connection...");
            using var writer = new StreamWriter(client.GetStream()) { AutoFlush = true };
            using var reader = new StreamReader(client.GetStream());
            Unwrapper wrapper = new Unwrapper(reader);
            RequestContext request;
            request = wrapper.unwrap();
            ResponseHandler response = new ResponseHandler(writer);
            response.response(request, myGm);
            client.Close();
        }

    }

}