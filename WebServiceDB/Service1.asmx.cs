using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace WebServiceDB
{
    /// <summary>
    /// Service1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return DateTime.Now.ToString();
        }

        [WebMethod]
        public void InsertUserDetails(int UID, string Uname,int Uage,string Usex,string Udate,string Password)
        {
            // Write some SQL INSERT statement
            string SQL = "INSERT INTO tbUser VALUES ('" + UID + "', '" + Uname + "', " + Uage + ",'" + Usex + "','" + Udate + "', '" + Password + "')";
            
            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);
            // Execute SQL command
            cmd.ExecuteNonQuery();

            // Close & Disconnect from DB
            conn.Close();
        }

        [WebMethod]
        public List<User> GetAllUser()
        {
            List<User> UserList = new List<User>();

            // Write some SQL statement
            string SQL = "SELECT * FROM tbUser";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    User s = new User();
                    s.Uname = reader["Uname"].ToString();
                    s.Usex = reader["Usex"].ToString();
                    s.Udate = reader["Udate"].ToString();
                    s.Uage = int.Parse(reader["Uage"].ToString());
                    s.UID = int.Parse(reader["UID"].ToString());
                    s.Password = reader["Password"].ToString();
                    UserList.Add(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            reader.Close();
            conn.Close();

            return UserList;
        }

        [WebMethod]
        public List<User> FindUser(string searchstring)
        {
            List<User> UserList = new List<User>();

            // Write some SQL statement
            string SQL = "SELECT * FROM tbUser WHERE Uname LIKE '%" + searchstring + "%'";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    User s = new User();
                    s.Uname = reader["Uname"].ToString();
                    s.Usex = reader["Usex"].ToString();
                    s.Udate = reader["Udate"].ToString();
                    s.Uage = int.Parse(reader["Uage"].ToString());
                    s.UID = int.Parse(reader["UID"].ToString());
                    s.Password = reader["Password"].ToString();
                    UserList.Add(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            reader.Close();
            conn.Close();

            return UserList;
        }

        [WebMethod]
        public User FindUID(string searchstring)
        {
           User s = new User ();

            // Write some SQL statement
           string SQL = "SELECT * FROM tbUser WHERE UID = '" + searchstring + "'";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    s.Uname = reader["Uname"].ToString();
                    s.Usex = reader["Usex"].ToString();
                    s.Udate = reader["Udate"].ToString();
                    s.Uage = int.Parse(reader["Uage"].ToString());
                    s.UID = int.Parse(reader["UID"].ToString());
                    s.Password = reader["Password"].ToString();
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            reader.Close();
            conn.Close();

            return s;
        }
        [WebMethod]
        public void InsertDeviceDetails(int DID, string Dname, string Dintroduction, int Dappearance)
        {
            // Write some SQL INSERT statement
            string SQL = "INSERT INTO tbDevice VALUES (" + DID + ", '" + Dname + "', " + Dintroduction + "," + Dappearance+  ")";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);
            // Execute SQL command
            cmd.ExecuteNonQuery();

            // Close & Disconnect from DB
            conn.Close();
        }

        [WebMethod]
        public List<Device> FindDevice(string searchstring)
        {
            List<Device> DeviceList = new List<Device>();

            // Write some SQL statement
            string SQL = "SELECT * FROM tbDevice WHERE Dname LIKE '%" + searchstring + "%'";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    Device s = new Device();
                    s.Dname = reader["Dname"].ToString();
                    s.Dintroduction = reader["Dintroduction"].ToString();
                    s.Dappearance = int.Parse(reader["Dappearance"].ToString());
                    s.DID = int.Parse(reader["DID"].ToString());
                    DeviceList.Add(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            reader.Close();
            conn.Close();

            return DeviceList;
        }

        [WebMethod]
        public List<Device> GetAllDevice()
        {
            List<Device> DeviceList = new List<Device>();

            // Write some SQL statement
            string SQL = "SELECT * FROM tbDevice";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    Device s = new Device();
                    s.Dname = reader["Dname"].ToString();
                    s.Dintroduction = reader["Dintroduction"].ToString();
                    s.Dappearance = int.Parse(reader["Dappearance"].ToString());
                    s.DID = int.Parse(reader["DID"].ToString());
                    DeviceList.Add(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            reader.Close();
            conn.Close();

            return DeviceList;
        }

        [WebMethod]
        public List<Chat> FindChatByUID(string searchstring)
        {
            List<Chat> ChatList = new List<Chat>();

            // Write some SQL statement
            string SQL = "SELECT * FROM tbChat WHERE UID = '" + searchstring + "'";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    Chat s = new Chat();
                    s.ChatID = int.Parse(reader["ChatID"].ToString());
                    s.DID = int.Parse(reader["DID"].ToString());
                    s.UID = int.Parse(reader["UID"].ToString());
                    s.Comment = reader["Comment"].ToString();
                    ChatList.Add(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            reader.Close();
            conn.Close();

            return ChatList;
        }

        [WebMethod]
        public List<Chat> FindChatByDID(string searchstring)
        {
            List<Chat> ChatList = new List<Chat>();

            // Write some SQL statement
            string SQL = "SELECT * FROM tbChat WHERE DID = '" + searchstring + "'";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    Chat s = new Chat();
                    s.ChatID = int.Parse(reader["ChatID"].ToString());
                    s.DID = int.Parse(reader["DID"].ToString());
                    s.UID = int.Parse(reader["UID"].ToString());
                    s.Comment = reader["Comment"].ToString();
                    ChatList.Add(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            reader.Close();
            conn.Close();

            return ChatList;
        }

        [WebMethod]
        public void InsertChatDetails(int ChatID, int DID, int UID, string Comment)
        {
            // Write some SQL INSERT statement
            string SQL = "INSERT INTO tbChat VALUES ('" + ChatID + "', '" + DID + "','" + UID + "','" + Comment + "')";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);
            // Execute SQL command
            cmd.ExecuteNonQuery();

            // Close & Disconnect from DB
            conn.Close();
        }

        [WebMethod]
        public List<Chat> GetAllChat()
        {
            List<Chat> ChatList = new List<Chat>();

            // Write some SQL statement
            string SQL = "SELECT * FROM tbChat";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    Chat s = new Chat();
                    s.ChatID = int.Parse(reader["ChatID"].ToString());
                    s.DID = int.Parse(reader["DID"].ToString());
                    s.UID = int.Parse(reader["UID"].ToString());
                    s.Comment = reader["Comment"].ToString();
                    ChatList.Add(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            reader.Close();
            conn.Close();

            return ChatList;
        }

    }
}