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

namespace WindowsFormsApp1
{
    public partial class Odeme : Form
    {
        public Odeme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-VTC9958\SQLEXPRESS04;Initial Catalog=SporDb;Integrated Security=True");


        //üye ad soyadını seçer ve kutuya yazar
        private void FillName()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select UAdSoyad from UyeTbl", baglanti);
            SqlDataReader rdr;
            rdr=komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("UAdSoyad", typeof(string));
            dt.Load(rdr);
            AdSoyadCb.ValueMember = "UAdSoyad";
            AdSoyadCb.DataSource = dt;
            baglanti.Close();
        }
        
        
        //ödeme sayfasında arama yapan fonksiyon
        private void Adfiltrele()
        {
            /* baglanti.Open();
             string query = "select *from OdmTbl where OUye='"+AraTb.Text+"'";
             SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
             SqlCommandBuilder builder = new SqlCommandBuilder();
             var ds = new DataSet();
             sda.Fill(ds);
             OdemeDGV.DataSource = ds.Tables[0];
             baglanti.Close();*/
            baglanti.Open();
            string query = "SELECT * FROM OdmTbl WHERE OUye LIKE @OUye";

            using (SqlDataAdapter sda = new SqlDataAdapter(query, baglanti))
            {
                // Parametreyi oluştur
                sda.SelectCommand.Parameters.AddWithValue("@OUye", "%" + AraTb.Text + "%");

                using (var ds = new DataSet())
                {
                    // SqlDataAdapter'ın içindeki SqlCommandBuilder'ı kullanmak yerine direkt bir SqlCommandBuilder nesnesi oluştur
                    using (SqlCommandBuilder builder = new SqlCommandBuilder(sda))
                    {
                        sda.Fill(ds);
                        OdemeDGV.DataSource = ds.Tables[0];
                    }
                }
            }

            baglanti.Close();
        }
        private void uyeler()
        {
            baglanti.Open();
            string query = "select *from OdmTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            OdemeDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdSoyadCb.Text = "";
            OdemeTb.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnaSayfa anasayfa= new AnaSayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void Odeme_Load(object sender, EventArgs e)
        {
            FillName();
            uyeler();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (AdSoyadCb.Text==""||OdemeTb.Text=="")
            {
                MessageBox.Show("Eksik Bilgi Girdiniz");
            }
            else
            {
                string odemeperiyot=Periyot.Value.Month.ToString()+ " " +Periyot.Value.Year.ToString();
                baglanti.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from OdmTbl where OUye='"+AdSoyadCb.SelectedValue.ToString()+"' and OAy='"+odemeperiyot+"'",baglanti);
                DataTable dt = new DataTable(); 
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString()=="1")
                {
                    MessageBox.Show("Ödeme Önceden Yapılmış");
                }
                else
                {
                    string query = "insert into OdmTbl values('" + odemeperiyot + "','" + AdSoyadCb.SelectedValue.ToString() + "'," + OdemeTb.Text + ")";
                    SqlCommand komut = new SqlCommand(query,baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Tutar Başarıyla Ödendi");
                }
                baglanti.Close();
                uyeler();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Adfiltrele();
            AraTb.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            uyeler();
        }

        private void Periyot_ValueChanged(object sender, EventArgs e)
        {

        }

       
    }
}
