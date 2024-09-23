<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirmed_Document.aspx.cs" Inherits="ArtistManagerApp.Confirmed_Document" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Document</title>

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


           .VertiColumn th {
               writing-mode: tb-rl;
               filter: fliph()flipV();
           }


table
           {
               border: 35px solid white;
                font-size:medium;
           }

           .auto-style6 {
               height: 24px;
           }

           .auto-style7 {
               height: 30px;
           }

           .auto-style8 {
               height: 72px;
           }

           </style>
    <form id="form1" runat="server">
             <link href="Content/BackBtn.css" rel="stylesheet" />
         <a runat="server" id="BackBut" class="btn btn1" onserverclick="BackButton_Click">Back</a>

        <div class="container">
               
                    
                   
                        
                        <div class="row" align="center">
                            <div class="col" align="center">
                                <strong style="color:white;" ><asp:Label ID="OrderAmountLabel" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large" Text="Document" Width="320px" CssClass="img-fluid" ForeColor="white"></asp:Label></strong>
                            </div>
                        </div>
                        <br /> <br />
                   </div>

        <asp:Panel ID="WediingPannel" runat="server">

        <div class="container">
            <div class="row" align="center">
                
                  <div class="col-md-12">
        
        <div class="table-responsive"> 

            <div style="width: 640px; height: 100%; overflow: auto" class="table-responsive" >
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                    <asp:Panel ID="Panel1" runat="server" BackColor="white"  Height="100%" CssClass="table-responsive"  BorderColor="Black" BorderStyle="Solid" ScrollBars="Auto">
                      
                        <font size="2"  face="Times New Roman" >
              <table style="width:100%" class="table-responsive"  >
                
           <tr>
               <td colspan="5" >
                

                <img src="https://i.imgur.com/a0BuW1b.jpeg" width="560" />

</td>

                 
           </tr>


                     <tr align="center">
               <td colspan="5" class="auto-style7" >
                  
                   <asp:Label ID="Label1" runat="server" Text=" RESERVATION AGREEMENT FOR WEDDINGS" Font-Bold="True" ForeColor="Black" ></asp:Label>
                  
                   
</td>


           </tr>
                    <tr align="left">
               <td colspan="5" class="auto-style7" >
                  
                   <asp:Label ID="Label2" runat="server" Text="WE ARE FULLY VACCINATED" Font-Bold="True" ForeColor="#33CC33" Font-Underline="True" Font-Size="23px" ></asp:Label>
                  
                   
</td>
           </tr>






               <tr align="left">
               <td colspan="2"> Date of Booking Conformation
                   </td>

                   <td colspan="2">: <asp:Label ID="DateofBookingConfirmLBL" runat="server" Font-Bold="True"></asp:Label>
                   </td>
                   <td colspan="1"></td>
           </tr>

                  <tr align="left">
               <td colspan="2">  Date of Event 
                   </td>

                   <td colspan="2"> : <asp:Label ID="DateOfEventLBL" runat="server" Font-Bold="True"></asp:Label>
                   </td>

                      <td colspan="1"></td>
           </tr>

                   <tr align="left">
               <td colspan="2"> Couple Name  
                   </td>

                   <td colspan="2"> : <asp:Label ID="cplnamelbl" runat="server" Font-Bold="True"></asp:Label>
                   </td>

                       <td colspan="1"></td>
           </tr>

                     <tr align="left">
               <td colspan="2">  Venue    
                   </td>

                   <td colspan="2">  : <asp:Label ID="VenueLBL" runat="server" Font-Bold="True"></asp:Label> 
                   </td>

                         <td colspan="1"></td>
           </tr>

                   <tr align="left">
               <td colspan="2">   Time (From – To)   
                   </td>

                   <td colspan="2">  : <asp:Label ID="TimeFromToLBL" runat="server" Font-Bold="True"></asp:Label> 

                   </td>

                       <td colspan="1"></td>
           </tr>


                    <tr align="left">
               <td colspan="2">  Full Contract Price     
                   </td>

                   <td colspan="2">   :<b> Rs.</b> <asp:Label ID="ActualRateLBL" runat="server" Font-Bold="True"></asp:Label>

                   </td>

                        <td colspan="1"></td>
           </tr>
                   <tr align="left">
               <td colspan="2">  Discount Price    
                   </td>

                   <td colspan="2">   :<b> Rs.</b> <asp:Label ID="DiscountPriceLBL" runat="server" Font-Bold="True"></asp:Label>

                   </td>

                        <td colspan="1"></td>
           </tr>

                   <tr align="left">
               <td colspan="2">  Net Price    
                   </td>

                   <td colspan="2">   :<b> Rs.</b> <asp:Label ID="FullContractPriceLBL" runat="server" Font-Bold="True"></asp:Label>

                   </td>

                        <td colspan="1"></td>
           </tr>

       

                    <tr align="center">
               <td colspan="5">
                  <br />
