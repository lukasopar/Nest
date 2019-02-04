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
    public partial class PostupakForm : Form, IPostupakView
    {
        public PostupakForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }
        private Postupak postupak = new Postupak(); 
        public Zivotinja Zivotinja { get => (Zivotinja)groupBox1.Tag;
            set
            {
                groupBox1.Tag = value;
                if (value == null)
                {
                    button1.Enabled = false;
                    return;

                }
                button1.Enabled = true;

                labelVlasnik.Text = value.Vlasnik.Ime + " " + value.Vlasnik.Prezime;
                labelZivotinja.Text = value.Ime;
                textBox1.Text = value.Napomena;

                labelVlasnik.ForeColor = Color.Black;
                labelZivotinja.ForeColor = Color.Black;
                buttonPovijest.Enabled = true;
            }
        }
        public PostupakPresenter Presenter { private get; set; }
        public List<VrstaPostupka> VrstePostupaka { get => (List<VrstaPostupka>)comboBoxVrstePostupaka.DataSource; set { comboBoxVrstePostupaka.DataSource = value; comboBoxVrstePostupaka.DisplayMember = "Naziv"; } }

        public List<Bolest> Bolesti { get => (List<Bolest>)listViewBolesti.Tag; set
            {
                listViewBolesti.Tag = value;
                listViewBolesti.Items.Clear();
                foreach (var bolest in value)
                {
                    ListViewItem it = new ListViewItem(new string[] { bolest.Naziv });
                    it.Tag = bolest;
                    listViewBolesti.Items.Add(it);
                }
                listViewBolesti.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listViewBolesti.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
        public List<Lijek> Lijekovi { get => (List<Lijek>)listViewLijekovi.Tag; set
            {
                listViewLijekovi.Tag = value;
                listViewLijekovi.Items.Clear();
                foreach (var lijek in value)
                {
                    ListViewItem it = new ListViewItem(new string[] { lijek.Naziv });
                    it.Tag = lijek;
                    listViewLijekovi.Items.Add(it);
                }
                listViewLijekovi.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listViewLijekovi.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        public string InterakcijaUpozorenje { get => "";
            set
            {
                if (value.Length == 0)
                {
                    labelUpozorenje.Visible = false;
                    return;
                }
                labelUpozorenje.Visible = true;
                toolTip1.SetToolTip(labelUpozorenje, value);
            } }

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
           
            var selected = (Bolest)listViewBolesti.SelectedItems[0].Tag;
            Presenter.IzbrisiIzDijagnoze(selected);
        }

        private void listBoxBolesti_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewBolesti.SelectedItems.Count == 0)
            {
                buttonObrisiBolest.Enabled = false;
                return;
            }
            buttonObrisiBolest.Enabled = true;
            
        }

        private void buttonLijek_Click(object sender, EventArgs e)
        {
            Presenter.DodajTerapiju();

        }

        private void buttonObrisiLijek_Click(object sender, EventArgs e)
        {
            var selected = (Lijek)listViewLijekovi.SelectedItems[0].Tag;
            Presenter.IzbrisiIzTerapije(selected);
        }

        private void listBoxLijekovi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewLijekovi.SelectedItems.Count == 0)
            {
                buttonObrisiLijek.Enabled = false;
                return;
            }
            buttonObrisiLijek.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Zivotinja == null)
            {
                var result = MessageBox.Show("Niste odabrali životinju. Morate odabrati životinju.", "Greška",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                    return;
            }
            var vrsta = (VrstaPostupka)comboBoxVrstePostupaka.SelectedItem;

            if (vrsta == null)
            {
                var result = MessageBox.Show("Nemate dodane vrste postupaka koje obavljate. Dodajte nove vrste prije obavljanja postupka.", "Greška",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                    return;
            }

            if (labelUpozorenje.Visible)
            {
                var result = MessageBox.Show("Postoje interakcije među odabranim lijekovima.\nJeste li sigurni da želite odabrati te lijekove?", "Interakcije među lijekovima",
                                 MessageBoxButtons.OKCancel,
                                 MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                    return;
            }
//            var vrsta = (VrstaPostupka)comboBoxVrstePostupaka.SelectedItem;
            var napomena = richTextBox1.Text;
            Presenter.NoviPostupak(Zivotinja, vrsta, Lijekovi, Bolesti, napomena);
            Presenter.CloseUnitOfWork();
            this.Close();
            MessageBox.Show("Postupak dodan.", "Postupak dodan", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonPovijest_Click(object sender, EventArgs e)
        {
            Presenter.PovijestZivotinje(Zivotinja);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Presenter.CloseUnitOfWork();
            Close();
        }
    }
}
