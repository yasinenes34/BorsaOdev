using BorsaOdev.DatabaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorsaOdev.GirisEkrani
{
    public partial class Kayitol : Form
    {
        public Kayitol()
        {
            InitializeComponent();
        }



        Form1 form1 = new Form1();
        private void btngeri_Click_1(object sender, EventArgs e)
        {
            
            form1.Show();
            this.Hide();
        }
        BorsaOdevEntities db = new BorsaOdevEntities();
        private void btnkayitol_Click(object sender, EventArgs e)
        {
            kayitolkullanici();
            if (comboBox1.Text=="alici")
            {
                kayitetalici();
            }
            else if (comboBox1.Text=="satici")
            {
                kayitetsatici();
            }
          
        }
        void kayitolkullanici()
        {
            TblKullanici kullanici = new TblKullanici();
            kullanici.Ad = txtad.Text;
            kullanici.Soyad = txtsoyad.Text;
            kullanici.KullaniciAdi = txtkullaniciadi.Text;
            kullanici.Sifre = txtsifre.Text;
            kullanici.Tc = int.Parse(txttc.Text);
            kullanici.Telefon = int.Parse(txttelefon.Text);
            kullanici.Email = txtemail.Text;
            kullanici.Adres = txtadres.Text;
            kullanici.Rol = comboBox1.Text;
            db.TblKullanicis.Add(kullanici);
            db.SaveChanges();
            MessageBox.Show("Kayıt İşelmi Başarıyla Tamamlandı");
            form1.Show();
            this.Hide();
        }
        void kayitetalici()
        {
            TblAlici alici = new TblAlici();
            alici.Ad = txtad.Text;
            alici.Soyad = txtsoyad.Text;
            alici.kullaniciad = txtkullaniciadi.Text;
            alici.Tc = int.Parse(txttc.Text);
            alici.Telefon = int.Parse(txttelefon.Text);
            alici.Email = txtemail.Text;
            alici.Adres = txtadres.Text;
            db.TblAlicis.Add(alici);
            db.SaveChanges();
        }
        void kayitetsatici()
        {
            TblSatici satici = new TblSatici();
            satici.Ad = txtad.Text;
            satici.Soyad = txtsoyad.Text;
            satici.kullaniciad = txtkullaniciadi.Text;
            satici.Tc = int.Parse(txttc.Text);
            satici.Telefon = int.Parse(txttelefon.Text);
            satici.Email = txtemail.Text;
            satici.Adres = txtadres.Text;
            db.TblSaticis.Add(satici);
            db.SaveChanges();
        }
    }
}
