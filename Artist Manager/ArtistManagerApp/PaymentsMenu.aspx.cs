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

namespace ArtistManagerApp
{
    public partial class PaymentsMenu : System.Web.UI.Page
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

                OrderDetails.FieldI38 = 0;//Tenative booking message purposes

               // OrderDetails.FieldI11 = 0;//  payment purposes

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
        protected void StaffPay_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PaymentPages/BandPayments.aspx?ssid=" + SessionID.ToString());

        }
        protected void EventPay_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PaymentPages/EventPayments.aspx?ssid=" + SessionID.ToString());
        }
    }
}