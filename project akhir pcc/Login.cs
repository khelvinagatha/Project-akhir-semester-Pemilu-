using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace project_akhir_pcc
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        koneksi konn = new koneksi();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = konn.Getconn();



            SqlCommand cmd = new SqlCommand("SELECT * FROM Persons WHERE nama=@nama and passwords=@pasword and levels=@level", conn);
            cmd.Parameters.AddWithValue("@nama", txt_nama.Text);
            cmd.Parameters.AddWithValue("@pasword", txt_password.Text);
            cmd.Parameters.AddWithValue("@level", cb_level.Text);
            conn.Open();
            SqlDataReader log = cmd.ExecuteReader();

            if (log.HasRows)
            {
                while (log.Read())
                {
                    string level = log["levels"].ToString();
                    MessageBox.Show(level);
                    if (level == "admin")
                    {
                        MessageBox.Show("Selamat Datang Admin!!!");
                        beranda_admin userpage = new beranda_admin();
                        userpage.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Selamat Datang User!!!");
                        Home userpage = new Home();
                        userpage.Show();
                        this.Hide();
                    }

                }

                /*Form1 dash = new Form1();
                dash.Show();
                this.Hide();*/
            }
            else
            {
                MessageBox.Show("Login Failed!");
            }
        }
    }
}
