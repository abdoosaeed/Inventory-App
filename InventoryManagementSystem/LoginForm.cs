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
    
    public partial class LoginForm : Form
    {
        DB_Controller controller = DB_Controller.Instance;
        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPass.Checked == false)
                txtPass.UseSystemPasswordChar = true;
            
            else
                txtPass.UseSystemPasswordChar = false;
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPass.Clear();    
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Applicaton", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtPass.Text != string.Empty || txtName.Text != string.Empty)
                {
                    bool value = controller.LogIn(txtName.Text, txtPass.Text);
                    if (value)
                    {
                        MessageBox.Show($"Welcome {txtName}");
                        this.Hide();
                        MainForm home = new MainForm();
                        home.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
                //cm = new SqlCommand("SELECT * FROM tbUser WHERE username=@username AND password=@password", con);
                //cm.Parameters.AddWithValue("@username", txtName.Text);
                //cm.Parameters.AddWithValue("@password", txtPass.Text);
                //con.Open();
                //dr = cm.ExecuteReader();
                //dr.Read();
                //if (dr.HasRows)
                //{
                //    MessageBox.Show("Welcome " + dr["fullname"].ToString() + " | ", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    MainForm main = new MainForm();
                //    this.Hide();
                //    main.ShowDialog();

            //}
            //else
            //{
            //}
            //con.Close();
        }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=DESKTOP-BUH2NDQ\SQLEXPRESS;Initial Catalog=inventoryDB;Integrated Security=True");
            cn.Open();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            DB_Controller controller = DB_Controller.Instance;
            label5.Text = controller.Test_con();
        }
    }
}
