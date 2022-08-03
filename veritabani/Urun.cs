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
    public partial class Urun : Form
    {
        public Urun()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=dbproje; " +
            "user id=postgres; password=asli+123");
        private void Urun_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from urunkategori", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Ktip.DisplayMember = "ad";
            Ktip.ValueMember = "no";
            Ktip.DataSource = dt;
            baglanti.Close();

            baglanti.Open();
            NpgsqlDataAdapter da1 = new NpgsqlDataAdapter("select * from urunkategori", baglanti);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            Ftip.DisplayMember = "ad";
            Ftip.ValueMember = "no";
            Ftip.DataSource = dt;
            baglanti.Close();
        }

        private void btCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Klistele_Click(object sender, EventArgs e)
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from urunkitap()", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dbUrun.DataSource = ds.Tables[0];
        }

        private void Ksil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from urun where no=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(Kurunkod.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("Delete from kitap where kitapno=@p2", baglanti);
            komut3.Parameters.AddWithValue("@p2", int.Parse(Kurunkod.Text));
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitap Silme işlemi başarılı bir şekilde gerçekleşti.");

        }

        private void Kguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update urun set kategorino=@p2 where no=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", int.Parse(Kurunkod.Text));
            komut3.Parameters.AddWithValue("@p2", int.Parse(Ktip.SelectedValue.ToString()));
            komut3.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("update kitap set ad=@p4,yazarno=@p5,kategorino=@p6,yayinevino=@p7,urunkod=@p8 where kitapno=@p3", baglanti);
            komut4.Parameters.AddWithValue("@p3", int.Parse(Kurunkod.Text));
            komut4.Parameters.AddWithValue("@p4", Kad.Text);
            komut4.Parameters.AddWithValue("@p5", int.Parse(Kyazar.Text));
            komut4.Parameters.AddWithValue("@p6", int.Parse(Kkategori.Text));
            komut4.Parameters.AddWithValue("@p7", int.Parse(Kyayinevi.Text));
            komut4.Parameters.AddWithValue("@p8", int.Parse(Kurunkod.Text));
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitap Bilgisi güncelleme işlemi başarılı bir şekilde gerçekleşti.");

        }

        private void Kara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("select * from urun where no=@p1", baglanti);
            komut4.Parameters.AddWithValue("@p1", int.Parse(Kurunkod.Text));
            komut4.ExecuteNonQuery();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut4);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dbUrun.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void Kekle_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            NpgsqlCommand komut5 = new NpgsqlCommand("insert into urun(no,kategorino) values(@p1,@p2)", baglanti);
            komut5.Parameters.AddWithValue("@p1", int.Parse(Kurunkod.Text));
            komut5.Parameters.AddWithValue("@p2", int.Parse(Ktip.SelectedValue.ToString()));
            komut5.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            NpgsqlCommand komut6 = new NpgsqlCommand("insert into kitap(kitapno,ad,yazarno,kategorino,yayinevino,urunkod) values(@p3,@p4,@p5,@p6,@p7,@p8)", baglanti);
            komut6.Parameters.AddWithValue("@p3", int.Parse(Kurunkod.Text));
            komut6.Parameters.AddWithValue("@p4", Kad.Text);
            komut6.Parameters.AddWithValue("@p5", int.Parse(Kyazar.Text));
            komut6.Parameters.AddWithValue("@p6", int.Parse(Kkategori.Text));
            komut6.Parameters.AddWithValue("@p7", int.Parse(Kyayinevi.Text));
            komut6.Parameters.AddWithValue("@p8", int.Parse(Kurunkod.Text));
            komut6.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitap Ekleme işlemi başarılı bir şekilde gerçekleşti.");

        }

        private void Flistele_Click(object sender, EventArgs e)
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from urunfilm()", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dbUrun.DataSource = ds.Tables[0];
        }

        private void Fsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from urun where no=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(Furunkod.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("Delete from film where no=@p2", baglanti);
            komut3.Parameters.AddWithValue("@p2", int.Parse(Furunkod.Text));
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film Silme işlemi başarılı bir şekilde gerçekleşti.");
        }

        private void Fguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update urun set kategorino=@p2 where no=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", int.Parse(Furunkod.Text));
            komut3.Parameters.AddWithValue("@p2", int.Parse(Ftip.SelectedValue.ToString()));
            komut3.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("update film set ad=@p4,cikisyili=@p5,kategorino=@p6,urunkod=@p7 where no=@p3", baglanti);
            komut4.Parameters.AddWithValue("@p3", int.Parse(Furunkod.Text));
            komut4.Parameters.AddWithValue("@p4", Fad.Text);
            komut4.Parameters.AddWithValue("@p5", int.Parse(Fyil.Text));
            komut4.Parameters.AddWithValue("@p6", int.Parse(Fkategori.Text));
            komut4.Parameters.AddWithValue("@p7", int.Parse(Furunkod.Text));
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film Bilgisi güncelleme işlemi başarılı bir şekilde gerçekleşti.");
        }

        private void Fara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("select * from urun where no=@p1", baglanti);
            komut4.Parameters.AddWithValue("@p1", int.Parse(Furunkod.Text));
            komut4.ExecuteNonQuery();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut4);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dbUrun.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void Fekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut5 = new NpgsqlCommand("insert into urun(no,kategorino) values(@p1,@p2)", baglanti);
            komut5.Parameters.AddWithValue("@p1", int.Parse(Furunkod.Text));
            komut5.Parameters.AddWithValue("@p2", int.Parse(Ftip.SelectedValue.ToString()));
            komut5.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            NpgsqlCommand komut6 = new NpgsqlCommand("insert into film(no,ad,cikisyili,kategorino,urunkod) values(@p3,@p4,@p5,@p6,@p7)", baglanti);
            komut6.Parameters.AddWithValue("@p3", int.Parse(Furunkod.Text));
            komut6.Parameters.AddWithValue("@p4", Fad.Text);
            komut6.Parameters.AddWithValue("@p5", Fyil.Text);
            komut6.Parameters.AddWithValue("@p6", int.Parse(Fkategori.Text));
            komut6.Parameters.AddWithValue("@p7", int.Parse(Furunkod.Text));
            komut6.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film Ekleme işlemi başarılı bir şekilde gerçekleşti.");
        }

        private void btToplam_Click(object sender, EventArgs e)
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from toplam1()", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dbUrun.DataSource = ds.Tables[0];
        }
    }
}
