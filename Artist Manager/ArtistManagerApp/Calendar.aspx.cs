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
    public partial class Calendar : System.Web.UI.Page
    {
        private int FoodHavingType;
        private int test;
        private int SessionID;
        private Manager_DAO aManager_DAO;
        private string DataSource;
        private string LocalDataSource;
        private CeylonAdaptor OrderDetails;
        DataTable dt = new DataTable();
        private CeylonAdaptor[] CalendarSelectedData;
        [System.ComponentModel.Bindable(true)]
        public DateTime SelectedDate { get; set; }
        public event System.Web.UI.WebControls.MonthChangedEventHandler VisibleMonthChanged;


        private CeylonMiniAdaptor[] CalanderData;
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

                SearchTextBox.Visible = false;
                //ShowDetailsBtn.Visible = false;
                //GridView2.Visible = false;
                EventTypeLabel.Text = "NA";

                // Calendar text Adding
                dt.Columns.Add("EventName");
                dt.Columns.Add("EventTime");

                dt.Columns.Add("Date", typeof(DateTime));
                CalanderData = aManager_DAO.GetCalendarDate();
                DataTable CalendarData = new DataTable();

                for (int i = 0; i < CalanderData.Length; i++)
                {

                    dt.Rows.Add(CalanderData[i].FieldS1, CalanderData[i].FieldS2, Convert.ToDateTime(CalanderData[i].FieldDate1));


                }

            }
            catch (Exception Ex)
            {
                Response.Redirect("StartPage.aspx");
            }
        }
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {

            if (e.Day.IsWeekend)
            {
                e.Cell.BackColor = System.Drawing.Color.PaleVioletRed;

            }

            foreach (DataRow row in dt.Rows)
            {

                if (Convert.ToDateTime(e.Day.Date) == Convert.ToDateTime(row["Date"]))
                {

                    //Adding Text to Calendar from DB
                    Literal text6 = new Literal();
                    text6.Text = "<br/> ";
                    Literal text = new Literal();
                    text.Text = row["EventTime"].ToString();
                    Literal text3 = new Literal();
                    text3.Text = "<br/> ";
                    Literal text2 = new Literal();
                    text2.Text = row["EventName"].ToString();
                    Literal text4 = new Literal();
                    text4.Text = "<br/> <br/>";
                    Literal text5 = new Literal();
                    text5.Text = "";


                    text6.Visible = true;
                    e.Cell.Controls.Add(text6);
                    text.Visible = true;
                    e.Cell.Controls.Add(text);
                    text3.Visible = true;
                    e.Cell.Controls.Add(text3);
                    text2.Visible = true;
                    e.Cell.Controls.Add(text2);
                    text4.Visible = true;
                    e.Cell.Controls.Add(text4);
                    text5.Visible = true;
                    e.Cell.Controls.Add(text5);
                   

                    if (row["EventName"].ToString() == "Wedding")
                    {
                        e.Cell.BackColor = System.Drawing.Color.DodgerBlue;
                    }

                    if (row["EventName"].ToString() == "Home Coming")
                    {
                        e.Cell.BackColor = System.Drawing.Color.Firebrick;
                    }
                    if (row["EventName"].ToString() == "Engagement")
                    {
                        e.Cell.BackColor = System.Drawing.Color.Firebrick;
                    }
                    if (row["EventName"].ToString() == "Corporate Events")
                    {
                        e.Cell.BackColor = System.Drawing.Color.MediumSeaGreen;
                    }

                    if (row["EventName"].ToString() == "Dinner Dance")
                    {
                        e.Cell.BackColor = System.Drawing.Color.MediumSeaGreen;
                    }
                    if (row["EventName"].ToString() == "Birthday Party")
                    {
                        e.Cell.BackColor = System.Drawing.Color.MediumSeaGreen;
                    }
                    if (row["EventName"].ToString() == "Wedding Annivesary Party ")
                    {
                        e.Cell.BackColor = System.Drawing.Color.MediumSeaGreen;
                    }

                    if (row["EventName"].ToString() == "Concerts-70s")
                    {
                        e.Cell.BackColor = System.Drawing.Color.Gold;
                    }
                    if (row["EventName"].ToString() == "Concerts-Thaala")
                    {
                        e.Cell.BackColor = System.Drawing.Color.Gold;
                    }
                    if (row["EventName"].ToString() == "Concerts-MS")
                    {
                        e.Cell.BackColor = System.Drawing.Color.Gold;
                    }

                    if (row["EventName"].ToString() == "Practice")
                    {
                        e.Cell.BackColor = System.Drawing.Color.DimGray;
                    }
                    if (row["EventName"].ToString() == "Other")
                    {
                        e.Cell.BackColor = System.Drawing.Color.White;
                    }

                    if (row["EventName"].ToString() == "Concert-General")
                    {
                        e.Cell.BackColor = System.Drawing.Color.Gold;
                    }


                }
                else
                {

                }
            }

            //Hide next month dates in current month
            if (e.Day.IsOtherMonth)
            {
                e.Cell.Controls.Clear();
                e.Cell.Text = string.Empty;
                e.Cell.BackColor = System.Drawing.Color.Transparent;
            }

        }

        public void getComputerName()
        {
            LocalDataSource = System.Environment.MachineName;
        }

        public void getCalendarSelectedData()
        {


            if (calendar.SelectedDate.Date == null)

            {

                

            }

            else

            {

                try
                {
                    EventDateLabel.Text = "NA";
                    EventTimeLabel.Text = "NA";
                    EventTypeLabel.Text = "NA";
                    CustomerNameLabel.Text = "NA";
                    ContactNameLabel.Text = "NA";
                    ContactNoLabel.Text = "NA";
                    AddressLabel.Text = "NA";
                    VenueLabel.Text = "NA";
                    CoupleNameLabel.Text = "NA";
                    SpecialNoteLabel.Text = "NA";



                    CalendarSelectedData = aManager_DAO.GetCalendarDetails(SearchTextBox.Text.Trim());
                    DataTable aTentativeBook = new DataTable();

                    aTentativeBook.Columns.Add(new DataColumn("Event Date", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Event Time", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Event Type", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Special Note", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Contact Phone", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Customer Name", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Venue", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Couple Name", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("Status", typeof(string)));
                    aTentativeBook.Columns.Add(new DataColumn("EID", typeof(string)));



                    for (int i = 0; i < CalendarSelectedData.Length; i++)
                    {
                        //aTentativeBook.Rows.Add(
                        //  CalendarSelectedData[i].FieldDate1, CalendarSelectedDa]ta[i].FieldS10, CalendarSelectedData[i].FieldS9, CalendarSelectedData[i].FieldS5, CalendarSelectedData[i].FieldS2, CalendarSelectedData[i].FieldS7,

                        //    CalendarSelectedData[i].FieldS6, CalendarSelectedData[i].FieldS4, CalendarSelectedData[i].FieldS8, CalendarSelectedData[i].FieldI1);
                        //OrderDetails.FieldDate10 = CalendarSelectedData[i].FieldDate1;
                        EventDateLabel.Text = (Convert.ToDateTime(CalendarSelectedData[i].FieldDate1)).ToShortDateString();
                        EventTimeLabel.Text = CalendarSelectedData[i].FieldS10;
                        EventTypeLabel.Text = CalendarSelectedData[i].FieldS9;
                        CustomerNameLabel.Text = CalendarSelectedData[i].FieldS7;
                        ContactNameLabel.Text = CalendarSelectedData[i].FieldS1;
                        ContactNoLabel.Text = CalendarSelectedData[i].FieldS2;
                        AddressLabel.Text = CalendarSelectedData[i].FieldS3;
                        VenueLabel.Text = CalendarSelectedData[i].FieldS6;
                        CoupleNameLabel.Text = CalendarSelectedData[i].FieldS4;
                        SpecialNoteLabel.Text = CalendarSelectedData[i].FieldS5;





                        //OrderDetails.FieldS20 = Convert.ToString(CalendarSelectedData[i].FieldDate1);
                        //OrderDetails.FieldS21 = CalendarSelectedData[i].FieldS10;
                        //OrderDetails.FieldS22 = CalendarSelectedData[i].FieldS9;
                        //OrderDetails.FieldS23 = CalendarSelectedData[i].FieldS7;
                        //OrderDetails.FieldS24 = CalendarSelectedData[i].FieldS1;
                        //OrderDetails.FieldS25 = CalendarSelectedData[i].FieldS2;
                        //OrderDetails.FieldS26 = CalendarSelectedData[i].FieldS3;
                        //OrderDetails.FieldS27 = CalendarSelectedData[i].FieldS6;
                        //OrderDetails.FieldS28 = CalendarSelectedData[i].FieldS4;
                        //OrderDetails.FieldS29 = CalendarSelectedData[i].FieldS5;

                        Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);

                      

                    }



                    //GridView2.DataSource = aTentativeBook;
                    //GridView2.DataBind();


                }
                catch (Exception Ex)
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);

                }

            }


           


        }


        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdSRPage.aspx?ssid=" + SessionID.ToString());
        }

        protected void calendar_SelectionChanged(object sender, EventArgs e)
        {
            if (calendar.SelectedDate.Date == null)

            {

                

            }

            else

            {

                SearchTextBox.Text = calendar.SelectedDate.ToString();

                getCalendarSelectedData();


                string message1 = "Event Date -";
                string message2 = EventDateLabel.Text;

                string message3 = "Event Time -";
                string message4 = EventTimeLabel.Text;

                string message5 = "Event Type -";
                string message6 = EventTypeLabel.Text;

                string message7 = "Customer Name -";
                string message8 = CustomerNameLabel.Text;

                string message9 = "Contact Name -";
                string message10 = ContactNameLabel.Text;

                string message11 = "Contact No -";
                string message12 = ContactNoLabel.Text;

                string message13 = "Address -";
                string message14 = AddressLabel.Text;

                string message15 = "Venue -";
                string message16 = VenueLabel.Text;

                string message17 = "Couple Name -";
                string message18 = CoupleNameLabel.Text;

                string message19 = "Special Note -";
                string message20 = SpecialNoteLabel.Text;


                ScriptManager.RegisterStartupScript((sender as Control), this.GetType(), "Popup", "ShowPopup('" + OrderDetails.FieldS20 + OrderDetails.FieldS21 + OrderDetails.FieldS22 +
                OrderDetails.FieldS23 + OrderDetails.FieldS24 + OrderDetails.FieldS25 + OrderDetails.FieldS26 + OrderDetails.FieldS27 + OrderDetails.FieldS28 + OrderDetails.FieldS2 + "');", true);


            }



            //}

        }


        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }





        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Show_Details_Click(object sender, EventArgs e)
        {
            getCalendarSelectedData();
            //  GridView2.Visible = true;

        }

        protected void calendar_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {


        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void btnShowPopup_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Error')", true);
            // ScriptManager.RegisterStartupScript((sender as Control), this.GetType(), "Popup", "ShowPopup('" + OrderDetails.FieldS20 + OrderDetails.FieldS21 + OrderDetails.FieldS22 +
            //OrderDetails.FieldS23 + OrderDetails.FieldS24 + OrderDetails.FieldS25 + OrderDetails.FieldS26 + OrderDetails.FieldS27 + OrderDetails.FieldS28 + OrderDetails.FieldS2 + "');", true);

        }
    }
}