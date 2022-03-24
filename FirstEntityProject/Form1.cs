using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstEntityProject
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
 
        public string Message(int kayit)
        {

            if (kayit > 0)
            {
                return $"İşleminiz başarılı bir şekilde gerçekleştirilmiştir.";
            }
            else
            {
               return $"Hay Aksi. Bir şeyler ters gitti !";
            }

        }

        public List<TblKategori> Listele()
        {
            var kategoriler = db.TblKategori.ToList();
            return (List<TblKategori>)(dataGridView1.DataSource = kategoriler);
        }

         DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TblKategori tblKategori = new TblKategori();
            tblKategori.AD = txtKategoriAdi.Text;

            db.TblKategori.Add(tblKategori);

            MessageBox.Show(Message(db.SaveChanges()));
            Listele();



        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int silinecekId = int.Parse(txtKategoriId.Text);

            var silId = db.TblKategori.Find(silinecekId);
            db.TblKategori.Remove(silId);

            MessageBox.Show(Message(db.SaveChanges()));
            Listele();

        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            int guncellenecekId = int.Parse(txtKategoriId.Text);

            var guncelleId = db.TblKategori.Find(guncellenecekId);

            guncelleId.AD = txtKategoriAdi.Text;

            MessageBox.Show(Message(db.SaveChanges()));
            Listele();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
