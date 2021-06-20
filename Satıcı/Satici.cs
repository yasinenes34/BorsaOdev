using BorsaOdev.DatabaseModel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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
            alimkontrolet();
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
        public int para1;
        void alimkontrolet()
        {
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
            bool bitir = false;
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
                            int aliciid = int.Parse(i.Aliciid.ToString());
                            int saticiid = int.Parse(item.SaticiID.ToString());
                            var silalim = db.TblAlimİstek.Find(idalim);
                            var silurun = db.TblUruns.Find(idurun);
                            var aliciparaguncelle = db.TblAlicis.Where(p => p.AliciID == aliciid).First<TblAlici>();
                            var saticiparaguncelle = db.TblSaticis.Where(p => p.SaticiID == saticiid).First<TblSatici>();
                            var kasaguncelle = db.TblKasas.Where(p => p.KasaID == 1).First<TblKasa>();
                            var urunmiktarguncelle = db.TblUruns.Where(p => p.UrunID == idurun).First<TblUrun>();
                            kasaguncelle.KasaPara += (uruntoplamfiyat * 1) / 100;
                            if (saticiparaguncelle.SaticiPara == null)
                            {
                                saticiparaguncelle.SaticiPara = 0;
                            }
                            if (item.UrunMiktar == i.UrunMiktar)
                            {
                                db.TblUruns.Remove(silurun);
                            }
                            else
                            {
                                urunmiktarguncelle.UrunMiktar = item.UrunMiktar - i.UrunMiktar;
                            }
                            TblAlinanUrunler alinanUrunler = new TblAlinanUrunler();
                            alinanUrunler.AliciID = i.Aliciid;
                            alinanUrunler.AlimBaslangic = i.AlimBaslangic;
                            alinanUrunler.AlimBitis = i.AlimBitis;
                            alinanUrunler.UrunAdi = i.UrunAdi;
                            alinanUrunler.UrunMiktar = i.UrunMiktar;
                            alinanUrunler.UrunFiyat = i.UrunFiyat;
                            db.TblAlinanUrunlers.Add(alinanUrunler);
                            TblSatilanUrun satilanUrun = new TblSatilanUrun();
                            satilanUrun.SaticiID = item.SaticiID;
                            satilanUrun.UrunAdi = item.UrunAdi;
                            satilanUrun.UrunFiyat = item.UrunFiyat;
                            satilanUrun.UrunMiktar = i.UrunMiktar;
                            satilanUrun.UrunSatisBaslangic = item.UrunSatisBaslangic;
                            satilanUrun.UrunSatisBitis = item.UrunSatisBitis;
                            db.TblSatilanUruns.Add(satilanUrun);
                            saticiparaguncelle.SaticiPara += uruntoplamfiyat;
                            aliciparaguncelle.AliciPara -= uruntoplamfiyat + (uruntoplamfiyat / 100);
                            db.TblAlimİstek.Remove(silalim);
                            db.SaveChanges();
                            MessageBox.Show("Satış Gerçekleşti");
                            bitir = true;
                        }
                        break;
                    }


                }

            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            RaporOlustur();
        }
        void RaporOlustur()
        {
            int Satir = 1;
            int Sutun = 1;
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.Commercial;
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            ExcelPackage package = new ExcelPackage();
            package.Workbook.Worksheets.Add("Sayfa1");
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
            worksheet.Cells[Satir, Sutun].Value = "ÜrünAdı";
            worksheet.Cells[Satir, Sutun + 1].Value = "ÜrünMiktar";
            worksheet.Cells[Satir, Sutun + 2].Value = "ÜrünFiyat";
            worksheet.Cells[Satir, Sutun + 3].Value = "Ürün Satım Başlangıç Tarihi";
            worksheet.Cells[Satir, Sutun + 4].Value = "Ürün Satım Bitiş Tarihi";
            var satilanUrunler = db.TblSatilanUruns.Where(p => p.TblSatici.kullaniciad == Form1.kullaniciadi).ToList();
            foreach (var item in satilanUrunler)
            {
                worksheet.Cells[Satir + 1, Sutun].Value = item.UrunAdi;
                worksheet.Cells[Satir + 1, Sutun + 1].Value = item.UrunMiktar;
                worksheet.Cells[Satir + 1, Sutun + 2].Value = item.UrunFiyat;
                worksheet.Cells[Satir + 1, Sutun + 3].Value = item.UrunSatisBaslangic;
                worksheet.Cells[Satir + 1, Sutun + 4].Value = item.UrunSatisBitis;
                Satir++;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Dosyası|*.xlsx";
            saveFileDialog.ShowDialog();
            Stream stream = saveFileDialog.OpenFile();
            package.SaveAs(stream);
            stream.Close();
            MessageBox.Show("Rapor Oluşturuldu");
        }
    }
}
