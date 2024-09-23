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

namespace ArtistManagerApp
{
    public partial class PaymentConfirm : System.Web.UI.Page
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
        private CeylonAdaptor[] TentativeBookingsArray;
        private CeylonAdaptor[] DepartmentArray;
        private CeylonAdaptor[] PlayerArray;
        private CeylonAdaptor[] AmountArray;
        public int paymentID;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                getComputerName();

                aManager_DAO = new Manager_DAO();
                FoodHavingType = 0;

                SessionID = Convert.ToInt32(Request.QueryString["ssid"]);
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                OrderDetails.FieldI38 = 0;//Tenative booking message purpose

                if (!IsPostBack)
                {
                    SearchEvents();
                    SearchDepartments();
                    FilterPlayers();
                    GetPaymentAmount();
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
            Response.Redirect("~/AdSRPage.aspx?ssid=" + SessionID.ToString());
        }
        protected void EventType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DepartmentDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {


            try
            {
                FilterPlayers();

                GetPaymentAmount();


            }
            catch (Exception EX)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('" + EX.Message + "')", true);

            }

            if (DepartmentDropdown.SelectedValue.Trim() == "Others")
            {

                Label9.Visible = true;
                AnyNoteTB.Visible = true;

            }
            else
            {

                Label9.Visible = false;
                AnyNoteTB.Visible = false;
            }
            if (DepartmentDropdown.SelectedValue.Trim() == "Transport")
            {

                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                if (KMTB.Text == "" || KMTB.Text == "0" || KMTB.Text == "0.00")
                {
                    PaymentShowTB.Text = Convert.ToString(OrderDetails.FieldD2);
                }
                else
                {
                    PaymentShowTB.Text = Convert.ToString(OrderDetails.FieldD2 * Convert.ToDecimal(KMTB.Text));
                }
                KMPanel.Visible = true;

            }
            else
            {
                KMPanel.Visible = false;

            }

           

        }


        protected void Player_SelectedIndexChanged(object sender, EventArgs e)
        {

            GetPaymentAmount();

            
        }

        protected void TextBoxshow_TextChanged(object sender, EventArgs e)
        {

        }

        protected void BandPay_Click(object sender, EventArgs e)
        {
            DepartmentArray = aManager_DAO.SearchDepartments(Convert.ToString(OrderDetails.FieldI20));
            OrderDetails.FieldI23 = DepartmentArray[DepartmentDropdown.SelectedIndex].FieldI2;//DEP ID

            PlayerArray = aManager_DAO.FilterPlayers(Convert.ToString(OrderDetails.FieldI20), Convert.ToString(DepartmentArray[DepartmentDropdown.SelectedIndex].FieldI2));//Pet ID and DEP ID
            OrderDetails.FieldI22 = PlayerArray[PlayerDropdown.SelectedIndex].FieldI1;//PID

            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('" + OrderDetails.FieldI24 + "')", true);


            if (EventTypeDropdown.Text.Trim().Equals("") ||
           DepartmentDropdown.Text.Trim().Equals("") || PlayerDropdown.Text.Trim().Equals("") || PaymentShowTB.Text.Trim().Equals("") || String.IsNullOrWhiteSpace(PayDateTB.Text))
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Reservation Error", "alert('Please fill all fields to Payment Process')", true);


            }
            else
            {
                //try
                //{

                CeylonAdaptor aBook = new CeylonAdaptor();


                aBook.FieldI1 = OrderDetails.FieldI19;// FK_EventID
                aBook.FieldI2 = OrderDetails.FieldI24;//FK_PayID
                aBook.FieldI3 = OrderDetails.FieldI22; //FK_PID
                aBook.FieldI4 = OrderDetails.FieldI23; //FK_Dep_ID
                aBook.FieldI5 = OrderDetails.FieldI20; //FK_PETID
                aBook.FieldD1 = Convert.ToDecimal(PaymentShowTB.Text); //PaymentAmount
                aBook.FieldD2 = Convert.ToDecimal(PaymentShowTB.Text); //Special_Payment
                aBook.FieldS1 = PaymentTypeDropdown.SelectedValue.Trim(); //Payment Type
                if (String.IsNullOrWhiteSpace(BankNameTB.Text))
                {
                    aBook.FieldS2 = "NA"; //Bank
                }
                else
                {

                    aBook.FieldS2 = BankNameTB.Text;
                }

                if (String.IsNullOrWhiteSpace(ChequeNoTB.Text))
                {
                    aBook.FieldS3 = "NA"; //Cheque No
                }
                else
                {

                    aBook.FieldS3 = ChequeNoTB.Text;
                }

                if (String.IsNullOrWhiteSpace(ChequeDateTB.Text))
                {
                    aBook.FieldDate1 = DateTime.Now; //Cheque Date
                }
                else
                {

                    aBook.FieldDate1 = Convert.ToDateTime(ChequeDateTB.Text);
                }
                if (String.IsNullOrWhiteSpace(ReasonTB.Text))
                {
                    aBook.FieldS4 = "NA"; //Details1 = FOC reason

                }
                else
                {
                    aBook.FieldS4 = ReasonTB.Text; //Details1 = FOC reason

                }


                aBook.FieldS5 = PlayerDropdown.SelectedValue.Trim(); //Details2  player name
                aBook.FieldS6 = "Paid";//Details3   status
                aBook.FieldS7 = DepartmentDropdown.SelectedValue.Trim();//Details4 departmenttype


                if (String.IsNullOrWhiteSpace(AnyNoteTB.Text))
                {
                    aBook.FieldS8 = "NA";//Details5  Other // special nots
                }
                else
                {

                    aBook.FieldS8 = AnyNoteTB.Text;//Details5  Other // special nots
                }


               

                    aBook.FieldS9 = DateTime.Parse(PayDateTB.Text.Trim()).ToString("yyyy/MM/dd", CultureInfo.InvariantCulture); //Details6 pay date
                


                
                aBook.FieldS10 = "NA";//Details7



                aManager_DAO.AddAStaffPayment(aBook);

                SearchStaffPaymentsByEventID();

                Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Payment done Successfully')", true);

                //}
                //catch (Exception EX)
                //{
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

                //}

            }
        }

        protected void Amend_Click(object sender, EventArgs e)
        {
            PaymentShowTB.ReadOnly = false;
        }


        public void SearchEvents()
        {
            try
            {
                TentativeBookingsArray = aManager_DAO.SearchEventsByDate(Convert.ToString(OrderDetails.FieldDate6), OrderDetails.FieldS13);
                DataTable aTentativeBook = new DataTable();

                aTentativeBook.Columns.Add(new DataColumn("Event ID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("PET ID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Event Date", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Event Name", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Event Time", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Contract Price", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Discount Price", typeof(string)));

                for (int i = 0; i < TentativeBookingsArray.Length; i++)
                {
                    aTentativeBook.Rows.Add(
                      TentativeBookingsArray[i].FieldI1, TentativeBookingsArray[i].FieldI2, TentativeBookingsArray[i].FieldDate1,
                      TentativeBookingsArray[i].FieldS1, TentativeBookingsArray[i].FieldS2, TentativeBookingsArray[i].FieldI3, TentativeBookingsArray[i].FieldI4);


                    EventTypeDropdown.Items.Add(TentativeBookingsArray[i].FieldS1);
                    OrderDetails.FieldI19 = TentativeBookingsArray[i].FieldI1; //Event ID
                    OrderDetails.FieldI20 = TentativeBookingsArray[i].FieldI2; //PET ID
                    Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);

                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('" + OrderDetails.FieldI20 + "')", true);

                }


                //GridView1.DataSource = aTentativeBook;
                //GridView1.DataBind();


            }
            catch (Exception Ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }

        }

        public void SearchStaffPaymentsByEventID()
        {
            try
            {
                TentativeBookingsArray = aManager_DAO.SearchStaffPaymentsByEventID(Convert.ToString(OrderDetails.FieldI19));
                DataTable aTentativeBook = new DataTable();

                aTentativeBook.Columns.Add(new DataColumn("Payment ID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Payment Date", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Department", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Player", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Payment Type", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Bank", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Paying Amount", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("FOC", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Other/Any Note", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Status", typeof(string)));

                for (int i = 0; i < TentativeBookingsArray.Length; i++)
                {
                    aTentativeBook.Rows.Add(
                      TentativeBookingsArray[i].FieldI1, TentativeBookingsArray[i].FieldS8, TentativeBookingsArray[i].FieldS6,
                      TentativeBookingsArray[i].FieldS4, TentativeBookingsArray[i].FieldS1, TentativeBookingsArray[i].FieldS2, TentativeBookingsArray[i].FieldD1
                      , TentativeBookingsArray[i].FieldS3, TentativeBookingsArray[i].FieldS7, TentativeBookingsArray[i].FieldS5);


                   

                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('" + OrderDetails.FieldI20 + "')", true);

                }


                GridView1.DataSource = aTentativeBook;
                GridView1.DataBind();


            }
            catch (Exception Ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }

        }

        public void FilterPlayers()
        {
            try
            {
                PlayerDropdown.Items.Clear();

                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                DepartmentArray = aManager_DAO.SearchDepartments(Convert.ToString(OrderDetails.FieldI20));


                PlayerArray = aManager_DAO.FilterPlayers(Convert.ToString(OrderDetails.FieldI20), Convert.ToString(DepartmentArray[DepartmentDropdown.SelectedIndex].FieldI2));//Pet ID and DEP ID
                DataTable aTentativeBook = new DataTable();

                aTentativeBook.Columns.Add(new DataColumn("PID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Player Name", typeof(string)));


                for (int i = 0; i < PlayerArray.Length; i++)
                {
                    aTentativeBook.Rows.Add(
                      PlayerArray[i].FieldI1, PlayerArray[i].FieldS1);


                    PlayerDropdown.Items.Add(PlayerArray[i].FieldS1);

                    Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
                    // OrderDetails.FieldI20 = TentativeBookingsArray[i].FieldI2;
                }


                //GridView1.DataSource = aTentativeBook;
                //GridView1.DataBind();


            }
            catch (Exception Ex)
            {

                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }

        }

        public void SearchDepartments()
        {
            try
            {
                DepartmentArray = aManager_DAO.SearchDepartments(Convert.ToString(OrderDetails.FieldI20));
               

                for (int i = 0; i < DepartmentArray.Length; i++)
                {
                   
                    DepartmentDropdown.Items.Add(DepartmentArray[i].FieldS1);
                    Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
                }

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('"+ DepartmentArray.Length + "')", true);

                //GridView1.DataSource = DepartmentDetails;
                //GridView1.DataBind();


            }
            catch (Exception Ex)
            {

                 ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeleteBtn.Visible = true;

           //paymentIDTB.Text = GridView1.SelectedRow.Cells[1].Text;

           
        }





        public void GetPaymentAmount()
        {
            try
            {

                PaymentShowTB.Text = "";

                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                DepartmentArray = aManager_DAO.SearchDepartments(Convert.ToString(OrderDetails.FieldI20));
                PlayerArray = aManager_DAO.FilterPlayers(Convert.ToString(OrderDetails.FieldI20), Convert.ToString(DepartmentArray[DepartmentDropdown.SelectedIndex].FieldI2));

                AmountArray = aManager_DAO.GetPaymentAmount(Convert.ToString(OrderDetails.FieldI20), Convert.ToString(DepartmentArray[DepartmentDropdown.SelectedIndex].FieldI2), Convert.ToString(PlayerArray[PlayerDropdown.SelectedIndex].FieldI1));//Pet ID and DEP ID and PID
                DataTable aTentativeBook = new DataTable();

                aTentativeBook.Columns.Add(new DataColumn("Pay ID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Amount", typeof(string)));


                for (int i = 0; i < AmountArray.Length; i++)
                {
                    aTentativeBook.Rows.Add(
                     AmountArray[i].FieldI1, AmountArray[i].FieldD1);

                    OrderDetails.FieldI24 = Convert.ToInt32(AmountArray[i].FieldI1);//pay id

                    //PaymentShowTB.Text = Convert.ToString(OrderDetails.FieldI24);

                    PaymentShowTB.Text = Convert.ToString(AmountArray[i].FieldD1);

                    OrderDetails.FieldD2 = AmountArray[i].FieldD1;

                    Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
                }





            }
            catch (Exception Ex)
            {

                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }

        }



        protected void PaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PaymentTypeDropdown.SelectedValue == "Bank")
            {
                ReasonLBL.Visible = false;
                ReasonTB.Visible = false;

                ChequeNoTB.Text = string.Empty;
                ChequeDateTB.Text = string.Empty;

                Label6.Visible = false;
                Label8.Visible = false;

                ChequeNoTB.Visible = false;
                ChequeDateTB.Visible = false;

                Label5.Visible = true;
                BankNameTB.Visible = true;

                PayDateLBL.Visible = true;
                PayDateTB.Visible = true;

            }

            if (PaymentTypeDropdown.SelectedValue == "Cash")
            {
                ReasonLBL.Visible = false;
                ReasonTB.Visible = false;

                BankNameTB.Text = string.Empty;
                ChequeNoTB.Text = string.Empty;
                ChequeDateTB.Text = string.Empty;

                Label6.Visible = false;
                Label8.Visible = false;

                ChequeNoTB.Visible = false;
                ChequeDateTB.Visible = false;

                Label5.Visible = false;
                BankNameTB.Visible = false;


                PayDateLBL.Visible = true;
                PayDateTB.Visible = true;



            }

            if (PaymentTypeDropdown.SelectedValue == "Card")
            {
                ReasonLBL.Visible = false;
                ReasonTB.Visible = false;
                BankNameTB.Text = string.Empty;
                ChequeNoTB.Text = string.Empty;
                ChequeDateTB.Text = string.Empty;


                Label6.Visible = false;
                Label8.Visible = false;

                ChequeNoTB.Visible = false;
                ChequeDateTB.Visible = false;

                Label5.Visible = false;
                BankNameTB.Visible = false;


                PayDateLBL.Visible = true;
                PayDateTB.Visible = true;




            }
            if (PaymentTypeDropdown.SelectedValue == "Credit")
            {
                ReasonLBL.Visible = true;
                ReasonTB.Visible = true;

                Label6.Visible = false;
                Label8.Visible = false;

                ChequeNoTB.Visible = false;
                ChequeDateTB.Visible = false;

                Label5.Visible = false;
                BankNameTB.Visible = false;

                PayDateLBL.Visible = true;
                PayDateTB.Visible = true;




            }
            if (PaymentTypeDropdown.SelectedValue == "Cheque")
            {
                ReasonLBL.Visible = false;
                ReasonTB.Visible = false;

                Label6.Visible = true;
                Label8.Visible = true;

                ChequeNoTB.Visible = true;
                ChequeDateTB.Visible = true;

                BankNameTB.Visible = false;
                Label5.Visible = false;

                PayDateLBL.Visible = true;
                PayDateTB.Visible = true;

            }
            if (PaymentTypeDropdown.SelectedValue == "FOC")
            {
                PayDateLBL.Visible = true;
                PayDateTB.Visible = true;


                ReasonLBL.Visible = true;
                ReasonTB.Visible = true;

                ChequeNoTB.Visible = false;
                ChequeDateTB.Visible = false;

                BankNameTB.Visible = false;
                Label5.Visible = false;

                ChequeNoTB.Text = string.Empty;
                ChequeDateTB.Text = string.Empty;

                Label6.Visible = false;
                Label8.Visible = false;

                ChequeNoTB.Visible = false;
                ChequeDateTB.Visible = false;


                BankNameTB.Text = string.Empty;
                ChequeNoTB.Text = string.Empty;
                ChequeDateTB.Text = string.Empty;


                Label6.Visible = false;
                Label8.Visible = false;

                ChequeNoTB.Visible = false;
                ChequeDateTB.Visible = false;

                B_PayAmend.Visible = false;

                PaymentShowTB.Text = Convert.ToString(Convert.ToDecimal("0"));

            }

        }


        protected void PaymentTypeDropdown_TextChanged(object sender, EventArgs e)
        {


        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            try
            {

                CeylonAdaptor aStaff = new CeylonAdaptor();

                aStaff.FieldI1 = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);



                aManager_DAO.DeleteStaffPAyment(aStaff);



                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Payment Deleted Successfully')", true);

                SearchStaffPaymentsByEventID();

            }
            catch (Exception Ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Payment Deleted Error')", true);

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }

        protected void KMTB_TextChanged(object sender, EventArgs e)
        {
            OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
            if(KMTB.Text==""|| KMTB.Text=="0"|| KMTB.Text == "0.00")
            {
                PaymentShowTB.Text = Convert.ToString(OrderDetails.FieldD2);
            }
            else
            {
                PaymentShowTB.Text = Convert.ToString(OrderDetails.FieldD2 * Convert.ToDecimal(KMTB.Text));
            }

           

        }
    }
}


