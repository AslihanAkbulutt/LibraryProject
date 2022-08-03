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
    public partial class Odunc : Form
    {
        public Odunc()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=dbproje; " +
            "user id=postgres; password=asli+123");
        private void Oara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("select * from odunc where no=@p1", baglanti);
            komut4.Parameters.AddWithValue("@p1", int.Parse(oduncNo.Text));
            komut4.ExecuteNonQuery();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut4);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dbOdunc.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void Osil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from odunc where no=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(oduncNo.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İade işlemi başarılı bir şekilde gerçekleşti.");
        }

        private void Oguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update odunc set odunctarih=@p2,uye=@p3,gorevli=@p4,urunkod=@p5 where no=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", int.Parse(oduncNo.Text));
            komut3.Parameters.AddWithValue("@p2", dateOdunc.Value);
            komut3.Parameters.AddWithValue("@p3", int.Parse(Ouyeno.Text));
            komut3.Parameters.AddWithValue("@p4", int.Parse(Ogorevlino.Text));
            komut3.Parameters.AddWithValue("@p5", int.Parse(Ourunkod.Text));
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ödünç Bilgisi güncelleme işlemi başarılı bir şekilde gerçekleşti.");

        }

        private void Oekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into odunc(no,odunctarih,uye,gorevli,urunkod) " +
                "values(@p1,@p2,@p3,@p4,@p5)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(oduncNo.Text));
            komut.Parameters.AddWithValue("@p2", dateOdunc.Value);
            komut.Parameters.AddWithValue("@p3", int.Parse(Ouyeno.Text));
            komut.Parameters.AddWithValue("@p4", int.Parse(Ogorevlino.Text));
            komut.Parameters.AddWithValue("@p5", int.Parse(Ourunkod.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ödünç Alma işlemi başarılı bir şekilde gerçekleşti.");

        }

        private void Olistele_Click(object sender, EventArgs e)
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from odunckisi() order by no", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dbOdunc.DataSource = ds.Tables[0];
        }

        private void Klistele_Click(object sender, EventArgs e)
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from kayitkisi() order by no", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dbOdunc.DataSource = ds.Tables[0];
        }

        private void Ksil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from kayitlar where no=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(kayitNo.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silme işlemi başarılı bir şekilde gerçekleşti.");

        }

        private void Kguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update kayitlar set uye=@p2,gorevli=@p3,urunkod=@p4,odunctarih=@p5,iadetarih=@p6 where no=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", int.Parse(kayitNo.Text));
            komut3.Parameters.AddWithValue("@p2", int.Parse(Kuyeno.Text));
            komut3.Parameters.AddWithValue("@p3", int.Parse(Kgorevlino.Text));
            komut3.Parameters.AddWithValue("@p4", int.Parse(Kurunkod.Text));
            komut3.Parameters.AddWithValue("@p5", dateKodunc.Value);
            komut3.Parameters.AddWithValue("@p6", dateKiade.Value);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Bilgisi güncelleme işlemi başarılı bir şekilde gerçekleşti.");

        }

        private void Kara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("select * from kayitlar where no=@p1", baglanti);
            komut4.Parameters.AddWithValue("@p1", int.Parse(kayitNo.Text));
            komut4.ExecuteNonQuery();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut4);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dbOdunc.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void Kekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into kayitlar(no,uye,gorevli,urunkod,odunctarih,iadetarih) " +
                "values(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(kayitNo.Text));
            komut.Parameters.AddWithValue("@p2", int.Parse(Kuyeno.Text));
            komut.Parameters.AddWithValue("@p3", int.Parse(Kgorevlino.Text));
            komut.Parameters.AddWithValue("@p4", int.Parse(Kurunkod.Text));
            komut.Parameters.AddWithValue("@p5", dateKodunc.Value);
            komut.Parameters.AddWithValue("@p6", dateKiade.Value);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Ekleme işlemi başarılı bir şekilde gerçekleşti.");

        }

        private void btCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
