using BorsaOdev.DatabaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorsaOdev.admin
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        BorsaOdevEntities db = new BorsaOdevEntities();
        private void btnsatici_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource= db.TblUrunOnays.ToList();
            dataGridView2.Visible = false;
            dataGridView2.Enabled = false;
            dataGridView1.Visible = true;
            dataGridView1.Enabled = true;
        }

        private void btnalici_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = db.TblParaOnays.ToList();
            dataGridView1.Visible = false;
            dataGridView1.Enabled = false;
            dataGridView2.Visible = true;
            dataGridView2.Enabled = true;
        }

        private void brncikis_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
            
        }

       
        void urunonay()
        {
            TblUrun urun = new TblUrun();
            
           
                urun.UrunAdi = txturunad.Text;
                urun.UrunFiyat =int.Parse( txtfiyat.Text);
                urun.UrunMiktar = int.Parse(txturunmiktar.Text);
                urun.UrunSatisBaslangic = Convert.ToDateTime( txtbaslangic.Text);
                urun.UrunSatisBitis = Convert.ToDateTime(txtbitis.Text);
                urun.SaticiID =int.Parse( txtsaticiid.Text);
                db.TblUruns.Add(urun);
                db.SaveChanges();
                

                MessageBox.Show("Ürünler Onaylandı");
            
        }
        void urunsil()
        {
           var x = db.TblUrunOnays.Find(int.Parse(txturunid.Text));
            db.TblUrunOnays.Remove(x);
            db.SaveChanges();
        }

        private void btnUrunonay_Click(object sender, EventArgs e)
        {
            urunonay();
            urunsil();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
          
        }

       

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txturunid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtsaticiid.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txturunad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txturunmiktar.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtbaslangic.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtbitis.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtfiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            dataGridView2.Enabled = false;
            dataGridView1.Visible = true;
            dataGridView1.Enabled = true;
            dataGridView1.DataSource= db.TblUruns.ToList();
        }
        public int para;
        public int paraonayid;
        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            paraonayid =int.Parse( dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtaliciid.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            para = int.Parse(dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TblAlici alici = new TblAlici();
            int id = Convert.ToInt32(txtaliciid.Text);
            alici.AliciPara = para;
            
             var std = db.TblAlicis.Where(p=>p.AliciID==id).First<TblAlici>();
             std.AliciPara = para;
             db.SaveChanges();
            
            MessageBox.Show("Para onaylandı");
            var x = db.TblParaOnays.Find(paraonayid);
            db.TblParaOnays.Remove(x);

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_saticiListele_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            dataGridView2.Enabled = false;
            dataGridView1.Visible = true;
            dataGridView1.Enabled = true;
            dataGridView1.DataSource = db.TblSaticis.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            dataGridView2.Enabled = false;
            dataGridView1.Visible = true;
            dataGridView1.Enabled = true;
            dataGridView1.DataSource = db.TblAlicis.ToList();
        }
    }
}
