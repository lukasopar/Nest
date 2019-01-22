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

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            Presenter.OtvoriRegistracijuVlasnika();

        }

        private void buttonRacunSkini_Click(object sender, EventArgs e)
        {
            Presenter.OtvoriPreuzimanjeRacuna();
        }
    }
}
