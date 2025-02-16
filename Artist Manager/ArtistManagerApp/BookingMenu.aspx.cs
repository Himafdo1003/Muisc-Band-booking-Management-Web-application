﻿using System;
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
    public partial class BookingMenu : System.Web.UI.Page
    {
        private int FoodHavingType;
        private int SessionID;
        private Manager_DAO aManager_DAO;
        private string DataSource;
        private string LocalDataSource;
        private CeylonAdaptor OrderDetails;
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

        protected void Tentative_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BookingPages/TentativeBookings.aspx?ssid=" + SessionID.ToString());
        }
        protected void Confirmed_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BookingPages/ConfirmedBookings.aspx?ssid=" + SessionID.ToString());
        }
        protected void History_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BookingPages/BookingHistory.aspx?ssid=" + SessionID.ToString());
        }
        protected void Cancelled_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BookingPages/CancelledBookings.aspx?ssid=" + SessionID.ToString());
        }

    }
}