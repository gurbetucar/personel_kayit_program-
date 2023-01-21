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

namespace personel_kayit_programı
{
    public partial class frmistatistik : Form
    {
        public frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=GUCAR;Initial Catalog=personelVeritabani;Integrated Security=True");
        private void frmistatistik_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.MediumVioletRed;
            this.ForeColor = Color.White;
            //TOPLAM PERSONEL SAYISI 
            baglanti.Open();
            SqlCommand komut1= new SqlCommand("select count(*) from tbl_personel", baglanti);
            SqlDataReader dr1= komut1.ExecuteReader();
            while (dr1.Read())
            {
                lbltoplampersonel.Text = dr1[0].ToString();
            }
           
            baglanti.Close();

            //EVLİ PERSONEL SAYISI
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select count(*) from tbl_personel where PerDurum=1", baglanti);
            SqlDataReader dr2= komut2.ExecuteReader();
            while (dr2.Read()) {lblevlipersonel.Text = dr2[0].ToString(); }
            baglanti.Close();

            //BEKAR PERSONEL SAYISI
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select count(*) from tbl_personel where PerDurum=0", baglanti);
            SqlDataReader dr3= komut3.ExecuteReader();
            while (dr3.Read()) { lblbekarpersonel.Text = dr3[0].ToString(); } 
            baglanti.Close();

            //ŞEHİR SAYISI
           baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select count(distinct(persehir)) from tbl_personel", baglanti);
            SqlDataReader dr4= komut4.ExecuteReader();
            while (dr4.Read()) { lblsehirsayisi.Text = dr4[0].ToString(); }
            baglanti.Close();

            //TOPLAM MAAŞ

            baglanti.Open();
            SqlCommand komut5= new SqlCommand("select sum(permaas) from tbl_personel ",baglanti);
            SqlDataReader dr5= komut5.ExecuteReader();
            while (dr5.Read()) { lbltoplammaas.Text= dr5[0].ToString(); }
            baglanti.Close();

            //ORTALAMA MAAŞ
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select avg(permaas) from tbl_personel", baglanti);
            SqlDataReader dr6= komut6.ExecuteReader();
            while (dr6.Read()) { lblortalamamaas.Text= dr6[0].ToString(); }
            baglanti.Close();
        }
    }
}
