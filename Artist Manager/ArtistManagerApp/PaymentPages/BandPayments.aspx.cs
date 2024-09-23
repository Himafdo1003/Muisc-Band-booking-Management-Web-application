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
    public partial class BandPayments : System.Web.UI.Page
    {
        private int FoodHavingType;
        private int SessionID;
        private Manager_DAO aManager_DAO;
        private string DataSource;
        private string LocalDataSource;
        private CeylonAdaptor OrderDetails;
        private CeylonMiniAdaptor[] PlayerData;
        private CeylonMiniAdaptor[] GetDepartments;
        private CeylonMiniAdaptor[] EventsArray;
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                //GetAllPlayers

                //TextBoxshow.ReadOnly = true;
                getComputerName();
                aManager_DAO = new Manager_DAO();
                FoodHavingType = 0;
                SessionID = Convert.ToInt32(Request.QueryString["ssid"]);
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());


                EventsArray = aManager_DAO.EventType();//Get Events
                                                       // GetDepartments = aManager_DAO.GetDepartments();//Showing Departments
                if (!IsPostBack)
                {
                    //for (int i = 0; i < GetDepartments.Length; i++)
                    //{
                    //    DepaartmentDropdown.Items.Add(GetDepartments[i].FieldS1);

                    //}





                    //for (int i = 0; i < EventsArray.Length; i++)
                    //{
                    //    EventDropdown.Items.Add(EventsArray[i].FieldS1);

                    //}



                }



                //PlayerData = aManager_DAO.PlayerInfo();
                //if (!IsPostBack)
                //{
                //    for (int i = 0; i < PlayerData.Length; i++)
                //    {
                //        PlayersDropdown.Items.Add(PlayerData[i].FieldS1);

                //    }

                //}


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





        protected void BandPay_Click(object sender, EventArgs e)
        {

        }

        protected void Amend_Click(object sender, EventArgs e)
        {
            //TextBoxshow.ReadOnly = false;

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBoxshow_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ProceedBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DateTextBox.Text) || EventTimeDropdown.SelectedValue.Trim() == "..Select Time..")
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Date and Time')", true);

            }
            else
            {

                OrderDetails.FieldDate6 = Convert.ToDateTime(DateTextBox.Text);//eventDate
                OrderDetails.FieldS13 = EventTimeDropdown.SelectedValue.Trim();//eventTime
                Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);

                Response.Redirect("~/PaymentConfirm.aspx?ssid=" + SessionID.ToString());

            }
        }
    }
}