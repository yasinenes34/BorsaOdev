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
using BorsaOdev.DatabaseModel;
using BorsaOdev.GirisEkrani;
using BorsaOdev.admin;
using BorsaOdev.Satıcı;
using BorsaOdev.Alıcı;

namespace BorsaOdev
{
    
    public partial class Form1 : Form
    {
        BorsaOdevEntities db = new BorsaOdevEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        public static string kullaniciadi;
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            
            kullaniciadi = txtKullaniciadi.Text;
            string sifre = txtSifre.Text;
            var admin = from d1 in db.TblKullanicis where d1.KullaniciAdi == kullaniciadi && d1.Sifre == sifre && d1.Rol=="admin"  select new {d1.KullaniciID,d1.KullaniciAdi,d1.Sifre,d1.Rol};
            var alici = from d1 in db.TblKullanicis where d1.KullaniciAdi == kullaniciadi && d1.Sifre == sifre && d1.Rol == "alici" select new { d1.KullaniciID, d1.KullaniciAdi, d1.Sifre, d1.Rol };
            var satici = from d1 in db.TblKullanicis where d1.KullaniciAdi == kullaniciadi && d1.Sifre == sifre && d1.Rol == "satici" select new { d1.KullaniciID, d1.KullaniciAdi, d1.Sifre, d1.Rol };
            if (admin.Any())
            {
                MessageBox.Show("Admin Olarak Giriş Yaptınız ");
                Admin admin1 = new Admin();
                admin1.Show();
                this.Hide();

            }
            else if (alici.Any())
            {
                MessageBox.Show("Alıcı Olarak Giriş Yaptınız");
                Alici alici1 = new Alici();
                alici1.Show();
                this.Hide();
            }
            else if (satici.Any())
            {
                Satici satıcı = new Satici();
                MessageBox.Show("Satıcı Olarak Giriş Yaptınız");
                satıcı.Show();
                this.Hide();
            }

        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            Kayitol kayitol = new Kayitol();
            kayitol.Show();
            this.Hide();
        }

       
    }
}
