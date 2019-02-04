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
    public partial class PridruziZivotinjuForm : Form, IPridruziZivotinjuView
    {
        public PridruziZivotinjuForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        public IList<Vlasnik> Vlasnici {
            get
            {
                var l = new List<Vlasnik>();

                return l;
            }
            set
            {
                listView1.Items.Clear();
                foreach (var vlasnik in value)
                {
                    ListViewItem it = new ListViewItem(new string[] { vlasnik.Ime, vlasnik.Prezime, vlasnik.DatumRod.HasValue?vlasnik.DatumRod.Value.Date.ToString():"" });
                    it.Tag = vlasnik;
                    listView1.Items.Add(it);
                }
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
        public PridruziZivotinjuPresenter Presenter { private get; set; }
        public IList<VrstaZivotinje> VrsteZivotinja { get => null;
            set
            {
                comboBox1.DataSource = value;
                comboBox1.DisplayMember = "Vrsta";

            } }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            Presenter.UpdateVlasnikListView(textBoxFilter.Text);
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            button1.Enabled = false;
            if (listView1.SelectedItems.Count == 0)
            {
                listView2.Items.Clear();
                return;
            }
            var vlasnik = (Vlasnik)listView1.SelectedItems[0].Tag;
            Presenter.UpdateZivotinjaListView(vlasnik);
            listView2.Items.Clear();
            if (vlasnik.Zivotinjas == null || vlasnik.Zivotinjas.Count == 0)
                return;
            
            foreach (var zivotinja in vlasnik.Zivotinjas)
            {
                ListViewItem it = new ListViewItem(zivotinja.Ime);
                it.Tag = zivotinja;
                listView2.Items.Add(it);
            }
            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 0)
            {
                groupBox3.Visible = false;
                button1.Enabled = false;
                return;
            }
            groupBox3.Visible = true;
            button1.Enabled = true;
            var zivotinja = (Zivotinja)listView2.SelectedItems[0].Tag;
            groupBox3.Tag = zivotinja;
            //Presenter.UpdateZivotinjaListView(vlasnik);
            labelIme.Text = zivotinja.Ime;
            labelNapomena.Text = zivotinja.Napomena;
            labelVlasnik.Text = zivotinja.Vlasnik.Ime + " " + zivotinja.Vlasnik.Prezime;
            var result = Presenter.OdabranaZivotinja(zivotinja);
            if (result == null)
            {
                label6.Visible = false;
                comboBox1.Visible = true;
                label8.Visible = true;
            }
            else
            {
                label6.Visible = true;
                label6.Text = result.Vrsta;
                comboBox1.Visible = false;
                label8.Visible = false;
            }
        }

        private void buttonOdustani_Click(object sender, EventArgs e)
        {
            Presenter.CloseUnitOfWork();
            this.Close();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            
                VrstaZivotinje vrsta = null;
                if (comboBox1.Visible)
                {
                    vrsta = (VrstaZivotinje)comboBox1.SelectedItem;
                }
                Presenter.Spremi((Zivotinja)groupBox3.Tag, vrsta);
                Presenter.CloseUnitOfWork();
                this.Close();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
