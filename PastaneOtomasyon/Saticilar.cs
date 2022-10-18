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

namespace PastaneOtomasyon
{
    public partial class Saticilar : Form
    {
        public Saticilar()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Server=10.22.0.23; Database =M05; Integrated Security =true; ");

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 go = new Form1();
            go.Show();
            this.Hide();
        }

        public void Listele(string sorgu)
        {
            SqlDataAdapter dr = new SqlDataAdapter(sorgu, con);
            DataTable doldur = new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }

        private void Saticilar_Load(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e) //kaydet butonu
        {
          
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Ürünler (ÜrünAd,ÜrünFiyat,KullanimTarihi,ÜretimTarihi,SatıcıNo) values (@ÜrünAd, @ÜrünFiyat, @KullanimTarihi, @ÜretimTarihi,@SatıcıNo)", con);

                cmd.Parameters.AddWithValue("@SaticiAdSoyad", textBox2.Text);
                cmd.Parameters.AddWithValue("@SaticiAdres", textBox3.Text);
                cmd.Parameters.AddWithValue("@Saticiil", textBox4.Text);
                cmd.Parameters.AddWithValue("@Saticiilçe", textBox5.Text);
            
                cmd.ExecuteNonQuery();
                con.Close();
                Listele("select * from Saticilar ");

            }

        }
    }
}
