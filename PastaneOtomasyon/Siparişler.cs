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
    public partial class Siparişler : Form
    {
        public Siparişler()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection
           ("Server=10.22.0.23; Database =M05; Integrated Security =true; ");
        SqlConnection con1 = new SqlConnection
         ("Server=10.22.0.23; Database =M05; Integrated Security =true; ");

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 go = new Form1();
            go.Show();
            this.Hide();
        }
        private void button4_Click(object sender, EventArgs e)  //listele
        {
            Listele("select * from Siparisler ");
        }

        public void Listele(string sorgu)
        {
            SqlDataAdapter dr = new SqlDataAdapter(sorgu, con);
            DataTable doldur = new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }
        
        private void button3_Click(object sender, EventArgs e)  //ekle
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Siparisler(SiparisAd,SiparisAdres,SiparisAdet,SiparisFiyat,ÜrünNo,Tutar,MüsteriNo) values (@SiparisAd, @SiparisAdres, @SiparisAdet, @SiparisFiyat,@ÜrünNo,@Tutar,@MüsteriNo)", con);

            cmd.Parameters.AddWithValue("@SiparisAd", textBox2.Text);
            cmd.Parameters.AddWithValue("@SiparisAdres", textBox3.Text);
            cmd.Parameters.AddWithValue("@SiparisAdet", textBox4.Text);
            cmd.Parameters.AddWithValue("@SiparisFiyat", textBox5.Text);
            cmd.Parameters.AddWithValue("@ÜrünNo", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Tutar", textBox4.Text);
            cmd.Parameters.AddWithValue("@MüsteriNo", comboBox2.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele("select * from Siparisler");
        }

        private void Siparişler_Load(object sender, EventArgs e)
        { 
                con.Open();
                SqlCommand komut = new SqlCommand("select * from Ürünler", con);


                SqlDataReader dr;

                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["UrunNo"]);
                }



                con.Close();

            con1.Open();
            SqlCommand komut1 = new SqlCommand("select * from Müsteriler", con1);


            SqlDataReader dr1;

            dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox2.Items.Add(dr1["MüsteriNo"]);
            }



            con1.Close();


        }

        private void button6_Click(object sender, EventArgs e) //ara
        {
            SqlCommand cmd = new SqlCommand("select * from Siparisler  where SiparisAd like '%" + textBox2.Text + "%'", con);
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }

        private void button7_Click(object sender, EventArgs e)  //sil
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete  from Siparisler where SiparisNo=@SiparisNo", con);
            cmd.Parameters.AddWithValue("@SiparisNo", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele("select * from Siparisler ");

        }
    }
}
