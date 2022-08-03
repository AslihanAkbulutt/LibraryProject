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
    public partial class Diger : Form
    {
        public Diger()
        {
            InitializeComponent();
        }

        private void Diger_Load(object sender, EventArgs e)
        {

        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=dbproje; " +
            "user id=postgres; password=asli+123");
        private void Yguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update yazar set ad=@p2,soyad=@p3 where yazarno=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", int.Parse(Yyazarno.Text));
            komut3.Parameters.AddWithValue("@p2", Yad.Text);
            komut3.Parameters.AddWithValue("@p3", Ysoyad.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yazar Bilgisi güncelleme işlemi başarılı bir şekilde gerçekleşti.");

        }

        private void Ylistele_Click(object sender, EventArgs e)
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from yazar order by yazarno", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dbDiger.DataSource = ds.Tables[0];
        }

        private void Yara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("select * from yazar where yazarno=@p1", baglanti);
            komut4.Parameters.AddWithValue("@p1", int.Parse(Yyazarno.Text));
            komut4.ExecuteNonQuery();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut4);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dbDiger.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void Ysil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from yazar where yazarno=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(Yyazarno.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yazar Silme işlemi başarılı bir şekilde gerçekleşti.");

        }

        private void Yekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into yazar(yazarno,ad,soyad) " +
                "values(@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(Yyazarno.Text));
            komut.Parameters.AddWithValue("@p2", Yad.Text);
            komut.Parameters.AddWithValue("@p3", Ysoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yazar Ekleme işlemi başarılı bir şekilde gerçekleşti.");

        }

        private void Klistele_Click(object sender, EventArgs e)
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from kitapkategori order by kategorino", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dbDiger.DataSource = ds.Tables[0];
        }

        private void Kara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("select * from kitapkategori where kategorino=@p1", baglanti);
            komut4.Parameters.AddWithValue("@p1", int.Parse(Kkategori.Text));
            komut4.ExecuteNonQuery();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut4);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dbDiger.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void Kguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update kitapkategori set ad=@p2, where kategorino=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", int.Parse(Kkategori.Text));
            komut3.Parameters.AddWithValue("@p2", Kad.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitap Kategori Bilgisi güncelleme işlemi başarılı bir şekilde gerçekleşti.");
        }

        private void Ksil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from kitapkategori where kategorino=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(Kkategori.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitap Kategori Silme işlemi başarılı bir şekilde gerçekleşti.");
        }

        private void Kekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into kitapkategori(kategorino,ad) " +
                "values(@p1,@p2)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(Kkategori.Text));
            komut.Parameters.AddWithValue("@p2", Kad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitap Kategori Ekleme işlemi başarılı bir şekilde gerçekleşti.");
        }

        private void Flistele_Click(object sender, EventArgs e)
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from filmkategori order by no", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dbDiger.DataSource = ds.Tables[0];
        }

        private void Fara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("select * from filmkategori where no=@p1", baglanti);
            komut4.Parameters.AddWithValue("@p1", int.Parse(Fkategori.Text));
            komut4.ExecuteNonQuery();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut4);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dbDiger.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void Fguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update filmkategori set ad=@p2, where no=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", int.Parse(Fkategori.Text));
            komut3.Parameters.AddWithValue("@p2", Fad.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film Kategori Bilgisi güncelleme işlemi başarılı bir şekilde gerçekleşti.");
        }

        private void Fsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from filmkategori where no=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(Fkategori.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film Kategori Silme işlemi başarılı bir şekilde gerçekleşti.");
        }

        private void Fekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into filmkategori(no,ad) " +
                "values(@p1,@p2)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(Fkategori.Text));
            komut.Parameters.AddWithValue("@p2", Fad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film Kategori Ekleme işlemi başarılı bir şekilde gerçekleşti.");
        }

        private void YAlistele_Click(object sender, EventArgs e)
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from yayinevi order by yayinevino", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dbDiger.DataSource = ds.Tables[0];
        }

        private void YAara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("select * from yayinevi where yayinevino=@p1", baglanti);
            komut4.Parameters.AddWithValue("@p1", int.Parse(YAyayievino.Text));
            komut4.ExecuteNonQuery();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut4);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dbDiger.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void YAguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update yayinevi set ad=@p2,telefon=@p3 where yayinevino=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", int.Parse(YAyayievino.Text));
            komut3.Parameters.AddWithValue("@p2", YAad.Text);
            komut3.Parameters.AddWithValue("@p3", YAtelefon.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yayınevi güncelleme işlemi başarılı bir şekilde gerçekleşti.");

        }

        private void YAsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from yayinevi where yayinevino=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(YAyayievino.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yayınevi Silme işlemi başarılı bir şekilde gerçekleşti.");

        }

        private void YAekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into yayinevi(yayinevino,ad,telefon) " +
                "values(@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(YAyayievino.Text));
            komut.Parameters.AddWithValue("@p2", YAad.Text);
            komut.Parameters.AddWithValue("@p3", YAtelefon.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yayınevi Ekleme işlemi başarılı bir şekilde gerçekleşti.");

        }

        private void btCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
