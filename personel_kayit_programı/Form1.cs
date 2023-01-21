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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=GUCAR;Initial Catalog=personelVeritabani;Integrated Security=True");

        
        void temizle() 
        {
            txtID.Text = "";
            TxtAD.Text = "";
            txtSoyad.Text = "";
            txtmeslek.Text = "";
            maas.Text = "";
            comboBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked=false;
            TxtAD.Focus();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("select distinct(persehir) from tbl_personel", baglanti);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            baglanti.Close();
        }
        

        private void btnlistele_Click(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personelVeritabaniDataSet.tbl_personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_personelTableAdapter.Fill(this.personelVeritabaniDataSet.tbl_personel);

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            // İNSERT İNTO (VERİ EKLEME )
            baglanti.Open(); // bağlantı açıldı
            //komut sınıfı türetilir
            SqlCommand komut = new SqlCommand("insert into tbl_personel (Perad, PerSoyad,persehir, permaas,permeslek, perdurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            //komutun parametrelerini textboxtan alacak 
            komut.Parameters.AddWithValue("@p1", TxtAD.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", comboBox1.Text);
            komut.Parameters.AddWithValue("@p4", maas.Text);
            komut.Parameters.AddWithValue("@p5", txtmeslek.Text);
            komut.Parameters.AddWithValue("@p6", label1.Text);
            komut.ExecuteNonQuery();//sorguyu çalıştır (insert, update, delete de kullanılır yani tablo sonucunda değişiklikte                    
            MessageBox.Show("personel eklendi");
            baglanti.Close(); // bağlantı kapandı
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
                label1.Text = "true";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
          
                label1.Text = " false";
            
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) //herhangi bir hücreye iki defa basılınca ne olsun celldoubleclick
        {
            int secılen= dataGridView1.SelectedCells[0].RowIndex; // herhangi bir hücreye çift tıklanan değeri seçilene atandı
            txtID.Text = dataGridView1.Rows[secılen].Cells[0].Value.ToString(); // rows (satırlar) cells(hücre) value (değer)
            TxtAD.Text = dataGridView1.Rows[secılen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secılen].Cells[2].Value.ToString();
            txtmeslek.Text = dataGridView1.Rows[secılen].Cells[6].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secılen].Cells[3].Value.ToString();
            string durum = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            if (durum=="True")
            {
                radioButton1.Checked = true;
            }
            else if (durum=="False")
            {
                radioButton2.Checked = true;
            }
            maas.Text = dataGridView1.Rows[secılen].Cells[4].Value.ToString();

         
          
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            //DELETE (VERİ SİLME)
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("delete from tbl_personel where perid=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", txtID.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("personel silindi");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            //UPDATE (VERİ GÜNCELLEME)
            baglanti.Open();   
            SqlCommand guncelle = new SqlCommand("Update tbl_personel set perad=@a1,persoyad=@a2, persehir=@a3, permaas=@a4, permeslek= @a5, perdurum=@a6 where perid=@a7", baglanti);
            guncelle.Parameters.AddWithValue("@a1", TxtAD.Text);
            guncelle.Parameters.AddWithValue("@a2", txtSoyad.Text);
            guncelle.Parameters.AddWithValue("@a3", comboBox1.Text);
            guncelle.Parameters.AddWithValue("@a4", maas.Text);
            guncelle.Parameters.AddWithValue("@a5", txtmeslek.Text);
            guncelle.Parameters.AddWithValue("@a6", label1.Text);
            guncelle.Parameters.AddWithValue("@a7", txtID.Text);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("güncellendi");
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            //TOPLAM PERSONEL SAYISI 

            frmistatistik fr = new frmistatistik();  
            fr.Show();
            
        }

        private void btngrafik_Click(object sender, EventArgs e)
        {
            frmgrafik frmgrafik= new frmgrafik();
            frmgrafik.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }
    }
}
