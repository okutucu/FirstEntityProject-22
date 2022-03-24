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
    public partial class FrmIstatistikler : Form
    {
        public FrmIstatistikler()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void FrmIstatistikler_Load(object sender, EventArgs e)
        {

            // Toplam Kategori Sayısı
            label2.Text = db.TblKategori.Count().ToString();

            // Toplam Ürün Sayısı
            label3.Text = db.TblUrun.Count().ToString();

            // Aktif Müşteri Sayısı
            label5.Text = db.TblMusteri.Count(x=>x.DURUM==true).ToString();
            //  x => x..  Lambda sorgulaması

            // Pasif Müşteri Sayısı
            label7.Text = db.TblMusteri.Count(x => x.DURUM == false).ToString();

            // Toplam Stok sayısı
            label13.Text = db.TblUrun.Sum(x => x.STOK).ToString();

            // Kasadaki Toplam Tutar
            label21.Text = db.TblSatis.Sum(x=> x.FIYAT).ToString() + " ₺";

            // En YÜKSEK FİYATLI ÜRÜN
            label11.Text = (from x in db.TblUrun orderby x.FIYAT descending select x.URUNAD).FirstOrDefault();

            // En Düşük FİYATLI ÜRÜN
            label9.Text = (from x in db.TblUrun orderby x.FIYAT ascending select x.URUNAD).FirstOrDefault();

            // Beyaz Eşya sayısı bulmak
            label15.Text = db.TblUrun.Count(x => x.KATEGORI == 1).ToString();

            // Toplam buzdolabı sayısı
            label17.Text = db.TblUrun.Count(x => x.URUNAD == "BUZDOLABI").ToString();

            //Şehir sayısı
            label23.Text = (from x in db.TblMusteri select x.SEHIR).Distinct().Count().ToString();

            // En fazla ürünlü marka
            label19.Text = db.MARKAGETİR().FirstOrDefault();
            
        }
    }
}