</td>
           </tr>

                   <tr align="left">
               <td colspan="5" class="auto-style7" >
                  
                   <asp:Label ID="Label3" runat="server" Text="PLEASE NOTE THAT THIS CONTRACT PRICE IS VALID FOR YEAR " Font-Bold="True" ForeColor="Red" Font-Underline="False" Font-Size="Medium" ></asp:Label>
               &nbsp;      <asp:Label ID="EventyearLBL" runat="server" Text="" Font-Bold="True" ForeColor="Red" Font-Underline="False" Font-Size="Medium" ></asp:Label>
               &nbsp;    <asp:Label ID="Label15" runat="server" Text="ONLY." Font-Bold="True" ForeColor="Red" Font-Underline="False" Font-Size="Medium" ></asp:Label>
                  

                   
</td>
           </tr>


                  <tr align="left">
               <td colspan="5">
              This Agreement is entered into on this <asp:Label ID="DateLBL" runat="server" Font-Bold="True"></asp:Label><asp:Label ID="SuffixLBL" runat="server" Font-Bold="True" ></asp:Label>  of <asp:Label ID="MonthLBL" runat="server" Font-Bold="True"></asp:Label> <asp:Label ID="YearLBL" runat="server" Font-Bold="True"></asp:Label>  between <b>GRAVITY</b> a musical band established in Sri Lanka and having its registered address at 
                   <b>82/A, 1st lane, Rajagahawatta, Chilaw, Sri Lanka</b> (Hereinafter referred to as the “BAND” and which shall include its successor and assigns) and <asp:Label ID="CustomerNameLBL" runat="server" Font-Bold="True"></asp:Label> holder of National Identity Card No.<asp:Label ID="NICNOlbl" runat="server" Font-Underline="True" Font-Bold="True"></asp:Label> (Hereinafter referred to as the “CUSTOMER” and which shall include its successors and assigns)  (Each a “Party” and together the “Parties”).
</td>
           </tr>

                   <tr align="left">
               <th colspan="5">
                  Terms and Conditions
</th>
           </tr>
                    <tr align="left">
                        
               <th colspan="5">
                 <b> 1. Payments</b>
</th>
           </tr>
                  <tr>
                       
                      
                  
      <td align="right" style="vertical-align: top;" colspan="1">  a. </td>
                               <td align="left" colspan="4">
            
                                   
                                  <b>Please note that any changes on your scheduled wedding date due to the current COVID-19 pandemic will not affect the initial advance payment of </b> <asp:Label ID="Label4" runat="server" Text="Rs." Font-Bold="True" ForeColor="#33CC33"></asp:Label> <asp:Label ID="AdvanceAmountLBL" runat="server" Font-Bold="True" ForeColor="#33CC33"></asp:Label><b> made and the new date change will be done without any additional charges.</b>
                                   <asp:Label ID="Label5" runat="server" Text="However, the advance payment will not be refunded even if the wedding is cancelled." Font-Bold="True" ForeColor="Red"></asp:Label> 
                                   
                                   
                     
