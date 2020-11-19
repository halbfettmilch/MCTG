using System;

using System.IO;
using Newtonsoft.Json;


namespace MonsterTradingCardGame1
{
    public class ResponseHandler
    {
        private StreamWriter writer;

        public ResponseHandler(StreamWriter writer)
        {
            this.writer = writer;
        }

        public void response(RequestContext request, GameManager manager)
        {   // gets the sent parameter and depending on that manipulates our Database
            string[] arr = request.requested.Split("/");
            string VERSION = request.http_version;
            string NAME = "AndreasServer";
            string status = "200 OK";
            string mime = "text/html";
            string load = "";

            if ((arr.Length == 2 || arr.Length == 3))
            {
                switch (arr[1])
                {
                    case "users":
                        User userbuffer1 = JsonConvert.DeserializeObject<User>(request.json);
                        switch (request.http_verb)
                    {
                            case "GET":
                               manager.getUser(userbuffer1.Username);
                                break;
                            case "POST":
                                manager.setUser(userbuffer1.Username,userbuffer1.Password);

                                break;
                            case "DELETE":
                                manager.deleteUser(userbuffer1.Username);

                                break;
                               
                            default:
                                Console.WriteLine("ERROR");
                                break;
                    }
                        break;
                    case "sessions ":
                        User userbuffer2 = JsonConvert.DeserializeObject<User>(request.json);

                        break;
                    case "packages ":
                        break;
                    case "transactions":
                        break;
                   

                    default:
                        Console.WriteLine("ERROR");
                        break;
                }

               
                string response =
                    string.Format(
                        "{0} {1}\r\nServer: {2}\r\nContent-Type: {3}\r\nAccept-Ranges: bytes\r\nContent-Lenght: {4}\r\n\r\n {5}\r\n",
                        VERSION, status, NAME, mime, load.Length, load);
                Console.WriteLine("Writing:\n{0}", response);

                writer.Write(response, 0, response.Length);
            }
        }
    }
}
