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

namespace ArtistManagerApp.BookingPages
{
    public partial class CancelledBookings : System.Web.UI.Page
    {
        private int FoodHavingType;
        private int SessionID;
        private Manager_DAO aManager_DAO;
        private string DataSource;
        private string LocalDataSource;
        private CeylonAdaptor OrderDetails;
        private CeylonAdaptor[] CancelledBookingArray;
        private CeylonMiniAdaptor[] BookingData;
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                getComputerName();
                aManager_DAO = new Manager_DAO();
                FoodHavingType = 0;
                SessionID = Convert.ToInt32(Request.QueryString["ssid"]);

                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());

                GetCancelledBookings();


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
            Response.Redirect("~/BookingMenu.aspx?ssid=" + SessionID.ToString());

        }

        public void GetCancelledBookings()
        {


            try
            {
                CancelledBookingArray = aManager_DAO.GetCancelledBookings();
                DataTable aTentativeBook = new DataTable();

                aTentativeBook.Columns.Add(new DataColumn("Event Date", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Event Time", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Event Type", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Contact Name", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Contact Phone", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Contact Address", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Customer Name", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Venue", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Special Note", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Couple Name", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Status", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("EID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("CustomerID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("AgentID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("PETID", typeof(string)));


                for (int i = 0; i < CancelledBookingArray.Length; i++)
                {
                    aTentativeBook.Rows.Add(
                      CancelledBookingArray[i].FieldDate1, CancelledBookingArray[i].FieldS10, CancelledBookingArray[i].FieldS9, CancelledBookingArray[i].FieldS1, CancelledBookingArray[i].FieldS2, CancelledBookingArray[i].FieldS3, CancelledBookingArray[i].FieldS7,

                        CancelledBookingArray[i].FieldS6, CancelledBookingArray[i].FieldS5, CancelledBookingArray[i].FieldS4, CancelledBookingArray[i].FieldS8, CancelledBookingArray[i].FieldI1, CancelledBookingArray[i].FieldI2
                        , CancelledBookingArray[i].FieldI3, CancelledBookingArray[i].FieldI4);




                }


                GridView1.DataSource = aTentativeBook;
                GridView1.DataBind();


            }
            catch (Exception Ex)
            {

                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }

        }



        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;

            e.Row.Cells[0].Font.Bold = true;
            e.Row.Cells[1].Font.Bold = true;
        }


        public void ZSearchCancelledBookingsByDate()
        {


            try
            {
                CancelledBookingArray = aManager_DAO.ZSearchCancelledBookingsByDate(DateTB.Text);
                DataTable aTentativeBook = new DataTable();

                aTentativeBook.Columns.Add(new DataColumn("Event Date", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Event Time", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Event Type", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Contact Name", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Contact Phone", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Contact Address", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Customer Name", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Venue", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Special Note", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Couple Name", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Status", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("EID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("CustomerID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("AgentID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("PETID", typeof(string)));


                for (int i = 0; i < CancelledBookingArray.Length; i++)
                {
                    aTentativeBook.Rows.Add(
                      CancelledBookingArray[i].FieldDate1, CancelledBookingArray[i].FieldS10, CancelledBookingArray[i].FieldS9, CancelledBookingArray[i].FieldS1, CancelledBookingArray[i].FieldS2, CancelledBookingArray[i].FieldS3, CancelledBookingArray[i].FieldS7,

                        CancelledBookingArray[i].FieldS6, CancelledBookingArray[i].FieldS5, CancelledBookingArray[i].FieldS4, CancelledBookingArray[i].FieldS8, CancelledBookingArray[i].FieldI1, CancelledBookingArray[i].FieldI2
                        , CancelledBookingArray[i].FieldI3, CancelledBookingArray[i].FieldI4);




                }


                GridView1.DataSource = aTentativeBook;
                GridView1.DataBind();


            }
            catch (Exception Ex)
            {

                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }

        }
        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            if (DateTB.Text.Trim().Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Please Select Date For Before Search')", true);
            }
            else
            {
                ZSearchCancelledBookingsByDate();
            }
        }

        protected void ViewAll_Click(object sender, EventArgs e)
        {
            GetCancelledBookings();

        }
    }
}