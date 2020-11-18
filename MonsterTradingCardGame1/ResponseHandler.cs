using System;

using System.IO;



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
                        switch (request.http_verb)
                    {
                            case "GET":
                                manager.getUser(request.payload[0]["Username"]);
                                break;
                            case "POST":

                                break;
                            case "PUT":

                                break;
                            case "DELETE":

                                break;
                            default:
                                Console.WriteLine("ERROR");
                                break;

                        }
                        break;
                    case "sessions ":
                        break;
                    case "packages ":
                        break;
                    case "transactions":
                        break;
                   

                    default:
                        Console.WriteLine("ERROR");
                        break;
                }

                
                
                /*switch (request.http_verb)
                {
                    case "GET":
                        if (id > 0)
                        {
                           
                        }
                        else
                        {
                           
                        }

                        break;
                    case "POST":

                        

                        break;
                    case "PUT":
                       
                        break;
                    case "DELETE":
                       
                        break;

                    default:
                        break;


                }
                */


                // the response to send with the streamwriter
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
