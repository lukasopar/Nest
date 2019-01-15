using DesktopFOrms.Presenters;
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
    public partial class BolestForm : Form, IBolestiView
    {
        public BolestForm()
        {
            InitializeComponent();
            //button1.Enabled = false;
        }
        public BolestiPresenter Presenter { private get; set; }
        public IList<Bolest> Bolesti
        {
            get
            {
                var l = new List<Bolest>();

                return l;
            }
            set
            {
                listView1.Items.Clear();
                foreach (var bolest in value)
                {
                    ListViewItem it = new ListViewItem(new string[] { bolest.Naziv, bolest.Opis });
                    it.Tag = bolest;
                    listView1.Items.Add(it);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selected = listView1.SelectedItems[0].Tag;
            if (selected == null) return;
            Presenter.DetaljiBolest((Bolest)selected);
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listView1.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;

            if (item != null)
            {
                var selected = listView1.SelectedItems[0].Tag;
                if (selected == null) return;
                Presenter.DetaljiBolest((Bolest)selected);
            }
            else
            {

            }
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            Presenter.UpdateBolestiListView(textBox1.Text);
        }
    }
}
