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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }
        //public List<TblUrun> Listele()
        //{
        //    var tblUrun = (from x in db.TblUrun
        //                   select new
        //                   {
        //                       x.URUNID,
        //                       x.URUNAD,
        //                       x.MARKA,
        //                       x.FIYAT,
        //                       x.KATEGORI,
        //                       x.DURUM,
        //                       x.STOK
        //                   }).ToList();


        //    return (List<TblUrun>)(dataGridView1.DataSource = (tblUrun));
        //}

        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = (from x in db.TblUrun
                                        select new
                                        {
                                            x.URUNID,
                                            x.URUNAD,
                                            x.MARKA,
                                            x.FIYAT,
                                            //x.KATEGORI, // Burda sadece kategorilerin id si gelir.
                                            x.TblKategori.AD, // Urun tablosu kategoriye bağlı olduğundan kategori namelere ulaşabiliyoruz.
                                            x.DURUM,
                                            x.STOK
                                        }).ToList();
        }
        public string Message(int saveChange)
        {
            if (saveChange > 0)
            {
                return $"İşleminiz başarılı bir şekilde gerçekleştirilmiştir";
            }
            else
            {
                return $"Hay aksi. Başarısız işlemm !!";
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TblUrun tblUrun = new TblUrun();
            tblUrun.URUNAD = txtUrunAdi.Text;
            tblUrun.MARKA = txtUrunMarka.Text;
            tblUrun.FIYAT = decimal.Parse(txtUrunFiyat.Text);
            tblUrun.STOK = short.Parse(txtUrunStok.Text);
            tblUrun.KATEGORI = int.Parse(cmbUrunKategori.SelectedValue.ToString());
            tblUrun.DURUM = true;

            db.TblUrun.Add(tblUrun);

            MessageBox.Show(Message(db.SaveChanges()));

        }

        private void btnSilme_Click(object sender, EventArgs e)
        {

            int silinecekId = int.Parse(txtUrunId.Text);

            var silinecekUrun = db.TblUrun.Find(silinecekId);
            db.TblUrun.Remove(silinecekUrun);

            MessageBox.Show(Message(db.SaveChanges()));



        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            int guncellenecekId = int.Parse(txtUrunId.Text);

            var guncellenecekUrun = db.TblUrun.Find(guncellenecekId);

            guncellenecekUrun.URUNAD = txtUrunAdi.Text;
            guncellenecekUrun.STOK = short.Parse(txtUrunStok.Text);
            guncellenecekUrun.MARKA = txtUrunMarka.Text;

            MessageBox.Show(Message(db.SaveChanges()));


        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            // Kategoriler combobox'ına kategoriler tablosundaki verilerin ıd lerini ve kategori adlarını alıp listeledik. !!
            var kategoriler = (from x in db.TblKategori
                               select new
                               {
                                   x.ID,
                                   x.AD
                               }).ToList();

            cmbUrunKategori.ValueMember = "ID"; // arka planda çalışacak olan değer .
            cmbUrunKategori.DisplayMember = "AD"; // tabloda gösterilecek olan değer.
            cmbUrunKategori.DataSource = kategoriler; // comboboxa atama yaptığımız değer
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {

        }
    }
}
