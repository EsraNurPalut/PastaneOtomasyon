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
    public partial class Ürünler : Form
    {
        public Ürünler()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection
            ("Server=10.22.0.23; Database =M05; Integrated Security =true; ");

        public void Listele (string sorgu)
        {
            SqlDataAdapter dr=new SqlDataAdapter(sorgu,con);
            DataTable doldur =new DataTable();  
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 go = new Form1();
            go.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)   //kaydet butonu
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Ürünler (ÜrünAd,ÜrünFiyat,KullanimTarihi,ÜretimTarihi,SatıcıNo) values (@ÜrünAd, @ÜrünFiyat, @KullanimTarihi, @ÜretimTarihi,@SatıcıNo)", con);

            cmd.Parameters.AddWithValue("@ÜrünAd", comboBox2.Text);
            cmd.Parameters.AddWithValue("@ÜrünFiyat", textBox3.Text); 
            cmd.Parameters.AddWithValue("@KullanimTarihi", textBox4.Text);
            cmd.Parameters.AddWithValue("@ÜretimTarihi", textBox5.Text);
            cmd.Parameters.AddWithValue("@SatıcıNo", comboBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele("select * from Ürünler ");



        }

        private void button4_Click(object sender, EventArgs e)  //listele butonu
        {
            Listele("select * from Ürünler ");
        }

        private void button5_Click(object sender, EventArgs e)  //yenile butonu 
        {
            con.Open();
            SqlCommand komut = new SqlCommand("Update Ürünler set ÜrünAd='" + comboBox2.Text.ToString() + "',ÜrünFiyat='" + textBox3.Text.ToString() + "',KullanimTarihi='"+textBox4.Text.ToString() + "',ÜretimTarihi='" + textBox5.Text.ToString() + "',SaticiNo='" + comboBox1.Text.ToString() + "'where UrunNo='" + textBox1.Text+"'",con);
            komut.ExecuteNonQuery();      
            Listele("select * from Ürünler ");
            con.Close();

        }

        private void button6_Click(object sender, EventArgs e)  //Ara butonu
        {
            SqlCommand cmd = new SqlCommand("select * from Ürünler  where ÜrünAd like '%" + comboBox2.Text + "%'", con);
            con.Close();
            SqlDataAdapter da =new SqlDataAdapter(cmd);    
            DataTable doldur =new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }

        private void button7_Click(object sender, EventArgs e)  //sil butonu
        {
            //int a = Convert.ToInt32(textBox1.Tag);
            //MessageBox.Show(a.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("delete  from Ürünler where UrunNo=@UrunNo", con);
            cmd.Parameters.AddWithValue("@UrunNo", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele("select * from Ürünler ");


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Ürünler_Load(object sender, EventArgs e)   // satıcı no ürünler tablosunda gözükmesi için.
        {
            con.Open();
            SqlCommand komut = new SqlCommand("select * from Saticilar",con );
        

            SqlDataReader dr;

            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["SaticiNo"]);
            }
            con.Close();
        }

        
    }
}
