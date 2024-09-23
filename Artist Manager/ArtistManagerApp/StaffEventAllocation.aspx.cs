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
    public partial class StaffEventAllocation : System.Web.UI.Page
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
        private CeylonAdaptor[] TentativeBookingsArray;
        private CeylonAdaptor[] DupicationArraya;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                getComputerName();
                aManager_DAO = new Manager_DAO();
                FoodHavingType = 0;
                SessionID = Convert.ToInt32(Request.QueryString["ssid"]);
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());


                EventsArray = aManager_DAO.EventType();


                //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Reservation Error", "alert('Player ID-"+ OrderDetails.FieldI26 + "// Dep ID-"+ OrderDetails.FieldI27 + "')", true);

                if (!IsPostBack)
                {


                    for (int i = 0; i < EventsArray.Length; i++)
                    {
                        EventDropdown.Items.Add(EventsArray[i].FieldS1);

                    }

                    SearchStaffPaymentsByEventID();


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
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StaffPaymentAllocation.aspx?ssid=" + SessionID.ToString());
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            if (AmountTB.Text.Trim().Equals("") || AmountTB.Text=="0"|| AmountTB.Text=="0.00")
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Reservation Error", "alert('Amount Cannot be Empty or zero!!')", true);

            }
            else
            {
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                EventsArray = aManager_DAO.EventType();
                DupicationArraya = aManager_DAO.SearchPlayerPaumentScheduleDuplication(Convert.ToString(OrderDetails.FieldI26), Convert.ToString(EventsArray[EventDropdown.SelectedIndex].FieldI1));

                if (DupicationArraya == null || DupicationArraya.Length == 0)
                {

                    try
                    {

                        OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                        EventsArray = aManager_DAO.EventType();
                        CeylonAdaptor aBook = new CeylonAdaptor();

                        aBook.FieldI1 = OrderDetails.FieldI26;//PID
                        aBook.FieldI2 = OrderDetails.FieldI27;//Dep ID
                        aBook.FieldI3 = EventsArray[EventDropdown.SelectedIndex].FieldI1;//Event ID
                        aBook.FieldD1 = Convert.ToDecimal(AmountTB.Text);
                        aBook.FieldD2 = Convert.ToDecimal(AmountTB.Text);
                        aBook.FieldS1 = "NA";
                        aBook.FieldS2 = "NA";
                        aBook.FieldS3 = "NA";
                        aBook.FieldS4 = "NA";
                        aBook.FieldS5 = "NA";
                        aBook.FieldS6 = "NA";

                        aManager_DAO.AllocatePlayerPayments(aBook);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Reservation Error", "alert('Allocation Done Successfully')", true);
                        SearchStaffPaymentsByEventID();

                    }
                    catch
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Reservation Error", "alert('Error!! Please Check Details Formats')", true);

                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('This Staff has been Already Allocated for this Event Type!!!')", true);
                }


                  




            }
          
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Reservation Error", "alert('Please Select Staff From Table')", true);

            }
            else
            {
                try
                {

                    //CeylonAdaptor aStaff = new CeylonAdaptor();

                    //aStaff.FieldI1 = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
                    //aManager_DAO.DeleteStaffPlayerPaymentSchedule(aStaff);
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Deleted Successfully')", true);

                    if(AmountTB.Text==""|| AmountTB.Text == "0" || AmountTB.Text == "0.00")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Amount CAnnot be Empty or 0!!!')", true);

                    }
                    else
                    {
                        CeylonAdaptor aBook = new CeylonAdaptor();

                        aBook.FieldI1 = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);//PID                       
                        aBook.FieldD1 = Convert.ToDecimal(AmountTB.Text);
                        aBook.FieldD2 = Convert.ToDecimal(AmountTB.Text);
                       

                        aManager_DAO.UpdateStaffPaymentSchedule(aBook);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Reservation Error", "alert('Amount Updated Successfully')", true);
                        SearchStaffPaymentsByEventID();
                        GridView1.SelectedIndex = -1;
                        AmountTB.Text = "";
                    }

                }
                catch (Exception Ex)
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Payment Deleted Error')", true);

                }
            }
           
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventDropdown.SelectedValue = GridView1.SelectedRow.Cells[4].Text;
            AmountTB.Text= GridView1.SelectedRow.Cells[5].Text;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        public void SearchStaffPaymentsByEventID()
        {
            try
            {
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                TentativeBookingsArray = aManager_DAO.SearchPlayerPaumentSchedule(Convert.ToString(OrderDetails.FieldI26));

                if (TentativeBookingsArray == null || TentativeBookingsArray.Length == 0)
                {
                    GridView1.Visible = false;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('No Payment Allocations Found!!!')", true);
                }
                else
                {
                    DataTable aTentativeBook = new DataTable();

                    aTentativeBook.Columns.Add(new DataColumn("Payment ID", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Staff", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Department", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Event Type", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Amount", typeof(string)));


                    for (int i = 0; i < TentativeBookingsArray.Length; i++)
                    {
                        aTentativeBook.Rows.Add(
                          TentativeBookingsArray[i].FieldI1,
                          TentativeBookingsArray[i].FieldS1,
                          TentativeBookingsArray[i].FieldS2,
                          TentativeBookingsArray[i].FieldS3,
                          TentativeBookingsArray[i].FieldD1
                         );




                        // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('" + OrderDetails.FieldI20 + "')", true);

                    }


                    GridView1.DataSource = aTentativeBook;
                    GridView1.DataBind();
                    GridView1.Visible = true;
                }

            }
            catch (Exception Ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }

        }
    }
}