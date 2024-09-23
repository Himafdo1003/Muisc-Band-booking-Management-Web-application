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


namespace ArtistManagerApp
{
    public partial class UserEnter : System.Web.UI.Page
    {

        private int FoodHavingType;
        private int SessionID;
        private Manager_DAO aManager_DAO;
        private string DataSource;
        private string LocalDataSource;
        private CeylonMiniAdaptor[] StaffArray;
        private List<CeylonAdaptor> ORList;
        private string WaiterName;
        private int WaiterID;
        private string EmpoyeeType;
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

                OrderDetails = new CeylonAdaptor();

                StaffArray = aManager_DAO.GetAllAvailableStaff();

                ORList = new List<CeylonAdaptor>();
                ORList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CeylonAdaptor>>(Session["ORList" + SessionID + ""].ToString());


                CodeTextBox.Focus();

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
            Response.Redirect("~/StartPage.aspx?ssid=" + SessionID.ToString());
        }



        protected void Go_Click(object sender, EventArgs e)
        {

            try
            {
                if (CodeTextBox.Text.Trim().Equals(""))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "No Staff Code Entered...!!!", "alert('Please Enter Valid Staff PassCode and Continue')", true);

                }
                else
                {
                    int CheckUser = 0;
                    CeylonMiniAdaptor[] UserArray = aManager_DAO.CheckUser(CodeTextBox.Text);
                    CheckUser = UserArray[0].FieldI1;


                    if (CheckUser > 0)
                    {
                        if (UserArray[0].FieldS2.Equals("Band Member"))
                        {

                            OrderDetails.FieldI10 = 1;
                            Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
                            Response.Redirect("~/AdSRPage.aspx?ssid=" + SessionID.ToString());
                        }
                        else if (UserArray[0].FieldS2.Equals("Manager"))
                        {
                            OrderDetails.FieldI12 = CheckUser;
                            OrderDetails.FieldI10 = 2;
                            Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
                            Response.Redirect("~/AdSRPage.aspx?ssid=" + SessionID.ToString());

                        }
                        else if (UserArray[0].FieldS2.Equals("Admin"))

                        {

                            OrderDetails.FieldI12 = CheckUser;
                            OrderDetails.FieldI10 = 3;
                            Session["" + SessionID + ""] = Newtonsoft.Json.JsonConvert.SerializeObject(OrderDetails);
                            Response.Redirect("~/AdSRPage.aspx?ssid=" + SessionID.ToString());



                        }

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Please Enter Valid Staff PassCode and Continue", "alert('Please Enter Valid Staff PassCode and Continue')", true);

                    }

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "No Staff Code Entered...!!!", "alert('Please Enter Valid Staff PassCode and Continue')", true);
            }
        }

        protected void CodeTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}