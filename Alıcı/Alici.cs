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
                if (item.AliciPara > 0)
                {
                    para1 = int.Parse(item.AliciPara.ToString());
                }
            }
            bool bitir=false;
            foreach (var item in urun)
            {
                if (bitir)
                {
                    break;
                }
                foreach (var i in alimistek)
                {
                    if (item.UrunAdi == i.UrunAdi && item.UrunFiyat == i.UrunFiyat && item.UrunMiktar >= i.UrunMiktar && item.UrunSatisBitis >= i.AlimBitis)
                    {
                        int uruntoplamfiyat = int.Parse(item.UrunMiktar.ToString()) * int.Parse(item.UrunFiyat.ToString());
                        if (para1 > uruntoplamfiyat + (uruntoplamfiyat / 100))
                        {
                            int idalim = i.AlimID;
                            int idurun = item.UrunID;
                            int aliciid =int.Parse( i.Aliciid.ToString());
                            int saticiid = int.Parse(item.SaticiID.ToString());
                            var silalim = db.TblAlimİstek.Find(idalim);
                            var silurun = db.TblUruns.Find(idurun);
                            var aliciparaguncelle = db.TblAlicis.Where(p => p.AliciID ==aliciid).First<TblAlici>();
                            var saticiparaguncelle = db.TblSaticis.Where(p => p.SaticiID == saticiid).First<TblSatici>();
                            var kasaguncelle = db.TblKasas.Where(p => p.KasaID == 1).First<TblKasa>();
                            kasaguncelle.KasaPara += (uruntoplamfiyat * 1) / 100;
                            saticiparaguncelle.SaticiPara += uruntoplamfiyat;
                            aliciparaguncelle.AliciPara -= uruntoplamfiyat+(uruntoplamfiyat/100);
                            db.TblAlimİstek.Remove(silalim);
                            db.TblUruns.Remove(silurun);
                            db.SaveChanges();
                            MessageBox.Show("Satış Gerçekleşti");
                            bitir = true;
                           
                        }
                        
                        break;
                    }
                   

                }
               
            }



        }

        private void dataGridView2_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }
    }
}
