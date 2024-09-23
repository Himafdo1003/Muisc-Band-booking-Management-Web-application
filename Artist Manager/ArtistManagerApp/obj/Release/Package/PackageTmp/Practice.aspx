<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Practice.aspx.cs" Inherits="MariansArtistMangerApp.Practice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Practice</title>

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
           /* background-image:url(MariansImages/mixer.jpg);*/
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
         .auto-style4 {
             position: relative;
             min-height: 1px;
             float: left;
             width: 100%;
             -ms-flex: 0 0 33.333333%;
             flex: 0 0 33.333333%;
             max-width: 33.333333%;
             left: 0px;
             top: 0px;
             padding-left: 15px;
             padding-right: 15px;
         }
         .auto-style5 {
             position: relative;
             min-height: 1px;
             float: left;
             width: 100%;
             -ms-flex: 0 0 33.333333%;
             flex: 0 0 33.333333%;
             max-width: 33.333333%;
             left: 0px;
             top: 0px;
             height: 46px;
             padding-left: 15px;
             padding-right: 15px;
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
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

              <link href="Content/BackBtn.css" rel="stylesheet" />
         <a runat="server" id="BackBut" class="btn btn1" onserverclick="BackButton_Click">Back</a>

        <div class="container">
               
                    
                   
                        
                        <div class="row" align="center">
                            <div class="col" align="center">
                                <strong style="color:white;" ><asp:Label ID="OrderAmountLabel" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large" Text="Practice" Width="320px" CssClass="img-fluid" ForeColor="white"></asp:Label></strong>
                            </div>
                        </div>
                        <br /> <br />
                   </div>

          <div class="container">

                <div class="row">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4" align="center">
                          
                            <ContentTemplate>


                                <asp:Label ID="Label1" runat="server" Text="Event Type" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="150px"></asp:Label>
                                <br />
                                <br /><br /> 
                             
                               <asp:DropDownList ID="DropDownList1" CssClass="TB" runat="server" Font-Bold="True" Font-Size="Large" Height="54px" Width="300px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" BackColor="White" >

                                                               
                               </asp:DropDownList>
                                
                                 <%--<asp:TextBox ID="Testing" runat="server" Height="44px" Width="200px"></asp:TextBox>--%>
                           
                               
                       
                            </ContentTemplate>    
                       
                    </div>
                    <div class="auto-style4">

                    </div>
                   
            </div>

        </div>

        <div class="container">

                <div class="row">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4" align="center">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>


                                     
                                
                               
                            </ContentTemplate></asp:UpdatePanel>
                       
                    </div>
                    <div class="auto-style4">

                    </div>
                   
            </div>

        </div>


        
          <div class="container">

                <div class="row">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4" align="center">
                        
                            <ContentTemplate>


                                <asp:Label ID="Label2" runat="server" Text="Event Time" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="125px"></asp:Label>
                                <br />
                                <br /><br />
                                 <asp:DropDownList ID="DropDownList2" CssClass="TB" runat="server" Font-Bold="True" Font-Size="Large" Height="54px" Width="300px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Enabled="False">
                                     
                               <asp:ListItem>Morning </asp:ListItem>  
                                <asp:ListItem>Evening</asp:ListItem>  
            
                                     
                                 </asp:DropDownList>
                               
                            </ContentTemplate>
                       
                    </div>
                    <div class="auto-style4">

                    </div>
                   
            </div>

        </div>

         <div class="container">

                <div class="row">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4" align="center">
                        
                            <ContentTemplate>


                                <asp:Label ID="Label4" runat="server" Text="Special Notes" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="150px"></asp:Label>
                                <br />
                                <br /><br />
                                <asp:TextBox ID="SpecialNote" CssClass="TB"  runat="server" Font-Bold="True" Font-Size="Large" Height="64px" Width="300px" TextMode="MultiLine"  ></asp:TextBox>
                               
                            </ContentTemplate>
                       
                    </div>
                    <div class="auto-style4">

                    </div>
                    <div class="col-sm-4" align="center">
                   
            </div>

        </div></div>

           <div class="container">
                <div class="row">
                    <div class="auto-style5"></div>
                    <div class="col-sm-4" align="center">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <br /><br /> <br /><br />
                                <asp:Button class="third" ID="Confirmbtn" runat="server"   CssClass="button" Font-Bold="True" Font-Size="Large" Height="60px" OnClick="ConfirmBtn_Click" Text="Confirm Booking" Width="200px" />

                            </ContentTemplate></asp:UpdatePanel>
                       
                    </div>
                    <div class="auto-style4">

                                               <br /><br /> <br /><br />

                    </div>
                   
            </div>
        </div>
        <br />

            <div class="container-fluid">
            <div class="row">

                <div class="col" align="right">
                   <img src="MariansImages/Marians3.png" alt="" width="180"/>
                </div>
            </div></div>


    </form>
</body>
</html>

