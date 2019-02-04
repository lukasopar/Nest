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
    public partial class DostupniLijekoviForm : Form, IDostupniLijekovi
    {
        public DostupniLijekoviForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        public IList<LijekKodVeterinara> LijekoviKodVeterinara {
            set
            {
                listView2.Items.Clear();
                foreach (var dostupniLijek in value)
                {
                    ListViewItem it = new ListViewItem(new string[] { dostupniLijek.Lijek.Naziv, dostupniLijek.Lijek.Opis, dostupniLijek.Cijena.ToString() });
                    it.Tag = dostupniLijek;
                    listView2.Items.Add(it);
                }
                listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }


        public IList<Lijek> Lijekovi { set {
                listView1.Items.Clear();
                foreach (var lijek in value)
                {
                    ListViewItem it = new ListViewItem(new string[] { lijek.Naziv, lijek.Opis });
                    it.Tag = lijek;
                    listView1.Items.Add(it);
                }
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
        public DostupniLijekoviPresenter Presenter { private get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = listView1.SelectedItems;
            if (items.Count == 0) return;
            double number;
            try
            {
                number = Math.Round(Double.Parse(textBox1.Text), 2);
            }
            catch (FormatException)
            {
                label10.Text = "Cijena lijeka je obavezna!";
                return;
            }
            ListViewItem lvItem = items[0];
            Lijek lijek = (Lijek)lvItem.Tag;
            label10.Text = "";
            Presenter.DodajLijekVeterinaru(lijek, number, richTextBox1.Text);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = listView2.SelectedItems;
            if (items.Count == 0) return;
            ListViewItem lvItem = items[0];
            LijekKodVeterinara lijek = (LijekKodVeterinara)lvItem.Tag;

            Presenter.IzbrisiLijekKodVeterinara(lijek);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Presenter.CloseUnitOfWork();
            this.Close();
        }

        public void Update(Lijek entity, bool state)
        {
            if (state == true)
            {
                ListViewItem it = new ListViewItem(new string[] { entity.Naziv, entity.Opis });
                it.Tag = entity;
                listView1.Items.Add(it);
            }
            else
            {
                int i = 0;
                for (i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Tag.Equals(entity)) break;
                }
                if (i == listView1.Items.Count) ;
                else
                {
                    listView1.Items.RemoveAt(i);
                }
            }
        }

        public void Update(LijekKodVeterinara entity, bool state)
        {
            if (state == true)
            {
                ListViewItem it = new ListViewItem(new string[] { entity.Lijek.Naziv, entity.Lijek.Opis, entity.Cijena.ToString() });
                it.Tag = entity;
                listView2.Items.Add(it);
            }
            else
            {
                int i = 0;
                for (i = 0; i < listView2.Items.Count; i++)
                {
                    if (listView2.Items[i].Tag.Equals(entity)) break;
                }
                if (i == listView2.Items.Count) ;
                else
                {
                    listView2.Items.RemoveAt(i);
                }
            }
        }
    }
}
