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
    public partial class LandingPage : System.Web.UI.Page
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

                
                aManager_DAO = new Manager_DAO();
                FoodHavingType = 0;

               
                      
               // EventTypeLabel.Text = "NA";

                // Calendar text Adding
                dt.Columns.Add("EventName");
                dt.Columns.Add("EventTime");

                dt.Columns.Add("Date", typeof(DateTime));
                CalanderData = aManager_DAO.GetCalendarDate();
                DataTable CalendarData = new DataTable();

                for (int i = 0; i < CalanderData.Length; i++)
                {

                   dt.Rows.Add(CalanderData[i].FieldS1, CalanderData[i].FieldS2, Convert.ToDateTime(CalanderData[i].FieldDate1));

                   // dt.Rows.Add("Booked");


                }

            }
            catch (Exception Ex)
            {
                Response.Redirect("StartPage.aspx");
            }
        }
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            e.Day.IsSelectable = false;
            if (e.Day.IsWeekend)
            {
                e.Cell.BackColor = System.Drawing.Color.LightCyan;

            }

            foreach (DataRow row in dt.Rows)
            {

                if (Convert.ToDateTime(e.Day.Date) == Convert.ToDateTime(row["Date"]))
                {

                    //Adding Text to Calendar from DB
                    Literal text6 = new Literal();
                    text6.Text = "<br/> <br/> ";
                    Literal text = new Literal();
                    text.Text = row["EventTime"].ToString();
                    Literal text3 = new Literal();
                    text3.Text = "<br/> ";
                    Literal text2 = new Literal();
                    text2.Text = row["EventName"].ToString();
                    //Literal text4 = new Literal();
                    //text4.Text = "<br/> <br/>";
                    //Literal text5 = new Literal();
                    //text5.Text = "Booked";


                    text6.Visible = true;
                    e.Cell.Controls.Add(text6);
                    text.Visible = true;
                    e.Cell.Controls.Add(text);
                    text3.Visible = true;
                   e.Cell.Controls.Add(text3);
                    text2.Visible = true;
                    e.Cell.Controls.Add(text2);
                    //text4.Visible = true;
                    //e.Cell.Controls.Add(text4);
                    text2.Visible = true;
                    e.Cell.Controls.Add(text2);


                    if (row["EventName"].ToString() == "" || row["EventName"].ToString() == null)
                    {
                        //e.Cell.BackColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#EE5106");
                    }

                  


                }
                else
                {

                }
               
            }
            if (Convert.ToDateTime(e.Day.Date) == DateTime.Now.Date)
            {

                //Adding Text to Calendar from DB
                Literal text6 = new Literal();
                text6.Text = "<br/> <br/> ";

                Literal text5 = new Literal();
                text5.Text = "Today";


                text6.Visible = true;
                e.Cell.Controls.Add(text6);

                text5.Visible = true;
                e.Cell.Controls.Add(text5);

            }

            //Hide next month dates in current month
            if (e.Day.IsOtherMonth)
            {
                e.Cell.Controls.Clear();
                e.Cell.Text = string.Empty;
                e.Cell.BackColor = System.Drawing.Color.Transparent;
            }

        }

        protected void calendar_SelectionChanged(object sender, EventArgs e)
        {
            //if (calendar.SelectedDate.Date == null)

            //{



            //}

            //else

            //{

            //    SearchTextBox.Text = calendar.SelectedDate.ToString();

            //    getCalendarSelectedData();


            //    string message1 = "Event Date -";
            //    string message2 = EventDateLabel.Text;

            //    string message3 = "Event Time -";
            //    string message4 = EventTimeLabel.Text;

            //    string message5 = "Event Type -";
            //    string message6 = EventTypeLabel.Text;

            //    string message7 = "Customer Name -";
            //    string message8 = CustomerNameLabel.Text;

            //    string message9 = "Contact Name -";
            //    string message10 = ContactNameLabel.Text;

            //    string message11 = "Contact No -";
            //    string message12 = ContactNoLabel.Text;

            //    string message13 = "Address -";
            //    string message14 = AddressLabel.Text;

            //    string message15 = "Venue -";
            //    string message16 = VenueLabel.Text;

            //    string message17 = "Couple Name -";
            //    string message18 = CoupleNameLabel.Text;

            //    string message19 = "Special Note -";
            //    string message20 = SpecialNoteLabel.Text;


            //    ScriptManager.RegisterStartupScript((sender as Control), this.GetType(), "Popup", "ShowPopup('" + OrderDetails.FieldS20 + OrderDetails.FieldS21 + OrderDetails.FieldS22 +
            //    OrderDetails.FieldS23 + OrderDetails.FieldS24 + OrderDetails.FieldS25 + OrderDetails.FieldS26 + OrderDetails.FieldS27 + OrderDetails.FieldS28 + OrderDetails.FieldS2 + "');", true);


            //}



            //}

        }
        protected void calendar_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {


        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (NameTB.Text.Trim().Equals("") || TeleTB.Text.Trim().Equals("") ||
            EmailTB.Text.Trim().Equals("") || DetailsTB.Text.Trim().Equals(""))
            {
                
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('Please fill all fields before Submit')", true);

            }
            else
            {

                CeylonAdaptor aCustomer = new CeylonAdaptor();
                aCustomer.FieldS1 = NameTB.Text;
                aCustomer.FieldS2 = TeleTB.Text;
                aCustomer.FieldS3 = EmailTB.Text;
                aCustomer.FieldS4 = DetailsTB.Text;               
                aCustomer.FieldDate1 = DateTime.Now;
                aManager_DAO.InsertToRequestTable(aCustomer);
               
                NameTB.Text = "";
                TeleTB.Text = "";
                EmailTB.Text = "";
                DetailsTB.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Successfully Sent ", "alert('Request Sent Successfully')", true);


            }

        }
    }
}