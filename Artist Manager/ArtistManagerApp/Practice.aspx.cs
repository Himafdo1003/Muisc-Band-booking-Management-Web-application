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
    public partial class Practice : System.Web.UI.Page
    {
        private int FoodHavingType;
        private int SessionID;
        private Manager_DAO aManager_DAO;
        private string DataSource;
        private string LocalDataSource;
        private CeylonAdaptor OrderDetails;
        private CeylonMiniAdaptor[] EventsArray;
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

                for (int i = 0; i < EventsArray.Length; i++)
                {
                    //DropDownList1.DataTextField = "EventName";
                    //DropDownList1.DataValueField = "PETID";
                    if (EventsArray[i].FieldS1 == "Practice")
                    {

                        DropDownList1.Items.Insert(0, new ListItem("Practice"));
                    }
                }


                if (OrderDetails.FieldI10 == 3)
                {

                    Confirmbtn.Visible = true;
                }


                foreach (ListItem ColorItems in DropDownList1.Items)

                {



                    if (ColorItems.Text.Trim() == "Practice")

                        ColorItems.Attributes.Add("style", "background-color: #515151");


                }

                if (OrderDetails.FielSd12 == "Morning" && OrderDetails.FielSd32 == "Evening")
                {

                    DropDownList2.Enabled = true;

                    //  DropDownList2.Items.Clear();
                    //  DropDownList2.Items.Add(OrderDetails.FielSd12);
                    //DropDownList2.Items.Add(OrderDetails.FielSd32);
                }
                else

if (OrderDetails.FielSd12 == "Morning")
                {
                    DropDownList2.SelectedIndex = DropDownList2.Items.IndexOf(DropDownList2.Items.FindByText("Morning"));
                    //DropDownList2.Items.Clear();
                    //DropDownList2.Items.Add(OrderDetails.FielSd12);
                }
                else
if (OrderDetails.FielSd32 == "Evening")
                {

                    DropDownList2.SelectedIndex = DropDownList2.Items.IndexOf(DropDownList2.Items.FindByText("Evening"));
                    //DropDownList2.Items.Clear();
                    //DropDownList2.Items.Add(OrderDetails.FielSd32);
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

        protected void ConfirmBtn_Click(object sender, EventArgs e)
        {


            CeylonAdaptor aBook = new CeylonAdaptor();

            aBook.FieldI1 = 0;
            aBook.FieldI2 = 0;
            aBook.FieldI3 = OrderDetails.FieldI13;
            aBook.FieldS1 = "NA";
            aBook.FieldS2 = "NA";
            aBook.FieldS3 = "NA";
            aBook.FieldS4 = "NA";
            aBook.FieldS5 = SpecialNote.Text;
            aBook.FieldS6 = "NA";
            aBook.FieldS7 = "NA";
            aBook.FieldS8 = "Confirmed";
            aBook.FieldS9 = DropDownList1.SelectedValue.Trim();
            aBook.FieldS10 = DropDownList2.SelectedValue.Trim();
            aBook.FieldDate1 = OrderDetails.FieldDate2;
            aBook.FieldI4 = 0;
            aBook.FieldDate2 = DateTime.Now;
            aBook.FieldI5 = OrderDetails.FieldI11;
            aBook.FieldI6 = OrderDetails.FieldI11;
            aBook.FieldI7 = 0;
            aManager_DAO.AddABooking(aBook);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Practice Reservation Added Successfully')", true);
            Response.Redirect("~/AdSRPage.aspx?ssid=" + SessionID.ToString());

        }
        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdSRPage.aspx?ssid=" + SessionID.ToString());
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}