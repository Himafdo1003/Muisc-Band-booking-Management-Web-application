<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advance.aspx.cs" Inherits="MariansArtistMangerApp.Advance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Advance</title>
      
    <script src="Boostrap/js/popper.min.js"></script>
    <script src="Boostrap/js/jquery-3.3.1.slim.min.js"></script>
    <script src="Boostrap/js/bootstrap.js"></script>

    <link href="Boostrap/css/bootstrap.min.css" rel="stylesheet" />

    <link href="Buttons.css" rel="stylesheet" />
    
    </head>
<body>
     <style type="text/css">
        body{
           /* background-image:url(MariansImages/13.jpg);*/
           background: rgb(19,18,71);
background: linear-gradient(90deg, rgba(19,18,71,1) 39%, rgba(17,29,72,1) 51%, rgba(18,30,102,1) 100%);
            background-repeat:no-repeat;
            background-size:cover;
            background-position:center center;
            background-attachment:fixed;
            height:100%;
        }
         </style>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       

        
         <link href="../Content/BackBtn.css" rel="stylesheet" />
         <a runat="server" id="BackBut" class="btn btn1" onserverclick="BackButton_Click">Back</a>

        <div class="container">
               
                    
                   
                        
                        <div class="row" align="center">
                            <div class="col" align="center">
                                <strong style="color:white;" ><asp:Label ID="OrderAmountLabel" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large" Text="Advance" Width="320px" CssClass="img-fluid" ForeColor="white"></asp:Label></strong>
                            </div>
                        </div>
                        <br /> <br />
                   </div>

        <div class="container align-content-center">
                <div class="row" align="center">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4" align="center">
                        
                    </div>
                   
                   
            </div>
        </div>

        <div class="container">
                <div class="row" align="center">
                    <div class="col-sm-4"></div>
                    
                    <div class="col-md-4 text-center">
                         <div class="row">
                            <div class="col">
                                <strong style="color:white;" ><asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="X-Large" Text=""></asp:Label></strong>
                            </div>
                        </div>
                        <br /> <br />
                    </div>
                   
            </div>
        </div>





         
         <div class="container">
                <div class="row">
                    <div class="auto-style5"></div>
                    <div class="col-sm-4" align="center">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                 <br /><br /><br />
                            </ContentTemplate></asp:UpdatePanel>
                       
                    </div>
                    <div class="auto-style4">

                                                <br /><br /> <br /><br />

                    </div>
                   
            </div>
        </div>

         <br /><br />
         <div class="container-fluid">
            <div class="row">

                <div class="col" align="right">
                   <img src="MariansImages/Marians3.png" alt="" width="180"/>
                </div>
            </div></div>

  <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <!-- Include all compiled plugins (below), or include individual files as needed -->
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>


        

    </form>
</body>
</html>


