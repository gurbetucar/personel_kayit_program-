using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace personel_kayit_programı
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=GUCAR;Initial Catalog=personelVeritabani;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select*from tbl_giris where kullanıcıAdi=@p1 and sifre= @p2", baglanti);
            komut1.Parameters.AddWithValue("@p1", txtkullanci.Text);
            komut1.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = komut1.ExecuteReader();
            if (dr.Read())
            {
                Form1 fr = new Form1();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("hatalı kullanıcı adı veya şifre");
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm=new Form3();  
            frm.Show();
            this.Hide();
        }
    }
}
