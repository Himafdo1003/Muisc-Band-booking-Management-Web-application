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
    public partial class BookingHistory : System.Web.UI.Page
    {
       
        private int SessionID;
        private Manager_DAO aManager_DAO;
        private string DataSource;
        private string LocalDataSource;
        private CeylonAdaptor OrderDetails;
        private CeylonMiniAdaptor[] BookingData;
        private CeylonAdaptor[] TentativeBookingsArray;
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                getComputerName();
                aManager_DAO = new Manager_DAO();              
                SessionID = Convert.ToInt32(Request.QueryString["ssid"]);
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());

                GetBookingHistory();
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

        public void GetBookingHistory()
        {
            try
            {
                TentativeBookingsArray = aManager_DAO.GetBookingHistory();
                DataTable aTentativeBook = new DataTable();

                aTentativeBook.Columns.Add(new DataColumn("Event Date", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Event Time", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Event Type", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Special Note", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Contact Phone", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Customer Name", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Venue", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Couple Name", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Status", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("EID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("CustomerID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("AgentID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("PETID", typeof(string)));

                for (int i = 0; i < TentativeBookingsArray.Length; i++)
                {
                    aTentativeBook.Rows.Add(

                        Convert.ToDateTime(TentativeBookingsArray[i].FieldDate1).ToString("dd/MM/yyyy")
                     , TentativeBookingsArray[i].FieldS10, TentativeBookingsArray[i].FieldS9, TentativeBookingsArray[i].FieldS5, TentativeBookingsArray[i].FieldS2, TentativeBookingsArray[i].FieldS7,

                        TentativeBookingsArray[i].FieldS6, TentativeBookingsArray[i].FieldS4, TentativeBookingsArray[i].FieldS8, TentativeBookingsArray[i].FieldI1, TentativeBookingsArray[i].FieldI2
                        , TentativeBookingsArray[i].FieldI3, TentativeBookingsArray[i].FieldI4);


                }


                GridView1.DataSource = aTentativeBook;
                GridView1.DataBind();


            }
            catch (Exception Ex)
            {

                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }

        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BookingMenu.aspx?ssid=" + SessionID.ToString());
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;



            e.Row.Cells[0].Font.Bold = true;
            e.Row.Cells[1].Font.Bold = true;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            if (DateTB.Text.Trim().Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Please Select Date For Before Search')", true);
            }
            else
            {
                ZSearchBookingsHistoryByDate();
            }
        }

        protected void ViewAll_Click(object sender, EventArgs e)
        {
            GetBookingHistory();
        }
        public void ZSearchBookingsHistoryByDate()
        {
            try
            {
                TentativeBookingsArray = aManager_DAO.ZSearchBookingsHistoryByDate(DateTB.Text);
                DataTable aTentativeBook = new DataTable();

                aTentativeBook.Columns.Add(new DataColumn("Event Date", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Event Time", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Event Type", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Special Note", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Contact Phone", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Customer Name", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Venue", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Couple Name", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Status", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("EID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("CustomerID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("AgentID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("PETID", typeof(string)));

                for (int i = 0; i < TentativeBookingsArray.Length; i++)
                {
                    aTentativeBook.Rows.Add(

                        Convert.ToDateTime(TentativeBookingsArray[i].FieldDate1).ToString("dd/MM/yyyy")
                     , TentativeBookingsArray[i].FieldS10, TentativeBookingsArray[i].FieldS9, TentativeBookingsArray[i].FieldS5, TentativeBookingsArray[i].FieldS2, TentativeBookingsArray[i].FieldS7,

                        TentativeBookingsArray[i].FieldS6, TentativeBookingsArray[i].FieldS4, TentativeBookingsArray[i].FieldS8, TentativeBookingsArray[i].FieldI1, TentativeBookingsArray[i].FieldI2
                        , TentativeBookingsArray[i].FieldI3, TentativeBookingsArray[i].FieldI4);


                }


                GridView1.DataSource = aTentativeBook;
                GridView1.DataBind();


            }
            catch (Exception Ex)
            {

                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }

        }
    }
}