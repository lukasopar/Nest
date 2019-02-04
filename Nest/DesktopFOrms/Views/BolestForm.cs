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
    public partial class BolestForm : Form, IBolestiView
    {
        public BolestForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

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
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            }
        }

        public bool Dijagnoza { get => button1.Visible; set { button1.Visible = value;  listView1.MultiSelect = value; } }

        private void button1_Click(object sender, EventArgs e)
        {
            int number = listView1.SelectedItems.Count;
            List<Bolest> lista = new List<Bolest>();
            for (int i = 0; i < number; i++)
                lista.Add((Bolest)listView1.SelectedItems[i].Tag);
            Presenter.DodanaDijagnoza(lista);
            //Presenter.CloseUnitOfWork();
            Close();
            MessageBox.Show("Dodano u dijagnozu.", "Dodano", MessageBoxButtons.OK);

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

        private void button2_Click(object sender, EventArgs e)
        {
            if(!Dijagnoza) 
                Presenter.CloseUnitOfWork();
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count == 0)
            {
                button1.Enabled = false;
            }
            button1.Enabled = true;
        }
    }
}
