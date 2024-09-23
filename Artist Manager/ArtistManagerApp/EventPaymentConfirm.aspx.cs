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
    public partial class EventPaymentConfirm : System.Web.UI.Page
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
                    SearchEvents();
                    SearchAdvance();
                    SearchEventamount();
                    GetBalanceAmount();

                    AllEventPsySearchbyEventID();

                    if (string.IsNullOrWhiteSpace(EventAmountTB.Text))
                    {
                        AdvancePaidTB.Text = "";
                    }
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
            Response.Redirect("~/PaymentPages/EventPayments.aspx?ssid=" + SessionID.ToString());
        }

        protected void EventType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void PaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PaymentTypeDropdown.SelectedValue == "Bank")
            {
                ChequeNoTB.Text = string.Empty;
                ChequeDateTB.Text = string.Empty;

                Label6.Visible = false;
                Label8.Visible = false;

                ChequeNoTB.Visible = false;
                ChequeDateTB.Visible = false;

                Label5.Visible = true;
                BankNameTB.Visible = true;


                AccountNameLBL.Visible = true;
                AccountNameTB.Visible = true;


            }

            if (PaymentTypeDropdown.SelectedValue == "Cash")
            {
                BankNameTB.Text = string.Empty;
                ChequeNoTB.Text = string.Empty;
                ChequeDateTB.Text = string.Empty;

                Label6.Visible = false;
                Label8.Visible = false;

                ChequeNoTB.Visible = false;
                ChequeDateTB.Visible = false;

                Label5.Visible = false;
                BankNameTB.Visible = false;

                AccountNameLBL.Visible = false;
                AccountNameTB.Visible = false;



            }

            if (PaymentTypeDropdown.SelectedValue == "Card")
            {
                BankNameTB.Text = string.Empty;
                ChequeNoTB.Text = string.Empty;
                ChequeDateTB.Text = string.Empty;


                Label6.Visible = false;
                Label8.Visible = false;

                ChequeNoTB.Visible = false;
                ChequeDateTB.Visible = false;

                Label5.Visible = false;
                BankNameTB.Visible = false;


                AccountNameLBL.Visible = false;
                AccountNameTB.Visible = false;

            }
            if (PaymentTypeDropdown.SelectedValue == "Credit")
            {


                Label6.Visible = false;
                Label8.Visible = false;

                ChequeNoTB.Visible = false;
                ChequeDateTB.Visible = false;

                Label5.Visible = false;
                BankNameTB.Visible = false;
                AccountNameLBL.Visible = false;
                AccountNameTB.Visible = false;



            }
            if (PaymentTypeDropdown.SelectedValue == "Cheque")
            {

                Label6.Visible = true;
                Label8.Visible = true;

                ChequeNoTB.Visible = true;
                ChequeDateTB.Visible = true;

                BankNameTB.Visible = false;
                Label5.Visible = false;

                AccountNameLBL.Visible = false;
                AccountNameTB.Visible = false;

            }
        }

        protected void BandPay_Click(object sender, EventArgs e)
        {
            if (PayingAmountTB.Text.Length == 0|| String.IsNullOrWhiteSpace(PayingDateTB.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter all paying details')", true);
            }
            else
            {

                



                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());


                CeylonAdaptor aPay = new CeylonAdaptor();


                aPay.FieldI1 = OrderDetails.FieldI19;// Event ID
                aPay.FieldI2 = OrderDetails.FieldI3;// FK_Customer ID
                aPay.FieldI3 = OrderDetails.FieldI2;//Fk_AgentID

                aPay.FieldS1 = "NA";
                aPay.FieldS2 = PaymentTypeDropdown.SelectedValue.Trim();
                aPay.FieldS3 = BankNameTB.Text;
                aPay.FieldS4 = ChequeNoTB.Text;
                aPay.FieldS5 = "NA";

                aPay.FieldS6 = AccountNameTB.SelectedValue.Trim();// details1 account name


                aPay.FieldS7 = DateTime.Parse(PayingDateTB.Text.Trim()).ToString("yyyy/MM/dd", CultureInfo.InvariantCulture); // payed date date 
                aPay.FieldS8 = "Balance Paid";// Advance 
                aPay.FieldS9 = "NA";
                aPay.FieldS10 = "NA";

               

                if (String.IsNullOrWhiteSpace(BankNameTB.Text))
                {


                    OrderDetails.FieldS36 = "NA";

                }
                else
                {

                    OrderDetails.FieldS36 = BankNameTB.Text;
                }


               

                if (string.IsNullOrWhiteSpace(PayingAmountTB.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter the Amount')", true);
                }
                else
                {
                    aPay.FieldD1 = Convert.ToDecimal(PayingAmountTB.Text);
                }
                //aPay.FieldD1 = Convert.ToDecimal(AmountTB.Text);

                //if (string.IsNullOrWhiteSpace(RealiseAmountTB.Text))
                //{
                //    aPay.FieldD2 = 0;
                //}
                //else
                //{
                //    aPay.FieldD2 = Convert.ToDecimal(RealiseAmountTB.Text);
                //}

                aPay.FieldD2 = 0;
                //aPay.FieldD1 = Convert.ToDecimal(AmountTB.Text);
                aPay.FieldDate1 = DateTime.Now;
                //aPay.FieldDate2 = Convert.ToDateTime("0000-00-00");
                //aPay.FieldDate3 = Convert.ToDateTime("0000-00-00");



                aManager_DAO.AddingPayment(aPay);
                OrderDetails.FieldI38 = 0;//Tenative booking message purpose
                Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Payment Added Successfully')", true);

                AllEventPsySearchbyEventID();


            }
        }

        protected void TextBoxshow_TextChanged(object sender, EventArgs e)
        {

        }

        protected void PaymentTypeDropdown_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeleteBtn.Visible = true;
        }

        public void AllEventPsySearchbyEventID()
        {
            try
            {
                TentativeBookingsArray = aManager_DAO.SearchAllEventPayments(Convert.ToString(OrderDetails.FieldI19));
                DataTable aTentativeBook = new DataTable();

                aTentativeBook.Columns.Add(new DataColumn("Pay ID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Paid Amount", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Payment Type", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Bank", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Account", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Date", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Payment Status", typeof(string)));

                for (int i = 0; i < TentativeBookingsArray.Length; i++)
                {
                    aTentativeBook.Rows.Add(
                      TentativeBookingsArray[i].FieldI1, TentativeBookingsArray[i].FieldD1, TentativeBookingsArray[i].FieldS1, TentativeBookingsArray[i].FieldS2, TentativeBookingsArray[i].FieldS3
                      , TentativeBookingsArray[i].FieldS4
                      , TentativeBookingsArray[i].FieldS5);


                   

                    Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);

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


        public void SearchEvents()
        {
            try
            {
                TentativeBookingsArray = aManager_DAO.SearchEventsByDate(Convert.ToString(OrderDetails.FieldDate6), OrderDetails.FieldS13);
                DataTable aTentativeBook = new DataTable();

                aTentativeBook.Columns.Add(new DataColumn("Event ID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("PET ID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Event Name", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Contract Price", typeof(string)));

                for (int i = 0; i < TentativeBookingsArray.Length; i++)
                {
                    aTentativeBook.Rows.Add(
                      TentativeBookingsArray[i].FieldI1, TentativeBookingsArray[i].FieldI2, TentativeBookingsArray[i].FieldS1, TentativeBookingsArray[i].FieldI3);


                    EventTypeDropdown.Items.Add(TentativeBookingsArray[i].FieldS1);
                    OrderDetails.FieldI19 = TentativeBookingsArray[i].FieldI1; //Event ID
                    OrderDetails.FieldI20 = TentativeBookingsArray[i].FieldI2; //PET ID
                   // OrderDetails.FieldI21 = TentativeBookingsArray[i].FieldI3; // contract price

                    EventAmountTB.Text = (Convert.ToDecimal(TentativeBookingsArray[i].FieldI3)).ToString(); //amount

                    Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);

                   //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('" + OrderDetails.FieldI19 + "')", true);

                }

                //AllEventPsySearchbyEventID();
                //GridView1.DataSource = aTentativeBook;
                //GridView1.DataBind();



            }
            catch (Exception Ex)
            {

                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }


        }


        public void SearchAdvance()
        {
            try
            {
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                TentativeBookingsArray = aManager_DAO.SearchAdvance(Convert.ToString(OrderDetails.FieldI19));
                DataTable aTentativeBook = new DataTable();

                aTentativeBook.Columns.Add(new DataColumn("Pay ID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Advance", typeof(string)));

                int sum = 0;

                for (int i = 0; i < TentativeBookingsArray.Length; i++)
                {
                    aTentativeBook.Rows.Add(
                      TentativeBookingsArray[i].FieldI1, TentativeBookingsArray[i].FieldD1);

                    OrderDetails.FieldI25 = TentativeBookingsArray[i].FieldI1;


                    sum += Convert.ToInt32(TentativeBookingsArray[i].FieldD1); ;



                    ////////////////////////////////////////////////////////////////////////////////////////////////////////




                   

                    Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);




                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('" + OrderDetails.FieldI20 + "')", true);

                }
                AdvancePaidTB.Text = Convert.ToString(sum); //amount




            }
            catch (Exception Ex)
            {

                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }


        }

        public void SearchEventamount()
        {
            try
            {
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                TentativeBookingsArray = aManager_DAO.SearchEventAmount(Convert.ToString(EventTypeDropdown.SelectedValue));
                DataTable aTentativeBook = new DataTable();

                aTentativeBook.Columns.Add(new DataColumn("Pay ID", typeof(string)));
                aTentativeBook.Columns.Add(new DataColumn("Advance", typeof(string)));



                for (int i = 0; i < TentativeBookingsArray.Length; i++)
                {
                    aTentativeBook.Rows.Add(
                      TentativeBookingsArray[i].FieldI1, TentativeBookingsArray[i].FieldS1);



                   // EventAmountTB.Text = (Convert.ToDecimal(TentativeBookingsArray[i].FieldS1)).ToString(); //amount

                    Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);

                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('" + OrderDetails.FieldI20 + "')", true);

                }




            }
            catch (Exception Ex)
            {

                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }


        }

        public void GetBalanceAmount()
        {
            try
            {

                decimal balance;
                balance = (Convert.ToDecimal(EventAmountTB.Text)) - (Convert.ToDecimal(AdvancePaidTB.Text));
                BalanceTB.Text = balance.ToString();


            }
            catch (Exception Ex)
            {

                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

            }


        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            try
            {

                CeylonAdaptor aStaff = new CeylonAdaptor();

                aStaff.FieldI1 = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);



                aManager_DAO.DeleteEventPAyment(aStaff);



                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Payment Deleted Successfully')", true);

                AllEventPsySearchbyEventID();

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
    }

}