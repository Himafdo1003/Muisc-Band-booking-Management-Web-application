<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="ArtistManagerApp.Customer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer</title>
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
          /*  background-image:url(MariansImages/44.jpg);*/
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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
      <link href="Content/BackBtn.css" rel="stylesheet" />
         <a runat="server" id="BackBut" class="btn btn1" onserverclick="BackButton_Click">Back</a>

        <div class="container">
               
                    
                   
                        
                        <div class="row" align="center">
                            <div class="col" align="center">
                                <strong style="color:white;" ><asp:Label ID="OrderAmountLabel" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large" Text="Customers" Width="320px" CssClass="img-fluid" ForeColor="white"></asp:Label></strong>
                            </div>
                        </div>
                        <br />
                   </div>
        
        <div class="container" >
          <div class="row" align="center">
             
            <div class="col-sm-12" ><br />
                            <asp:TextBox ID="SearchTextBox" runat="server" BackColor="White" placeholder="Name or TP Number"  ToolTip="Search By Name, Phone or NIC Number" Height="60px" Font-Bold="True" Font-Size="X-Large" OnTextChanged="SearchTextBox_TextChanged2" CssClass="TB"></asp:TextBox>
                            <br />
                   
                             <asp:Button class="third" ID="SearchButton" runat="server" OnClick="SearchButton_Click1" Text="Search"  CssClass="button" Font-Bold="True" Font-Size="Medium" Width="120px" Height="60px" />
                          <asp:Button class="third" ID="NewButton1" runat="server" OnClick="NewButton_Click" Text="New User"  CssClass="button" Font-Bold="True" Font-Size="Medium" Width="120px" Height="60px" />
   
                            </div>
                       
                    </div></div>



         <br /><br />
         

        <div class="container">
    <div class="row">
      <div class="col-md-12">
        <div class="table-responsive">
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" CellPadding="4"  ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Visible="False" Font-Size="medium" width="100%" HorizontalAlign="Center" OnRowDataBound="GridView1_RowDataBound"   >
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Height="60px" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                            </asp:GridView>
                                        </div></div>
                                        
                    </div>

                </div>




        <div class="container">
    <div class="row" align="center">
      <div class="col-md-12" align="center">

           <strong><asp:Label ID="NameLabel" runat="server" Text="Name" Visible="False" ForeColor="White" Font-Size="Medium"></asp:Label></strong><br />
                                        <asp:TextBox ID="NameTextBox" runat="server"  CssClass="TB"  Height="50px" Width="300px" Visible="False" Font-Bold="True" Font-Size="Large"></asp:TextBox>
                                        <br />
        <strong><asp:Label ID="PhoneLabel" runat="server"  Text="Phone No" Visible="False" ForeColor="White" Font-Size="Medium"></asp:Label></strong><br />

                                        <asp:TextBox ID="PhoneTextBox" runat="server" CssClass="TB" Width="300px" Visible="False" Height="50px" OnTextChanged="PhoneTextBox_TextChanged1" Font-Bold="True" Font-Size="Large"></asp:TextBox>
                                        <br />
                                        <strong><asp:Label ID="AddressLabel" runat="server" Text="Address" Visible="False" ForeColor="White" Font-Size="Medium"></asp:Label></strong><br />
                                        <asp:TextBox ID="AddressTextBox" runat="server" CssClass="TB"  Height="50px" Width="300px" Visible="False" Font-Bold="True" Font-Size="Large"></asp:TextBox>
                                        <br />
                                        <strong><asp:Label ID="EmailLabel" runat="server" Text="Email" Visible="False" ForeColor="White" Font-Size="Medium"></asp:Label></strong><br />
                                        <asp:TextBox ID="EmailTextBox" runat="server" CssClass="TB" Width="300px" Visible="False" Height="50px" Font-Bold="True" Font-Size="Large"></asp:TextBox>
                                        <br />
                                        <strong><asp:Label ID="NICNumberLabel" runat="server" Text="NIC No" Visible="False" ForeColor="White" Font-Size="Medium"></asp:Label></strong><br />
                                        <asp:TextBox ID="NICNumberTextBox" runat="server" CssClass="TB" Width="300px" Visible="False" Height="50px" Font-Bold="True" Font-Size="Large"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="ValidateLabel" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Text="Please Fill All the fields to Register" Visible="False"></asp:Label>
                                        
                              </div>
        </div>
            </div>

                        
                        <div class="col-md-12" align="center">
                            <br />
                            <asp:Button class="third" ID="NewButton" runat="server"  CssClass="button" Font-Bold="True" Font-Size="Medium" Text="New" Visible="False" OnClick="NewButton_Click" Height="60px" Width="120px" /><br/>
                              <br /><br />
                            <asp:Button class="third" ID="Button1" runat="server"  CssClass="button"  Font-Bold="True" Font-Size="Medium" OnClick="Button1_Click" Text="Register" Visible="False" Width="120px" Height="60px" />
                        </div>

        <br />

         <br /><br />
        <div class="container">
            <div class="row" align="right">

        <div class="col" align="right">
                   <img src="#" alt="" width="180"/>
                </div>
                </div></div>

       

    </form>
</body>
</html>


