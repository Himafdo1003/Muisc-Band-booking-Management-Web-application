<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEnter.aspx.cs" Inherits="MariansArtistMangerApp.UserEnter" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  
    <title>Marians</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.14.0/css/all.min.css" integrity="sha512-1PKOgIY59xJ8Co8+NE6FZ+LOAZKjy+KY8iq0G4B3CyeY6wYHN3yt9PW0XpSriVlkMXe40PTKnXrLnZ9+fkDaog==" crossorigin="anonymous" />
    <link href="Content/BackBtn.css" rel="stylesheet" />
    <link href="Content/customerlogin.css" rel="stylesheet" />
</head>
<body>

     <style type="text/css">
        body{
            background-image: url('/MariansImages/10.jpg');
    background-position: center center;
    background-repeat: no-repeat;
    background-attachment: fixed;
    background-size: cover;
        }
 
    </style>
    <form id="form1" runat="server">
            <a runat="server" id="BackBut" class="btn btn1" onserverclick="BackButton_Click">Back</a>
        <div class="container" height="13px">

        </div>

        <div class="container">
        <div class="myCard">
            <div class="row">
                <div class="col-md-6">
                    <div class="myLeftCtn"> 
                        <form class="myForm text-center">
                            <header>Login to your account</header> <br>

                            <div class="form-group">
                                <i class="fas fa-lock"></i>
                               
                               
                                <asp:TextBox ID="CodeTextBox" runat="server" class="myInput" placeholder=" Enter Code" TextMode="Password"></asp:TextBox>
                            </div>

                          <%-- <%-- <div class="form-group">
                                
                                <%--  <input class="myInput" type="password" id="password" placeholder="Password" required> 

                                  <asp:TextBox ID="PasswordTB" runat="server" class="myInput" placeholder="Password" TextMode="Password"></asp:TextBox>
                            </div>--%>

                            <div class="form-group">
                                <label>
                                  <small> Use your Staff Code to login to the account.</small></input> 
                                    <br>
                                    </label>
                            </div>

                           <%-- <input type="submit" class="butt" value="CREATE ACCOUNT">--%>
                            <asp:Button ID="LoginBtn" class="butt" runat="server" Text="Login" OnClick="Go_Click" />
                            
                        </form>
                    </div>
                </div> 
                <div class="col-md-6">
                    <div class="myRightCtn">
                            <div class="box"><header>Marians Smart Calendar</header>
                            
                            <p>Marians, under the leadership of Nalin Perera was established as a musical band in 1988 and now has marked it’s acme in the music industry of Sri Lanka winning the hearts of millions both locally and globally with the newness and the remarkable change it has brought to the industry as a versatile band covering a wide range of music genres such as pop, semi-rock, and western classical. </p>
                               <%-- <input type="button" class="butt_out" value="Learn More"/>--%>
                            </div>
                                
                    </div>
                </div>
            </div>
        </div>
</div>
    </form>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
   <script src="assets/js/Back.js"></script>
</body>
</html>