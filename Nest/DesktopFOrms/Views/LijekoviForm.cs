using DatabaseBootstrap;
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
    public partial class LijekoviForm : Form, ILijekoviView
    {
        public LijekoviForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            
        }


        public LijekoviPresenter Presenter { private get; set; }
        public IList<Lijek> Lijekovi
        {
            get {
                var l = new List<Lijek>();
                
                return l;
            }
            set
            {
                foreach (var lijek in value)
                {
                    ListViewItem it = new ListViewItem(new string[] { lijek.Naziv, lijek.Opis});
                    it.Tag = lijek;
                    listView1.Items.Add(it);
                }
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        public bool Terapija { get => buttonDodajTerapiju.Visible; set { buttonDodajTerapiju.Visible = value; listView1.MultiSelect = value; } }

       

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            //this.Close();

            ListView.SelectedListViewItemCollection items = listView1.SelectedItems;
            ListViewItem lvItem = items[0];
            Lijek lijek = (Lijek)lvItem.Tag;

            DetaljiOLijekuForm view = new DetaljiOLijekuForm(lijek);

            var presenter = new DetaljiOLijekuPresenter(view, new UnitOfWork());

            view.Show();

        }

        private void buttonOdustani_Click(object sender, EventArgs e)
        {
            Presenter.CloseUnitOfWork();
            Close();
        }

        private void buttonDodajTerapiju_Click(object sender, EventArgs e)
        {
            int number = listView1.SelectedItems.Count;
            List<Lijek> lista = new List<Lijek>();
            for (int i = 0; i < number; i++)
                lista.Add((Lijek)listView1.SelectedItems[i].Tag);
            Presenter.DodanaTerapija(lista);
            //Presenter.CloseUnitOfWork();
            Close();
            MessageBox.Show("Dodano u terapiju.", "Dodano", MessageBoxButtons.OK);
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                buttonDodajTerapiju.Enabled = false;
            }
            buttonDodajTerapiju.Enabled = true;
        }
    }
}
