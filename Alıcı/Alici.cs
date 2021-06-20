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

namespace BorsaOdev.Alıcı
{
    public partial class Alici : Form
    {
        public Alici()
        {
            InitializeComponent();
        }
        public string USD, EUR, GBP;
        BorsaOdevEntities db = new BorsaOdevEntities();
        private void Alici_Load(object sender, EventArgs e)
        {
            string dovizlink = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var XmlDosya = new XmlDocument();
            XmlDosya.Load(dovizlink);
             USD = XmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
             EUR = XmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
             GBP = XmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
            comboBox1.Items.Add("Dolar");
            comboBox1.Items.Add("Euro");
            comboBox1.Items.Add("İNGİLİZ STERLİNİ");
            comboBox1.Items.Add("TL");
            
           MessageBox.Show(USD.ToString());

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
            if (comboBox1.Text=="Dolar")
            {
                para = int.Parse(txtalicipara.Text);
                float sonpara = float.Parse( USD.ToString());
                alicionay.aliciID = alici.AliciID;
                alicionay.AliciPara = para *int.Parse(sonpara.ToString());
                db.TblParaOnays.Add(alicionay);
                db.SaveChanges();
                MessageBox.Show("Para Eklendi Admin Onayı Bekleniyor");
            }
            else if (comboBox1.Text=="Euro")
            {
                para = int.Parse(txtalicipara.Text);
                float sonpara = float.Parse(USD.ToString());
                alicionay.aliciID = alici.AliciID;
                alicionay.AliciPara = para * int.Parse(sonpara.ToString());
                db.TblParaOnays.Add(alicionay);
                db.SaveChanges();
                MessageBox.Show("Para Eklendi Admin Onayı Bekleniyor");
            }
            else if (comboBox1.Text=="GBP")
            {
                para = int.Parse(txtalicipara.Text);
                float sonpara = float.Parse(USD.ToString());
                alicionay.aliciID = alici.AliciID;
                alicionay.AliciPara = para * int.Parse(sonpara.ToString());
                db.TblParaOnays.Add(alicionay);
                db.SaveChanges();
                MessageBox.Show("Para Eklendi Admin Onayı Bekleniyor");
            }
            else
            {
                para = int.Parse(txtalicipara.Text);
                alicionay.aliciID = alici.AliciID;
                alicionay.AliciPara = para;
                db.TblParaOnays.Add(alicionay);
                db.SaveChanges();
                MessageBox.Show("Para Eklendi Admin Onayı Bekleniyor");
            }
          
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
                            var urunmiktarguncelle = db.TblUruns.Where(p => p.UrunID == idurun).First<TblUrun>();
                            kasaguncelle.KasaPara += (uruntoplamfiyat * 1) / 100;
                            if (saticiparaguncelle.SaticiPara==null)
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
                            aliciparaguncelle.AliciPara -= uruntoplamfiyat+(uruntoplamfiyat/100);
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
            worksheet.Cells[Satir, Sutun + 3].Value = "Ürün Alım Başlangıç Tarihi";
            worksheet.Cells[Satir, Sutun + 4].Value = "Ürün Alım Bitiş Tarihi";
            var alinanUrunler = db.TblAlinanUrunlers.Where(p => p.TblAlici.kullaniciad == Form1.kullaniciadi).ToList();
            foreach (var item in alinanUrunler)
            {
                worksheet.Cells[Satir+1, Sutun].Value = item.UrunAdi;
                worksheet.Cells[Satir+1, Sutun + 1].Value = item.UrunMiktar;
                worksheet.Cells[Satir+1, Sutun + 2].Value = item.UrunFiyat;
                worksheet.Cells[Satir+1, Sutun + 3].Value = item.AlimBaslangic;
                worksheet.Cells[Satir+1, Sutun + 4].Value = item.AlimBitis;
                Satir++;               
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Dosyası|*.xlsx";
            saveFileDialog.ShowDialog();
            Stream stream1 = saveFileDialog.OpenFile();
            package.SaveAs(stream1);
            stream1.Close();
            MessageBox.Show("Rapor Oluşturuldu");
        }

        private void dataGridView2_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }
       
    }
}
