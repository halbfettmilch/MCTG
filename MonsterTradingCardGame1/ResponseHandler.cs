using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


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
                        JObject obj = JObject.Parse(request.json);
                        string name = (string)obj["Username"];
                        string password = (string)obj["Password"];
                        switch (request.http_verb)
                        {
                            case "GET":

                                load = manager.getUser(name);
                                break;
                            case "POST":
                                load = manager.setUser(name, password);

                                break;
                            case "DELETE":
                                load = manager.deleteUser(name);

                                break;

                            default:
                                Console.WriteLine("ERROR1");
                                break;
                        }
                        break;
                    case "sessions":
                        JObject obj1 = JObject.Parse(request.json);
                        string name1 = (string)obj1["Username"];
                        string password1 = (string)obj1["Password"];
                        switch (request.http_verb)
                        {
                            case "POST":
                                load = manager.login(name1, password1);
                                break;
                            case "DELETE":
                                load = manager.logout(name1, password1);
                                break;

                            default:
                                Console.WriteLine("ERROR2");
                                break;
                        }

                        break;
                    case "transactions":
                        switch (arr[2])
                        {
                            case "packages":
                                string[] arrbuffer1 = request.data["Authorization:"].Split(new Char[] { ' ', '-' });
                                load = manager.acuirePackage(arrbuffer1[1]);
                                break;
                        }
                        break;

                   
                    case "cards":
                        string[] arrbuffer3 = request.data["Authorization:"].Split(new Char[] { ' ', '-' });
                        load = manager.showUsercards(arrbuffer3[1]);
                        break;


                    default:
                        Console.WriteLine("ERROR3");
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
