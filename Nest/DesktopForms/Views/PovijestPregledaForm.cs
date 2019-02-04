using DesktopForms.Presenters;
using DesktopForms.ViewInterfaces;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        public List<Postupak> Postupci { get => (List<Postupak>)listView1.Tag;
            set
            {
                groupBox1.Visible = false;
                listView1.Items.Clear();
                listView1.Tag = value;
                foreach(var postupak in value)
                {
                    ListViewItem it = new ListViewItem(new string[] {postupak.Datum.Value.ToString("dd/MM/yyyy HH:ss"), postupak.VrstaPostupka.Naziv, postupak.Zivotinja.Ime });
                    it.Tag = postupak;
                    listView1.Items.Add(it);
                }
            } }

        public RacunPresenter Presenter { private get; set; }
        public IzvjestajiPresenter PresenterIzvjestaji { private get; set; }
        public bool Dodavanje { get => buttonDodaj.Visible; set => buttonDodaj.Visible = value; }
        public bool Izvjestaj { get => buttonIzvjestaj.Visible; set { buttonIzvjestaj.Visible = value; ; dateTimePicker1.Visible = value; } }
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
            //Presenter.CloseUnitOfWork();
            Close();
            MessageBox.Show("Dodano na račun.", "Dodano", MessageBoxButtons.OK);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            PresenterIzvjestaji.NapuniView(dateTimePicker1.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (Presenter != null) Presenter.CloseUnitOfWork();
            if (PresenterIzvjestaji != null) PresenterIzvjestaji.CloseUnitOfWork();
            Close();
        }

        private void buttonIzvjestaj_Click(object sender, EventArgs e)
        {
            var datum = dateTimePicker1.Value;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\";
            sfd.RestoreDirectory = true;
            sfd.FileName = "izvjestaj-" + datum.ToString("dd.MM.yyyy") + ".pdf";
            sfd.DefaultExt = "pdf";
            sfd.Filter = "pdf files (*.pdf)|*.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var path = Path.GetFullPath(sfd.FileName);
                PresenterIzvjestaji.Izvjestaj((List<Postupak>)listView1.Tag, datum ,path);
            }
        }
    }
}
