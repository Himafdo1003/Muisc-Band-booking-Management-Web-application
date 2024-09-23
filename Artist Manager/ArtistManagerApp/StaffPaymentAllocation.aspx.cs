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
    public partial class StaffPaymentAllocation : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                getComputerName();
                aManager_DAO = new Manager_DAO();
                FoodHavingType = 0;
                SessionID = Convert.ToInt32(Request.QueryString["ssid"]);
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());


                EventsArray = aManager_DAO.GetAllPaymentDepartmentsTypes();

               

                if (!IsPostBack)
                {
                    

                    for (int i = 0; i < EventsArray.Length; i++)
                    {
                        DepartmentDropdown.Items.Add(EventsArray[i].FieldS1);

                    }

                   


                }

                GetAllStaffMembers();

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



        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            if (StaffNameTB.Text.Trim().Equals("") ||
           AddressTB.Text.Trim().Equals("") || PhoneTB.Text.Trim().Equals("") || EmailTB.Text.Trim().Equals("") || DOBTB.Text.Trim().Equals("") )
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Reservation Error", "alert('Please fill all fields to Registration Process')", true);

            }
            else
            {
                try
                {
                    CeylonAdaptor aBook = new CeylonAdaptor();

                    EventsArray = aManager_DAO.GetAllPaymentDepartmentsTypes();


                    aBook.FieldS1 = StaffNameTB.Text;
                    aBook.FieldS2 = AddressTB.Text;
                    aBook.FieldS3 = PhoneTB.Text;
                    aBook.FieldS4 = EmailTB.Text;
                    aBook.FieldDate1 = Convert.ToDateTime(DOBTB.Text);
                    aBook.FieldDate2 = DateTime.Now;
                    aBook.FieldS5 = Convert.ToString(EventsArray[DepartmentDropdown.SelectedIndex].FieldI1);
                    aBook.FieldS6 = "NA";
                    aBook.FieldS7 = "NA";
                    aBook.FieldS8 = "NA";
                    aBook.FieldS9 = "NA";

                    aManager_DAO.RegisterPlayer(aBook);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Reservation Error", "alert('Registration Done Successfully')", true);
                    GetAllStaffMembers();

                }
                catch
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Reservation Error", "alert('Error!! Please Check Details Formats')", true);

                }




            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                DepartmentDropdown.SelectedValue = Convert.ToString(GridView1.SelectedRow.Cells[2].Text);
                StaffNameTB.Text = Convert.ToString(GridView1.SelectedRow.Cells[3].Text);
                AddressTB.Text = Convert.ToString(GridView1.SelectedRow.Cells[4].Text);
                PhoneTB.Text = Convert.ToString(GridView1.SelectedRow.Cells[5].Text);
                EmailTB.Text = Convert.ToString(GridView1.SelectedRow.Cells[6].Text);
                DOBTB.Text = (Convert.ToDateTime(GridView1.SelectedRow.Cells[7].Text)).ToString("yyyy-MM-dd");
                AddressTB.Text = Convert.ToString(GridView1.SelectedRow.Cells[4].Text);
            }
            catch (Exception EX)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Reservation Error", "alert('Selection Error')", true);

            }



        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        public void GetAllStaffMembers()
        {
            try
            {
              
                TentativeBookingsArray = aManager_DAO.GetAllStaffMembers();
                if (TentativeBookingsArray == null || TentativeBookingsArray.Length == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Reservation Error", "alert('No Results!!!')", true);
                    GridView1.Visible = false;
                }
                else
                {
                    DataTable aTentativeBook = new DataTable();

                    aTentativeBook.Columns.Add(new DataColumn("Staff ID", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Department", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Name", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Address", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Phone", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Email", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("DOB", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Reg Date", typeof(string)));



                    for (int i = 0; i < TentativeBookingsArray.Length; i++)
                    {
                        aTentativeBook.Rows.Add(
                          TentativeBookingsArray[i].FieldI1,
                          TentativeBookingsArray[i].FieldS1,
                          TentativeBookingsArray[i].FieldS2,
                          TentativeBookingsArray[i].FieldS3,
                          TentativeBookingsArray[i].FieldS4,
                          TentativeBookingsArray[i].FieldS5,
                          TentativeBookingsArray[i].FieldDate1.ToString("yyyy-MM-dd"),
                           TentativeBookingsArray[i].FieldDate2

                            );

                    }


                    GridView1.DataSource = aTentativeBook;
                    GridView1.DataBind();
                    GridView1.Visible = true;
                }

            }
            catch (Exception Ex)
            {

                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }

        }

        protected void UpdateBTN_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Reservation Error", "alert('Please Select Staff From Table')", true);

            }
            else
            {
                if (StaffNameTB.Text.Trim().Equals("") ||
                         AddressTB.Text.Trim().Equals("") || PhoneTB.Text.Trim().Equals("") || EmailTB.Text.Trim().Equals("") || DOBTB.Text.Trim().Equals(""))
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Reservation Error", "alert('Please fill all fields to Registration Process')", true);

                }
                else
                {
                    try
                    {
                        CeylonAdaptor aBook = new CeylonAdaptor();

                        EventsArray = aManager_DAO.GetAllPaymentDepartmentsTypes();

                        aBook.FieldI1 = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
                        aBook.FieldS1 = StaffNameTB.Text;
                        aBook.FieldS2 = AddressTB.Text;
                        aBook.FieldS3 = PhoneTB.Text;
                        aBook.FieldS4 = EmailTB.Text;
                        aBook.FieldDate1 = Convert.ToDateTime(DOBTB.Text);                    
                        aBook.FieldS5 = Convert.ToString(EventsArray[DepartmentDropdown.SelectedIndex].FieldI1);
                      

                        aManager_DAO.UpdateABandPlayerStaff(aBook);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Reservation Error", "alert('Updated Successfully')", true);
                        GetAllStaffMembers();
                        GridView1.SelectedIndex = -1;

                    }
                    catch
                    {

                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Reservation Error", "alert('Error!! Please Check Details Formats')", true);

                    }




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

                    CeylonAdaptor aStaff = new CeylonAdaptor();

                    aStaff.FieldI1 = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);

                    aManager_DAO.DeleteStaffPlayer(aStaff);



                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Deleted Successfully')", true);

                    GetAllStaffMembers();
                    GridView1.SelectedIndex = -1;

                }
                catch (Exception Ex)
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Payment Deleted Error')", true);

                }
            }
        }

        protected void AlloateBTN_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Reservation Error", "alert('Please Select Staff From Table')", true);

            }
            else
            {
                EventsArray = aManager_DAO.GetAllPaymentDepartmentsTypes();
                DepartmentDropdown.SelectedValue = Convert.ToString(GridView1.SelectedRow.Cells[2].Text);

                OrderDetails.FieldI26=Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);// Player ID
                OrderDetails.FieldI27 = EventsArray[DepartmentDropdown.SelectedIndex].FieldI1;// Dep ID
                OrderDetails.FieldS40= GridView1.SelectedRow.Cells[2].Text + "-"+GridView1.SelectedRow.Cells[3].Text;
                Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
                Response.Redirect("~/StaffEventAllocation.aspx?ssid=" + SessionID.ToString());

            }
            }
    }
}