using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GuessTheSubreddit
{
    public partial class Main : System.Web.UI.Page
    {
        private enum pageState
        {
            about,
            question,
            answer,
            results
        }

        private static pageState currentState = pageState.about;
        private static List<RedditPost> postsUsed = new List<RedditPost>();
        private static int currentQuestion = 0;
        private static int points = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //testLabel.Text = "According to all known laws of aviation, a bee should not be able to fly";
        }

        private class RedditPost
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
        }
    }
}