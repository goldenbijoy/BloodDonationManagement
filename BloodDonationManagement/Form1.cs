using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodDonationManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoginForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            string user = userName.Text;
            string pass = password.Text;
            if (user.Equals("admin") && pass.Equals("admin"))
            {
                this.Hide();
                new Viewlist().Show();
            }
            else
            {
                MessageBox.Show("User name or Password invalid.");
            }
        }

        private void userName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
