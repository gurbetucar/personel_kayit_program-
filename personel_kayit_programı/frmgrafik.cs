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
    public partial class frmgrafik : Form
    {
        public frmgrafik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=GUCAR;Initial Catalog=personelVeritabani;Integrated Security=True");
       

        private void frmgrafik_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select persehir, count(*) from tbl_personel group by persehir", baglanti);
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr[0], dr[1]);

            }
            baglanti.Close();

            //ortalama maas meslek
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select permeslek, avg(permaas) from tbl_personel group by permeslek", baglanti);
            SqlDataReader dr2= komut2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["meslek-maas"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();
        }
    }
}
