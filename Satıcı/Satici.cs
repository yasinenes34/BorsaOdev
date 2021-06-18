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

namespace BorsaOdev.Satıcı
{
    public partial class Satici : Form
    {
        public Satici()
        {
            InitializeComponent();
        }
       
        private void Satici_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = db.TblSaticis.Where(x => x.kullaniciad == Form1.kullaniciadi).ToList();
            
        }
        BorsaOdevEntities db = new BorsaOdevEntities();
        private void btnurunekle_Click(object sender, EventArgs e)
        {
            urunekle();
        }
        void urunekle()
        {
            TblUrunOnay urunOnay = new TblUrunOnay();
            urunOnay.SaticiID =int.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString());
            urunOnay.UrunAdi = txturunad.Text;
            urunOnay.UrunFiyat =int.Parse( txtfiyat.Text);
            urunOnay.UrunMiktar = int.Parse(txturunmiktar.Text);
            urunOnay.UrunSatisBaslangic = baslangic.Value;
            urunOnay.UrunSatisBitis = bitis.Value;
            db.TblUrunOnays.Add(urunOnay);
            db.SaveChanges();
            MessageBox.Show("Ürünler eklendi Admin Onayı Bekleniyor ");
        }
    }
}
