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
    public partial class Viewlist : Form
    {
        public Viewlist()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            new Form1().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string conString = "server=SS\\SQLEXPRESS; Database= info; Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);
            string ccmd = "Select * FROM task";

            string z = textBox1.Text;
            string blood;
            string zz = DateTime.Now.AddMonths(-3).ToString();

            try
            {
                blood = bgroup.SelectedItem.ToString();
            }
            catch
            {
                blood = null;
            }
            if (blood == "ALL" && z!="" && !checkBox1.Checked)
            {
                ccmd = "SELECT * FROM task where (Name = '" + z + "' OR [Phone Number] = '" + z + "' OR Email = '" + z + "')";
            }
            else if (blood == "ALL" && z !="" && checkBox1.Checked)
            {
                ccmd = "SELECT * FROM task where [Last Donation] <= '" + zz + "'AND (Name = '" + z + "' OR [Phone Number] = '" + z + "' OR Email = '" + z + "')";
            }
            else if (blood == "ALL" && checkBox1.Checked)
            {
                ccmd = "SELECT * FROM task where [Last Donation] <= '" + zz + "'";
            }
            else if (blood == "ALL")
            {
                blood = null;
            }
            else if (checkBox1.Checked && blood !=null)
            {

                if(z!="") ccmd = "SELECT * FROM task where [Blood Group] = '" + blood + "' AND [Last Donation] <= '"+zz+"'AND (Name = '"+z+"' OR [Phone Number] = '"+z+"' OR Email = '"+z+"')" ;
                else
                {
                   ccmd = "SELECT * FROM task where [Blood Group] = '" + blood + "' AND [Last Donation] <= '" + zz + "'";
                }
            }
            else if (!checkBox1.Checked && blood !=null)
            {
                if(z=="") ccmd = "SELECT * FROM task where [Blood Group] = '" + blood  + "'";
                else
                {
                    ccmd = "SELECT * FROM task where [Blood Group] = '" + blood + "' AND (Name = '" + z + "' OR [Phone Number] = '" + z + "' OR Email = '" + z + "')";
                }
            }
            else if (!checkBox1.Checked && blood == null && z != "")
            {
                ccmd = "SELECT * FROM task where  Name = '" + z + "' OR [Phone Number] = '" + z + "' OR Email = '" + z + "'";
            }
            else if (checkBox1.Checked && blood == null && z != "")
            {

                ccmd = "SELECT * FROM task where [Last Donation] <= '" + zz + "'AND (Name = '" + z + "' OR [Phone Number] = '" + z + "' OR Email = '" + z + "')";
            }
            
            SqlCommand cmd = new SqlCommand(ccmd, con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            dataGridView1.DataSource = bsource;
        }

        private void Viewlist_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string name, age, date, gender, blood, phone, email;
            name = me.Text;
            age = ge.Text;
            date = ate.Value.ToString();
            int recheck = 0;
            try
            {
                gender = ender.SelectedItem.ToString();
            }
            catch
            {
                gender = "";
                recheck = 1;
            }
            try
            {
                blood = comboBox1.SelectedItem.ToString();
            }
            catch
            {
                blood = "";
                recheck = 2;
            }
            
            phone = pnumber.Text;
            email = mail.Text;

            bool mcheck;
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                mcheck = (addr.Address == email);
            }
            catch
            {
                mcheck = false;
            }
           

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

            if (con.State == System.Data.ConnectionState.Open && recheck == 0 && mcheck)
            {
                string q = "insert into task values('" + name + "','" + age + "','" + gender + "','" + blood + "','" + date + "','" + phone + "','" + email + "')";
                SqlCommand cmd = new SqlCommand(q, con);
                //MessageBox.Show(q);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Connection made successfuly");
                MessageBox.Show("added to database");
            }
            else
            {
                if (recheck == 1) MessageBox.Show("Check Gender");
                else if (recheck == 2) MessageBox.Show("Check Blood Group");
                else if (mcheck == false) MessageBox.Show("Check Email");
            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string z = id.Text;
            string k = z;
            try
            {
                int zz = int.Parse(z);
                z = zz.ToString();
            }
            catch
            {
                z = "";
                MessageBox.Show("recheck id");
            }
            if (z != "")
            {
                string conString = "server=SS\\SQLEXPRESS; Database= info; Integrated Security=True";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string ccmd = "DELETE FROM info.dbo.task where ID = " + k;
                SqlCommand cmd = new SqlCommand(ccmd, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted");
                con.Close();
            }


        }

        private void bgroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string conString = "server=SS\\SQLEXPRESS; Database= info; Integrated Security=True";
            string z = id.Text;
            string k = z;
                try
                {
                    int zz = int.Parse(z);
                    z = zz.ToString();
                }
                catch
                {
                    z = "";
                    MessageBox.Show("recheck id");
                }
            if (z != "")
            {
                SqlConnection con = new SqlConnection(conString);

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                SqlDataReader read = (null);
                //MessageBox.Show(z);
                con.Open();
                string ccmd = "Select * FROM task where ID = " + k;
                com.CommandText = (ccmd);
                read = com.ExecuteReader();
                try
                {
                    read.Read();

                    me.Text = read["Name"].ToString();
                    ge.Text = read["Age"].ToString();
                    ate.Value = Convert.ToDateTime(read["Last Donation"]);
                    ender.SelectedIndex = ender.Items.IndexOf(read["Gender"].ToString());
                    bgroup.SelectedIndex = bgroup.Items.IndexOf(read["Blood Group"].ToString());
                    mail.Text = read["Email"].ToString();
                    pnumber.Text = read["Phone Number"].ToString();
                }
                catch
                {
                    MessageBox.Show("No data found");
                }
                    con.Close();

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
                string z = id.Text;
                string k = z;
                try
                {
                    int zz = int.Parse(z);
                    z = zz.ToString();
                }
                catch
                {
                    z = "";
                    MessageBox.Show("recheck id");
                }
                if (z != "")
                {


                    string name, age, date, gender, blood, phone, email;
                    name = me.Text;
                    age = ge.Text;
                    date = ate.Value.ToString();
                    int recheck = 0;
                    try
                    {
                        gender = ender.SelectedItem.ToString();
                    }
                    catch
                    {
                        gender = "";
                        recheck = 1;
                    }
                    try
                    {
                        blood = comboBox1.SelectedItem.ToString();
                    }
                    catch
                    {
                        blood = "";
                        recheck = 2;
                    }

                    phone = pnumber.Text;
                    email = mail.Text;

                    bool mcheck;
                    try
                    {
                        var addr = new System.Net.Mail.MailAddress(email);
                        mcheck = (addr.Address == email);
                    }
                    catch
                    {
                        mcheck = false;
                    }


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

                    if (con.State == System.Data.ConnectionState.Open && recheck == 0 && mcheck)
                    {
                        string q = "update task set name = '" + name + "',age = '" + age + "',[Last Donation] = '" + date + "',Gender = '" + gender + "',[Blood Group] = '" + blood + "',[Phone Number] = '" + phone + "',email = '" + email + "' where id = " + k;
                        SqlCommand cmd = new SqlCommand(q, con);
                        //MessageBox.Show(q);
                        cmd.ExecuteNonQuery();
                        //MessageBox.Show("Connection made successfuly");
                        MessageBox.Show("Edited");
                    }
                    else
                    {
                        if (recheck == 1) MessageBox.Show("Check Gender");
                        else if (recheck == 2) MessageBox.Show("Check Blood Group");
                        else if (mcheck == false) MessageBox.Show("Check Email");
                    }
                    con.Close();
                }
        }
    }
}
