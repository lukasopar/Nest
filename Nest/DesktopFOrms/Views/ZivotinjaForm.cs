using DatabaseBootstrap.Repositories;
using DesktopForms.Presenters;
using DesktopForms.ViewInterfaces;
using Model;
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
    public partial class ZivotinjaForm : Form, IZivotinjaView
    {

        public ZivotinjaPresenter Presenter { private get; set; }

        public IList<Vlasnik> Vlasnici
        {
            get
            {
                var l = new List<Vlasnik>();
                return l;
            }
            set
            {
                comboBox1.DataSource = value;
                comboBox1.DisplayMember = "KorisnickoIme";
            }
        }

        public IList<VrstaZivotinje> VrsteZivotinja { set{
                comboBox2.DataSource = value;
                comboBox2.DisplayMember = "Vrsta";

            } }

        public ZivotinjaForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }



        private void textBox3_Leave(object sender, EventArgs e)
        {
            Presenter.UpdateVlasnikList(textBox3.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean valid = true;
            if (textBox1.Text.Equals(""))
            {
                label9.Text = "Ovo polje je obavezno";
                valid = false;
            }
            else label9.Text = " ";
            if (textBox2.Text.Equals(""))
            {
                label10.Text = "Ovo polje je obavezno";
                valid = false;
            }
            else label10.Text = " ";
            if (comboBox1.SelectedIndex == -1)
            {
                label8.Text = "Ovo polje je obavezno";
                valid = false;
            }
            else label8.Text = " ";
            if (comboBox2.SelectedIndex == -1)
            {
                label11.Text = "Ovo polje je obavezno";
                valid = false;
            }
            else label11.Text = " ";
            if (!valid) return;

            Vlasnik vlasnik = (Vlasnik)comboBox1.SelectedItem;
            Zivotinja zivotinja = ModelFactory.CreateZivotinja(vlasnik, textBox1.Text, dateTimePicker1.Value, textBox2.Text);
            
            Presenter.UpdateVlasnik(vlasnik, zivotinja);
            Presenter.RegistrirajZivotinju(zivotinja);

            Presenter.CloseUnitOfWork();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Presenter.CloseUnitOfWork();
            this.Close();
        }
    }
}
