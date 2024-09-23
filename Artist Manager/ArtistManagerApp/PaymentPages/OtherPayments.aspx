<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OtherPayments.aspx.cs" Inherits="ArtistManagerApp.PaymentPages.OtherPayments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Other Payments</title>
    <script src="../Boostrap/js/popper.min.js"></script>
    <script src="../Boostrap/js/jquery-3.3.1.slim.min.js"></script>
    <script src="../Boostrap/js/bootstrap.js"></script>

    <link href="../Boostrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Buttons.css" rel="stylesheet" />
</head>
<body >
    <style type="text/css">
        body{
          /*  background-image:url(../MariansImages/image.jpg);*/
            background-repeat:no-repeat;
            background-size:cover;
            background-position:center center;
            background-attachment:fixed;
            height:100%;
        }
         </style>
    <form id="form1" runat="server">


        <div class="container">
                <br />
                <div class="row">
                    <div>
                   
                        <br />
                    </div>
                    <div class="col-md-4">
                        <br/><br/>
                        <div class="row">
                            <div class="col">
                                <link href="../cssButton/back.css" rel="stylesheet" />
                                <div class="main">
                                     <a runat="server" id="BackBut" class="a3" onserverclick="BackButton_Click">Back</a>
                                </div>
                                <%--<asp:Button class="third" ID="BackToOrderButton" runat="server" BackColor="White" BorderStyle="Solid" Font-Size="XX-Large" OnClick="BackToOrderButton_Click" Text="Menu " style=" width:150px; height:80px;" />--%>
                            </div>
                        </div>
                        <br/><br/>
                        <div class="row">
                            <div class="col">
                                
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 text-center">
                        
                        <div class="row">
                            <div class="col"><br />
                                <strong style="color:white;" ><asp:Label ID="OrderAmountLabel" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large" Text="Other Payments" Width="320px" CssClass="img-fluid" ForeColor="Black"></asp:Label></strong>
                            </div>
                        </div>
                        <br /> <br />
                    </div>
                </div>
            </div>

          
        <div class="container">
                <div class="row">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4" align="center">
                        
                    </div>
                    <div class="auto-style4">

                                                 <br /><br /> <br />

                    </div>
                   
            </div>
        </div>


      
         
        

        <div class="container-fluid align-bottom">
            <div class="row align-bottom">

                <div class="col" align="right">
                   <img src="/#" alt="" width="180"/>
                </div>
            </div></div>

  <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <!-- Include all compiled plugins (below), or include individual files as needed -->
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    </form>
</body>
</html>
