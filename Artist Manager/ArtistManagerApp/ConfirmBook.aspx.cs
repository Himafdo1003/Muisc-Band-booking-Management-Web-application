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
    public partial class ConfirmBook : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {
           

            foreach (ListItem ColorItems in EventTypeDropDown.Items)

            {

                if (ColorItems.Text.Trim() == "Wedding")

                    ColorItems.Attributes.Add("style", "background-color: blue");

                if (ColorItems.Text.Trim() == "Home Coming")

                    ColorItems.Attributes.Add("style", "background-color: red");

                if (ColorItems.Text.Trim() == "Engagement")

                    ColorItems.Attributes.Add("style", "background-color: red");

                if (ColorItems.Text.Trim() == "Corporate Events")

                    ColorItems.Attributes.Add("style", "background-color: green");

                if (ColorItems.Text.Trim() == "Dinner Dance")

                    ColorItems.Attributes.Add("style", "background-color: green");

                if (ColorItems.Text.Trim() == "Birthday Party")

                    ColorItems.Attributes.Add("style", "background-color: green");

                if (ColorItems.Text.Trim() == "Wedding Annivesary Party")

                    ColorItems.Attributes.Add("style", "background-color: green");

                if (ColorItems.Text.Trim() == "Concerts-70s")

                    ColorItems.Attributes.Add("style", "background-color: yellow");

                if (ColorItems.Text.Trim() == "Concerts-Thaala")

                    ColorItems.Attributes.Add("style", "background-color: yellow");

                if (ColorItems.Text.Trim() == "Concerts-MS")

                    ColorItems.Attributes.Add("style", "background-color: yellow");

                if (ColorItems.Text.Trim() == "Practice")

                    ColorItems.Attributes.Add("style", "background-color: #515151");

                if (ColorItems.Text.Trim() == "Other")

                    ColorItems.Attributes.Add("style", "background-color: white");

                if (ColorItems.Text.Trim() == "Concert-General")

                    ColorItems.Attributes.Add("style", "background-color: yellow");
            }
            try
            {
                getComputerName();
                aManager_DAO = new Manager_DAO();
                FoodHavingType = 0;
                SessionID = Convert.ToInt32(Request.QueryString["ssid"]);
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());

                
                EventsArray = aManager_DAO.EventType();

               


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




                if (!IsPostBack)
                {
                    DiscountTB.Text = "0";

                    if (OrderDetails.FieldI2 == 0)//customer
                    {
                        CustomerNameTB.Text = OrderDetails.FieldS2;// customer Name 
                        ContactNameTB.Text = OrderDetails.FieldS2;// customer Name 
                        Contact.Text = OrderDetails.FieldS5;//phone
                        ContactAdressTB.Text = OrderDetails.FieldS6;//address
                    }

                    if (OrderDetails.FieldI2 == 1)//agent
                    {
                        CustomerNameTB.Text = OrderDetails.FieldS39;// customer Name 
                        ContactNameTB.Text = OrderDetails.FieldS39;// customer Name 
                        Contact.Text = "";//phone
                        ContactAdressTB.Text = "";//address

                    }

                    for (int i = 0; i < EventsArray.Length; i++)
                    {
                        EventTypeDropDown.Items.Add(EventsArray[i].FieldS1);

                    }


                    if (OrderDetails.FieldI10 == 3)
                    {

                        Confirmbtn.Visible = true;
                    }
                    foreach (ListItem ColorItems in EventTypeDropDown.Items)

                    {

                        if (ColorItems.Text.Trim() == "Wedding")

                            ColorItems.Attributes.Add("style", "background-color: blue");

                        if (ColorItems.Text.Trim() == "Home Coming")

                            ColorItems.Attributes.Add("style", "background-color: red");

                        if (ColorItems.Text.Trim() == "Engagement")

                            ColorItems.Attributes.Add("style", "background-color: red");

                        if (ColorItems.Text.Trim() == "Corporate Events")

                            ColorItems.Attributes.Add("style", "background-color: green");

                        if (ColorItems.Text.Trim() == "Dinner Dance")

                            ColorItems.Attributes.Add("style", "background-color: green");

                        if (ColorItems.Text.Trim() == "Birthday Party")

                            ColorItems.Attributes.Add("style", "background-color: green");

                        if (ColorItems.Text.Trim() == "Wedding Annivesary Party")

                            ColorItems.Attributes.Add("style", "background-color: green");

                        if (ColorItems.Text.Trim() == "Concerts-70s")

                            ColorItems.Attributes.Add("style", "background-color: yellow");

                        if (ColorItems.Text.Trim() == "Concerts-Thaala")

                            ColorItems.Attributes.Add("style", "background-color: yellow");

                        if (ColorItems.Text.Trim() == "Concerts-MS")

                            ColorItems.Attributes.Add("style", "background-color: yellow");

                        if (ColorItems.Text.Trim() == "Practice")

                            ColorItems.Attributes.Add("style", "background-color: #515151");

                        if (ColorItems.Text.Trim() == "Other")

                            ColorItems.Attributes.Add("style", "background-color: white");

                        if (ColorItems.Text.Trim() == "Concert-General")

                            ColorItems.Attributes.Add("style", "background-color: yellow");
                    }

                    //EventTypeDropDown.SelectedIndex = 1;
                    //Rate.Text = decimal.Parse(EventsArray[EventTypeDropDown.SelectedIndex].FieldS3).ToString("#,#");
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


        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
            Couple_Name.Visible = true;
            cplNameLabel.Visible = true;

        }
        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ReservationMenu.aspx?ssid=" + SessionID.ToString());
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void Submit_Click(object sender, EventArgs e)
        {


        }

        protected void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Next_Click(object sender, EventArgs e)
        {

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void AmendRate_btn_Click(object sender, EventArgs e)
        {
            EventsArray = aManager_DAO.EventType();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Make Sure that need To Amend Rate')", true);

            Rate.ReadOnly = false;
        }

        protected void ConfirmBtn_Click(object sender, EventArgs e)
        {


            if (ContactNameTB.Text.Trim().Equals("") ||
            ContactAdressTB.Text.Trim().Equals("") || Contact.Text.Trim().Equals("") ||  Rate.Text.Trim().Equals("") || DiscountTB.Text.Trim().Equals("") || ActualRateTB.Text.Trim().Equals(""))
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Reservation Error", "alert('Please fill all fields to Reservation Process')", true);

                OrderDetails.FieldI38 = 0;//Tenative booking message purpose
            }
            else
            {
                try
                {
                    CeylonAdaptor aBook = new CeylonAdaptor();


                    aBook.FieldI1 = OrderDetails.FieldI3;// FK_Customer ID
                    aBook.FieldI2 = OrderDetails.FieldI2;//Fk_AgentID
                    aBook.FieldI3 = EventsArray[EventTypeDropDown.SelectedIndex].FieldI1;
                    OrderDetails.FieldI13 = EventsArray[EventTypeDropDown.SelectedIndex].FieldI1; //FK_EventID   
                    Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
                    aBook.FieldS1 = ContactNameTB.Text;
                    aBook.FieldS2 = Contact.Text;
                    aBook.FieldS3 = ContactAdressTB.Text;
                    if (Couple_Name.Text.Length == 0)
                    {

                        aBook.FieldS4 = "NA";
                    }
                    else
                    {
                        aBook.FieldS4 = Couple_Name.Text;
                    }

                    if (SpecialNoteTB.Text.Trim().Equals(""))
                    {
                        aBook.FieldS5 = "NA";
                    }
                    else
                    {
                        aBook.FieldS5 = SpecialNoteTB.Text;
                    }

                    aBook.FieldS6 = VenueTB.Text;
                    aBook.FieldS7 = CustomerNameTB.Text;
                    aBook.FieldS8 = "Not Confirmed";    // Status              
                    aBook.FieldS9 = EventTypeDropDown.SelectedValue.Trim();//event type
                    aBook.FieldS10 = DropDownList2.SelectedValue.Trim();   //event time
                    aBook.FieldDate1 = OrderDetails.FieldDate2; //event date         
                    aBook.FieldI4 = Convert.ToInt32(decimal.Parse(Rate.Text).ToString());//Event Price
                    //aBook.FieldI4 = Convert.ToInt32(Convert.ToDecimal(Rate.Text.ToString()));//Event Price
                    aBook.FieldDate2 = DateTime.Now; //Confirmed Date            
                    aBook.FieldI5 = OrderDetails.FieldI12;//Initial Booking By
                    aBook.FieldI6 = 0;//Person who confirmed the booking with a Advance Payment 


                    if (DiscountTB.Text == "0.00" || DiscountTB.Text == "0" || DiscountTB.Text == "")
                    {
                        aBook.FieldI7 = 0;
                    }
                    else
                    {
                        aBook.FieldI7 = Convert.ToInt32(DiscountTB.Text);//discount rate 

                       // aBook.FieldI7 = Convert.ToInt32(Convert.ToDecimal(DiscountTB.Text.ToString()));//discount Price

                    }
                    Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);

                    OrderDetails.FieldS19 = EventTypeDropDown.SelectedValue.Trim();
                    OrderDetails.FieldS29 = DropDownList2.SelectedValue.Trim();
                    OrderDetails.FieldDate10 = aBook.FieldDate2;
                    Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);

                    // aManager_DAO.AddABooking(aBook);
                    OrderDetails.FieldI11 = aManager_DAO.AddABooking(aBook);


                    CeylonAdaptor aRate = new CeylonAdaptor();
                    aRate.FieldI1 = OrderDetails.FieldI11;// Event ID
                    aRate.FieldS1 = ActualRateTB.Text;//actual rate
                    aManager_DAO.InsertToEventRateTable(aRate);


                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + EventID + "')", true);
                    OrderDetails.FieldI38 = 1;
                    Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
                    

                    Response.Redirect("~/BookingPages/TentativeBookings.aspx?ssid=" + SessionID.ToString());
                }
                catch
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Reservation Error", "alert('Error!! Please Check Details Formats')", true);

                }




            }

        }



        protected void EventTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
               
               // Rate.ReadOnly = true;

               // Rate.Text = decimal.Parse(EventsArray[EventTypeDropDown.SelectedIndex].FieldS3).ToString("#,#");

                


                if (EventTypeDropDown.SelectedValue.ToString().Trim() == "Wedding" || EventTypeDropDown.SelectedValue.ToString().Trim() == "Home Coming" || EventTypeDropDown.SelectedValue.ToString().Trim() == "Engagement" || EventTypeDropDown.SelectedValue.ToString().Trim() == "Wedding Annivesary Party")
                {
                    cplNameLabel.Visible = true;
                    Couple_Name.Visible = true;
                }
                else
                {
                    cplNameLabel.Visible = false;
                    Couple_Name.Visible = false;
                }


            }
            catch (Exception EX)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('" + EX.Message + "')", true);
                Rate.Text = "Error";
            }
        }

        protected void Rate_TextChanged(object sender, EventArgs e)
        {
            //if (Convert.ToDecimal(EventsArray[EventTypeDropDown.SelectedIndex].FieldS3) > Convert.ToDecimal(Rate.Text))
            //{
            //    Decimal discount;
            //    discount = Convert.ToDecimal(EventsArray[EventTypeDropDown.SelectedIndex].FieldS3) - Convert.ToDecimal(Rate.Text);
            //    DiscountTB.Text = decimal.Parse(Convert.ToString(discount)).ToString("#,#");
            //}


            //if (Convert.ToDecimal(EventsArray[EventTypeDropDown.SelectedIndex].FieldS3) <= Convert.ToDecimal(Rate.Text))
            //{
            //    DiscountTB.Text = "0.00";
            //}
        }

        protected void DiscountTB_TextChanged(object sender, EventArgs e)
        {
            if(ActualRateTB.Text=="0"|| ActualRateTB.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "alert('Please Enter Contract Actual Rate')", true);
            }
            else
            {
                Rate.Text = Convert.ToString(Convert.ToInt32(ActualRateTB.Text) - Convert.ToInt32(DiscountTB.Text));
            }
           
        }
    }
}