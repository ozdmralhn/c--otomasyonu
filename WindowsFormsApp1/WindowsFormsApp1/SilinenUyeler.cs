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
    public partial class SilinenUyeler : Form
    {
        public SilinenUyeler()
        {
            InitializeComponent();
        }
        private void uyeler()
        {
            baglanti.Open();
            string query = "select *from SilinenTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            SilinenUyeDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-VTC9958\SQLEXPRESS04;Initial Catalog=SporDb;Integrated Security=True");
        private void UyeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            baglanti.Open();
            string query = "select *from SilinenTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            SilinenUyeDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnaSayfa anasayfa = new AnaSayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void SilinenUyeler_Load(object sender, EventArgs e)
        {
            uyeler();
        }
    }
}
