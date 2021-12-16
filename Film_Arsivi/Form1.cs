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

namespace Film_Arsivi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Data Source=DESKTOP-T6JACR2\SQLEXPRESS;Initial Catalog=FilmArsivi;Integrated Security=True

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-T6JACR2;Initial Catalog=FilmArsivi;Integrated Security=True");

        void filmler()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBLFILMLER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
         }
        private void Form1_Load(object sender, EventArgs e)
        {
            filmler();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLFILMLER (ad,KATEGORI,LINK) values (@P1,@P2,@P3)", baglanti);
            komut.Parameters.AddWithValue("@P1", TxtFilmAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtKategori.Text);
            komut.Parameters.AddWithValue("@P3", TxtLink.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Film Listenize Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            filmler();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            string link = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            webBrowser1.Navigate(link);
        }

        private void BtnHakkımızda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu Proje Ömer Alper Güneş tarafından 16 Aralık 2021 tarihinde kodlanmıştır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnRenkDegistir_Click(object sender, EventArgs e)
        {
            Color[] renkler = new Color[8] { Color.Red, Color.Blue, Color.Black, Color.Yellow, Color.Purple, Color.White, Color.Orange, Color.Pink };
            Random rnd = new Random();
            int eleman = rnd.Next(0, 7);
            this.BackColor = renkler[eleman];
        }
    }
}
