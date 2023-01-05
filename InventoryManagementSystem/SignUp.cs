using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace InventoryManagementSystem
{
    public partial class SignUp : Form
    {
        DB_Controller controller = DB_Controller.Instance;

        public SignUp()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string value = "";
            if (txtpassconf.Text != string.Empty || txtpass.Text != string.Empty || txtname2.Text != string.Empty)
            {
                if (txtpass.Text == txtpassconf.Text)
                {
                    value = controller.SignUp(txtname2.Text, txtpass.Text);
                    MessageBox.Show(value, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    LoginForm login = new LoginForm();
                    login.ShowDialog();
                }
                else
                {
                    MessageBox.Show(value, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(value, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void txtname_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.ShowDialog();
        }
    }
}
