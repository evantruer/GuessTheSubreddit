<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="GuessTheSubreddit.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formAbout" runat="server" visible ="false">
        <div>
            <%-- Display welcome message + disclaimers + get started button --%>
            <asp:Label ID="welcomeText" runat="server" />
            <asp:Button ID="startButton" title="Start" Text="Start"  runat="server" OnClick="ButtonStartButton_Click"/>
        </div>
    </form>
    <form id="formQuestion" runat="server" visible ="false">
        <div>
            <%-- Display content of a Reddit post + answer form --%>
            <asp:Label ID="questionText" runat="server" />
            <asp:TextBox ID="answerBox" runat="server"/>
            <asp:Button ID="submitButton" title="Submit Answer" Text="Submit Answer" runat="server" OnClick="ButtonSubmitButton_Click"/>
        </div>
    </form>
    <form id="formAnswer" runat="server" visible ="false">
        <div>
            <%-- Display whether the question was answered correctly + points worth + link + next question button--%>
            <asp:Label ID="feedbackText" runat="server" />
            <asp:Button ID="ContinueButton" title="Continue" Text="Continue" runat="server" OnClick="ButtonContinueButton_Click"/>
        </div>
    </form>
    <form id="formResults" runat="server" visible ="false">
        <div>
            <%-- Display summary of questions: links and points per question + total points + start over button--%>
            <asp:Label ID="resultsText" runat="server" />
            <asp:Button ID="RestartButton" title="Restart" Text="Restart" runat="server" OnClick="ButtonRestartButton_Click"/>
        </div>
    </form>
</body>
</html>
