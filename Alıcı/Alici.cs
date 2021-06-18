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
            dataGridView1.DataSource = db.TblAlicis.Where(x => x.kullaniciad == Form1.kullaniciadi).ToList();
        }

        private void btnparaekle_Click(object sender, EventArgs e)
        {
           
            paraekle();
        }
        void paraekle()
        {
            TblParaOnay alici = new TblParaOnay();
            alici.aliciID =int.Parse( txtaliciid.Text);
            alici.AliciPara =int.Parse(txtalicipara.Text);
            db.TblParaOnays.Add(alici);
            db.SaveChanges();
            MessageBox.Show("Para Eklendi Admin Onayı Bekleniyor");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.TblUruns.ToList();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtaliciid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //txtalicipara.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.TblParaOnays.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.TblAlicis.ToList();
        }
    }
}
