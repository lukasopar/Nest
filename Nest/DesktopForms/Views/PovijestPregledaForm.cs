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

namespace DesktopFOrms.Views
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

        public PostupakPresenter Presenter { private get;  set; }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                groupBox1.Visible = false;
                return;
            }
            groupBox1.Visible = true;
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
    }
}
