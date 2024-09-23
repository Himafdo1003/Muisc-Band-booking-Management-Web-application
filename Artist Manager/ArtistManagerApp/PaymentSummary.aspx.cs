using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ArtistManagerApp_ClassLibrary.DAOs;
using ArtistManagerApp_ClassLibrary.BusinessObjects;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data;
using System.Globalization;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace ArtistManagerApp
{
    public partial class PaymentSummary : System.Web.UI.Page
    {
        private int FoodHavingType;
        private int SessionID;
        private Manager_DAO aManager_DAO;
        private string DataSource;
        private string LocalDataSource;
        private CeylonAdaptor OrderDetails;
        private CeylonMiniAdaptor[] EventsArray;
        private CeylonMiniAdaptor aObjectForAgents;
        CeylonMiniAdaptor[] UserArray;
        private CeylonMiniAdaptor[] AgentsArray;
        private CeylonAdaptor[] TentativeBookingsArray;
        private CeylonAdaptor[] StaffPaymentArray;
        private CeylonAdaptor[] DocumentData;
        private CeylonAdaptor[] RateArray;
        private CeylonAdaptor[] advancearray;
        private CeylonAdaptor[] Lastadvancearray;
        private CeylonMiniAdaptor[] StaffArray;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                getComputerName();
                aManager_DAO = new Manager_DAO();
                FoodHavingType = 0;
                SessionID = Convert.ToInt32(Request.QueryString["ssid"]);
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());


                EventsArray = aManager_DAO.EventType();
                StaffArray = aManager_DAO.GetAllStaffForExpenseReport();

                if (!IsPostBack)
                {
                   
                    for (int i = 0; i < EventsArray.Length; i++)
                    {
                        EventTypeDropDown.Items.Add(EventsArray[i].FieldS1);

                    }

                    StaffDropdown.Items.Add("-Select-");
                    for (int i = 0; i < StaffArray.Length; i++)
                    {
                        StaffDropdown.Items.Add(StaffArray[i].FieldS1);

                    }




                }



            }
            catch (Exception Ex)
            {
                Response.Redirect("StartPage.aspx");
            }
        }

        public void getComputerName()
        {
            LocalDataSource = System.Environment.MachineName;
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdSRPage.aspx?ssid=" + SessionID.ToString());
        }

       

        protected void EventSummeryBTN_Click(object sender, EventArgs e)
        {
            EventPaymentPAnel.Visible = true;
            ExpensePanel.Visible = false;
            IncomePanel.Visible = false;
        }

        protected void SearchBTN1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(DateTB.Text) || TimeDropdown.SelectedValue.Trim() == "..Select Time..")
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Date and Time')", true);

            }
            else
            {

                //OrderDetails.FieldDate6 = Convert.ToDateTime(DateTB.Text);//eventDate
                //OrderDetails.FieldS13 = TimeDropdown.SelectedValue.Trim();//eventTime

                SearchEvents();

            }
        }
        protected void SearchBtn2_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(SearchTB.Text))
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Search Box cannot be empty !!!')", true);

            }
            else
            {

               
                SearchEventsByEventTypeandPara();

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EventGridPanel.Visible = false;
                SearchStaffPaymentsByEventIDGrouped();
                getDocumentDetails();
                SearchEventRateByEventID();
                SearchAdvance();
                SearchLastAdvanceDate();

                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());

                ActualRateLBL.Text = decimal.Parse(OrderDetails.FieldS38).ToString("#,#");
                DateofBookingConfirmLBL.Text = DateTime.ParseExact(OrderDetails.FieldS30, "yyyy/MM/dd", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                DateOfEventLBL.Text = OrderDetails.FieldS21;

                if (OrderDetails.FieldS29 == "Morning")
                {

                    TimeFromToLBL.Text = "9.00am-3.30pm";
                }

                if (OrderDetails.FieldS29 == "Evening")
                {
                    TimeFromToLBL.Text = "6.00pm-12.00am";

                }


                if (OrderDetails.FieldS22 == "NA")
                {
                    cplnamelbl.Text = "NA";
                }
                else
                {
                    cplnamelbl.Text = OrderDetails.FieldS22;
                }

                VenueLBL.Text = OrderDetails.FieldS23;

                FullContractPriceLBL.Text = decimal.Parse(OrderDetails.FieldS24).ToString("#,#");

               

                if (OrderDetails.FieldS37 == "0")
                {
                    DiscountPriceLBL.Text = "0.00";
                }
                else
                {
                    DiscountPriceLBL.Text = decimal.Parse(OrderDetails.FieldS37).ToString("#,#");
                }

                if (OrderDetails.FieldS26 == "0.00"|| OrderDetails.FieldS26==""|| OrderDetails.FieldS26=="0")
                {
                    FullPaidAmountLBL.Text = "0.00";
                   
                }
                else
                {
                    FullPaidAmountLBL.Text = decimal.Parse(OrderDetails.FieldS26).ToString("#,#");
                    
                }
               

                NetProfitLBL.Text = (decimal.Parse(FullPaidAmountLBL.Text) - decimal.Parse(TotalExpenseLBL.Text)).ToString("#,#");
                EventSummaryPannel.Visible = true;
                Print.Visible = true;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);
            }

        

        }


        public void SearchEvents()
        {
            try
            {
                TentativeBookingsArray = aManager_DAO.SearchEventsByDate(Convert.ToString(Convert.ToDateTime(DateTB.Text)), TimeDropdown.SelectedValue.Trim());

                if(TentativeBookingsArray==null|| TentativeBookingsArray.Length == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Event Found !!!')", true);
                    EventGridPanel.Visible = false;
                }
                else
                {
                    DataTable aTentativeBook = new DataTable();

                    aTentativeBook.Columns.Add(new DataColumn("Event ID", typeof(string)));
                    //aTentativeBook.Columns.Add(new DataColumn("PET ID", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Event Date", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Event Name", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Event Time", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Venue", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Contract Price", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Discount Price", typeof(string)));

                    for (int i = 0; i < TentativeBookingsArray.Length; i++)
                    {
                        aTentativeBook.Rows.Add(
                          TentativeBookingsArray[i].FieldI1,
                          //TentativeBookingsArray[i].FieldI2,
                          TentativeBookingsArray[i].FieldDate1.ToString("yyyy-MM-dd"),
                          TentativeBookingsArray[i].FieldS1,
                          TentativeBookingsArray[i].FieldS2,
                          TentativeBookingsArray[i].FieldS3,
                          TentativeBookingsArray[i].FieldI3,
                          TentativeBookingsArray[i].FieldI4
                          
                          );




                    }


                    GridView1.DataSource = aTentativeBook;
                    GridView1.DataBind();
                    EventGridPanel.Visible = true;

                }

               


            }
            catch (Exception Ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }

        }
        public void SearchEventsByEventTypeandPara()
        {
            try
            {
                TentativeBookingsArray = aManager_DAO.SearchEventsByEventTypeandPara(EventTypeDropDown.SelectedValue.Trim(), SearchTB.Text.Trim());

                if (TentativeBookingsArray == null || TentativeBookingsArray.Length == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Event Found !!!')", true);
                    EventGridPanel.Visible = false;

                }
                else
                {
                    DataTable aTentativeBook = new DataTable();

                    aTentativeBook.Columns.Add(new DataColumn("Event ID", typeof(string)));
                    //aTentativeBook.Columns.Add(new DataColumn("PET ID", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Event Date", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Event Name", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Event Time", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Venue", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Contract Price", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Discount Price", typeof(string)));

                    for (int i = 0; i < TentativeBookingsArray.Length; i++)
                    {
                        aTentativeBook.Rows.Add(
                          TentativeBookingsArray[i].FieldI1,
                          //TentativeBookingsArray[i].FieldI2,
                          TentativeBookingsArray[i].FieldDate1.ToString("yyyy-MM-dd"),
                          TentativeBookingsArray[i].FieldS1,
                          TentativeBookingsArray[i].FieldS2,
                             TentativeBookingsArray[i].FieldS3,
                          TentativeBookingsArray[i].FieldI3,
                          TentativeBookingsArray[i].FieldI4);




                    }


                    GridView1.DataSource = aTentativeBook;
                    GridView1.DataBind();
                    EventGridPanel.Visible = true;

                }




            }
            catch (Exception Ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }

        }
        public void SearchStaffPaymentsByEventIDGrouped()
        {
            try
            {
                StaffPaymentArray = aManager_DAO.SearchStaffPaymentsByEventIDGrouped(GridView1.SelectedRow.Cells[1].Text);
                if(StaffPaymentArray==null|| StaffPaymentArray.Length == 0)
                {
                    // EventSummaryPannel.Visible = false;
                    TotalExpenseLBL.Text = "0.00" ;
                    NetProfitLBL.Text = "0.00";
                }
                else
                {
                    DataTable aTentativeBook = new DataTable();

                    //aTentativeBook.Columns.Add(new DataColumn("Payment ID", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Payment Date", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Department", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Staff", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Payment Type", typeof(string)));
                    //aTentativeBook.Columns.Add(new DataColumn("Bank", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Paying Amount", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("FOC Reason", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Extra", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Status", typeof(string)));

                    decimal total = 0;
                    for (int i = 0; i < StaffPaymentArray.Length; i++)
                    {
                        aTentativeBook.Rows.Add(
                          //StaffPaymentArray[i].FieldI1,
                          StaffPaymentArray[i].FieldS8,
                          StaffPaymentArray[i].FieldS6,
                          StaffPaymentArray[i].FieldS4,
                          StaffPaymentArray[i].FieldS1,
                         // StaffPaymentArray[i].FieldS2,
                          StaffPaymentArray[i].FieldD1,
                          StaffPaymentArray[i].FieldS3,
                          StaffPaymentArray[i].FieldS7,
                          StaffPaymentArray[i].FieldS5);

                        total = total + StaffPaymentArray[i].FieldD1;
                    }
                    TotalExpenseLBL.Text = total.ToString("#,#"); 
                    //NetProfitLBL.Text = Convert.ToString(Convert.ToDecimal(FullContractPriceLBL.Text) - total);


                    GridView2.DataSource = aTentativeBook;
                    GridView2.DataBind();
                    EventSummaryPannel.Visible = true;


                }


            }
            catch (Exception Ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('SearchStaffPaymentsByEventIDGrouped Error')", true);

            }

        }
        public void getDocumentDetails()
        {
            try
            {

                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                DocumentData = aManager_DAO.GetDocumentDetails(GridView1.SelectedRow.Cells[1].Text);
                DataTable DocumetDetails = new DataTable();

                DocumetDetails.Columns.Add(new DataColumn("Trans Date", typeof(string)));
                DocumetDetails.Columns.Add(new DataColumn("Event Date", typeof(string)));
                DocumetDetails.Columns.Add(new DataColumn("Couple Name", typeof(string)));
                DocumetDetails.Columns.Add(new DataColumn("Venue", typeof(string)));
                DocumetDetails.Columns.Add(new DataColumn("Contract rate", typeof(string)));
                DocumetDetails.Columns.Add(new DataColumn("Customer Name", typeof(string)));
                DocumetDetails.Columns.Add(new DataColumn("Advance Ammount", typeof(string)));
                DocumetDetails.Columns.Add(new DataColumn("Advance pay Date", typeof(string)));
                DocumetDetails.Columns.Add(new DataColumn("Contact Number", typeof(string)));
                DocumetDetails.Columns.Add(new DataColumn("Event Time", typeof(string)));
                DocumetDetails.Columns.Add(new DataColumn("Advanced Date", typeof(string)));
                DocumetDetails.Columns.Add(new DataColumn("Discount", typeof(string)));


                for (int i = 0; i < DocumentData.Length; i++)
                {
                    DocumetDetails.Rows.Add(
                      DocumentData[i].FieldDate2, DocumentData[i].FieldDate1, DocumentData[i].FieldS4, DocumentData[i].FieldS6,
                      DocumentData[i].FieldI5, DocumentData[i].FieldS7, DocumentData[i].FieldD1, DocumentData[i].FieldDate3, DocumentData[i].FieldS2,
                      DocumentData[i].FieldS10, DocumentData[i].FieldS18

                      , DocumentData[i].FieldI8

                      );

                    OrderDetails.FieldS20 = DocumentData[i].FieldDate2.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture).Trim();// trans date
                    OrderDetails.FieldS21 = DocumentData[i].FieldDate1.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture).Trim();//event date
                    OrderDetails.FieldS22 = DocumentData[i].FieldS4.ToString().Trim();//couple name
                    OrderDetails.FieldS23 = DocumentData[i].FieldS6.ToString().Trim();//venue
                    OrderDetails.FieldS24 = DocumentData[i].FieldI5.ToString().Trim();// contract rate
                    OrderDetails.FieldS25 = DocumentData[i].FieldS7.ToString().Trim(); // customer name
                                                                                       // OrderDetails.FieldS26 = DocumentData[i].FieldD1.ToString().Trim(); //advance amount
                    OrderDetails.FieldS27 = DocumentData[i].FieldDate3.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture).Trim(); //pay date
                    OrderDetails.FieldS28 = DocumentData[i].FieldS2.ToString().Trim();//Contact number
                    OrderDetails.FieldS29 = DocumentData[i].FieldS10.ToString().Trim();
                    OrderDetails.FieldS37 = DocumentData[i].FieldI8.ToString().Trim();//Discount amount

                    //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('"+ OrderDetails.FieldS37 + "')", true);

                   

                }

                Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
            }
            catch (Exception Ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('getDocumentDetails Error')", true);

            }


        }
        public void SearchEventRateByEventID()
        {

            try
            {
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                RateArray = aManager_DAO.SearchEventRateByEventID(GridView1.SelectedRow.Cells[1].Text);

                if (RateArray == null || RateArray.Length == 0)
                {

                }
                else
                {

                    DataTable DocumetDetails = new DataTable();
                    DocumetDetails.Columns.Add(new DataColumn("ID", typeof(string)));
                    DocumetDetails.Columns.Add(new DataColumn("Contract Rate", typeof(string)));

                    for (int i = 0; i < RateArray.Length; i++)
                    {
                        DocumetDetails.Rows.Add(
                          RateArray[i].FieldI1, RateArray[i].FieldS1);

                        OrderDetails.FieldS38 = RateArray[i].FieldS1;//Discount amount
                                                                     //  ActualRateLBL.Text = RateArray[i].FieldS1;

                    }

                    Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
                }

            }
            catch (Exception Ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('SearchEventRateByEventID Error')", true);

            }


        }
        public void SearchAdvance()
        {
            try
            {
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                advancearray = aManager_DAO.SearchAdvance(GridView1.SelectedRow.Cells[1].Text);


                DataTable aTentativeBook = new DataTable();

                aTentativeBook.Columns.Add(new DataColumn("Pay ID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Advance", typeof(string)));

                int sum = 0;

                for (int i = 0; i < advancearray.Length; i++)
                {
                    aTentativeBook.Rows.Add(
                      advancearray[i].FieldI1, advancearray[i].FieldD1);

                    // OrderDetails.FieldI25 = TentativeBookingsArray[i].FieldI1;


                    sum += Convert.ToInt32(advancearray[i].FieldD1);




                }
                OrderDetails.FieldS26 = Convert.ToString(sum); //amount
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('" + OrderDetails.FieldS26 + "')", true);

                Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);

            }
            catch (Exception Ex)
            {

                 ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Search Advance Error')", true);

            }


        }
        public void SearchLastAdvanceDate()
        {
            try
            {
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                Lastadvancearray = aManager_DAO.SearchLastAdvanceDate(GridView1.SelectedRow.Cells[1].Text);
                DataTable aTentativeBook = new DataTable();


                aTentativeBook.Columns.Add(new DataColumn("Advance Date", typeof(string)));



                for (int i = 0; i < Lastadvancearray.Length; i++)
                {
                    aTentativeBook.Rows.Add(
                      Lastadvancearray[i].FieldS1);

                    OrderDetails.FieldS30 = Lastadvancearray[i].FieldS1;
                    Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);

                }

            }
            catch (Exception Ex)
            {

                 ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Search Last Advance Date Error')", true);

            }


        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }
        protected void Print_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Gravity Payment Summary.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            EventSummaryPannel.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 20, 20, 20, 20);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }

        protected void ExpenseBtn_Click(object sender, EventArgs e)
        {
            EventPaymentPAnel.Visible = false;
            ExpensePanel.Visible = true;
            IncomePanel.Visible = false;
        }

        protected void ExpeseByDateBTN_Click(object sender, EventArgs e)
        {


            if (StaffDropdown.SelectedValue == "-Select-")
            {
                if (string.IsNullOrWhiteSpace(FromDateTB.Text) || string.IsNullOrWhiteSpace(ToDateTB.Text))
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Dates')", true);
                    DownloadBtn2.Visible = false;

                }
                else
                {

                    SearchExpensesByDateRange();
                    DateRangeLBL.Text = "From- " + FromDateTB.Text + " -To -" + ToDateTB.Text;
                    ExpenseReultPanel.Visible = true;
                    DownloadBtn2.Visible = true;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(FromDateTB.Text) || string.IsNullOrWhiteSpace(ToDateTB.Text))
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Dates')", true);
                    DownloadBtn2.Visible = false;
                }
                else
                {


                    SearchExpensesByDateRangeByStaff();
                    DateRangeLBL.Text = "From- " + FromDateTB.Text + " -To -" + ToDateTB.Text;
                    ExpenseReultPanel.Visible = true;
                    DownloadBtn2.Visible = true;
                }

            }
               
        }

        public void SearchExpensesByDateRange()
        {
            try
            {
                TentativeBookingsArray = aManager_DAO.SearchExpensesByDateRange(FromDateTB.Text, ToDateTB.Text);

                if (TentativeBookingsArray == null || TentativeBookingsArray.Length == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Expenses Found !!!')", true);
                    GridView3.Visible = false;
                    TotalExpenseFromReportLBL.Text = "0.00";
                }
                else
                {
                    DataTable aTentativeBook = new DataTable();
                   

                  
                    aTentativeBook.Columns.Add(new DataColumn("Staff", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Event", typeof(string)));                
                    aTentativeBook.Columns.Add(new DataColumn("Amount", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Payment Details", typeof(string)));

                    decimal total = 0;
                    for (int i = 0; i < TentativeBookingsArray.Length; i++)
                    {
                        aTentativeBook.Rows.Add(
                          TentativeBookingsArray[i].FieldS1 +"-"+ TentativeBookingsArray[i].FieldS2,
                         TentativeBookingsArray[i].FieldS4 + "-"+TentativeBookingsArray[i].FieldDate1.ToString("yyyy/MM/dd")+"-"+ TentativeBookingsArray[i].FieldS3,

                          TentativeBookingsArray[i].FieldD1,
                          TentativeBookingsArray[i].FieldS5 +"-"+ TentativeBookingsArray[i].FieldS6+"-"+ TentativeBookingsArray[i].FieldS7
                             );

                        total = total + TentativeBookingsArray[i].FieldD1;


                    }

                    TotalExpenseFromReportLBL.Text = Convert.ToString(total);
                    GridView3.DataSource = aTentativeBook;
                    GridView3.DataBind();
                    GridView3.Visible = true;

                }




            }
            catch (Exception Ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }

        }
        public void SearchExpensesByDateRangeByStaff()
        {
            try
            {
                StaffArray = aManager_DAO.GetAllStaffForExpenseReport();
                TentativeBookingsArray = aManager_DAO.SearchExpensesByDateRangeByStaff(FromDateTB.Text, ToDateTB.Text, Convert.ToString(StaffArray[StaffDropdown.SelectedIndex-1].FieldI1));

                if (TentativeBookingsArray == null || TentativeBookingsArray.Length == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Expenses Found !!!')", true);
                    GridView3.Visible = false;
                    TotalExpenseFromReportLBL.Text = "0.00";
                }
                else
                {
                    DataTable aTentativeBook = new DataTable();



                    aTentativeBook.Columns.Add(new DataColumn("Staff", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Event", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Amount", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Payment Details", typeof(string)));

                    decimal total = 0;
                    for (int i = 0; i < TentativeBookingsArray.Length; i++)
                    {
                        aTentativeBook.Rows.Add(
                          TentativeBookingsArray[i].FieldS1 + "-" + TentativeBookingsArray[i].FieldS2,
                         TentativeBookingsArray[i].FieldS4 + "-" + TentativeBookingsArray[i].FieldDate1.ToString("yyyy/MM/dd") + "-" + TentativeBookingsArray[i].FieldS3,

                          TentativeBookingsArray[i].FieldD1,
                          TentativeBookingsArray[i].FieldS5 + "-" + TentativeBookingsArray[i].FieldS6 + "-" + TentativeBookingsArray[i].FieldS7
                             );

                        total = total + TentativeBookingsArray[i].FieldD1;


                    }

                    TotalExpenseFromReportLBL.Text = Convert.ToString(total);
                    GridView3.DataSource = aTentativeBook;
                    GridView3.DataBind();
                    GridView3.Visible = true;

                }




            }
            catch (Exception Ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }

        }

        protected void DownloadBtn2_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Gravity Expense Report.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            ExpenseReultPanel.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 20, 20, 20, 20);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }

        protected void IncomeReportBtn_Click(object sender, EventArgs e)
        {
            EventPaymentPAnel.Visible = false;
            ExpensePanel.Visible = false;
            IncomePanel.Visible = true;

        }

        protected void IncomeSearchBtn_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(IncomeFromDateTB.Text) || string.IsNullOrWhiteSpace(IncomeToDateTB.Text))
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Dates')", true);
                //DownloadBtn2.Visible = false;

            }
            else
            {

                SearchEventIncomeByDateRange();
                SearchExpensesByDateRangeForIncome();
                IncomeDateRangeLBL.Text = "From- " + IncomeFromDateTB.Text + " -To -" + IncomeToDateTB.Text;
                NetIncomeLBL.Text = Convert.ToString(Convert.ToDecimal(TotalIncomeLBL.Text) - Convert.ToDecimal(TotalExpenseAmountLBL.Text));
                IncomeStatementPanel.Visible = true;
                IncomeReportDownloadBtn.Visible = true;
               
               
            }




        }


        public void SearchEventIncomeByDateRange()//////////////////////////////////
        {
            try
            {
                TentativeBookingsArray = aManager_DAO.SearchEventIncomeByDateRange1(IncomeFromDateTB.Text, IncomeToDateTB.Text);

                if (TentativeBookingsArray == null || TentativeBookingsArray.Length == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Income Found !!!')", true);
                    GridView4.Visible = false;
                    TotalIncomeLBL.Text = "0.00";
                }
                else
                {
                    DataTable aTentativeBook = new DataTable();



                   
                    aTentativeBook.Columns.Add(new DataColumn("Event ID", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Event Details", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Event Amount", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Event Date", typeof(string)));

                    decimal total = 0;
                    for (int i = 0; i < TentativeBookingsArray.Length; i++)
                    {
                        aTentativeBook.Rows.Add(
                             TentativeBookingsArray[i].FieldI1,
                          TentativeBookingsArray[i].FieldS1,
                           TentativeBookingsArray[i].FieldD1,
                            TentativeBookingsArray[i].FieldS2
                             );

                        total = total + TentativeBookingsArray[i].FieldD1;


                    }

                    TotalIncomeLBL.Text = Convert.ToString(total);
                    GridView4.DataSource = aTentativeBook;
                    GridView4.DataBind();
                    GridView4.Visible = true;

                }




            }
            catch (Exception Ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }

        }
        public void SearchExpensesByDateRangeForIncome()
        {
            try
            {
                TentativeBookingsArray = aManager_DAO.SearchExpensesByDateRange(IncomeFromDateTB.Text, IncomeToDateTB.Text);

                if (TentativeBookingsArray == null || TentativeBookingsArray.Length == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Expenses Found !!!')", true);
                    GridView5.Visible = false;
                    TotalExpenseAmountLBL.Text = "0.00";
                }
                else
                {
                    DataTable aTentativeBook = new DataTable();



                    aTentativeBook.Columns.Add(new DataColumn("Staff", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Event", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Amount", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Payment Details", typeof(string)));

                    decimal total = 0;
                    for (int i = 0; i < TentativeBookingsArray.Length; i++)
                    {
                        aTentativeBook.Rows.Add(
                          TentativeBookingsArray[i].FieldS1 + "-" + TentativeBookingsArray[i].FieldS2,
                         TentativeBookingsArray[i].FieldS4 + "-" + TentativeBookingsArray[i].FieldDate1.ToString("yyyy/MM/dd") + "-" + TentativeBookingsArray[i].FieldS3,

                          TentativeBookingsArray[i].FieldD1,
                          TentativeBookingsArray[i].FieldS5 + "-" + TentativeBookingsArray[i].FieldS6 + "-" + TentativeBookingsArray[i].FieldS7
                             );

                        total = total + TentativeBookingsArray[i].FieldD1;


                    }

                    TotalExpenseAmountLBL.Text = Convert.ToString(total);
                    GridView5.DataSource = aTentativeBook;
                    GridView5.DataBind();
                    GridView5.Visible = true;

                }




            }
            catch (Exception Ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }

        }

        protected void IncomeReportDownloadBtn_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Gravity Income/Expense Report.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            IncomeStatementPanel.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 20, 20, 20, 20);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }
    }
}