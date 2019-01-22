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
    public partial class PovijestPregledaForm : Form, IPovijestPregledaView
    {
        public PovijestPregledaForm()
        {
            InitializeComponent();
        }

        public List<Postupak> Postupci { get => null;
            set
            {
                foreach(var postupak in value)
                {
                    ListViewItem it = new ListViewItem(new string[] {postupak.Datum.Value.ToString("dd/MM/yyyy HH:ss"), postupak.VrstaPostupka.Naziv, postupak.Zivotinja.Ime });
                    it.Tag = postupak;
                    listView1.Items.Add(it);
                }
            } }

        public RacunPresenter Presenter { private get; set; }
        public bool Dodavanje { get => buttonDodaj.Visible; set => buttonDodaj.Visible = value; }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                groupBox1.Visible = false;
                buttonDodaj.Enabled = false;
                return;
            }
            groupBox1.Visible = true;
            buttonDodaj.Enabled = true;

            var postupak = (Postupak)listView1.SelectedItems[0].Tag;
            labelZiv.Text = postupak.Zivotinja.Ime;
            labelZiv.Visible = true;
            labelPostupak.Text = postupak.VrstaPostupka.Naziv;
            labelPostupak.Visible = true;
            richTextBox1.Text = postupak.Opaska;
            richTextBox2.Text = postupak.VrstaPostupka.Opis;
            listBoxTerapija.DataSource = postupak.Lijeks.ToList();
            listBoxTerapija.DisplayMember = "Naziv";
            listBoxDijagnoza.DataSource = postupak.Bolests.ToList();
            listBoxDijagnoza.DisplayMember = "Naziv";

        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            int number = listView1.SelectedItems.Count;
            List<Postupak> lista = new List<Postupak>();
            for (int i = 0; i < number; i++)
                lista.Add((Postupak)listView1.SelectedItems[i].Tag);
            Presenter.DodaniPostupci(lista);
            Close();
            MessageBox.Show("Dodano na račun.", "Dodano", MessageBoxButtons.OK);
        }
    }
}
