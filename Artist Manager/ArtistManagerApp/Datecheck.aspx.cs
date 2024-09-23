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
    public partial class Datecheck : System.Web.UI.Page
    {
        private int FoodHavingType;
        private int SessionID;
        private Manager_DAO aManager_DAO;
        private string DataSource;
        private int CustomerID;
        private string LocalDataSource;
        private CeylonAdaptor OrderDetails;
        private CeylonMiniAdaptor[] BookingData;
        private CeylonAdaptor[] TentativeArray;
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {

                getComputerName();
                aManager_DAO = new Manager_DAO();
                FoodHavingType = 0;
                CustomerID = 0;

                SessionID = Convert.ToInt32(Request.QueryString["ssid"]);
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());

                OrderDetails.FieldI38 = 0;//Tenative booking message purpose
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
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow aGridViewRowData = GridView.SelectedRow;
            string EMorning = aGridViewRowData.Cells[2].Text;
            string EEvening = aGridViewRowData.Cells[3].Text;

            if (EMorning == "Not Available" && EEvening == "Not Available")
            {
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "Date is not Available !!!", "alert('Selected Date is already Booked...!!!');", true);

            }
            else
            {
                if (EMorning == "Available")
                {
                    OrderDetails.FielSd12 = "Morning";
                }
                else
                {
                    OrderDetails.FielSd12 = "Not Available";
                }
                if (EEvening == "Available")
                {
                    OrderDetails.FielSd32 = "Evening";
                }
                else
                {
                    OrderDetails.FielSd32 = "Not Available";
                }

                OrderDetails.FieldDate2 = Convert.ToDateTime(aGridViewRowData.Cells[1].Text);  //Selected date assigned
                Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
                Response.Redirect("~/ReservationMenu.aspx?ssid=" + SessionID.ToString());
            }

        }
        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdSRPage.aspx?ssid=" + SessionID.ToString());

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DatesCheck();
            SearchTenativeByDate();
            SearchConfirmedBookingsByDate();


        }

        public void DatesCheck()
        {
            try
            {
                /********************* Import Data from Database ****************/
                BookingData = aManager_DAO.GetDateAvailability(WaiterSearchTextBox.Text, Convert.ToDateTime(WaiterSearchTextBox.Text).AddDays(7).ToShortDateString());

                DataTable aBookingData = new DataTable();
                aBookingData.Columns.Add(new DataColumn("Date", typeof(string)));
                aBookingData.Columns.Add(new DataColumn("Morning", typeof(string)));
                aBookingData.Columns.Add(new DataColumn("Evening", typeof(string)));

                for (int i = 0; i < BookingData.Length; i++)
                {


                    string MorningS = "";
                    string EveningS = "";
                    if (BookingData[i].FieldI1 == 1)
                    {
                        MorningS = "Available";
                    }
                    else
                    {
                        MorningS = "Not Available";
                    }

                    if (BookingData[i].FieldI2 == 1)
                    {
                        EveningS = "Available";
                    }
                    else
                    {
                        EveningS = "Not Available";
                    }

                    aBookingData.Rows.Add(BookingData[i].FieldDate1.ToShortDateString(), MorningS, EveningS);
                }

                GridView.DataSource = aBookingData;
                GridView.DataBind();
                if (BookingData.Length == 0)
                {
                    GridView.Visible = false;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Booking Data Not Found !!! ", "alert('Details Not Found...!!!')", true);
                }
                else
                {
                    GridView.Visible = true;

                }

            }
            catch (Exception Ex)
            {
                GridView.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Booking Data Not Found !!! ", "alert('Details Not Found...!!!')", true);

            }
        }



        public void SearchTenativeByDate()
        {

            TentativeArray = aManager_DAO.SearchTentativeBooking(WaiterSearchTextBox.Text);
            DataTable TentativeData = new DataTable();
            TentativeData.Columns.Add(new DataColumn("Event Date", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("Event Time", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("Event Type", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("Contact Name", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("Contact Phone", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("Contact Address", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("Customer Name", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("Venue", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("Special Note", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("Couple Name", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("Status", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("EID", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("CustomerID", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("AgentID", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("PETID", typeof(string)));

            for (int i = 0; i < TentativeArray.Length; i++)
            {
                TentativeData.Rows.Add(
                  TentativeArray[i].FieldDate1, TentativeArray[i].FieldS10, TentativeArray[i].FieldS9, TentativeArray[i].FieldS1, TentativeArray[i].FieldS2, TentativeArray[i].FieldS3, TentativeArray[i].FieldS7,

                    TentativeArray[i].FieldS6, TentativeArray[i].FieldS5, TentativeArray[i].FieldS4, TentativeArray[i].FieldS8, TentativeArray[i].FieldI1, TentativeArray[i].FieldI2
                    , TentativeArray[i].FieldI3, TentativeArray[i].FieldI4);




            }



            GridView2.DataSource = TentativeData;
            GridView2.DataBind();
            GridView2.Visible = true;
            OrderAmountLabel.Visible = true;




        }


        public void SearchConfirmedBookingsByDate()
        {

            TentativeArray = aManager_DAO.SearchConfirmedBookingsByDate(WaiterSearchTextBox.Text);
            DataTable TentativeData = new DataTable();
            TentativeData.Columns.Add(new DataColumn("Event Date", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("Event Time", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("Event Type", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("Contact Name", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("Contact Phone", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("Contact Address", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("Customer Name", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("Venue", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("Special Note", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("Couple Name", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("Status", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("EID", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("CustomerID", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("AgentID", typeof(string)));
            TentativeData.Columns.Add(new DataColumn("PETID", typeof(string)));

            for (int i = 0; i < TentativeArray.Length; i++)
            {
                TentativeData.Rows.Add(
                  TentativeArray[i].FieldDate1, TentativeArray[i].FieldS10, TentativeArray[i].FieldS9, TentativeArray[i].FieldS1, TentativeArray[i].FieldS2, TentativeArray[i].FieldS3, TentativeArray[i].FieldS7,

                    TentativeArray[i].FieldS6, TentativeArray[i].FieldS5, TentativeArray[i].FieldS4, TentativeArray[i].FieldS8, TentativeArray[i].FieldI1, TentativeArray[i].FieldI2
                    , TentativeArray[i].FieldI3, TentativeArray[i].FieldI4);




            }



            GridView3.DataSource = TentativeData;
            GridView3.DataBind();
            GridView3.Visible = true;
            Label2.Visible = true;




        }

        protected void WaiterSearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[15].Visible = false;
        }
    }
}