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

        //Resets the page
        protected void Page_Load(object sender, EventArgs e)
        {
            //testLabel.Text = "According to all known laws of aviation, a bee should not be able to fly";
            if (!Page.IsPostBack)
            {
                currentState = pageState.about;
                welcomeText.Text = "Welcome Text";
                formAbout.Visible = true;
                formQuestion.Visible = false;
                formAnswer.Visible = false;
                formResults.Visible = false;
                currentQuestion = 1;
            }
        }

        //Sets up the test and shows the first question
        protected void ButtonStartButton_Click(object sender, EventArgs e)
        {
            questionText.Text = "Question: " + currentQuestion.ToString();
            formAbout.Visible = false;
            formQuestion.Visible = true;
            formAnswer.Visible = false;
            formResults.Visible = false;
        }

        //Checks the submitted answer agaisnt the real answer and then shows the question results page
        protected void ButtonSubmitButton_Click(object sender, EventArgs e)
        {
            feedbackText.Text = "Answer: " + currentQuestion.ToString();
            formAbout.Visible = false;
            formQuestion.Visible = false;
            formAnswer.Visible = true;
            formResults.Visible = false;
        }

        //Shows the next question (or if 10 questions have passed) the results page
        protected void ButtonContinueButton_Click(object sender, EventArgs e)
        {
            currentQuestion++;
            questionText.Text = "Question: " + currentQuestion.ToString();
            if (currentQuestion > 10)
            {
                formAbout.Visible = false;
                formQuestion.Visible = false;
                formAnswer.Visible = false;
                formResults.Visible = true;
            }
            else
            {
                formAbout.Visible = false;
                formQuestion.Visible = true;
                formAnswer.Visible = false;
                formResults.Visible = false;
                resultsText.Text = "Done!";
            }
        }

        //Restarts the quiz
        protected void ButtonRestartButton_Click(object sender, EventArgs e)
        {
            //formAbout.Visible = true;
            //formQuestion.Visible = true;
            //formAnswer.Visible = false;
            //formResults.Visible = false;
            Response.Redirect(Request.RawUrl);
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