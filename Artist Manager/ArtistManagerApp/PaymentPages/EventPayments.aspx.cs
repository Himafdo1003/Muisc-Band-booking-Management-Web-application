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

namespace ArtistManagerApp.PaymentPages
{
    public partial class EventPayments : System.Web.UI.Page
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
            Response.Redirect("~/PaymentsMenu.aspx?ssid=" + SessionID.ToString());
        }



        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ProceedBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DateTextBox.Text) && EventTimeDropdown.SelectedValue.ToString() == "..Select Time..")
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Date and Select Time')", true);

            }
            else
            {

                OrderDetails.FieldDate6 = Convert.ToDateTime(DateTextBox.Text);//eventDate
                OrderDetails.FieldS13 = EventTimeDropdown.SelectedValue.Trim();//eventTime
                Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);

                Response.Redirect("~/EventPaymentConfirm.aspx?ssid=" + SessionID.ToString());

            }
        }
    }
}