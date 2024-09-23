using ArtistManagerApp_ClassLibrary.BusinessObjects;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ArtistManagerApp_ClassLibrary.DAOs
{
    public class Manager_DAO
    {
        // Creates variables for Connect to the database,return messages and ect
        private readonly byte _DataBase_Error_Code;
        private string _DataBase_Result_Message;
        private ConnectionStringSettings _aConnectionString;
        private SqlConnection _aSqlConnection;
        private SqlCommand _aSqlCommand;
        private SqlDataReader _aSqlReader;
        private string DataSource;
        private string LocalDataSource;

        /***** Define Properties *******/
        public byte DataBase_Error_Code

        {
            get
            {
                return _DataBase_Error_Code;
            }
        } // end of DataBase_Error_Code
        public string DataBase_Result_Mesaage
        {
            get
            {
                return _DataBase_Result_Message;
            }
        } // end of DataBase_Result_Mesaage
        public ConnectionStringSettings aConnectionString
        {
            set
            {
                _aConnectionString = value;
            }
            get
            {
                return _aConnectionString;
            }
        } // end of aConnectionString
        public SqlConnection aSqlConnection
        {
            set
            {
                _aSqlConnection = value;
            }

            get
            {
                return _aSqlConnection;
            }
        } // end of aOleDbConnection
        public SqlCommand aSqlCommand
        {
            set
            {
                _aSqlCommand = value;
            }
            get
            {
                return _aSqlCommand;
            }
        } // end of aOleDbCommand
        public SqlDataReader aSqlDataReader
        {
            set
            {
                _aSqlReader = value;
            }
            get
            {
                return _aSqlReader;
            }

        } // end of aOleDbReader
        public Manager_DAO()
        {
            _DataBase_Error_Code = 255;
            _DataBase_Result_Message = "";
            getComputerName();

          
            DataSource = "Data Source = " + LocalDataSource + "; Initial Catalog = GravityDB; Integrated Security = True";

        }//End of Defult Constructor 

        public void getComputerName()
        {
            LocalDataSource = System.Environment.MachineName;
        }//End of getComputerName() method    

        //****************  All the Data Read Methods from the Database Using Parameters ************************//
        public CeylonMiniAdaptor[] CheckWaiterAvailibility(string SearchParameter)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();
                aSqlCommand = new SqlCommand("CheckWaiterAvailibility", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();

                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    ListOfCategory.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of  Method
        public CeylonMiniAdaptor[] CheckSuperAvailibility(string SearchParameter)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();
                aSqlCommand = new SqlCommand("CheckSuperAvailibility", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();

                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    ListOfCategory.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of  Method
        public int PoolSorting()
        {
            // Just read the details of due payments
            try
            {
                int PRID = 0;

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Create command to get the all centers into the arraylist
                aSqlCommand = new SqlCommand("PoolSorting", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {

                    PRID = aSqlDataReader.GetInt32(0);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return (PRID);

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (0);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public bool UpdatePoolID(CeylonMiniAdaptor aObject)
        {
            // Just read the details of due payments
            try
            {
                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Create command to get the all centers into the arraylist

                aSqlCommand = new SqlCommand("UpdatePoolIDCounter", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@Test1", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Details", SqlDbType.VarChar);
                aSqlCommand.Parameters["@Test1"].Value = aObject.FieldD1;
                aSqlCommand.Parameters["@Details"].Value = aObject.FieldS1;

                aSqlCommand.ExecuteNonQuery();
                return (true);
            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (false);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of GenerateAvailableBalanceByCustomerID(int SearchParameter, string DataSource) Method
        public CeylonMiniAdaptor[] GetPoolIDInfo()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfItemsForPurchase = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetCurrentPoolID", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();

                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    ListOfItemsForPurchase.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfItemsForPurchase.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of CeylonMiniAdaptor[] GetTestTotal(string SearchParameter, string DataSource) Method
        public decimal GetCurrentPoolID()
        {
            // Just read the details of due payments
            try
            {
                decimal AvailableBalance = 0;

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Create command to get the all centers into the arraylist
                aSqlCommand = new SqlCommand("GetNextPoolID", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {

                    AvailableBalance = aSqlDataReader.GetDecimal(0);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return (AvailableBalance);

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (0);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public decimal GetNextTakeawayID()
        {
            // Just read the details of due payments
            try
            {
                decimal AvailableBalance = 0;

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Create command to get the all centers into the arraylist
                aSqlCommand = new SqlCommand("GetNextTakeAwayID", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {

                    AvailableBalance = aSqlDataReader.GetDecimal(0);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return (AvailableBalance);

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (0);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonAdaptor[] GetAllPendingOrdersItemsByTableID(string SearchParameter)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOFCustomer = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();


                // Check the Parametter is int or string and select the appropriate statement into the arraylist
                aSqlCommand = new SqlCommand("GetAllPendingOrdersItemsByTableIDM", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aCustomerTable = new CeylonAdaptor();

                    aCustomerTable.FieldS1 = aSqlDataReader.GetString(0);
                    aCustomerTable.FieldS2 = aSqlDataReader.GetString(1);
                    aCustomerTable.FieldS3 = aSqlDataReader.GetString(2);
                    aCustomerTable.FieldD1 = aSqlDataReader.GetDecimal(3);
                    aCustomerTable.FieldD2 = aSqlDataReader.GetDecimal(4);
                    aCustomerTable.FieldD3 = aSqlDataReader.GetDecimal(5);
                    aCustomerTable.FieldD4 = aSqlDataReader.GetDecimal(6);
                    aCustomerTable.FieldD5 = aSqlDataReader.GetDecimal(7);
                    aCustomerTable.FieldI1 = aSqlDataReader.GetInt32(8);
                    aCustomerTable.FieldD6 = aSqlDataReader.GetDecimal(9);
                    aCustomerTable.FieldD7 = aSqlDataReader.GetDecimal(10);
                    aCustomerTable.FieldD8 = aSqlDataReader.GetDecimal(11);
                    ListOFCustomer.Add(aCustomerTable);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOFCustomer.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of CeylonAdaptor[] GetAllCustomerByParaForSale(string SearchParameter, string DataSource) Method
        public CeylonAdaptor[] GetAllCustomerByParaForSale(string SearchParameter)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOFCustomer = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();


                aSqlCommand = new SqlCommand("GetAllCustomerByParaForSale", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aCustomerTable = new CeylonAdaptor();

              

                    aCustomerTable.FieldI1 = aSqlDataReader.GetInt32(0);//iD
                    aCustomerTable.FieldS1 = aSqlDataReader.GetString(1);//name                  
                    aCustomerTable.FieldS3 = aSqlDataReader.GetString(2);//address
                    aCustomerTable.FieldS4 = aSqlDataReader.GetString(3);//phone
                    aCustomerTable.FieldS5 = aSqlDataReader.GetString(4);//nic
                    aCustomerTable.FieldS6 = aSqlDataReader.GetString(5);//email
                    aCustomerTable.FieldS7 = aSqlDataReader.GetString(6);//type
                    aCustomerTable.FieldDate1 = aSqlDataReader.GetDateTime(7);
                    
                    ListOFCustomer.Add(aCustomerTable);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOFCustomer.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of CeylonAdaptor[] GetAllCustomerByParaForSale(string SearchParameter, string DataSource) Method
        public CeylonMiniAdaptor[] GetAllRandBItemsByPara(string SearchParameter)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfPastryItems = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Check the Parametter is int or string and select the appropriate statement into the arraylist
                if (Regex.IsMatch(SearchParameter, @"^\d+$"))
                {
                    aSqlCommand = new SqlCommand("GetAllRandBItemsByParaInt", aSqlConnection);

                }
                else
                {
                    aSqlCommand = new SqlCommand("GetAllRandBItemsByPara", aSqlConnection);

                }

                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();

                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(2);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(3);
                    aObjectForReports.FieldI4 = aSqlDataReader.GetInt32(4);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(5);
                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(6);
                    aObjectForReports.FieldD2 = aSqlDataReader.GetDecimal(7);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(8);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(9);
                    aObjectForReports.FieldI5 = aSqlDataReader.GetInt32(10);
                    aObjectForReports.FieldD3 = aSqlDataReader.GetDecimal(11);


                    ListOfPastryItems.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfPastryItems.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of ItemTable[]  GetAllItemsByPara(string SearchParameter, string DataSource) Method
        public CeylonMiniAdaptor[] GetAllRandBItems()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfPastryItems = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllRandBItems", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();

                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(2);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(3);
                    aObjectForReports.FieldI4 = aSqlDataReader.GetInt32(4);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(5);
                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(6);
                    aObjectForReports.FieldD2 = aSqlDataReader.GetDecimal(7);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(8);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(9);
                    aObjectForReports.FieldI5 = aSqlDataReader.GetInt32(10);
                    aObjectForReports.FieldD3 = aSqlDataReader.GetDecimal(11);


                    ListOfPastryItems.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfPastryItems.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of  GetAllPastryItems(string DataSource) Method
        public CeylonMiniAdaptor[] GetAllRandBForSalesByMenu(string SearchParameter)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfUsers = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllItemForRandBSalesByMenu", aSqlConnection);

                // Create command to get the all centers into the arraylist

                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor PastryItems = new CeylonMiniAdaptor();
                    PastryItems.FieldI1 = aSqlDataReader.GetInt32(0);
                    PastryItems.FieldS1 = aSqlDataReader.GetString(1);
                    PastryItems.FieldS2 = aSqlDataReader.GetString(2);
                    PastryItems.FieldS3 = aSqlDataReader.GetString(3);
                    PastryItems.FieldS4 = aSqlDataReader.GetString(4);
                    PastryItems.FieldD1 = aSqlDataReader.GetDecimal(5);
                    PastryItems.FieldD2 = aSqlDataReader.GetDecimal(6);
                    PastryItems.FieldI2 = aSqlDataReader.GetInt32(7);
                    PastryItems.FieldD3 = aSqlDataReader.GetDecimal(8);

                    ListOfUsers.Add(PastryItems);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfUsers.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of CeylonAdaptor[] GetAllUsersByPara(string SearchParameter, string DataSource) Method
        public CeylonMiniAdaptor[] GetAllRandBForSalesByPara(string SearchParameter)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfUsers = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Check the Parametter is int or string and select the appropriate statement into the arraylist
                if (Regex.IsMatch(SearchParameter, @"^\d+$"))
                {
                    aSqlCommand = new SqlCommand("GetAllItemForRandBSalesByParaID", aSqlConnection);

                }
                else
                {
                    aSqlCommand = new SqlCommand("GetAllItemForRandBSalesByPara", aSqlConnection);

                }

                // Create command to get the all centers into the arraylist

                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor PastryItems = new CeylonMiniAdaptor();
                    PastryItems.FieldI1 = aSqlDataReader.GetInt32(0);
                    PastryItems.FieldS1 = aSqlDataReader.GetString(1);
                    PastryItems.FieldS2 = aSqlDataReader.GetString(2);
                    PastryItems.FieldS3 = aSqlDataReader.GetString(3);
                    PastryItems.FieldS4 = aSqlDataReader.GetString(4);
                    PastryItems.FieldD1 = aSqlDataReader.GetDecimal(5);
                    PastryItems.FieldD2 = aSqlDataReader.GetDecimal(6);
                    PastryItems.FieldI2 = aSqlDataReader.GetInt32(7);
                    PastryItems.FieldD3 = aSqlDataReader.GetDecimal(8);


                    ListOfUsers.Add(PastryItems);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfUsers.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of CeylonAdaptor[] GetAllUsersByPara(string SearchParameter, string DataSource) Method
        public CeylonMiniAdaptor[] GetAllRandBForSalesByParaBarCode(string SearchParameter)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfUsers = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Check the Parametter is int or string and select the appropriate statement into the arraylist

                aSqlCommand = new SqlCommand("GetAllItemForRandBSalesByParaB", aSqlConnection);


                // Create command to get the all centers into the arraylist

                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor PastryItems = new CeylonMiniAdaptor();
                    PastryItems.FieldI1 = aSqlDataReader.GetInt32(0);
                    PastryItems.FieldS1 = aSqlDataReader.GetString(1);
                    PastryItems.FieldS2 = aSqlDataReader.GetString(2);
                    PastryItems.FieldS3 = aSqlDataReader.GetString(3);
                    PastryItems.FieldS4 = aSqlDataReader.GetString(4);
                    PastryItems.FieldD1 = aSqlDataReader.GetDecimal(5);
                    PastryItems.FieldD2 = aSqlDataReader.GetDecimal(6);
                    PastryItems.FieldI2 = aSqlDataReader.GetInt32(7);
                    PastryItems.FieldD3 = aSqlDataReader.GetDecimal(8);

                    ListOfUsers.Add(PastryItems);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfUsers.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of CeylonAdaptor[] GetAllUsersByPara(string SearchParameter, string DataSource) Method
        public CeylonMiniAdaptor[] GetAllTableForSales()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllTableAvailable", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();

                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(2);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(3);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(4);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(5);
                    ListOfCategory.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of  CeylonMiniAdaptor[] GetAllCategory(string DataSource) Method
        public CeylonMiniAdaptor[] GetAllAvailableStaff()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllAvailableStaff", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();

                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(3);
                    ListOfCategory.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of  CeylonMiniAdaptor[] GetAllCategory(string DataSource) Method
        public CeylonMiniAdaptor[] GetAllTableForSalesBar()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllTableAvailableBar", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();

                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(2);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(3);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(4);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(5);
                    ListOfCategory.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of  CeylonMiniAdaptor[] GetAllCategory(string DataSource) Method
        public CeylonMiniAdaptor[] GetAllTableForSalesBarCounter()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllTableAvailableBarCounter", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();

                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(2);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(3);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(4);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(5);
                    ListOfCategory.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of  CeylonMiniAdaptor[] GetAllCategory(string DataSource) Method
        public CeylonMiniAdaptor[] GetAllTableForSalesFirstFloor()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllTableAvailableFirstFloor", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();

                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(2);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(3);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(4);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(5);
                    ListOfCategory.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of  CeylonMiniAdaptor[] GetAllCategory(string DataSource) Method
        public CeylonMiniAdaptor[] GetAllTableForSalesGroundFloor()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllTableAvailableGroundFloor", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();

                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(2);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(3);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(4);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(5);
                    ListOfCategory.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of  CeylonMiniAdaptor[] GetAllCategory(string DataSource) Method
        public CeylonMiniAdaptor[] GetAllTableForSalesGarden()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllTableAvailableGarden", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();

                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(2);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(3);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(4);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(5);
                    ListOfCategory.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of  CeylonMiniAdaptor[] GetAllCategory(string DataSource) Method
        public CeylonMiniAdaptor[] GetAllTableForSalesPrivate()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllTableAvailablePrivate", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();

                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(2);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(3);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(4);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(5);
                    ListOfCategory.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of  CeylonMiniAdaptor[] GetAllCategory(string DataSource) Method


        public CeylonMiniAdaptor[] GetAllRoomsOccipiedFloor1()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllRoomsOccipiedFloor1", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(3);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(4);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(5);
                    ListOfCategory.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonMiniAdaptor[] GetAllRoomsOccipiedFloor2()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllRoomsOccipiedFloor2", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(3);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(4);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(5);
                    ListOfCategory.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonMiniAdaptor[] GetAllRoomsOccipiedFloor3()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllRoomsOccipiedFloor3", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(3);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(4);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(5);
                    ListOfCategory.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonMiniAdaptor[] GetAllRoomsOccipiedFloor4()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllRoomsOccipiedFloor4", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(3);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(4);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(5);
                    ListOfCategory.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonMiniAdaptor[] GetAllRoomsOccipiedFloor5()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllRoomsOccipiedFloor5", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(3);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(4);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(5);
                    ListOfCategory.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonMiniAdaptor[] GetAllRoomsOccipiedFloor6()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllRoomsOccipiedFloor6", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(3);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(4);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(5);
                    ListOfCategory.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonMiniAdaptor[] GetAllRoomsOccipiedFloor7()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllRoomsOccipiedFloor7", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(3);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(4);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(5);
                    ListOfCategory.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method

        //****************  All the Data Update Methods from the Database Using Parameters ************************//
        public bool UpdateTableStatus(CeylonMiniAdaptor aObject)
        {
            // Just read the details of due payments
            try
            {
                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Create command to get the all centers into the arraylist

                aSqlCommand = new SqlCommand("UpdateTableStatus", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@ID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@Status", SqlDbType.VarChar);
                aSqlCommand.Parameters["@ID"].Value = aObject.FieldI1;
                aSqlCommand.Parameters["@Status"].Value = aObject.FieldS1;

                aSqlCommand.ExecuteNonQuery();
                return (true);
            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (false);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public bool UpdateATable(CeylonMiniAdaptor UpdateTable)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();


                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("UpdateATable", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@TableID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@TableName", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@NumberOfChairs", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@RegisterDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@Details1", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details2", SqlDbType.VarChar);

                aSqlCommand.Parameters["@TableID"].Value = UpdateTable.FieldI1;
                aSqlCommand.Parameters["@TableName"].Value = UpdateTable.FieldS1;
                aSqlCommand.Parameters["@NumberOfChairs"].Value = UpdateTable.FieldI2;
                aSqlCommand.Parameters["@RegisterDate"].Value = UpdateTable.FieldDate1;
                aSqlCommand.Parameters["@Details1"].Value = UpdateTable.FieldS2;
                aSqlCommand.Parameters["@Details2"].Value = UpdateTable.FieldS3;

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "Selected Table Item is Updated";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End of UpdateAItem(ItemTable UpdateItem, string DataSource) Method 
        public bool UpdateACustomer(CeylonAdaptor UpdateCustomer)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("UpdateACustomer", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@CustomerID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Address", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Phone", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@NICNumber", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Email", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@CustomerType", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@CreditLimit", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Balance", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@PostDatedChequeBalance", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@AvailableBalance", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@TotalACCPoints", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Details1", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details2", SqlDbType.VarChar);

                aSqlCommand.Parameters["@CustomerID"].Value = UpdateCustomer.FieldI1;
                aSqlCommand.Parameters["@FirstName"].Value = UpdateCustomer.FieldS1;
                aSqlCommand.Parameters["@LastName"].Value = UpdateCustomer.FieldS2;
                aSqlCommand.Parameters["@Address"].Value = UpdateCustomer.FieldS3;
                aSqlCommand.Parameters["@Phone"].Value = UpdateCustomer.FieldS4;
                aSqlCommand.Parameters["@NICNumber"].Value = UpdateCustomer.FieldS5;
                aSqlCommand.Parameters["@Email"].Value = UpdateCustomer.FieldS6;
                aSqlCommand.Parameters["@CustomerType"].Value = UpdateCustomer.FieldS7;
                aSqlCommand.Parameters["@CreatedDate"].Value = UpdateCustomer.FieldDate1;
                aSqlCommand.Parameters["@CreditLimit"].Value = UpdateCustomer.FieldD1;
                aSqlCommand.Parameters["@Balance"].Value = UpdateCustomer.FieldD2;
                aSqlCommand.Parameters["@PostDatedChequeBalance"].Value = UpdateCustomer.FieldD3;
                aSqlCommand.Parameters["@AvailableBalance"].Value = UpdateCustomer.FieldD4;
                aSqlCommand.Parameters["@TotalACCPoints"].Value = UpdateCustomer.FieldD5;
                aSqlCommand.Parameters["@Details1"].Value = UpdateCustomer.FieldS8;
                aSqlCommand.Parameters["@Details2"].Value = UpdateCustomer.FieldS9;

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "Selected ACC Customer is Updated";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End of  Method 




        public bool UpdateABooking(CeylonMiniAdaptor UpdateaBooking)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();


                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("UpdateBooking", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@EventID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@EventDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@EventTime", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@EventType", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@ContactName", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@CustomerName", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@ContactPhone", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Address", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Status", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Venue", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@SpecialNote", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@CoupleName", SqlDbType.VarChar);


                aSqlCommand.Parameters["@EventID"].Value = UpdateaBooking.FieldI1;
                aSqlCommand.Parameters["@EventDate"].Value = UpdateaBooking.FieldDate1;
                aSqlCommand.Parameters["@EventTime"].Value = UpdateaBooking.FieldS1;
                aSqlCommand.Parameters["@EventType"].Value = UpdateaBooking.FieldS2;
                aSqlCommand.Parameters["@ContactName"].Value = UpdateaBooking.FieldS3;
                aSqlCommand.Parameters["@CustomerName"].Value = UpdateaBooking.FieldS4;
                aSqlCommand.Parameters["@ContactPhone"].Value = UpdateaBooking.FieldS5;
                aSqlCommand.Parameters["@Address"].Value = UpdateaBooking.FieldS6;
                aSqlCommand.Parameters["@Status"].Value = UpdateaBooking.FieldS7;
                aSqlCommand.Parameters["@Venue"].Value = UpdateaBooking.FieldS8;
                aSqlCommand.Parameters["@SpecialNote"].Value = UpdateaBooking.FieldS9;
                aSqlCommand.Parameters["@CoupleName"].Value = UpdateaBooking.FieldS10;

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "Selected Booking is Updated";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End

        public bool UpdateBpayments(CeylonMiniAdaptor UpdateaBooking)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();


                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("UpdateBPayment", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@PayID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@PayedAdvances", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@PaymentType", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@BankName", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@chequeNo", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@chequeDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@balance", SqlDbType.VarChar);


                aSqlCommand.Parameters["@PayID"].Value = UpdateaBooking.FieldI1;
                aSqlCommand.Parameters["@PayedAdvances"].Value = UpdateaBooking.FieldD1;
                aSqlCommand.Parameters["@PaymentType"].Value = UpdateaBooking.FieldS1;
                aSqlCommand.Parameters["@BankName"].Value = UpdateaBooking.FieldS2;
                aSqlCommand.Parameters["@chequeNo"].Value = UpdateaBooking.FieldS3;
                aSqlCommand.Parameters["@chequeDate"].Value = UpdateaBooking.FieldDate1;
                aSqlCommand.Parameters["@balance"].Value = UpdateaBooking.FieldS4;
              
                aSqlCommand.ExecuteNonQuery();

                _DataBase_Result_Message = "Selected Booking is Updated";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End

        public bool UpdatBookingStatus(CeylonMiniAdaptor UpdateaBooking)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();


                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("UpdateStatus", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@EventID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@Status", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@ConfirmedBy", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@ConfirmedDate", SqlDbType.DateTime);


                aSqlCommand.Parameters["@EventID"].Value = UpdateaBooking.FieldI1;
                aSqlCommand.Parameters["@Status"].Value = UpdateaBooking.FieldS1;
                aSqlCommand.Parameters["@ConfirmedBy"].Value = UpdateaBooking.FieldI2;
                aSqlCommand.Parameters["@ConfirmedDate"].Value = UpdateaBooking.FieldDate1;





                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "Booking Confirmed";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End



        public bool UpdateTestX(CeylonMiniAdaptor aObject)
        {
            // Just read the details of due payments
            try
            {
                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Create command to get the all centers into the arraylist

                aSqlCommand = new SqlCommand("UpdateBooking", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@EventID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@Phone", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@CustomerName", SqlDbType.VarChar);
                aSqlCommand.Parameters["@EventID"].Value = aObject.FieldI1;
                aSqlCommand.Parameters["@Phone"].Value = aObject.FieldS1;
                aSqlCommand.Parameters["@CustomerName"].Value = aObject.FieldS2;

                aSqlCommand.ExecuteNonQuery();
                return (true);
            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (false);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method



        public bool UpdatePendingSaleStatus(CeylonMiniAdaptor UpdateAdvance)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("UpdatePendingSaleStatus", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@PRandBSaleID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@Status", SqlDbType.VarChar);

                aSqlCommand.Parameters["@PRandBSaleID"].Value = UpdateAdvance.FieldI1;
                aSqlCommand.Parameters["@Status"].Value = UpdateAdvance.FieldS1;

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "Selected R and B Pending Sale is Updated";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End of Method 

        public bool DeleteStaffPAyment(CeylonAdaptor NewPay)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("DeleteStaffPayment", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;


                aSqlCommand.Parameters.Add("@Payment_ID", SqlDbType.Int);



                aSqlCommand.Parameters["@Payment_ID"].Value = NewPay.FieldI1;


                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "Customer Added to the Database";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End 
        public bool DeleteStaffPlayer(CeylonAdaptor NewPay)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("DeleteStaffPlayer", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;


                aSqlCommand.Parameters.Add("@Payment_ID", SqlDbType.Int);



                aSqlCommand.Parameters["@Payment_ID"].Value = NewPay.FieldI1;


                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "Customer Added to the Database";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End 
        public bool DeleteStaffPlayerPaymentSchedule(CeylonAdaptor NewPay)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("DeleteStaffPlayerPaymentSchedule", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;


                aSqlCommand.Parameters.Add("@Payment_ID", SqlDbType.Int);



                aSqlCommand.Parameters["@Payment_ID"].Value = NewPay.FieldI1;


                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "Customer Added to the Database";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End 


        public bool DeleteEventPAyment(CeylonAdaptor NewPay)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("DeleteEventPAyment", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;


                aSqlCommand.Parameters.Add("@Payment_ID", SqlDbType.Int);



                aSqlCommand.Parameters["@Payment_ID"].Value = NewPay.FieldI1;


                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "Customer Added to the Database";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End 



        //****************  All the Data Adding Methods from the Database Using Parameters ************************//
        public int AddARandBPendingSaleOrder(CeylonAdaptor NewSaleTable)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("InsertARandBPendingSaleOrder", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                int new_MEM_BASIC_ID = 0;
                SqlParameter aParameter = new SqlParameter("@NewBankID", SqlDbType.Int);
                aParameter.Direction = ParameterDirection.Output;
                aSqlCommand.Parameters.Add(aParameter);

                aSqlCommand.Parameters.Add("@FK_PRandBSaleID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@OrderDateTime", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@PrintStatus", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details1", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details2", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@KOT1", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@KOT2", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@KOT3", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@BOT", SqlDbType.Int);

                aSqlCommand.Parameters["@FK_PRandBSaleID"].Value = NewSaleTable.FieldI1;
                aSqlCommand.Parameters["@OrderDateTime"].Value = NewSaleTable.FieldDate1;
                aSqlCommand.Parameters["@PrintStatus"].Value = NewSaleTable.FieldS1;
                aSqlCommand.Parameters["@Details1"].Value = NewSaleTable.FieldS2;
                aSqlCommand.Parameters["@Details2"].Value = NewSaleTable.FieldS3;
                aSqlCommand.Parameters["@KOT1"].Value = NewSaleTable.FieldI2;
                aSqlCommand.Parameters["@KOT2"].Value = NewSaleTable.FieldI3;
                aSqlCommand.Parameters["@KOT3"].Value = NewSaleTable.FieldI4;
                aSqlCommand.Parameters["@BOT"].Value = NewSaleTable.FieldI5;

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "A New Pending R and B Sale Order Added to the Database";
                if (aParameter.Value != DBNull.Value) new_MEM_BASIC_ID = Convert.ToInt32(aParameter.Value);
                return new_MEM_BASIC_ID;
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (0);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End of method
        public int AddAPendingRandBSale(CeylonAdaptor NewSaleTable)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("InsertARandBPendingSale", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                int new_MEM_BASIC_ID = 0;
                SqlParameter aParameter = new SqlParameter("@NewBankID", SqlDbType.Int);
                aParameter.Direction = ParameterDirection.Output;
                aSqlCommand.Parameters.Add(aParameter);

                aSqlCommand.Parameters.Add("@OrderDateTime", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@CustomerType", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@FK_CustomerId", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@CustomerName", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@FK_TableID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@ExpectedOrderDeliveredTime", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@SpecialRequest", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@OrderType", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@PrintStatus", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@RoomID", SqlDbType.VarChar);


                aSqlCommand.Parameters["@OrderDateTime"].Value = NewSaleTable.FieldDate1;
                aSqlCommand.Parameters["@CustomerType"].Value = NewSaleTable.FieldS1;
                aSqlCommand.Parameters["@FK_CustomerId"].Value = NewSaleTable.FieldI1;
                aSqlCommand.Parameters["@CustomerName"].Value = NewSaleTable.FieldS2;
                aSqlCommand.Parameters["@FK_TableID"].Value = NewSaleTable.FieldI2;
                aSqlCommand.Parameters["@ExpectedOrderDeliveredTime"].Value = NewSaleTable.FieldD1;
                aSqlCommand.Parameters["@SpecialRequest"].Value = NewSaleTable.FieldS3;
                aSqlCommand.Parameters["@OrderType"].Value = NewSaleTable.FieldS4;
                aSqlCommand.Parameters["@PrintStatus"].Value = NewSaleTable.FieldS5;
                aSqlCommand.Parameters["@RoomID"].Value = NewSaleTable.FieldS6;

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "A New Pending R and B Sale Added to the Database";
                if (aParameter.Value != DBNull.Value) new_MEM_BASIC_ID = Convert.ToInt32(aParameter.Value);
                return new_MEM_BASIC_ID;
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (0);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End of method
        public bool AddARandBPendingSaleTransaction(CeylonAdaptor NewSaleTransaction)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("InsertARandBPendingSaleTransaction", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlCommand.Parameters.Add("@FK_PRandBSaleID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_RandBItemID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@ItemOrderedDateTime", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@SellingPrice", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Cost", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@SellingQuantity", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@FreeQuantity", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@SubTotal", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Discount", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@TotalWithoutTax", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@ProfitWithoutTax", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@ServiceCharge", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@NBT", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@VAT", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@STax1", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@STax2", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@TotalWithTax", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@ProfitWithTax", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@FK_PrepDepID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@PreparationStatus", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Comment", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@SpecialRequest", SqlDbType.VarChar);

                aSqlCommand.Parameters["@FK_PRandBSaleID"].Value = NewSaleTransaction.FieldI1;
                aSqlCommand.Parameters["@FK_RandBItemID"].Value = NewSaleTransaction.FieldI2;
                aSqlCommand.Parameters["@ItemOrderedDateTime"].Value = NewSaleTransaction.FieldDate1;
                aSqlCommand.Parameters["@SellingPrice"].Value = NewSaleTransaction.FieldD1;
                aSqlCommand.Parameters["@SellingQuantity"].Value = NewSaleTransaction.FieldD3;
                aSqlCommand.Parameters["@FreeQuantity"].Value = NewSaleTransaction.FieldD2;
                aSqlCommand.Parameters["@Discount"].Value = NewSaleTransaction.FieldD4;
                aSqlCommand.Parameters["@SubTotal"].Value = NewSaleTransaction.FieldD5;
                aSqlCommand.Parameters["@TotalWithoutTax"].Value = NewSaleTransaction.FieldD6;
                aSqlCommand.Parameters["@ProfitWithoutTax"].Value = NewSaleTransaction.FieldD7;
                aSqlCommand.Parameters["@Cost"].Value = NewSaleTransaction.FieldD8;
                aSqlCommand.Parameters["@ServiceCharge"].Value = NewSaleTransaction.FieldD13;
                aSqlCommand.Parameters["@NBT"].Value = NewSaleTransaction.FieldD10;
                aSqlCommand.Parameters["@VAT"].Value = NewSaleTransaction.FieldD11;
                aSqlCommand.Parameters["@STax1"].Value = NewSaleTransaction.FieldD12;
                aSqlCommand.Parameters["@STax2"].Value = NewSaleTransaction.FieldD9;
                aSqlCommand.Parameters["@TotalWithTax"].Value = NewSaleTransaction.FieldD14;
                aSqlCommand.Parameters["@ProfitWithTax"].Value = NewSaleTransaction.FieldD15;
                aSqlCommand.Parameters["@FK_PrepDepID"].Value = NewSaleTransaction.FieldI3;
                aSqlCommand.Parameters["@PreparationStatus"].Value = NewSaleTransaction.FieldS1;
                aSqlCommand.Parameters["@Comment"].Value = NewSaleTransaction.FieldS2;
                aSqlCommand.Parameters["@SpecialRequest"].Value = NewSaleTransaction.FieldS3;

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "A New Pending R and B Sale Transaction Added to the Database";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End of AddAPastrySaleTransaction(CeylonAdaptor NewSaleTransaction, string DataSource) Method 
        public bool AddLog(CeylonMiniAdaptor NewLog)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("InsertALog", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@StaffID", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@LogDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@LogFunction", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@LogCommand", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details", SqlDbType.VarChar);

                aSqlCommand.Parameters["@StaffID"].Value = NewLog.FieldI1;
                aSqlCommand.Parameters["@LogDate"].Value = NewLog.FieldDate1;
                aSqlCommand.Parameters["@LogFunction"].Value = NewLog.FieldS1;
                aSqlCommand.Parameters["@LogCommand"].Value = NewLog.FieldS2;
                aSqlCommand.Parameters["@Details"].Value = NewLog.FieldS3;

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "New Log Added to the Database";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End of AddLog(LogClass NewLogClass) Method 


      



        public bool AddACustomer(CeylonAdaptor NewCustomer)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("InsertAACCCustomer", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Address", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Phone", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@NICNumber", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Email", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@CustomerType", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@CreditLimit", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Balance", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@PostDatedChequeBalance", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@AvailableBalance", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@TotalACCPoints", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Details1", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details2", SqlDbType.VarChar);

                aSqlCommand.Parameters["@FirstName"].Value = NewCustomer.FieldS1;
                aSqlCommand.Parameters["@LastName"].Value = NewCustomer.FieldS2;
                aSqlCommand.Parameters["@Address"].Value = NewCustomer.FieldS3;
                aSqlCommand.Parameters["@Phone"].Value = NewCustomer.FieldS4;
                aSqlCommand.Parameters["@NICNumber"].Value = NewCustomer.FieldS5;
                aSqlCommand.Parameters["@Email"].Value = NewCustomer.FieldS6;
                aSqlCommand.Parameters["@CustomerType"].Value = NewCustomer.FieldS7;
                aSqlCommand.Parameters["@CreatedDate"].Value = NewCustomer.FieldDate1;
                aSqlCommand.Parameters["@CreditLimit"].Value = NewCustomer.FieldD1;
                aSqlCommand.Parameters["@Balance"].Value = NewCustomer.FieldD2;
                aSqlCommand.Parameters["@PostDatedChequeBalance"].Value = NewCustomer.FieldD3;
                aSqlCommand.Parameters["@AvailableBalance"].Value = NewCustomer.FieldD4;
                aSqlCommand.Parameters["@TotalACCPoints"].Value = NewCustomer.FieldD5;
                aSqlCommand.Parameters["@Details1"].Value = NewCustomer.FieldS8;
                aSqlCommand.Parameters["@Details2"].Value = NewCustomer.FieldS9;

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "A New ACC Customer Added to the Database";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End of AddACustomer(CustomerTable NewCustomer, string DataSource) Method 


       
        public bool InsertToEventRateTable(CeylonAdaptor NewBook)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("InsertToEventRateTable", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@FK_EventID", SqlDbType.Int);               
                aSqlCommand.Parameters.Add("@EventRate", SqlDbType.NVarChar);
               

                aSqlCommand.Parameters["@FK_EventID"].Value = NewBook.FieldI1;              
                aSqlCommand.Parameters["@EventRate"].Value = NewBook.FieldS1;
               

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "A New ACC Customer Added to the Database";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End 


        public int AddABooking(CeylonAdaptor NewBook)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("InsertToEventTypeTable", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                int new_MEM_BASIC_ID = 0;
                SqlParameter aParameter = new SqlParameter("@EventID", SqlDbType.Int);
                aParameter.Direction = ParameterDirection.Output;
                aSqlCommand.Parameters.Add(aParameter);


                aSqlCommand.Parameters.Add("@FK_CustomerID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_AgentID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_PETID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@Contact_Details_Name", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Contact_Details_Phone", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Contact_Details_Address", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Couple_Name", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details1_SpecialNote", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details2", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details3", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details4", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details5", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@EventTime", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Event_Date", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@M_EventID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@Trans_Date", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@TransBy", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@ConfirmedBy", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_UserTypeID", SqlDbType.Int);
              //  aSqlCommand.Parameters.Add("@EventID", SqlDbType.Int);

                aSqlCommand.Parameters["@FK_CustomerID"].Value = NewBook.FieldI1;
                aSqlCommand.Parameters["@FK_AgentID"].Value = NewBook.FieldI2;
                aSqlCommand.Parameters["@FK_PETID"].Value = NewBook.FieldI3;
                aSqlCommand.Parameters["@Contact_Details_Name"].Value = NewBook.FieldS1;
                aSqlCommand.Parameters["@Contact_Details_Phone"].Value = NewBook.FieldS2;
                aSqlCommand.Parameters["@Contact_Details_Address"].Value = NewBook.FieldS3;
                aSqlCommand.Parameters["@Couple_Name"].Value = NewBook.FieldS4;
                aSqlCommand.Parameters["@Details1_SpecialNote"].Value = NewBook.FieldS5;
                aSqlCommand.Parameters["@Details2"].Value = NewBook.FieldS6;
                aSqlCommand.Parameters["@Details3"].Value = NewBook.FieldS7;
                aSqlCommand.Parameters["@Details4"].Value = NewBook.FieldS8;
                aSqlCommand.Parameters["@Details5"].Value = NewBook.FieldS9;
                aSqlCommand.Parameters["@EventTime"].Value = NewBook.FieldS10;
                aSqlCommand.Parameters["@Event_Date"].Value = NewBook.FieldDate1;
                aSqlCommand.Parameters["@M_EventID"].Value = NewBook.FieldI4;// event rate
                aSqlCommand.Parameters["@Trans_Date"].Value = NewBook.FieldDate2;
                aSqlCommand.Parameters["@TransBy"].Value = NewBook.FieldI5;
                aSqlCommand.Parameters["@ConfirmedBy"].Value = NewBook.FieldI6;
                aSqlCommand.Parameters["@FK_UserTypeID"].Value = NewBook.FieldI7;//discount
               //aSqlCommand.Parameters["@EventID"].Value = NewBook.FieldI8;

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "A New ACC Customer Added to the Database";
                if (aParameter.Value != DBNull.Value) new_MEM_BASIC_ID = Convert.ToInt32(aParameter.Value);
                return new_MEM_BASIC_ID;
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (0);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End 
        public bool AddToEventHistoryTable(CeylonAdaptor NewBook)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("InsertToEventHistoryTable", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@EventID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_CustomerID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_AgentID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_PETID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@Contact_Details_Name", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Contact_Details_Phone", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Contact_Details_Address", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Couple_Name", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details1_SpecialNote", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details2", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details3", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details4", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details5", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@EventTime", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Event_Date", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@M_EventID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@Trans_Date", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@TransBy", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@ConfirmedBy", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_UserTypeID", SqlDbType.Int);

                aSqlCommand.Parameters["@EventID"].Value = NewBook.FieldI1;
                aSqlCommand.Parameters["@FK_CustomerID"].Value = NewBook.FieldI2;
                aSqlCommand.Parameters["@FK_AgentID"].Value = NewBook.FieldI3;
                aSqlCommand.Parameters["@FK_PETID"].Value = NewBook.FieldI4;
                aSqlCommand.Parameters["@Contact_Details_Name"].Value = NewBook.FieldS1;
                aSqlCommand.Parameters["@Contact_Details_Phone"].Value = NewBook.FieldS2;
                aSqlCommand.Parameters["@Contact_Details_Address"].Value = NewBook.FieldS3;
                aSqlCommand.Parameters["@Couple_Name"].Value = NewBook.FieldS4;
                aSqlCommand.Parameters["@Details1_SpecialNote"].Value = NewBook.FieldS5;
                aSqlCommand.Parameters["@Details2"].Value = NewBook.FieldS6;
                aSqlCommand.Parameters["@Details3"].Value = NewBook.FieldS7;
                aSqlCommand.Parameters["@Details4"].Value = NewBook.FieldS8;
                aSqlCommand.Parameters["@Details5"].Value = NewBook.FieldS9;
                aSqlCommand.Parameters["@EventTime"].Value = NewBook.FieldS10;
                aSqlCommand.Parameters["@Event_Date"].Value = NewBook.FieldDate1;
                aSqlCommand.Parameters["@M_EventID"].Value = NewBook.FieldI5;
                aSqlCommand.Parameters["@Trans_Date"].Value = NewBook.FieldDate2;
                aSqlCommand.Parameters["@TransBy"].Value = NewBook.FieldI6;
                aSqlCommand.Parameters["@ConfirmedBy"].Value = NewBook.FieldI7;
                aSqlCommand.Parameters["@FK_UserTypeID"].Value = NewBook.FieldI8;

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "A New ACC Customer Added to the Database";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End 
        public bool RegisterPlayer(CeylonAdaptor NewBook)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("RegisterPlayer", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

              
                aSqlCommand.Parameters.Add("@PName", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@PAddress", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@PPhone", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@PEmail", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@DOB", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@RegistredDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@Details1", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details2", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details3", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details4", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details5", SqlDbType.NVarChar);


                aSqlCommand.Parameters["@PName"].Value = NewBook.FieldS1;
                aSqlCommand.Parameters["@PAddress"].Value = NewBook.FieldS2;
                aSqlCommand.Parameters["@PPhone"].Value = NewBook.FieldS3;
                aSqlCommand.Parameters["@PEmail"].Value = NewBook.FieldS4;
                aSqlCommand.Parameters["@DOB"].Value = NewBook.FieldDate1;
                aSqlCommand.Parameters["@RegistredDate"].Value = NewBook.FieldDate2;
                aSqlCommand.Parameters["@Details1"].Value = NewBook.FieldS5;
                aSqlCommand.Parameters["@Details2"].Value = NewBook.FieldS6;
                aSqlCommand.Parameters["@Details3"].Value = NewBook.FieldS7;
                aSqlCommand.Parameters["@Details4"].Value = NewBook.FieldS8;
                aSqlCommand.Parameters["@Details5"].Value = NewBook.FieldS9;
                

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "A New ACC Customer Added to the Database";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End 
        public bool AllocatePlayerPayments(CeylonAdaptor NewBook)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("AllocatePlayerPayments", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;


                aSqlCommand.Parameters.Add("@FK_PID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_Dep_ID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_PETID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@BPayment", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Special_Payment", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Details1", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details2", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details3", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details4", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details5", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details6", SqlDbType.NVarChar);


                aSqlCommand.Parameters["@FK_PID"].Value = NewBook.FieldI1;
                aSqlCommand.Parameters["@FK_Dep_ID"].Value = NewBook.FieldI2;
                aSqlCommand.Parameters["@FK_PETID"].Value = NewBook.FieldI3;
                aSqlCommand.Parameters["@BPayment"].Value = NewBook.FieldD1;
                aSqlCommand.Parameters["@Special_Payment"].Value = NewBook.FieldD2;
                aSqlCommand.Parameters["@Details1"].Value = NewBook.FieldS1;
                aSqlCommand.Parameters["@Details2"].Value = NewBook.FieldS2;
                aSqlCommand.Parameters["@Details3"].Value = NewBook.FieldS3;
                aSqlCommand.Parameters["@Details4"].Value = NewBook.FieldS4;
                aSqlCommand.Parameters["@Details5"].Value = NewBook.FieldS5;
                aSqlCommand.Parameters["@Details6"].Value = NewBook.FieldS6;


                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "A New ACC Customer Added to the Database";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End 
        public bool UpdateStaffPaymentSchedule(CeylonAdaptor NewBook)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("UpdateStaffPaymentSchedule", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;


                aSqlCommand.Parameters.Add("@PayID", SqlDbType.Int);              
                aSqlCommand.Parameters.Add("@BPayment", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Special_Payment", SqlDbType.Decimal);
               


                aSqlCommand.Parameters["@PayID"].Value = NewBook.FieldI1;              
                aSqlCommand.Parameters["@BPayment"].Value = NewBook.FieldD1;
                aSqlCommand.Parameters["@Special_Payment"].Value = NewBook.FieldD2;
                


                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "A New ACC Customer Added to the Database";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End 
        public bool UpdateABandPlayerStaff(CeylonAdaptor NewBook)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("UpdateABandPlayerStaff", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
             

                aSqlCommand.Parameters.Add("@PID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@PName", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@PAddress", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@PPhone", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@PEmail", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@DOB", SqlDbType.DateTime);               
                aSqlCommand.Parameters.Add("@Details1", SqlDbType.NVarChar);


                aSqlCommand.Parameters["@PID"].Value = NewBook.FieldI1;
                aSqlCommand.Parameters["@PName"].Value = NewBook.FieldS1;
                aSqlCommand.Parameters["@PAddress"].Value = NewBook.FieldS2;
                aSqlCommand.Parameters["@PPhone"].Value = NewBook.FieldS3;
                aSqlCommand.Parameters["@PEmail"].Value = NewBook.FieldS4;
                aSqlCommand.Parameters["@DOB"].Value = NewBook.FieldDate1;               
                aSqlCommand.Parameters["@Details1"].Value = NewBook.FieldS5;
              


                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "A New ACC Customer Added to the Database";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End 

        public bool AddAStaffPayment(CeylonAdaptor NewBook)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("InsertToStaffPayment", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@FK_EventID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_PayID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_PID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_Dep_ID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_PETID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@PaymentAmount", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Special_Payment", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@PaymentType", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Bank", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@ChequeNo", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@ChequeDate", SqlDbType.DateTime);

                aSqlCommand.Parameters.Add("@Details1", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details2", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details3", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details4", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details5", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details6", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Details7", SqlDbType.NVarChar);


                aSqlCommand.Parameters["@FK_EventID"].Value = NewBook.FieldI1;
                aSqlCommand.Parameters["@FK_PayID"].Value = NewBook.FieldI2;
                aSqlCommand.Parameters["@FK_PID"].Value = NewBook.FieldI3;
                aSqlCommand.Parameters["@FK_Dep_ID"].Value = NewBook.FieldI4;
                aSqlCommand.Parameters["@FK_PETID"].Value = NewBook.FieldI5;
                aSqlCommand.Parameters["@PaymentAmount"].Value = NewBook.FieldD1;
                aSqlCommand.Parameters["@Special_Payment"].Value = NewBook.FieldD2;
                aSqlCommand.Parameters["@PaymentType"].Value = NewBook.FieldS1;
                aSqlCommand.Parameters["@Bank"].Value = NewBook.FieldS2;
                aSqlCommand.Parameters["@ChequeNo"].Value = NewBook.FieldS3;
                aSqlCommand.Parameters["@ChequeDate"].Value = NewBook.FieldDate1;
                aSqlCommand.Parameters["@Details1"].Value = NewBook.FieldS4;
                aSqlCommand.Parameters["@Details2"].Value = NewBook.FieldS5;
                aSqlCommand.Parameters["@Details3"].Value = NewBook.FieldS6;
                aSqlCommand.Parameters["@Details4"].Value = NewBook.FieldS7;
                aSqlCommand.Parameters["@Details5"].Value = NewBook.FieldS8;
                aSqlCommand.Parameters["@Details6"].Value = NewBook.FieldS9;
                aSqlCommand.Parameters["@Details7"].Value = NewBook.FieldS10;


                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "A New Staff Payment Added to the Database";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End 

        public bool AddingPayment(CeylonAdaptor NewPay)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("InsertToPayment", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@BPayDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@FK_EID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_CustomerID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_AgentID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@PayingAmount", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@PaymentDescription", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@PaymentType", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@BankName", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@ChequeNumber", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@ChequeDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@RealiseDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@RealiseAmount", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Status", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details1", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details2", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details3", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details4", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details5", SqlDbType.VarChar);



                aSqlCommand.Parameters["@BPayDate"].Value = NewPay.FieldDate1;
                aSqlCommand.Parameters["@FK_EID"].Value = NewPay.FieldI1;
                aSqlCommand.Parameters["@FK_CustomerID"].Value = NewPay.FieldI2;
                aSqlCommand.Parameters["@FK_AgentID"].Value = NewPay.FieldI3;
                aSqlCommand.Parameters["@PayingAmount"].Value = NewPay.FieldD1;
                aSqlCommand.Parameters["@PaymentDescription"].Value = NewPay.FieldS1;
                aSqlCommand.Parameters["@PaymentType"].Value = NewPay.FieldS2;
                aSqlCommand.Parameters["@BankName"].Value = NewPay.FieldS3;
                aSqlCommand.Parameters["@ChequeNumber"].Value = NewPay.FieldS4;
                aSqlCommand.Parameters["@ChequeDate"].Value = NewPay.FieldDate2;
                aSqlCommand.Parameters["@RealiseDate"].Value = NewPay.FieldDate3;
                aSqlCommand.Parameters["@RealiseAmount"].Value = NewPay.FieldD2;
                aSqlCommand.Parameters["@Status"].Value = NewPay.FieldS5;
                aSqlCommand.Parameters["@Details1"].Value = NewPay.FieldS6;
                aSqlCommand.Parameters["@Details2"].Value = NewPay.FieldS7;
                aSqlCommand.Parameters["@Details3"].Value = NewPay.FieldS8;
                aSqlCommand.Parameters["@Details4"].Value = NewPay.FieldS9;
                aSqlCommand.Parameters["@Details5"].Value = NewPay.FieldS10;
                

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "Payment Added to the Database";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End 



        public bool UpdateSessionID(CeylonMiniAdaptor aObject)
        {
            // Just read the details of due payments
            try
            {
                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Create command to get the all centers into the arraylist

                aSqlCommand = new SqlCommand("UpdateSessionIDCounter", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@Test1", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Details", SqlDbType.VarChar);
                aSqlCommand.Parameters["@Test1"].Value = aObject.FieldD1;
                aSqlCommand.Parameters["@Details"].Value = aObject.FieldS1;

                aSqlCommand.ExecuteNonQuery();
                return (true);
            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (false);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of GenerateAvailableBalanceByCustomerID(int SearchParameter, string DataSource) Method
        public CeylonMiniAdaptor[] GetSessionInformation()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfItemsForPurchase = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetCurrentSessionCounter", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();

                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    ListOfItemsForPurchase.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfItemsForPurchase.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of CeylonMiniAdaptor[] GetTestTotal(string SearchParameter, string DataSource) Method
        public bool AddStaffDailyTransaction(CeylonMiniAdaptor NewSaleTable)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("InsertStaffDailyTransaction", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@FK_StaffID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_TableID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@Status", SqlDbType.VarChar);

                aSqlCommand.Parameters["@FK_StaffID"].Value = NewSaleTable.FieldI1;
                aSqlCommand.Parameters["@FK_TableID"].Value = NewSaleTable.FieldI2;
                aSqlCommand.Parameters["@Status"].Value = NewSaleTable.FieldS1;



                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "A New Table Allocated to the Staff";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End of method
        public string GetWaiterByTableID(string TableID)
        {
            // Just read the details of due payments
            try
            {
                string AvailableBalance = "";

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Create command to get the all centers into the arraylist
                aSqlCommand = new SqlCommand("GetWaiterByTable", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = TableID;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {

                    AvailableBalance = aSqlDataReader.GetString(0);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return (AvailableBalance);

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return ("");
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public int CheckTableAvailability(int TableID)
        {
            // Just read the details of due payments
            try
            {
                int TableAvailability = 0;

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Create command to get the all centers into the arraylist
                aSqlCommand = new SqlCommand("CheckTableAvailability", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.Int;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = TableID;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {

                    TableAvailability = aSqlDataReader.GetInt32(0);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return (TableAvailability);

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (0);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public int GetRandBPendingSaleIDByTable(int TableID)
        {
            // Just read the details of due payments
            try
            {
                int TableAvailability = 0;

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Create command to get the all centers into the arraylist
                aSqlCommand = new SqlCommand("GetRandBPendingSaleIDByTable", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.Int;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = TableID;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {

                    TableAvailability = aSqlDataReader.GetInt32(0);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return (TableAvailability);

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (0);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonMiniAdaptor[] GeneratePastryDailyMasterReport(string StartDate, string EndDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GeneratePastryDailyMasterReportMobile", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@StartDate";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);
                SqlParameter aSqlParameter1 = new SqlParameter();
                aSqlParameter1.ParameterName = "@EndDate";
                aSqlParameter1.SqlDbType = SqlDbType.VarChar;
                aSqlParameter1.Direction = ParameterDirection.Input;
                aSqlParameter1.Value = EndDate;
                aSqlCommand.Parameters.Add(aSqlParameter1);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();
                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(0);
                    aObjectForReports.FieldD2 = aSqlDataReader.GetDecimal(1);
                    aObjectForReports.FieldD3 = aSqlDataReader.GetDecimal(2);
                    aObjectForReports.FieldD4 = aSqlDataReader.GetDecimal(3);
                    aObjectForReports.FieldD5 = aSqlDataReader.GetDecimal(4);
                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfSale.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of GenerateDailyMasterReport(string DataSource) Method
        public CeylonMiniAdaptor[] GenerateRandBDailyMasterReport(string StartDate, string EndDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GenerateRandBDailyMasterReportMobile", aSqlConnection);

                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@StartDate";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);
                SqlParameter aSqlParameter1 = new SqlParameter();
                aSqlParameter1.ParameterName = "@EndDate";
                aSqlParameter1.SqlDbType = SqlDbType.VarChar;
                aSqlParameter1.Direction = ParameterDirection.Input;
                aSqlParameter1.Value = EndDate;
                aSqlCommand.Parameters.Add(aSqlParameter1);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();
                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(0);
                    aObjectForReports.FieldD2 = aSqlDataReader.GetDecimal(1);
                    aObjectForReports.FieldD3 = aSqlDataReader.GetDecimal(2);
                    aObjectForReports.FieldD4 = aSqlDataReader.GetDecimal(3);
                    aObjectForReports.FieldD5 = aSqlDataReader.GetDecimal(4);
                    //aObjectForReports.FieldD3 = aSqlDataReader.GetDecimal(2);
                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfSale.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of GenerateDailyMasterReport(string DataSource) Method
        public CeylonMiniAdaptor[] GenerateSkyWalkDailyMasterReport(string StartDate, string EndDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GenerateSkyWalkDailyMasterReportMobile", aSqlConnection);

                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@StartDate";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);
                SqlParameter aSqlParameter1 = new SqlParameter();
                aSqlParameter1.ParameterName = "@EndDate";
                aSqlParameter1.SqlDbType = SqlDbType.VarChar;
                aSqlParameter1.Direction = ParameterDirection.Input;
                aSqlParameter1.Value = EndDate;
                aSqlCommand.Parameters.Add(aSqlParameter1);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();
                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(0);
                    aObjectForReports.FieldD2 = aSqlDataReader.GetDecimal(1);
                    aObjectForReports.FieldD3 = aSqlDataReader.GetDecimal(2);
                    aObjectForReports.FieldD4 = aSqlDataReader.GetDecimal(3);
                    aObjectForReports.FieldD5 = aSqlDataReader.GetDecimal(4);
                    //aObjectForReports.FieldD3 = aSqlDataReader.GetDecimal(2);
                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfSale.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of GenerateDailyMasterReport(string DataSource) Method
        public CeylonAdaptor[] GetFullPendingSaleTransactionsByOrderIDSkyWalk(int SearchParameter)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfItemsForPurchase = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetFullPendingSaleTransactionsByOrderIDSkyNet", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@PendingOrderID";
                aSqlParameter.SqlDbType = SqlDbType.Int;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();

                    aObjectForReports.FieldI10 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(1);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(2);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(3);
                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(4);
                    aObjectForReports.FieldD2 = aSqlDataReader.GetDecimal(5);
                    aObjectForReports.FieldD3 = aSqlDataReader.GetDecimal(6);
                    aObjectForReports.FieldD4 = aSqlDataReader.GetDecimal(7);
                    aObjectForReports.FieldD5 = aSqlDataReader.GetDecimal(8);
                    aObjectForReports.FieldD6 = aSqlDataReader.GetDecimal(9);
                    aObjectForReports.FieldD7 = aSqlDataReader.GetDecimal(10);
                    aObjectForReports.FieldD8 = aSqlDataReader.GetDecimal(11);
                    aObjectForReports.FieldD9 = aSqlDataReader.GetDecimal(12);
                    aObjectForReports.FieldD10 = aSqlDataReader.GetDecimal(13);
                    aObjectForReports.FieldD11 = aSqlDataReader.GetDecimal(14);
                    aObjectForReports.FieldD12 = aSqlDataReader.GetDecimal(15);
                    aObjectForReports.FieldD13 = aSqlDataReader.GetDecimal(16);
                    aObjectForReports.FieldD14 = aSqlDataReader.GetDecimal(17);
                    aObjectForReports.FieldD15 = aSqlDataReader.GetDecimal(18);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(19);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(20);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(21);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(22);
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(23);
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(24);
                    ListOfItemsForPurchase.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfItemsForPurchase.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of ObjectForReports[] GetAllBrokerByPara(string SearchParameter, string DataSource) Method
        public CeylonAdaptor[] GetFullPendingSaleTransactionsByOrderID(int SearchParameter)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfItemsForPurchase = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetFullPendingSaleTransactionsByOrderID", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@PendingOrderID";
                aSqlParameter.SqlDbType = SqlDbType.Int;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();

                    aObjectForReports.FieldI10 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(1);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(2);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(3);
                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(4);
                    aObjectForReports.FieldD2 = aSqlDataReader.GetDecimal(5);
                    aObjectForReports.FieldD3 = aSqlDataReader.GetDecimal(6);
                    aObjectForReports.FieldD4 = aSqlDataReader.GetDecimal(7);
                    aObjectForReports.FieldD5 = aSqlDataReader.GetDecimal(8);
                    aObjectForReports.FieldD6 = aSqlDataReader.GetDecimal(9);
                    aObjectForReports.FieldD7 = aSqlDataReader.GetDecimal(10);
                    aObjectForReports.FieldD8 = aSqlDataReader.GetDecimal(11);
                    aObjectForReports.FieldD9 = aSqlDataReader.GetDecimal(12);
                    aObjectForReports.FieldD10 = aSqlDataReader.GetDecimal(13);
                    aObjectForReports.FieldD11 = aSqlDataReader.GetDecimal(14);
                    aObjectForReports.FieldD12 = aSqlDataReader.GetDecimal(15);
                    aObjectForReports.FieldD13 = aSqlDataReader.GetDecimal(16);
                    aObjectForReports.FieldD14 = aSqlDataReader.GetDecimal(17);
                    aObjectForReports.FieldD15 = aSqlDataReader.GetDecimal(18);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(19);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(20);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(21);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(22);
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(23);
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(24);
                    ListOfItemsForPurchase.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfItemsForPurchase.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of ObjectForReports[] GetAllBrokerByPara(string SearchParameter, string DataSource) Method
        public CeylonAdaptor[] GetFullPendingSaleTransactionsByOrderIDPastry(int SearchParameter)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfItemsForPurchase = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetFullPendingSaleTransactionsByOrderIDPastry", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@PendingOrderID";
                aSqlParameter.SqlDbType = SqlDbType.Int;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();

                    aObjectForReports.FieldI10 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(1);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(2);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(3);
                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(4);
                    aObjectForReports.FieldD2 = aSqlDataReader.GetDecimal(5);
                    aObjectForReports.FieldD3 = aSqlDataReader.GetDecimal(6);
                    aObjectForReports.FieldD4 = aSqlDataReader.GetDecimal(7);
                    aObjectForReports.FieldD5 = aSqlDataReader.GetDecimal(8);
                    aObjectForReports.FieldD6 = aSqlDataReader.GetDecimal(9);
                    aObjectForReports.FieldD7 = aSqlDataReader.GetDecimal(10);
                    aObjectForReports.FieldD8 = aSqlDataReader.GetDecimal(11);
                    aObjectForReports.FieldD9 = aSqlDataReader.GetDecimal(12);
                    aObjectForReports.FieldD10 = aSqlDataReader.GetDecimal(13);
                    aObjectForReports.FieldD11 = aSqlDataReader.GetDecimal(14);
                    aObjectForReports.FieldD12 = aSqlDataReader.GetDecimal(15);
                    aObjectForReports.FieldD13 = aSqlDataReader.GetDecimal(16);
                    aObjectForReports.FieldD14 = aSqlDataReader.GetDecimal(17);
                    aObjectForReports.FieldD15 = aSqlDataReader.GetDecimal(18);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(19);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(20);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(21);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(22);
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(23);
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(24);
                    ListOfItemsForPurchase.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfItemsForPurchase.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of ObjectForReports[] GetAllBrokerByPara(string SearchParameter, string DataSource) Method
        public bool UpdateRandBOrderStatus(CeylonMiniAdaptor UpdateAdvance)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("UpdateRandBOrderStatus", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@PRandBSTID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@PrintStatus", SqlDbType.VarChar);

                aSqlCommand.Parameters["@PRandBSTID"].Value = UpdateAdvance.FieldI1;
                aSqlCommand.Parameters["@PrintStatus"].Value = UpdateAdvance.FieldS1;

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "Selected Order Status is Updated";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End of  Method 
        public bool UpdateARandBPendingSaleTransaction(CeylonAdaptor UpdateRandBSale)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("UpdateARandBPendingSaleTransaction", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@FK_PRandBSaleID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_RandBItemID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@SubTotal", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Discount", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@TotalWithoutTax", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@ProfitWithoutTax", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@VAT", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@NBT", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@STax1", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@STax2", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@ServiceCharge", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@TotalWithTax", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@ProfitWithTax", SqlDbType.Decimal);

                aSqlCommand.Parameters["@FK_PRandBSaleID"].Value = UpdateRandBSale.FieldI1;
                aSqlCommand.Parameters["@FK_RandBItemID"].Value = UpdateRandBSale.FieldI2;
                aSqlCommand.Parameters["@SubTotal"].Value = UpdateRandBSale.FieldD5;
                aSqlCommand.Parameters["@Discount"].Value = UpdateRandBSale.FieldD6;
                aSqlCommand.Parameters["@TotalWithoutTax"].Value = UpdateRandBSale.FieldD7;
                aSqlCommand.Parameters["@ProfitWithoutTax"].Value = UpdateRandBSale.FieldD8;
                aSqlCommand.Parameters["@ServiceCharge"].Value = UpdateRandBSale.FieldD9;
                aSqlCommand.Parameters["@NBT"].Value = UpdateRandBSale.FieldD10;
                aSqlCommand.Parameters["@VAT"].Value = UpdateRandBSale.FieldD11;
                aSqlCommand.Parameters["@STax1"].Value = UpdateRandBSale.FieldD12;
                aSqlCommand.Parameters["@STax2"].Value = UpdateRandBSale.FieldD13;
                aSqlCommand.Parameters["@TotalWithTax"].Value = UpdateRandBSale.FieldD14;
                aSqlCommand.Parameters["@ProfitWithTax"].Value = UpdateRandBSale.FieldD15;

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "Selected Order's Discount is Updated";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End of  Method 
        public decimal GetServiceChargePercentage()
        {
            // Just read the details of due payments
            try
            {
                decimal CahsBalance = 0;

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Create command to get the all centers into the arraylist
                aSqlCommand = new SqlCommand("GetServiceChargePercentage", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {

                    CahsBalance = aSqlDataReader.GetDecimal(0);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return (CahsBalance);

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (0);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of GetCashBalance(string DataSource) Method
        public decimal GetVATPercentage()
        {
            // Just read the details of due payments
            try
            {
                decimal CahsBalance = 0;

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Create command to get the all centers into the arraylist
                aSqlCommand = new SqlCommand("GetVATPercentage", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {

                    CahsBalance = aSqlDataReader.GetDecimal(0);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return (CahsBalance);

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (0);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of GetCashBalance(string DataSource) Method
        public decimal GetNBTPercentage()
        {
            // Just read the details of due payments
            try
            {
                decimal CahsBalance = 0;

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Create command to get the all centers into the arraylist
                aSqlCommand = new SqlCommand("GetNBTPercentage", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {

                    CahsBalance = aSqlDataReader.GetDecimal(0);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return (CahsBalance);

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (0);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of GetCashBalance(string DataSource) Method
        public string GetTableLocationViaPendingSaleID(int PendingSaleID)
        {
            // Just read the details of due payments
            try
            {
                string EntittledAvailability = "";

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Create command to get the all centers into the arraylist
                aSqlCommand = new SqlCommand("GetTableLocationViaPendingSaleID", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.Int;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = PendingSaleID;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {

                    EntittledAvailability = aSqlDataReader.GetString(0);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return (EntittledAvailability);

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return ("");
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonAdaptor[] GetAllResevationDetailsConfirmed(string CheckINDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllCheckDetailsDaily", aSqlConnection);

                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.DateTime;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = CheckINDate;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(3);
                    aObjectForReports.FieldDate2 = aSqlDataReader.GetDateTime(4);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(5);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(6);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(7);
                    aObjectForReports.FieldI4 = aSqlDataReader.GetInt32(8);
                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonAdaptor[] GetAllBookingsTransPara(string SearchParameter)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfRooms = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("BookingsTransByParaInt", aSqlConnection);



                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI14 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(1);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(3);
                    aObjectForReports.FieldD2 = aSqlDataReader.GetDecimal(4);
                    aObjectForReports.FieldD3 = aSqlDataReader.GetDecimal(5);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(6);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(7);
                    aObjectForReports.FieldDate2 = aSqlDataReader.GetDateTime(8);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(9);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(10);
                    aObjectForReports.FieldI4 = aSqlDataReader.GetInt32(11);
                    aObjectForReports.FieldI5 = aSqlDataReader.GetInt32(12);
                    aObjectForReports.FieldI6 = aSqlDataReader.GetInt32(13);
                    aObjectForReports.FieldI7 = aSqlDataReader.GetInt32(14);
                    aObjectForReports.FieldI8 = aSqlDataReader.GetInt32(15);
                    aObjectForReports.FieldI9 = aSqlDataReader.GetInt32(16);
                    aObjectForReports.FieldI10 = aSqlDataReader.GetInt32(17);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(18);
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(19);
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(20);
                    aObjectForReports.FieldD4 = aSqlDataReader.GetDecimal(21);
                    aObjectForReports.FieldD5 = aSqlDataReader.GetDecimal(22);
                    aObjectForReports.FieldD6 = aSqlDataReader.GetDecimal(23);
                    aObjectForReports.FieldD7 = aSqlDataReader.GetDecimal(24);
                    aObjectForReports.FieldD8 = aSqlDataReader.GetDecimal(25);
                    aObjectForReports.FieldD9 = aSqlDataReader.GetDecimal(26);
                    aObjectForReports.FieldD10 = aSqlDataReader.GetDecimal(27);
                    aObjectForReports.FieldS6 = aSqlDataReader.GetString(28);
                    aObjectForReports.FieldS7 = aSqlDataReader.GetString(29);
                    ListOfRooms.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfRooms.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonAdaptor[] BookingsRoomsByRoomType(string SearchParameter)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfRooms = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();
                aSqlCommand = new SqlCommand("BookingsRoomsByRoomType", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@RoomType";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(3);
                    ListOfRooms.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfRooms.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End of Method
        public CeylonAdaptor[] GetAllCustomerByPara(string SearchParameter)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOFCustomer = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();


                // Check the Parametter is int or string and select the appropriate statement into the arraylist
                if (Regex.IsMatch(SearchParameter, @"^\d+$"))
                {
                    if (SearchParameter.Length > 9)
                    {
                        aSqlCommand = new SqlCommand("GetAllCustomerByPara", aSqlConnection);
                    }
                    else
                    {
                        aSqlCommand = new SqlCommand("GetAllCustomerByParaInt", aSqlConnection);
                    }


                }
                else
                {
                    aSqlCommand = new SqlCommand("GetAllCustomerByPara", aSqlConnection);

                }
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aCustomerTable = new CeylonAdaptor();

                    aCustomerTable.FieldI1 = aSqlDataReader.GetInt32(0);
                    aCustomerTable.FieldS1 = aSqlDataReader.GetString(1);
                    aCustomerTable.FieldS2 = aSqlDataReader.GetString(2);
                    aCustomerTable.FieldS3 = aSqlDataReader.GetString(3);
                    aCustomerTable.FieldS4 = aSqlDataReader.GetString(4);
                    aCustomerTable.FieldS5 = aSqlDataReader.GetString(5);
                    aCustomerTable.FieldS6 = aSqlDataReader.GetString(6);
                    aCustomerTable.FieldS7 = aSqlDataReader.GetString(7);
                    aCustomerTable.FieldDate1 = aSqlDataReader.GetDateTime(8);
                    aCustomerTable.FieldD1 = aSqlDataReader.GetDecimal(9);
                    aCustomerTable.FieldD2 = aSqlDataReader.GetDecimal(10);
                    aCustomerTable.FieldD3 = aSqlDataReader.GetDecimal(11);
                    aCustomerTable.FieldD4 = aSqlDataReader.GetDecimal(12);
                    aCustomerTable.FieldD5 = aSqlDataReader.GetDecimal(13);
                    aCustomerTable.FieldS8 = aSqlDataReader.GetString(14);
                    aCustomerTable.FieldS9 = aSqlDataReader.GetString(15);
                    ListOFCustomer.Add(aCustomerTable);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOFCustomer.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of  Method
        public CeylonAdaptor[] CustomerDetailsViaBookingID(int BookingID)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("CustomerDetailsViaBookingID", aSqlConnection);

                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.Int;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = BookingID;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);// Customer ID
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);// Customer FName
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);// Customer LastName
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(3);// Customer NIC
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(4);// Customer Phone
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(5);// Email
                    aObjectForReports.FieldS6 = aSqlDataReader.GetString(6);// Addrress
                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonAdaptor[] GetAllBookingsPara(string SearchParameter)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfRooms = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Check the Parametter is int or string and select the appropriate statement into the arraylist
                if (Regex.IsMatch(SearchParameter, @"^\d+$"))
                {
                    aSqlCommand = new SqlCommand("BookingsByParaInt", aSqlConnection);

                }
                else
                {
                    //aSqlCommand = new SqlCommand("ExchangeByPara", aSqlConnection);

                }

                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI14 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(1);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(2);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(3);
                    aObjectForReports.FieldI4 = aSqlDataReader.GetInt32(4);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(5);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(6);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(7);
                    aObjectForReports.FieldDate2 = aSqlDataReader.GetDateTime(8);
                    aObjectForReports.FieldI5 = aSqlDataReader.GetInt32(9);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(10);
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(11);
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(12);
                    aObjectForReports.FieldS6 = aSqlDataReader.GetString(13);
                    aObjectForReports.FieldI6 = aSqlDataReader.GetInt32(14);
                    aObjectForReports.FieldI7 = aSqlDataReader.GetInt32(15);
                    aObjectForReports.FieldI8 = aSqlDataReader.GetInt32(16);
                    aObjectForReports.FieldI9 = aSqlDataReader.GetInt32(17);
                    aObjectForReports.FieldI10 = aSqlDataReader.GetInt32(18);
                    aObjectForReports.FieldI11 = aSqlDataReader.GetInt32(19);
                    aObjectForReports.FieldS7 = aSqlDataReader.GetString(20);
                    aObjectForReports.FieldS8 = aSqlDataReader.GetString(21);
                    aObjectForReports.FieldI12 = aSqlDataReader.GetInt32(22);
                    ListOfRooms.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfRooms.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public bool UpdateABooking(CeylonAdaptor NewSaleTable)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();


                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("BookingsUpdateABooking", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@BookingID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_CustomerID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_AgentID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_RoomID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_PackageID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@AccommodationType", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@CheckINType", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@CheckINDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@CheckOUTDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@NumberOfNights", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@BookingStatus", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@InitialBookingBy", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@CheckINBy", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@CheckOUTBy", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@NumberOfAdults", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NumberOfKids", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NumberOfInfants", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NumberOfAdultBeds", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NumberOfKidsBeds", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NumberOfInfantCots", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@Details1", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details2", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@MasterBillID", SqlDbType.Int);

                aSqlCommand.Parameters["@BookingID"].Value = NewSaleTable.FieldI14;
                aSqlCommand.Parameters["@FK_CustomerID"].Value = NewSaleTable.FieldI1;
                aSqlCommand.Parameters["@FK_AgentID"].Value = NewSaleTable.FieldI2;
                aSqlCommand.Parameters["@FK_RoomID"].Value = NewSaleTable.FieldI3;
                aSqlCommand.Parameters["@FK_PackageID"].Value = NewSaleTable.FieldI4;
                aSqlCommand.Parameters["@AccommodationType"].Value = NewSaleTable.FieldS1;
                aSqlCommand.Parameters["@CheckINType"].Value = NewSaleTable.FieldS2;
                aSqlCommand.Parameters["@CheckINDate"].Value = NewSaleTable.FieldDate1;
                aSqlCommand.Parameters["@CheckOUTDate"].Value = NewSaleTable.FieldDate2;
                aSqlCommand.Parameters["@NumberOfNights"].Value = NewSaleTable.FieldI5;
                aSqlCommand.Parameters["@BookingStatus"].Value = NewSaleTable.FieldS3;
                aSqlCommand.Parameters["@InitialBookingBy"].Value = NewSaleTable.FieldS4;
                aSqlCommand.Parameters["@CheckINBy"].Value = NewSaleTable.FieldS5;
                aSqlCommand.Parameters["@CheckOUTBy"].Value = NewSaleTable.FieldS6;
                aSqlCommand.Parameters["@NumberOfAdults"].Value = NewSaleTable.FieldI6;
                aSqlCommand.Parameters["@NumberOfKids"].Value = NewSaleTable.FieldI7;
                aSqlCommand.Parameters["@NumberOfInfants"].Value = NewSaleTable.FieldI8;
                aSqlCommand.Parameters["@NumberOfAdultBeds"].Value = NewSaleTable.FieldI9;
                aSqlCommand.Parameters["@NumberOfKidsBeds"].Value = NewSaleTable.FieldI10;
                aSqlCommand.Parameters["@NumberOfInfantCots"].Value = NewSaleTable.FieldI11;
                aSqlCommand.Parameters["@Details1"].Value = NewSaleTable.FieldS7;
                aSqlCommand.Parameters["@Details2"].Value = NewSaleTable.FieldS8;
                aSqlCommand.Parameters["@MasterBillID"].Value = NewSaleTable.FieldI12;

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "Selected Booking is Updated";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End of Method 
        public CeylonMiniAdaptor[] GetAllRoomsPara(string SearchParameter)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfRooms = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Check the Parametter is int or string and select the appropriate statement into the arraylist
                if (Regex.IsMatch(SearchParameter, @"^\d+$"))
                {
                    aSqlCommand = new SqlCommand("GetAllRoomsByParaInt", aSqlConnection);

                }
                else
                {
                    aSqlCommand = new SqlCommand("GetAllRoomsByPara", aSqlConnection);

                }

                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();

                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(3);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(4);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(5);
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(6);
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(7);
                    aObjectForReports.FieldS6 = aSqlDataReader.GetString(8);
                    aObjectForReports.FieldS7 = aSqlDataReader.GetString(9);
                    aObjectForReports.FieldS8 = aSqlDataReader.GetString(10);

                    ListOfRooms.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfRooms.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public bool UpdateARoom(CeylonMiniAdaptor NewItem)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();


                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("BookingsUpdateARoom", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@RoomID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@RoomType", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@RoomFloor", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@MaximumOccupancy", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@RoomStatus", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@LastCleanedDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@CleanedBy", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@RepairsStatus", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Comment", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details1", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details2", SqlDbType.VarChar);

                aSqlCommand.Parameters["@RoomID"].Value = NewItem.FieldI1;
                aSqlCommand.Parameters["@RoomType"].Value = NewItem.FieldS1;
                aSqlCommand.Parameters["@RoomFloor"].Value = NewItem.FieldS2;
                aSqlCommand.Parameters["@MaximumOccupancy"].Value = NewItem.FieldI2;
                aSqlCommand.Parameters["@RoomStatus"].Value = NewItem.FieldS3;
                aSqlCommand.Parameters["@LastCleanedDate"].Value = NewItem.FieldDate1;
                aSqlCommand.Parameters["@CleanedBy"].Value = NewItem.FieldS4;
                aSqlCommand.Parameters["@RepairsStatus"].Value = NewItem.FieldS5;
                aSqlCommand.Parameters["@Comment"].Value = NewItem.FieldS6;
                aSqlCommand.Parameters["@Details1"].Value = NewItem.FieldS7;
                aSqlCommand.Parameters["@Details2"].Value = NewItem.FieldS8;

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "Selected Room is Updated";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End of Method 
        public CeylonMiniAdaptor[] GetAllCountries()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllCountries", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();

                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    ListOfCategory.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method


        /*************** Marians Date Check ****************/
        public CeylonMiniAdaptor[] GetDateAvailability(string StartDate, string EndDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("BBanAvailabilityByDate", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@StartDate";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);
                SqlParameter aSqlParameter1 = new SqlParameter();
                aSqlParameter1.ParameterName = "@EndDate";
                aSqlParameter1.SqlDbType = SqlDbType.VarChar;
                aSqlParameter1.Direction = ParameterDirection.Input;
                aSqlParameter1.Value = EndDate;
                aSqlCommand.Parameters.Add(aSqlParameter1);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(0);
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(1);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(2);

                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfSale.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method

        public CeylonAdaptor[] SearchCalendarDetails(string StartDate, string EndDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("SearchCalendarDetails", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchDate";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);
               
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(1);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(2);
                    aObjectForReports.FieldI4 = aSqlDataReader.GetInt32(3);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(4);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(5);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(6);
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(7);
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(8);
                    aObjectForReports.FieldS6 = aSqlDataReader.GetString(9);
                    aObjectForReports.FieldS7 = aSqlDataReader.GetString(10);
                    aObjectForReports.FieldS8 = aSqlDataReader.GetString(11);
                    aObjectForReports.FieldS9 = aSqlDataReader.GetString(12);
                    aObjectForReports.FieldS10 = aSqlDataReader.GetString(13);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(14);
                    aObjectForReports.FieldI5 = aSqlDataReader.GetInt32(15);
                    aObjectForReports.FieldDate2 = aSqlDataReader.GetDateTime(16);
                    aObjectForReports.FieldI6 = aSqlDataReader.GetInt32(17);
                    aObjectForReports.FieldI7 = aSqlDataReader.GetInt32(18);
                    aObjectForReports.FieldI8 = aSqlDataReader.GetInt32(19);

                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method

        public CeylonAdaptor[] SearchTentativeBooking(string StartDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("SearchTentativeBookings", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchDate";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(1);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(2);
                    aObjectForReports.FieldI4 = aSqlDataReader.GetInt32(3);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(4);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(5);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(6);
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(7);
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(8);
                    aObjectForReports.FieldS6 = aSqlDataReader.GetString(9);
                    aObjectForReports.FieldS7 = aSqlDataReader.GetString(10);
                    aObjectForReports.FieldS8 = aSqlDataReader.GetString(11);
                    aObjectForReports.FieldS9 = aSqlDataReader.GetString(12);
                    aObjectForReports.FieldS10 = aSqlDataReader.GetString(13);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(14);
                    aObjectForReports.FieldI5 = aSqlDataReader.GetInt32(15);
                    aObjectForReports.FieldDate2 = aSqlDataReader.GetDateTime(16);
                    aObjectForReports.FieldI6 = aSqlDataReader.GetInt32(17);
                    aObjectForReports.FieldI7 = aSqlDataReader.GetInt32(18);
                    aObjectForReports.FieldI8 = aSqlDataReader.GetInt32(19);

                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method


        public CeylonAdaptor[] SearchConfirmedBookingsByDate(string StartDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("SearchConfirmedBookingsByDate", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchDate";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(1);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(2);
                    aObjectForReports.FieldI4 = aSqlDataReader.GetInt32(3);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(4);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(5);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(6);
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(7);
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(8);
                    aObjectForReports.FieldS6 = aSqlDataReader.GetString(9);
                    aObjectForReports.FieldS7 = aSqlDataReader.GetString(10);
                    aObjectForReports.FieldS8 = aSqlDataReader.GetString(11);
                    aObjectForReports.FieldS9 = aSqlDataReader.GetString(12);
                    aObjectForReports.FieldS10 = aSqlDataReader.GetString(13);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(14);
                    aObjectForReports.FieldI5 = aSqlDataReader.GetInt32(15);
                    aObjectForReports.FieldDate2 = aSqlDataReader.GetDateTime(16);
                    aObjectForReports.FieldI6 = aSqlDataReader.GetInt32(17);
                    aObjectForReports.FieldI7 = aSqlDataReader.GetInt32(18);
                    aObjectForReports.FieldI8 = aSqlDataReader.GetInt32(19);

                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonAdaptor[] SearchAgentByID(string StartDate)
        {
            // Just read the details of due payments
            try
            { 
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("[SearchAgentByID]", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchPara";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    //aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    //aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(1);
                    //aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(2);
                    //aObjectForReports.FieldI4 = aSqlDataReader.GetInt32(3);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    //aObjectForReports.FieldS2 = aSqlDataReader.GetString(5);
                    //aObjectForReports.FieldS3 = aSqlDataReader.GetString(6);
                    //aObjectForReports.FieldS4 = aSqlDataReader.GetString(7);
                    //aObjectForReports.FieldS5 = aSqlDataReader.GetString(8);
                    //aObjectForReports.FieldS6 = aSqlDataReader.GetString(9);
                    //aObjectForReports.FieldS7 = aSqlDataReader.GetString(10);
                    //aObjectForReports.FieldS8 = aSqlDataReader.GetString(11);
                    //aObjectForReports.FieldS9 = aSqlDataReader.GetString(12);
                    //aObjectForReports.FieldS10 = aSqlDataReader.GetString(13);
                    //aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(14);
                    //aObjectForReports.FieldI5 = aSqlDataReader.GetInt32(15);
                    //aObjectForReports.FieldDate2 = aSqlDataReader.GetDateTime(16);
                    //aObjectForReports.FieldI6 = aSqlDataReader.GetInt32(17);
                    //aObjectForReports.FieldI7 = aSqlDataReader.GetInt32(18);
                    //aObjectForReports.FieldI8 = aSqlDataReader.GetInt32(19);

                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method


        public CeylonAdaptor[] SearchStaffPaymentsByEventID(string StartDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("SearchStaffPaymentsByEventID", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchPara";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);// payment id
                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(6);// payment Amount
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(8);// payment type
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(9); //Bank
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(11); //payed Date
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(12); //FOC details 1
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(13); // player name  details 2
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(14);// paid  details 3
                    aObjectForReports.FieldS6 = aSqlDataReader.GetString(15);// department  details 4
                    aObjectForReports.FieldS7 = aSqlDataReader.GetString(16);// anynote  details 5
                    aObjectForReports.FieldS8 = aSqlDataReader.GetString(17);// pay date  details 6


                    //aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(1);
                    //aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(2);
                    //aObjectForReports.FieldI4 = aSqlDataReader.GetInt32(3);
                    // aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    //aObjectForReports.FieldS2 = aSqlDataReader.GetString(5);
                    //aObjectForReports.FieldS3 = aSqlDataReader.GetString(6);
                    //aObjectForReports.FieldS4 = aSqlDataReader.GetString(7);
                    //aObjectForReports.FieldS5 = aSqlDataReader.GetString(8);
                    //aObjectForReports.FieldS6 = aSqlDataReader.GetString(9);
                    //aObjectForReports.FieldS7 = aSqlDataReader.GetString(10);
                    //aObjectForReports.FieldS8 = aSqlDataReader.GetString(11);
                    //aObjectForReports.FieldS9 = aSqlDataReader.GetString(12);
                    //aObjectForReports.FieldS10 = aSqlDataReader.GetString(13);
                    //aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(14);
                    //aObjectForReports.FieldI5 = aSqlDataReader.GetInt32(15);
                    //aObjectForReports.FieldDate2 = aSqlDataReader.GetDateTime(16);
                    //aObjectForReports.FieldI6 = aSqlDataReader.GetInt32(17);
                    //aObjectForReports.FieldI7 = aSqlDataReader.GetInt32(18);
                    //aObjectForReports.FieldI8 = aSqlDataReader.GetInt32(19);

                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonAdaptor[] SearchPlayerPaumentSchedule(string StartDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("SearchPlayerPaumentSchedule", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@PID";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);// payment id                  
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);// staff
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2); //department                 
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(3); //Event Type
                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(4); //Amount
                

                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonAdaptor[] SearchPlayerPaumentScheduleDuplication(string StartDate, string End)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("SearchPlayerPaumentScheduleDuplication", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@PID";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);

                SqlParameter aSqlParameter1 = new SqlParameter();
                aSqlParameter1.ParameterName = "@ETID";
                aSqlParameter1.SqlDbType = SqlDbType.VarChar;
                aSqlParameter1.Direction = ParameterDirection.Input;
                aSqlParameter1.Value = End;
                aSqlCommand.Parameters.Add(aSqlParameter1);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);// payment id                  
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);// staff
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2); //department                 
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(3); //Event Type
                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(4); //Amount


                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method

        public CeylonAdaptor[] SearchStaffPaymentsByEventIDGrouped(string StartDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("SearchStaffPaymentsByEventIDGrouped", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchPara";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);// payment id
                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(6);// payment Amount
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(8);// payment type
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(9); //Bank
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(11); //payed Date
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(12); //FOC details 1
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(13); // player name  details 2
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(14);// paid  details 3
                    aObjectForReports.FieldS6 = aSqlDataReader.GetString(15);// department  details 4
                    aObjectForReports.FieldS7 = aSqlDataReader.GetString(16);// anynote  details 5
                    aObjectForReports.FieldS8 = aSqlDataReader.GetString(17);// pay date  details 6



                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method

        public CeylonAdaptor[] SearchDepartments(string StartDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("SearchDepartmentByEventID", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@EventID";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);//FK_PETID   
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(1);//FK_DEPID  
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(2);//Department
                   

                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method

        public CeylonAdaptor[] SearchEventsByDate(string StartDate, string EndDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("SearchEventsByDate", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchDate";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);
                SqlParameter aSqlParameter1 = new SqlParameter();
                aSqlParameter1.ParameterName = "@SearchTime";
                aSqlParameter1.SqlDbType = SqlDbType.VarChar;
                aSqlParameter1.Direction = ParameterDirection.Input;
                aSqlParameter1.Value = EndDate;
                aSqlCommand.Parameters.Add(aSqlParameter1);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor EventDetails = new CeylonAdaptor();

                    EventDetails.FieldI1 = aSqlDataReader.GetInt32(0);//eventID
                    EventDetails.FieldI2 = aSqlDataReader.GetInt32(3);//FK_PETID
                    EventDetails.FieldI3 = aSqlDataReader.GetInt32(15);//Contract price
                    EventDetails.FieldS1 = aSqlDataReader.GetString(12);//event NAme
                    EventDetails.FieldS2 = aSqlDataReader.GetString(13);//event time
                    EventDetails.FieldDate1 = aSqlDataReader.GetDateTime(14);//event Date
                    EventDetails.FieldI4 = aSqlDataReader.GetInt32(19);//Discount price
                    EventDetails.FieldS3 = aSqlDataReader.GetString(9);//venue

                    ListOfSale.Add(EventDetails);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonAdaptor[] SearchEventsByEventTypeandPara(string StartDate, string EndDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("SearchEventsByEventTypeandPara", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@Event";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);
                SqlParameter aSqlParameter1 = new SqlParameter();
                aSqlParameter1.ParameterName = "@Search";
                aSqlParameter1.SqlDbType = SqlDbType.VarChar;
                aSqlParameter1.Direction = ParameterDirection.Input;
                aSqlParameter1.Value = EndDate;
                aSqlCommand.Parameters.Add(aSqlParameter1);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor EventDetails = new CeylonAdaptor();

                    EventDetails.FieldI1 = aSqlDataReader.GetInt32(0);//eventID
                    EventDetails.FieldI2 = aSqlDataReader.GetInt32(3);//FK_PETID
                    EventDetails.FieldI3 = aSqlDataReader.GetInt32(15);//Contract price
                    EventDetails.FieldS1 = aSqlDataReader.GetString(12);//event NAme
                    EventDetails.FieldS2 = aSqlDataReader.GetString(13);//event time
                    EventDetails.FieldDate1 = aSqlDataReader.GetDateTime(14);//event Date
                    EventDetails.FieldI4 = aSqlDataReader.GetInt32(19);//Discount price
                    EventDetails.FieldS3 = aSqlDataReader.GetString(9);//venue

                    ListOfSale.Add(EventDetails);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method

        public CeylonAdaptor[] SearchExpensesByDateRange(string StartDate, string EndDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("SearchExpensesByDateRange", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@FromDate";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);
                SqlParameter aSqlParameter1 = new SqlParameter();
                aSqlParameter1.ParameterName = "@ToDate";
                aSqlParameter1.SqlDbType = SqlDbType.VarChar;
                aSqlParameter1.Direction = ParameterDirection.Input;
                aSqlParameter1.Value = EndDate;
                aSqlCommand.Parameters.Add(aSqlParameter1);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor EventDetails = new CeylonAdaptor();

                   

                    EventDetails.FieldI1 = aSqlDataReader.GetInt32(0);//PaymentID
                    EventDetails.FieldS1 = aSqlDataReader.GetString(1);//Department
                    EventDetails.FieldS2 = aSqlDataReader.GetString(2);//PlayerName
                    EventDetails.FieldI2 = aSqlDataReader.GetInt32(3);//Event ID
                    EventDetails.FieldDate1 = aSqlDataReader.GetDateTime(4);//event Date
                    EventDetails.FieldS3 = aSqlDataReader.GetString(5);//event Time
                    EventDetails.FieldS4 = aSqlDataReader.GetString(6);//event Type
                    EventDetails.FieldD1 = aSqlDataReader.GetDecimal(7);// pay amount
                    EventDetails.FieldS5 = aSqlDataReader.GetString(8);//Pay Type
                    EventDetails.FieldS6 = aSqlDataReader.GetString(9);//bank
                    EventDetails.FieldS7 = aSqlDataReader.GetString(10);//pay date
                  
                 

                    ListOfSale.Add(EventDetails);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonAdaptor[] SearchExpensesByDateRangeByStaff(string StartDate, string EndDate, string StaffID)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("SearchExpensesByDateRangeByStaff", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@FromDate";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);

                SqlParameter aSqlParameter1 = new SqlParameter();
                aSqlParameter1.ParameterName = "@ToDate";
                aSqlParameter1.SqlDbType = SqlDbType.VarChar;
                aSqlParameter1.Direction = ParameterDirection.Input;
                aSqlParameter1.Value = EndDate;
                aSqlCommand.Parameters.Add(aSqlParameter1);

                SqlParameter aSqlParameter2 = new SqlParameter();
                aSqlParameter2.ParameterName = "@StaffID";
                aSqlParameter2.SqlDbType = SqlDbType.VarChar;
                aSqlParameter2.Direction = ParameterDirection.Input;
                aSqlParameter2.Value = StaffID;
                aSqlCommand.Parameters.Add(aSqlParameter2);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor EventDetails = new CeylonAdaptor();



                    EventDetails.FieldI1 = aSqlDataReader.GetInt32(0);//PaymentID
                    EventDetails.FieldS1 = aSqlDataReader.GetString(1);//Department
                    EventDetails.FieldS2 = aSqlDataReader.GetString(2);//PlayerName
                    EventDetails.FieldI2 = aSqlDataReader.GetInt32(3);//Event ID
                    EventDetails.FieldDate1 = aSqlDataReader.GetDateTime(4);//event Date
                    EventDetails.FieldS3 = aSqlDataReader.GetString(5);//event Time
                    EventDetails.FieldS4 = aSqlDataReader.GetString(6);//event Type
                    EventDetails.FieldD1 = aSqlDataReader.GetDecimal(7);// pay amount
                    EventDetails.FieldS5 = aSqlDataReader.GetString(8);//Pay Type
                    EventDetails.FieldS6 = aSqlDataReader.GetString(9);//bank
                    EventDetails.FieldS7 = aSqlDataReader.GetString(10);//pay date



                    ListOfSale.Add(EventDetails);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method

        public CeylonAdaptor[] SearchEventIncomeByDateRange(string StartDate, string EndDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("SearchEventIncomeByDateRange", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@FromDate";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);
                SqlParameter aSqlParameter1 = new SqlParameter();
                aSqlParameter1.ParameterName = "@ToDate";
                aSqlParameter1.SqlDbType = SqlDbType.VarChar;
                aSqlParameter1.Direction = ParameterDirection.Input;
                aSqlParameter1.Value = EndDate;
                aSqlCommand.Parameters.Add(aSqlParameter1);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor EventDetails = new CeylonAdaptor();



                    EventDetails.FieldI1 = aSqlDataReader.GetInt32(0);//Event ID
                    EventDetails.FieldS1 = aSqlDataReader.GetString(1);//Event Details                  
                    EventDetails.FieldD1 = aSqlDataReader.GetDecimal(2);// Total Paid
                    EventDetails.FieldS2 = aSqlDataReader.GetString(3);//Pay Date


                    ListOfSale.Add(EventDetails);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method

        public CeylonAdaptor[] SearchEventIncomeByDateRange1(string StartDate, string EndDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("SearchEventIncomeByDateRange1", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@FromDate";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);
                SqlParameter aSqlParameter1 = new SqlParameter();
                aSqlParameter1.ParameterName = "@ToDate";
                aSqlParameter1.SqlDbType = SqlDbType.VarChar;
                aSqlParameter1.Direction = ParameterDirection.Input;
                aSqlParameter1.Value = EndDate;
                aSqlCommand.Parameters.Add(aSqlParameter1);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor EventDetails = new CeylonAdaptor();



                    EventDetails.FieldI1 = aSqlDataReader.GetInt32(0);//Event ID
                    EventDetails.FieldS1 = aSqlDataReader.GetString(1);//Event Details                  
                    EventDetails.FieldD1 = aSqlDataReader.GetDecimal(2);// Total Paid
                    EventDetails.FieldS2 = aSqlDataReader.GetString(3);//Pay Date


                    ListOfSale.Add(EventDetails);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method

        public CeylonAdaptor[] SearchAdvance(string SearchPara)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("AdvanceSearchbyEventID", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@Searchpara";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchPara;
                aSqlCommand.Parameters.Add(aSqlParameter);
           

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor EventDetails = new CeylonAdaptor();

                    EventDetails.FieldI1 = aSqlDataReader.GetInt32(0);//PayID
                    EventDetails.FieldD1 = aSqlDataReader.GetDecimal(5);//Amount
                    



                    ListOfSale.Add(EventDetails);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method


        public CeylonAdaptor[] SearchAllEventPayments(string SearchPara)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("AllEventPsySearchbyEventID", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@Searchpara";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchPara;
                aSqlCommand.Parameters.Add(aSqlParameter);


                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor EventDetails = new CeylonAdaptor();

                    EventDetails.FieldI1 = aSqlDataReader.GetInt32(0);//PayID
                    EventDetails.FieldD1 = aSqlDataReader.GetDecimal(5);//Amount
                    EventDetails.FieldS1 = aSqlDataReader.GetString(7);//PAy type
                    EventDetails.FieldS2 = aSqlDataReader.GetString(8);//bank name
                    EventDetails.FieldS3 = aSqlDataReader.GetString(14);//pay account
                    EventDetails.FieldS4 = aSqlDataReader.GetString(15);//pay  date
                    EventDetails.FieldS5 = aSqlDataReader.GetString(16);//pay type




                    ListOfSale.Add(EventDetails);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method

        public CeylonAdaptor[] SearchLastAdvanceDate(string SearchPara)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("AdvanceDateSearchbyEventID", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@Searchpara";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchPara;
                aSqlCommand.Parameters.Add(aSqlParameter);


                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor EventDetails = new CeylonAdaptor();

                    EventDetails.FieldS1 = aSqlDataReader.GetString(15);//Adfvance last date
                  




                    ListOfSale.Add(EventDetails);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonAdaptor[] SearchEventAmount(string SearchPara)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("SearchPriceByEventName", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@Searchpara";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchPara;
                aSqlCommand.Parameters.Add(aSqlParameter);


                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor EventDetails = new CeylonAdaptor();

                    EventDetails.FieldI1 = aSqlDataReader.GetInt32(0);//PETID
                    EventDetails.FieldS1 = aSqlDataReader.GetString(4);//Amount




                    ListOfSale.Add(EventDetails);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method

        public CeylonAdaptor[] FilterPlayers(string EventTypeID, string DepartmentTypeID)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("FilterPlayers", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@EventTypeID";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = EventTypeID;
                aSqlCommand.Parameters.Add(aSqlParameter);
                SqlParameter aSqlParameter1 = new SqlParameter();
                aSqlParameter1.ParameterName = "@DepTypeID";
                aSqlParameter1.SqlDbType = SqlDbType.VarChar;
                aSqlParameter1.Direction = ParameterDirection.Input;
                aSqlParameter1.Value = DepartmentTypeID;
                aSqlCommand.Parameters.Add(aSqlParameter1);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor EventDetails = new CeylonAdaptor();

                   
                    EventDetails.FieldI1 = aSqlDataReader.GetInt32(0);//FK_PEID
                    EventDetails.FieldS1 = aSqlDataReader.GetString(1);//Player Name



                    ListOfSale.Add(EventDetails);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method


        public CeylonAdaptor[] GetPaymentAmount(string EventTypeID, string DepartmentTypeID,string PlayerID)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetPaymentAmount", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@EventTypeID";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = EventTypeID;
                aSqlCommand.Parameters.Add(aSqlParameter);

                SqlParameter aSqlParameter1 = new SqlParameter();
                aSqlParameter1.ParameterName = "@DEPID";
                aSqlParameter1.SqlDbType = SqlDbType.VarChar;
                aSqlParameter1.Direction = ParameterDirection.Input;
                aSqlParameter1.Value = DepartmentTypeID;
                aSqlCommand.Parameters.Add(aSqlParameter1);

                SqlParameter aSqlParameter2 = new SqlParameter();
                aSqlParameter2.ParameterName = "@PID";
                aSqlParameter2.SqlDbType = SqlDbType.VarChar;
                aSqlParameter2.Direction = ParameterDirection.Input;
                aSqlParameter2.Value = PlayerID;
                aSqlCommand.Parameters.Add(aSqlParameter2);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor AmountDetails = new CeylonAdaptor();


                    AmountDetails.FieldI1 = aSqlDataReader.GetInt32(0);//PayID
                    AmountDetails.FieldD1 = aSqlDataReader.GetDecimal(4);//Amount



                    ListOfSale.Add(AmountDetails);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method

        public CeylonMiniAdaptor[] GetAllPlayers()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("Player", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();

                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                   
                    ListOfCategory.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }

        public CeylonAdaptor[] GetBookingHistory()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("BookingHistory", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aTentativeBook = new CeylonAdaptor();


                    aTentativeBook.FieldI1 = aSqlDataReader.GetInt32(0);
                    aTentativeBook.FieldI2 = aSqlDataReader.GetInt32(1);
                    aTentativeBook.FieldI3 = aSqlDataReader.GetInt32(2);
                    aTentativeBook.FieldI4 = aSqlDataReader.GetInt32(3);
                    aTentativeBook.FieldS1 = aSqlDataReader.GetString(4);
                    aTentativeBook.FieldS2 = aSqlDataReader.GetString(5);
                    aTentativeBook.FieldS3 = aSqlDataReader.GetString(6);
                    aTentativeBook.FieldS4 = aSqlDataReader.GetString(7);
                    aTentativeBook.FieldS5 = aSqlDataReader.GetString(8);
                    aTentativeBook.FieldS6 = aSqlDataReader.GetString(9);
                    aTentativeBook.FieldS7 = aSqlDataReader.GetString(10);
                    aTentativeBook.FieldS8 = aSqlDataReader.GetString(11);
                    aTentativeBook.FieldS9 = aSqlDataReader.GetString(12);
                    aTentativeBook.FieldS10 = aSqlDataReader.GetString(13);
                    aTentativeBook.FieldDate1 = aSqlDataReader.GetDateTime(14);
                    aTentativeBook.FieldI5 = aSqlDataReader.GetInt32(15);
                    aTentativeBook.FieldDate2 = aSqlDataReader.GetDateTime(16);
                    aTentativeBook.FieldI6 = aSqlDataReader.GetInt32(17);
                    aTentativeBook.FieldI7 = aSqlDataReader.GetInt32(18);
                    aTentativeBook.FieldI8 = aSqlDataReader.GetInt32(19);

                    ListOfCategory.Add(aTentativeBook);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfCategory.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }
        public CeylonAdaptor[] GetTentativeBookings()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetTentativeBookings", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aTentativeBook = new CeylonAdaptor();
                   

                    aTentativeBook.FieldI1 = aSqlDataReader.GetInt32(0);
                    aTentativeBook.FieldI2 = aSqlDataReader.GetInt32(1);
                    aTentativeBook.FieldI3 = aSqlDataReader.GetInt32(2);
                    aTentativeBook.FieldI4 = aSqlDataReader.GetInt32(3);
                    aTentativeBook.FieldS1 = aSqlDataReader.GetString(4);
                    aTentativeBook.FieldS2 = aSqlDataReader.GetString(5);
                    aTentativeBook.FieldS3 = aSqlDataReader.GetString(6);
                    aTentativeBook.FieldS4 = aSqlDataReader.GetString(7);
                    aTentativeBook.FieldS5 = aSqlDataReader.GetString(8);
                    aTentativeBook.FieldS6 = aSqlDataReader.GetString(9);
                    aTentativeBook.FieldS7 = aSqlDataReader.GetString(10);
                    aTentativeBook.FieldS8 = aSqlDataReader.GetString(11);
                    aTentativeBook.FieldS9 = aSqlDataReader.GetString(12);
                    aTentativeBook.FieldS10 = aSqlDataReader.GetString(13);
                    aTentativeBook.FieldDate1 = aSqlDataReader.GetDateTime(14);
                    aTentativeBook.FieldI5 = aSqlDataReader.GetInt32(15);
                    aTentativeBook.FieldDate2 = aSqlDataReader.GetDateTime(16);
                    aTentativeBook.FieldI6 = aSqlDataReader.GetInt32(17);
                    aTentativeBook.FieldI7 = aSqlDataReader.GetInt32(18);
                    aTentativeBook.FieldI8 = aSqlDataReader.GetInt32(19);
                   
                    ListOfCategory.Add(aTentativeBook);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfCategory.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }
        public CeylonAdaptor[] GetAllStaffMembers()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllStaffMembers", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor ConfirmedBook = new CeylonAdaptor();
                 

                    ConfirmedBook.FieldI1 = aSqlDataReader.GetInt32(0);//ID                  
                    ConfirmedBook.FieldS1 = aSqlDataReader.GetString(1);// department
                    ConfirmedBook.FieldS2 = aSqlDataReader.GetString(2);// name
                    ConfirmedBook.FieldS3 = aSqlDataReader.GetString(3);//address
                    ConfirmedBook.FieldS4 = aSqlDataReader.GetString(4);//phone
                    ConfirmedBook.FieldS5 = aSqlDataReader.GetString(5);//email
                    ConfirmedBook.FieldDate1 = aSqlDataReader.GetDateTime(6);//DOB
                    ConfirmedBook.FieldDate2 = aSqlDataReader.GetDateTime(7);//register date
                   

                    ListOfCategory.Add(ConfirmedBook);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfCategory.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }
        public CeylonAdaptor[] GetConfirmedBookings()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetConfirmed Booking", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor ConfirmedBook = new CeylonAdaptor();


                    ConfirmedBook.FieldI1 = aSqlDataReader.GetInt32(0);
                    ConfirmedBook.FieldI2 = aSqlDataReader.GetInt32(1);
                    ConfirmedBook.FieldI3 = aSqlDataReader.GetInt32(2);
                    ConfirmedBook.FieldI4 = aSqlDataReader.GetInt32(3);
                    ConfirmedBook.FieldS1 = aSqlDataReader.GetString(4);
                    ConfirmedBook.FieldS2 = aSqlDataReader.GetString(5);
                    ConfirmedBook.FieldS3 = aSqlDataReader.GetString(6);
                    ConfirmedBook.FieldS4 = aSqlDataReader.GetString(7);
                    ConfirmedBook.FieldS5 = aSqlDataReader.GetString(8);
                    ConfirmedBook.FieldS6 = aSqlDataReader.GetString(9);
                    ConfirmedBook.FieldS7 = aSqlDataReader.GetString(10);
                    ConfirmedBook.FieldS8 = aSqlDataReader.GetString(11);
                    ConfirmedBook.FieldS9 = aSqlDataReader.GetString(12);
                    ConfirmedBook.FieldS10 = aSqlDataReader.GetString(13);
                    ConfirmedBook.FieldDate1 = aSqlDataReader.GetDateTime(14);
                    ConfirmedBook.FieldI5 = aSqlDataReader.GetInt32(15);
                    ConfirmedBook.FieldDate2 = aSqlDataReader.GetDateTime(16);
                    ConfirmedBook.FieldI6 = aSqlDataReader.GetInt32(17);
                    ConfirmedBook.FieldI7 = aSqlDataReader.GetInt32(18);
                    ConfirmedBook.FieldI8 = aSqlDataReader.GetInt32(19);

                    ListOfCategory.Add(ConfirmedBook);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfCategory.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }
        public CeylonAdaptor[] GetConfirmedBookingasEventDateAscending()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetConfirmedBookingasEventDateAscending", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor ConfirmedBook = new CeylonAdaptor();


                    ConfirmedBook.FieldI1 = aSqlDataReader.GetInt32(0);
                    ConfirmedBook.FieldI2 = aSqlDataReader.GetInt32(1);
                    ConfirmedBook.FieldI3 = aSqlDataReader.GetInt32(2);
                    ConfirmedBook.FieldI4 = aSqlDataReader.GetInt32(3);
                    ConfirmedBook.FieldS1 = aSqlDataReader.GetString(4);
                    ConfirmedBook.FieldS2 = aSqlDataReader.GetString(5);
                    ConfirmedBook.FieldS3 = aSqlDataReader.GetString(6);
                    ConfirmedBook.FieldS4 = aSqlDataReader.GetString(7);
                    ConfirmedBook.FieldS5 = aSqlDataReader.GetString(8);
                    ConfirmedBook.FieldS6 = aSqlDataReader.GetString(9);
                    ConfirmedBook.FieldS7 = aSqlDataReader.GetString(10);
                    ConfirmedBook.FieldS8 = aSqlDataReader.GetString(11);
                    ConfirmedBook.FieldS9 = aSqlDataReader.GetString(12);
                    ConfirmedBook.FieldS10 = aSqlDataReader.GetString(13);
                    ConfirmedBook.FieldDate1 = aSqlDataReader.GetDateTime(14);
                    ConfirmedBook.FieldI5 = aSqlDataReader.GetInt32(15);
                    ConfirmedBook.FieldDate2 = aSqlDataReader.GetDateTime(16);
                    ConfirmedBook.FieldI6 = aSqlDataReader.GetInt32(17);
                    ConfirmedBook.FieldI7 = aSqlDataReader.GetInt32(18);
                    ConfirmedBook.FieldI8 = aSqlDataReader.GetInt32(19);

                    ListOfCategory.Add(ConfirmedBook);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfCategory.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }
        public CeylonAdaptor[] GetLastRegisteredCusomer()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetLastCustomerID", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor ConfirmedBook = new CeylonAdaptor();


                    ConfirmedBook.FieldI1 = aSqlDataReader.GetInt32(0);//id               
                    ConfirmedBook.FieldS1 = aSqlDataReader.GetString(1);//name
                    ConfirmedBook.FieldS3 = aSqlDataReader.GetString(3);//address
                    ConfirmedBook.FieldS2 = aSqlDataReader.GetString(4);//phone
                    ConfirmedBook.FieldS5 = aSqlDataReader.GetString(5);//nic

                   


                    ListOfCategory.Add(ConfirmedBook);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfCategory.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }

        public CeylonAdaptor[] SearchCustomerByID(string StartDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("SearchCustomerByID", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchPara";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(4);
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(5);

                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method


        //public CeylonAdaptor[] SearchCustomerByID()
        //{
        //    // Just read the details of due payments
        //    try
        //    {
        //        ArrayList ListOfCategory = new ArrayList();

        //        // Create new Databse Connection
        //        aSqlConnection = new SqlConnection(DataSource);

        //        // Open the Database Connection
        //        aSqlConnection.Open();

        //        aSqlCommand = new SqlCommand("SearchCustomerByID", aSqlConnection);


        //        aSqlCommand.CommandType = CommandType.StoredProcedure;
        //        aSqlDataReader = aSqlCommand.ExecuteReader();

        //        while (aSqlDataReader.Read())
        //        {
        //            CeylonAdaptor ConfirmedBook = new CeylonAdaptor();


        //            ConfirmedBook.FieldI1 = aSqlDataReader.GetInt32(0);
        //            ConfirmedBook.FieldS1 = aSqlDataReader.GetString(1);
        //            ConfirmedBook.FieldS2 = aSqlDataReader.GetString(4);
        //            ConfirmedBook.FieldS5 = aSqlDataReader.GetString(5);

        //            ListOfCategory.Add(ConfirmedBook);
        //        }

        //        _DataBase_Result_Message = "Database Read Successfully";
        //        return ((CeylonAdaptor[])ListOfCategory.ToArray(typeof(CeylonAdaptor)));

        //    }
        //    catch (Exception Ex)
        //    {
        //        _DataBase_Result_Message = "Database Error:-" + Ex.Message;
        //        return (null);
        //    }
        //    finally
        //    {
        //        // If connection is unclosed, connection will be closed in here
        //        if (aSqlConnection != null)
        //        {
        //            aSqlConnection.Close();
        //        }
        //    }

        //}
        public CeylonAdaptor[] GetCancelledBookings()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetCancelledBooking", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor ConfirmedBook = new CeylonAdaptor();


                    ConfirmedBook.FieldI1 = aSqlDataReader.GetInt32(0);
                    ConfirmedBook.FieldI2 = aSqlDataReader.GetInt32(1);
                    ConfirmedBook.FieldI3 = aSqlDataReader.GetInt32(2);
                    ConfirmedBook.FieldI4 = aSqlDataReader.GetInt32(3);
                    ConfirmedBook.FieldS1 = aSqlDataReader.GetString(4);
                    ConfirmedBook.FieldS2 = aSqlDataReader.GetString(5);
                    ConfirmedBook.FieldS3 = aSqlDataReader.GetString(6);
                    ConfirmedBook.FieldS4 = aSqlDataReader.GetString(7);
                    ConfirmedBook.FieldS5 = aSqlDataReader.GetString(8);
                    ConfirmedBook.FieldS6 = aSqlDataReader.GetString(9);
                    ConfirmedBook.FieldS7 = aSqlDataReader.GetString(10);
                    ConfirmedBook.FieldS8 = aSqlDataReader.GetString(11);
                    ConfirmedBook.FieldS9 = aSqlDataReader.GetString(12);
                    ConfirmedBook.FieldS10 = aSqlDataReader.GetString(13);
                    ConfirmedBook.FieldDate1 = aSqlDataReader.GetDateTime(14);
                    ConfirmedBook.FieldI5 = aSqlDataReader.GetInt32(15);
                    ConfirmedBook.FieldDate2 = aSqlDataReader.GetDateTime(16);
                    ConfirmedBook.FieldI6 = aSqlDataReader.GetInt32(17);
                    ConfirmedBook.FieldI7 = aSqlDataReader.GetInt32(18);
                    ConfirmedBook.FieldI8 = aSqlDataReader.GetInt32(19);

                    ListOfCategory.Add(ConfirmedBook);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfCategory.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }

        public CeylonAdaptor[] GetPDF()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetPDF", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor Document = new CeylonAdaptor();


                    Document.FieldI1 = aSqlDataReader.GetInt32(0);
                    Document.FieldI2 = aSqlDataReader.GetInt32(1);
                    Document.FieldI3 = aSqlDataReader.GetInt32(2);
                    Document.FieldI4 = aSqlDataReader.GetInt32(3);
                    Document.FieldS1 = aSqlDataReader.GetString(4);
                    Document.FieldS2 = aSqlDataReader.GetString(5);
                    Document.FieldS3 = aSqlDataReader.GetString(6);
                    Document.FieldS4 = aSqlDataReader.GetString(7);
                    Document.FieldS5 = aSqlDataReader.GetString(8);
                    Document.FieldS6 = aSqlDataReader.GetString(9);
                    Document.FieldS7 = aSqlDataReader.GetString(10);
                    Document.FieldS8 = aSqlDataReader.GetString(11);
                    Document.FieldS9 = aSqlDataReader.GetString(12);
                    Document.FieldS10 = aSqlDataReader.GetString(13);
                    Document.FieldDate1 = aSqlDataReader.GetDateTime(14);
                    Document.FieldI5 = aSqlDataReader.GetInt32(15);
                    Document.FieldDate2 = aSqlDataReader.GetDateTime(16);
                    Document.FieldI6 = aSqlDataReader.GetInt32(17);
                    Document.FieldI7 = aSqlDataReader.GetInt32(18);
                    Document.FieldI8 = aSqlDataReader.GetInt32(19);
                    Document.FieldS22 = aSqlDataReader.GetString(20);
                    Document.FieldI9 = aSqlDataReader.GetInt32(21);
                    Document.FieldDate3 = aSqlDataReader.GetDateTime(22);
                    Document.FieldI10 = aSqlDataReader.GetInt32(23);
                    Document.FieldI11 = aSqlDataReader.GetInt32(24);
                    Document.FieldI12 = aSqlDataReader.GetInt32(25);
                    Document.FieldD1 = aSqlDataReader.GetDecimal(26);
                    Document.FieldS11 = aSqlDataReader.GetString(27);
                    Document.FieldS13 = aSqlDataReader.GetString(28);
                    Document.FieldS14 = aSqlDataReader.GetString(29);
                    Document.FieldS15 = aSqlDataReader.GetString(30);
                    Document.FieldDate4 = aSqlDataReader.GetDateTime(31);
                    Document.FieldDate5 = aSqlDataReader.GetDateTime(32);
                    Document.FieldD2 = aSqlDataReader.GetDecimal(33);
                    Document.FieldS16 = aSqlDataReader.GetString(34);
                    Document.FieldS17 = aSqlDataReader.GetString(35);
                    Document.FieldS18 = aSqlDataReader.GetString(36);
                    Document.FieldS19 = aSqlDataReader.GetString(37);
                    Document.FieldS20 = aSqlDataReader.GetString(38);
                    Document.FieldS21 = aSqlDataReader.GetString(39);

                    ListOfCategory.Add(Document);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfCategory.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }

        public CeylonAdaptor[] GetCalendarDetails(string SearchParameter)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetCalendarDetails", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchDate";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor ConfirmedBook = new CeylonAdaptor();


                    ConfirmedBook.FieldI1 = aSqlDataReader.GetInt32(0);
                    ConfirmedBook.FieldI2 = aSqlDataReader.GetInt32(1);
                    ConfirmedBook.FieldI3 = aSqlDataReader.GetInt32(2);
                    ConfirmedBook.FieldI4 = aSqlDataReader.GetInt32(3);
                    ConfirmedBook.FieldS1 = aSqlDataReader.GetString(4);
                    ConfirmedBook.FieldS2 = aSqlDataReader.GetString(5);
                    ConfirmedBook.FieldS3 = aSqlDataReader.GetString(6);
                    ConfirmedBook.FieldS4 = aSqlDataReader.GetString(7);
                    ConfirmedBook.FieldS5 = aSqlDataReader.GetString(8);
                    ConfirmedBook.FieldS6 = aSqlDataReader.GetString(9);
                    ConfirmedBook.FieldS7 = aSqlDataReader.GetString(10);
                    ConfirmedBook.FieldS8 = aSqlDataReader.GetString(11);
                    ConfirmedBook.FieldS9 = aSqlDataReader.GetString(12);
                    ConfirmedBook.FieldS10 = aSqlDataReader.GetString(13);
                    ConfirmedBook.FieldDate1 = aSqlDataReader.GetDateTime(14);
                    ConfirmedBook.FieldI5 = aSqlDataReader.GetInt32(15);
                    ConfirmedBook.FieldDate2 = aSqlDataReader.GetDateTime(16);
                    ConfirmedBook.FieldI6 = aSqlDataReader.GetInt32(17);
                    ConfirmedBook.FieldI7 = aSqlDataReader.GetInt32(18);
                    ConfirmedBook.FieldI8 = aSqlDataReader.GetInt32(19);

                    ListOfCategory.Add(ConfirmedBook);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfCategory.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }
        public CeylonAdaptor[] GetDocumentDetails(string SearchParameter)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetDocument", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@EventID";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor Document = new CeylonAdaptor();


                    Document.FieldI1 = aSqlDataReader.GetInt32(0); //event ID
                    Document.FieldI2 = aSqlDataReader.GetInt32(1); //FK CustomerID
                    Document.FieldI3 = aSqlDataReader.GetInt32(2); //FK AgentID
                    Document.FieldI4 = aSqlDataReader.GetInt32(3); //FK PETID

                    Document.FieldS1 = aSqlDataReader.GetString(4); //Contact Name
                    Document.FieldS2 = aSqlDataReader.GetString(5);// Contact Number
                    Document.FieldS3 = aSqlDataReader.GetString(6);//Contact Address
                    Document.FieldS4 = aSqlDataReader.GetString(7); //Cpl Name
                    Document.FieldS5 = aSqlDataReader.GetString(8); // Spcl Note
                    Document.FieldS6 = aSqlDataReader.GetString(9); // venue
                    Document.FieldS7 = aSqlDataReader.GetString(10); // Customer Name
                    Document.FieldS8 = aSqlDataReader.GetString(11); // status
                    Document.FieldS9 = aSqlDataReader.GetString(12); // Event Type
                    Document.FieldS10 = aSqlDataReader.GetString(13); //Event Time

                    Document.FieldDate1 = aSqlDataReader.GetDateTime(14); //Event Date
                    Document.FieldI5 = aSqlDataReader.GetInt32(15);  // contract price
                    Document.FieldDate2 = aSqlDataReader.GetDateTime(16); // Transe Date

                    Document.FieldI6 = aSqlDataReader.GetInt32(17); // Transed By
                    Document.FieldI7 = aSqlDataReader.GetInt32(18); //Confirmed By
                    Document.FieldI8 = aSqlDataReader.GetInt32(19); //FK Usertype== advance paid


                    //Document.FieldS22 = aSqlDataReader.GetString(20); // time stamp

                    Document.FieldI9 = aSqlDataReader.GetInt32(21);  //BPayID
                    Document.FieldDate3 = aSqlDataReader.GetDateTime(22); //PayDate

                    Document.FieldI10 = aSqlDataReader.GetInt32(23); //FK EID
                    Document.FieldI11 = aSqlDataReader.GetInt32(24);// FK CustomerID
                    Document.FieldI12 = aSqlDataReader.GetInt32(25); //FK AgentID

                    Document.FieldD1 = aSqlDataReader.GetDecimal(26); // Amount

                    Document.FieldS11 = aSqlDataReader.GetString(27);// Payment Description
                    Document.FieldS13 = aSqlDataReader.GetString(28);// Payment Type
                    Document.FieldS14 = aSqlDataReader.GetString(29); //Bank Name
                    Document.FieldS15 = aSqlDataReader.GetString(30);// Cheque Number
                    Document.FieldDate4 = aSqlDataReader.GetDateTime(31);//Cheque Date
                    Document.FieldDate5 = aSqlDataReader.GetDateTime(32); //realise Date
                    Document.FieldD2 = aSqlDataReader.GetDecimal(33); // Realise amount
                    Document.FieldS16 = aSqlDataReader.GetString(34); // payment status
                    Document.FieldS17 = aSqlDataReader.GetString(35); // Pdetails1== account name
                    Document.FieldS18 = aSqlDataReader.GetString(36); // Pdetails2 == advanced date
                    Document.FieldS19 = aSqlDataReader.GetString(37);// Pdetails3 ==Advance highlight
                    Document.FieldS20 = aSqlDataReader.GetString(38);// Pdetails4
                    Document.FieldS21 = aSqlDataReader.GetString(39);// Pdetails5

                    ListOfCategory.Add(Document);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfCategory.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }

        public CeylonAdaptor[] SearchEventRateByEventID(string SearchParameter)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("SearchEventRateByEventID", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor Document = new CeylonAdaptor();


                    Document.FieldI1 = aSqlDataReader.GetInt32(0); // ID                  
                    Document.FieldS1 = aSqlDataReader.GetString(1); //rate
                    
                    ListOfCategory.Add(Document);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfCategory.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }
        public CeylonMiniAdaptor[] GetCalendarDate()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("BandCalendar", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();

                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0); //eventID
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(1);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(3);

                    ListOfCategory.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }



        public CeylonMiniAdaptor[] GetCurrentBookings(string StartDate, string EndDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("BCurrentBookedBan", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@StartDate";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);
                SqlParameter aSqlParameter1 = new SqlParameter();
                aSqlParameter1.ParameterName = "@EndDate";
                aSqlParameter1.SqlDbType = SqlDbType.VarChar;
                aSqlParameter1.Direction = ParameterDirection.Input;
                aSqlParameter1.Value = EndDate;
                aSqlCommand.Parameters.Add(aSqlParameter1);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(0);
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(1);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(2);

                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfSale.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonMiniAdaptor[] CheckUser(string SearchParameter)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();
                aSqlCommand = new SqlCommand("CheckUser", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();

                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    ListOfCategory.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of  Method

        /***************** Banquet Bookings Availibility By Date **********************/
        public CeylonAdaptor[] BBanAvailabilityByDate(string SearchParameter, string SearchParameter1, string DataSource)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();


                aSqlCommand = new SqlCommand("BBanAvailabilityByDate", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@StartDate";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);

                SqlParameter aSqlParameter1 = new SqlParameter();
                aSqlParameter1.ParameterName = "@EndDate";
                aSqlParameter1.SqlDbType = SqlDbType.VarChar;
                aSqlParameter1.Direction = ParameterDirection.Input;
                aSqlParameter1.Value = SearchParameter1;
                aSqlCommand.Parameters.Add(aSqlParameter1);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(0);
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(1);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(2);

                    //********** For Each Banquet Need a Morning and Evening Location **********/
                    //aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(3);
                    //aObjectForReports.FieldI4 = aSqlDataReader.GetInt32(4);

                    //********** For Each Banquet Need a Morning and Evening Location **********/
                    //aObjectForReports.FieldI5 = aSqlDataReader.GetInt32(5);
                    //aObjectForReports.FieldI6 = aSqlDataReader.GetInt32(6);
                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonAdaptor[] BCurrentBookedBan(string SearchParameter, string SearchParameter1, string DataSource)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();


                aSqlCommand = new SqlCommand("BCurrentBookedBan", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@StartDate";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);

                SqlParameter aSqlParameter1 = new SqlParameter();
                aSqlParameter1.ParameterName = "@EndDate";
                aSqlParameter1.SqlDbType = SqlDbType.VarChar;
                aSqlParameter1.Direction = ParameterDirection.Input;
                aSqlParameter1.Value = SearchParameter1;
                aSqlCommand.Parameters.Add(aSqlParameter1);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(3);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(4);
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(5);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(6);
                    aObjectForReports.FieldDate2 = aSqlDataReader.GetDateTime(7);
                    //aObjectForReports.FieldS5 = aSqlDataReader.GetString(8);
                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonAdaptor[] GetAllBAgent(string DataSource)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfRooms = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllBAgent", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();

                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(3);
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(4);
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(5);
                    aObjectForReports.FieldS6 = aSqlDataReader.GetString(6);
                    aObjectForReports.FieldS7 = aSqlDataReader.GetString(7);
                    aObjectForReports.FieldS8 = aSqlDataReader.GetString(8);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(9);
                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(10);
                    aObjectForReports.FieldS9 = aSqlDataReader.GetString(11);
                    aObjectForReports.FieldS10 = aSqlDataReader.GetString(12);
                    ListOfRooms.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfRooms.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End of Method
        public CeylonMiniAdaptor[] BGetAllBanTypes(string DataSource)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("BGetAllBanTypes", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForReports = new CeylonMiniAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    ListOfCategory.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of  Method
        public CeylonAdaptor[] BGetAllExPackages(string DataSource)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfRooms = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("BGetAllExPackages", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(0);
                    ListOfRooms.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfRooms.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End of Method

        public CeylonAdaptor[] BGenerateBookingPackagesLocal(string SearchParameter, string SearchParameter1, string SearchParameter2, string SearchParameter3, string DataSource)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfRooms = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();
                aSqlCommand = new SqlCommand("BGenerateBookingPackagesLocal", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);

                SqlParameter aSqlParameter1 = new SqlParameter();
                aSqlParameter1.ParameterName = "@SearchParameter1";
                aSqlParameter1.SqlDbType = SqlDbType.VarChar;
                aSqlParameter1.Direction = ParameterDirection.Input;
                aSqlParameter1.Value = SearchParameter1;
                aSqlCommand.Parameters.Add(aSqlParameter1);

                SqlParameter aSqlParameter2 = new SqlParameter();
                aSqlParameter2.ParameterName = "@SearchParameter2";
                aSqlParameter2.SqlDbType = SqlDbType.VarChar;
                aSqlParameter2.Direction = ParameterDirection.Input;
                aSqlParameter2.Value = SearchParameter2;
                aSqlCommand.Parameters.Add(aSqlParameter2);

                SqlParameter aSqlParameter3 = new SqlParameter();
                aSqlParameter3.ParameterName = "@SearchParameter3";
                aSqlParameter3.SqlDbType = SqlDbType.VarChar;
                aSqlParameter3.Direction = ParameterDirection.Input;
                aSqlParameter3.Value = SearchParameter3;
                aSqlCommand.Parameters.Add(aSqlParameter3);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(3);
                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(4);
                    aObjectForReports.FieldD2 = aSqlDataReader.GetDecimal(5);
                    aObjectForReports.FieldD3 = aSqlDataReader.GetDecimal(6);
                    aObjectForReports.FieldD4 = aSqlDataReader.GetDecimal(7);
                    ListOfRooms.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfRooms.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonAdaptor[] BGenerateBookingPackagesFore(string SearchParameter, string SearchParameter1, string SearchParameter2, string SearchParameter3, string DataSource)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfRooms = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();
                aSqlCommand = new SqlCommand("BGenerateBookingPackagesFore", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);

                SqlParameter aSqlParameter1 = new SqlParameter();
                aSqlParameter1.ParameterName = "@SearchParameter1";
                aSqlParameter1.SqlDbType = SqlDbType.VarChar;
                aSqlParameter1.Direction = ParameterDirection.Input;
                aSqlParameter1.Value = SearchParameter1;
                aSqlCommand.Parameters.Add(aSqlParameter1);

                SqlParameter aSqlParameter2 = new SqlParameter();
                aSqlParameter2.ParameterName = "@SearchParameter2";
                aSqlParameter2.SqlDbType = SqlDbType.VarChar;
                aSqlParameter2.Direction = ParameterDirection.Input;
                aSqlParameter2.Value = SearchParameter2;
                aSqlCommand.Parameters.Add(aSqlParameter2);

                SqlParameter aSqlParameter3 = new SqlParameter();
                aSqlParameter3.ParameterName = "@SearchParameter3";
                aSqlParameter3.SqlDbType = SqlDbType.VarChar;
                aSqlParameter3.Direction = ParameterDirection.Input;
                aSqlParameter3.Value = SearchParameter3;
                aSqlCommand.Parameters.Add(aSqlParameter3);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(3);
                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(4);
                    aObjectForReports.FieldD2 = aSqlDataReader.GetDecimal(5);
                    aObjectForReports.FieldD3 = aSqlDataReader.GetDecimal(6);
                    aObjectForReports.FieldD4 = aSqlDataReader.GetDecimal(7);
                    ListOfRooms.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfRooms.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method





        public CeylonAdaptor[] GetAllPackageParaB(string SearchParameter, string DataSource)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfRooms = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Check the Parametter is int or string and select the appropriate statement into the arraylist
                if (Regex.IsMatch(SearchParameter, @"^\d+$"))
                {
                    aSqlCommand = new SqlCommand("GetAllPackageByParaIntB", aSqlConnection);

                }
                else
                {
                    aSqlCommand = new SqlCommand("GetAllPackageByParaN", aSqlConnection);

                }

                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();

                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(3);
                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(4);
                    aObjectForReports.FieldD2 = aSqlDataReader.GetDecimal(5);
                    aObjectForReports.FieldD3 = aSqlDataReader.GetDecimal(6);
                    aObjectForReports.FieldD4 = aSqlDataReader.GetDecimal(7);
                    aObjectForReports.FieldD5 = aSqlDataReader.GetDecimal(8);
                    aObjectForReports.FieldD6 = aSqlDataReader.GetDecimal(9);
                    aObjectForReports.FieldD7 = aSqlDataReader.GetDecimal(10);
                    aObjectForReports.FieldD8 = aSqlDataReader.GetDecimal(11);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(12);
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(13);
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(14);
                    aObjectForReports.FieldS6 = aSqlDataReader.GetString(15);
                    aObjectForReports.FieldS7 = aSqlDataReader.GetString(16);
                    aObjectForReports.FieldS8 = aSqlDataReader.GetString(17);
                    aObjectForReports.FieldS9 = aSqlDataReader.GetString(18);
                    aObjectForReports.FieldS10 = aSqlDataReader.GetString(19);
                    aObjectForReports.FieldS11 = aSqlDataReader.GetString(20);
                    aObjectForReports.FielSd12 = aSqlDataReader.GetString(21);
                    aObjectForReports.FieldS13 = aSqlDataReader.GetString(22);
                    aObjectForReports.FieldS14 = aSqlDataReader.GetString(23);

                    ListOfRooms.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfRooms.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method

      

        public int AddAB(CeylonAdaptor NewSaleTable, string DataSource)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("BInsertABooking", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                int new_MEM_BASIC_ID = 0;
                SqlParameter aParameter = new SqlParameter("@NewBankID", SqlDbType.Int);
                aParameter.Direction = ParameterDirection.Output;
                aSqlCommand.Parameters.Add(aParameter);

                aSqlCommand.Parameters.Add("@BookingID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_CustomerID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_AgentID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_RoomID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_PackageID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@AccommodationType", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@CheckINType", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@CheckINDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@CheckOUTDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@NumberOfNights", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@BookingStatus", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@InitialBookingBy", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@CheckINBy", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@CheckOUTBy", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@NumberOfAdults", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NumberOfKids", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NumberOfInfants", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NumberOfAdultBeds", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NumberOfKidsBeds", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NumberOfInfantCots", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@Details1", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details2", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@MasterBillID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@TimeIn", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@TimeOUT", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@BookedDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@Details3", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details4", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details5", SqlDbType.VarChar);

                aSqlCommand.Parameters["@BookingID"].Value = NewSaleTable.FieldI30;
                aSqlCommand.Parameters["@FK_CustomerID"].Value = NewSaleTable.FieldI1;
                aSqlCommand.Parameters["@FK_AgentID"].Value = NewSaleTable.FieldI2;
                aSqlCommand.Parameters["@FK_RoomID"].Value = NewSaleTable.FieldI3;
                aSqlCommand.Parameters["@FK_PackageID"].Value = NewSaleTable.FieldI4;
                aSqlCommand.Parameters["@AccommodationType"].Value = NewSaleTable.FieldS1;
                aSqlCommand.Parameters["@CheckINType"].Value = NewSaleTable.FieldS2;
                aSqlCommand.Parameters["@CheckINDate"].Value = NewSaleTable.FieldDate1;
                aSqlCommand.Parameters["@CheckOUTDate"].Value = NewSaleTable.FieldDate2;
                aSqlCommand.Parameters["@NumberOfNights"].Value = NewSaleTable.FieldI5;
                aSqlCommand.Parameters["@BookingStatus"].Value = NewSaleTable.FieldS3;
                aSqlCommand.Parameters["@InitialBookingBy"].Value = NewSaleTable.FieldS4;
                aSqlCommand.Parameters["@CheckINBy"].Value = NewSaleTable.FieldS5;
                aSqlCommand.Parameters["@CheckOUTBy"].Value = NewSaleTable.FieldS6;
                aSqlCommand.Parameters["@NumberOfAdults"].Value = NewSaleTable.FieldI6;//Number of Adults
                aSqlCommand.Parameters["@NumberOfKids"].Value = NewSaleTable.FieldI7;//Number of Kids
                aSqlCommand.Parameters["@NumberOfInfants"].Value = NewSaleTable.FieldI8;
                aSqlCommand.Parameters["@NumberOfAdultBeds"].Value = NewSaleTable.FieldI9;
                aSqlCommand.Parameters["@NumberOfKidsBeds"].Value = NewSaleTable.FieldI10;
                aSqlCommand.Parameters["@NumberOfInfantCots"].Value = NewSaleTable.FieldI11;
                aSqlCommand.Parameters["@Details1"].Value = NewSaleTable.FieldS7;
                aSqlCommand.Parameters["@Details2"].Value = NewSaleTable.FieldS8;
                aSqlCommand.Parameters["@MasterBillID"].Value = NewSaleTable.FieldI12;
                aSqlCommand.Parameters["@TimeIn"].Value = NewSaleTable.FieldS20;
                aSqlCommand.Parameters["@TimeOUT"].Value = NewSaleTable.FieldS21;
                aSqlCommand.Parameters["@BookedDate"].Value = NewSaleTable.FieldDate5;//Booked Date
                aSqlCommand.Parameters["@Details3"].Value = NewSaleTable.FieldS22;
                aSqlCommand.Parameters["@Details4"].Value = NewSaleTable.FieldS23;
                aSqlCommand.Parameters["@Details5"].Value = NewSaleTable.FieldS24;


                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "A New Booking Added to the Database";
                if (aParameter.Value != DBNull.Value) new_MEM_BASIC_ID = Convert.ToInt32(aParameter.Value);
                return new_MEM_BASIC_ID;
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (0);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End of method
        public int AddABTrans(CeylonAdaptor NewSaleTable, string DataSource)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("BInsertABookingTrans", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                int new_MEM_BASIC_ID = 0;
                SqlParameter aParameter = new SqlParameter("@NewBankID", SqlDbType.Int);
                aParameter.Direction = ParameterDirection.Output;
                aSqlCommand.Parameters.Add(aParameter);

                aSqlCommand.Parameters.Add("@FK_BookingID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@Basis", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@RoomRatePerDay", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Discount", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@DiscountedRoomRatePerDay", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@AuthorisedBy", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@DateStart", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@DateEnd", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@NoOFBreakfast", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NoOFLunch", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NoOFEveSnack", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NoOFDinner", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NoSpecialPack1", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NoSpecialPack2", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NoSpecialPack3", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NoSpecialPack4", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NoSpecialPack5", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@SpecialRequests1", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@SpecialRequests2", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@SpecialRequests3", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@SubTotal", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Tax1", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Tax2", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Tax3", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Tax4", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Tax5", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Total", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Details1", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details2", SqlDbType.VarChar);

                aSqlCommand.Parameters["@FK_BookingID"].Value = NewSaleTable.FieldI1;
                aSqlCommand.Parameters["@Basis"].Value = NewSaleTable.FieldS1;
                aSqlCommand.Parameters["@RoomRatePerDay"].Value = NewSaleTable.FieldD1;
                aSqlCommand.Parameters["@Discount"].Value = NewSaleTable.FieldD2;
                aSqlCommand.Parameters["@DiscountedRoomRatePerDay"].Value = NewSaleTable.FieldD3;
                aSqlCommand.Parameters["@AuthorisedBy"].Value = NewSaleTable.FieldS2;
                aSqlCommand.Parameters["@DateStart"].Value = NewSaleTable.FieldDate1;
                aSqlCommand.Parameters["@DateEnd"].Value = NewSaleTable.FieldDate2;
                aSqlCommand.Parameters["@NoOFBreakfast"].Value = NewSaleTable.FieldI2;
                aSqlCommand.Parameters["@NoOFLunch"].Value = NewSaleTable.FieldI3;
                aSqlCommand.Parameters["@NoOFEveSnack"].Value = NewSaleTable.FieldI4;
                aSqlCommand.Parameters["@NoOFDinner"].Value = NewSaleTable.FieldI5;
                aSqlCommand.Parameters["@NoSpecialPack1"].Value = NewSaleTable.FieldI6;
                aSqlCommand.Parameters["@NoSpecialPack2"].Value = NewSaleTable.FieldI7;
                aSqlCommand.Parameters["@NoSpecialPack3"].Value = NewSaleTable.FieldI8;
                aSqlCommand.Parameters["@NoSpecialPack4"].Value = NewSaleTable.FieldI9;
                aSqlCommand.Parameters["@NoSpecialPack5"].Value = NewSaleTable.FieldI10;
                aSqlCommand.Parameters["@SpecialRequests1"].Value = NewSaleTable.FieldS3;
                aSqlCommand.Parameters["@SpecialRequests2"].Value = NewSaleTable.FieldS4;
                aSqlCommand.Parameters["@SpecialRequests3"].Value = NewSaleTable.FieldS5;
                aSqlCommand.Parameters["@SubTotal"].Value = NewSaleTable.FieldD4;
                aSqlCommand.Parameters["@Tax1"].Value = NewSaleTable.FieldD5;//USD Rate
                aSqlCommand.Parameters["@Tax2"].Value = NewSaleTable.FieldD6;//Adults Day Total USD 
                aSqlCommand.Parameters["@Tax3"].Value = NewSaleTable.FieldD7;//Kids Day Total USD 
                aSqlCommand.Parameters["@Tax4"].Value = NewSaleTable.FieldD8;
                aSqlCommand.Parameters["@Tax5"].Value = NewSaleTable.FieldD9;//Total Day Total USD 
                aSqlCommand.Parameters["@Total"].Value = NewSaleTable.FieldD10;
                aSqlCommand.Parameters["@Details1"].Value = NewSaleTable.FieldS6;
                aSqlCommand.Parameters["@Details2"].Value = NewSaleTable.FieldS7;



                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "A New Booking Trans Added to the Database";
                if (aParameter.Value != DBNull.Value) new_MEM_BASIC_ID = Convert.ToInt32(aParameter.Value);
                return new_MEM_BASIC_ID;
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (0);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End of method
        public CeylonAdaptor[] GetAllResevationDetailsTemporaryB(string DataSource)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllResevationDetailsTemporaryB", aSqlConnection);

                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(3);
                    aObjectForReports.FieldDate2 = aSqlDataReader.GetDateTime(4);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(5);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(6);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(7);
                    aObjectForReports.FieldI4 = aSqlDataReader.GetInt32(8);
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(9);
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(10);
                    //aObjectForReports.FieldS6 = aSqlDataReader.GetString(11);
                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method

        public int AddADailyPastryProduction(CeylonMiniAdaptor NewPastryWasatage, string DataSource)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("DailyInsertAPastryProduction", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                int new_MEM_BASIC_ID = 0;
                SqlParameter aParameter = new SqlParameter("@NewBankID", SqlDbType.Int);
                aParameter.Direction = ParameterDirection.Output;
                aSqlCommand.Parameters.Add(aParameter);

                aSqlCommand.Parameters.Add("@ProductionDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@Total", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Details", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@FromShop", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@ToShop", SqlDbType.VarChar);

                aSqlCommand.Parameters["@ProductionDate"].Value = NewPastryWasatage.FieldDate1;
                aSqlCommand.Parameters["@Total"].Value = NewPastryWasatage.FieldD1;
                aSqlCommand.Parameters["@Details"].Value = NewPastryWasatage.FieldS1;
                aSqlCommand.Parameters["@FromShop"].Value = NewPastryWasatage.FieldS2;
                aSqlCommand.Parameters["@ToShop"].Value = NewPastryWasatage.FieldS3;

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "New Pastry Production Record Added to the Database";
                if (aParameter.Value != DBNull.Value) new_MEM_BASIC_ID = Convert.ToInt32(aParameter.Value);
                return new_MEM_BASIC_ID;
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (0);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End of AddAPastryWastage(CeylonMiniAdaptor NewPastryCategory, string DataSource) Method 
        public bool AddADailyPastryProductionTransaction(CeylonMiniAdaptor NewPastryWastageTransaction, string DataSource)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("DailyInsertAPastryProductionTransaction", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@FK_PProductionID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_PItemID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@RetailPrice", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Quantity", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Total", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@ProductionDateDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@Details1", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details2", SqlDbType.VarChar);

                aSqlCommand.Parameters["@FK_PProductionID"].Value = NewPastryWastageTransaction.FieldI1;
                aSqlCommand.Parameters["@FK_PItemID"].Value = NewPastryWastageTransaction.FieldI2;
                aSqlCommand.Parameters["@RetailPrice"].Value = NewPastryWastageTransaction.FieldD1;
                aSqlCommand.Parameters["@Quantity"].Value = NewPastryWastageTransaction.FieldD2;
                aSqlCommand.Parameters["@Total"].Value = NewPastryWastageTransaction.FieldD3;
                aSqlCommand.Parameters["@ProductionDateDate"].Value = NewPastryWastageTransaction.FieldDate1;
                aSqlCommand.Parameters["@Details1"].Value = NewPastryWastageTransaction.FieldS1;
                aSqlCommand.Parameters["@Details2"].Value = NewPastryWastageTransaction.FieldS2;

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "New Pastry Production Transaction Record Added to the Database";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End of AddAPastryWastage(CeylonMiniAdaptor NewPastryCategory, string DataSource) Method 
        public bool DailyUpdateAPastryProduction(CeylonMiniAdaptor UpdateWastage, string DataSource)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("DailyUpdateAPastryProduction", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@WastageID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@WasteDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@WasteTotal", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Details", SqlDbType.VarChar);

                aSqlCommand.Parameters["@WastageID"].Value = UpdateWastage.FieldI1;
                aSqlCommand.Parameters["@WasteDate"].Value = UpdateWastage.FieldDate1;
                aSqlCommand.Parameters["@WasteTotal"].Value = UpdateWastage.FieldD1;
                aSqlCommand.Parameters["@Details"].Value = UpdateWastage.FieldS1;
                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "Selected Production is Updated";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End of UpdateAWastage(CeylonMiniAdaptor UpdateWastage, string DataSource) Method 
        public CeylonAdaptor[] DailyGeneratePastryProductionSheet(int SearchParameter, string DataSource)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();
                aSqlCommand = new SqlCommand("DailyGeneratePastryProductionReport", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@PWasteID";
                aSqlParameter.SqlDbType = SqlDbType.Int;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();

                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);//Wasateg Trans ID
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(1);//Wasatage ID
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(2);// Item ID
                    aObjectForReports.FieldD1 = Math.Round(aSqlDataReader.GetDecimal(3), 2);//Unit Price
                    aObjectForReports.FieldD2 = Math.Round(aSqlDataReader.GetDecimal(4), 3);//Quantity
                    aObjectForReports.FieldD3 = Math.Round(aSqlDataReader.GetDecimal(5), 2);//Total
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(6);//Date
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(7);//ItemName
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(8);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(9);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(10);
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(11);
                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of  Method


        public CeylonAdaptor[] XGenerateDailyOrdersByWaiter(string SearchParameter, string SearchParameter1, string DataSource)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();


                aSqlCommand = new SqlCommand("XGenerateDailyOrdersByWaiter", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@StartDate";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);

                SqlParameter aSqlParameter1 = new SqlParameter();
                aSqlParameter1.ParameterName = "@EndDate";
                aSqlParameter1.SqlDbType = SqlDbType.VarChar;
                aSqlParameter1.Direction = ParameterDirection.Input;
                aSqlParameter1.Value = SearchParameter1;
                aSqlCommand.Parameters.Add(aSqlParameter1);

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(3);
                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method


        public CeylonAdaptor[] BookingsGenerateTempBookingDetailsViaBookingIDB(int BookingID, string DataSource)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("BookingsGenerateTempBookingDetailsViaBookingIDB", aSqlConnection);

                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.Int;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = BookingID;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();

                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(0);// Customer Name
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(1);// Customer Phone 
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(2);// Customer Address
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(3);// Customer Email
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(4);// Check IN Type
                    aObjectForReports.FieldS6 = aSqlDataReader.GetString(5);// Customer Type
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(6); // Start Date
                    aObjectForReports.FieldDate2 = aSqlDataReader.GetDateTime(7); // End Date
                    aObjectForReports.FieldS7 = aSqlDataReader.GetString(8); // Room Type
                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(9); // Adults Total
                    aObjectForReports.FieldD2 = aSqlDataReader.GetDecimal(10); // Kids Total
                    aObjectForReports.FieldD3 = aSqlDataReader.GetDecimal(11); // Adults + Kids
                    aObjectForReports.FieldS8 = aSqlDataReader.GetString(12);//Authorised By
                    aObjectForReports.FieldS10 = aSqlDataReader.GetString(13);//Agent Name
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(14);//No of Adults 
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(15);//No of Adults 
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(16);//No of Adults 
                    aObjectForReports.FieldS9 = aSqlDataReader.GetString(17);//Acc Type
                    aObjectForReports.FieldS20 = aSqlDataReader.GetString(18);//Acc Type
                    aObjectForReports.FieldS21 = aSqlDataReader.GetString(19);//Acc Type
                    aObjectForReports.FieldS22 = aSqlDataReader.GetString(20);//Acc Type
                    aObjectForReports.FieldI5 = aSqlDataReader.GetInt32(21);//No of Adults 
                    aObjectForReports.FieldI6 = aSqlDataReader.GetInt32(22);//No of Adults 
                    aObjectForReports.FieldS23 = aSqlDataReader.GetString(23);//Acc Type
                    aObjectForReports.FieldS24 = aSqlDataReader.GetString(24);//Acc Type
                    aObjectForReports.FieldS25 = aSqlDataReader.GetString(25);//Acc Type
                    aObjectForReports.FieldI7 = aSqlDataReader.GetInt32(26);//No of Adults 
                    aObjectForReports.FieldD4 = aSqlDataReader.GetDecimal(27); // USDRate
                    aObjectForReports.FieldD5 = aSqlDataReader.GetDecimal(28); // USDRate
                    aObjectForReports.FieldD6 = aSqlDataReader.GetDecimal(29); // ExchangeRate
                    aObjectForReports.FieldD7 = aSqlDataReader.GetDecimal(30); // USDDiscountedRate
                    aObjectForReports.FieldS26 = aSqlDataReader.GetString(31);//Tour No
                    aObjectForReports.FieldS27 = aSqlDataReader.GetString(32);//Voucher No
                    aObjectForReports.FieldS28 = aSqlDataReader.GetString(33);//TimeIn
                    aObjectForReports.FieldS29 = aSqlDataReader.GetString(34);//TimeOut
                    aObjectForReports.FieldS30 = aSqlDataReader.GetString(35);
                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonMiniAdaptor BookingsGeneateCurrentBalanceB(int SearchParameter, string DataSource)
        {
            // Just read the details of due payments
            try
            {
                CeylonMiniAdaptor MealDetails = new CeylonMiniAdaptor();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Create command to get the all centers into the arraylist
                aSqlCommand = new SqlCommand("BookingsGeneateCurrentBalanceB", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@FK_BookingID";
                aSqlParameter.SqlDbType = SqlDbType.Int;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    MealDetails.FieldD1 = aSqlDataReader.GetDecimal(0);//Current Balance
                    MealDetails.FieldD2 = aSqlDataReader.GetDecimal(1);//Total Advance
                    MealDetails.FieldD3 = aSqlDataReader.GetDecimal(2);//Card Payment
                    MealDetails.FieldD4 = aSqlDataReader.GetDecimal(3);//Cash Payment
                    MealDetails.FieldD5 = aSqlDataReader.GetDecimal(4);//Cheque Payment
                    MealDetails.FieldD6 = aSqlDataReader.GetDecimal(5);//Agent Credit
                    MealDetails.FieldD7 = aSqlDataReader.GetDecimal(6);//Total Bill
                    MealDetails.FieldD8 = aSqlDataReader.GetDecimal(7);//Bank Payment

                }

                _DataBase_Result_Message = "Database Read Successfully";
                return (MealDetails);

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of  Method

        public CeylonAdaptor[] GetAllBookingsParaB(string SearchParameter, string DataSource)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfRooms = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Check the Parametter is int or string and select the appropriate statement into the arraylist
                if (Regex.IsMatch(SearchParameter, @"^\d+$"))
                {
                    aSqlCommand = new SqlCommand("BookingsByParaIntB", aSqlConnection);

                }
                else
                {
                    //aSqlCommand = new SqlCommand("ExchangeByPara", aSqlConnection);

                }

                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI14 = aSqlDataReader.GetInt32(0);//BookingID
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(1);//Customer ID
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(2);//Agent ID
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(3);//Room ID
                    aObjectForReports.FieldI4 = aSqlDataReader.GetInt32(4);//PackageID
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(5);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(6);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(7);
                    aObjectForReports.FieldDate2 = aSqlDataReader.GetDateTime(8);
                    aObjectForReports.FieldI5 = aSqlDataReader.GetInt32(9);//Number of Nights
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(10);//
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(11);
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(12);
                    aObjectForReports.FieldS6 = aSqlDataReader.GetString(13);
                    aObjectForReports.FieldI6 = aSqlDataReader.GetInt32(14);//No of Adults
                    aObjectForReports.FieldI7 = aSqlDataReader.GetInt32(15);//No of Kids
                    aObjectForReports.FieldI8 = aSqlDataReader.GetInt32(16);
                    aObjectForReports.FieldI9 = aSqlDataReader.GetInt32(17);
                    aObjectForReports.FieldI10 = aSqlDataReader.GetInt32(18);
                    aObjectForReports.FieldI11 = aSqlDataReader.GetInt32(19);
                    aObjectForReports.FieldS7 = aSqlDataReader.GetString(20);//BookingType
                    aObjectForReports.FieldS8 = aSqlDataReader.GetString(21);
                    aObjectForReports.FieldI12 = aSqlDataReader.GetInt32(22);
                    ListOfRooms.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfRooms.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public int GetNextBookingIDB(string DataSource)
        {
            // Just read the details of due payments
            try
            {
                int PastryItemID = 0;

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Create command to get the all centers into the arraylist
                aSqlCommand = new SqlCommand("GetNextBookingIDB", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {

                    PastryItemID = aSqlDataReader.GetInt32(0);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return (PastryItemID);

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (0);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method

        public bool UpdateABookingB(CeylonAdaptor NewSaleTable, string DataSource)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();


                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("BookingsUpdateABookingB", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@BookingID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_CustomerID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_AgentID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_RoomID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_PackageID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@AccommodationType", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@CheckINType", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@CheckINDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@CheckOUTDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@NumberOfNights", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@BookingStatus", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@InitialBookingBy", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@CheckINBy", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@CheckOUTBy", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@NumberOfAdults", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NumberOfKids", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NumberOfInfants", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NumberOfAdultBeds", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NumberOfKidsBeds", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NumberOfInfantCots", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@Details1", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details2", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@MasterBillID", SqlDbType.Int);

                aSqlCommand.Parameters["@BookingID"].Value = NewSaleTable.FieldI14;
                aSqlCommand.Parameters["@FK_CustomerID"].Value = NewSaleTable.FieldI1;
                aSqlCommand.Parameters["@FK_AgentID"].Value = NewSaleTable.FieldI2;
                aSqlCommand.Parameters["@FK_RoomID"].Value = NewSaleTable.FieldI3;
                aSqlCommand.Parameters["@FK_PackageID"].Value = NewSaleTable.FieldI4;
                aSqlCommand.Parameters["@AccommodationType"].Value = NewSaleTable.FieldS1;
                aSqlCommand.Parameters["@CheckINType"].Value = NewSaleTable.FieldS2;
                aSqlCommand.Parameters["@CheckINDate"].Value = NewSaleTable.FieldDate1;
                aSqlCommand.Parameters["@CheckOUTDate"].Value = NewSaleTable.FieldDate2;
                aSqlCommand.Parameters["@NumberOfNights"].Value = NewSaleTable.FieldI5;
                aSqlCommand.Parameters["@BookingStatus"].Value = NewSaleTable.FieldS3;
                aSqlCommand.Parameters["@InitialBookingBy"].Value = NewSaleTable.FieldS4;
                aSqlCommand.Parameters["@CheckINBy"].Value = NewSaleTable.FieldS5;
                aSqlCommand.Parameters["@CheckOUTBy"].Value = NewSaleTable.FieldS6;
                aSqlCommand.Parameters["@NumberOfAdults"].Value = NewSaleTable.FieldI6;//Number of Adults
                aSqlCommand.Parameters["@NumberOfKids"].Value = NewSaleTable.FieldI7;// Number of Kids
                aSqlCommand.Parameters["@NumberOfInfants"].Value = NewSaleTable.FieldI8;
                aSqlCommand.Parameters["@NumberOfAdultBeds"].Value = NewSaleTable.FieldI9;
                aSqlCommand.Parameters["@NumberOfKidsBeds"].Value = NewSaleTable.FieldI10;
                aSqlCommand.Parameters["@NumberOfInfantCots"].Value = NewSaleTable.FieldI11;
                aSqlCommand.Parameters["@Details1"].Value = NewSaleTable.FieldS7;
                aSqlCommand.Parameters["@Details2"].Value = NewSaleTable.FieldS8;
                aSqlCommand.Parameters["@MasterBillID"].Value = NewSaleTable.FieldI12;

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "Selected Booking is Updated";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End of Method 
        public bool UpdateABookingTransB(CeylonAdaptor NewSaleTable, string DataSource)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();


                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("BookingsUpdateABookingTransB", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@BookTransID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_BookingID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@Basis", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@RoomRatePerDay", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Discount", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@DiscountedRoomRatePerDay", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@AuthorisedBy", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@DateStart", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@DateEnd", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@NoOFBreakfast", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NoOFLunch", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NoOFEveSnack", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NoOFDinner", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NoSpecialPack1", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NoSpecialPack2", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NoSpecialPack3", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NoSpecialPack4", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@NoSpecialPack5", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@SpecialRequests1", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@SpecialRequests2", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@SpecialRequests3", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@SubTotal", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Tax1", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Tax2", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Tax3", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Tax4", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Tax5", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Total", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Details1", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details2", SqlDbType.VarChar);

                aSqlCommand.Parameters["@BookTransID"].Value = NewSaleTable.FieldI14;
                aSqlCommand.Parameters["@FK_BookingID"].Value = NewSaleTable.FieldI1;
                aSqlCommand.Parameters["@Basis"].Value = NewSaleTable.FieldS1;
                aSqlCommand.Parameters["@RoomRatePerDay"].Value = NewSaleTable.FieldD1;
                aSqlCommand.Parameters["@Discount"].Value = NewSaleTable.FieldD2;
                aSqlCommand.Parameters["@DiscountedRoomRatePerDay"].Value = NewSaleTable.FieldD3;
                aSqlCommand.Parameters["@AuthorisedBy"].Value = NewSaleTable.FieldS2;
                aSqlCommand.Parameters["@DateStart"].Value = NewSaleTable.FieldDate1;
                aSqlCommand.Parameters["@DateEnd"].Value = NewSaleTable.FieldDate2;
                aSqlCommand.Parameters["@NoOFBreakfast"].Value = NewSaleTable.FieldI2;
                aSqlCommand.Parameters["@NoOFLunch"].Value = NewSaleTable.FieldI3;
                aSqlCommand.Parameters["@NoOFEveSnack"].Value = NewSaleTable.FieldI4;
                aSqlCommand.Parameters["@NoOFDinner"].Value = NewSaleTable.FieldI5;
                aSqlCommand.Parameters["@NoSpecialPack1"].Value = NewSaleTable.FieldI6;
                aSqlCommand.Parameters["@NoSpecialPack2"].Value = NewSaleTable.FieldI7;
                aSqlCommand.Parameters["@NoSpecialPack3"].Value = NewSaleTable.FieldI8;
                aSqlCommand.Parameters["@NoSpecialPack4"].Value = NewSaleTable.FieldI9;
                aSqlCommand.Parameters["@NoSpecialPack5"].Value = NewSaleTable.FieldI10;
                aSqlCommand.Parameters["@SpecialRequests1"].Value = NewSaleTable.FieldS3;
                aSqlCommand.Parameters["@SpecialRequests2"].Value = NewSaleTable.FieldS4;
                aSqlCommand.Parameters["@SpecialRequests3"].Value = NewSaleTable.FieldS5;
                aSqlCommand.Parameters["@SubTotal"].Value = NewSaleTable.FieldD4;
                aSqlCommand.Parameters["@Tax1"].Value = NewSaleTable.FieldD5;//Exchange Rate
                aSqlCommand.Parameters["@Tax2"].Value = NewSaleTable.FieldD6;
                aSqlCommand.Parameters["@Tax3"].Value = NewSaleTable.FieldD7;
                aSqlCommand.Parameters["@Tax4"].Value = NewSaleTable.FieldD8;
                aSqlCommand.Parameters["@Tax5"].Value = NewSaleTable.FieldD9;
                aSqlCommand.Parameters["@Total"].Value = NewSaleTable.FieldD10;
                aSqlCommand.Parameters["@Details1"].Value = NewSaleTable.FieldS6;
                aSqlCommand.Parameters["@Details2"].Value = NewSaleTable.FieldS7;

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "Selected Booking Trans is Updated";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End of Method 
        public CeylonAdaptor[] GetAllResevationDetailsConfirmedB(string DataSource)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllResevationDetailsConfirmedB", aSqlConnection);

                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(3);
                    aObjectForReports.FieldDate2 = aSqlDataReader.GetDateTime(4);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(5);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(6);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(7);
                    aObjectForReports.FieldI4 = aSqlDataReader.GetInt32(8);
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(9);
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(10);
                    //aObjectForReports.FieldS6 = aSqlDataReader.GetString(11);

                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method

        public CeylonAdaptor[] GetAllResevationDetailsByParaB(string SearchParameter, string DataSource)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Check the Parametter is int or string and select the appropriate statement into the arraylist
                if (Regex.IsMatch(SearchParameter, @"^\d+$"))
                {
                    aSqlCommand = new SqlCommand("GetAllResevationDetailsByIDB", aSqlConnection);

                }
                else
                {
                    aSqlCommand = new SqlCommand("GetAllResevationDetailsByParaB", aSqlConnection);

                }
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(3);
                    aObjectForReports.FieldDate2 = aSqlDataReader.GetDateTime(4);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(5);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(6);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(7);
                    aObjectForReports.FieldI4 = aSqlDataReader.GetInt32(8);
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(9);
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(10);
                    //aObjectForReports.FieldS6 = aSqlDataReader.GetString(11);
                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method

        public CeylonAdaptor[] GetAllResevationDetailsAgentB(string DataSource)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllResevationDetailsAgentB", aSqlConnection);

                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(3);
                    aObjectForReports.FieldDate2 = aSqlDataReader.GetDateTime(4);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(5);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(6);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(7);
                    aObjectForReports.FieldI4 = aSqlDataReader.GetInt32(8);
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(9);
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(10);
                    //aObjectForReports.FieldS6 = aSqlDataReader.GetString(11);
                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method


        public CeylonAdaptor[] GetAllResevationDetailsCancelledB(string DataSource)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllResevationDetailsCancelledB", aSqlConnection);

                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(3);
                    aObjectForReports.FieldDate2 = aSqlDataReader.GetDateTime(4);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(5);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(6);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(7);
                    aObjectForReports.FieldI4 = aSqlDataReader.GetInt32(8);
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(9);
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(10);
                    //aObjectForReports.FieldS6 = aSqlDataReader.GetString(11);
                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonAdaptor[] GetAllResevationDetailsNoShowB(string DataSource)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllResevationDetailsNoShowB", aSqlConnection);

                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(3);
                    aObjectForReports.FieldDate2 = aSqlDataReader.GetDateTime(4);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(5);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(6);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(7);
                    aObjectForReports.FieldI4 = aSqlDataReader.GetInt32(8);
                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method

        public CeylonAdaptor[] GetAllResevationDetailsB(string DataSource)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllResevationDetailsB", aSqlConnection);

                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(3);
                    aObjectForReports.FieldDate2 = aSqlDataReader.GetDateTime(4);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(5);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(6);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(7);
                    aObjectForReports.FieldI4 = aSqlDataReader.GetInt32(8);
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(9);
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(10);
                    //aObjectForReports.FieldS6 = aSqlDataReader.GetString(11);
                    ListOfSale.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method


        public int AddAHotelRoomPaymentTableB(CeylonAdaptor NewSalePaymentsTable, string DataSource)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                //Create COmmand to Add a Council into the Council Table
                aSqlCommand = new SqlCommand("InsertAHotelRoomPaymentTableB", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                int new_MEM_BASIC_ID = 0;
                SqlParameter aParameter = new SqlParameter("@NewBankID", SqlDbType.Int);
                aParameter.Direction = ParameterDirection.Output;
                aSqlCommand.Parameters.Add(aParameter);

                aSqlCommand.Parameters.Add("@BPayDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@FK_BookingID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_CustomerID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@FK_AgentID", SqlDbType.Int);
                aSqlCommand.Parameters.Add("@PayingAmount", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@PaymentDescription", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@PaymentType", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@BankName", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@ChequeNumber", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@ChequeDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@RealiseDate", SqlDbType.DateTime);
                aSqlCommand.Parameters.Add("@RealiseAmount", SqlDbType.Decimal);
                aSqlCommand.Parameters.Add("@Status", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details1", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details2", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details3", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details4", SqlDbType.VarChar);
                aSqlCommand.Parameters.Add("@Details5", SqlDbType.VarChar);

                aSqlCommand.Parameters["@BPayDate"].Value = NewSalePaymentsTable.FieldDate1;
                aSqlCommand.Parameters["@FK_BookingID"].Value = NewSalePaymentsTable.FieldI3;
                aSqlCommand.Parameters["@FK_CustomerID"].Value = NewSalePaymentsTable.FieldI2;
                aSqlCommand.Parameters["@FK_AgentID"].Value = NewSalePaymentsTable.FieldI1;
                aSqlCommand.Parameters["@PayingAmount"].Value = NewSalePaymentsTable.FieldD1;
                aSqlCommand.Parameters["@PaymentType"].Value = NewSalePaymentsTable.FieldS1;
                aSqlCommand.Parameters["@ChequeNumber"].Value = NewSalePaymentsTable.FieldS2;
                aSqlCommand.Parameters["@ChequeDate"].Value = NewSalePaymentsTable.FieldDate2;
                aSqlCommand.Parameters["@RealiseDate"].Value = NewSalePaymentsTable.FieldDate3;
                aSqlCommand.Parameters["@RealiseAmount"].Value = NewSalePaymentsTable.FieldD2;
                aSqlCommand.Parameters["@Status"].Value = NewSalePaymentsTable.FieldS3;
                aSqlCommand.Parameters["@Details1"].Value = NewSalePaymentsTable.FieldS4;
                aSqlCommand.Parameters["@Details2"].Value = NewSalePaymentsTable.FieldS5;
                aSqlCommand.Parameters["@Details3"].Value = NewSalePaymentsTable.FieldS6;
                aSqlCommand.Parameters["@Details4"].Value = NewSalePaymentsTable.FieldS7;
                aSqlCommand.Parameters["@Details5"].Value = NewSalePaymentsTable.FieldS8;
                aSqlCommand.Parameters["@PaymentDescription"].Value = NewSalePaymentsTable.FieldS9;
                aSqlCommand.Parameters["@BankName"].Value = NewSalePaymentsTable.FieldS10;

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "A New Hotel Room Payment to the Database";
                if (aParameter.Value != DBNull.Value) new_MEM_BASIC_ID = Convert.ToInt32(aParameter.Value);
                return new_MEM_BASIC_ID;
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Sale Payment Error : " + aException.Message;
                return (0);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }//End  Method 

        public CeylonAdaptor[] BookingsAdvancePaymentBreakdownB(int BookingID, string DataSource)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Create command to get the all centers into the arraylist
                aSqlCommand = new SqlCommand("BookingsAdvancePaymentBreakdownB", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@FK_BookingID";
                aSqlParameter.SqlDbType = SqlDbType.Int;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = BookingID;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(1);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(3);
                    aObjectForReports.FieldD2 = aSqlDataReader.GetDecimal(4);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(5);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(6);
                    ListOfSale.Add(aObjectForReports);

                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonAdaptor[] BookingsGenerateGRCB(int BookingID, string DataSource)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Create command to get the all centers into the arraylist
                aSqlCommand = new SqlCommand("BookingsGenerateGRCB", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@FK_BookingID";
                aSqlParameter.SqlDbType = SqlDbType.Int;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = BookingID;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(0);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(1);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(3);
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(4);
                    aObjectForReports.FieldS6 = aSqlDataReader.GetString(5);
                    aObjectForReports.FieldS7 = aSqlDataReader.GetString(6);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(7);
                    aObjectForReports.FieldDate2 = aSqlDataReader.GetDateTime(8);
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(9);
                    aObjectForReports.FieldS8 = aSqlDataReader.GetString(10);
                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(11);
                    aObjectForReports.FieldS9 = aSqlDataReader.GetString(12);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(13);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(14);
                    aObjectForReports.FieldI4 = aSqlDataReader.GetInt32(15);
                    aObjectForReports.FieldS10 = aSqlDataReader.GetString(16);
                    aObjectForReports.FieldS11 = aSqlDataReader.GetString(17);//
                    aObjectForReports.FielSd12 = aSqlDataReader.GetString(18);//
                    aObjectForReports.FieldS13 = aSqlDataReader.GetString(19);
                    aObjectForReports.FieldDate3 = aSqlDataReader.GetDateTime(20);
                    aObjectForReports.FieldDate4 = aSqlDataReader.GetDateTime(21);
                    aObjectForReports.FieldS14 = aSqlDataReader.GetString(22);
                    aObjectForReports.FieldD2 = aSqlDataReader.GetDecimal(23);
                    aObjectForReports.FieldD4 = aSqlDataReader.GetDecimal(24); // USDRate
                    aObjectForReports.FieldD5 = aSqlDataReader.GetDecimal(25); // USDRate
                    aObjectForReports.FieldD6 = aSqlDataReader.GetDecimal(26); // ExchangeRate
                    aObjectForReports.FieldD7 = aSqlDataReader.GetDecimal(27); // USDDiscountedRate
                    aObjectForReports.FieldS15 = aSqlDataReader.GetString(28);
                    aObjectForReports.FieldS16 = aSqlDataReader.GetString(29);

                    ListOfSale.Add(aObjectForReports);

                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method

        public CeylonAdaptor[] GetAllBookingsTransParaB(string SearchParameter, string DataSource)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfRooms = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("BookingsTransByParaIntB", aSqlConnection);



                aSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = SearchParameter;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aObjectForReports = new CeylonAdaptor();
                    aObjectForReports.FieldI14 = aSqlDataReader.GetInt32(0);
                    aObjectForReports.FieldI1 = aSqlDataReader.GetInt32(1);
                    aObjectForReports.FieldS1 = aSqlDataReader.GetString(2);
                    aObjectForReports.FieldD1 = aSqlDataReader.GetDecimal(3);
                    aObjectForReports.FieldD2 = aSqlDataReader.GetDecimal(4);
                    aObjectForReports.FieldD3 = aSqlDataReader.GetDecimal(5);
                    aObjectForReports.FieldS2 = aSqlDataReader.GetString(6);
                    aObjectForReports.FieldDate1 = aSqlDataReader.GetDateTime(7);
                    aObjectForReports.FieldDate2 = aSqlDataReader.GetDateTime(8);
                    aObjectForReports.FieldI2 = aSqlDataReader.GetInt32(9);
                    aObjectForReports.FieldI3 = aSqlDataReader.GetInt32(10);
                    aObjectForReports.FieldI4 = aSqlDataReader.GetInt32(11);
                    aObjectForReports.FieldI5 = aSqlDataReader.GetInt32(12);
                    aObjectForReports.FieldI6 = aSqlDataReader.GetInt32(13);
                    aObjectForReports.FieldI7 = aSqlDataReader.GetInt32(14);
                    aObjectForReports.FieldI8 = aSqlDataReader.GetInt32(15);
                    aObjectForReports.FieldI9 = aSqlDataReader.GetInt32(16);
                    aObjectForReports.FieldI10 = aSqlDataReader.GetInt32(17);
                    aObjectForReports.FieldS3 = aSqlDataReader.GetString(18);
                    aObjectForReports.FieldS4 = aSqlDataReader.GetString(19);
                    aObjectForReports.FieldS5 = aSqlDataReader.GetString(20);
                    aObjectForReports.FieldD4 = aSqlDataReader.GetDecimal(21);
                    aObjectForReports.FieldD5 = aSqlDataReader.GetDecimal(22);
                    aObjectForReports.FieldD6 = aSqlDataReader.GetDecimal(23);
                    aObjectForReports.FieldD7 = aSqlDataReader.GetDecimal(24);
                    aObjectForReports.FieldD8 = aSqlDataReader.GetDecimal(25);
                    aObjectForReports.FieldD9 = aSqlDataReader.GetDecimal(26);
                    aObjectForReports.FieldD10 = aSqlDataReader.GetDecimal(27);
                    aObjectForReports.FieldS6 = aSqlDataReader.GetString(28);
                    aObjectForReports.FieldS7 = aSqlDataReader.GetString(29);
                    ListOfRooms.Add(aObjectForReports);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfRooms.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method

        public CeylonMiniAdaptor[] AgentType()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("AgentType", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor GetAgent = new CeylonMiniAdaptor();

                    GetAgent.FieldI1 = aSqlDataReader.GetInt32(0);//ID
                    GetAgent.FieldS1 = aSqlDataReader.GetString(1);//Details
                    GetAgent.FieldS2 = aSqlDataReader.GetString(2);//Colour
                    GetAgent.FieldS3 = aSqlDataReader.GetString(3);//Fixed Rate
                    GetAgent.FieldS4 = aSqlDataReader.GetString(4);//Special Rate
                    GetAgent.FieldS5 = aSqlDataReader.GetString(5);//Based Rate
                    GetAgent.FieldS6 = aSqlDataReader.GetString(6);//NA
                    GetAgent.FieldS7 = aSqlDataReader.GetString(7);//NA
                    GetAgent.FieldS8 = aSqlDataReader.GetString(8);//NA
                    GetAgent.FieldDate1 = aSqlDataReader.GetDateTime(9);//Date
                    GetAgent.FieldD1 = aSqlDataReader.GetDecimal(10);//NA
                    GetAgent.FieldS9 = aSqlDataReader.GetString(11);//NA
                    GetAgent.FieldS10 = aSqlDataReader.GetString(1);//NA

                    ListOfCategory.Add(GetAgent);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of  CeylonMiniAdaptor[] GetAllCategory(string DataSource) Method


        public CeylonMiniAdaptor[] PlayerInfo()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("Player", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor GetPlayerinfo = new CeylonMiniAdaptor();

                    GetPlayerinfo.FieldI1 = aSqlDataReader.GetInt32(0);//Player ID
                    GetPlayerinfo.FieldS1 = aSqlDataReader.GetString(1);//Player Name
                    GetPlayerinfo.FieldS2 = aSqlDataReader.GetString(2);//Player Address
                    GetPlayerinfo.FieldS3 = aSqlDataReader.GetString(3);//Player Phone
                    GetPlayerinfo.FieldS4 = aSqlDataReader.GetString(4);//Player Email
                    GetPlayerinfo.FieldDate1 = aSqlDataReader.GetDateTime(5);//Player DOB
                    GetPlayerinfo.FieldDate2 = aSqlDataReader.GetDateTime(6);//Player Registered Date
                    GetPlayerinfo.FieldS5 = aSqlDataReader.GetString(7);//Details1
                    GetPlayerinfo.FieldS6 = aSqlDataReader.GetString(8);//Details2
                    GetPlayerinfo.FieldS7 = aSqlDataReader.GetString(9);//Details3
                    GetPlayerinfo.FieldS8 = aSqlDataReader.GetString(10);//Details4
                    GetPlayerinfo.FieldS9 = aSqlDataReader.GetString(11);//Details5


                    ListOfCategory.Add(GetPlayerinfo);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End

        public CeylonMiniAdaptor[] GetDepartments()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetDepartments", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor GetDepartmentinfo = new CeylonMiniAdaptor();

                    GetDepartmentinfo.FieldI1 = aSqlDataReader.GetInt32(0);//Department ID
                    GetDepartmentinfo.FieldS1 = aSqlDataReader.GetString(1);//Department Name
                    GetDepartmentinfo.FieldS2 = aSqlDataReader.GetString(2);//Details1
                    GetDepartmentinfo.FieldS3 = aSqlDataReader.GetString(3);//Details2
                    GetDepartmentinfo.FieldS4 = aSqlDataReader.GetString(4);//Details3
                    GetDepartmentinfo.FieldS5 = aSqlDataReader.GetString(5);//Details4
                    GetDepartmentinfo.FieldS6 = aSqlDataReader.GetString(6);//Details5




                    ListOfCategory.Add(GetDepartmentinfo);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End


        public CeylonMiniAdaptor[] EventType()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("EventType", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForAgents = new CeylonMiniAdaptor();

                    aObjectForAgents.FieldI1 = aSqlDataReader.GetInt32(0);//ID
                    aObjectForAgents.FieldS1 = aSqlDataReader.GetString(1);//Details
                    aObjectForAgents.FieldDate1 = aSqlDataReader.GetDateTime(2);//Date
                    aObjectForAgents.FieldS2 = aSqlDataReader.GetString(3);//Colour
                    aObjectForAgents.FieldS3 = aSqlDataReader.GetString(4);//Fixed Rate
                    aObjectForAgents.FieldS4 = aSqlDataReader.GetString(5);//Special Rate
                    aObjectForAgents.FieldS5 = aSqlDataReader.GetString(6);//Based Rate
                    aObjectForAgents.FieldS6 = aSqlDataReader.GetString(7);//NA
                    ListOfCategory.Add(aObjectForAgents);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End
        public CeylonMiniAdaptor[] GetAllPaymentDepartmentsTypes()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllPaymentDepartmentsTypes", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForAgents = new CeylonMiniAdaptor();

                    aObjectForAgents.FieldI1 = aSqlDataReader.GetInt32(0);//ID
                    aObjectForAgents.FieldS1 = aSqlDataReader.GetString(1);//Details
                   
                    ListOfCategory.Add(aObjectForAgents);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End

        public CeylonMiniAdaptor[] GetAllStaffForExpenseReport()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllStaffForExpenseReport", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonMiniAdaptor aObjectForAgents = new CeylonMiniAdaptor();

                    aObjectForAgents.FieldI1 = aSqlDataReader.GetInt32(0);//Player ID
                    aObjectForAgents.FieldS1 = aSqlDataReader.GetString(1);//Name
                   
                    ListOfCategory.Add(aObjectForAgents);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonMiniAdaptor[])ListOfCategory.ToArray(typeof(CeylonMiniAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End
        public string GetEventRate(int EventID)
        {
            // Just read the details of due payments
            try
            {
                string TableAvailability = "";

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                // Create command to get the all centers into the arraylist
                aSqlCommand = new SqlCommand("GetEventRate", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchParameter";
                aSqlParameter.SqlDbType = SqlDbType.Int;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = EventID;
                aSqlCommand.Parameters.Add(aSqlParameter);
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {

                    TableAvailability = aSqlDataReader.GetString(0);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return (TableAvailability);

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return ("");
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method


        public CeylonAdaptor[] ZSearchTentativeBookingsByDate(string StartDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("ZSearchTentativeBookingsByDate", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchDate";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);
               

                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aTentativeBook = new CeylonAdaptor();

                    aTentativeBook.FieldI1 = aSqlDataReader.GetInt32(0);
                    aTentativeBook.FieldI2 = aSqlDataReader.GetInt32(1);
                    aTentativeBook.FieldI3 = aSqlDataReader.GetInt32(2);
                    aTentativeBook.FieldI4 = aSqlDataReader.GetInt32(3);
                    aTentativeBook.FieldS1 = aSqlDataReader.GetString(4);
                    aTentativeBook.FieldS2 = aSqlDataReader.GetString(5);
                    aTentativeBook.FieldS3 = aSqlDataReader.GetString(6);
                    aTentativeBook.FieldS4 = aSqlDataReader.GetString(7);
                    aTentativeBook.FieldS5 = aSqlDataReader.GetString(8);
                    aTentativeBook.FieldS6 = aSqlDataReader.GetString(9);
                    aTentativeBook.FieldS7 = aSqlDataReader.GetString(10);
                    aTentativeBook.FieldS8 = aSqlDataReader.GetString(11);
                    aTentativeBook.FieldS9 = aSqlDataReader.GetString(12);
                    aTentativeBook.FieldS10 = aSqlDataReader.GetString(13);
                    aTentativeBook.FieldDate1 = aSqlDataReader.GetDateTime(14);
                    aTentativeBook.FieldI5 = aSqlDataReader.GetInt32(15);
                    aTentativeBook.FieldDate2 = aSqlDataReader.GetDateTime(16);
                    aTentativeBook.FieldI6 = aSqlDataReader.GetInt32(17);
                    aTentativeBook.FieldI7 = aSqlDataReader.GetInt32(18);
                    aTentativeBook.FieldI8 = aSqlDataReader.GetInt32(19);

                    ListOfSale.Add(aTentativeBook);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonAdaptor[] ZSearchCancelledBookingsByDate(string StartDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("ZSearchCancelledBookingsByDate", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchDate";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);


                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor ConfirmedBook = new CeylonAdaptor();

                    ConfirmedBook.FieldI1 = aSqlDataReader.GetInt32(0);
                    ConfirmedBook.FieldI2 = aSqlDataReader.GetInt32(1);
                    ConfirmedBook.FieldI3 = aSqlDataReader.GetInt32(2);
                    ConfirmedBook.FieldI4 = aSqlDataReader.GetInt32(3);
                    ConfirmedBook.FieldS1 = aSqlDataReader.GetString(4);
                    ConfirmedBook.FieldS2 = aSqlDataReader.GetString(5);
                    ConfirmedBook.FieldS3 = aSqlDataReader.GetString(6);
                    ConfirmedBook.FieldS4 = aSqlDataReader.GetString(7);
                    ConfirmedBook.FieldS5 = aSqlDataReader.GetString(8);
                    ConfirmedBook.FieldS6 = aSqlDataReader.GetString(9);
                    ConfirmedBook.FieldS7 = aSqlDataReader.GetString(10);
                    ConfirmedBook.FieldS8 = aSqlDataReader.GetString(11);
                    ConfirmedBook.FieldS9 = aSqlDataReader.GetString(12);
                    ConfirmedBook.FieldS10 = aSqlDataReader.GetString(13);
                    ConfirmedBook.FieldDate1 = aSqlDataReader.GetDateTime(14);
                    ConfirmedBook.FieldI5 = aSqlDataReader.GetInt32(15);
                    ConfirmedBook.FieldDate2 = aSqlDataReader.GetDateTime(16);
                    ConfirmedBook.FieldI6 = aSqlDataReader.GetInt32(17);
                    ConfirmedBook.FieldI7 = aSqlDataReader.GetInt32(18);
                    ConfirmedBook.FieldI8 = aSqlDataReader.GetInt32(19);

                    ListOfSale.Add(ConfirmedBook);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonAdaptor[] ZSearchConfirmedBookingsByDate(string StartDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("ZSearchConfirmedBookingsByDate", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchDate";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);


                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor ConfirmedBook = new CeylonAdaptor();

                    ConfirmedBook.FieldI1 = aSqlDataReader.GetInt32(0);
                    ConfirmedBook.FieldI2 = aSqlDataReader.GetInt32(1);
                    ConfirmedBook.FieldI3 = aSqlDataReader.GetInt32(2);
                    ConfirmedBook.FieldI4 = aSqlDataReader.GetInt32(3);
                    ConfirmedBook.FieldS1 = aSqlDataReader.GetString(4);
                    ConfirmedBook.FieldS2 = aSqlDataReader.GetString(5);
                    ConfirmedBook.FieldS3 = aSqlDataReader.GetString(6);
                    ConfirmedBook.FieldS4 = aSqlDataReader.GetString(7);
                    ConfirmedBook.FieldS5 = aSqlDataReader.GetString(8);
                    ConfirmedBook.FieldS6 = aSqlDataReader.GetString(9);
                    ConfirmedBook.FieldS7 = aSqlDataReader.GetString(10);
                    ConfirmedBook.FieldS8 = aSqlDataReader.GetString(11);
                    ConfirmedBook.FieldS9 = aSqlDataReader.GetString(12);
                    ConfirmedBook.FieldS10 = aSqlDataReader.GetString(13);
                    ConfirmedBook.FieldDate1 = aSqlDataReader.GetDateTime(14);
                    ConfirmedBook.FieldI5 = aSqlDataReader.GetInt32(15);
                    ConfirmedBook.FieldDate2 = aSqlDataReader.GetDateTime(16);
                    ConfirmedBook.FieldI6 = aSqlDataReader.GetInt32(17);
                    ConfirmedBook.FieldI7 = aSqlDataReader.GetInt32(18);
                    ConfirmedBook.FieldI8 = aSqlDataReader.GetInt32(19);

                    ListOfSale.Add(ConfirmedBook);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method
        public CeylonAdaptor[] ZSearchBookingsHistoryByDate(string StartDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("ZSearchBookingsHistoryByDate", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchDate";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);


                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor ConfirmedBook = new CeylonAdaptor();

                    ConfirmedBook.FieldI1 = aSqlDataReader.GetInt32(0);
                    ConfirmedBook.FieldI2 = aSqlDataReader.GetInt32(1);
                    ConfirmedBook.FieldI3 = aSqlDataReader.GetInt32(2);
                    ConfirmedBook.FieldI4 = aSqlDataReader.GetInt32(3);
                    ConfirmedBook.FieldS1 = aSqlDataReader.GetString(4);
                    ConfirmedBook.FieldS2 = aSqlDataReader.GetString(5);
                    ConfirmedBook.FieldS3 = aSqlDataReader.GetString(6);
                    ConfirmedBook.FieldS4 = aSqlDataReader.GetString(7);
                    ConfirmedBook.FieldS5 = aSqlDataReader.GetString(8);
                    ConfirmedBook.FieldS6 = aSqlDataReader.GetString(9);
                    ConfirmedBook.FieldS7 = aSqlDataReader.GetString(10);
                    ConfirmedBook.FieldS8 = aSqlDataReader.GetString(11);
                    ConfirmedBook.FieldS9 = aSqlDataReader.GetString(12);
                    ConfirmedBook.FieldS10 = aSqlDataReader.GetString(13);
                    ConfirmedBook.FieldDate1 = aSqlDataReader.GetDateTime(14);
                    ConfirmedBook.FieldI5 = aSqlDataReader.GetInt32(15);
                    ConfirmedBook.FieldDate2 = aSqlDataReader.GetDateTime(16);
                    ConfirmedBook.FieldI6 = aSqlDataReader.GetInt32(17);
                    ConfirmedBook.FieldI7 = aSqlDataReader.GetInt32(18);
                    ConfirmedBook.FieldI8 = aSqlDataReader.GetInt32(19);

                    ListOfSale.Add(ConfirmedBook);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method

        public bool InsertToRequestTable(CeylonAdaptor NewCustomer)
        {
            try
            {
                //Create new Database Connection
                aSqlConnection = new SqlConnection(DataSource);

                //Open the Database Connection
                aSqlConnection.Open();

                
                aSqlCommand = new SqlCommand("InsertToRequestTable", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;

                aSqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Phone", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@Info", SqlDbType.NVarChar);
                aSqlCommand.Parameters.Add("@RDateTime", SqlDbType.DateTime);
               

                aSqlCommand.Parameters["@Name"].Value = NewCustomer.FieldS1;
                aSqlCommand.Parameters["@Phone"].Value = NewCustomer.FieldS2;
                aSqlCommand.Parameters["@Email"].Value = NewCustomer.FieldS3;
                aSqlCommand.Parameters["@Info"].Value = NewCustomer.FieldS4;             
                aSqlCommand.Parameters["@RDateTime"].Value = NewCustomer.FieldDate1;
                

                aSqlCommand.ExecuteNonQuery();
                _DataBase_Result_Message = "New request Added to the Database";
                return (true);
            }
            catch (Exception aException)
            {
                _DataBase_Result_Message = "Database Error : " + aException.Message;
                return (false);
            }
            finally
            {
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }
        }

        public CeylonAdaptor[] GetAllCRequests()
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfCategory = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("GetAllCRequests", aSqlConnection);


                aSqlCommand.CommandType = CommandType.StoredProcedure;
                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor aTentativeBook = new CeylonAdaptor();


                    aTentativeBook.FieldI1 = aSqlDataReader.GetInt32(0);                  
                    aTentativeBook.FieldS1 = aSqlDataReader.GetString(1);
                    aTentativeBook.FieldS2 = aSqlDataReader.GetString(2);
                    aTentativeBook.FieldS3 = aSqlDataReader.GetString(3);
                    aTentativeBook.FieldS4 = aSqlDataReader.GetString(4);                 
                    aTentativeBook.FieldDate1 = aSqlDataReader.GetDateTime(5);
                    

                    ListOfCategory.Add(aTentativeBook);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfCategory.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }
        public CeylonAdaptor[] ZSearchCRequestsByDate(string StartDate)
        {
            // Just read the details of due payments
            try
            {
                ArrayList ListOfSale = new ArrayList();

                // Create new Databse Connection
                aSqlConnection = new SqlConnection(DataSource);

                // Open the Database Connection
                aSqlConnection.Open();

                aSqlCommand = new SqlCommand("ZSearchCRequestsByDate", aSqlConnection);
                aSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter aSqlParameter = new SqlParameter();
                aSqlParameter.ParameterName = "@SearchDate";
                aSqlParameter.SqlDbType = SqlDbType.VarChar;
                aSqlParameter.Direction = ParameterDirection.Input;
                aSqlParameter.Value = StartDate;
                aSqlCommand.Parameters.Add(aSqlParameter);


                aSqlDataReader = aSqlCommand.ExecuteReader();

                while (aSqlDataReader.Read())
                {
                    CeylonAdaptor ConfirmedBook = new CeylonAdaptor();

                    ConfirmedBook.FieldI1 = aSqlDataReader.GetInt32(0);
                    ConfirmedBook.FieldS1 = aSqlDataReader.GetString(1);
                    ConfirmedBook.FieldS2 = aSqlDataReader.GetString(2);
                    ConfirmedBook.FieldS3 = aSqlDataReader.GetString(3);
                    ConfirmedBook.FieldS4 = aSqlDataReader.GetString(4);
                    ConfirmedBook.FieldDate1 = aSqlDataReader.GetDateTime(5);

                    ListOfSale.Add(ConfirmedBook);
                }

                _DataBase_Result_Message = "Database Read Successfully";
                return ((CeylonAdaptor[])ListOfSale.ToArray(typeof(CeylonAdaptor)));

            }
            catch (Exception Ex)
            {
                _DataBase_Result_Message = "Database Error:-" + Ex.Message;
                return (null);
            }
            finally
            {
                // If connection is unclosed, connection will be closed in here
                if (aSqlConnection != null)
                {
                    aSqlConnection.Close();
                }
            }

        }//End of Method

    }//End of Manager_DAO
}//End of namespace 
