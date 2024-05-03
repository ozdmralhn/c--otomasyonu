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
    public partial class Maas : Form
    {
        public Maas()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-VTC9958\SQLEXPRESS04;Initial Catalog=SporDb;Integrated Security=True");
        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void uyeler()
        {
            baglanti.Open();
            string query = "select *from MaasTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            MaasDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AnaSayfa anasayfa = new AnaSayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void Maas_Load(object sender, EventArgs e)
        {
            uyeler();
        }
        int key = 0;


       
        private void button2_Click(object sender, EventArgs e)
        {
            if (key == 0 || PersonelAdSoyadTb.Text == "" || PersonelMaasTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "update MaasTbl set PMaas='" + PersonelMaasTb.Text + "' where PId=" + key + ";";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();

                    MessageBox.Show("Personel Maaşı Başarıyla Güncellendi");

                    baglanti.Close();
                    uyeler();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void MaasDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = MaasDGV.CurrentRow;
            if (selectedRow != null)
            {
                key = Convert.ToInt32(selectedRow.Cells["PId"].Value.ToString());
                PersonelAdSoyadTb.Text = selectedRow.Cells["PAdSoyad"].Value.ToString();
                PersonelMaasTb.Text = selectedRow.Cells["PMaas"].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Silinecek Maaş Bilgisini Seçiniz");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "delete from MaasTbl where PId=" + key + ";";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();

                    MessageBox.Show("Personel Maaş bilgisi Başarıyla Silindi");

                    baglanti.Close();
                    uyeler();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }
    }
}
