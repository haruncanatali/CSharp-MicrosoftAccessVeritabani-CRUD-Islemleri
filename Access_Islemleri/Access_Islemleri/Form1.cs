using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Access_Islemleri
{
    public partial class Form1 : Form
    {
        int id = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void VeriTabaniBtns_Click(object sender, EventArgs e)
        {
            SimpleButton buton = sender as SimpleButton;
            switch (buton.Text)
            {
                case "Ekle":
                    Ekle_Fonk();
                    break;
                case "Güncelle":
                    Guncelle_Fonk();
                    break;
                case "Sil":
                    Sil_Fonk();
                    break;
            }
        }

        private void Sil_Fonk()
        {
            Db_Access.Delete(id);
            Yukle_Fonk();
        }

        private void Guncelle_Fonk()
        {
            Db_Access.Update(new Personel
            {
                Id = id,
                Ad = adTxt.Text.ToString(),
                Soyad = soyadTxt.Text.ToString(),
                Maas = int.Parse(maasTxt.Text.ToString()),
                Meslek = meslekTxt.Text.ToString()
            });

            Yukle_Fonk();
        }

        private void Ekle_Fonk()
        {
            Db_Access.Add(new Personel
            {
                Id = (new Random()).Next(1, 10000),
                Ad = adTxt.Text.ToString(),
                Soyad = soyadTxt.Text.ToString(),
                Maas = int.Parse(maasTxt.Text.ToString()),
                Meslek = meslekTxt.Text.ToString()
            });
            Yukle_Fonk();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Yukle_Fonk();
        }

        private void Yukle_Fonk()
        {
            id = -1;
            adTxt.Text = "";
            soyadTxt.Text = "";
            meslekTxt.Text = "";
            maasTxt.Text = "";

            gridControl1.DataSource = Db_Access.Read();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
            adTxt.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            soyadTxt.Text = gridView1.GetFocusedRowCellValue("Soyad").ToString();
            meslekTxt.Text = gridView1.GetFocusedRowCellValue("Meslek").ToString();
            maasTxt.Text = gridView1.GetFocusedRowCellValue("Maas").ToString();
        }
    }
}