</td>
           </tr>

                      <tr align="center">
               <td colspan="5" class="auto-style6">
                  <br />
</td>
           </tr>
                   <tr>
                       
                      
                       
      <td align="right" style="vertical-align: top;" colspan="1"> b.  </td>
                               <td align="left" colspan="4">
             	CUSTOMER should settle the balance payment of <asp:Label ID="Label6" runat="server" Text="Rs." Font-Bold="True" ForeColor="#33CC33"></asp:Label> <asp:Label ID="BalanceAmountLBL" runat="server" Font-Bold="True" ForeColor="#33CC33"></asp:Label> by handing it over to BAND Office located at 
                                   <b>82/A, 1st lane, Rajagahawatta, Chilaw, Sri Lanka, or deposit to </b> <asp:Label ID="Label7" runat="server" Text="Gravity Account 1430010500 of Commercial bank at Chilaw branch " Font-Bold="True" ForeColor="Red"></asp:Label>
                                   <b>at least Fourteen (14) days (2 Weeks) prior to the event date. </b>
                               </td>
           </tr>

                        <tr align="center">
               <td colspan="5">
                  <br />
</td>
           </tr>

                        <tr align="left">
                       
               <th colspan="5">
                 <b> 2. Postponement / Cancelation of Event</b>
</th>
           </tr>

                      <tr>
                       
                      
                       
      <td align="right" style="vertical-align: top;" colspan="1"> a.  </td>
                               <td align="left" colspan="4">
        If the event date has been postponed by the CUSTOMER, this agreement will become null and void and CUSTOMER should negotiate for a new event date with the BAND and it will be subject to the availability of the BAND on the said date. 
</td>
           </tr>
                       <tr align="center">
               <td colspan="5">
                  <br />
</td>
           </tr>

                      <%--  <tr>
                       
                      
                       
      <td valign="top" colspan="1">  </td>
                               <td align="left" colspan="4">
        However Non-refundable advance payment will not be set-off against the alternative date even the Band is available and it will be considered as a fresh Booking where CUSTOMER need to pay a fresh advance payment and confirm the booking. 
</td>
           </tr>--%>

<%--  <tr align="center">
               <td colspan="5">
                  <br />
</td>
           </tr>--%>

        <tr>
                       
                      
                       
      <td align="right" style="vertical-align: top;" colspan="1"> b.  </td>
                               <td align="left" colspan="4">
      If the event is canceled by the Customer, it should be communicated to the BAND in writing (either by letter fax or e-mail) and this agreement will become null and void. 
                                
                                   <asp:Label ID="Label8" runat="server" Text="AT THIS POINT THE ADVANCE PAYMENT WILL BE CANCELLED." Font-Bold="True" ForeColor="Red"></asp:Label>
</td>
           </tr>
  <tr align="center">
               <td colspan="5">
                  <br />
</td>
           </tr>

      <tr>
                       
                      
                       
      <td valign="top" colspan="1">  </td>
                               <td align="left" colspan="4">
       If the CUSTOMER informs fourteen (14) days prior to the above event date CUSTOMER is liable to pay seventy five percent (75%) of the total amount which includes the advance payment as well.
</td>
           </tr>


                         <tr align="center">
               <td colspan="5">
                  <br />
</td>
           </tr>

                      <tr align="left">
                       
               <th colspan="5">
              <b>3.	Providing music to other artists and Provision of Sounds to another Band</b>
</th>
           </tr>

                   <tr>
                       
                      
                       
      <td align="right" style="vertical-align: top;" colspan="1" class="auto-style8"> a.  </td>
                               <td align="left" colspan="4" class="auto-style8">
       CUSTOMER agree to pay Rs.25,000 (Rupees Twenty-Five thousand) for each performing guest artists for the provisioning of Music by the BAND during the time of the event.
</td>
           </tr>
                  
                         <tr align="center">
               <td colspan="5">
                  <br />
