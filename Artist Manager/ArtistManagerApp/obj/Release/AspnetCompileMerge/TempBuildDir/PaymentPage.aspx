<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentPage.aspx.cs" Inherits="MariansArtistMangerApp.PaymentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script src="Boostrap/js/jquery-3.3.1.slim.min.js"></script>
        <script src="Boostrap/js/bootstrap.js"></script>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.14.0/css/all.min.css" integrity="sha512-1PKOgIY59xJ8Co8+NE6FZ+LOAZKjy+KY8iq0G4B3CyeY6wYHN3yt9PW0XpSriVlkMXe40PTKnXrLnZ9+fkDaog==" crossorigin="anonymous" />
   
      <link href="Content/BackBtn.css" rel="stylesheet" />
    <link href="Content/staffmenu.css" rel="stylesheet" />
    <title>Payments</title>
     
  
</head>
<body>


    <style type="text/css">
        body{
          /*  background-image:url(MariansImages/stage.jpg);*/
          background: rgb(19,18,71);
background: linear-gradient(90deg, rgba(19,18,71,1) 39%, rgba(17,29,72,1) 51%, rgba(18,30,102,1) 100%);
            background-repeat:no-repeat;
            background-size:cover;
            background-position:center center;
            background-attachment:fixed;
            height:100%;
        }
         .auto-style3 {
             height: 34px;
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
                               <%-- <strong style="color:white;" ><asp:Label ID="OrderAmountLabel" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large" Text="Payment Page" Width="320px" CssClass="img-fluid" ForeColor="white"></asp:Label></strong>
                          --%>  </div>
                        </div>
                        <br /> <br />
                   </div>


      
        

 


         
        <div class="jumbotron text-center">
            <div class="container">

               

              <h1>Payment Select</h1>
              
          
            </div>
          </div>
          <div class="container"> 
            <div class="row">
             
            </div>
            
            <div class="row">
             <div class="col-sm-6" align="right">
                  
                  


                   <a runat="server" id="A1" class="btn btn-sm animated-button victoria-one" onserverclick="With_Click">Confirm With Advance</a>
                    
          
               </div>
              <div class="col-sm-6">
                
                
                 
  <a runat="server" id="A2" class="btn btn-sm animated-button victoria-one" onserverclick="Without_Click" OnClientClick="return confirm('Are you sure to proceed without Payment?');">Confirm Without Advance</a>

                 
              </div>
             

          
              
            </div>
              </div>


            


    
        
        <br />
           <div class="container" >
            
            <div class="row"  >
                
                
                <div class="col-md-6">
                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
                 <asp:Label ID="Label7" runat="server" Text="Payment Type" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="250px" Visible="False"></asp:Label>                    
             
                    
                    <asp:DropDownList ID="PaymentTypeDropdown" CssClass="TB" runat="server" autopostback="true" Font-Bold="True" Font-Size="Large" Height="54px" Width="220px"  OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Visible="False" OnTextChanged="PaymentTypeDropdown_TextChanged" BackColor="White" ForeColor="Black">
            
                          
                        <asp:ListItem>Cash</asp:ListItem>  
                        <asp:ListItem>Bank</asp:ListItem>  
                         <asp:ListItem>Cheque</asp:ListItem>  
                       
                    </asp:DropDownList>
                 
                
                   
                               
            
                                     
                               
               
               <br />  <br />  
               
                 <asp:Label ID="Label10" runat="server" Text="Advanced Date" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="250px" Visible="False"></asp:Label>                    
                 <asp:TextBox ID="AdvancedDateTB" CssClass="TB"  runat="server" Font-Bold="True" Font-Size="Medium" Height="50px" Width="220px" Visible="False" BackColor="White" ForeColor="Black"  TextMode="Date"  ></asp:TextBox>
               
               <br /><br />  

         <asp:Label ID="Label1" runat="server" Text="Amount" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="250px" Visible="False"></asp:Label>                    
               <asp:TextBox ID="AmountTB" CssClass="TB" runat="server" Font-Bold="True" Font-Size="Medium" Height="50px" Width="220px" Visible="False" OnDisposed="AmountTB_Disposed" OnInit="AmountTB_Init" OnLoad="AmountTB_Load" OnPreRender="AmountTB_PreRender" OnTextChanged="AmountTB_TextChanged" OnUnload="AmountTB_Unload" TextMode="Number" ValidateRequestMode="Enabled" BackColor="White" ForeColor="Black"  onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" ></asp:TextBox>
               <br /><br />  

                   <asp:Label ID="Label2" runat="server" Text="Payment Description" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="250px" Visible="False"></asp:Label>                    
               <asp:TextBox ID="Description" CssClass="TB"  runat="server" Font-Bold="True" Font-Size="Medium" Height="50px" Width="220px" Visible="False" TextMode="MultiLine" BackColor="White" ForeColor="Black"  ></asp:TextBox>
               <br /><br />  

                   <asp:Label ID="Label3" runat="server" Text="Bank Name" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="250px" Visible="False" style="margin-bottom: 0px"></asp:Label>                    
               <asp:TextBox ID="BankNameTB" CssClass="TB"  runat="server" Font-Bold="True" Font-Size="Medium" Height="50px" Width="220px" Visible="False" BackColor="White" ForeColor="Black"  ></asp:TextBox>
               <br /><br />  

           <asp:Label ID="AccountNameLBL" runat="server" Text="Account Name" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="250px" Visible="False" style="margin-bottom: 0px"></asp:Label>                    
                            <asp:DropDownList ID="AccountNameTB"  CssClass="TB" runat="server" Font-Bold="True" Font-Size="Large" Height="54px" BackColor="White" ForeColor="Black" OnSelectedIndexChanged="EventType_SelectedIndexChanged" Width="200px" Visible="False">
                                                             
                                <asp:ListItem>Marians</asp:ListItem>  
                                <asp:ListItem>MCSM</asp:ListItem>  

                                                                </asp:DropDownList>

                             <br /><br />  


                   <asp:Label ID="Label4" runat="server" Text="Cheque Number" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="250px" Visible="False"></asp:Label>                    
               <asp:TextBox ID="ChequeNoTB" CssClass="TB"  runat="server" Font-Bold="True" Font-Size="Medium" Height="50px" Width="220px" Visible="False" BackColor="White" ForeColor="Black"  ></asp:TextBox>
               <br /><br />  

         <asp:Label ID="Label6" runat="server" Text="Cheque Date" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="250px" Visible="False"></asp:Label>                    
               <asp:TextBox ID="ChequeDateTB"  CssClass="TB" runat="server" Font-Bold="True" Font-Size="Medium" Height="50px" Width="220px" Visible="False" TextMode="Date" BackColor="White" ForeColor="Black"  ></asp:TextBox>
               <br /><br />  
                   <asp:Label ID="Label5" runat="server" Text="Realise Date" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="250px" Visible="False"></asp:Label>                    
               <asp:TextBox ID="RealiseDateTB"  CssClass="TB" runat="server" Font-Bold="True" Font-Size="Medium" Height="50px" Width="220px" Visible="False" TextMode="Date" BackColor="White" ForeColor="Black"  ></asp:TextBox>
               <br /><br />  

                  

                   <asp:Label ID="Label8" runat="server" Text="Realise Amount" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="250px" Visible="False"></asp:Label>                    
               <asp:TextBox ID="RealiseAmountTB"  CssClass="TB" runat="server" Font-Bold="True" Font-Size="Medium" Height="50px" Width="220px" Visible="False" TextMode="Number" BackColor="White" ForeColor="Black"  ></asp:TextBox>
               <br /><br />  

                   <asp:Label ID="Label9" runat="server" Text="Status" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="250px" Visible="False"></asp:Label>                    
               <asp:TextBox ID="StatusTB"  CssClass="TB" runat="server" Font-Bold="True" Font-Size="Medium" Height="50px" Width="220px" Visible="False" BackColor="White" ForeColor="Black"  ></asp:TextBox>
               <br />
               <br />

                     </ContentTemplate></asp:UpdatePanel>

                    <br /><br />
                   </div>
                
                         
            
               
          
                   
                <div class="col-md-4">
                     <asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>
                   <br /><br />
                   
        

                    <asp:Button ID="Confirm_Btn" runat="server" Text="Pay Advance"  CssClass="button" Font-Size="Large" Width="230px" Height="80px" OnClick="Confirm_Btn_Click" Visible="False" Font-Bold="True" />
    <br /><br /><br />
                   
    
    
    </ContentTemplate></asp:UpdatePanel>
                    </div>
                    </div>
        </div>



          <div class="container">
            <div class="row" align="center">
                
                </div>        
        </div>

        <br /><br />



        <div class="container-fluid">
            <div class="row">

                <div class="col" align="right">
                   <img src="MariansImages/Marians3.png" alt="" width="180"/>
                </div>
            </div></div>



       
    </form>
</body>
</html>
