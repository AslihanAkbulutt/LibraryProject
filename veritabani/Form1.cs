namespace veritabani
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btKisi_Click(object sender, EventArgs e)
        {
            Kisi kisi = new Kisi();
            kisi.Show();
            this.Hide();
        }

        private void btOdunc_Click(object sender, EventArgs e)
        {
            Odunc odunc = new Odunc();
            odunc.Show();
            this.Hide();
        }

        private void btUrun_Click(object sender, EventArgs e)
        {
            Urun urun = new Urun();
            urun.Show();
            this.Hide();
        }

        private void btDiger_Click(object sender, EventArgs e)
        {
            Diger diger = new Diger();
            diger.Show();
            this.Hide();
        }
    }
}