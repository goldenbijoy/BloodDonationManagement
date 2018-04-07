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

namespace BloodDonationManagement
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            new Options().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name, age, date, gender, blood, phone, email;
            name = me.Text;
            age = ge.Text;
            date = ate.Value.ToString();
            gender = ender.SelectedItem.ToString();
            blood = bgroup.SelectedItem.ToString();
            phone = pnumber.Text;
            email = mail.Text;

            string conString = "server=SS\\SQLEXPRESS; Database= info; Integrated Security=True";

           /* MessageBox.Show(name);
            MessageBox.Show(email);
            MessageBox.Show(age);
            MessageBox.Show(date);
            MessageBox.Show(blood);
            MessageBox.Show(gender);
            MessageBox.Show(phone);*/

            SqlConnection con = new SqlConnection(conString);

            con.Open();

            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "insert into task values('" + name + "','" + age + "','" + gender + "','"+ blood + "','"+date+ "','"+ phone + "','"+ email+"')";
                SqlCommand cmd = new SqlCommand(q, con);
                //MessageBox.Show(q);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Connection made successfuly");
            }
            con.Close();
            Hide();
            new Options().Show();
            
        }
    }
}
