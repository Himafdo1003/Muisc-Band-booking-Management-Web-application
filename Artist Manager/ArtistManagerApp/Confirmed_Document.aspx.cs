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
using iTextSharp.text;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Globalization;
using System.Threading;

namespace ArtistManagerApp
{
    public partial class Confirmed_Document : System.Web.UI.Page
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
        private CeylonAdaptor[] DocumentData;
        private CeylonAdaptor[] RateArray;
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {

                getComputerName();
                aManager_DAO = new Manager_DAO();
                SessionID = Convert.ToInt32(Request.QueryString["ssid"]);
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());

                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('" + OrderDetails.FieldS30 + "')", true);
                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Advance Notification", "alert('" + DateTime.ParseExact(OrderDetails.FieldS21, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy", CultureInfo.InvariantCulture) + " ')", true);             
                if (Convert.ToInt32(OrderDetails.FieldS26) < 100000)
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Advance Notification", "alert('This Event has only Rs." + OrderDetails.FieldS26 + " as Advance')", true);
                }
                ActualRateLBL.Text = decimal.Parse(OrderDetails.FieldS38).ToString("#,#");
                DateofBookingConfirmLBL.Text = DateTime.ParseExact(OrderDetails.FieldS30, "yyyy/MM/dd", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                DateOfEventLBL.Text = OrderDetails.FieldS21;
                IEventDateLBL.Text = OrderDetails.FieldS21;

                EventyearLBL.Text = DateTime.ParseExact(OrderDetails.FieldS21, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy", CultureInfo.InvariantCulture);

                if (OrderDetails.FieldS29 == "Morning")
                {

                    TimeFromToLBL.Text = "9.00am-3.30pm";
                    IEventTimeLBL.Text = "9.00am-3.30pm";
                }

                if (OrderDetails.FieldS29 == "Evening")
                {
                    TimeFromToLBL.Text = "6.00pm-12.00am";
                    IEventTimeLBL.Text = "6.00pm-12.00am";
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
                IEventVenueLBL.Text = OrderDetails.FieldS23;
                EventPlacelbl.Text = OrderDetails.FieldS23;
                //TimeFromToLBL.Text = OrderDetails.FieldS29;
                // FullContractPriceLBL.Text = OrderDetails.FieldS24;
                FullContractPriceLBL.Text = decimal.Parse(OrderDetails.FieldS24).ToString("#,#");
                IFullAmountLBL.Text = decimal.Parse(OrderDetails.FieldS24).ToString("#,#");
                CustomerNameLBL.Text = OrderDetails.FieldS25;
                NICNOlbl.Text = OrderDetails.FieldS4;

                if (OrderDetails.FieldS26 == "0.00")
                {
                    AdvanceAmountLBL.Text = "0";
                    AdvanceAmount2LBL.Text = "0";

                    IAdvancePaidLBL.Text = "0";

                }
                else
                {
                    AdvanceAmountLBL.Text = decimal.Parse(OrderDetails.FieldS26).ToString("#,#");
                    AdvanceAmount2LBL.Text = decimal.Parse(OrderDetails.FieldS26).ToString("#,#");
                    IAdvancePaidLBL.Text = decimal.Parse(OrderDetails.FieldS26).ToString("#,#");
                    IadvanceLBL2.Text = decimal.Parse(OrderDetails.FieldS26).ToString("#,#");

                }

                DiscountPriceLBL.Text = decimal.Parse(OrderDetails.FieldS37).ToString("#,#");
                AdvancePaymentDateLBL.Text = OrderDetails.FieldS30;
                eventdatelbl.Text = OrderDetails.FieldS21;
                AgreementDateLBL.Text = DateTime.Now.ToString("dd/MM/yyyy");
                IDateLBL.Text = DateTime.Now.ToString("dd/MM/yyyy");

                CustomerNameLBL2.Text = OrderDetails.FieldS25;
                CustomerNumberLBL.Text = OrderDetails.FieldS28;
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                if (Convert.ToDecimal(OrderDetails.FieldS24) - Convert.ToDecimal(OrderDetails.FieldS26) == 0 || Convert.ToDecimal(OrderDetails.FieldS24) - Convert.ToDecimal(OrderDetails.FieldS26) == null)
                {
                    BalanceAmountLBL.Text = "0.00";
                    IBalanceLBL.Text = "0.00";
                }
                else
                {
                    BalanceAmountLBL.Text = decimal.Parse(Convert.ToString(Convert.ToDecimal(OrderDetails.FieldS24) - Convert.ToDecimal(OrderDetails.FieldS26))).ToString("#,#");
                    IBalanceLBL.Text = decimal.Parse(Convert.ToString(Convert.ToDecimal(OrderDetails.FieldS24) - Convert.ToDecimal(OrderDetails.FieldS26))).ToString("#,#");

                }

                DateTime dt = DateTime.Now;

                // Get year, month, and day

                int year = dt.Year;
                int month = dt.Month;

                DateLBL.Text = Convert.ToString(dt.Day);
                String dayName = dt.DayOfWeek.ToString();

                YearLBL.Text = "" + year.ToString();

                CultureInfo ci = Thread.CurrentThread.CurrentCulture;
                MonthLBL.Text = ci.DateTimeFormat.GetMonthName(DateTime.Now.Month);


                if (DateLBL.Text.EndsWith("11"))
                {
                    SuffixLBL.Text = "th";

                }
                if (DateLBL.Text.EndsWith("12"))
                {
                    SuffixLBL.Text = "th";

                }
                if (DateLBL.Text.EndsWith("13"))
                {
                    SuffixLBL.Text = "th";

                }
                if (DateLBL.Text.EndsWith("1"))
                {
                    SuffixLBL.Text = "st";

                }
                if (DateLBL.Text.EndsWith("2"))
                {
                    SuffixLBL.Text = "nd";

                }
                if (DateLBL.Text.EndsWith("3"))
                {
                    SuffixLBL.Text = "rd";

                }
                if (DateLBL.Text.EndsWith("13"))
                {
                    SuffixLBL.Text = "th";

                }
                if (DateLBL.Text.EndsWith("4"))
                {
                    SuffixLBL.Text = "th";

                }
                if (DateLBL.Text.EndsWith("5"))
                {
                    SuffixLBL.Text = "th";

                }
                if (DateLBL.Text.EndsWith("6"))
                {
                    SuffixLBL.Text = "th";

                }
                if (DateLBL.Text.EndsWith("7"))
                {
                    SuffixLBL.Text = "th";

                }
                if (DateLBL.Text.EndsWith("8"))
                {
                    SuffixLBL.Text = "th";

                }
                if (DateLBL.Text.EndsWith("9"))
                {
                    SuffixLBL.Text = "th";

                }
                if (DateLBL.Text.EndsWith("0"))
                {
                    SuffixLBL.Text = "th";

                }


                IEventNameLBL.Text= OrderDetails.FieldS41;



            }
            catch (Exception EX)
            {
                // Response.Redirect("~/StartPage.aspx");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "alert('Invoice Generation Error')", true);
            }
        }



      


        public void getComputerName()
        {
            LocalDataSource = System.Environment.MachineName;
        }//End of getComputerName() method    
        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdSRPage.aspx?ssid=" + SessionID.ToString());
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void TESTBTN_Click(object sender, EventArgs e)
        {
            // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('"  + OrderDetails.FieldS33 + OrderDetails.FieldS34 + OrderDetails.FieldS35 + OrderDetails.FieldS36 + "')", true);



        }




        protected void Print_Click(object sender, EventArgs e)
        {
            OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());




            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Gravity_Agreement.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            Panel1.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 20, 20, 20,20);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();






           


        }



        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected string GetUrl(string imagepath)
        {
            string[] splits = Request.Url.AbsoluteUri.Split('/');
            if (splits.Length >= 2)
            {
                string url = splits[0] + "//";
                for (int i = 2; i < splits.Length - 1; i++)
                {
                    url += splits[i];
                    url += "/";
                }
                return url + imagepath;
            }
            return imagepath;
        }

        protected void CommonInvoiceDonwloadBTN_Click(object sender, EventArgs e)
        {
            OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());




            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Gravity_Invoice.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            InvoicePanel.RenderControl(hw);
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