</td>
           </tr>

                      <tr>
                       
                      
                       
      <td align="right" style="vertical-align: top;" colspan="1"> b.  </td>
                               <td align="left" colspan="4">
     CUSTOMER agree to pay additional Rupees Rs.50,000 (Rupees Fifty Thousand) for the provision of sounds by the BAND to another Band or DJ during the time of event.
</td>
           </tr>
                         <tr align="center">
               <td colspan="5" >
                  <br />
</td>
           </tr>

                       <tr align="left">
                        
               <th colspan="5">
             <b> 4.	Time</b>
</th>
           </tr>

                       <tr>
                       
                      
                       
      <td align="right" style="vertical-align: top;" colspan="1"> a.  </td>
                               <td align="left" colspan="4">
    CUSTOMER is here by agree to strictly comply with the time allocation mention in the below of this contract and strictly no time–extensions will be entertained by the BAND under any circumstances.
</td>
           </tr>
                        <tr align="center">
               <td colspan="5" class="auto-style6" >
                  <br />
</td>
           </tr>

                  <tr align="left">
                       
               <th colspan="5" >
          <b>    5.	Facilities provided by the BAND to CUSTOMER</b>
</th>
           </tr>

                       <tr>
                       
                      
                       
      <td align="right" style="vertical-align: top;" colspan="1"> a.  </td>
                               <td align="left" colspan="4">
                                   <asp:Label ID="Label9" runat="server" Text="The BAND here by agrees to provide " ForeColor="Red"></asp:Label><asp:Label ID="Label10" runat="server" Text="Sound, Lights and Transportation." ForeColor="Red" Font-Bold="True"></asp:Label>
                               </td>
           </tr>
                   <tr align="center">
               <td colspan="5" >
                  <br />
</td>
           </tr>
                      <tr>
                       
                      
                       
      <td align="right" style="vertical-align: top;" colspan="1"> b.  </td>
                               <td align="left" colspan="4">
   Audio facility to play audio CDs for CUSTOMER ‘pre-shoot’ activities during the event time and it will be free of charge.
                                   
                               </td>
           </tr>
                        <tr align="center">
               <td colspan="5" >
                  <br />
</td>
           </tr>


                      <tr align="left">
                       
               <th colspan="5" >
             <b> 6.	Facilities provided by the CUSTOMER to BAND</b>
</th>
           </tr>

                       <tr>
                       
                      
                       
      <td align="right" style="vertical-align: top;" colspan="1"> a.  </td>
                               <td align="left" colspan="4">
  CUSTOMER here by agree to arrange a reserved table exclusively for 
                                   <asp:Label ID="Label11" runat="server" Text="(10) ten members " ForeColor="Red" Font-Bold="True"></asp:Label>
                                   
                                   of the BAND in coordination with the hotel management and a board to be displayed on the table “RESERVED FOR GRAVITY BAND”. Also, the table to be placed next to the stage either right or left of the stage. 
                                  
                                     <asp:Label ID="Label12" runat="server" Text=" STAGE SIZE SHOULD BE MINIMUM 24X8 " ForeColor="Red" Font-Bold="True"></asp:Label>
</td>
           </tr>
                        <tr align="center">
               <td colspan="5" >
                  <br />
</td>
           </tr>

                        <tr>
                       
                      
                       
      <td align="right" style="vertical-align: top;" colspan="1"> b.  </td>
                               <td align="left" colspan="4">
 
                                CUSTOMER should make sure that the no photographers and video crew is not allowed for the reserved table.
</td>
           </tr>

                        <tr align="center">
               <td colspan="5">
                  <br />
</td>
           </tr>

                      <tr>
                       
                      
                       
      <td align="right" style="vertical-align: top;" colspan="1"> c.  </td>
                               <td align="left" colspan="4">
 
                      CUSTOMER agrees to provide the same meals which are served for the guests during the event will be severed for ten (10) band members.
