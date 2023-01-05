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
    public partial class Update_cs : Form
    {
        public Update_cs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-BUH2NDQ\\SQLEXPRESS;Initial Catalog=inventoryDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update ProductInformation set Qty= @Qty ,Price = @price where @ProductName = ProductName", con);

            cmd.Parameters.AddWithValue("@ProductName", (ProductNameText.Text));
            cmd.Parameters.AddWithValue("@Qty", int.Parse(QtyText.Text));
            cmd.Parameters.AddWithValue("@Price", int.Parse(PriceText.Text));




            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Product Edited Successfully");
        }

        private void ProductNameText_TextChanged(object sender, EventArgs e)
        {

        }

        private void Update_cs_Load(object sender, EventArgs e)
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
                ProductNameText.AutoCompleteCustomSource = MyCollection;
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection("Data Source=DESKTOP-BUH2NDQ\\SQLEXPRESS;Initial Catalog=inventoryDB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from ProductInformation where ProductName = @ProductName", Conn);
            cmd.Parameters.AddWithValue("@ProductName", (ProductNameText.Text));
            Conn.Open();
            SqlDataReader DR1 = cmd.ExecuteReader();
            if (DR1.Read())
            {
                QtyText.Text = DR1.GetValue(1).ToString();
                PriceText.Text = DR1.GetValue(2).ToString();
            }
            Conn.Close();
        }
    }
}
