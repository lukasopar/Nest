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
    public partial class PreuzimanjeRacunaForm : Form, IPreuzimanjeRacunaView
    {
        public PreuzimanjeRacunaForm()
        {
            InitializeComponent();
        }

        public List<Racun> Racuni { get => (List<Racun>)listView1.Tag;
            set
            {
                foreach (var racun in value)
                {
                    ListViewItem it = new ListViewItem(new string[] { racun.Datum.ToString("dd/MM/yyyy HH:ss"), racun.IzracunajUkupnuCijenu()+"" });
                    it.Tag = racun;
                    listView1.Items.Add(it);
                }
            } }
        public PreuzimanjeRacunaPresenter Presenter { private get; set; }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                groupBox2.Visible = false;
                button1.Enabled = false;
                return;
            }
            groupBox2.Visible = true;
            button1.Enabled = true;

            listView2.Items.Clear();

            var racun = (Racun)listView1.SelectedItems[0].Tag;
            listView2.Tag = racun;
            foreach (var postupak in racun.Postupaks)
            {
                ListViewItem it = new ListViewItem(new string[] { postupak.VrstaPostupka.Naziv, postupak.VrstaPostupka.Cijena+ "", "1" });
                it.Tag = postupak;
                listView2.Items.Add(it);
            }
            foreach (var stavka in racun.LijekStavkaRacunas)
            {
                ListViewItem it = new ListViewItem(new string[] { stavka.LijekKodVeterinara.Lijek.Naziv, stavka.LijekKodVeterinara.Cijena + "", stavka.Kolicina+"" });
                it.Tag = stavka;
                listView2.Items.Add(it);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var racun = (Racun)listView2.Tag;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\";
            sfd.RestoreDirectory = true;
            sfd.FileName = "racun-"+ racun.Datum.ToString("dd.MM.yyyy HH-mm-ss")+".pdf";
            sfd.DefaultExt = "pdf";
            sfd.Filter = "pdf files (*.pdf)|*.pdf";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                var path = Path.GetFullPath(sfd.FileName);
                Presenter.PreuzmiPDF(racun, path);
            }
            
        }
    }
}
