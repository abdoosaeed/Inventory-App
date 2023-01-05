using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class Delete_Formcs : Form
    {
        public Delete_Formcs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-BUH2NDQ\\SQLEXPRESS;Initial Catalog=inventoryDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete ProductInformation where @ProductName = ProductName", con);
            cmd.Parameters.AddWithValue("@ProductName", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted");
        }

        private void Delete_Formcs_Load(object sender, EventArgs e)
        {
            string ConString = "Data Source=DESKTOP-BUH2NDQ\\SQLEXPRESS;Initial Catalog=inventoryDB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(ConString))
            {
                SqlCommand cmd = new SqlCommand("SELECT ProductName FROM ProductInformation", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    MyCollection.Add(reader.GetString(0));
                }
                textBox1.AutoCompleteCustomSource = MyCollection;
                con.Close();
            }
        }
    }
}
