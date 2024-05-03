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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace WindowsFormsApp1
{
    public partial class Personel : Form
    {
        public Personel()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-VTC9958\SQLEXPRESS04;Initial Catalog=SporDb;Integrated Security=True");
        private void uyeler()
        {
            baglanti.Open();
            string query = "select *from PersonelTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            PersonelDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
        int key = 0;
        private void UyeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = PersonelDGV.CurrentRow;
            if (selectedRow != null)
            {
                key = Convert.ToInt32(selectedRow.Cells["PId"].Value.ToString());
                PersonelAdSoyadTb.Text = selectedRow.Cells["PAdSoyad"].Value.ToString();
                PersonelTelefonTb.Text = selectedRow.Cells["PTelefon"].Value.ToString();
                PersonelCinsiyetCb.Text = selectedRow.Cells["PCinsiyet"].Value.ToString();
                PersonelYasTb.Text = selectedRow.Cells["PYas"].Value.ToString();
               
                PersonelZamanlamaCb.Text = selectedRow.Cells["PZamanlama"].Value.ToString();
                PersonelBransCb.Text = selectedRow.Cells["PBrans"].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AnaSayfa anasayfa=new AnaSayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonelAdSoyadTb.Text = "";
            PersonelBransCb.Text = "";
            PersonelCinsiyetCb.Text = "";
            PersonelYasTb.Text = "";
            PersonelZamanlamaCb.Text = "";
            PersonelTelefonTb.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Silinecek Üyeyi Seçiniz");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "delete from PersonelTbl where PId=" + key + ";";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();

                    MessageBox.Show("Personel Başarıyla Silindi");

                    baglanti.Close();
                    uyeler();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0 || PersonelAdSoyadTb.Text == "" || PersonelTelefonTb.Text == "" || PersonelCinsiyetCb.Text == "" || PersonelYasTb.Text == ""  || PersonelZamanlamaCb.Text == "" || PersonelBransCb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "update PersonelTbl set PAdSoyad='" + PersonelAdSoyadTb.Text + "',PTelefon='" + PersonelTelefonTb.Text + "',PCinsiyet='" + PersonelCinsiyetCb.Text + "',PYas='" + PersonelYasTb.Text + "',PZamanlama='" + PersonelZamanlamaCb.Text + "',PBrans='" + PersonelBransCb.Text + "' where PId=" + key + ";";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();

                    MessageBox.Show("Personel Başarıyla Güncellendi");

                    baglanti.Close();
                    uyeler();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }
        private void personel()
        {
            baglanti.Open();
            string query = "select *from PersonelTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            PersonelDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (PersonelAdSoyadTb.Text == "" || PersonelTelefonTb.Text == ""  || PersonelYasTb.Text == "")
            {
                MessageBox.Show("eksik bilgi");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "insert into PersonelTbl values('" + PersonelAdSoyadTb.Text + "','" + PersonelTelefonTb.Text + "','" + PersonelBransCb.SelectedItem.ToString() + "','" + PersonelCinsiyetCb.SelectedItem.ToString() + "','" + PersonelZamanlamaCb.SelectedItem.ToString() + "','" + PersonelYasTb.Text + "')";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("personel başarıyla eklendi");
                    baglanti.Close();
                    PersonelAdSoyadTb.Text = "";
                    PersonelTelefonTb.Text = "";  
                    PersonelYasTb.Text = "";
                    PersonelCinsiyetCb.Text = "";
                    PersonelZamanlamaCb.Text = "";
                    PersonelBransCb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Ex.Message");
                    throw;
                }
                
            }
            personel();
        }

        private void Personel_Load(object sender, EventArgs e)
        {
            personel();
        }
    }
}
