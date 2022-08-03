using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data;

namespace veritabani
{
    public partial class Kisi : Form
    {
        public Kisi()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=dbproje; " +
            "user id=postgres; password=asli+123");
        private void Kisi_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from kisitur", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbTur.DisplayMember = "ad";
            cbTur.ValueMember = "no";
            cbTur.DataSource = dt;
            baglanti.Close();
        }

        private void btKListele_Click(object sender, EventArgs e)
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from kisi order by kisino", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dbKisi.DataSource = ds.Tables[0];
        }

        private void btAra_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("select * from kisi where kisino=@p1", baglanti);
            komut4.Parameters.AddWithValue("@p1", int.Parse(kisino.Text));
            komut4.ExecuteNonQuery();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut4);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dbKisi.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void btGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update kisi set ad=@p2,soyad=@p3,kisitur=@p4 where kisino=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", int.Parse(kisino.Text));
            komut3.Parameters.AddWithValue("@p2", ad.Text);
            komut3.Parameters.AddWithValue("@p3", soyad.Text);
            komut3.Parameters.AddWithValue("@p4", int.Parse(cbTur.SelectedValue.ToString()));
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kişi güncelleme işlemi başarılı bir şekilde gerçekleşti.");
        }

        private void btSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from kisi where kisino=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(kisino.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kişi Silme işlemi başarılı bir şekilde gerçekleşti.");

        }

        private void btEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into kisi(kisino,ad,soyad,kisitur) " +
                "values(@p1,@p2,@p3,@p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(kisino.Text));
            komut.Parameters.AddWithValue("@p2", ad.Text);
            komut.Parameters.AddWithValue("@p3", soyad.Text);
            komut.Parameters.AddWithValue("@p4", int.Parse(cbTur.SelectedValue.ToString()));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kişi ekleme işlemi başarılı bir şekilde gerçekleşti.");

        }

        private void btCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ibEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into iletisimbilgileri(no,telefon,adres,ilce,kisino) " +
                "values(@p1,@p2,@p3,@p4,@p5)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(ibno.Text));
            komut.Parameters.AddWithValue("@p2", telefon.Text);
            komut.Parameters.AddWithValue("@p3", adres.Text);
            komut.Parameters.AddWithValue("@p4", int.Parse(ilceno.Text));
            komut.Parameters.AddWithValue("@p5", int.Parse(ibkisino.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İletişim bilgisi ekleme işlemi başarılı bir şekilde gerçekleşti.");

        }

        private void ibListele_Click(object sender, EventArgs e)
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from iletisimbilgileri", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dbKisi.DataSource = ds.Tables[0];
        }

        private void ibSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from iletisimbilgileri where no=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(ibno.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İletişim bilgisi Silme işlemi başarılı bir şekilde gerçekleşti.");

        }

        private void ibGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update iletisimbilgileri set telefon=@p2,adres=@p3,ilce=@p4,kisino=@p5 where no=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", int.Parse(ibno.Text));
            komut3.Parameters.AddWithValue("@p2", telefon.Text);
            komut3.Parameters.AddWithValue("@p3", adres.Text);
            komut3.Parameters.AddWithValue("@p4", int.Parse(ilceno.Text));
            komut3.Parameters.AddWithValue("@p5", int.Parse(ibkisino.Text));
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İletişim bilgisi güncelleme işlemi başarılı bir şekilde gerçekleşti.");

        }

        private void KBsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from kisiselbilgiler where tckimlik=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", tckimlik.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kişisel Bilgi Silme işlemi başarılı bir şekilde gerçekleşti.");
        }

        private void KBguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update kisiselbilgiler set dogumtarih=@p2,kayittarih=@p3,kisino=@p4 where tckimlik=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", tckimlik.Text);
            komut3.Parameters.AddWithValue("@p2", datedogum.Value);
            komut3.Parameters.AddWithValue("@p3", datekayit.Value);
            komut3.Parameters.AddWithValue("@p4", int.Parse(KBkisino.Text));
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kişisel Bilgi güncelleme işlemi başarılı bir şekilde gerçekleşti.");
        }

        private void KBlistele_Click(object sender, EventArgs e)
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from kisiselbilgiler", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dbKisi.DataSource = ds.Tables[0];
        }

        private void KBekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into kisiselbilgiler(tckimlik,dogumtarih,kayittarih,kisino) " +
                "values(@p1,@p2,@p3,@p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", tckimlik.Text);
            komut.Parameters.AddWithValue("@p2", datedogum.Value);
            komut.Parameters.AddWithValue("@p3", datekayit.Value);
            komut.Parameters.AddWithValue("@p4", int.Parse(KBkisino.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kişisel Bilgi ekleme işlemi başarılı bir şekilde gerçekleşti.");
        }
    }
}
