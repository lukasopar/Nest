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
        public ZivotinjaForm()
        {
            InitializeComponent();
        }



        private void textBox3_Leave(object sender, EventArgs e)
        {
            Presenter.UpdateVlasnikList(textBox3.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean valid = true;
            var zivotinja = new Zivotinja();
            zivotinja.Id = new Guid();
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
            if (comboBox2.SelectedIndex != -1)
            {
                label11.Text = "Ovo polje je obavezno";
                valid = false;
            }
            else label11.Text = " ";
            if (!valid) return;

            zivotinja.Ime = textBox1.Text;
            zivotinja.DatumRod = dateTimePicker1.Value;
            zivotinja.Napomena = textBox3.Text;
            zivotinja.Vlasnik = (Vlasnik)comboBox1.SelectedItem;
            zivotinja.Napomena = textBox2.Text;

            Presenter.RegistrirajZivotinju(zivotinja);

            this.Close();

            GlavniForm form = new GlavniForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

            GlavniForm form = new GlavniForm();
            form.Show();
        }
    }
}
