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

namespace WindowsFormsApp1
{
    public partial class UyeleriGoruntule : Form
    {
        public UyeleriGoruntule()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-VTC9958\SQLEXPRESS04;Initial Catalog=SporDb;Integrated Security=True");
        private void uyeler()
        {
            baglanti.Open();
            string query = "select *from UyeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query,baglanti);
            SqlCommandBuilder builder= new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            UyeDGV.DataSource= ds.Tables[0];
            baglanti.Close();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void UyeleriGoruntule_Load(object sender, EventArgs e)
        {
            uyeler();   
        }

        private void UyeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            baglanti.Open();
            string query = "select *from UyeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            UyeDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnaSayfa anasayfa= new AnaSayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void Adfiltrele()
        {
            /* baglanti.Open();
             string query = "select *from UyeTbl where UAdSoyad='" + AraUyeTb.Text + "'";
             SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
             SqlCommandBuilder builder = new SqlCommandBuilder();
             var ds = new DataSet();
             sda.Fill(ds);
             UyeDGV.DataSource = ds.Tables[0];
             baglanti.Close();*/
            baglanti.Open();
            string query = "SELECT * FROM UyeTbl WHERE UAdSoyad LIKE @AdSoyad";

            using (SqlDataAdapter sda = new SqlDataAdapter(query, baglanti))
            {
                // Parametreyi oluştur
                sda.SelectCommand.Parameters.AddWithValue("@AdSoyad", "%" + AraUyeTb.Text + "%");

                using (var ds = new DataSet())
                {
                    // SqlDataAdapter'ın içindeki SqlCommandBuilder'ı kullanmak yerine direkt bir SqlCommandBuilder nesnesi oluştur
                    using (SqlCommandBuilder builder = new SqlCommandBuilder(sda))
                    {
                        sda.Fill(ds);
                        UyeDGV.DataSource = ds.Tables[0];
                    }
                }
            }

            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Adfiltrele();
            AraUyeTb.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uyeler();
        }
    }
}
