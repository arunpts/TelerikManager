using System.Data;
using System.Data.SqlClient;
using TelerikManager.Interface;
using TelerikManager.Models;

namespace TelerikManager.Implementation
{
    public class ManagerImplementation : IManager
    {
        private readonly IConfiguration Configuration;

        public ManagerImplementation(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Manager> GetAllManagerDetails(string SearchText, string SelectedPlace,string SelectedEmail)
        {
            List<Manager> lstManager = new List<Manager>();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("spGettblManagersearch", Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@tnID", ID);
                cmd.Parameters.AddWithValue("@tcSearchText", SearchText);
                cmd.Parameters.AddWithValue("@tcPlace", SelectedPlace);
                cmd.Parameters.AddWithValue("@tcEmail", SelectedEmail);
                Connection.Open();
                using (SqlDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Manager objManager = new Manager();
                        objManager.ID = Convert.ToInt32(dataReader["ID"]);
                        objManager.Name = Convert.ToString(dataReader["Name"]);
                        objManager.Email = Convert.ToString(dataReader["Email"]);
                        objManager.Phone = Convert.ToString(dataReader["Phone"]);
                        objManager.Place = Convert.ToString(dataReader["Place"]);
                        objManager.EnteredBy = Convert.ToString(dataReader["EnteredBy"]);
                        objManager.EnteredDate = Convert.ToDateTime(dataReader["EnteredDate"]);
                        objManager.UpdatedBy = Convert.ToString(dataReader["UpdatedBy"]);
                        objManager.UpdatedDate = dataReader["UpdatedDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)dataReader["UpdatedDate"];

                        lstManager.Add(objManager);
                    }

                    Connection.Close();
                }

            }
            return lstManager;
        }
        public List<Manager> GetPlaceList()
        {
            List<Manager> lstPlace = new List<Manager>();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("spDistinctPlace", Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                Connection.Open();
                using (SqlDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Manager objManager = new Manager();
                        //objManager.ID = Convert.ToInt32(dataReader["ID"]);
                       
                        objManager.Place = Convert.ToString(dataReader["Place"]);
                        
                        lstPlace.Add(objManager);
                    }

                    Connection.Close();
                }

            }
            return lstPlace;
        }
        public List<Manager> GetEmailList()
        {
            List<Manager> lstEmail = new List<Manager>();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("spDistinctEmail", Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                Connection.Open();
                using (SqlDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Manager objManager = new Manager();
                        //objManager.ID = Convert.ToInt32(dataReader["ID"]);

                        objManager.Email = Convert.ToString(dataReader["Email"]);

                        lstEmail.Add(objManager);
                    }

                    Connection.Close();
                }

            }
            return lstEmail;
        }
        public Manager GetManagerDetails(int ID)
        {

            Manager objManager = new Manager();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
         {
              SqlCommand cmd = new SqlCommand("spGettblManagerSearch", connection);
               cmd.CommandType = CommandType.StoredProcedure;
              cmd.Parameters.AddWithValue("@tnID", ID);
               //cmd.Parameters.AddWithValue("@tcSearchText", SearchText);
                connection.Open();
               using (SqlDataReader dataReader = cmd.ExecuteReader())

                {
                   if (dataReader.Read())

                    {

                       objManager.ID = Convert.ToInt32(dataReader["ID"]);
                       objManager.Name = Convert.ToString(dataReader["Name"]);
                      objManager.Email = Convert.ToString(dataReader["Email"]);
                       objManager.Phone = Convert.ToString(dataReader["Phone"]);
                      objManager.Place = Convert.ToString(dataReader["Place"]);
                       objManager.EnteredBy = Convert.ToString(dataReader["EnteredBy"]);
                       objManager.EnteredDate = Convert.ToDateTime(dataReader["EnteredDate"]);
                       objManager.UpdatedBy = Convert.ToString(dataReader["UpdatedBy"]);
                       objManager.UpdatedDate = dataReader["UpdatedDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)dataReader["UpdatedDate"];
                        

                   }
               }
           }
           return objManager;
        }
        public Manager AddManagerDetails(Manager objManager)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spCreatetblManager", Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tcName", objManager.Name);
                cmd.Parameters.AddWithValue("@tcEmail", objManager.Email);
                cmd.Parameters.AddWithValue("@tcPhone", objManager.Phone);
                cmd.Parameters.AddWithValue("@tcPlace", objManager.Place);
                cmd.Parameters.AddWithValue("@tcEnteredBy","Admin");

                Connection.Open();
                cmd.ExecuteNonQuery();
                Connection.Close();
            }
            return objManager;
        }
        public void UpdateManagerDetails(Manager objManager)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                //Check ID
                SqlCommand cmd = new SqlCommand("spGettblManager_ID", Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tnID", objManager.ID);
                Connection.Open();
                var reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    Connection.Close();

                }
                reader.Close();
                //ID Found
                SqlCommand updatecmd = new SqlCommand("spUpdatetblManager", Connection);
                updatecmd.CommandType = CommandType.StoredProcedure;
                updatecmd.Parameters.AddWithValue("@tnID", objManager.ID);
                updatecmd.Parameters.AddWithValue("@tcName", objManager.Name);
                updatecmd.Parameters.AddWithValue("@tcEmail", objManager.Email);
                updatecmd.Parameters.AddWithValue("@tcPhone", objManager.Phone);
                updatecmd.Parameters.AddWithValue("@tcPlace", objManager.Place);
                updatecmd.Parameters.AddWithValue("@tcUpdatedBy", "Admin");
                updatecmd.ExecuteNonQuery();
                Connection.Close();
            }
        }
        public void DeleteManagerDetails(int ID)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                //Check id
                SqlCommand cmd = new SqlCommand("spGettblManager_ID", Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tnID", ID);
                Connection.Open();
                var reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    Connection.Close();

                }
                reader.Close();
                //find id
                SqlCommand deletecmd = new SqlCommand("spDeletetblManager", Connection);
                deletecmd.CommandType = CommandType.StoredProcedure;
                deletecmd.Parameters.AddWithValue("@tnID", ID);
                deletecmd.ExecuteNonQuery();
                Connection.Close();
            }
        }

       
    }
}
