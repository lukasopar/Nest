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
    public partial class DetaljiOLijekuForm : Form, IDetaljiOLijekuView
    {
        private Lijek _lijek;

        public DetaljiOLijekuForm(Lijek lijek)
        {
            InitializeComponent();
            _lijek = lijek;
        }

        public IList<Bolest> Bolesti
        {
            get
            {
                var l = new List<Bolest>();

                return l;
            }
            set
            {
                foreach (var bolest in value)
                {
                    ListViewItem it = new ListViewItem(new string[] { bolest.Naziv, bolest.Opis });
                    it.Tag = bolest;
                    listView1.Items.Add(it);
                }
            }
        }
        public IList<InterakcijaLijekova> Interakcije
        {
            get
            {
                var l = new List<InterakcijaLijekova>();

                return l;
            }
            set
            {
                foreach (var interakcija in value)
                {
                    ListViewItem it;
                    if (interakcija.Lijek1.Id.Equals(Lijek.Id))
                    {
                        it = new ListViewItem(new string[] { interakcija.Lijek2.Naziv, interakcija.Opis });
                        it.Tag = interakcija.Lijek2;
                    }
                    else
                    {
                        it = new ListViewItem(new string[] { interakcija.Lijek1.Naziv, interakcija.Opis });
                        it.Tag = interakcija.Lijek1;
                    }
                    listView2.Items.Add(it);
                }
            }
        }

        public Lijek Lijek {
            get { return _lijek; }
            set
            {
                _lijek = value;
            }
        }

        public DetaljiOLijekuPresenter Presenter { private get; set; }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = listView1.SelectedItems;
            ListViewItem lvItem = items[0];
            Lijek lijek = (Lijek)lvItem.Tag;

            Presenter.UpdateLijek(lijek);
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //prebaci se na stranicu s tom bolesti
            ListView.SelectedListViewItemCollection items = listView1.SelectedItems;
            ListViewItem lvItem = items[0];
            Bolest lijek = (Bolest)lvItem.Tag;
        }
    }
}
