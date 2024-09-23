<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViaAgent.aspx.cs" Inherits="MariansArtistMangerApp.ViaAgent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Via Agent</title>


     <script src="Boostrap/js/popper.min.js"></script>
        <script src="Boostrap/js/jquery-3.3.1.slim.min.js"></script>
        <script src="Boostrap/js/bootstrap.js"></script>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />

        <link href="Boostrap/css/bootstrap.min.css" rel="stylesheet" />
        <link href="../Buttons.css" rel="stylesheet" />
</head>
<body>

     <style type="text/css">
        body{
           /* background-image:url(MariansImages/12.jpg);*/
           background: rgb(19,18,71);
background: linear-gradient(90deg, rgba(19,18,71,1) 39%, rgba(17,29,72,1) 51%, rgba(18,30,102,1) 100%);
            background-repeat:no-repeat;
            background-size:cover;
            background-position:center center;
            background-attachment:fixed;
            height:100%;
        }
         .auto-style3 {
            height: 12px;
        }
          .button {
background-color: #0088cc;
border-radius: 10px;  
   
    color:#FFFFFF;  
    text-align :center;  
    font-family:arial, helvetica, sans-serif;  
    padding: 5px 10px 10px 10px;  
    font-weight:bold;  
color: #ffffff;

width: auto;
}

.button:active,
.button:focus,
.button:hover {
background-color: #005580;
border-color: #005580;
color: #ffffff;
text-decoration: none;
}

.button:active {
box-shadow: inset 0 0.15625em 0.25em rgba(0, 0, 0, 0.15), 0 1px 0.15625em rgba(0, 0, 0, 0.05);
}

.TB {

border-radius: 10px;  
   
        border-color:dodgerblue; 
    text-align :center;  
    font-family:arial, helvetica, sans-serif;  
    padding: 5px 10px 10px 10px;  
    font-weight:bold;  



}

    </style>


    <form id="form1" runat="server">
        
    
            <link href="Content/BackBtn.css" rel="stylesheet" />
         <a runat="server" id="BackBut" class="btn btn1" onserverclick="BackButton_Click">Back</a>

        <div class="container">
               
                    
                   
                        
                        <div class="row" align="center">
                            <div class="col" align="center">
                                <strong style="color:white;" ><asp:Label ID="OrderAmountLabel" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large" Text="Via Agent" Width="320px" CssClass="img-fluid" ForeColor="white"></asp:Label></strong>
                            </div>
                        </div>
                        <br /> <br />
                   </div>






          <div class="container">

                <div class="row" align="center">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4" align="center">
                        
                        <ContentTemplate>

                        <asp:Label ID="Label1" runat="server" Text="Agent Name" Font-Bold="True" Font-Size="Large" Height="54px" ForeColor="White"></asp:Label>
                               
                        &nbsp;
                        <asp:TextBox ID="AgentNameTB" runat="server" CssClass="TB" Width="300px" Font-Bold="True" Font-Size="Large" Height="54px" BackColor="White" ForeColor="Black"></asp:TextBox>
                   </ContentTemplate>
                       
                    </div>
                   

                                              <br /><br /> <br />

                    
                   
            </div>

        </div>


         <div class="container">
                <div class="row">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4" align="center">
                        
                            
                               
                                <asp:Button class="third" ID="Go_btn" runat="server"   CssClass="button" Font-Bold="True" Font-Size="Large" Height="60px" OnClick="Go_btn_Click" Text="Go" Width="120px" />
                            
                       
                    </div>
                    <div class="auto-style4">

                                               <br /><br /> <br /><br />

                    </div>
                   
            </div>
        </div>


         <div class="container- bottom-right">
            <div class="row">
                  
                 <div class="col align-content-center" align="center">
                    <asp:Panel ID="Panel1" runat="server"     Width="100%" CssClass="col" Direction="LeftToRight" Height="420px" HorizontalAlign="Center">
                   </asp:Panel></div>
                </div>
            </div>

       <br />
        
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

