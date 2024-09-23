<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="MariansArtistMangerApp.Calendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Calendar</title>

     <script src="Boostrap/js/popper.min.js"></script>
    <script src="Boostrap/js/jquery-3.3.1.slim.min.js"></script>
    <script src="Boostrap/js/bootstrap.js"></script>

    <link href="Boostrap/css/bootstrap.min.css" rel="stylesheet" />

    <link href="Buttons.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/themes/smoothness/jquery-ui.css">
<script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>

  <script src="http://code.jquery.com/jquery-latest.min.js"
    type="text/javascript"></script>
<script type="text/javascript" src="http://code.jquery.com/ui/1.11.4/jquery-ui.js"></script>


</head>
<body>


    <style type="text/css">
        body{
            /*background-image:url(MariansImages/mixer.jpg);*/
           background: rgb(19,18,71);
background: linear-gradient(90deg, rgba(19,18,71,1) 39%, rgba(17,29,72,1) 51%, rgba(18,30,102,1) 100%);
            background-repeat:no-repeat;
            background-size:cover;
            background-position:center center;
            background-attachment:fixed;
            height:100%;
        }
         .auto-style3 {
             height: 24px;
         }
         .auto-style4 {
             height: 38px;
         }
         .auto-style5 {
             left: 0px;
             top: 0px;
             height: 35px;

         }

         
