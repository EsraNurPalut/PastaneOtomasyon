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
                SqlCommand cmd = new SqlCommand("insert into Saticilar (SaticiAdSoyad,SaticiAdres,Saticiil,Saticiilçe) values (@SaticiAdSoyad,@SaticiAdres, @Saticiil, @Saticiilçe)", con);

                cmd.Parameters.AddWithValue("@SaticiAdSoyad", textBox2.Text);
                cmd.Parameters.AddWithValue("@SaticiAdres", textBox3.Text);
                cmd.Parameters.AddWithValue("@Saticiil", textBox4.Text);
                cmd.Parameters.AddWithValue("@Saticiilçe", textBox5.Text);
            
                cmd.ExecuteNonQuery();
                con.Close();
                Listele("select * from Saticilar ");

            }

        private void button4_Click(object sender, EventArgs e)  //listele
        {
            Listele("select * from Saticilar ");
        }

        private void button5_Click(object sender, EventArgs e)  //yenile 
        {
            con.Open();
            SqlCommand komut = new SqlCommand("Update Saticilar set SaticiAdSoyad='" + textBox2.Text.ToString() + "',SaticiAdres='" + textBox3.Text.ToString() + "',Saticiil='" + textBox4.Text.ToString() + "',Saticiilçe='" + textBox5.Text.ToString() + "'where SaticiNo='" + textBox1.Text +"'", con);
            komut.ExecuteNonQuery();
            Listele("select * from Saticilar ");
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e) //ara 
        {
            SqlCommand cmd = new SqlCommand("select * from Saticilar  where SaticiAdSoyad like '%" + textBox2.Text + "%'", con);
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }

        private void button7_Click(object sender, EventArgs e) //sil
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete  from Saticilar where SaticiNo=@SaticiNo", con);
            cmd.Parameters.AddWithValue("@SaticiNo", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele("select * from Saticilar ");

        }
    }
}
