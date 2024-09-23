<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentConfirm.aspx.cs" Inherits="MariansArtistMangerApp.PaymentConfirm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Staff Payments</title>
      
    <script src="Boostrap/js/popper.min.js"></script>
    <script src="Boostrap/js/jquery-3.3.1.slim.min.js"></script>
    <script src="Boostrap/js/bootstrap.js"></script>

    <link href="Boostrap/css/bootstrap.min.css" rel="stylesheet" />

    <link href="Buttons.css" rel="stylesheet" />
    
    </head>
<body>
     <style type="text/css">
        body{
            /*background-image:url(MariansImages/13.jpg);*/
            background: rgb(19,18,71);
background: linear-gradient(90deg, rgba(19,18,71,1) 39%, rgba(17,29,72,1) 51%, rgba(18,30,102,1) 100%);
            background-repeat:no-repeat;
            background-size:cover;
            background-position:center center;
            background-attachment:fixed;
            height:100%;
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
                                <strong style="color:white;" ><asp:Label ID="OrderAmountLabel" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large" Text="Payment Confirm" Width="320px" CssClass="img-fluid" ForeColor="white"></asp:Label></strong>
                            </div>
                        </div>
                        <br /> <br />
                   </div>

      
       
         <div class="container">

                <div class="row"align="center">
                    
                    <div class="col" align="center" >

                        <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Event Type" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="150px"></asp:Label>
                            <asp:DropDownList ID="EventTypeDropdown"  CssClass="TB" runat="server" Font-Bold="True" Font-Size="Large" Height="54px" OnSelectedIndexChanged="EventType_SelectedIndexChanged" Width="200px">
                                                                   
                                                                </asp:DropDownList>
                        <br /><br />
                          <asp:Label ID="Label2" runat="server" Text="Department Type" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="150px"></asp:Label>
                         <asp:DropDownList ID="DepartmentDropdown"  CssClass="TB" runat="server" Font-Bold="True" Font-Size="Large" autopostback="true" Height="54px" OnSelectedIndexChanged="DepartmentDropdown_SelectedIndexChanged" Width="200px">
                                                                   
                                                                </asp:DropDownList>
                        
                        <br /><br />
                              <asp:Label ID="Label3" runat="server" Text="Staff Members" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="150px"></asp:Label>
                         <asp:DropDownList ID="PlayerDropdown"  CssClass="TB" runat="server" autopostback="true" Font-Bold="True" Font-Size="Large" Height="54px" OnSelectedIndexChanged="Player_SelectedIndexChanged" Width="200px">
                                                                   
                                                                </asp:DropDownList>
                        
                        <br /><br />
                            <asp:Panel ID="KMPanel" runat="server" Visible="false">
                                 <asp:Label ID="Label10" runat="server" Text="No. of kilometers" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="150px"></asp:Label>
                              <asp:TextBox ID="KMTB"  CssClass="TB"  runat="server" Font-Bold="True" Font-Size="Large" Height="54px" Width="200px"   TextMode="Number"  onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" OnTextChanged="KMTB_TextChanged"  AutoPostBack="true"></asp:TextBox>
                            <br /><br />

                            </asp:Panel>

                              <asp:Label ID="Label4" runat="server" Text="Amount LKR" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="150px"></asp:Label>
                              <asp:TextBox ID="PaymentShowTB"  CssClass="TB"  runat="server" Font-Bold="True" Font-Size="Large" Height="54px" Width="200px" ReadOnly="True" OnTextChanged="TextBoxshow_TextChanged" TextMode="Number"  onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" ></asp:TextBox>
                            <br /><br />
                              <asp:Button class="third" ID="B_PayAmend" runat="server"   CssClass="button" Font-Bold="True" Font-Size="Large" Height="54px" OnClick="Amend_Click" Text="Amend Amount" Width="160px" OnClientClick="return confirm('Would you want to Amend?');" ></asp:Button>
                      
                            <br /><br />

                                   <asp:Label ID="Label7" runat="server" Text="Payment Type" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="150px"></asp:Label>                    
             
                    
                    <asp:DropDownList ID="PaymentTypeDropdown"  CssClass="TB" runat="server" autopostback="true" Font-Bold="True" Font-Size="Large" Height="54px" Width="200px" OnSelectedIndexChanged="PaymentType_SelectedIndexChanged" Visible="true" OnTextChanged="PaymentTypeDropdown_TextChanged">
            
                        <asp:ListItem>Cash</asp:ListItem>
                        <asp:ListItem>Bank</asp:ListItem>
                        <asp:ListItem>Card</asp:ListItem>
                       
                        <asp:ListItem>Cheque</asp:ListItem>               
                        <asp:ListItem>Credit</asp:ListItem> 
                         <asp:ListItem>FOC</asp:ListItem> 
                           
                       
                    </asp:DropDownList>
                            <br /><br />

                             <asp:Label ID="PayDateLBL" runat="server" Text=" Payment Date" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="150px" style="margin-bottom: 0px"></asp:Label>                    
               <asp:TextBox ID="PayDateTB"  CssClass="TB"  runat="server" Font-Bold="True" Font-Size="Medium" Height="54px" Width="200px" TextMode="Date" ></asp:TextBox>


                             <br /><br />

                             <asp:Label ID="ReasonLBL" runat="server" Text="Reason" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="150px" Visible="False" style="margin-bottom: 0px"></asp:Label>                    
               <asp:TextBox ID="ReasonTB"  CssClass="TB"  runat="server" Font-Bold="True" Font-Size="Medium" Height="54px" Width="200px" Visible="False" TextMode="MultiLine"  ></asp:TextBox>


                             <br /><br />


                             

                             <asp:Label ID="Label5" runat="server" Text="Bank Name" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="150px" Visible="False" style="margin-bottom: 0px"></asp:Label>                    
               <asp:TextBox ID="BankNameTB"  CssClass="TB"  runat="server" Font-Bold="True" Font-Size="Medium" Height="54px" Width="200px" Visible="False"  ></asp:TextBox>


                             <br /><br />
                            <asp:Label ID="Label9" runat="server" Text="Any Note" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="150px" Visible="False" style="margin-bottom: 0px"></asp:Label>                    
               <asp:TextBox ID="AnyNoteTB"  CssClass="TB"  runat="server" Font-Bold="True" Font-Size="Medium" Height="54px" Width="200px" Visible="False" TextMode="MultiLine"  ></asp:TextBox>


                             <br /><br />

                               <asp:Label ID="Label6" runat="server" Text="Cheque No" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="150px" Visible="False" style="margin-bottom: 0px"></asp:Label>                    
               <asp:TextBox ID="ChequeNoTB"  CssClass="TB"  runat="server" Font-Bold="True" Font-Size="Medium" Height="54px" Width="200px" Visible="False"  ></asp:TextBox>


                             <br /><br />
                               <asp:Label ID="Label8" runat="server" Text="Cheque Date" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="150px" Visible="False" style="margin-bottom: 0px"></asp:Label>                    
               <asp:TextBox ID="ChequeDateTB"  CssClass="TB"  runat="server" Font-Bold="True" Font-Size="Medium" Height="54px" Width="200px" Visible="False" TextMode="Date"  ></asp:TextBox>


                             <br /><br />
                             <asp:Button class="third" ID="BandPay_btn" runat="server"  CssClass="button" Font-Bold="True" Font-Size="Large" Height="60px" OnClick="BandPay_Click" Text="Pay" Width="140px" />
                            </ContentTemplate></asp:UpdatePanel> 
                      
                     
                           
                         <br /><br />

                          
                   
                                    </div>
   
                    </div>
                    <div class="auto-style4">

                                                 <br /><br /> <br /><br />

                    </div>
                   
            </div>


          

         <div class="container">
                 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate> 

    <div class="row" align="center">
      <div class="col-md-12" align="center">
        <div class="table-responsive">
           

             <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" CellPadding="4"  ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Font-Size="medium" width="100%" HorizontalAlign="Center"   >
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
          
            
        </div>
      </div>
    </div>
                    <asp:TextBox ID="paymentIDTB" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
                      <div class="col" align="center" >
                      <br /><br />
                             <asp:Button class="third" ID="DeleteBtn" runat="server"  CssClass="button" Font-Bold="True" Font-Size="Large" Height="60px" OnClick="Delete_Click" Text="Delete" Width="140px" Visible="False" />
                          </div>
            </ContentTemplate>
           </asp:UpdatePanel>
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


