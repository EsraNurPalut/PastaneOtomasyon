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
    public partial class Müsteriler : Form
    {
        public Müsteriler()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 go = new Form1();
            go.Show();
            this.Hide();
        }

        SqlConnection con = new SqlConnection
           ("Server=10.22.0.23; Database =M05; Integrated Security =true; "); 


        public void Listele(string sorgu)
        {
            SqlDataAdapter dr = new SqlDataAdapter(sorgu, con);
            DataTable doldur = new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }


        private void button4_Click(object sender, EventArgs e)  //listele
        {
            Listele("select * from Müsteriler ");
        }

        private void button3_Click(object sender, EventArgs e) //kaydet
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Ürünler (MüsteriAdSoyad,MüsteriTelefon) values (@MüsteriAdSoyad @MüsteriTelefon)", con);

            cmd.Parameters.AddWithValue("@MüsteriAdSoyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@MüsteriTelefon", textBox3.Text);
            
            cmd.ExecuteNonQuery();
            con.Close();
            Listele("select * from Müsteriler ");
        }

        private void button5_Click(object sender, EventArgs e) //yenile
        {

            con.Open();
            SqlCommand komut = new SqlCommand("Update Müsteriler set MüsteriAdSoyad='" + textBox2.Text.ToString() + "',MüsteriTelefon='" + textBox3.Text.ToString() + "'where MüsteriNo='" + textBox1.Text + "'", con);
            komut.ExecuteNonQuery();
            Listele("select * from Müsteriler ");
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e) //ara 
        {
            SqlCommand cmd = new SqlCommand("select * from Müsteriler  where MüsteriAdSoyad like '%" + textBox2.Text + "%'", con);
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }

        private void button7_Click(object sender, EventArgs e)  //sil
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete  from Müsteriler where MüsteriNo=@MüsteriNo", con);
            cmd.Parameters.AddWithValue("@MüsteriNo", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele("select * from Müsteriler ");
        }
    }
}
