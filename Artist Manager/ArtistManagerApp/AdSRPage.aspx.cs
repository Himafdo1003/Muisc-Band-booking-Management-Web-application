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
using System.Globalization;

namespace ArtistManagerApp
{
    public partial class AdSRPage : System.Web.UI.Page
    {
        private int FoodHavingType;
        private int SessionID;
        private Manager_DAO aManager_DAO;
        private string DataSource;
        private string LocalDataSource;
        private CeylonAdaptor OrderDetails;
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {




                getComputerName();
                aManager_DAO = new Manager_DAO();
                FoodHavingType = 0;
                SessionID = Convert.ToInt32(Request.QueryString["ssid"]);
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                OrderDetails.FieldI38 = 0;//Tenative booking message purpose

                //string iDate = "05/05/2005";
                //DateTime oDate = Convert.ToDateTime(iDate);
              
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Advance Notification", "alert('"+ oDate.Day + " " + oDate.Month + "  " + oDate.Year + "')", true);


                if (OrderDetails.FieldI10 == 1) // band member
                {
                    A2.Visible = false;
                    A3.Visible = false;
                    A4.Visible = false;
                    PaymentSummaryBTN.Visible = false;
                    StaffPayBtn.Visible = false;
                    CRequestBtn.Visible = false;
                }
                else if (OrderDetails.FieldI10 == 2)//Manager
                {
                    PaymentSummaryBTN.Visible = false;
                    A4.Visible = true;
                    StaffPayBtn.Visible = false;
                }
                else if (OrderDetails.FieldI10 == 3)//admin
                {

                }
                else
                {

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
        }//End of getComputerName() method 
        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserEnter.aspx?ssid=" + SessionID.ToString());
        }

        protected void Date_Click(object sender, EventArgs e)
        {
            //FoodHavingType = 1;
            //OrderDetails.FieldI31 = FoodHavingType;
            //Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
            //Response.Redirect("StaffAllocatePage.aspx?ssid=" + SessionID.ToString());
            Response.Redirect("~/Datecheck.aspx?ssid=" + SessionID.ToString());
        }

        protected void Advane_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Advance.aspx?ssid=" + SessionID.ToString());
        }

        protected void Booking_Click(object sender, EventArgs e)
        {
            //Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
            //Response.Redirect("NewOder.aspx?ssid=" + SessionID.ToString());
            Response.Redirect("~/BookingMenu.aspx?ssid=" + SessionID.ToString());
        }

        protected void Payments_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PaymentsMenu.aspx?ssid=" + SessionID.ToString());
        }

        protected void Calendar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Calendar.aspx?ssid=" + SessionID.ToString());
        }

        protected void PaymentSummaryBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PaymentSummary.aspx?ssid=" + SessionID.ToString());
        }

        protected void StaffPayBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StaffPaymentAllocation.aspx?ssid=" + SessionID.ToString());
        }
        protected void CRequestBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CRequests.aspx?ssid=" + SessionID.ToString());
        }

        

    }


}