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
    public partial class Personelgiris : Form
    {
        public Personelgiris()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection
          ("Server=10.22.0.23; Database =M05; Integrated Security =true; ");

        private void button1_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Personelgiris  where PersonelAdSoyad=@PersonelAdSoyad and Sifre=@Sifre", con);
            cmd.Parameters.AddWithValue("@PersonelAdSoyad", textBox1.Text);
            cmd.Parameters.AddWithValue("@Sifre", textBox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("HOŞGELDİNİZ");
                Form1 go = new Form1();
                go.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("ÜZGÜNÜM..HATALI GİRİŞ..");
            }

        }
    }
}
