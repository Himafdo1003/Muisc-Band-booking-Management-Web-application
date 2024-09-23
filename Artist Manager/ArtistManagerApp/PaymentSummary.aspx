<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentSummary.aspx.cs" Inherits="ArtistManagerApp.PaymentSummary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Payment Summary</title>


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
 .td {
  text-align: center;
}
  .tr {
  text-align: center;
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
                <div class="row" align="center" >
                   
                    <div class="col" align="center" >
                           <asp:Button  ID="EventSummeryBTN" runat="server"  Height="60px"  Text="Event Payment Summary" Width="200px" CssClass="button" Font-Bold="True" Font-Size="Small" OnClick="EventSummeryBTN_Click"   /> 
                        </div>

                    <div class="col" align="center" >
                         <asp:Button  ID="ExpenseBtn" runat="server"  Height="60px"  Text="Expense Report" Width="200px" CssClass="button" Font-Bold="True" Font-Size="Small" OnClick="ExpenseBtn_Click"   /> 
                        </div>

                     <div class="col" align="center" >
                           <asp:Button  ID="IncomeReportBtn" runat="server"  Height="60px"  Text="Income Report" Width="200px" CssClass="button" Font-Bold="True" Font-Size="Small" OnClick="IncomeReportBtn_Click"    /> 
                         </div>

                    </div>
             <br /> <br /> <br /> <br />
             
             <asp:Panel ID="EventPaymentPAnel" runat="server" Visible="false">
              
        
                <div class="row" align="center">
                    <div class="col" align="center">
                     <asp:Label ID="Label3" runat="server" Text="Event Date" Font-Bold="True" Font-Size="Small" ForeColor="White" Height="35px" Width="100px"></asp:Label>
                      <asp:TextBox ID="DateTB" runat="server" CssClass="TB"  Width="180px" Font-Bold="True" Font-Size="Small" Height="35px" TextMode="Date"></asp:TextBox>
                   
                        

                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                          <asp:Label ID="Label2" runat="server" Text="Event Time" Font-Bold="True" Font-Size="Small" ForeColor="White" Height="35px" Width="100px"></asp:Label>
                                
                                 <asp:DropDownList ID="TimeDropdown" CssClass="TB" runat="server" Font-Bold="True" Font-Size="Small" Height="35px" Width="180px"  >
                                    
                               <asp:ListItem>Morning</asp:ListItem>  
                                <asp:ListItem>Evening</asp:ListItem>  
            
                                     
                                 </asp:DropDownList>
                     
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           
                          <asp:Button  ID="SearchBTN1" runat="server"  Height="40px" OnClick="SearchBTN1_Click" Text="Search" Width="150px" CssClass="button" Font-Bold="True" Font-Size="Small"   />                                      
                       
   </div>
                    </div>

               <%--  //////////////////////////////////////////--%>
                 <br /> <br />
                 <div class="row" align="center">
                      <div class="col" align="center">
                  <asp:Label ID="Label5" runat="server" Text="Search By City/ Customer Name/ Couple Name/ Contact Number/ Contact Name/ Venue" ForeColor="White" Font-Bold="True" Font-Size="Medium"></asp:Label>
                  <br />
                          </div>
                     </div>
                  <div class="row" align="center">
                      <div class="col" align="center">
                   
                            <asp:Label ID="Label1" runat="server" Text="Event Type" Font-Bold="True" Font-Size="Small" ForeColor="White" Height="35px" Width="100px" ></asp:Label>                             
                        
                            <asp:DropDownList ID="EventTypeDropDown"  runat="server"  CssClass="TB"   Width="180px" Font-Bold="True" Font-Size="Small" Height="35px">
                            </asp:DropDownList>

                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                          <asp:Label ID="Label4" runat="server" Text="Search" Font-Bold="True" Font-Size="Small" ForeColor="White" Height="35px" Width="100px"></asp:Label>
                                       
                      <asp:TextBox ID="SearchTB" runat="server" CssClass="TB"    Width="180px" Font-Bold="True" Font-Size="Small" Height="35px"></asp:TextBox>
                                
            
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           
                          <asp:Button  ID="SearchBtn2" runat="server"  Height="40px"  Text="Search" Width="150px" CssClass="button" Font-Bold="True" Font-Size="Small" OnClick="SearchBtn2_Click"   />                                      
                       
   </div>
                    </div>
                 <br />
           


                    <%--  //////////////////////////////////////////--%>
                 <br /> <br />


                 <asp:Panel ID="EventGridPanel" runat="server" Visible="false">
                
                   <asp:GridView ID="GridView1" runat="server" 
                  AutoGenerateSelectButton="True" CellPadding="1"  RowStyle-Wrap="true"  ForeColor="#333333" GridLines="None"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Font-Size="Small" width="100%" HorizontalAlign="Center" ShowFooter="True"  HeaderStyle-CssClass="GVFixedHeader" >
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
                       <br />  <br />
                   
          </asp:Panel>
               

                  <asp:Panel ID="EventSummaryPannel" runat="server" Visible="false" BackColor="white"  Height="100%" CssClass="table-responsive"  BorderColor="Black" BorderStyle="Solid" ScrollBars="Auto">

                               <font size="2"  face="Times New Roman" >
              <table style="width:100%" class="table-responsive"  >
                
       <%--    <tr>
               <td colspan="5" >
                

                <img src="https://i.imgur.com/W0ja9AN.jpg" width="570" />

</td>

                 
           </tr>--%>

                           <tr align="center">
               <td colspan="3"  >                 
                   <asp:Label ID="Label6" runat="server" Text="Payment Summary" Font-Bold="True" ForeColor="Black" ></asp:Label>                 
</td>
           </tr>

                  <tr align="left">
               <td> Date of Booking Conformation
                   </td>

                   <td>: <asp:Label ID="DateofBookingConfirmLBL" runat="server" Font-Bold="True"></asp:Label>
                   </td>
                   <td colspan="1"></td>
           </tr>

                  <tr align="left">
               <td>  Date of Event 
                   </td>

                   <td> : <asp:Label ID="DateOfEventLBL" runat="server" Font-Bold="True"></asp:Label>
                   </td>

                      <td colspan="1"></td>
           </tr>

                   <tr align="left">
               <td> Couple Name  
                   </td>

                   <td> : <asp:Label ID="cplnamelbl" runat="server" Font-Bold="True"></asp:Label>
                   </td>

                       <td colspan="1"></td>
           </tr>

                     <tr align="left">
               <td>  Venue    
                   </td>

                   <td>  : <asp:Label ID="VenueLBL" runat="server" Font-Bold="True"></asp:Label> 
                   </td>

                         <td colspan="1"></td>
           </tr>

                   <tr align="left">
               <td>   Time (From – To)   
                   </td>

                   <td>  : <asp:Label ID="TimeFromToLBL" runat="server" Font-Bold="True"></asp:Label> 

                   </td>

                       <td colspan="1"></td>
           </tr>


                    <tr align="left">
               <td>  Full Contract Price     
                   </td>

                   <td>   :<b> Rs.</b> <asp:Label ID="ActualRateLBL" runat="server" Font-Bold="True"></asp:Label>

                   </td>

                        <td colspan="1"></td>
           </tr>
                   <tr align="left">
               <td>  Discount Price    
                   </td>

                   <td>   :<b> Rs.</b> <asp:Label ID="DiscountPriceLBL" runat="server" Font-Bold="True"></asp:Label>

                   </td>

                        <td colspan="1"></td>
           </tr>

                   <tr align="left">
               <td>  Net Price    
                   </td>

                   <td>   :<b> Rs.</b> <asp:Label ID="FullContractPriceLBL" runat="server" Font-Bold="True"></asp:Label>

                   </td>

                        <td colspan="1"></td>
           </tr>

                   <tr align="left">
               <td>  Total Paid Amount    
                   </td>

                   <td>   :<b> Rs.</b> <asp:Label ID="FullPaidAmountLBL" runat="server" Font-Bold="True"></asp:Label>

                   </td>

                        <td colspan="1"></td>
           </tr>

                      <tr align="center">
               <td colspan="3"  >   </td></tr>

                   <tr align="center">
               <td colspan="3"  >  

                   <asp:Label ID="Label9" runat="server" Text="Expense List" Font-Bold="True" ForeColor="Black" ></asp:Label>  
                   <br />  <br />
                      <asp:GridView ID="GridView2" runat="server"   Width="100%"  BorderStyle="Solid"  AutoGenerateSelectButton="false" Font-Size="10px" >
                                 
                                  <AlternatingRowStyle BackColor="#B3E7FB" />
                                  <HeaderStyle BackColor="#B4D2E9" />
                                 
                              </asp:GridView>	

               </td></tr>

                   
           </tr>

                    <tr align="center">
               <td colspan="3"  >    </td></tr>


                    <tr align="right">
               <td colspan="3"  >   

                    <asp:Label ID="Label7" runat="server" Text="Total Expense : Rs. " Font-Bold="True" ForeColor="Black" ></asp:Label> &nbsp;&nbsp;
                   <asp:Label ID="TotalExpenseLBL" runat="server"  Font-Bold="True" ForeColor="Black" ></asp:Label>

               </td></tr>

                   <tr align="right">
               <td colspan="3"  >   

                    <asp:Label ID="Label8" runat="server" Text="Net Profit : Rs. " Font-Bold="True" ForeColor="Black" ></asp:Label> &nbsp;&nbsp;
                   <asp:Label ID="NetProfitLBL" runat="server"  Font-Bold="True" ForeColor="Black" ></asp:Label>

               </td></tr>

                  </table>
                                   </font>


                  </asp:Panel>

 <div class="row" align="center">
               <br /> 
                  <div class="col-md-12" align="center">
                 <asp:Button ID="Print" runat="server" Text="Download" OnClick="Print_Click" Height="60px" Width="130px" Font-Bold="True" CssClass="button" Font-Size="Large" Visible="false" />
                    </div>
            </div>

             </asp:Panel>

             <asp:Panel ID="ExpensePanel" runat="server" Visible="false">
              
        
                <div class="row" align="center">
                    <div class="col" align="center">
                     <asp:Label ID="Label10" runat="server" Text="From Date" Font-Bold="True" Font-Size="Small" ForeColor="White" Height="35px" Width="100px"></asp:Label>
                      <asp:TextBox ID="FromDateTB" runat="server" CssClass="TB"  Width="200px" Font-Bold="True" Font-Size="Small" Height="35px" TextMode="Date"></asp:TextBox>
                     </div>
                        

                    <div class="col" align="center">
                         <asp:Label ID="Label11" runat="server" Text="To Date" Font-Bold="True" Font-Size="Small" ForeColor="White" Height="35px" Width="100px"></asp:Label>
                      <asp:TextBox ID="ToDateTB" runat="server" CssClass="TB"  Width="200px" Font-Bold="True" Font-Size="Small" Height="35px" TextMode="Date"></asp:TextBox>
                   </div>
                     
                     <div class="col" align="center">
                         <asp:Label ID="Label13" runat="server" Text="Staff" Font-Bold="True" Font-Size="Small" ForeColor="White" Height="35px" Width="100px"></asp:Label>
                        <asp:DropDownList ID="StaffDropdown"  runat="server"  CssClass="TB"   Width="200px" Font-Bold="True" Font-Size="Small" Height="35px" >
                            </asp:DropDownList>
                          </div>
                       
                            <div class="col" align="center">
                                <br /> <br />
                          <asp:Button  ID="ExpeseByDateBTN" runat="server"  Height="45px"  Text="Search" Width="200px" CssClass="button" Font-Bold="True" Font-Size="Small" OnClick="ExpeseByDateBTN_Click"   />                                      
                        </div>
 
                    </div>

                  <div class="row" align="center">
                    <div class="col" align="center">

                         

                        </div>

                      </div>

               <%--  //////////////////////////////////////////--%>
                 <br /> <br />

             <asp:Panel ID="ExpenseReultPanel" runat="server" Visible="false" BackColor="white"  Height="100%" CssClass="table-responsive"  BorderColor="Black" BorderStyle="Solid" ScrollBars="Auto">

                               <font size="2"  face="Times New Roman" >
              <table style="width:100%" class="table-responsive"  >
                
       <%--    <tr>
               <td colspan="5" >
                

                <img src="https://i.imgur.com/W0ja9AN.jpg" width="570" />

</td>

                 
           </tr>--%>

                           <tr align="center">
               <td  >                 
                   <asp:Label ID="Label12" runat="server" Text="Expense Report" Font-Bold="True" ForeColor="Black" ></asp:Label>    
                    <br /><br />
                    <asp:Label ID="DateRangeLBL" runat="server" Font-Bold="True"></asp:Label>
                        <br /><br />
                         <asp:Label ID="Label21" runat="server" Text="Expense List" Font-Bold="True" ForeColor="Black" ></asp:Label>  

                   <br /><br />
                     <asp:GridView ID="GridView3" runat="server"   Width="100%"  BorderStyle="Solid"  AutoGenerateSelectButton="false" Font-Size="10px" CellPadding="2" HorizontalAlign="Center" >
                                 
                                  <AlternatingRowStyle BackColor="#B3E7FB" />
                                  <HeaderStyle BackColor="#B4D2E9" />
                                 
                              </asp:GridView>	
</td>
           </tr>

                


                 

                    <tr align="center">
               <td  >    </td></tr>


                    <tr align="right">
               <td  >   

                    <asp:Label ID="Label22" runat="server" Text="Total Expense : Rs." Font-Bold="True" ForeColor="Black" ></asp:Label> &nbsp;&nbsp;
                   <asp:Label ID="TotalExpenseFromReportLBL" runat="server"  Font-Bold="True" ForeColor="Black" ></asp:Label>

               </td></tr>

               

                  </table>
                                   </font>


                  </asp:Panel>

 <div class="row" align="center">
               <br /> 
                  <div class="col-md-12" align="center">
                 <asp:Button ID="DownloadBtn2" runat="server" Text="Download"  Height="60px" Width="130px" Font-Bold="True" CssClass="button" Font-Size="Large" Visible="false" OnClick="DownloadBtn2_Click" />
                    </div>
            </div>


                 </asp:Panel>

              <asp:Panel ID="IncomePanel" runat="server" Visible="false">
              
        
                <div class="row" align="center">
                    <div class="col" align="center">
                     <asp:Label ID="Label14" runat="server" Text="From Date" Font-Bold="True" Font-Size="Small" ForeColor="White" Height="35px" Width="100px"></asp:Label>
                          <br />
                      <asp:TextBox ID="IncomeFromDateTB" runat="server" CssClass="TB"  Width="200px" Font-Bold="True" Font-Size="Small" Height="35px" TextMode="Date"></asp:TextBox>
                     </div>
                        

                    <div class="col" align="center">
                         <asp:Label ID="Label15" runat="server" Text="To Date" Font-Bold="True" Font-Size="Small" ForeColor="White" Height="35px" Width="100px"></asp:Label>
                          <br />
                      <asp:TextBox ID="IncomeToDateTB" runat="server" CssClass="TB"  Width="200px" Font-Bold="True" Font-Size="Small" Height="35px" TextMode="Date"></asp:TextBox>
                   </div>
                     
                    
                       
                            <div class="col" align="center">
                               <br /> <br />
                          <asp:Button  ID="IncomeSearchBtn" runat="server"  Height="45px"  Text="Search" Width="200px" CssClass="button" Font-Bold="True" Font-Size="Small" OnClick="IncomeSearchBtn_Click"   />                                      
                        </div>
 
                    </div>

                  <div class="row" align="center">
                    <div class="col" align="center">

                         

                        </div>

                      </div>

               <%--  //////////////////////////////////////////--%>
                 <br /> <br />

             <asp:Panel ID="IncomeStatementPanel" runat="server" Visible="false" BackColor="white"  Height="100%"  Width="100%"  BorderColor="Black" BorderStyle="Solid" ScrollBars="Auto" >

                               <font size="2"  face="Times New Roman" >
              <table style="width:100%" class="table-responsive" align="center" >
                
       <%--    <tr>
               <td colspan="5" >
                

                <img src="https://i.imgur.com/W0ja9AN.jpg" width="570" />

</td>

                 
           </tr>--%>

                           <tr align="center">
               <td  align="center">                 
                   <asp:Label ID="Label17" runat="server" Text="Income and Expense Report" Font-Bold="True" ForeColor="Black" ></asp:Label>    
                    <br /><br />
                    <asp:Label ID="IncomeDateRangeLBL" runat="server" Font-Bold="True"></asp:Label>
                        <br /><br />
                         <asp:Label ID="Label19" runat="server" Text="Income List" Font-Bold="True" ForeColor="Black" ></asp:Label>  

                   <br /><br />
                     <asp:GridView ID="GridView4" runat="server"   Width="100%"  BorderStyle="Solid"  AutoGenerateSelectButton="false" Font-Size="10px" CellPadding="2" HorizontalAlign="Center" >
                                 
                                  <AlternatingRowStyle BackColor="#B3E7FB" />
                                  <HeaderStyle BackColor="#B4D2E9" />
                                 
                              </asp:GridView>	

                     <br />
                   </td>
           </tr>

                   <tr align="right">
               <td  align="right"> 
                    <asp:Label ID="Label18" runat="server" Text="Total Income : Rs." Font-Bold="True" ForeColor="Black" ></asp:Label> &nbsp;&nbsp;
                   <asp:Label ID="TotalIncomeLBL" runat="server"  Font-Bold="True" ForeColor="Black" ></asp:Label>
                    <br /><br />
                      </td></tr>
                  
                     <tr align="center">
               <td  align="center"> 
                         <asp:Label ID="Label16" runat="server" Text="Expense List" Font-Bold="True" ForeColor="Black" ></asp:Label>  
                      
                   <br /><br />
                     <asp:GridView ID="GridView5" runat="server"   Width="100%"  BorderStyle="Solid"  AutoGenerateSelectButton="false" Font-Size="10px" CellPadding="2" HorizontalAlign="Center" >
                                 
                                  <AlternatingRowStyle BackColor="#B3E7FB" />
                                  <HeaderStyle BackColor="#B4D2E9" />
                                 
                              </asp:GridView>	

                    <br />
                   </td></tr>
                 
                    <tr align="right">
               <td  align="right"> 
                    <asp:Label ID="Label24" runat="server" Text="Total Expense : Rs." Font-Bold="True" ForeColor="Black" ></asp:Label> &nbsp;&nbsp;
                   <asp:Label ID="TotalExpenseAmountLBL" runat="server"  Font-Bold="True" ForeColor="Black" ></asp:Label>
                     
                   <br /><br />
                   </td></tr>

                


                 

                    <tr align="center">
               <td  >    </td></tr>


                    <tr align="right">
               <td  >   

                    <asp:Label ID="Label20" runat="server" Text="Net Income : Rs." Font-Bold="True" ForeColor="Black" ></asp:Label> &nbsp;&nbsp;
                   <asp:Label ID="NetIncomeLBL" runat="server"  Font-Bold="True" ForeColor="Black" ></asp:Label>

               </td></tr>

               

                  </table>
                                   </font>


                  </asp:Panel>

 <div class="row" align="center">
               <br /> 
                  <div class="col-md-12" align="center">
                 <asp:Button ID="IncomeReportDownloadBtn" runat="server" Text="Download"  Height="60px" Width="130px" Font-Bold="True" CssClass="button" Font-Size="Large" Visible="false" OnClick="IncomeReportDownloadBtn_Click"  />
                    </div>
            </div>


                 </asp:Panel>

            </div>
            









         
        
       

  <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <!-- Include all compiled plugins (below), or include individual files as needed -->
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

        

    </form>
</body>
</html>
