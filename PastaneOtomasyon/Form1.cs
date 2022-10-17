using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PastaneOtomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ürünler go = new Ürünler();
            go.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Siparişler go =new Siparişler();
            go.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Müsteriler go =new Müsteriler();
            go.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Saticilar go =new Saticilar();
            go.Show();
            this.Hide();
        }
    }
}
