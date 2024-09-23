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
    public partial class ReservationMenu : System.Web.UI.Page
    {
        private int FoodHavingType;
        private int SessionID;
        private Manager_DAO aManager_DAO;
        private string DataSource;
        private string LocalDataSource;
        private CeylonAdaptor OrderDetails;
        private int CustomerID;
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                getComputerName();
                aManager_DAO = new Manager_DAO();
                FoodHavingType = 0;

                SessionID = Convert.ToInt32(Request.QueryString["ssid"]);
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                OrderDetails.FieldI3 = 0;
                OrderDetails.FieldI3 = CustomerID;

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
        protected void DirectBooking_Click(object sender, EventArgs e)
        {

            OrderDetails.FieldI2 = 0;
            Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
            Response.Redirect("~/Customer.aspx?ssid=" + SessionID.ToString());
        }
        protected void ViaAgent_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ViaAgent.aspx?ssid=" + SessionID.ToString()); ;
        }


        protected void Practice_Click(object sender, EventArgs e)
        {
            OrderDetails.FieldI2 = 0;
            Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
            Response.Redirect("~/Practice.aspx?ssid=" + SessionID.ToString());
        }

    }
}