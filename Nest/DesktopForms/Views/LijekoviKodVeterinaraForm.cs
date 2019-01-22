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
    public partial class LijekoviKodVeterinaraForm : Form, ILijekoviKodVeterinaraView
    {
        public LijekoviKodVeterinaraForm()
        {
            InitializeComponent();
        }

        public List<LijekKodVeterinara> Lijekovi
        {
            get => (List<LijekKodVeterinara>)listView1.Tag;
            set
            {
                listView1.Tag = value;
                foreach (var lijek in value)
                {
                    ListViewItem it = new ListViewItem(new string[] { lijek.Lijek.Naziv, lijek.Cijena+"", lijek.Napomena });
                    it.Tag = lijek;
                    listView1.Items.Add(it);
                }
            }
        }
        public RacunPresenter Presenter { private get; set; }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                buttonDodaj.Enabled = false;
                return;
            }
            buttonDodaj.Enabled = true;
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            int number = listView1.SelectedItems.Count;
            List<LijekKodVeterinara> lista = new List<LijekKodVeterinara>();
            for (int i = 0; i < number; i++)
                lista.Add((LijekKodVeterinara)listView1.SelectedItems[i].Tag);
            Presenter.DodaniLijekovi(lista);
            Close();
            MessageBox.Show("Dodano na račun.", "Dodano", MessageBoxButtons.OK);
        }
    }
}
