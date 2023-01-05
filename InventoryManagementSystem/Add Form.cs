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
    public partial class Add_Form : Form
    {
        public Add_Form()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-BUH2NDQ\\SQLEXPRESS;Initial Catalog=inventoryDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into ProductInformation values (@ProductName  , @Qty ,@price )", con);
            cmd.Parameters.AddWithValue("@ProductName", (ProductNameText.Text));


            cmd.Parameters.AddWithValue("@Qty", int.Parse(QtyText.Text));
            cmd.Parameters.AddWithValue("@Price", int.Parse(PriceText.Text));




            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Product Added Successfully");
        }
    }
    
}
