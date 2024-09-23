<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmBook.aspx.cs" Inherits="ArtistManagerApp.ConfirmBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Tentative Booking</title>


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
                                <strong style="color:white;" ><asp:Label ID="OrderAmountLabel" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large" Text="Tentative Booking" Width="388px" CssClass="img-fluid" ForeColor="White"></asp:Label></strong>
                            </div>
                        </div>
                        <br /> <br />
                   </div>






          <div class="container">

                <div class="row" align="center">
                   
                    <div class="col" >

                            <ContentTemplate>


                                <asp:Label ID="Label1" runat="server" Text="Event Type" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="170px"></asp:Label>
                               
                             
                               
                            <asp:DropDownList ID="EventTypeDropDown" CssClass="auto-style6" runat="server" autopostback="true"  OnSelectedIndexChanged="EventTypeDropDown_SelectedIndexChanged" Width="300px" Font-Bold="True" Font-Size="Large" Height="54px">
                            </asp:DropDownList>
                           
                               
                       
                            </ContentTemplate> 
                       
                    </div>


                     <div class="col" >


                            <asp:Label ID="Label2" runat="server" Text="Event Time" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="170px"></asp:Label>
                                
                                 <asp:DropDownList ID="DropDownList2" CssClass="TB" runat="server" Font-Bold="True" Font-Size="Large" Height="54px" Width="300px"  OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Enabled="False">
                                    
                               <asp:ListItem>Morning</asp:ListItem>  
                                <asp:ListItem>Evening</asp:ListItem>  
            
                                     
                                 </asp:DropDownList>

                     </div>


                   
            </div>
              <br />

                  <div class="row" align="center">
                  
                    <div class="col" >
                        
                          <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>


                                <asp:Label ID="Label10" runat="server" Text="Contract Rate(LKR)" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="170px"></asp:Label>
                              
                                <asp:TextBox ID="ActualRateTB"  CssClass="TB" runat="server" Font-Bold="True" Font-Size="Large" Height="54px" Width="300px" AutoPostBack="true" OnTextChanged="Rate_TextChanged" TextMode="Number" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" ></asp:TextBox>
                               
                            </ContentTemplate></asp:UpdatePanel>
                       
                    </div>
                      <div class="col">
                           <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>

                         
                                <asp:Label ID="Label9" runat="server" Text="Discount Amount" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="170px"></asp:Label>
                               
                                <asp:TextBox ID="DiscountTB" CssClass="TB" runat="server"  Font-Bold="True" Font-Size="Large" Height="54px" Width="300px"  AutoPostBack="true" TextMode="Number" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" OnTextChanged="DiscountTB_TextChanged" ></asp:TextBox>
                               
                            </ContentTemplate>
                            </asp:UpdatePanel>
                      </div>
                  

        </div>

                <br />
                 <div class="row" align="center">
                  
                    <div class="col" >
                         
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>


                                <asp:Label ID="Label3" runat="server" Text="Net Rate(LKR)" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="170px"></asp:Label>
                              
                                <asp:TextBox ID="Rate"  CssClass="TB" runat="server" Font-Bold="True" Font-Size="Large" Height="54px" Width="300px" AutoPostBack="true" OnTextChanged="Rate_TextChanged" TextMode="Number" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" ></asp:TextBox>
                               
                            </ContentTemplate></asp:UpdatePanel>
                    </div>

                      <div class="col" >
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>

                         
                                <asp:Label ID="Label8" runat="server" Text="Customer Name" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="170px"></asp:Label>
                              
                                <asp:TextBox ID="CustomerNameTB" CssClass="TB" runat="server"  Font-Bold="True" Font-Size="Large" Height="54px" Width="300px"  ></asp:TextBox>
                               
                            </ContentTemplate>
                            </asp:UpdatePanel>
                            
                    </div>

        </div>
            



           <br />
           <div class="row" align="center">
                  
                    <div class="col" >

                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>

                         
                                <asp:Label ID="cplNameLabel" runat="server" Text="Couple Name" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="170px"></asp:Label>
                             
                                <asp:TextBox ID="Couple_Name" CssClass="TB" runat="server" Font-Bold="True" Font-Size="Large" Height="54px" Width="300px"  ></asp:TextBox>
                               
                            </ContentTemplate>
                            </asp:UpdatePanel>
                    </div>

                      <div class="col" >
                            <ContentTemplate>


                                <asp:Label ID="Label5" runat="server" Text="Contact Name" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="170px"></asp:Label>
                               
                                <asp:TextBox ID="ContactNameTB" CssClass="TB"  runat="server" Font-Bold="True" Font-Size="Large" Height="54px" Width="300px"  ></asp:TextBox>
                               
                            </ContentTemplate>
                        
                    </div>

        </div>



          <br />
           <div class="row" align="center">
                  
                    <div class="col" >
                         <ContentTemplate>


                                <asp:Label ID="venueLabel" runat="server" Text="Contact Phone" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="170px"></asp:Label>
                              
                                <asp:TextBox ID="Contact" CssClass="TB"  runat="server" Font-Bold="True" Font-Size="Large" Height="54px" Width="300px"  ></asp:TextBox>
                               
                            </ContentTemplate>

                    </div>

                      <div class="col" >
                          
                            <ContentTemplate>


                                <asp:Label ID="Label6" runat="server" Text="Contact Address" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="170px"></asp:Label>
                              
                                <asp:TextBox ID="ContactAdressTB"  CssClass="TB" runat="server" Font-Bold="True" Font-Size="Large" Height="54px" Width="300px"  ></asp:TextBox>
                               
                            </ContentTemplate>

                    </div>

        </div>




          <br />
           <div class="row" align="center">
                  
                    <div class="col" >
                           <ContentTemplate>


                                <asp:Label ID="Label7" runat="server" Text="Venue" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="170px"></asp:Label>
                               
                                <asp:TextBox ID="VenueTB" CssClass="TB"  runat="server" Font-Bold="True" Font-Size="Large" Height="54px" Width="300px"  ></asp:TextBox>
                               
                            </ContentTemplate> 

                    </div>

                      <div class="col" >
                             <ContentTemplate>


                                <asp:Label ID="Label4" runat="server" Text="Special Notes" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="35px" Width="170px"></asp:Label>
                               
                                <asp:TextBox ID="SpecialNoteTB" CssClass="TB" runat="server" Font-Bold="True" Font-Size="Large" Height="64px" Width="300px" TextMode="MultiLine"  ></asp:TextBox>
                               
                            </ContentTemplate>
                          
                    </div>

        </div>

        
        

        
          <br />
           <div class="row" align="center">
                  
                         <div class="col" align="center">
                                <asp:Button class="third" ID="Confirmbtn" runat="server"  Height="60px" OnClick="ConfirmBtn_Click" Text="Add Tentative Booking" Width="290px" CssClass="button" Font-Bold="True" Font-Size="Large" autopostback="false"  />

                   </div>

                     <%-- <div class="col" >


                    </div>--%>

        </div>

  </div>


          <br /><br />

        
         <div class="container-fluid">
            <div class="row">

                <div class="col" align="right">
                   <img src="#" alt="" width="180"/>
                </div>
            </div></div>

  <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <!-- Include all compiled plugins (below), or include individual files as needed -->
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

        

    </form>
</body>
</html>