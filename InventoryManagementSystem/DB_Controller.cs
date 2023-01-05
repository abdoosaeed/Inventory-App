using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace InventoryManagementSystem
{
    public class DB_Controller
    {
        private static DB_Controller _instance = null;
        private static SqlConnection con = null;
        SqlDataReader dr;
        static object _syncObject = new object();
        SqlCommand cmd;

        private DB_Controller()
        {
            string conString = "Data Source=DESKTOP-BUH2NDQ\\SQLEXPRESS;Initial Catalog=inventoryDB;Integrated Security=True";
            try
            {
                con = new SqlConnection(conString);

            }

            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }
        public bool LogIn(string username, string password)
        {
            con.Open();
            cmd = new SqlCommand("select * from SignUp where Name='" + username + "' and Password='" + password + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                con.Close();
                return true;
            }
            else
            {
                dr.Close();
                con.Close();
                return false;
            }
            con.Close();
        }
        public string SignUp(string username, string password)
        {
            

            con.Open();
            cmd = new SqlCommand("select * from SignUp where Name='" + username + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                return "name already exist";
                con.Close();
            }
            else
            {
                dr.Close();
                cmd = new SqlCommand("insert into SignUp values(@Name,@Password)", con);
                cmd.Parameters.AddWithValue("Name", username);
                cmd.Parameters.AddWithValue("Password", password);
                cmd.ExecuteNonQuery();
                con.Close();
                return "Created your account success";
            }
        }

        public string Test_con()
        {
            string conString = "Data Source=DESKTOP-BUH2NDQ\\SQLEXPRESS;Initial Catalog=inventoryDB;Integrated Security=True";

            using (SqlConnection Conn = new SqlConnection(conString))
            {

                Conn.Open();
                if (Conn.State == System.Data.ConnectionState.Open)
                {
                    return "success connection";
                }
                else
                {
                    return "error in connection";
                }
                Conn.Close();
            }

        }
        public static DB_Controller Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new DB_Controller();
                        }
                    }
                }
                return _instance;
            }
        }

    }
}
