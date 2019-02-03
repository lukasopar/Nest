using DesktopForms.Presenters;
using DesktopForms.ViewInterfaces;
using Nest.Model.Domain;
using System.Collections.Generic;
using DatabaseBootstrap.Observer;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;

namespace DesktopForms.Views
{
    public partial class AdministracijaForm : Form, IAdministracijaView
    {
        AdministracijaPresenter _presenter;

        public AdministracijaForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        public IList<VrstaZivotinje> Vrste { set {
                listView2.Items.Clear();
                foreach (var vrsta in value)
                {
                    ListViewItem it = new ListViewItem(new string[] { vrsta.Vrsta });
                    it.Tag = vrsta;
                    listView2.Items.Add(it);
                }
                listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            } }
        public IList<VrstaPostupka> Postupci { set {
                listView1.Items.Clear();
                foreach (var vrstaPostupka in value)
                {
                    ListViewItem it = new ListViewItem(new string[] { vrstaPostupka.Naziv, vrstaPostupka.Opis, vrstaPostupka.Cijena.ToString() });
                    it.Tag = vrstaPostupka;
                    listView1.Items.Add(it);
                }
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            } }

        public AdministracijaPresenter Presenter { set => _presenter = value; }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Equals(""))
            {
                label7.Text = "Ovo polje je obavezno!";
                return;
            }
            else label7.Text = "";

            _presenter.DodajVrstu(textBox4.Text);
            textBox4.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 0) return;

            ListView.SelectedListViewItemCollection items = listView2.SelectedItems;
            ListViewItem lvItem = items[0];
            VrstaZivotinje vrsta = (VrstaZivotinje)lvItem.Tag;
            _presenter.IzbrisiVrstuZivotinje(vrsta);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean valid = true;
            double cijena = 0;
            if (textBox1.Text.Equals(""))
            {
                label8.Text = "Ovo polje je obavezno";
                valid = false;
            }
            else label8.Text = " ";
            if (textBox2.Text.Equals(""))
            {
                label9.Text = "Ovo polje je obavezno";
                valid = false;
            }
            else label9.Text = " ";
            if (textBox3.Text.Equals(""))
            {
                label10.Text = "Ovo polje je obavezno";
                valid = false;
            }
            else {
                try
                {
                    cijena = Double.Parse(textBox3.Text);
                } catch(FormatException exc)
                {
                    label10.Text = "Cijena je broj.";
                    valid = false;
                }
            }
            if (!valid) return;

            _presenter.DodajVrstuPostupka(textBox1.Text, textBox2.Text, Math.Round(cijena, 2));
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            ListView.SelectedListViewItemCollection items = listView1.SelectedItems;
            ListViewItem lvItem = items[0];
            VrstaPostupka vrsta = (VrstaPostupka)lvItem.Tag;
            _presenter.IzbrisiVrstuPostupka(vrsta);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _presenter.CloseUnitOfWork();

            this.Close();
        }

        public void Update(VrstaZivotinje entity, bool state)
        {
            if(state == true)
            {
                ListViewItem it = new ListViewItem(new string[] { entity.Vrsta });
                it.Tag = entity;
                listView2.Items.Add(it);
            } else
            {
                int i = 0;
                for (i = 0; i < listView2.Items.Count; i++)
                {
                    if (listView2.Items[i].Tag.Equals(entity)) break;
                }
                if (i == listView2.Items.Count);
                else
                {
                    listView2.Items.RemoveAt(i);
                }
            }
        }

        public void Update(VrstaPostupka entity, bool state)
        {
            if(state == true)
            {
                ListViewItem it = new ListViewItem(new string[] { entity.Naziv, entity.Opis, entity.Cijena.ToString() });
                it.Tag = entity;
                listView1.Items.Add(it);
            } else
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
    }
}
