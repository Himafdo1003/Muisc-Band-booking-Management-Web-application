<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TentativeBookings.aspx.cs" Inherits="ArtistManagerApp.BookingPages.TentativeBookings"  EnableEventValidation="false" ValidateRequest="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Tentative Bookings</title>

     <script src="../Boostrap/js/popper.min.js"></script>
    <script src="../Boostrap/js/jquery-3.3.1.slim.min.js"></script>
    <script src="../Boostrap/js/bootstrap.js"></script>

    <link href="../Boostrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Buttons.css" rel="stylesheet" />
</head>
<body>

     <style type="text/css">
        body{
           /* background-image:url(../MariansImages/qq.jpg);*/
           background: rgb(19,18,71);
background: linear-gradient(90deg, rgba(19,18,71,1) 39%, rgba(17,29,72,1) 51%, rgba(18,30,102,1) 100%);
            background-repeat:no-repeat;
            background-size:cover;
            background-position:center center;
            background-attachment:fixed;
            height:100%;
        }
         .auto-style3 {
            height: 5px;
        }
         .GVFixedHeader
        {
            font-weight: bold;
            background-color: Green;
            position: relative;
            top: expression(this.parentNode.parentNode.parentNode.scrollTop-1);
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
   
      
    text-align :center;  
    font-family:arial, helvetica, sans-serif;  
    padding: 5px 10px 10px 10px;  
    font-weight:bold;  

     border-color:dodgerblue; 

}

    </style>
    <form id="form1" runat="server">

        <link href="../Content/BackBtn.css" rel="stylesheet" />
         <a runat="server" id="BackBut" class="btn btn1" onserverclick="BackButton_Click">Back</a>

        <div class="container">
               
    
                        <div class="row" align="center">
                            <div class="col" align="center">
                                <strong style="color:white;" ><asp:Label ID="OrderAmountLabel" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large" Text="Tentative Bookings"  CssClass="img-fluid" ForeColor="white"></asp:Label></strong>
                            </div>
                        </div>
                        <br /> <br />

              <div class="row" align="center">
                            <div class="col" align="center">
                         
      
                             <asp:TextBox ID="DateTB" TextMode="Date" CssClass="TB" runat="server" Font-Bold="True" Font-Size="Large" Height="54px" Width="200px"   ></asp:TextBox>
                               &nbsp;&nbsp;
                                <asp:Button class="third" ID="SearchBtn" runat="server"   CssClass="button" Font-Bold="True" Font-Size="Large" Height="60px"  Text="Search" Width="160px" OnClick="SearchBtn_Click" />
                         &nbsp;&nbsp;

                                   <asp:Button class="third" ID="ViewAll" runat="server"   CssClass="button" Font-Bold="True" Font-Size="Large" Height="60px"  Text="View All" Width="160px" OnClick="ViewAll_Click" />
                         
                            </div>
                        </div>
                   </div>
                
    

        

        <br />
     <div class="table-responsive" align="center">

            <div style="width: 95%; height: 100%; overflow: auto;" >

                  <asp:ScriptManager ID="ScriptManager2" runat="server">
       </asp:ScriptManager>
      <%-- <asp:UpdatePanel ID="UpdatePanel1" height="200px" runat="server">
    <ContentTemplate>--%>
    
         <asp:GridView ID="GridView1" runat="server" 
                  AutoGenerateSelectButton="True" CellPadding="1"  RowStyle-Wrap="true"  ForeColor="#333333" GridLines="None"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Font-Size="Small" width="100%" HorizontalAlign="Center" ShowFooter="True"  HeaderStyle-CssClass="GVFixedHeader" OnRowDataBound="GridView1_RowDataBound">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"  />
                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Height="60px" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                              
                                            </asp:GridView>
      <%-- </ContentTemplate>
         </asp:UpdatePanel>--%>
            
            
           </div>
            
        </div>

 <br /><br />

        <div class="container">
            <div class="row">
                <br /><br />
            </div>
        </div>

         <asp:Panel ID="Panel1" runat="server" Visible="false">
              <div class="container" >
            
            
            <div class="row"  >
                
                
                <div class="col-md-6">
                   <%--  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>--%>
        
                 <asp:Label ID="Label7" runat="server" Text="Event Date" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="180px" ></asp:Label>                    
               <asp:TextBox ID="EventDateTB"  runat="server" CssClass="TB" Font-Bold="True" Font-Size="Medium" Height="50px" Width="220px" ReadOnly="True"  TextMode="Date"  AutoPostBack="true" ></asp:TextBox>
               
               <br />  
               
                 <asp:Label ID="Label1" runat="server" Text="Event Time" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="180px"  ></asp:Label>                    
            
                 <asp:DropDownList ID="EventTimeDropdown" runat="server" Font-Bold="True" CssClass="TB" Font-Size="Medium" Height="50px" Width="220px" ReadOnly="True"   Enabled="False">
                     <asp:ListItem >Morning</asp:ListItem>
                     <asp:ListItem >Evening</asp:ListItem>

                 </asp:DropDownList>
               <br />

                   <asp:Label ID="Label2" runat="server" Text="Event Type" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="180px"  ></asp:Label>                    
            
        <asp:DropDownList ID="EventTypeDropdown" runat="server" Font-Bold="True" CssClass="TB" Font-Size="Medium" Height="50px" Width="220px" ReadOnly="True"   Enabled="False">
                     <asp:ListItem >Wedding </asp:ListItem>
                     <asp:ListItem >Home Coming</asp:ListItem>
            <asp:ListItem >Engagement</asp:ListItem>
            <asp:ListItem >Corporate Events</asp:ListItem>
            <asp:ListItem >Dinner Dance</asp:ListItem>
            <asp:ListItem >Birthday Party</asp:ListItem>
            <asp:ListItem >Wedding Annivesary Party </asp:ListItem>
            <asp:ListItem >Concerts-70s</asp:ListItem>
            <asp:ListItem >Concerts-Thaala</asp:ListItem>
             <asp:ListItem >Concerts-MS</asp:ListItem>
            <asp:ListItem >Practice</asp:ListItem>
            <asp:ListItem >Other</asp:ListItem>
            <asp:ListItem >Concert-General</asp:ListItem>

                 </asp:DropDownList>
               <br />



        
                   <asp:Label ID="Label20" runat="server" Text="Contact Name" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="180px"  ></asp:Label>                    
               <asp:TextBox ID="ContactNameTB"  CssClass="TB" runat="server" Font-Bold="True" Font-Size="Medium" Height="50px" Width="220px" ReadOnly="True"    ></asp:TextBox>
               <br />

                  

                   

         <asp:Label ID="Label6" runat="server" Text="Customer Name" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="180px"  ></asp:Label>                    
               <asp:TextBox ID="CustomerNameTB"  CssClass="TB" runat="server" Font-Bold="True" Font-Size="Medium" Height="50px" Width="220px" ReadOnly="True"    ></asp:TextBox>
               <br />
                   <asp:Label ID="Label5" runat="server" Text="Contact Phone" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="180px"  ></asp:Label>                    
               <asp:TextBox ID="ContactPhoneTB" CssClass="TB"  runat="server" Font-Bold="True" Font-Size="Medium" Height="50px" Width="220px" ReadOnly="True"    ></asp:TextBox>
               <br />
         <asp:Label ID="Label21" runat="server" Text="Contact Address" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="180px"  ></asp:Label>                    
               <asp:TextBox ID="AddressTB" CssClass="TB"  runat="server" Font-Bold="True" Font-Size="Medium" Height="50px" Width="220px" ReadOnly="True"    ></asp:TextBox>
               <br />

                    <asp:Label ID="Label4" runat="server" Text="Status" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="180px"  ></asp:Label>                    
               <asp:TextBox ID="StatusTB"  CssClass="TB" runat="server" Font-Bold="True" Font-Size="Medium" Height="50px" Width="220px" ReadOnly="True"    ></asp:TextBox>
               <br />

                   <asp:Label ID="Label8" runat="server" Text="Venue" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="180px"  ></asp:Label>                    
               <asp:TextBox ID="VenueTB"  CssClass="TB" runat="server" Font-Bold="True" Font-Size="Medium" Height="50px" Width="220px" ReadOnly="True"    ></asp:TextBox>
               <br />
         <asp:Label ID="Label3" runat="server" Text="Special Note" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="180px"  ></asp:Label>                    
               <asp:TextBox ID="SpecialNoteTB" CssClass="TB"  runat="server" Font-Bold="True" Font-Size="Medium" Height="50px" Width="220px" ReadOnly="True"    ></asp:TextBox>
               <br />

                   <asp:Label ID="Label9" runat="server" Text="Couple Name" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="180px"  ></asp:Label>                    
               <asp:TextBox ID="CoupleNameTB"  CssClass="TB" runat="server" Font-Bold="True" Font-Size="Medium" Height="50px" Width="220px" ReadOnly="True"    ></asp:TextBox>
               <br />
                      <asp:Label ID="Label10" runat="server" Text="Couple Name" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="180px"  ></asp:Label>                    
               <asp:TextBox ID="EventIDTB"  CssClass="TB" runat="server" Font-Bold="True" Font-Size="Medium" Height="50px" Width="220px" ReadOnly="True"    ></asp:TextBox>
               <br />

                    <%-- </ContentTemplate></asp:UpdatePanel>--%>

                     <br /><br />
                   </div>
                
                         
            
               
          
                   
                <div class="col-md-4">
                    <%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>--%>
                    <asp:Button ID="EditBtn" runat="server" Text="Edit" Font-Bold="True"  CssClass="button" Font-Size="Medium" Width="180px" Height="80px" OnClick="EditBtn_Click" OnClientClick="return confirm('Are you sure you want to Edit?');"   />
                    <br /><br />
               <asp:Button ID="UpdateBtn" runat="server" Text="Update" Font-Bold="True"  CssClass="button" Font-Size="Medium" Width="180px" Height="80px" OnClick="UpdateBtn_Click"   />
                   <br /><br />
                   
        

                    <asp:Button ID="Confirm_Btn" runat="server" Text="Confirm Bookings" Font-Bold="True" CssClass="button" Font-Size="Medium" Width="180px" Height="80px" OnClick="Confirm_Btn_Click"   />
     <br /><br />
         <asp:Button ID="CancelBtn" runat="server" Text="Cancel Booking" Font-Bold="True" CssClass="button" Font-Size="Medium" Width="180px" Height="80px" OnClick="CancelBtn_Click" OnClientClick="return confirm('Do you wish to Cancel this Booking?');"   />
                    <br /><br />
                   
    
    
    <%--</ContentTemplate></asp:UpdatePanel>--%>
                    </div>
                    </div>
        </div>

         </asp:Panel>
        

           

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

