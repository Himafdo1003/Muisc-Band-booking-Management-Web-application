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
    public partial class Customer : System.Web.UI.Page
    {
        private Manager_DAO aManager_DAO;
        private string DataSource;
        private string LocalDataSource;
        private CeylonAdaptor[] CustomerArray;
        private int CustomerID;
        private string CustomerName;
        private int SessionID;
        private CeylonAdaptor OrderDetails;
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                getComputerName();
                aManager_DAO = new Manager_DAO();
                SearchTextBox.Focus();
                CustomerID = 0;
                SessionID = Convert.ToInt32(Request.QueryString["ssid"]);
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());





            }
            catch (Exception EX)
            {
                Response.Redirect("~/StartPage.aspx");
            }
        }
        public void getComputerName()
        {
            LocalDataSource = System.Environment.MachineName;
        }//End of getComputerName() method    

        protected void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            getCustomersByPara();

        }
        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            CeylonAdaptor aCustomer = new CeylonAdaptor();
            aCustomer.FieldS1 = SearchTextBox.Text;
            aCustomer.FieldS1 = NameTextBox.Text;
            aCustomer.FieldS3 = AddressTextBox.Text;
            aCustomer.FieldS6 = EmailTextBox.Text;
            aCustomer.FieldS4 = PhoneTextBox.Text;
            aCustomer.FieldS5 = NICNumberTextBox.Text;
            aCustomer.FieldS7 = "Basic";
            aManager_DAO.AddACustomer(aCustomer);
            SearchTextBox.Text = "";
            AddressTextBox.Text = "";
            EmailTextBox.Text = ""; PhoneTextBox.Text = "";
            NICNumberTextBox.Text = "";

        }


        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ReservationMenu.aspx?ssid=" + SessionID.ToString());
        }
        protected void NICTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        protected void GuessButton_Click(object sender, EventArgs e)
        {
            CustomerID = 0;
        }
        protected void SearchTextBox_TextChanged1(object sender, EventArgs e)
        {
            if (SearchTextBox.Text.Trim().Equals(""))
            {
                SearchTextBox.Focus();
            }
            else
            {
                PhoneTextBox.Focus();
            }

        }
        protected void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            if (PhoneTextBox.Text.Trim().Equals(""))
            {
                PhoneTextBox.Focus();
            }
            else
            {
                AddressTextBox.Focus();
            }
        }
        protected void AddressTextBox_TextChanged(object sender, EventArgs e)
        {
            if (AddressTextBox.Text.Trim().Equals(""))
            {
                AddressTextBox.Focus();
            }
            else
            {
                EmailTextBox.Focus();
            }
        }
        protected void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            if (EmailTextBox.Text.Trim().Equals(""))
            {
                EmailTextBox.Focus();
            }
            else
            {
                NICNumberTextBox.Focus();
            }
        }
        protected void NICNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NICNumberTextBox.Text.Trim().Equals(""))
            {
                NICNumberTextBox.Focus();
            }
            else
            {
            }
        }
        protected void SearchButton_Click(object sender, EventArgs e)
        {
            getCustomersByPara();
        }
        public void getCustomersByPara()
        {
            try
            {
                CustomerArray = aManager_DAO.GetAllCustomerByParaForSale(SearchTextBox.Text.Trim());
                DataTable aCustomerData = new DataTable();
                aCustomerData.Columns.Add(new DataColumn("ACCID", typeof(string)));
                aCustomerData.Columns.Add(new DataColumn("Name", typeof(string)));
                aCustomerData.Columns.Add(new DataColumn("Phone", typeof(string)));
                aCustomerData.Columns.Add(new DataColumn("NIC", typeof(string)));
                aCustomerData.Columns.Add(new DataColumn("Address", typeof(string)));

                if (CustomerArray == null || CustomerArray.Length == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('No Customers Found!')", true);
                    GridView1.Visible = false;
                }
                else { 
                    for (int i = 0; i < CustomerArray.Length; i++)
                    {
                        aCustomerData.Rows.Add(CustomerArray[i].FieldI1, CustomerArray[i].FieldS1, CustomerArray[i].FieldS4, CustomerArray[i].FieldS5, CustomerArray[i].FieldS3);
                    }

                    GridView1.DataSource = aCustomerData;
                    GridView1.DataBind();
                    if (aCustomerData.Rows.Count == 0 || String.IsNullOrEmpty(SearchTextBox.Text))
                    {
                        GridView1.Visible = false;
                        NewButton.Visible = true;
                        PhoneTextBox.Visible = true;
                        PhoneTextBox.Text = "";
                        PhoneLabel.Visible = true;
                        AddressLabel.Visible = true;
                        AddressTextBox.Text = "";
                        AddressTextBox.Visible = true;
                        EmailLabel.Visible = true;
                        EmailTextBox.Text = "";
                        EmailTextBox.Visible = true;
                        NICNumberLabel.Visible = true;
                        NICNumberTextBox.Text = "";
                        NICNumberTextBox.Visible = true;
                        Button1.Visible = true;
                        NewButton1.Visible = true;
                        NameLabel.Visible = true;
                        NameTextBox.Visible = true;
                        NameTextBox.Text = "";
                    }
                    else
                    {
                        GridView1.Visible = true;
                        NewButton.Visible = false;
                        PhoneTextBox.Visible = false;
                        PhoneTextBox.Text = "";
                        PhoneLabel.Visible = false;
                        AddressLabel.Visible = false;
                        AddressTextBox.Text = "";
                        AddressTextBox.Visible = false;
                        EmailLabel.Visible = false;
                        EmailTextBox.Text = "";
                        EmailTextBox.Visible = false;
                        NICNumberLabel.Visible = false;
                        NICNumberTextBox.Text = "";
                        NICNumberTextBox.Visible = false;
                        Button1.Visible = false;
                        NameLabel.Visible = false;
                        NameTextBox.Visible = false;
                        NameTextBox.Text = "";

                    }
                }

            }
            catch (Exception Ex)
            {
                SearchTextBox.Focus();
                GridView1.Visible = false;
                NewButton.Visible = true;


            }
        }

        public void getCustomersByRegister()
        {
            try
            {
                CustomerArray = aManager_DAO.GetAllCustomerByParaForSale(NICNumberTextBox.Text.Trim());
                DataTable aCustomerData = new DataTable();
                aCustomerData.Columns.Add(new DataColumn("ACCID", typeof(string)));
                aCustomerData.Columns.Add(new DataColumn("Name", typeof(string)));
                aCustomerData.Columns.Add(new DataColumn("Phone", typeof(string)));
                aCustomerData.Columns.Add(new DataColumn("NIC", typeof(string)));
                aCustomerData.Columns.Add(new DataColumn("Address", typeof(string)));

                for (int i = 0; i < CustomerArray.Length; i++)
                {
                    aCustomerData.Rows.Add(CustomerArray[i].FieldI1, CustomerArray[i].FieldS1, CustomerArray[i].FieldS4, CustomerArray[i].FieldS5, CustomerArray[i].FieldS3);
                }

                GridView1.DataSource = aCustomerData;
                GridView1.DataBind();

                GridView1.Visible = true;

                PhoneTextBox.Visible = false;
                PhoneLabel.Visible = false;

                AddressLabel.Visible = false;

                AddressTextBox.Visible = false;
                EmailLabel.Visible = false;

                EmailTextBox.Visible = false;
                NICNumberLabel.Visible = false;

                NICNumberTextBox.Visible = false;
                Button1.Visible = false;
                NameLabel.Visible = false;
                NameTextBox.Visible = false;

                ValidateLabel.Visible = false;
                NewButton.Visible = false;




            }
            catch (Exception Ex)
            {


            }
        }
        public void GetLastRegisteredCusomer()
        {
            try
            {
                CustomerArray = aManager_DAO.GetLastRegisteredCusomer();
                DataTable aCustomerData = new DataTable();
                aCustomerData.Columns.Add(new DataColumn("ACCID", typeof(string)));
                aCustomerData.Columns.Add(new DataColumn("Name", typeof(string)));
                aCustomerData.Columns.Add(new DataColumn("Phone", typeof(string)));
                aCustomerData.Columns.Add(new DataColumn("NIC", typeof(string)));
                aCustomerData.Columns.Add(new DataColumn("Address", typeof(string)));

                for (int i = 0; i < CustomerArray.Length; i++)
                {
                    aCustomerData.Rows.Add(CustomerArray[i].FieldI1, CustomerArray[i].FieldS1, CustomerArray[i].FieldS2, CustomerArray[i].FieldS5, CustomerArray[i].FieldS3);
                }

                GridView1.DataSource = aCustomerData;
                GridView1.DataBind();

                GridView1.Visible = true;

                PhoneTextBox.Visible = false;
                PhoneLabel.Visible = false;

                AddressLabel.Visible = false;

                AddressTextBox.Visible = false;
                EmailLabel.Visible = false;

                EmailTextBox.Visible = false;
                NICNumberLabel.Visible = false;

                NICNumberTextBox.Visible = false;
                Button1.Visible = false;
                NameLabel.Visible = false;
                NameTextBox.Visible = false;

                ValidateLabel.Visible = false;
                NewButton.Visible = false;




            }
            catch (Exception Ex)
            {


            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow aGridViewRowData = GridView1.SelectedRow;
            CustomerID = Convert.ToInt32(aGridViewRowData.Cells[1].Text);//id
            OrderDetails.FieldI3 = CustomerID;
            OrderDetails.FieldS2 = aGridViewRowData.Cells[2].Text;// name
            OrderDetails.FieldS3 = "Fully Registered";
            OrderDetails.FieldS4 = aGridViewRowData.Cells[4].Text;//customer nic
            OrderDetails.FieldS5= aGridViewRowData.Cells[3].Text;//customer phone
            OrderDetails.FieldS6 = aGridViewRowData.Cells[5].Text;//customer address




            ValidateLabel.Visible = false;
            Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
            if (OrderDetails.FieldI2 == 2)
            {
                Response.Redirect("~/ConfirmBook.aspx?ssid=" + SessionID.ToString());
            }
            else
            {
                Response.Redirect("~/ConfirmBook.aspx?ssid=" + SessionID.ToString());
            }


        }
        protected void NextButton_Click(object sender, EventArgs e)
        {


        }
        protected void SearchRealButton_Click(object sender, EventArgs e)
        {

        }
        protected void SearchButton_Click1(object sender, EventArgs e)
        {
            getCustomersByPara();

        }
        protected void NewButton_Click(object sender, EventArgs e)
        {
            PhoneTextBox.Focus();
            PhoneTextBox.Visible = true;
            PhoneLabel.Visible = true;
            PhoneTextBox.Text = "";
            AddressLabel.Visible = true;
            AddressTextBox.Text = "";
            AddressTextBox.Visible = true;
            EmailLabel.Visible = true;
            EmailTextBox.Text = "";
            EmailTextBox.Visible = true;
            NICNumberLabel.Visible = true;
            NICNumberTextBox.Text = "";
            NICNumberTextBox.Visible = true;
            Button1.Visible = true;
            NameLabel.Visible = true;
            NameTextBox.Visible = true;
            NameTextBox.Text = "";
            ValidateLabel.Visible = false;

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (EmailTextBox.Text.Trim().Equals("") || AddressTextBox.Text.Trim().Equals("") ||
             PhoneTextBox.Text.Trim().Equals("") || NICNumberTextBox.Text.Trim().Equals(""))
            {
                ValidateLabel.Visible = true;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Please fill all fields to Register')", true);

            }
            else
            {

                CeylonAdaptor aCustomer = new CeylonAdaptor();
                aCustomer.FieldS1 = SearchTextBox.Text;
                aCustomer.FieldS1 = NameTextBox.Text;
                aCustomer.FieldS3 = AddressTextBox.Text;
                aCustomer.FieldS6 = EmailTextBox.Text;
                aCustomer.FieldS4 = PhoneTextBox.Text;
                aCustomer.FieldS5 = NICNumberTextBox.Text;
                aCustomer.FieldS7 = "Basic";
                aManager_DAO.AddACustomer(aCustomer);
                //getCustomersByRegister();
                GetLastRegisteredCusomer();
                AddressTextBox.Text = "";
                EmailTextBox.Text = "";
                PhoneTextBox.Text = "";
                NICNumberTextBox.Text = "";
                Button1.Visible = false;
                // getCustomersByPara();
                ValidateLabel.Visible = false;

            }

        }
        protected void GuestButton_Click(object sender, EventArgs e)
        {
            CustomerID = 0;
            OrderDetails.FieldI3 = CustomerID;
            OrderDetails.FieldS2 = "Cash Customer";
            OrderDetails.FieldS3 = "Cash Customer";
            Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
            if (OrderDetails.FieldI2 == 2)
            {
                Response.Redirect("~/ConfirmBook.aspx?ssid=" + SessionID.ToString());
            }
            else
            {
                Response.Redirect("~/ConfirmBook.aspx?ssid=" + SessionID.ToString());
            }
        }

        protected void PhoneTextBox_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void SearchTextBox_TextChanged2(object sender, EventArgs e)
        {

        }

        protected void New_Click1(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[5].Visible = false;
        }
    }
}