</td>
           </tr>

                        <tr align="center">
               <td colspan="5" >
                  <br />
</td>
           </tr>

                   <tr align="left">
                      
               <th colspan="5">
            <b> 7.	Termination of this Agreement</b>
</th>
           </tr>

                       <tr>
                       
                      
                       
      <td align="right" style="vertical-align: top;" colspan="1"> a.  </td>
                               <td align="left" colspan="4">
  This agreement will be terminated upon the completion of the event which is mentioned below in this agreement or may terminated due to the points mentioned in Point No 2 of this agreement.
</td>
           </tr>

    <tr align="center">
               <td colspan="5" >
                  <br />
</td>
           </tr>
                  
                    <tr align="left">
                      
               <th colspan="5">
            <b> 8.	Governing Law/Submission to Jurisdiction</b>
</th>
           </tr>

                       <tr>
                       
                      
                       
      <td align="right" style="vertical-align: top;" colspan="1"> a.  </td>
                               <td align="left" colspan="4">
 This Agreement and all transactions entered into hereunder shall be governed by the Laws of Sri Lanka and the Parties submit to the exclusive jurisdiction of the courts of Sri Lanka.
</td>
           </tr>
                  <tr align="center">
               <td colspan="5" >
                  <br />
</td>
           </tr>


                  
                  <tr align="left">
               <td colspan="5">
            We kindly request you to carefully check the content of this agreement and inform us of any errors immediately to avoid any inconveniences subsequently and acknowledge receipt of this agreement by replying to this e-mail.
</td>
           </tr>
                   <tr align="center">
               <td colspan="5" >
                  <br />
