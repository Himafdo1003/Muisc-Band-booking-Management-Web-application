<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartPage.aspx.cs" Inherits="ArtistManagerApp.StartPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Gravity</title>
    
    <script src="Boostrap/js/popper.min.js"></script>
    <script src="Boostrap/js/jquery-3.3.1.slim.min.js"></script>
    <script src="Boostrap/js/bootstrap.js"></script>

    <link href="Boostrap/css/bootstrap.min.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.6/css/bootstrap.min.css" integrity="sha384-rwoIResjU2yc3z8GV/NPeZWAv56rSmLldC3R/AZzGRnGxQQKnKkoFVhFQhNUwEyJ" crossorigin="anonymous">
<script src="https://code.jquery.com/jquery-3.1.1.slim.min.js" integrity="sha384-A7FZj7v+d/sdmMqp/nOQwliLvUsJfDHW+k9Omg/a/EheAdgtzNs3hpfag6Ed950n" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.0/js/tether.min.js" integrity="sha384-DztdAPBWPRXSA/3eYEEUWrWCy7G5KFbe8fFjk5JAIxUYHKkDx6Qin1DkWx51bBrb" crossorigin="anonymous"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.6/js/bootstrap.min.js" integrity="sha384-vBWWzlZJ8ea9aCX4pEW3rVHjgjt7zpkNpZk+02D9phzyeVkE+jo0ieGizqPLForn" crossorigin="anonymous"></script>


</head>
<body class="text-center" >
     <style type="text/css">
        body{
            
            background-image:url(Images/Img2.jpg);
            background-repeat:no-repeat;
            background-size:cover;
            background-position:center center;
            background-attachment:fixed;
        }
       
         .auto-style1 {
             height: 205px;
         }
         .auto-style2 {
             height: 21px;
         }
    </style>
    
    <form id="form1" runat="server" class="form-signin">
        
        <br/>
        <div class="auto-style1"></div>

        <%--<img class="img-fluid" src="#" alt="" width="600px"/>--%>
        <asp:Label ID="Label1" runat="server" Text="Gravity" CssClass="img-fluid" width="600px" Font-Size="70px" Font-Bold="true" Font-Italic="true" ForeColor="White"></asp:Label>
        <br /><br />
        <div class="auto-style2"></div>
        <div class="form-group">
            <div class="col-md-12">

                 <link href="GreButton.css" rel="stylesheet" />
                <br />
                <div class="main">
                    <a runat="server" id="StrtA" class="a3" onserverclick="StrtButton_Click">Start</a>

                    <br />
                     <a runat="server" id="A1" onserverclick="BackBtn">Back to Home</a>
                </div>
            </div>
        </div>
        <br /><br />
       
    </form>
</body>
</html>

