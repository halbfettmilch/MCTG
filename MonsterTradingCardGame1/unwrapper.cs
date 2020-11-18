using System;
using System.Collections.Generic;
using System.IO;



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
                message = "";

                while (reader.Peek() != -1)
                {
                    
                    message += (char)reader.Read();


                }
                debug($"received: " + message);
                arr = message.Split(",");
                int i = 0;
                while (i<arr.Length)
                {
                   
                    string[] bufferarr;
                    bufferarr = arr[i].Split(":");
                    SortedDictionary<string, string> buffermap= new SortedDictionary<string, string>();
                    buffermap.Add(bufferarr[0], bufferarr[1]);
                    request.payload.Add(buffermap);
                    i++;
                    debug(bufferarr[0]+ " " + bufferarr[1]);
                }

            }
            catch (Exception exc)
            {
                debug("exception: " + exc.Message);

            }

            return request;
        }

    }
}
