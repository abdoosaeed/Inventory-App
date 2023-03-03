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
    public partial class ProductForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-BUH2NDQ\SQLEXPRESS;Initial Catalog=inventoryDB;Integrated Security=True");

        DataTable dt = new DataTable();
        

        public ProductForm()
        {
            InitializeComponent();
            LoadProduct();
            display_Data();
        }

        public void LoadProduct()
        {
            display_Data();

        }

       

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void DeleterButton1_Click(object sender, EventArgs e)
        {
            Delete_Formcs delete = new Delete_Formcs();
            delete.Show();
        }

        public void display_Data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * From ProductInformation";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvProduct.DataSource = dt;
            con.Close();
        }
        private void Product_Form_Load(object sender, EventArgs e)
        {
            display_Data();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Add_Form add = new Add_Form();
            add.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Update_cs Update = new Update_cs();
            Update.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Delete_Formcs Delete = new Delete_Formcs();
            Delete.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * From ProductInformation where @ProductName = ProductName", con);
            cmd.Parameters.AddWithValue("@ProductName", txtSearch.Text);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvProduct.DataSource = dt;
            con.Close();

            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Want To Delete All Data?", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-BUH2NDQ\\SQLEXPRESS;Initial Catalog=inventoryDB;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete from ProductInformation", con);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Deleted");
            }
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerForm customerForm = new CustomerForm();
            customerForm.ShowDialog();

        }

        private void productsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ProductForm productForm = new ProductForm();
            productForm.ShowDialog();
        }

 
        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrderForm orderForm = new OrderForm();
            orderForm.ShowDialog();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            display_Data();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserForm userForm = new UserForm();
            userForm.ShowDialog();
        }
    }
}

// boudy
// abdelrahman saeed is pushing 