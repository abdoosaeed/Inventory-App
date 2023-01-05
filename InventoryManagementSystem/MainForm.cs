using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            
        }

        //to show subform form in mainform
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            openChildForm(new UserForm());
            this.Hide();
            UserForm userForm = new UserForm();
            userForm.ShowDialog();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            openChildForm(new CustomerForm());
            this.Hide();
            CustomerForm customerForm = new CustomerForm();
            customerForm.ShowDialog();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            //openChildForm(new CategoryForm());
            this.Hide();
            CategoryForm categoryForm = new CategoryForm();
            categoryForm.ShowDialog();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            //openChildForm(new ProductForm());
            this.Hide();
            ProductForm productForm = new ProductForm();
            productForm.ShowDialog();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            openChildForm(new OrderForm());
            this.Hide();
            OrderForm orderForm = new OrderForm();
            orderForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
