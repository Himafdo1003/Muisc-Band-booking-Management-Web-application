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
    public partial class PaymentPage : System.Web.UI.Page
    {
        private int FoodHavingType;
        private int SessionID;
        private Manager_DAO aManager_DAO;
        private string DataSource;
        private string LocalDataSource;
        private CeylonAdaptor OrderDetails;
        private int CustomerID;
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {

                getComputerName();
                aManager_DAO = new Manager_DAO();
                FoodHavingType = 0;
                SessionID = Convert.ToInt32(Request.QueryString["ssid"]);
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                OrderDetails.FieldI3 = CustomerID;
                OrderDetails.FieldI38 = 0;



                if (!IsPostBack)
                {
                    //PaymentTypeDropdown.Items.Add(new ListItem("Cash", "Cash", true));
                    //PaymentTypeDropdown.Items.Add(new ListItem("Cheque", "Cheque", true));
                    //PaymentTypeDropdown.Items.Add(new ListItem("Bank", "Bank", true));



                }

                if (OrderDetails.FieldI10 == 2)
                {
                    A2.Visible = false;
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


        protected void With_Click(object sender, EventArgs e)
        {
            Label7.Visible = true;

            PaymentTypeDropdown.Visible = true;

            Label1.Visible = true;

            Label2.Visible = true;
            AmountTB.Visible = true;
            Description.Visible = true;

            Confirm_Btn.Visible = true;


            Label10.Visible = true;
            AdvancedDateTB.Visible = true;



        }

        protected void Without_Click(object sender, EventArgs e)
        {
            try
            {
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                CeylonMiniAdaptor UpdateStatus = new CeylonMiniAdaptor();
                UpdateStatus.FieldI1 = OrderDetails.FieldI11;//Event ID
                UpdateStatus.FieldS1 = "Confirmed";
                UpdateStatus.FieldI2 = OrderDetails.FieldI12; // Confirmed By
                UpdateStatus.FieldDate1 = DateTime.Now; // Confirmed Date




                OrderDetails.FieldS33 = "NA";
                OrderDetails.FieldS34 = "0.00";
                OrderDetails.FieldS35 = "NA";
                OrderDetails.FieldS36 = "NA";



                ChequeDateTB.Text = "00-00-0000";
                RealiseDateTB.Text = "00-00-0000";
                aManager_DAO.UpdatBookingStatus(UpdateStatus);


                try
                {

                    CeylonAdaptor aPay = new CeylonAdaptor();


                    aPay.FieldI1 = OrderDetails.FieldI11;// Event ID
                    aPay.FieldI2 = OrderDetails.FieldI3;// FK_Customer ID
                    aPay.FieldI3 = OrderDetails.FieldI2;//Fk_AgentID

                    aPay.FieldS1 = "NA";
                    aPay.FieldS2 = "Pending";
                    aPay.FieldS3 = "NA"; ;
                    aPay.FieldS4 = "NA";
                    aPay.FieldS5 = "NA";

                    aPay.FieldS6 = "NA";// details1 account name


                    aPay.FieldS7 = DateTime.Parse(Convert.ToString(DateTime.Now)).ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);// advanced date 
                    aPay.FieldS8 = "Advance Paid";// Advance 
                    aPay.FieldS9 = "NA";
                    aPay.FieldS10 = "NA";

                    OrderDetails.FieldS33 = "Pending";
                    OrderDetails.FieldS34 = "0.00";

                    OrderDetails.FieldS36 = "NA";


                    OrderDetails.FieldS35 = "NA";

                    aPay.FieldD1 =0;

                    aPay.FieldD2 = 0;
                   

                    aManager_DAO.AddingPayment(aPay);
                    Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);

                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('" + UpdateStatus.FieldS1 + "')", true);
                    OrderDetails.FieldI38 = 1;
                    Response.Redirect("~/BookingPages/ConfirmedBookings.aspx?ssid=" + SessionID.ToString());

                   


                }

                catch (Exception Ex)
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Booking Confirmation Error", "alert('Confirmation Error')", true);

                }
            }



            catch (Exception Ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Details Update Error", "alert('Error')", true);

            }
        }

        protected void Confirm_Btn_Click(object sender, EventArgs e)
        {



            OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
            CeylonMiniAdaptor UpdateStatus = new CeylonMiniAdaptor();
            UpdateStatus.FieldI1 = OrderDetails.FieldI11;//Event ID
            UpdateStatus.FieldS1 = "Confirmed";
            UpdateStatus.FieldI2 = OrderDetails.FieldI12; // Confirmed By
            UpdateStatus.FieldDate1 = DateTime.Now; // Confirmed Date




            OrderDetails.FieldS33 = PaymentTypeDropdown.SelectedValue.Trim();
            OrderDetails.FieldS34 = AmountTB.Text;
            OrderDetails.FieldS35 = Description.Text;
            OrderDetails.FieldS36 = BankNameTB.Text;



            ChequeDateTB.Text = "00-00-0000";
            RealiseDateTB.Text = "00-00-0000";
            aManager_DAO.UpdatBookingStatus(UpdateStatus);



            // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('" + UpdateStatus.FieldS1 + "')", true);



            if (string.IsNullOrWhiteSpace(AmountTB.Text)|| string.IsNullOrWhiteSpace(AdvancedDateTB.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Related Details')", true);
            }
            else
            {
                try
                {

                    CeylonAdaptor aPay = new CeylonAdaptor();


                    aPay.FieldI1 = OrderDetails.FieldI11;// Event ID
                    aPay.FieldI2 = OrderDetails.FieldI3;// FK_Customer ID
                    aPay.FieldI3 = OrderDetails.FieldI2;//Fk_AgentID

                    aPay.FieldS1 = Description.Text;
                    aPay.FieldS2 = PaymentTypeDropdown.SelectedValue.Trim();
                    aPay.FieldS3 = BankNameTB.Text;
                    aPay.FieldS4 = "NA";
                    aPay.FieldS5 = "NA";

                    aPay.FieldS6 = AccountNameTB.SelectedValue.Trim();// details1 account name


                    aPay.FieldS7 = DateTime.Parse(AdvancedDateTB.Text.Trim()).ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);// advanced date 
                    aPay.FieldS8 = "Advance Paid";// Advance 
                    aPay.FieldS9 = "NA";
                    aPay.FieldS10 = "NA";

                    OrderDetails.FieldS33 = PaymentTypeDropdown.SelectedValue.Trim();
                    OrderDetails.FieldS34 = AmountTB.Text;

                    if (String.IsNullOrWhiteSpace(BankNameTB.Text))
                    {


                        OrderDetails.FieldS36 = "NA";

                    }
                    else
                    {

                        OrderDetails.FieldS36 = BankNameTB.Text;
                    }


                    if (String.IsNullOrWhiteSpace(Description.Text))
                    {

                        OrderDetails.FieldS35 = "NA";


                    }
                    else
                    {



                        OrderDetails.FieldS35 = Description.Text.Trim();

                    }

                    if (string.IsNullOrWhiteSpace(AmountTB.Text))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter the Amount')", true);
                    }
                    else
                    {
                        aPay.FieldD1 = Convert.ToDecimal(AmountTB.Text);
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
                    Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);

                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('" + UpdateStatus.FieldS1 + "')", true);
                    OrderDetails.FieldI38 = 1;
                    Response.Redirect("~/BookingPages/ConfirmedBookings.aspx?ssid=" + SessionID.ToString());

                    //AdvancedDateTB.Text = DateTime.Now.ToString("dd/MM/yyyy");

                    

                }

                catch (Exception Ex)
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Booking Confirmation Error", "alert('Confirmation Error')", true);

                }
            }

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {



            if (PaymentTypeDropdown.SelectedValue == "Bank")
            {

                Label1.Visible = true;
                Label2.Visible = true;
                Label3.Visible = true;
                AmountTB.Visible = true;
                Description.Visible = true;
                BankNameTB.Visible = true;
                AccountNameLBL.Visible = true;
                AccountNameTB.Visible = true;


                Label4.Visible = false;
                ChequeNoTB.Visible = false;
                Label6.Visible = false;
                ChequeDateTB.Visible = false;

            }

            if (PaymentTypeDropdown.SelectedValue == "Cash")
            {



                Label1.Visible = true;
                Label2.Visible = true;
                AmountTB.Visible = true;
                Description.Visible = true;

                Label3.Visible = false;
                BankNameTB.Visible = false;

                Label4.Visible = false;
                ChequeNoTB.Visible = false;
                Label6.Visible = false;
                ChequeDateTB.Visible = false;
                AccountNameLBL.Visible = false;
                AccountNameTB.Visible = false;

            }
            if (PaymentTypeDropdown.SelectedValue == "Cheque")
            {




                Label1.Visible = true;
                Label2.Visible = true;

                AmountTB.Visible = true;
                Description.Visible = true;
                Label4.Visible = true;
                ChequeNoTB.Visible = true;
                Label6.Visible = true;
                ChequeDateTB.Visible = true;

                BankNameTB.Visible = false;
                Label3.Visible = false;

                AccountNameLBL.Visible = false;
                AccountNameTB.Visible = false;

            }







        }

        protected void AmountTB_Disposed(object sender, EventArgs e)
        {

        }

        protected void AmountTB_Load(object sender, EventArgs e)
        {

        }

        protected void AmountTB_Init(object sender, EventArgs e)
        {

        }

        protected void AmountTB_PreRender(object sender, EventArgs e)
        {

        }

        protected void AmountTB_TextChanged(object sender, EventArgs e)
        {

        }

        protected void AmountTB_Unload(object sender, EventArgs e)
        {

        }

        protected void PaymentTypeDropdown_TextChanged(object sender, EventArgs e)
        {

        }

        protected void EventType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void AdvancedDateTB_TextChanged(object sender, EventArgs e)
        {
          //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('" + DateTime.Parse(AdvancedDateTB.Text.Trim()).ToString("yyyy/MM/dd", CultureInfo.InvariantCulture) + "')", true);
        }
    }
}