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
    public partial class ViaAgent : System.Web.UI.Page
    {

        private int SessionID;
        private Manager_DAO aManager_DAO;
        private string DataSource;
        private string LocalDataSource;
        private CeylonAdaptor OrderDetails;
        private CeylonMiniAdaptor[] AgentsArray;



        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {


                getComputerName();

                aManager_DAO = new Manager_DAO();

                SessionID = Convert.ToInt32(Request.QueryString["ssid"]);
                OrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<CeylonAdaptor>(Session["" + SessionID + ""].ToString());
                OrderDetails.FieldI3 = 0;
                //AgentsArray = aManager_DAO.AgentType();


                //if (!IsPostBack)
                //{
                //    for (int i = 0; i < AgentsArray.Length; i++)
                //    {

                //        AgentTypeDropDown.Items.Add(AgentsArray[i].FieldS1);



                //    }

                //}
                OrderDetails.FieldI2 = 1;
                Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
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
            Response.Redirect("~/ReservationMenu.aspx?ssid=" + SessionID.ToString());
        }



        protected void Go_btn_Click(object sender, EventArgs e)
        {
            //AgentsArray = aManager_DAO.EventType();
            // OrderDetails.FieldI2= AgentsArray[AgentTypeDropDown.SelectedIndex].FieldI1;

            if (string.IsNullOrWhiteSpace(AgentNameTB.Text) )
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Related Details')", true);
            }
            else
            {

                OrderDetails.FieldS39 = AgentNameTB.Text;
                Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
                Response.Redirect("~/ConfirmBook.aspx?ssid=" + SessionID.ToString());
            }

        }

        protected void AgentTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Customer Registration Error", "alert('" + OrderDetails.FieldI2 + "')", true);

        }
    }
}