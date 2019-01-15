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
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();

            GlavniForm view = new GlavniForm();

            view.Show();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();

            ListView.SelectedListViewItemCollection items = listView1.SelectedItems;
            ListViewItem lvItem = items[0];
            Lijek lijek = (Lijek)lvItem.Tag;

            DetaljiOLijekuForm view = new DetaljiOLijekuForm(lijek);

            var presenter = new DetaljiOLijekuPresenter(view, new LijekoviRepository());

            view.Show();

        }
    }
}
