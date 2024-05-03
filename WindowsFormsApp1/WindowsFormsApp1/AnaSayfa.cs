﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UyeEkle uyeekle = new UyeEkle();
            uyeekle.Show(); 
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GuncelleSıl guncelle = new GuncelleSıl();   
            guncelle.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Odeme odeme = new Odeme();
            odeme.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UyeleriGoruntule uyelerigoruntule = new UyeleriGoruntule();
            uyelerigoruntule.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SilinenUyeler silinenuyeler = new SilinenUyeler();
            silinenuyeler.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Personel personel = new Personel(); 
            personel.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Maas maas = new Maas(); 
            maas.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
