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
        </div>
    </form>
    <form id="formQuestion" runat="server" visible ="false">
        <div>
            <%-- Display content of a Reddit post + answer form --%>
        </div>
    </form>
    <form id="formAnswer" runat="server" visible ="false">
        <div>
            <%-- Display whether the question was answered correctly + points worth + link + next question button--%>
        </div>
    </form>
    <form id="formResults" runat="server" visible ="false">
        <div>
            <%-- Display summary of questions: links and points per question + total points + start over button--%>
        </div>
    </form>
</body>
</html>
