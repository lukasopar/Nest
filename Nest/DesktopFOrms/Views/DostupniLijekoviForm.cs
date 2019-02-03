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
        }

        public IList<LijekKodVeterinara> LijekoviKodVeterinara {
            set
            {
                foreach (var dostupniLijek in value)
                {
                    ListViewItem it = new ListViewItem(new string[] { dostupniLijek.Lijek.Naziv, dostupniLijek.Lijek.Opis });
                    it.Tag = dostupniLijek;
                    listView1.Items.Add(it);
                }
                listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }


        public IList<Lijek> Lijekovi { set {
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
            catch (FormatException exc)
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
