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
    public partial class CRequests : System.Web.UI.Page
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

                GetAllCRequests();
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




        public void GetAllCRequests()
        {
            try
            {
                TentativeBookingsArray = aManager_DAO.GetAllCRequests();
                DataTable aTentativeBook = new DataTable();

                aTentativeBook.Columns.Add(new DataColumn("Req ID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Name", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Phone", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Email", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Message", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Date", typeof(string)));
                

                for (int i = 0; i < TentativeBookingsArray.Length; i++)
                {
                    aTentativeBook.Rows.Add(

                      TentativeBookingsArray[i].FieldI1,
                      TentativeBookingsArray[i].FieldS1,
                      TentativeBookingsArray[i].FieldS2,
                      TentativeBookingsArray[i].FieldS3,
                      TentativeBookingsArray[i].FieldS4,
                      TentativeBookingsArray[i].FieldDate1);


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
        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdSRPage.aspx?ssid=" + SessionID.ToString());
        }
        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            if (DateTB.Text.Trim().Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Please Select Date For Before Search')", true);
            }
            else
            {
                ZSearchCRequestsByDate();
            }
        }

        protected void ViewAll_Click(object sender, EventArgs e)
        {
            GetAllCRequests();
        }
        public void ZSearchCRequestsByDate()
        {
            try
            {
                TentativeBookingsArray = aManager_DAO.ZSearchCRequestsByDate(DateTB.Text);
                DataTable aTentativeBook = new DataTable();

                aTentativeBook.Columns.Add(new DataColumn("Req ID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Name", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Phone", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Email", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Message", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Date", typeof(string)));

                for (int i = 0; i < TentativeBookingsArray.Length; i++)
                {
                    aTentativeBook.Rows.Add(

                       TentativeBookingsArray[i].FieldI1,
                      TentativeBookingsArray[i].FieldS1,
                      TentativeBookingsArray[i].FieldS2,
                      TentativeBookingsArray[i].FieldS3,
                      TentativeBookingsArray[i].FieldS4,
                      TentativeBookingsArray[i].FieldDate1);


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