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
    public partial class Rapor : Form
    {
        public Rapor()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection
         ("Server=10.22.0.23; Database =M05; Integrated Security =true; ");

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Ürünler order by ÜrünAd desc " , con); ;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
            con.Close();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Müsteriler order by MüsteriAdSoyad desc ", con); ;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Siparisler order by SiparisAd desc ", con); ;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Saticilar order by SaticiAdSoyad desc ", con); ;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select ÜrünAd,ÜrünFiyat,SaticiAdSoyad,Saticiil from Ürünler ü inner join Saticilar s on ü.SaticiNo=s.SaticiNo ", con); ;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select top 2 SiparisAd,SiparisAdet,count(1) AS Toplam FROM Siparisler Group by SiparisAd, SiparisAdet ORDER BY Toplam desc", con); 
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select  SiparisAd,SiparisAdet,count(1) AS Toplam FROM Siparisler Group by SiparisAd, SiparisAdet ORDER BY Toplam asc ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
            con.Close();
        }
    }
}
