using DesktopForms.Presenters;
using DesktopForms.ViewInterfaces;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopForms.Views
{
    public partial class RacunForm : Form, IRacunView
    {
        public RacunForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private Racun Racun { get; set; } = new Racun(DateTime.Now) { };

        public List<LijekStavkaRacuna> Lijekovi
        {
            get => (List<LijekStavkaRacuna>)listView1.Tag;
            set
            {
                listView1.Items.Clear();
                listView1.Tag = value;
                if (value.Count == 0)
                    buttonObrisiLijek.Enabled = false;
                foreach (var lijek in value)
                {
                    ListViewItem it = new ListViewItem(new string[] { lijek.LijekKodVeterinara.Lijek.Naziv, lijek.LijekKodVeterinara.Cijena + "", lijek.Kolicina+"" });
                    it.Tag = lijek;
                    listView1.Items.Add(it);
                }
                Racun.LijekStavkaRacunas = new HashSet<LijekStavkaRacuna>(value);
                
                labelUkupno.Text = Racun.IzracunajUkupnuCijenu() + " kn";
            }
        }
        public List<Postupak> Postupci { get => (List<Postupak>)listView2.Tag;
            set
            {
                listView2.Items.Clear();
                listView2.Tag = value;
                if(value.Count == 0)
                    buttonObrisiPostupak.Enabled = false;

                foreach (var postupak in value)
                {
                    ListViewItem it = new ListViewItem(new string[] { postupak.VrstaPostupka.Naziv, postupak.VrstaPostupka.Cijena+"" });
                    it.Tag = postupak;
                    listView2.Items.Add(it);
                }
                Racun.Postupaks = new HashSet<Postupak>(value);
                labelUkupno.Text = Racun.IzracunajUkupnuCijenu() + " kn";

            }
        }
        public RacunPresenter Presenter { private get; set; }

        private void buttonDodajPostupak_Click(object sender, EventArgs e)
        {
            Presenter.DodajPostupak();

        }

        private void buttonObrisiPostupak_Click(object sender, EventArgs e)
        {
            var selected = (Postupak)listView2.SelectedItems[0].Tag;
            Presenter.IzbrisiIzPostupaka(selected);
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 0)
                buttonObrisiPostupak.Enabled = false;
            else
                buttonObrisiPostupak.Enabled = true;
        }

        private void buttonDodajLijek_Click(object sender, EventArgs e)
        {
            Presenter.DodajLijek();
        }

        private void buttonObrisiLijek_Click(object sender, EventArgs e)
        {
            var selected = (LijekStavkaRacuna)listView1.SelectedItems[0].Tag;
            Presenter.IzbrisiIzLijekova(selected);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                buttonObrisiLijek.Enabled = false;
            else
                buttonObrisiLijek.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Presenter.NoviRacun(Racun);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Presenter.CloseUnitOfWork();
            this.Close();
        }
    }
}
