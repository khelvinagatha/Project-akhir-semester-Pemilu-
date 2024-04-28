using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace project_akhir_pcc
{
    public partial class Home : Form
    {
        koneksi konn = new koneksi();
        public Home()
        {
            InitializeComponent();
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Gagal Menambahkan");
            }
            else
            {
                SqlConnection conn = konn.Getconn();
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO suara (id_suara) VALUES (@suara)", conn);
                cmd.Parameters.AddWithValue("@suara", comboBox1.Text);
                int home = cmd.ExecuteNonQuery();
                if (home > 0)
                {
                    MessageBox.Show("Pemilihan berhasil");

                }
                else
                {
                    MessageBox.Show("Pemilihan Gagal");
                }
            }
        }
    }
}
