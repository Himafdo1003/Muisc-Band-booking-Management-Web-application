<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffPaymentAllocation.aspx.cs" Inherits="MariansArtistMangerApp.StaffPaymentAllocation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Staff Management</title>


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
   
      
    text-align :center;  
    font-family:arial, helvetica, sans-serif;  
    padding: 5px 10px 10px 10px;  
    font-weight:bold;  
     border-color:dodgerblue; 


}

         .auto-style6 {
             border-radius: 10px;
             text-align: center;
             font-family: arial, helvetica, sans-serif;
             font-weight: bold;
             padding-left: 10px;
             padding-right: 10px;
             padding-top: 5px;
             padding-bottom: 10px;
         }

    </style>


    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
        <link href="Content/BackBtn.css" rel="stylesheet" />
         <a runat="server" id="BackBut" class="btn btn1" onserverclick="BackButton_Click">Back</a>

        <div class="container">                                  
                        <div class="row" align="center">
                            <div class="col" align="center">
                                <strong style="color:white;" ><asp:Label ID="OrderAmountLabel" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large" Text="Staff Details" Width="388px" CssClass="img-fluid" ForeColor="White"></asp:Label></strong>
                            </div>
                        </div>
                        <br /> <br />
                   </div>






          <div class="container">

                <div class="row" align="center">
                   
                    <div class="col" >

                           
                                <asp:Label ID="Label1" runat="server" Text="Department" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="170px"></asp:Label>
                               
                             
                               
                            <asp:DropDownList ID="DepartmentDropdown" CssClass="auto-style6" runat="server"  Width="300px" Font-Bold="True" Font-Size="Large" Height="54px">
                            </asp:DropDownList>
                           
                               
                       
                          
                       
                    </div>


                     <div class="col" >


                            <asp:Label ID="Label2" runat="server" Text="Staff Name" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="170px"></asp:Label>
                                
                                  <asp:TextBox ID="StaffNameTB"  CssClass="TB" runat="server" Font-Bold="True" Font-Size="Large" Height="54px" Width="300px" ></asp:TextBox>
                               

                     </div>


                   
            </div>
              <br />

                  <div class="row" align="center">
                  
                    <div class="col" >
                        
                        

                                <asp:Label ID="Label10" runat="server" Text="Address" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="170px"></asp:Label>
                              
                                  <asp:TextBox ID="AddressTB"  CssClass="TB" runat="server" Font-Bold="True" Font-Size="Large" Height="54px" Width="300px" ></asp:TextBox>
                            
                       
                    </div>
                      <div class="col">
                           

                         
                                <asp:Label ID="Label9" runat="server" Text="Phone" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="170px"></asp:Label>
                               
                               <asp:TextBox ID="PhoneTB"  CssClass="TB" runat="server" Font-Bold="True" Font-Size="Large" Height="54px" Width="300px" ></asp:TextBox>
                            
                           
                      </div>
                  

        </div>

                <br />
                 <div class="row" align="center">
                  
                    <div class="col" >
                         
                       

                                <asp:Label ID="Label3" runat="server" Text="Email" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="170px"></asp:Label>
                              
                               <asp:TextBox ID="EmailTB"  CssClass="TB" runat="server" Font-Bold="True" Font-Size="Large" Height="54px" Width="300px" ></asp:TextBox>
                            
                           
                    </div>

                      <div class="col" >
                           
                         
                                <asp:Label ID="Label8" runat="server" Text="DOB" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="170px"></asp:Label>
                              
                                <asp:TextBox ID="DOBTB"  CssClass="TB" runat="server" Font-Bold="True" Font-Size="Large" Height="54px" Width="300px"  TextMode="Date"></asp:TextBox>
                            
                           
                            
                    </div>

        </div>
            


        
          <br />
           <div class="row" align="right">
                  
                         <div class="col" >
                                <asp:Button class="third" ID="RegisterBtn" runat="server"  Height="60px" OnClick="RegisterBtn_Click" Text="Register" Width="220px" CssClass="button" Font-Bold="True" Font-Size="Medium"  />

                   </div>

                      <div class="col" >
                            <asp:Button class="third" ID="UpdateBTN" runat="server"  Height="60px"  Text="Update" Width="220px" CssClass="button" Font-Bold="True" Font-Size="Medium" OnClick="UpdateBTN_Click"  OnClientClick="return confirm('Are you sure you want to Update?');" />


                    </div>

                <div class="col" >
                            <asp:Button class="third" ID="DeleteBtn" runat="server"  Height="60px"  Text="Delete" Width="220px" CssClass="button" Font-Bold="True" Font-Size="Medium"  OnClientClick="return confirm('Are you sure you want to Delete?');" OnClick="DeleteBtn_Click" />


                    </div>
              

        </div>

                <div class="row" align="right">
                      <div class="col" >
                            <asp:Button class="third" ID="AlloateBTN" runat="server"  Height="60px"  Text="Payment Plan" Width="220px" CssClass="button" Font-Bold="True" Font-Size="Medium" OnClick="AlloateBTN_Click"  />


                    </div>

                </div>

               <br />
               <div class="row" align="center">
                      <div class="col" >
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
