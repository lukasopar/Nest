using DatabaseBootstrap;
using DatabaseBootstrap.Repositories;
using DesktopForms.Presenters;
using DesktopForms.ViewInterfaces;
using System;
using System.Windows.Forms;

namespace DesktopForms.Views
{
    public partial class GlavniForm : Form, IGlavniView
    {
        public GlavniForm()
        {
            InitializeComponent();
            var vet = NHibernateService.PrijavljeniVeterinar;
            labelImeVet.Text = vet.Ime + " " + vet.Prezime;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        public GlavniPresenter Presenter { private get; set; }

        private void buttonRegistracijaVlasnik_Click(object sender, EventArgs e)
        {
            Presenter.OtvoriRegistracijuVlasnika();
        }

        private void buttonRegistracijaZivotinje_Click(object sender, EventArgs e)
        {
            Presenter.OtvoriRegistracijuZivotinje();

        }

        private void buttonBolesti_Click(object sender, EventArgs e)
        {
            Presenter.OtvoriBolesti();

        }

        private void buttonLijekovi_Click(object sender, EventArgs e)
        {
            Presenter.OtvoriLijekovi();

        }

        private void buttonRacunNovi_Click(object sender, EventArgs e)
        {
            Presenter.OtvoriNoviRacun();
        }

        private void buttonPostupak_Click(object sender, EventArgs e)
        {
            Presenter.OtvoriNoviPostupak();
        }

       

        private void buttonRacunSkini_Click(object sender, EventArgs e)
        {
            Presenter.OtvoriPreuzimanjeRacuna();
        }

        private void buttonIzvjestaji_Click(object sender, EventArgs e)
        {
            Presenter.OtvoriIzvjestaje();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Presenter.OtvoriRegistracijuVlasnika();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Presenter.OtvoriRegistracijuZivotinje();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Presenter.OtvoriBolesti();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Presenter.OtvoriIzvjestaje();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Presenter.OtvoriLijekovi();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Presenter.OtvoriPreuzimanjeRacuna();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Presenter.OtvoriNoviRacun();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Presenter.OtvoriNoviPostupak();
        }
    }
}
