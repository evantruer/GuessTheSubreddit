using System;
using System.Net;
using Newtonsoft.Json.Linq;


namespace ScratchPad
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            string json = client.DownloadString("https://www.reddit.com/r/all/hot.json?limit=10");
            JObject rss = JObject.Parse(json);
            string query = "data.children[*].data";
            System.Collections.Generic.IEnumerable<JToken> tokenList = rss.SelectTokens(query);
            foreach (JToken item in tokenList)
            {
                //Looking at tokens
                //Console.WriteLine(item.ToString());

                //Checking proper-ness
                //bool proper = !item.Value<bool>("over_18") && !item.Value<bool>("quarantine") && !item.Value<bool>("spoiler");
                //if (!proper)
                //{
                //    Console.WriteLine("oops!");
                //}

                //getting comments
                String commentsAPI = "https://www.reddit.com" + item.Value<String>("permalink") + ".json?limit=3";
                //Console.WriteLine(commentsAPI);
                //look at comments structure
                string commentsJson = client.DownloadString(commentsAPI);
                //commentsJson = "{" + commentsJson.Substring(1, commentsJson.Length - 2) + "}";
                commentsJson = "{\"data\" :" + commentsJson + "}";
                Console.WriteLine(commentsAPI);
                //Console.WriteLine(commentsJson);
                string commentsQuery = "..body";
                JObject commentsObject = JObject.Parse(commentsJson);
                
                System.Collections.Generic.IEnumerable<JToken> commentsList = commentsObject.SelectTokens(commentsQuery);
                foreach (JToken commentsToken in commentsList)
                {
                    Console.WriteLine(commentsToken.ToString());
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
            //Console.WriteLine(toPrint);
            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
