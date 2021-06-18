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

namespace BorsaOdev.Alıcı
{
    public partial class Alici : Form
    {
        public Alici()
        {
            InitializeComponent();
        }
        BorsaOdevEntities db = new BorsaOdevEntities();
        private void Alici_Load(object sender, EventArgs e)
        {
           
        }

        private void btnparaekle_Click(object sender, EventArgs e)
        {
            paraekle();
        }
        int para;

        void paraekle()
        {
            TblParaOnay alicionay = new TblParaOnay();
            var alici= db.TblAlicis.Where(x => x.kullaniciad == Form1.kullaniciadi).FirstOrDefault();
           para=int.Parse(txtalicipara.Text);
            alicionay.aliciID=alici.AliciID;
            alicionay.AliciPara = para;
            db.TblParaOnays.Add(alicionay);
            db.SaveChanges();
            MessageBox.Show("Para Eklendi Admin Onayı Bekleniyor");
        }
        private void btnalim_Click(object sender, EventArgs e)
        {
            alimistek();
            alimkontrolet();
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }
        TblAlimİstek alimIstek = new TblAlimİstek();
        void alimistek()
        {
            var alici = db.TblAlicis.Where(x => x.kullaniciad == Form1.kullaniciadi).FirstOrDefault();
            alimIstek.Aliciid = alici.AliciID;
            alimIstek.UrunAdi = txturunadi.Text;
            alimIstek.UrunFiyat = int.Parse(txturunfiyat.Text);
            alimIstek.UrunMiktar = int.Parse(txturunmiktar.Text);
            alimIstek.AlimBaslangic = baslangic.Value;
            alimIstek.AlimBitis = bitis.Value;
            db.TblAlimİstek.Add(alimIstek);
            db.SaveChanges();
            MessageBox.Show("Alım İsteği Gerçekleşti... ");

        }
        public int para1;
        void  alimkontrolet()
        {
            //TblUrun urun = new TblUrun();
            var urun = db.TblUruns.ToList();
            var alimistek = db.TblAlimİstek.ToList();
            var alicipara = db.TblAlicis.ToList();
            foreach (var item in alicipara)
            {
                if (item.AliciPara>0)
                {
                     para1 = int.Parse(item.AliciPara.ToString());
                }
            }
            MessageBox.Show(para1.ToString());
            foreach (var item in urun)
            {
                foreach (var i in alimistek)
                {
                    if (item.UrunAdi == i.UrunAdi && item.UrunFiyat == i.UrunFiyat && item.UrunMiktar == i.UrunMiktar && item.UrunSatisBitis >= i.AlimBitis)
                     {
                        
                        int uruntoplamfiyat =int.Parse(item.UrunMiktar.ToString())*int.Parse(item.UrunFiyat.ToString());
                        MessageBox.Show(para1.ToString());
                        if (para1>uruntoplamfiyat)
                        {
                            MessageBox.Show("Satış Gerçekleşti");
                            
                        }
                        break;
                    }
                    
                }
               
            }
           


        }

    }
}