</td>
           </tr>


                  
                  <tr align="left">
               <td colspan="5">
           We hereby acknowledge the receipt of Advance Payment of <asp:Label ID="Label13" runat="server" Text="Rs." Font-Bold="True" ForeColor="#33CC33"></asp:Label><asp:Label ID="AdvanceAmount2LBL" runat="server" Font-Bold="True" ForeColor="#33CC33"></asp:Label> made to our bank account W K S FERNANDO (Commercial Bank AC # 1130095162) on <asp:Label ID="AdvancePaymentDateLBL" runat="server" Font-Bold="True"></asp:Label> and confirm the Band booking as per the above terms and conditions in this agreement.

</td>
           </tr>

                   <tr align="center">
               <td colspan="5" >
                  <br />
</td>
           </tr>


                  
                  <tr align="left">
               <td colspan="5">
                   Thank you for the booking made with GRAVITY and waiting to provide the best of our service at the event on <asp:Label ID="eventdatelbl" runat="server" Font-Overline="False"  Font-Bold="True"></asp:Label>&nbsp; <b>at </b> <asp:Label ID="EventPlacelbl" runat="server" Font-Overline="False"  Font-Bold="True"></asp:Label>.
</td>
           </tr>

                   <tr align="left">
               <td colspan="5">
         

                    <asp:Label ID="Label16" runat="server" Text="It should be noted that the contract sum will alter if there is a considerable change in the price of fuel." Font-Bold="True" ForeColor="Red"></asp:Label>

               </td>
           </tr>

                      <tr align="center">
               <td colspan="5" >
                  <br />
</td>
           </tr>


                  
                  <tr align="left">
               <td colspan="5">
                   For and on behalf of GRAVITY BAND
</td>
           </tr>

                       <tr align="center">
               <td colspan="5" >
                  <br />
</td>
           </tr>


                  
                  <tr align="left">
               <td colspan="4">
       
                   <img src="https://i.imgur.com/eYM4xVQ.png" height="50px"   />
</td>
       <td>
        Date:<br /> <asp:Label ID="AgreementDateLBL" runat="server" Font-Bold="True"></asp:Label>
</td>
           </tr>

                    <tr align="left">
               <td colspan="5">
          Mr. Kaweesha Fernando <br />Manager GRAVITY

</td></tr>

                  <tr align="center">
               <td colspan="5" >
                  <br />
</td>
           </tr>


                  
                  <tr align="left">
               <td colspan="5">
         On behalf of CUSTOMER
</td>
           </tr>

                   <tr align="center">
               <td colspan="5" >
                  <br />
</td>
           </tr>


                  
                  <tr align="left">
               <td colspan="5">
         I have read and understood the above agreement and confirm that it is in order and have no objection against the terms and conditions mentioned in the agreement.
</td>
           </tr>
                    <tr align="center">
               <td colspan="5" >
                  <br />
</td>
           </tr>
                   <tr align="center">
               <td colspan="5" >
                  <br />
</td>
           </tr>


                  
                  <tr align="left">
               <td colspan="4">
           Name: <asp:Label ID="CustomerNameLBL2" runat="server" Font-Bold="True"></asp:Label>  <br />
   
</td>
       <td>
        Date: …………………………..
</td>
           </tr>

             


                     <tr align="center">
               <td colspan="5" >
                  <br />
</td>
           </tr>
                   <tr align="left">
               <td colspan="5" >
                   Contact Number: <asp:Label ID="CustomerNumberLBL" runat="server" Font-Bold="True"></asp:Label>
                  <br />
</td>
           </tr>

                   <tr align="left">
               <td colspan="5" >
                    <br />
</td>
           </tr>

                                    <tr align="left">
               <td colspan="2">
                   Gravity Office
</td>
                                        <td>
         	031-2226606
</td><td colspan="2"></td>
           </tr>


                                       <tr align="left">
               <td colspan="2">
        Manager	
</td>
                                        <td>
         	071-7316216
</td><td colspan="2"></td>
           </tr>


                                       <tr align="left">
               <td colspan="2">
         Accountant
</td>
                                        <td>
         	077-7392585
</td><td colspan="2"></td>
           </tr>
                   <caption>
                       <br />
                       <tr align="left">
                           <td colspan="5">
                               <asp:Label ID="Label14" runat="server" Text="System Generated Invoice" Font-Italic="True" Font-Size="21px"></asp:Label>
                               

                           </td>
                       </tr>
                       <%-- <tr>
    <td colspan="1"></td> <td colspan="2" align="left">Event Date </td>
    <td colspan="3" align="left">
        : <asp:Label ID="eventdatelbl" runat="server" Font-Size="Small"></asp:Label> </td>
   <td colspan="1"></td> <td colspan="2" align="left"> Event Time</td>
      <td colspan='3'align= "left">
         : <asp:Label ID="evntTimelbl" runat="server" Font-Size="Small"></asp:Label>  </td>
  </tr>
  <tr>
   <td colspan="1"></td> <td colspan="2" align="left">Event Type </td>
    <td colspan="3" align="left">
        : <asp:Label ID="eventtypelbl" runat="server" Font-Size="Small"></asp:Label> </td>
    <td colspan="1"></td><td colspan="2" align="left">Contact Name</td>
      <td colspan='3'align= left>
          : <asp:Label ID="contactnamelbl" runat="server" Font-Size="Small"></asp:Label>  </td>
  </tr>
  <tr>
    <td colspan="1"></td> <td colspan="2" align="left">Contact Number</td>
    <td colspan="3" align="left">
        : <asp:Label ID="contactnumberlbl" runat="server" Font-Size="Small"></asp:Label> </td>
   <td colspan="1"></td> <td colspan="2" align="left"> Contact Address</td>
      <td colspan='3'align= left>
          : <asp:Label ID="contactAddresslbl" runat="server" Font-Size="Small"></asp:Label>  </td>
  </tr>

                  <tr>
    <td colspan="1"></td> <td colspan="2" align="left">Customer Name</td>
    <td colspan="3" align="left">
       : <asp:Label ID="CustomerNamelbl" runat="server" Font-Size="Small"></asp:Label> </td>
   <td colspan="1"></td> <td colspan="2" align="left"> Venue</td>
      <td colspan='3'align= left>
          : <asp:Label ID="venuelbl" runat="server" Font-Size="Small"></asp:Label>  </td>
  </tr>

                  <tr>
    <td colspan="1"></td> <td colspan="2" align="left">Special Note</td>
    <td colspan="3" align="left">
        : <asp:Label ID="spclnotelbl" runat="server" Font-Size="Small"></asp:Label> </td>
   <td colspan="1"></td> <td colspan="2" align="left"> Couple Name</td>
      <td colspan='3'align= left>
          : <asp:Label ID="cplnamelbl" runat="server" Font-Size="Small"></asp:Label>  </td>
  </tr>


                  <tr>
    <td colspan="1"></td> <td colspan="2" align="left">Agent Name</td>
    <td colspan="3" align="left">
        : <asp:Label ID="AgentLBL" runat="server" Font-Size="Small"></asp:Label> </td>
   <td colspan="1"></td> <td colspan="2" align="left"> </td>
      <td colspan='3'align= left>
          <%--: <asp:Label ID="Label2" runat="server" Font-Size="Small"></asp:Label></td> --%>
                       <%-- </tr>
                   <tr align="center">
               <td colspan="11">
                   <img src="MariansImages/4Udi3l.png" height="10px" />
</td>
           </tr>

                   <tr align="center">
               <th colspan="11">
              DETAILS OF RECEIVER - BILLED TO
</th>
           </tr>

                    <tr align="center">
               <td colspan="11">
             Name   :  <asp:Label ID="customerNamelabel" runat="server" Text=""></asp:Label>
</td>
           </tr>

                    <tr align="center">
               <td colspan="11">
            Address :  <asp:Label ID="AddressLabel" runat="server" Text=""></asp:Label>
</td>
           </tr>

                    <tr align="center">
               <td colspan="11">
                   <img src="MariansImages/4Udi3l.png" height="10px" />
</td>
           </tr>


                  <tr>
    <td colspan="1"></td> <td colspan="2" align="left">Payment Type</td>
    <td colspan="4" align="left">
        : <asp:Label ID="paymentTypelbl" runat="server" Text=""></asp:Label> </td>
   
  </tr>

                             <tr>
    <td colspan="1"></td> <td colspan="2" align="left">Amount</td>
    <td colspan="4" align="left">
        : LKR <asp:Label ID="amount" runat="server" Text=""></asp:Label> </td>
   
  </tr>

                             <tr>
    <td colspan="1"></td> <td colspan="2" align="left">Payment Description</td>
    <td colspan="4" align="left">
        : <asp:Label ID="pdescription" runat="server" Text=""></asp:Label> </td>
   
  </tr>

                             <tr>
    <td colspan="1"></td> <td colspan="2" align="left">Bank</td>
    <td colspan="4" align="left">
        : <asp:Label ID="bank" runat="server" Text=""></asp:Label> </td>
   
  </tr>

                  <caption>
                      --%&gt;
                  </caption>--%>
                  </caption>


</table>
                            </font>
                    </asp:Panel>

                 
<br /><br />
              

                </div>
          </div>
                  </div></div>
       
        </div>


        <div class="container">
            <div class="row" align="center">
               <br /> <br /> 
                  <div class="col-md-12" align="center">
                 <asp:Button ID="Print" runat="server" Text="Download" OnClick="Print_Click" Height="60px" Width="130px" Font-Bold="True" CssClass="button" Font-Size="Large" />
                    </div>
            </div>
        </div>

            </asp:Panel>

         <asp:Panel ID="CommonInvoicePanel" runat="server">
               <div class="container">
            <div class="row" align="center">
                
                  <div class="col-md-12">
        
        <div class="table-responsive"> 

            <div style="width: 700px; height: 100%; overflow: auto" class="table-responsive" >
                 <asp:Panel ID="InvoicePanel" runat="server" BackColor="white"  Height="100%" CssClass="table-responsive"  BorderColor="Black" BorderStyle="Solid" ScrollBars="Auto">
                      
                        <font size="2"  face="Times New Roman" >
              <table style="width:100%" class="table-responsive"  >
                   <tr>
               <td >
             <img src="https://i.imgur.com/a0BuW1b.jpeg" width="560" />

</td>       
           </tr>
                   <tr >
              
       <td align="right">
         <asp:Label ID="IDateLBL" runat="server" Font-Bold="True"></asp:Label>
</td>
           </tr>

                <tr align="center">
              
       <td>
        <asp:Label ID="Label17" runat="server" Text="INVOICE" Font-Bold="True" ForeColor="Black" Font-Underline="True"></asp:Label>
           <br /> <br /> 
 
</td>
           </tr>
                  <tr>
                      <td>
<table  width="100%" >
               <tr>
                   <td  align="left">
                    Event  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       : <asp:Label ID="IEventNameLBL" runat="server" Text=""></asp:Label>
                       <br />
                          Date  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       : <asp:Label ID="IEventDateLBL" runat="server" Text=""></asp:Label>
                       <br />
                          Time &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       : <asp:Label ID="IEventTimeLBL" runat="server" Text=""></asp:Label>
                       <br />
                       Venue  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       : <asp:Label ID="IEventVenueLBL" runat="server" Text=""></asp:Label>
                   </td>
                  

               </tr>
              
             
              

           </table>
                      </td>

                  </tr>


                   <tr align="center">
<td>
    <br /><br />
      <table  border="1" width="100%"  style="border: 1px solid black; border-collapse: collapse;" >
          <tr>
              <td align="center">
                  <b>Description</b>
              </td>
              <td align="center">
                  <b>Amount</b>
              </td>
          </tr>
           <tr>
              <td align="left">
                 &nbsp;  Full amount for the event
              </td>
              <td align="left">
              &nbsp;  LKR. &nbsp;<asp:Label ID="IFullAmountLBL" runat="server" Text=""></asp:Label>  
              </td>
          </tr>


            <tr>
              <td align="left">
                 &nbsp; Advance Paid
              </td>
              <td align="left">
               &nbsp;  LKR.&nbsp; <asp:Label ID="IAdvancePaidLBL" runat="server" Text=""></asp:Label>  
              </td>
          </tr>

           <tr>
              <td align="left">
                 &nbsp; Balance to be paid
              </td>
              <td align="left">
               &nbsp;  LKR.&nbsp; <asp:Label ID="IBalanceLBL" runat="server" Text=""></asp:Label>  
              </td>
          </tr>

           <tr>
              <td align="center">
                 Payment Methods
              </td>
              <td align="center">
                Cheque/Cash  
              </td>
          </tr>

      </table>

    <br /><br />

</td>
                   </tr>

                  <tr>
                      <td align="left">
                          I acknowledge with thanks the advance payment of Rs.  <asp:Label ID="IadvanceLBL2" runat="server" Text=""></asp:Label> towards the above event..

                          <br /> <br /> <br />
                          Thanking you,
                          <br /> <br />
                          Yours truly,
                          <br />
                          <img src="https://i.imgur.com/eYM4xVQ.png" height="50px"   />
                          <br />
                          .....................
                          <br />
                           Mr. Kaweesha Fernando <br />Manager GRAVITY

                      </td>

                  </tr>
           

                  </table>
                            </font>
                      </asp:Panel>
                </div>

            </div>
                      </div>
                </div>
                   </div>
             <div class="container">
            <div class="row" align="center">
               <br /> <br /> 
                  <div class="col-md-12" align="center">
                 <asp:Button ID="CommonInvoiceDonwloadBTN" runat="server" Text="Download"  Height="60px" Width="130px" Font-Bold="True" CssClass="button" Font-Size="Large" OnClick="CommonInvoiceDonwloadBTN_Click" />
                    </div>
            </div>
        </div>

         </asp:Panel>

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
