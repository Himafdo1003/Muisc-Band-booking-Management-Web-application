using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using ArtistManagerApp_ClassLibrary.DAOs;
using ArtistManagerApp_ClassLibrary.BusinessObjects;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtistManagerApp
{
    public partial class StartPage : System.Web.UI.Page
    {
        private int SessionID;
        private Manager_DAO aManager_DAO;
        private string DataSource;
        private string LocalDataSource;
        private CeylonAdaptor OrderDetails;
        private CeylonMiniAdaptor[] CheckAmount;
        private CeylonAdaptor[] SaleDetailsArray;
        private List<CeylonAdaptor> ORList;
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                getComputerName();
                aManager_DAO = new Manager_DAO();


                /***** Creating Unqiue SessionID And Details ****/
                DateTime Today = DateTime.Today;
                string zeroBased = Today.ToString("yy-MM-dd");
                zeroBased = Regex.Replace(zeroBased, @"[^0-9]", "") + "001";
                int CheckSessionID = Convert.ToInt32(zeroBased);

                CheckAmount = aManager_DAO.GetSessionInformation();
                string DateCheck = DateTime.Now.ToShortDateString();
                DateTime NewDate = Convert.ToDateTime(DateCheck);
                DateCheck = NewDate.ToString("MM/dd/yyyy");

                if (DateCheck == CheckAmount[0].FieldS1)
                {
                    CeylonMiniAdaptor aUpdate = new CeylonMiniAdaptor();
                    aUpdate.FieldD1 = CheckAmount[0].FieldD1 + 1;
                    aUpdate.FieldS1 = DateCheck;
                    SessionID = Convert.ToInt32(aUpdate.FieldD1);
                    aManager_DAO.UpdateSessionID(aUpdate);
                }
                else
                {
                    CeylonMiniAdaptor aUpdate = new CeylonMiniAdaptor();
                    aUpdate.FieldD1 = CheckSessionID;
                    aUpdate.FieldS1 = DateCheck;
                    SessionID = Convert.ToInt32(aUpdate.FieldD1);
                    aManager_DAO.UpdateSessionID(aUpdate);

                }


                OrderDetails = new CeylonAdaptor();
                OrderDetails.FieldI1 = SessionID;
                OrderDetails.FieldI11 = 0;
                OrderDetails.FieldDate1 = DateTime.Now;
                OrderDetails.FieldD10 = 0;
                OrderDetails.FieldD5 = 0;
                OrderDetails.FieldD6 = 0;
                OrderDetails.FieldD7 = 0;
                OrderDetails.FieldD8 = 0;
                OrderDetails.FieldD9 = 0;



                Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);

                ORList = new List<CeylonAdaptor>();
                Session["ORList" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(ORList);

                
            }
            catch (Exception Ex)
            {
                Response.Write("Gravity Server Not Found");
            }
        }
        public void getComputerName()
        {
            LocalDataSource = System.Environment.MachineName;
        }//End of getComputerName() method    

        protected void StrtButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserEnter.aspx?ssid=" + SessionID.ToString());
        }
        protected void BackBtn(object sender, EventArgs e)
        {
            Response.Redirect("LandingPage.aspx");
        }
        
    }
}