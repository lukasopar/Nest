using DesktopForms.Presenters;
using DesktopFOrms.ViewInterfaces;
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
    public partial class PostupakForm : Form, IPostupakView
    {
        public PostupakForm()
        {
            InitializeComponent();
        }

        public Zivotinja Zivotinja { get => (Zivotinja)groupBox1.Tag;
            set
            {
                groupBox1.Tag = value;
                if (value == null)
                    return;
                labelVlasnik.Text = value.Vlasnik.Ime + " " + value.Vlasnik.Prezime;
                labelZivotinja.Text = value.Ime;
                textBox1.Text = value.Napomena;

                labelVlasnik.ForeColor = Color.Black;
                labelZivotinja.ForeColor = Color.Black;
            }
        }
        public PostupakPresenter Presenter { private get; set; }
        public List<VrstaPostupka> VrstePostupaka { get => (List<VrstaPostupka>)comboBoxVrstePostupaka.DataSource; set { comboBoxVrstePostupaka.DataSource = value; comboBoxVrstePostupaka.DisplayMember = "Naziv"; } }

        public List<Bolest> Bolesti { get => (List<Bolest>)listBoxBolesti.DataSource; set { listBoxBolesti.DataSource = value; listBoxBolesti.DisplayMember = "Naziv"; } }

        private void buttonOdaberi_Click(object sender, EventArgs e)
        {
            Presenter.OdaberiZivotinju();
        }

        private void comboBoxVrstePostupaka_SelectedIndexChanged(object sender, EventArgs e)
        {
            var vrsta = (VrstaPostupka)comboBoxVrstePostupaka.SelectedItem;
            labelCIjena.Text = vrsta.Cijena + " kn";
            textBoxOpisPostupka.Text = vrsta.Opis;
        }

        private void buttonDodajBolest_Click(object sender, EventArgs e)
        {
            Presenter.DodajDijagnozu();
        }

        private void buttonObrisiBolest_Click(object sender, EventArgs e)
        {
            var selected = (Bolest)listBoxBolesti.SelectedItem;
            Presenter.IzbrisiIzDijagnoze(selected);
        }

        private void listBoxBolesti_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxBolesti.SelectedItems.Count == 0)
            {
                buttonObrisiBolest.Enabled = false;
                return;
            }
            buttonObrisiBolest.Enabled = true;
            
        }
    }
}
