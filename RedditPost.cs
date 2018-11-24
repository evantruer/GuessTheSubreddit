using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace GuessTheSubreddit
{
    public class RedditPost
    {
        private enum contentType
        {
            self,
            link,
            image,
            video
        }

        protected String url, title, content, subreddit;
        protected String[] topComments;
        protected int subscribers;

        protected RedditPost(String init_url, String init_title, String init_content, String init_subreddit, String[] init_topComments, int init_subscribers)
        {
            url = init_url;
            title = init_title;
            content = init_content;
            subreddit = init_subreddit;
            topComments = init_topComments;
            subscribers = init_subscribers;
        }

        protected static List<RedditPost> makeRedditPosts(int amount)
        {
            List<RedditPost> posts = new List<RedditPost>();
            //use reddit API to get  some posts e.g. https://www.reddit.com/r/all/hot.json?limit=1
            WebRequest request = WebRequest.Create("https://www.reddit.com/r/all/hot.json?limit=1000");
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            string json = String.Empty;
            using (StreamReader sr = new StreamReader(data))
            {
                json = sr.ReadToEnd();
            }
            for (int i = 0; i < amount; i++)
            {

            }
            return posts;
        }
    }