using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace MonsterTradingCardGame1
{

    public class Unwrapper
    {
        StreamReader reader;

        public Unwrapper(StreamReader reader)
        {
            this.reader = reader;
        }

        public RequestContext unwrap()
        {   //takes a streamreader and starts to take it apart line by line and saves the results into requestContext
            Action<string> debug = message => Console.WriteLine(message);
            RequestContext request = new RequestContext();
            SortedDictionary<string, string> buffer = new SortedDictionary<string, string>();
            string message = null;
            try
            {
                message = reader.ReadLine();
                string[] arr = message.Split(" ");
                request.http_verb = arr[0];
                request.requested = arr[1];
                request.http_version = arr[2];
                debug($"received: " + message);
                do
                {
                    message = reader.ReadLine();
                    debug($"received: " + message);

                    arr = message.Split(" ", 2);
                    if (arr.Length == 2)
                    {
                       
                        buffer.Add(arr[0], arr[1]);
                    }

                } while (message != "");
                request.data = buffer;
                string json = "";

                while (reader.Peek() != -1)
                {
                    
                    json += (char)reader.Read();


                }
                debug($"received: " + json);
                request.json = json;
            }
            catch (Exception exc)
            {
                debug("exception: " + exc.Message);

            }

            return request;
        }

    }
}
