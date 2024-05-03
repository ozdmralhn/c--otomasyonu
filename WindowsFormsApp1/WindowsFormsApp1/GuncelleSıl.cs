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
    public partial class GuncelleSıl : Form
    {
        public GuncelleSıl()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-VTC9958\SQLEXPRESS04;Initial Catalog=SporDb;Integrated Security=True");
        private void uyeler()
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
        

        private void GuncelleSıl_Load(object sender, EventArgs e)
        {
            uyeler();
        }
        int key = 0;


        private void YasTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdSoyadTb.Text = "";
            TelefonTb.Text = "";
            CinsiyetCb.Text = "";
            YasTb.Text = "";
            OdemeTb.Text = "";
            ZamanlamaCb.Text = "";
            BransCb.Text = "";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AnaSayfa anasayfa= new AnaSayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key==0)
            {
                MessageBox.Show("Silinecek Üyeyi Seçiniz");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "delete from UyeTbl where UId=" + key + ";";
                    SqlCommand komut = new SqlCommand(query,baglanti);   
                    komut.ExecuteNonQuery();

                    MessageBox.Show("Üye Başarıyl Silindi");

                    baglanti.Close();
                    uyeler();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                  
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0||AdSoyadTb.Text==""||TelefonTb.Text==""||CinsiyetCb.Text==""||YasTb.Text==""||OdemeTb.Text==""||ZamanlamaCb.Text==""||BransCb.Text=="")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "update UyeTbl set UAdSoyad='"+AdSoyadTb.Text+"',UTelefon='"+TelefonTb.Text+"',UCinsiyet='"+CinsiyetCb.Text+"',UYas='"+YasTb.Text+"',UOdeme='"+OdemeTb.Text+"',UZamanlama='"+ZamanlamaCb.Text+"',UBrans='"+BransCb.Text+"' where UId="+key+";";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();

                    MessageBox.Show("Üye Başarıyl Güncellendi");

                    baglanti.Close();
                    uyeler();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

 
        //çift tıkla textbox' ların içine bilgileri yazar
        private void UyeDGV_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = UyeDGV.CurrentRow;
            if (selectedRow != null)
            {
                key = Convert.ToInt32(selectedRow.Cells["UId"].Value.ToString());
                AdSoyadTb.Text = selectedRow.Cells["UAdSoyad"].Value.ToString();
                TelefonTb.Text = selectedRow.Cells["UTelefon"].Value.ToString();
                CinsiyetCb.Text = selectedRow.Cells["UCinsiyet"].Value.ToString();
                YasTb.Text = selectedRow.Cells["UYas"].Value.ToString();
                OdemeTb.Text = selectedRow.Cells["UOdeme"].Value.ToString();
                ZamanlamaCb.Text = selectedRow.Cells["UZamanlama"].Value.ToString();
                BransCb.Text = selectedRow.Cells["UBrans"].Value.ToString();
            }
        }

        private void UyeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
