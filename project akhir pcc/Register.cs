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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        koneksi konn = new koneksi();

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tb_nama.Text == "" || tb_pw.Text == "" || tb_umur.Text == "" || tb_email.Text == "")
            {
                MessageBox.Show("register gagal");
            }
            else
            {
                
                SqlConnection conn = konn.Getconn();
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Persons (nama, passwords, umur, email, levels) VALUES (@nama, @passwords, @umur, @email, 'user')", conn);
                cmd.Parameters.AddWithValue("@nama", tb_nama.Text);
                cmd.Parameters.AddWithValue("@passwords", tb_pw.Text);
                cmd.Parameters.AddWithValue("@umur", tb_umur.Text);
                cmd.Parameters.AddWithValue("@email", tb_email.Text);
                

                int register = cmd.ExecuteNonQuery();
                if (register > 0)
                {
                    MessageBox.Show("register sukses");
                    Login dash = new Login();
                    dash.Show();
                }
                else
                {
                    MessageBox.Show("register gagal");
                }
            }
        }
    }
}
