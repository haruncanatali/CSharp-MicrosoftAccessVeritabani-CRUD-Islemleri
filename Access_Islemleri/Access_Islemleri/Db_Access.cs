using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace Access_Islemleri
{
    public static class Db_Access
    {
        public static List<Personel> liste;
        public static OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.Oledb.12.0; Data Source=C:\Users\Acer\Desktop\VeriTabani.accdb");

        public static List<Personel> Read()
        {
            liste = new List<Personel>();
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("Select * from Tbl_Personel", baglanti);
                OleDbDataReader okuyucu = komut.ExecuteReader();
                
                while (okuyucu.Read())
                {
                    liste.Add(new Personel
                    {
                        Id = int.Parse(okuyucu[0].ToString()),
                        Ad = okuyucu[1].ToString(),
                        Soyad = okuyucu[2].ToString(),
                        Meslek = okuyucu[3].ToString(),
                        Maas = int.Parse(okuyucu[4].ToString())
                    });
                }

                baglanti.Close();

                return liste;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Add(Personel personel)
        {
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into Tbl_Personel(ID,AD,SOYAD,MESLEK,MAAS) values(@p1,@p2,@p3,@p4,@p5)", baglanti);

                komut.Parameters.AddWithValue("@p1", personel.Id);
                komut.Parameters.AddWithValue("@p2", personel.Ad);
                komut.Parameters.AddWithValue("@p3", personel.Soyad);
                komut.Parameters.AddWithValue("@p4", personel.Meslek);
                komut.Parameters.AddWithValue("@p5", personel.Maas);

                komut.ExecuteNonQuery();

                baglanti.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Update(Personel personel)
        {
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("update Tbl_Personel set AD=@p1,SOYAD=@p2,MESLEK=@p3,MAAS=@p4 where ID=@p5", baglanti);

                komut.Parameters.AddWithValue("@p1", personel.Ad);
                komut.Parameters.AddWithValue("@p2", personel.Soyad);
                komut.Parameters.AddWithValue("@p3", personel.Meslek);
                komut.Parameters.AddWithValue("@p4", personel.Maas);
                komut.Parameters.AddWithValue("@p5", personel.Id);

                komut.ExecuteNonQuery();

                baglanti.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Delete(int id)
        {
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("delete from Tbl_Personel where ID=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", id);
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
