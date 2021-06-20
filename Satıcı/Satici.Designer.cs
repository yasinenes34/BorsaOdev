
namespace BorsaOdev.Satıcı
{
    partial class Satici
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txturunad = new System.Windows.Forms.TextBox();
            this.txturunmiktar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.baslangic = new System.Windows.Forms.DateTimePicker();
            this.bitis = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtfiyat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnurunekle = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ürün Adı:";
            // 
            // txturunad
            // 
            this.txturunad.Location = new System.Drawing.Point(122, 26);
            this.txturunad.Name = "txturunad";
            this.txturunad.Size = new System.Drawing.Size(200, 20);
            this.txturunad.TabIndex = 1;
            // 
            // txturunmiktar
            // 
            this.txturunmiktar.Location = new System.Drawing.Point(122, 52);
            this.txturunmiktar.Name = "txturunmiktar";
            this.txturunmiktar.Size = new System.Drawing.Size(200, 20);
            this.txturunmiktar.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ürün Miktarı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Satış başlangıç tarihi:";
            // 
            // baslangic
            // 
            this.baslangic.Location = new System.Drawing.Point(122, 79);
            this.baslangic.Name = "baslangic";
            this.baslangic.Size = new System.Drawing.Size(200, 20);
            this.baslangic.TabIndex = 8;
            // 
            // bitis
            // 
            this.bitis.Location = new System.Drawing.Point(122, 105);
            this.bitis.Name = "bitis";
            this.bitis.Size = new System.Drawing.Size(200, 20);
            this.bitis.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Satış bitiş tarihi:";
            // 
            // txtfiyat
            // 
            this.txtfiyat.Location = new System.Drawing.Point(122, 131);
            this.txtfiyat.Name = "txtfiyat";
            this.txtfiyat.Size = new System.Drawing.Size(200, 20);
            this.txtfiyat.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ürün Fiyatı:";
            // 
            // btnurunekle
            // 
            this.btnurunekle.Location = new System.Drawing.Point(342, 29);
            this.btnurunekle.Name = "btnurunekle";
            this.btnurunekle.Size = new System.Drawing.Size(190, 23);
            this.btnurunekle.TabIndex = 13;
            this.btnurunekle.Text = "Ürün Ekle";
            this.btnurunekle.UseVisualStyleBackColor = true;
            this.btnurunekle.Click += new System.EventHandler(this.btnurunekle_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 157);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(536, 150);
            this.dataGridView1.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(342, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Rapor Al";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Satici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 342);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnurunekle);
            this.Controls.Add(this.txtfiyat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bitis);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.baslangic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txturunmiktar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txturunad);
            this.Controls.Add(this.label1);
            this.Name = "Satici";
            this.Text = "Satici";
            this.Load += new System.EventHandler(this.Satici_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txturunad;
        private System.Windows.Forms.TextBox txturunmiktar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker baslangic;
        private System.Windows.Forms.DateTimePicker bitis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtfiyat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnurunekle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
    }
}