.calendar { border: solid 1px #B8B8B8 !important; background-color: #F8F8F8 !important; color: #B8B8B8; }
.calendar td { font-weight: bold; background-color: #F8F8F8 !important; padding: 2px; }
.calendar table td { background-color: #2272A7 !important; border: solid 0px #2272A7; color: #F8F8F8; font-weight: bold; }
.calendar table td a { color: #F8F8F8 !important; text-decoration: none; }
.calendar a { color: #2272A7 !important; text-decoration: none !important; }


.myCalendar {  
    background-color: #efefef;  
    width: 200px;  
    opacity:0.92;
    height:100%;
    width:100%;
}  
  
/* 
    Common style declaration for hyper linked text 
*/  
.myCalendar a {  
    text-decoration: none;  
}  
  
/* 
    Styles declaration for top title 
    [TitleStyle] [CssClass] = myCalendarTitle 
*/  
.myCalendar .myCalendarTitle {  
    font-weight: bold;  
}  
  
/* 
    Styles declaration for date cells 
    [DayStyle] [CssClass] = myCalendarDay 
*/  
.myCalendar td.myCalendarDay {  
    border: solid 1px #fff;  
    border-left: 0;  
    border-top: 0;  
    
}  
  
/* 
    Styles declaration for next/previous month links 
    [NextPrevStyle] [CssClass] = myCalendarNextPrev 
*/  
.myCalendar .myCalendarNextPrev {  
    text-align: center;  
}  
  
/* 
    Styles declaration for Week/Month selector links cells 
    [SelectorStyle] [CssClass] = myCalendarSelector 
*/  
.myCalendar td.myCalendarSelector {  
    background-color: #dddddd;  
}  
  
.myCalendar .myCalendarDay a,   
.myCalendar .myCalendarSelector a,  
.myCalendar .myCalendarNextPrev a {  
    display:  block ;  
    line-height: 15px;  
     
}  
        .myCalendarDay noti_Container a {  
            display:  block ;  
    line-height: 15px;  
        }  
.myCalendar .myCalendarDay a:hover,   
.myCalendar .myCalendarSelector a:hover {  
    background-color: #cccccc;  
}  
  
.myCalendar .myCalendarNextPrev a:hover {  
    background-color: #fff;  
}



        .modalBackground {
            background-color:black;
            filter:alpha(opacity=90) !important;
            opacity:0.6 !important;
            z-index:20;

        }
        .modalpopup{
            padding:20px 0px 24px 10px;
            position:relative;
            width:450px;
            height:66px;
            background-color:white;
            border:1px solid black;
        }



    </style>
    <form id="form1" runat="server">

 <%--<div class="container-fluid">
            <div class="row">
                <div class="col-md-4 text-center">
     <script type="text/javascript">
         function ShowPopup(message) {
             $(function () {
                 $("#dialog").html(message);
                 $("#dialog").dialog({
                     title: "Event Details",
                     buttons: {
                         Close: function () {
                             $(this).dialog('close');
                         }
                     },
                     modal: true
                 });
             });
         };
     </script>
                    </div></div></div>--%>


         <div class="container-fluid">
            <div class="row">
                <div class="col-md-4 text-center">



                   
<%--<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter">
  Launch demo modal
</button>--%>

<!-- Modal -->

                    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
                    <div class="container">
                        <div class="row">
                            
                            <div class="col-md-12" align="center" >

<div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalCenterTitle">Event Details</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
          <asp:UpdatePanel ID="UpdatePanel6" runat="server">
              <ContentTemplate>
         <asp:Panel ID="Panel1" runat="server" Visible="true" CssClass="table-responsive">


        <table class="d-xl-table" border="1" >

             <tr>
                    <td class="auto-style13"><strong><span class="auto-style18" style ="color:black">Event </span></strong><span class="auto-style18" style ="color:black">Date</td>
                    <td class="auto-style17"><strong>
                        <asp:Label ID="EventDateLabel" runat="server" Text="NA" CssClass="auto-style18" ForeColor="black"></asp:Label>
                        </strong></td>
                </tr>

            <tr>
                    <td class="auto-style13" id="eventTimelbl"><strong><span class="auto-style18"  style ="color:black">Event</span></strong><span class="auto-style18" style ="color:black"> Time </span></td>
                    <td class="auto-style17"><strong>
                        <asp:Label ID="EventTimeLabel" runat="server" Text="NA" CssClass="auto-style18" ForeColor="black"></asp:Label>
                        </strong></td>
                </tr>
            
                <tr >
                    <td  class="auto-style14"  property ="" id="eventTypelbl"><strong><span class="auto-style18" style ="color:black">Event</span></strong><span class="auto-style18" style ="color:black"> Type</span></td>
                    <td class="auto-style15"><strong>
                        <asp:Label ID="EventTypeLabel" runat="server" Text="NA" CssClass="auto-style18" ForeColor="black"></asp:Label>
                        </strong></td>
                </tr>
                
             <tr>
                    <td class="auto-style13"><strong><span class="auto-style18" style ="color:black">Customer</span></strong><span class="auto-style18" style ="color:black"> Name</span></td>
                    <td class="auto-style17"><strong>
                        <asp:Label ID="CustomerNameLabel" runat="server" Text="Label" CssClass="auto-style18" ForeColor="black"></asp:Label>
                        </strong></td>
                </tr>
            <tr>
                    <td class="auto-style13"><strong><span class="auto-style18" style ="color:black">Contact </span></strong><span class="auto-style18" style ="color:black">Name:</td>
                    <td class="auto-style17"><strong>
                        <asp:Label ID="ContactNameLabel" runat="server" Text="NA" CssClass="auto-style18" ForeColor="black"></asp:Label>
                        </strong></td>
                </tr>
              <tr>
                    <td class="auto-style13"><strong><span class="auto-style18" style ="color:black">Contact </span></strong><span class="auto-style18" style ="color:black">No:</td>
                    <td class="auto-style17"><strong>
                        <asp:Label ID="ContactNoLabel" runat="server" Text="NA" CssClass="auto-style18" ForeColor="black"></asp:Label>
                        </strong></td>
                </tr>
            <tr>
                    <td class="auto-style13"><strong><span class="auto-style18" style ="color:black">Contact </span></strong><span class="auto-style18" style ="color:black">Address:</td>
                    <td class="auto-style17"><strong>
                        <asp:Label ID="AddressLabel" runat="server" Text="NA" CssClass="auto-style18" ForeColor="black"></asp:Label>
                        </strong></td>
                </tr>
                <tr>
                    <td class="auto-style13" id="venuelbl"><strong><span class="auto-style18"  style ="color:black">Venue</span></strong></td>
                    <td class="auto-style17"><strong>
                        <asp:Label ID="VenueLabel" runat="server" Text="NA" CssClass="auto-style18" ForeColor="black"></asp:Label>
                        </strong></td>
                </tr>
               
               
           
                <tr>
                    <td class="auto-style13"><strong><span class="auto-style18" style ="color:black">Couple</span></strong><span class="auto-style18" style ="color:black"> Name</span></td>
                    <td class="auto-style17"><strong>
                        <asp:Label ID="CoupleNameLabel" runat="server" Text="NA" CssClass="auto-style18" ForeColor="black"></asp:Label>
                        </strong></td>
                </tr>
            <tr>
                    <td class="auto-style13"><strong><span class="auto-style18" style ="color:black">Special</span></strong><span class="auto-style18" style ="color:black"> Note</span></td>
                    <td class="auto-style17"><strong>
                        <asp:Label ID="SpecialNoteLabel" runat="server" Text="NA" CssClass="auto-style18" ForeColor="black"></asp:Label>
                        </strong></td>
                </tr>
             <%--<tr>
                    <td class="auto-style13"><strong><span class="auto-style18" style ="color:white">Status </span></strong></td>
                    <td class="auto-style17"><strong>
                        <asp:Label ID="StatusLabel" runat="server" Text="NA" CssClass="auto-style18" ForeColor="White"></asp:Label>
                        </strong></td>
                </tr>--%>
                
            </table>
            </asp:Panel></ContentTemplate></asp:UpdatePanel>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
     
      </div>
    </div>
  </div>
</div>
                                </div></div></div>


                </div></div></div>







        <div class="container-fluid">
            <div class="row">
                <div class="col-md-4 text-center">
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <div id="dialog" style="display: none">
        </div>
<%--        <asp:Button ID="btnShowPopup" runat="server" Text="Show Popup" OnClick="btnShowPopup_Click" />--%>
    </ContentTemplate>
</asp:UpdatePanel> </div></div></div>

</div>

         <link href="Content/BackBtn.css" rel="stylesheet" />
         <a runat="server" id="BackBut" class="btn btn1" onserverclick="BackButton_Click">Back</a>

        <div class="container">
               
                    
                   
                        
                        <div class="row" align="center">
                            <div class="col" align="center">
                                <strong style="color:white;" ><asp:Label ID="OrderAmountLabel" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large" Text="Calendar" Width="320px" CssClass="img-fluid" ForeColor="white"></asp:Label></strong>
                            </div>
                        </div>
                        <br /> <br />
                   </div>
                
    


                                      
       <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
   
           <ContentTemplate>--%>
        <%-- <div class="container">

                
                         <div class="row" align="center">
             

                            <div class="col-md-12" align="center" Height="100%" width="100%">
        
        <div class="img-fluid">--%>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                                    <asp:Calendar ID="calendar" runat="server" BackColor="#333333"
                                        FirstDayOfWeek="Monday"  
        BorderColor="White" BorderWidth="0px"
        Font-Names="Verdana" Font-Size="9pt" ForeColor="White" Height="100%"
        ondayrender="Calendar1_DayRender" Width="100%"  Font-Bold="True" OnSelectionChanged="calendar_SelectionChanged"  NextMonthText="&gt;&gt;" data-toggle="modal" data-target="#exampleModalCenter"  PrevMonthText="&lt;&lt;" CssClass="myCalendar"  OnVisibleMonthChanged="calendar_VisibleMonthChanged" CellSpacing="15" CellPadding="5" >
         <OtherMonthDayStyle ForeColor="white" />
            <DayStyle CssClass="myCalendarDay" ForeColor="White" Height="180px" Width="180px" HorizontalAlign="center" VerticalAlign="Top" />
            <DayHeaderStyle  ForeColor="white" HorizontalAlign="Center" VerticalAlign="Middle" />
<SelectedDayStyle Font-Bold="True" Font-Size="12px" CssClass="myCalendarSelector" />
            <TodayDayStyle CssClass="myCalendarToday" />
            <SelectorStyle CssClass="myCalendarSelector" />
            <NextPrevStyle CssClass="myCalendarNextPrev" />
            <TitleStyle CssClass="myCalendarTitle" />
    </asp:Calendar>

               </ContentTemplate> </asp:UpdatePanel>
                 <%--   </div>     

                                </div>

                        
           
             </div>--%>
          <div class="col-md-12" align="center">

          <asp:TextBox ID="SearchTextBox" runat="server" Width="300px" Height="45px" Font-Bold="True" Font-Size="Large" OnTextChanged="SearchTextBox_TextChanged"></asp:TextBox>
<asp:UpdatePanel ID="UpdatePanel7" runat="server">
   
           <ContentTemplate>
       <%--  <asp:Button ID="ShowDetailsBtn" runat="server" Height="45px" OnClick="Show_Details_Click" Text="Show Details" Font-Bold="True" Font-Size="Large" Visible="False" />--%>
          </ContentTemplate></asp:UpdatePanel>
           
             </div>
                            <%-- </div>
          

                        </div>--%>
                        <br /> <br /><%--</ContentTemplate></asp:UpdatePanel>--%>

       
            

                   



       
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
   
           <ContentTemplate>
         <div class="container">

                
          <div class="row" align="center">
              <div class="col-md-4 text-center">





<%--        <asp:Panel ID="Panel1" runat="server" Visible="False" CssClass="table-responsive">


        <table class="d-xl-table" border="1" >

             <tr>
                    <td class="auto-style13"><strong><span class="auto-style18" style ="color:white">Event </span></strong><span class="auto-style18" style ="color:white">Date</td>
                    <td class="auto-style17"><strong>
                        <asp:Label ID="EventDateLabel" runat="server" Text="NA" CssClass="auto-style18" ForeColor="White"></asp:Label>
                        </strong></td>
                </tr>

            <tr>
                    <td class="auto-style13" id="eventTimelbl"><strong><span class="auto-style18"  style ="color:white">Event</span></strong><span class="auto-style18" style ="color:white"> Time </span></td>
                    <td class="auto-style17"><strong>
                        <asp:Label ID="EventTimeLabel" runat="server" Text="NA" CssClass="auto-style18" ForeColor="White"></asp:Label>
                        </strong></td>
                </tr>
            
                <tr >
                    <td  class="auto-style14"  property ="" id="eventTypelbl"><strong><span class="auto-style18" style ="color:white">Event</span></strong><span class="auto-style18" style ="color:white"> Type</span></td>
                    <td class="auto-style15"><strong>
                        <asp:Label ID="EventTypeLabel" runat="server" Text="NA" CssClass="auto-style18" ForeColor="White"></asp:Label>
                        </strong></td>
                </tr>
                
             <tr>
                    <td class="auto-style13"><strong><span class="auto-style18" style ="color:white">Customer</span></strong><span class="auto-style18" style ="color:white"> Name</span></td>
                    <td class="auto-style17"><strong>
                        <asp:Label ID="CustomerNameLabel" runat="server" Text="Label" CssClass="auto-style18" ForeColor="White"></asp:Label>
                        </strong></td>
                </tr>
            <tr>
                    <td class="auto-style13"><strong><span class="auto-style18" style ="color:white">Contact </span></strong><span class="auto-style18" style ="color:white">Name:</td>
                    <td class="auto-style17"><strong>
                        <asp:Label ID="ContactNameLabel" runat="server" Text="NA" CssClass="auto-style18" ForeColor="White"></asp:Label>
                        </strong></td>
                </tr>
              <tr>
                    <td class="auto-style13"><strong><span class="auto-style18" style ="color:white">Contact </span></strong><span class="auto-style18" style ="color:white">No:</td>
                    <td class="auto-style17"><strong>
                        <asp:Label ID="ContactNoLabel" runat="server" Text="NA" CssClass="auto-style18" ForeColor="White"></asp:Label>
                        </strong></td>
                </tr>
            <tr>
                    <td class="auto-style13"><strong><span class="auto-style18" style ="color:white">Contact </span></strong><span class="auto-style18" style ="color:white">Address:</td>
                    <td class="auto-style17"><strong>
                        <asp:Label ID="AddressLabel" runat="server" Text="NA" CssClass="auto-style18" ForeColor="White"></asp:Label>
                        </strong></td>
                </tr>
                <tr>
                    <td class="auto-style13" id="venuelbl"><strong><span class="auto-style18"  style ="color:white">Venue</span></strong></td>
                    <td class="auto-style17"><strong>
                        <asp:Label ID="VenueLabel" runat="server" Text="NA" CssClass="auto-style18" ForeColor="White"></asp:Label>
                        </strong></td>
                </tr>
               
               
           
                <tr>
                    <td class="auto-style13"><strong><span class="auto-style18" style ="color:white">Couple</span></strong><span class="auto-style18" style ="color:white"> Name</span></td>
                    <td class="auto-style17"><strong>
                        <asp:Label ID="CoupleNameLabel" runat="server" Text="NA" CssClass="auto-style18" ForeColor="White"></asp:Label>
                        </strong></td>
                </tr>
            <tr>
                    <td class="auto-style13"><strong><span class="auto-style18" style ="color:white">Special</span></strong><span class="auto-style18" style ="color:white"> Note</span></td>
                    <td class="auto-style17"><strong>
                        <asp:Label ID="SpecialNoteLabel" runat="server" Text="NA" CssClass="auto-style18" ForeColor="White"></asp:Label>
                        </strong></td>
                </tr>
             <%--<tr>
                    <td class="auto-style13"><strong><span class="auto-style18" style ="color:white">Status </span></strong></td>
                    <td class="auto-style17"><strong>
                        <asp:Label ID="StatusLabel" runat="server" Text="NA" CssClass="auto-style18" ForeColor="White"></asp:Label>
                        </strong></td>
                </tr>--%>
                
            <%--</table>--%>
            <%--</asp:Panel>--%>
                             </div></div></div>
               </ContentTemplate></asp:UpdatePanel>





       <%--  <div class="container">
              
    <div class="row">
         <div class="col-md-12">


           <asp:Image ID="Image2" runat="server" Height="25px" ImageUrl="~/MariansImages/4Udi3l.png" Width="100%" /></div>
      <div class="col-md-12">
        
        <div class="table-responsive">

            <div style="width: 100%; height: 400px; overflow: auto" >

                  
       <asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>
    
         <asp:GridView ID="GridView2" runat="server" 
                  AutoGenerateSelectButton="True" CellPadding="1"  RowStyle-Wrap="true"  ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="25" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Font-Size="Small" width="100%" HorizontalAlign="Center" ShowFooter="True"  HeaderStyle-CssClass="GVFixedHeader">
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
       </ContentTemplate>
         </asp:UpdatePanel>
            
            
           </div>
            
        </div>
      </div>
    </div> 

               
  </div>--%>



       <%--    <div class="container">
              
    <div class="row">
         <div class="col-md-12">


           <asp:Image ID="Image1" runat="server" Height="25px" ImageUrl="~/MariansImages/4Udi3l.png" Width="100%" /></div>
      <div class="col-md-12">
        
        <div class="table-responsive">

            <div style="width: 100%; height: 400px; overflow: auto" >

                  
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
         <asp:GridView ID="GridView1" runat="server" 
                  AutoGenerateSelectButton="True" CellPadding="1"  RowStyle-Wrap="true"  ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="25" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Font-Size="Small" width="100%" Height="10%" HorizontalAlign="Center" ShowFooter="True"  HeaderStyle-CssClass="GVFixedHeader">
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
       </ContentTemplate>
         </asp:UpdatePanel>
            
            
           </div>
            
        </div>
      </div>
    </div> 

               
  </div>--%>
             
       

        <div class="container-fluid">
            <div class="row">

                <div class="col" align="right">
                   <img src="MariansImages/Marians3.png" alt="" width="180"/>
                </div>
            </div></div>


    </form>
</body>
</html>

