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
    public partial class TentativeBookings : System.Web.UI.Page
    {
        private int FoodHavingType;
        private int SessionID;
        private Manager_DAO aManager_DAO;
        private string DataSource;
        private string LocalDataSource;
        private CeylonAdaptor OrderDetails;
        private CeylonAdaptor[] TentativeBookingsArray;
        private CeylonAdaptor[] DocumentData;
        private CeylonAdaptor[] CustomerArray;

        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {



                getComputerName();
                aManager_DAO = new Manager_DAO();
                FoodHavingType = 0;
                SessionID = Convert.ToInt32(Request.QueryString["ssid"]);
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());

                
                if (!IsPostBack)

                {
                    GetTentativeBookings();
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
            Response.Redirect("~/BookingMenu.aspx?ssid=" + SessionID.ToString());
        }

        public void GetTentativeBookings()
        {
            try
            {
                TentativeBookingsArray = aManager_DAO.GetTentativeBookings();
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
                aTentativeBook.Columns.Add(new DataColumn("M EventID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("TransDate", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("trans by", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("confirmed by", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("UserTypeID", typeof(string)));






                for (int i = 0; i < TentativeBookingsArray.Length; i++)
                {
                    aTentativeBook.Rows.Add(
                      TentativeBookingsArray[i].FieldDate1, TentativeBookingsArray[i].FieldS10, TentativeBookingsArray[i].FieldS9, TentativeBookingsArray[i].FieldS1, TentativeBookingsArray[i].FieldS2, TentativeBookingsArray[i].FieldS3, TentativeBookingsArray[i].FieldS7,

                        TentativeBookingsArray[i].FieldS6, TentativeBookingsArray[i].FieldS5, TentativeBookingsArray[i].FieldS4, TentativeBookingsArray[i].FieldS8, TentativeBookingsArray[i].FieldI1, TentativeBookingsArray[i].FieldI2
                        , TentativeBookingsArray[i].FieldI3, TentativeBookingsArray[i].FieldI4, TentativeBookingsArray[i].FieldI5, TentativeBookingsArray[i].FieldDate2, TentativeBookingsArray[i].FieldI6
                        , TentativeBookingsArray[i].FieldI7, TentativeBookingsArray[i].FieldI8);




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
           
            SearchCustomerByID();

            //OrderDetails.FieldI11 = Convert.ToInt32(GridView1.SelectedRow.Cells[9].Text);
            //Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
            OrderDetails.FieldI38 = 0;//Tenative booking message purpose


            EventDateTB.Text = (Convert.ToDateTime(GridView1.SelectedRow.Cells[1].Text)).ToString("yyyy-MM-dd");

            //EventDateTB.Text = DateTime.Now.ToString("yyyy-MM-dd");
            //EventTimeDropdown.Items.FindByText(GridView1.SelectedRow.Cells[2].Text).Selected = true;

            EventTimeDropdown.SelectedIndex = EventTimeDropdown.Items.IndexOf(EventTimeDropdown.Items.FindByText(GridView1.SelectedRow.Cells[2].Text));
            EventTypeDropdown.SelectedIndex = EventTypeDropdown.Items.IndexOf(EventTypeDropdown.Items.FindByText(GridView1.SelectedRow.Cells[3].Text));
            //EventTimeTB.Text = GridView1.SelectedRow.Cells[2].Text;
            // EventTypeTB.Text = GridView1.SelectedRow.Cells[3].Text;



            ContactNameTB.Text = Convert.ToString(GridView1.SelectedRow.Cells[4].Text);
            ContactPhoneTB.Text = GridView1.SelectedRow.Cells[5].Text;
            AddressTB.Text = Convert.ToString(GridView1.SelectedRow.Cells[6].Text);
            CustomerNameTB.Text = Convert.ToString(GridView1.SelectedRow.Cells[7].Text);
            VenueTB.Text = Convert.ToString(GridView1.SelectedRow.Cells[8].Text);
            SpecialNoteTB.Text = Convert.ToString(GridView1.SelectedRow.Cells[9].Text);

            CoupleNameTB.Text = Convert.ToString(GridView1.SelectedRow.Cells[10].Text);


            StatusTB.Text = GridView1.SelectedRow.Cells[11].Text;
            EventIDTB.Text = GridView1.SelectedRow.Cells[12].Text;


            OrderDetails.FieldS20 = GridView1.SelectedRow.Cells[1].Text; // event date
            OrderDetails.FieldS21 = GridView1.SelectedRow.Cells[2].Text; //event time
            OrderDetails.FieldS22 = GridView1.SelectedRow.Cells[3].Text; //event type
            OrderDetails.FieldS23 = GridView1.SelectedRow.Cells[4].Text;//Contact name
            OrderDetails.FieldS24 = GridView1.SelectedRow.Cells[5].Text;//phone
            OrderDetails.FieldS25 = GridView1.SelectedRow.Cells[6].Text;//address
            OrderDetails.FieldS26 = GridView1.SelectedRow.Cells[7].Text;//customer name
            OrderDetails.FieldS27 = GridView1.SelectedRow.Cells[8].Text;//venue
            OrderDetails.FieldS28 = GridView1.SelectedRow.Cells[9].Text;//special note
            OrderDetails.FieldS29 = Convert.ToString(GridView1.SelectedRow.Cells[10].Text);//couple name
            OrderDetails.FieldS30 = GridView1.SelectedRow.Cells[11].Text;//statuss
            OrderDetails.FieldS31 = GridView1.SelectedRow.Cells[12].Text;//EID
            OrderDetails.FieldS34 = GridView1.SelectedRow.Cells[13].Text;//customer id
            OrderDetails.FieldS35 = GridView1.SelectedRow.Cells[14].Text;//agent id
            OrderDetails.FieldS36 = GridView1.SelectedRow.Cells[15].Text;//pet id

           

            OrderDetails.FieldI15= Convert.ToInt32(GridView1.SelectedRow.Cells[16].Text);// event rate
            OrderDetails.FieldDate6= Convert.ToDateTime(GridView1.SelectedRow.Cells[17].Text);// trans date



            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('" + OrderDetails.FieldS20 +  "')", true);



            Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);




            Panel1.Visible = true;


            OrderDetails.FieldI3 = Convert.ToInt32(GridView1.SelectedRow.Cells[13].Text); //CustomerID
            OrderDetails.FieldI2 = Convert.ToInt32(GridView1.SelectedRow.Cells[14].Text);//AgentID
            OrderDetails.FieldI13 = Convert.ToInt32(GridView1.SelectedRow.Cells[15].Text);//PETID
            OrderDetails.FieldI11 = Convert.ToInt32(EventIDTB.Text);//event ID




            SearchAgentByID();
            Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                CeylonMiniAdaptor UpdateBook = new CeylonMiniAdaptor();
                UpdateBook.FieldI1 = OrderDetails.FieldI11;//event ID
                UpdateBook.FieldDate1 = Convert.ToDateTime(EventDateTB.Text);
                UpdateBook.FieldS1 = EventTimeDropdown.SelectedValue.Trim();
                UpdateBook.FieldS2 = EventTypeDropdown.SelectedValue.Trim();
                UpdateBook.FieldS3 = ContactNameTB.Text;
                UpdateBook.FieldS4 = CustomerNameTB.Text;
                UpdateBook.FieldS5 = ContactPhoneTB.Text;
                UpdateBook.FieldS6 = AddressTB.Text;
                UpdateBook.FieldS7 = StatusTB.Text;
                UpdateBook.FieldS8 = VenueTB.Text;
                UpdateBook.FieldS9 = SpecialNoteTB.Text;
                UpdateBook.FieldS10 = CoupleNameTB.Text;
                aManager_DAO.UpdateABooking(UpdateBook);
                OrderDetails.FieldI38 = 0;//Tenative booking message purpose

                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('" + OrderDetails.FieldI11 + UpdateBook.FieldS1 + UpdateBook.FieldS2+ "')", true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Booking Details Updated Successfully')", true);

                GetTentativeBookings();

                EventDateTB.ReadOnly = true;
                EventTimeDropdown.Enabled = false;
                EventTypeDropdown.Enabled = false;
                //EventTypeTB.ReadOnly = false;
                ContactNameTB.ReadOnly = true;
                CustomerNameTB.ReadOnly = true;
                ContactPhoneTB.ReadOnly = true;
                AddressTB.ReadOnly = true;
                StatusTB.ReadOnly = true;
                VenueTB.ReadOnly = true;
                SpecialNoteTB.ReadOnly = true;
                CoupleNameTB.ReadOnly = true;

                EventDateTB.BackColor = System.Drawing.ColorTranslator.FromHtml("#fff");
                EventTimeDropdown.BackColor = System.Drawing.ColorTranslator.FromHtml("#fff");
                EventTypeDropdown.BackColor = System.Drawing.ColorTranslator.FromHtml("#fff");
                // EventTimeTB.BackColor = System.Drawing.ColorTranslator.FromHtml("#DB4133");
                //EventTypeTB.BackColor = System.Drawing.ColorTranslator.FromHtml("#DB4133");
                ContactNameTB.BackColor = System.Drawing.ColorTranslator.FromHtml("#fff");
                CustomerNameTB.BackColor = System.Drawing.ColorTranslator.FromHtml("#fff");
                ContactPhoneTB.BackColor = System.Drawing.ColorTranslator.FromHtml("#fff");
                AddressTB.BackColor = System.Drawing.ColorTranslator.FromHtml("#fff");
                StatusTB.BackColor = System.Drawing.ColorTranslator.FromHtml("#fff");
                VenueTB.BackColor = System.Drawing.ColorTranslator.FromHtml("#fff");
                SpecialNoteTB.BackColor = System.Drawing.ColorTranslator.FromHtml("#fff");
                CoupleNameTB.BackColor = System.Drawing.ColorTranslator.FromHtml("#fff");

            }
            catch (Exception Ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Booking Details Update Error", "alert('Error')", true);

            }

        }

        public void SearchCustomerByID()
        {
            try
            {



                CustomerArray = aManager_DAO.SearchCustomerByID(GridView1.SelectedRow.Cells[13].Text);
                if(CustomerArray==null|| CustomerArray.Length == 0)
                {
                    OrderDetails.FieldS4 = "NA";

                }
                else { 

                DataTable aCustomerData = new DataTable();
                aCustomerData.Columns.Add(new DataColumn("ACCID", typeof(string)));
                aCustomerData.Columns.Add(new DataColumn("Name", typeof(string)));
                aCustomerData.Columns.Add(new DataColumn("Phone", typeof(string)));
                aCustomerData.Columns.Add(new DataColumn("NIC", typeof(string)));

                for (int i = 0; i < CustomerArray.Length; i++)
                {
                    aCustomerData.Rows.Add(CustomerArray[i].FieldI1, CustomerArray[i].FieldS1, CustomerArray[i].FieldS2, CustomerArray[i].FieldS5);
                    OrderDetails.FieldS4 = CustomerArray[i].FieldS5.ToString().Trim();
                    Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
                }

                }
                //GridView1.DataSource = aCustomerData;
                //GridView1.DataBind();

                //GridView1.Visible = true;






            }
            catch (Exception Ex)
            {


            }
        }


        protected void Confirm_Btn_Click(object sender, EventArgs e)
        {

            OrderDetails.FieldI38 = 0;//Tenative booking message purpose
            Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);

            Response.Redirect("~/PaymentPage.aspx?ssid=" + SessionID.ToString());
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            OrderDetails.FieldI38 = 0;//Tenative booking message purpose

            EventDateTB.ReadOnly = false;
            EventTimeDropdown.Enabled = true;
            EventTypeDropdown.Enabled = true;
            //EventTypeTB.ReadOnly = false;
            ContactNameTB.ReadOnly = false;
            CustomerNameTB.ReadOnly = false;
            ContactPhoneTB.ReadOnly = false;
            AddressTB.ReadOnly = false;
            StatusTB.ReadOnly = false;
            VenueTB.ReadOnly = false;
            SpecialNoteTB.ReadOnly = false;
            CoupleNameTB.ReadOnly = false;


            UpdateBtn.Visible = true;
            EventDateTB.BackColor = System.Drawing.ColorTranslator.FromHtml("#DB4133");
            EventTimeDropdown.BackColor = System.Drawing.ColorTranslator.FromHtml("#DB4133");
            EventTypeDropdown.BackColor = System.Drawing.ColorTranslator.FromHtml("#DB4133");
            // EventTimeTB.BackColor = System.Drawing.ColorTranslator.FromHtml("#DB4133");
            //EventTypeTB.BackColor = System.Drawing.ColorTranslator.FromHtml("#DB4133");
            ContactNameTB.BackColor = System.Drawing.ColorTranslator.FromHtml("#DB4133");
            CustomerNameTB.BackColor = System.Drawing.ColorTranslator.FromHtml("#DB4133");
            ContactPhoneTB.BackColor = System.Drawing.ColorTranslator.FromHtml("#DB4133");
            AddressTB.BackColor = System.Drawing.ColorTranslator.FromHtml("#DB4133");
            StatusTB.BackColor = System.Drawing.ColorTranslator.FromHtml("#DB4133");
            VenueTB.BackColor = System.Drawing.ColorTranslator.FromHtml("#DB4133");
            SpecialNoteTB.BackColor = System.Drawing.ColorTranslator.FromHtml("#DB4133");
            CoupleNameTB.BackColor = System.Drawing.ColorTranslator.FromHtml("#DB4133");
            AddToEventHistory();





        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                CeylonMiniAdaptor UpdateStatus = new CeylonMiniAdaptor();
                UpdateStatus.FieldI1 = OrderDetails.FieldI11;
                UpdateStatus.FieldS1 = "Cancelled";
                OrderDetails.FieldI38 = 0;//Tenative booking message purpose
                aManager_DAO.UpdatBookingStatus(UpdateStatus);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Booking Cancelled Successfully')", true);

            }
            catch (Exception Ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Booking Deletion Error", "alert('Error')", true);

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[15].Visible = false;
            e.Row.Cells[16].Visible = false;
            e.Row.Cells[17].Visible = false;
            e.Row.Cells[18].Visible = false;
            e.Row.Cells[19].Visible = false;
            e.Row.Cells[20].Visible = false;

            e.Row.Cells[1].Font.Bold = true;
            e.Row.Cells[2].Font.Bold = true;

        }

        public void SearchAgentByID()
        {



            try
            {
                if (GridView1.SelectedRow.Cells[14].Text == "0")
                {

                    OrderDetails.FieldS39 = "NA";
                    Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
                }
                else
                {


                    DocumentData = aManager_DAO.SearchAgentByID(GridView1.SelectedRow.Cells[14].Text);
                    DataTable DocumetDetails = new DataTable();

                    DocumetDetails.Columns.Add(new DataColumn("Agent Name", typeof(string)));




                    for (int i = 0; i < DocumentData.Length; i++)
                    {
                        DocumetDetails.Rows.Add(
                          DocumentData[i].FieldS1);

                        OrderDetails.FieldS39 = DocumentData[i].FieldS1.ToString().Trim();// event date


                        Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
                    }



                    // GridView1.DataSource = DocumetDetails;
                    // GridView1.DataBind();

                }
            }
            catch (Exception Ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }



        }
        public void AddToEventHistory()
        {


            try
            {
                CeylonAdaptor aBook = new CeylonAdaptor();


                aBook.FieldI1 = Convert.ToInt32(EventIDTB.Text);//eventid
                aBook.FieldI2 = Convert.ToInt32(GridView1.SelectedRow.Cells[13].Text);//FK_Customerid
                aBook.FieldI3 = Convert.ToInt32(GridView1.SelectedRow.Cells[14].Text);//agentID
                aBook.FieldI4 = Convert.ToInt32(GridView1.SelectedRow.Cells[15].Text);//PETID
                aBook.FieldS1 = ContactNameTB.Text;//COntactName
                aBook.FieldS2 = ContactPhoneTB.Text;//phone

                aBook.FieldS3 = AddressTB.Text;//address
                aBook.FieldS4 = CoupleNameTB.Text;//cpl name


                aBook.FieldS5 = SpecialNoteTB.Text.Trim();//spcl not
                aBook.FieldS6 = VenueTB.Text;//venue
                aBook.FieldS7 = CustomerNameTB.Text;//customer Name
                aBook.FieldS8 = StatusTB.Text;//status         
                aBook.FieldS9 = EventTypeDropdown.SelectedValue.Trim();//eventType
                aBook.FieldS10 = EventTimeDropdown.SelectedValue.Trim(); //eventTime
                aBook.FieldDate1 = Convert.ToDateTime(EventDateTB.Text); //Event Date      
                aBook.FieldI5 = Convert.ToInt32(GridView1.SelectedRow.Cells[16].Text); //M_event id
                aBook.FieldDate2 = Convert.ToDateTime(GridView1.SelectedRow.Cells[17].Text); //trans date            
                aBook.FieldI6 = Convert.ToInt32(GridView1.SelectedRow.Cells[18].Text);//transed by
                aBook.FieldI7 = Convert.ToInt32(GridView1.SelectedRow.Cells[19].Text); // confirme by
                aBook.FieldI8 = Convert.ToInt32(GridView1.SelectedRow.Cells[20].Text);  //user type ID




                aManager_DAO.AddToEventHistoryTable(aBook);

                Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Booking History Added Successfully')", true);







            }
            catch (Exception Ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }



        }

        public void ZSearchTentativeBookingsByDate()
        {
            try
            {
                TentativeBookingsArray = aManager_DAO.ZSearchTentativeBookingsByDate(DateTB.Text);
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
                aTentativeBook.Columns.Add(new DataColumn("M EventID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("TransDate", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("trans by", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("confirmed by", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("UserTypeID", typeof(string)));






                for (int i = 0; i < TentativeBookingsArray.Length; i++)
                {
                    aTentativeBook.Rows.Add(
                      TentativeBookingsArray[i].FieldDate1, TentativeBookingsArray[i].FieldS10, TentativeBookingsArray[i].FieldS9, TentativeBookingsArray[i].FieldS1, TentativeBookingsArray[i].FieldS2, TentativeBookingsArray[i].FieldS3, TentativeBookingsArray[i].FieldS7,

                        TentativeBookingsArray[i].FieldS6, TentativeBookingsArray[i].FieldS5, TentativeBookingsArray[i].FieldS4, TentativeBookingsArray[i].FieldS8, TentativeBookingsArray[i].FieldI1, TentativeBookingsArray[i].FieldI2
                        , TentativeBookingsArray[i].FieldI3, TentativeBookingsArray[i].FieldI4, TentativeBookingsArray[i].FieldI5, TentativeBookingsArray[i].FieldDate2, TentativeBookingsArray[i].FieldI6
                        , TentativeBookingsArray[i].FieldI7, TentativeBookingsArray[i].FieldI8);




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
                ZSearchTentativeBookingsByDate();
            }
            Panel1.Visible = false;
        }

        protected void ViewAll_Click(object sender, EventArgs e)
        {


            GetTentativeBookings();
            DateTB.Text = "";
            Panel1.Visible = false;
        }
    }
}