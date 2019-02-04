using DatabaseBootstrap.Repositories;
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

        private readonly string DEFAULT_TEXT = "Detalji o lijeku: ";
        private Lijek _lijek;

        public DetaljiOLijekuForm(Lijek lijek)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Lijek = lijek;
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
                listView2.Items.Clear();
                foreach (var bolest in value)
                {
                    ListViewItem it = new ListViewItem(new string[] { bolest.Naziv, bolest.Opis });
                    it.Tag = bolest;
                    listView2.Items.Add(it);
                }
                listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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
                listView1.Items.Clear();
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
                    listView1.Items.Add(it);
                }
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        public Lijek Lijek {
            get { return _lijek; }
            set
            {
                _lijek = value;
                label4.Text = DEFAULT_TEXT + " " + _lijek.Naziv;
            }
        }

        public DetaljiOLijekuPresenter Presenter { private get; set; }

        private void label4_Click(object sender, EventArgs e)
        {
            Presenter.CloseUnitOfWork();
            this.Close();

           // LijekoviForm view = new LijekoviForm();

          //  var presenter = new LijekoviPresenter(view, new LijekoviRepository());

           // view.Show();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView.SelectedListViewItemCollection items = listView1.SelectedItems;
            ListViewItem lvItem = items[0];
            Lijek lijek = (Lijek)lvItem.Tag;

            Presenter.UpdateLijek(lijek);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Presenter.CloseUnitOfWork();
            Close();
        }
        
    }
}
