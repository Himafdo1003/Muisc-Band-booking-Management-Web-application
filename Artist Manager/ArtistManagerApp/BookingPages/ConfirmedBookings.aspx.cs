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
using System.Globalization;

namespace ArtistManagerApp.BookingPages
{
    public partial class ConfirmedBookings : System.Web.UI.Page
    {
        private int FoodHavingType;
        private int SessionID;
        private Manager_DAO aManager_DAO;
        private string DataSource;
        private string LocalDataSource;
        private CeylonAdaptor OrderDetails;
        private CeylonMiniAdaptor[] BookingData;
        private CeylonAdaptor[] ConfirmedBookingArray;
        private CeylonAdaptor[] DocumentData;
        private CeylonAdaptor[] TentativeBookingsArray;
        private CeylonAdaptor[] CustomerArray;
        private CeylonAdaptor[] RateArray;
        
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                getComputerName();
                aManager_DAO = new Manager_DAO();
                FoodHavingType = 0;
                SessionID = Convert.ToInt32(Request.QueryString["ssid"]);
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                OrderDetails.FieldI39 = 3101;


                // getDocumentDetails();

               

                if (!IsPostBack)

                {

                    if (OrderDetails.FieldI10 == 2)//Manager
                    {
                        GetConfirmedBookings();
                    }
                    else if (OrderDetails.FieldI10 == 3)//admin
                    {
                        GetConfirmedBookingasEventDateAscending();
                    }
                }

            }
            catch (Exception Ex)
            {
                Response.Redirect("StartPage.aspx");
            }
        }

        public void SearchCustomerByID()
        {
            try
            {



                CustomerArray = aManager_DAO.SearchCustomerByID(GridView1.SelectedRow.Cells[13].Text);
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


                //GridView1.DataSource = aCustomerData;
                //GridView1.DataBind();

                //GridView1.Visible = true;






            }
            catch (Exception Ex)
            {


            }
        }

        public void SearchAdvance()
        {
            try
            {
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                TentativeBookingsArray = aManager_DAO.SearchAdvance(Convert.ToString(OrderDetails.FieldI11));
                DataTable aTentativeBook = new DataTable();

                aTentativeBook.Columns.Add(new DataColumn("Pay ID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Advance", typeof(string)));

                int sum = 0;

                for (int i = 0; i < TentativeBookingsArray.Length; i++)
                {
                    aTentativeBook.Rows.Add(
                      TentativeBookingsArray[i].FieldI1, TentativeBookingsArray[i].FieldD1);

                   // OrderDetails.FieldI25 = TentativeBookingsArray[i].FieldI1;


                    sum += Convert.ToInt32(TentativeBookingsArray[i].FieldD1); 




                }
                OrderDetails.FieldS26 = Convert.ToString(sum); //amount
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('" + OrderDetails.FieldS26 + "')", true);

                Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);

            }
            catch (Exception Ex)
            {

                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }


        }

        public void SearchLastAdvanceDate()
        {
            try
            {
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                TentativeBookingsArray = aManager_DAO.SearchLastAdvanceDate(Convert.ToString(OrderDetails.FieldI11));
                DataTable aTentativeBook = new DataTable();

              
                aTentativeBook.Columns.Add(new DataColumn("Advance Date", typeof(string)));

                

                for (int i = 0; i < TentativeBookingsArray.Length; i++)
                {
                    aTentativeBook.Rows.Add(
                      TentativeBookingsArray[i].FieldS1);

                    OrderDetails.FieldS30 = TentativeBookingsArray[i].FieldS1;
                    Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);

                }
              
            }
            catch (Exception Ex)
            {

                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

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

        public void GetConfirmedBookings()
        {
            try
            {
                TentativeBookingsArray = aManager_DAO.GetConfirmedBookings();
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
        public void GetConfirmedBookingasEventDateAscending()
        {
            try
            {
                TentativeBookingsArray = aManager_DAO.GetConfirmedBookingasEventDateAscending();
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
           
            // OrderDetails.FieldI11 = Convert.ToInt32(GridView1.SelectedRow.Cells[10].Text);//Event ID
            //getDocumentDetails();
            //SearchAgentByID();
            SearchCustomerByID();

            EventDateTB.Text = (Convert.ToDateTime(GridView1.SelectedRow.Cells[1].Text)).ToString("yyyy-MM-dd");

            EventTimeDropdown.SelectedIndex = EventTimeDropdown.Items.IndexOf(EventTimeDropdown.Items.FindByText(GridView1.SelectedRow.Cells[2].Text));
            EventTypeDropdown.SelectedIndex = EventTypeDropdown.Items.IndexOf(EventTypeDropdown.Items.FindByText(GridView1.SelectedRow.Cells[3].Text));

            //EventTimeTB.Text = GridView1.SelectedRow.Cells[2].Text;
            //EventTypeTB.Text = GridView1.SelectedRow.Cells[3].Text;
            ContactNameTB.Text = Convert.ToString(GridView1.SelectedRow.Cells[4].Text);
            ContactPhoneTB.Text = Convert.ToString(GridView1.SelectedRow.Cells[5].Text);
            AddressTB.Text = Convert.ToString(GridView1.SelectedRow.Cells[6].Text);
            CustomerNameTB.Text = Convert.ToString(GridView1.SelectedRow.Cells[7].Text);
            VenueTB.Text = Convert.ToString(GridView1.SelectedRow.Cells[8].Text);
            SpecialNoteTB.Text = Convert.ToString(GridView1.SelectedRow.Cells[9].Text);

            CoupleNameTB.Text = Convert.ToString(GridView1.SelectedRow.Cells[10].Text);


            StatusTB.Text = GridView1.SelectedRow.Cells[11].Text;
            EventIDTB.Text = GridView1.SelectedRow.Cells[12].Text;

            OrderDetails.FieldI11 = Convert.ToInt32(GridView1.SelectedRow.Cells[12].Text);

            OrderDetails.FieldI11 = Convert.ToInt32(EventIDTB.Text);
            Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);


            Panel1.Visible = true;

            SearchLastAdvanceDate();
            SearchAdvance();



          

            Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
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


        public void getDocumentDetails()
        {
            try
            {

                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                DocumentData = aManager_DAO.GetDocumentDetails(OrderDetails.FieldI11.ToString().Trim());
                DataTable DocumetDetails = new DataTable();

                DocumetDetails.Columns.Add(new DataColumn("Trans Date", typeof(string)));
                DocumetDetails.Columns.Add(new DataColumn("Event Date", typeof(string)));
                DocumetDetails.Columns.Add(new DataColumn("Couple Name", typeof(string)));
                DocumetDetails.Columns.Add(new DataColumn("Venue", typeof(string)));
                DocumetDetails.Columns.Add(new DataColumn("Contract rate", typeof(string)));
                DocumetDetails.Columns.Add(new DataColumn("Customer Name", typeof(string)));             
                DocumetDetails.Columns.Add(new DataColumn("Advance Ammount", typeof(string)));
                DocumetDetails.Columns.Add(new DataColumn("Advance pay Date", typeof(string)));
                DocumetDetails.Columns.Add(new DataColumn("Contact Number", typeof(string)));
                DocumetDetails.Columns.Add(new DataColumn("Event Time", typeof(string)));
                DocumetDetails.Columns.Add(new DataColumn("Advanced Date", typeof(string)));
                DocumetDetails.Columns.Add(new DataColumn("Discount", typeof(string)));


                for (int i = 0; i < DocumentData.Length; i++)
                {
                    DocumetDetails.Rows.Add(
                      DocumentData[i].FieldDate2, DocumentData[i].FieldDate1, DocumentData[i].FieldS4, DocumentData[i].FieldS6,
                      DocumentData[i].FieldI5, DocumentData[i].FieldS7, DocumentData[i].FieldD1, DocumentData[i].FieldDate3, DocumentData[i].FieldS2,
                      DocumentData[i].FieldS10, DocumentData[i].FieldS18
                      
                      , DocumentData[i].FieldI8

                      );

                    OrderDetails.FieldS20 = DocumentData[i].FieldDate2.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture).Trim();// trans date
                    OrderDetails.FieldS21 = DocumentData[i].FieldDate1.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture).Trim();//event date
                    OrderDetails.FieldS22 = DocumentData[i].FieldS4.ToString().Trim();//couple name
                    OrderDetails.FieldS23 = DocumentData[i].FieldS6.ToString().Trim();//venue
                    OrderDetails.FieldS24 = DocumentData[i].FieldI5.ToString().Trim();// contract rate
                    OrderDetails.FieldS25 = DocumentData[i].FieldS7.ToString().Trim(); // customer name
                   // OrderDetails.FieldS26 = DocumentData[i].FieldD1.ToString().Trim(); //advance amount
                    OrderDetails.FieldS27 = DocumentData[i].FieldDate3.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture).Trim(); //pay date
                    OrderDetails.FieldS28 = DocumentData[i].FieldS2.ToString().Trim();//Contact number
                    OrderDetails.FieldS29 = DocumentData[i].FieldS10.ToString().Trim();      // event time                                      
                   OrderDetails.FieldS37 = DocumentData[i].FieldI8.ToString().Trim();//Discount amount
                    OrderDetails.FieldS41= DocumentData[i].FieldS9.ToString().Trim();// event type    




                }

                Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
            }
            catch (Exception Ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }


        }


        public void SearchAgentByID()
        {




            //try
            //{

            //    if (GridView1.SelectedRow.Cells[14].Text == "0")
            //    {
            //       // OrderDetails.FieldS39 = "NA";
            //        Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
            //    }
            //    else
            //    {


                    

            //        // GridView1.DataSource = DocumetDetails;
            //        // GridView1.DataBind();
            //    }

            //}
            //catch (Exception Ex)
            //{

            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            //}



        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            EventDateTB.ReadOnly = false;
            EventTimeDropdown.Enabled = true;
            EventTypeDropdown.Enabled = true;
            //EventTimeTB.ReadOnly = false;
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
            //EventTimeTB.BackColor = System.Drawing.ColorTranslator.FromHtml("#DB4133");
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



                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Booking Details Updated Successfully')", true);

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
                GetConfirmedBookings();

            }
            catch (Exception Ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Booking Details Update Error", "alert('Error')", true);

            }

        }

        protected void Confirm_Btn_Click(object sender, EventArgs e)
        {

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

        protected void Invoice_Btn_Click(object sender, EventArgs e)
        {
            
            getDocumentDetails();
            SearchEventRateByEventID();
           // OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
           // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert(''Date-'" + OrderDetails.FieldS30 + "')", true);            
            Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);

          Response.Redirect("~/Confirmed_Document.aspx?ssid=" + SessionID.ToString());

        }

        public void SearchEventRateByEventID()
        {

            try
            {
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                RateArray = aManager_DAO.SearchEventRateByEventID(Convert.ToString(OrderDetails.FieldI11));

                if (RateArray == null || RateArray.Length == 0)
                {

                }
                else
                {

                    DataTable DocumetDetails = new DataTable();
                    DocumetDetails.Columns.Add(new DataColumn("ID", typeof(string)));
                    DocumetDetails.Columns.Add(new DataColumn("Contract Rate", typeof(string)));

                    for (int i = 0; i < RateArray.Length; i++)
                    {
                        DocumetDetails.Rows.Add(
                          RateArray[i].FieldI1, RateArray[i].FieldS1);

                        OrderDetails.FieldS38 = RateArray[i].FieldS1;//Discount amount
                                                                                          //  ActualRateLBL.Text = RateArray[i].FieldS1;
                       
                    }

                    Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
                }

            }
            catch (Exception Ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }


        }

        protected void PayAdvanceBtn_Click(object sender, EventArgs e)
        {
            OrderDetails.FieldI11 = Convert.ToInt32(EventIDTB.Text);
            Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
            Response.Redirect("~/PaymentPage.aspx?ssid=" + SessionID.ToString());
            
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            if (DateTB.Text.Trim().Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Please Select Date For Before Search')", true);
            }
            else
            {
                ZSearchConfirmedBookingsByDate();
            }
            Panel1.Visible = false;
        }

        protected void ViewAll_Click(object sender, EventArgs e)
        {
            if (OrderDetails.FieldI10 == 2)//Manager
            {
                GetConfirmedBookings();
            }
            else if (OrderDetails.FieldI10 == 3)//admin
            {
                GetConfirmedBookingasEventDateAscending();
            }

            DateTB.Text = "";
            Panel1.Visible = false;
        }



        public void ZSearchConfirmedBookingsByDate()
        {
            try
            {
                TentativeBookingsArray = aManager_DAO.ZSearchConfirmedBookingsByDate(DateTB.Text);
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

    }







}