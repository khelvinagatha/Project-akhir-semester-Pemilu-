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
using System.IO;

namespace project_akhir_pcc
{
    public partial class admin_crud : Form
    {
        koneksi konn = new koneksi();
        public admin_crud()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_namapaslon.Text == "" || txt_namapartai.Text == "" || txt_visimisi.Text == "")
            {
                MessageBox.Show("Gagal Menambahkan");
            }
            else
            {
                byte[] images = null;
                FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                images = brs.ReadBytes((int)stream.Length);
                SqlConnection conn = konn.Getconn();
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Kandidat (Nama_kandidat, partai_politik, visi_misi, gambar) VALUES (@namakandidat, @partai, @visimisi, @gambar)", conn);
                cmd.Parameters.AddWithValue("@namakandidat", txt_namapaslon.Text);
                cmd.Parameters.AddWithValue("@partai", txt_namapartai.Text);
                cmd.Parameters.AddWithValue("@visimisi", txt_visimisi.Text);
                cmd.Parameters.AddWithValue("@gambar",images );

                int admincrud = cmd.ExecuteNonQuery();
                if (admincrud > 0)
                {
                    MessageBox.Show("Penambahan berhasil");

                }
                else
                {
                    MessageBox.Show("Penambahan Gagal");
                }
            }
        }
        string imgLocation = "";
        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                imgLocation = openFileDialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void label6_Click(object sender, EventArgs e)
        {
             
        }

        private void  ViewImage(string name)
        {
            SqlConnection conn = konn.Getconn();
            SqlCommand cmd = new SqlCommand($"select gambar from Kandidat where gambar = @gambar", conn);
            cmd.Parameters.AddWithValue("@gambar", name);

            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    byte[] img = (byte[])(reader["gambar"]);
                    if(img == null)
                    {
                        pictureBox1.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                reader.Close();
                conn.Close();
            }
        }

        private void admin_crud_Load(object sender, EventArgs e)
        {
            SqlConnection conn = konn.Getconn();
            SqlCommand cmd = new SqlCommand("SELECT Kandidat.id_kandidat, Kandidat.Nama_kandidat, Kandidat.partai_politik, Kandidat.visi_misi, Kandidat.gambar FROM Kandidat", conn);

            DataTable dt = new DataTable();
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = konn.Getconn();
            SqlCommand cmd = new SqlCommand("SELECT Kandidat.id_kandidat, Kandidat.Nama_kandidat, Kandidat.partai_politik, Kandidat.visi_misi, Kandidat.gambar FROM Kandidat)", conn);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }
    }
}
